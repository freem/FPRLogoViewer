﻿/* todo: when finished, move this back into LibFirePro */

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;

namespace FPRLogoViewer
{
	/// <summary>
	/// Fire Pro Wrestling Returns Logo data.
	/// </summary>
	class LogoData
	{
		#region Class Members
		/// <summary>
		/// Defines if this logo slot is active.
		/// </summary>
		public bool SlotUsed;

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
		#endregion

		/// <summary>
		/// Default constructor.
		/// </summary>
		public LogoData() {
			this.SlotUsed = false;
			this.PaletteData = new Color[64];
			this.PixelData = new byte[128 * 128];
			this.LogoBitmap = new Bitmap(128, 128);
		}

		#region Loading Routines
		/// <summary>
		/// Load logo data from a raw logo rip.
		/// </summary>
		/// <param name="path">File path to raw logo data.</param>
		public void LoadFromRawFile(string path) {
			FileStream fs = new FileStream(path, FileMode.Open);
			BinaryReader br = new BinaryReader(fs);

			ReadPalette(br);
			ReadPixelData(br);
			br.Close();
			UpdateBitmap();
		}

		/// <summary>
		/// Loads logo data from memory.
		/// </summary>
		/// <param name="logoData">Raw logo data</param>
		public void LoadFromMemory(byte[] logoData) {
			MemoryStream ms = new MemoryStream(logoData);
			BinaryReader br = new BinaryReader(ms);

			ReadPalette(br);
			ReadPixelData(br);
			br.Close();
			UpdateBitmap();
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
				_bw.Write((byte)0x7F); // xxx: alpha is hardcoded because I don't trust myself
			}
		}

		/// <summary>
		/// Read palette data from the image.
		/// </summary>
		/// <param name="_br"></param>
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
		/// <param name="_bw"></param>
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
			for (int y = 0; y < 128; y++) {
				for (int x = 0; x < 128; x++) {
					int pixelLoc = (y * 128) + x;
					if (this.PixelData[pixelLoc] <= 0x3F) {
						this.LogoBitmap.SetPixel(x, y, this.PaletteData[this.PixelData[pixelLoc]]);
					}
					else {
						// how to handle invalid indexes?
					}
				}
			}
		}
		#endregion
	}
}