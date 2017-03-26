/* todo: when finished, move this back into LibFirePro */

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;

namespace FPRLogoViewer
{
	/// <summary>
	/// Fire Pro Wrestling Returns Logo data.
	/// </summary>
	public class LogoData
	{
		/// <summary>
		/// Error codes for GIF conversion.
		/// </summary>
		enum GifErrorCode
		{
			/// <summary>
			/// No errors.
			/// </summary>
			NoError = 0,

			/// <summary>
			/// Unable to open GIF file. Odd...
			/// </summary>
			UnableToOpen = 1,

			/// <summary>
			/// Wrong pixel format. (Image must be 8bpp indexed.)
			/// </summary>
			WrongPixelFormat = 2,

			/// <summary>
			/// Wrong image size. (Image must be 128x128 pixels.)
			/// </summary>
			WrongImageSize = 3,

			/// <summary>
			/// Image uses more than 64 colors. (Logo palette is limited to 64 colors.)
			/// </summary>
			TooManyColors = 4,

			/// <summary>
			/// Unable to re-map color.
			/// </summary>
			CantRemapColor = 5,

			/// <summary>
			/// An error that doesn't exist. This should never happen.
			/// </summary>
			UndefinedError
		}

		#region Class Members
		/// <summary>
		/// Defines if this logo slot is active.
		/// </summary>
		public bool SlotUsed;

		/// <summary>
		/// Image header data (typically skipped)
		/// </summary>
		public byte[] HeaderData = new byte[0x10];

		/// <summary>
		/// Palette for this logo.
		/// </summary>
		public Color[] PaletteData;

		/// <summary>
		/// Pixel data for this logo.
		/// </summary>
		public byte[] PixelData;

		/// <summary>
		/// Bitmap object for this logo.
		/// </summary>
		public Bitmap LogoBitmap;

		#region GIF Conversion Members
		/// <summary>
		/// Color palette from imported GIF files.
		/// </summary>
		public Color[] GifPalette = new Color[256];

		/// <summary>
		/// Track the use of palette indices in GIF files.
		/// </summary>
		public bool[] GifPaletteUsage = new bool[256];

		/// <summary>
		/// Does this GIF require palette re-indexing?
		/// </summary>
		protected bool GifRequiresPaletteReindex = false;

		/// <summary>
		/// Is this a transparent GIF?
		/// </summary>
		private bool GifHasTransparency = false;

		/// <summary>
		/// Index of transparent color in GIF file.
		/// </summary>
		protected byte GifTransparentIndex;
		#endregion

		#endregion

		/// <summary>
		/// Default constructor.
		/// </summary>
		public LogoData() {
			this.SlotUsed = false;
			this.PaletteData = new Color[64];
			this.PixelData = new byte[128 * 128];
			this.LogoBitmap = new Bitmap(128, 128);

			for (int i = 0; i < this.HeaderData.Length; i++ ) {
				this.HeaderData[i] = 0;
			}
		}

		#region Loading Routines
		/// <summary>
		/// Load logo data from a raw logo rip.
		/// </summary>
		/// <param name="path">File path to raw logo data.</param>
		public void Load_RawFile(string path) {
			FileStream fs = new FileStream(path, FileMode.Open);
			BinaryReader br = new BinaryReader(fs);

			br.BaseStream.Seek(0, SeekOrigin.Begin);
			this.HeaderData = br.ReadBytes(0x10);
			this.SlotUsed = (this.HeaderData[0] == 1);
			ReadPalette(br);
			ReadPixelData(br);
			br.Close();
			UpdateBitmap();
		}

		/// <summary>
		/// Loads logo data from memory.
		/// </summary>
		/// <param name="logoData">Raw logo data</param>
		public void Load_Memory(byte[] logoData) {
			MemoryStream ms = new MemoryStream(logoData);
			BinaryReader br = new BinaryReader(ms);

			br.BaseStream.Seek(0, SeekOrigin.Begin);
			this.HeaderData = br.ReadBytes(0x10);
			this.SlotUsed = (this.HeaderData[0] == 1);
			ReadPalette(br);
			ReadPixelData(br);
			br.Close();
			UpdateBitmap();
		}
		#endregion

		#region Saving Routines
		/// <summary>
		/// Saves raw Fire Pro Returns logo data to a file.
		/// </summary>
		/// <param name="path">Path to new filename.</param>
		public void SaveFile_RawLogo(string path) {
			FileStream fs = new FileStream(path, FileMode.OpenOrCreate);
			BinaryWriter bw = new BinaryWriter(fs);

			this.HeaderData[0x00] = 1; // set logo slot as used
			bw.Write(ToRawLogoData());

			bw.Flush();
			bw.Close();
		}

		/// <summary>
		/// Saves logo as a PNG file.
		/// </summary>
		/// <param name="path">Path to logo PNG file.</param>
		public void SaveFile_PNG(string path) {
			UpdateBitmap();
			this.LogoBitmap.Save(path, ImageFormat.Png);
		}
		#endregion

		#region Palette-related Routines
		/// <summary>
		/// Helper routine for reading a partial chunk (8 colors) of the palette.
		/// </summary>
		/// <param name="_br">BinaryReader instance loaded with Logo data.</param>
		/// <param name="_start">Start index in palette</param>
		private void ReadPaletteSection(BinaryReader _br, int _start) {
			byte[] tempData = new byte[4];
			for (int i = _start; i < _start + 8; i++) {
				tempData = _br.ReadBytes(4);
				// multiply alpha by 2; an assumption that may not be true...
				tempData[3] = (byte)Math.Min((int)((tempData[3] + 1) * 2), 255);
				this.PaletteData[i] = Color.FromArgb(tempData[3], tempData[0], tempData[1], tempData[2]);
			}
		}

		/// <summary>
		/// Helper routine for writing a partial chunk (8 colors) of the palette.
		/// </summary>
		/// <param name="_bw">BinaryWriter instance prepared to write Logo data.</param>
		/// <param name="_start">Start index in palette</param>
		private void WritePaletteSection(BinaryWriter _bw, int _start) {
			for (int i = _start; i < _start + 8; i++) {
				_bw.Write((byte)this.PaletteData[i].R); // red
				_bw.Write((byte)this.PaletteData[i].G); // green
				_bw.Write((byte)this.PaletteData[i].B); // blue

				// xxx: is this conversion ok?
				if (this.PaletteData[i].A == 0xFF) {
					// full alpha
					_bw.Write((byte)0x80);
				}
				else if (this.PaletteData[i].A == 0) {
					// fully transparent/no alpha
					_bw.Write((byte)0x00);
				}
				else {
					// variable alpha
					// (this is the one I still have concerns with)
					_bw.Write((byte)((this.PaletteData[i].A / 2)-1));
				}
			}
		}

		/// <summary>
		/// Read palette data from the image.
		/// </summary>
		/// <param name="_br">BinaryReader with image data.</param>
		public void ReadPalette(BinaryReader _br) {
			_br.BaseStream.Seek(0x10, SeekOrigin.Begin);
			// 64 colors
			ReadPaletteSection(_br, 0x00);
			ReadPaletteSection(_br, 0x10);
			ReadPaletteSection(_br, 0x08);
			ReadPaletteSection(_br, 0x18);
			ReadPaletteSection(_br, 0x20);
			ReadPaletteSection(_br, 0x30);
			ReadPaletteSection(_br, 0x28);
			ReadPaletteSection(_br, 0x38);
		}

		/// <summary>
		/// Write palette data to the image.
		/// </summary>
		/// <param name="_bw">BinaryWriter for image data.</param>
		public void WritePalette(BinaryWriter _bw) {
			_bw.BaseStream.Seek(0x10, SeekOrigin.Begin);
			// 64 colors
			WritePaletteSection(_bw, 0x00);
			WritePaletteSection(_bw, 0x10);
			WritePaletteSection(_bw, 0x08);
			WritePaletteSection(_bw, 0x18);
			WritePaletteSection(_bw, 0x20);
			WritePaletteSection(_bw, 0x30);
			WritePaletteSection(_bw, 0x28);
			WritePaletteSection(_bw, 0x38);
		}
		#endregion

		#region Image Pixel Data Routines
		/// <summary>
		/// Reads the image pixel data (palette indices).
		/// </summary>
		/// <param name="_br"></param>
		public void ReadPixelData(BinaryReader _br) {
			this.PixelData = _br.ReadBytes(0x4000); // 16384; a.k.a. 128x128
		}

		/// <summary>
		/// Updates the internal Bitmap from PixelData.
		/// </summary>
		public void UpdateBitmap() {
			// xxx: this uses the slow way instead of locking and unlocking
			// but it seems ok enough? idk
			for (int y = 0; y < 128; y++) {
				for (int x = 0; x < 128; x++) {
					int pixelLoc = (y * 128) + x;
					if (this.PixelData[pixelLoc] <= 0x3F) {
						this.LogoBitmap.SetPixel(x, y, this.PaletteData[this.PixelData[pixelLoc]]);
					}
					else {
						// how to handle invalid palette indexes?
					}
				}
			}
		}

		#endregion

		#region Conversion Routines
		/// <summary>
		/// Converts from LogoData structure to raw Fire Pro Returns logo data.
		/// </summary>
		/// <returns>Logo as raw Fire Pro Returns logo data.</returns>
		public byte[] ToRawLogoData() {
			using (MemoryStream ms = new MemoryStream()) {
				using (BinaryWriter bw = new BinaryWriter(ms)) {
					ms.Seek(0, SeekOrigin.Begin);

					if (this.SlotUsed) {
						this.HeaderData[0] = 1;
					}

					bw.Write(this.HeaderData);
					WritePalette(bw);
					bw.Write(this.PixelData);
					return ms.ToArray();
				}
			}
		}

		/// <summary>
		/// Converts from GIF file to LogoData structure.
		/// </summary>
		/// <param name="path">Path to GIF file.</param>
		/// <param name="errorCode">Error code returned if unable to convert the GIF.</param>
		/// <returns>true if GIF conversion was successful, false otherwise.</returns>
		public bool FromGif(string path, out int errorCode) {
			/* clear any previous results */
			this.GifRequiresPaletteReindex = false;
			Array.Clear(this.GifPaletteUsage, 0, this.GifPaletteUsage.Length);

			// make Bitmap from gif
			Bitmap gifBitmap = new Bitmap(path);
			if(gifBitmap == null){
				errorCode = (int)GifErrorCode.UnableToOpen;
				return false;
			}

			// needs to be 8bpp indexed
			// (4bpp GIFs manage to get upgraded to 8bpp; I've tried.)
			if(gifBitmap.PixelFormat != PixelFormat.Format8bppIndexed){
				errorCode = (int)GifErrorCode.WrongPixelFormat;
				gifBitmap.Dispose();
				return false;
			}

			// check for images that aren't 128x128
			if (gifBitmap.Width != 128 || gifBitmap.Height != 128) {
				errorCode = (int)GifErrorCode.WrongImageSize;
				gifBitmap.Dispose();
				return false;
			}

			// Grab GIF palette.
			// Do not error out here if there are more than 64 entries, because
			// there are situations where using such entries can be legal.
			// Examples include:
			// 1) Image contains less than 64 colors, but with the used
			//    indices outside of 0x00-0x3F.
			// 2) Image transparent color index is outside the main
			//    palette area (indices 0x00-0x3F).
			for (int i = 0; i < gifBitmap.Palette.Entries.Length; i++) {
				this.GifPalette[i] = gifBitmap.Palette.Entries[i];
			}

			// Grab GIF pixels.
			BitmapData gifBData = gifBitmap.LockBits(new Rectangle(0, 0, gifBitmap.Width, gifBitmap.Height), ImageLockMode.ReadOnly, PixelFormat.Format8bppIndexed);
			IntPtr gifPtr = gifBData.Scan0;
			System.Runtime.InteropServices.Marshal.Copy(gifPtr, this.PixelData, 0, 128 * 128);
			gifBitmap.UnlockBits(gifBData);

			// Examine palette usage
			for (int i = 0; i < this.PixelData.Length; i++) {
				if (this.GifPaletteUsage[this.PixelData[i]] == false) {
					this.GifPaletteUsage[this.PixelData[i]] = true;
				}
			}
			int indexCount = 0;
			for (int i = 0; i < this.GifPaletteUsage.Length; i++) {
				if (this.GifPaletteUsage[i] == true) {
					indexCount++;
				}
			}
			if (indexCount > 64) {
				errorCode = (int)GifErrorCode.TooManyColors;
				gifBitmap.Dispose();
				return false;
			}

			// At this point, it seems REASONABLY safe to assume a compatible GIF
			// has been imported. These words will probably come back to haunt me.

			// handle transparency before killing the color indices
			foreach (PropertyItem prop in gifBitmap.PropertyItems) {
				if (prop.Id == 0x5104) {
					this.GifTransparentIndex = prop.Value[0];
					this.GifHasTransparency = true;
				}
			}

			// GifRequiresPaletteReindex if any indices outside of 0-63 are used.
			for (int i = 64; i < this.GifPaletteUsage.Length; i++) {
				if (this.GifPaletteUsage[i] == true) {
					this.GifRequiresPaletteReindex = true;
					break;
				}
			}

			// optional path time.
			// If GifRequiresPaletteReindex, then we need to re-index the palette.
			// This requires moving colors in the palette as well as rewriting
			// pixel data to use the new indices.
			if (this.GifRequiresPaletteReindex) {
				// start at the first "invalid" index (color 64)
				for (int slotCheck = 0x40; slotCheck < this.GifPaletteUsage.Length; slotCheck++) {
					if (this.GifPaletteUsage[slotCheck] == true) {
						int nextIndex = GetUnusedGifPalSlot(); // try to find a valid color index
						if (nextIndex != -1) {
							this.GifPaletteUsage[nextIndex] = true; // new color
							this.GifPaletteUsage[slotCheck] = false; // old color

							// copy color over to GifPalette
							this.GifPalette[nextIndex] = this.GifPalette[slotCheck];

							// ReplaceIndex(old,new) to update pixel data
							ReplaceIndex((byte)slotCheck, (byte)nextIndex);

							// update transparency if this is the transparent color
							if (this.GifHasTransparency && slotCheck == this.GifTransparentIndex) {
								this.GifTransparentIndex = (byte)nextIndex;
							}
						}
						else {
							// unable to remap color; error out
							errorCode = (int)GifErrorCode.CantRemapColor;
							return false;
						}
					}
				}
				
			}

			// by this point, the palette should be in the proper order.
			for (int i = 0; i < this.PaletteData.Length; i++) {
				this.PaletteData[i] = this.GifPalette[i];
			}

			// set transparent color, if it exists.
			if (this.GifHasTransparency) {
				this.LogoBitmap.MakeTransparent(this.PaletteData[this.GifTransparentIndex]);
			}

			// xxx: should this step be before or after MakeTransparent?
			UpdateBitmap();

			// If we've made it this far, everything went alright.
			errorCode = (int)GifErrorCode.NoError;
			return true;
		}

		#endregion

		#region GIF Helper Routines
		/// <summary>
		/// Replace all instances of a color index in PixelData with another.
		/// </summary>
		/// Despite being in the "GIF Helper Routines" section,
		/// this can be useful for non-GIF converted logos as well.
		/// <param name="find">Color index to find</param>
		/// <param name="replace">Color index to replace with</param>
		private void ReplaceIndex(byte find, byte replace) {
			for (int i = 0; i < this.PixelData.Length; i++) {
				if (this.PixelData[i] == find) {
					this.PixelData[i] = replace;
				}
			}
		}

		/// <summary>
		/// Get the first unused slot in the GIF palette.
		/// </summary>
		/// <returns>First unsed slot in GIF palette, or -1 if none found in the first 64 indices.</returns>
		private int GetUnusedGifPalSlot() {
			for (int i = 0; i < 64; i++) {
				if (this.GifPaletteUsage[i] == false) {
					return i;
				}
			}
			return -1; // no unused slot available
		}
		#endregion
	}
}
