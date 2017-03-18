﻿using System;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace FPRLogoViewer
{
	public partial class mainForm : Form
	{
		public Color[] logoPalette;
		public byte[] logoData;
		public Bitmap logoBitmap;
		public bool[] validLogos;
		public AboutBox aboutBox = new AboutBox();

		public mainForm() {
			InitializeComponent();
			logoPalette = new Color[64];
			logoData = new byte[128*128];
			logoBitmap = new Bitmap(128, 128);
			validLogos = new bool[6];

			for (int i = 0; i < validLogos.Length; i++) {
				validLogos[i] = false;
			}

			picboxLogo.BackColor = Color.FromArgb(127,0,0,0); // set partially transparent background color
			cboxColorTable.SelectedIndex = 0; // set initial index for combo box
		}

		private void menuItem_File_Exit_Click(object sender, EventArgs e) {
			this.Close();
		}

		private void menuItem_Help_About_Click(object sender, EventArgs e) {
			// who made this crap
			if (aboutBox.Visible) { aboutBox.BringToFront(); }
			aboutBox.Show();
		}

		private void menuItem_File_Open_Click(object sender, EventArgs e) {
			// open a logo item
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Title = "Select Logo File...";
			ofd.Filter = "Memory Linker|*.psu|Raw Save Data|BISLPM-66082;BASLUS-21702;BESLES-55041|Binary rips|*.bin|All Files|*.*";
			if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
				// ok cool open the file please, based on filetype
				if (ofd.FileName.EndsWith(".psu")) {
					// handle .psu FPR save
					LoadFPRSave_PSU(ofd.FileName);
				}
				else if(ofd.FileName.EndsWith(".bin")){
					// .bin = pre-ripped logo
					LoadRippedLogo(ofd.FileName);
				}
				else {
					// assume raw save file
					LoadFPRSave_Raw(ofd.FileName);
				}
			}
		}

		private void menuItem_File_Save_Click(object sender, EventArgs e) {
			// save this file as...
			SaveFileDialog sfd = new SaveFileDialog();
			sfd.Title = "Export Logo Image...";
			sfd.Filter = "PNG|*.png";
			if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
				logoBitmap.Save(sfd.FileName);
			}
		}

		/* Load .psu format save */
		private void LoadFPRSave_PSU(string inFile) {
			// reset array
			for (int i = 0; i < validLogos.Length; i++) {
				validLogos[i] = false;
			}

			// try loading save file
			FileStream saveFile = new FileStream(inFile, FileMode.Open);
			if (saveFile == null) {
				MessageBox.Show(String.Format("Unable to open {0}", inFile));
				return;
			}

			/* look for valid logos in save file */
			/* a typical logo is 16,656 bytes (0x4110). logos in .psu files start at 0xC6010 */
			for (int i = 0; i < 6; i++) {
				saveFile.Seek(0xC6010 + (i*16656), SeekOrigin.Begin);
				//read first byte; it will be 1 if a logo exists in this slot.
				validLogos[i] = saveFile.ReadByte() == 1 && true || false;
			}

			// modify entries in the selector
			LogoDialog selector = new LogoDialog();
			string s = "";
			for(int i = 0; i < 6; i++){
				if(validLogos[i]){
					s = "Logo Exists";
				}
				else{
					s = "No Logo";
				}
				selector.listboxLogos.Items[i] = String.Format("Logo {0} ({1})",i+1,s);
			}

			// ask which logo to load
			int saveFileLogoNum = 0;
			DialogResult d = selector.ShowDialog();
			if (d == System.Windows.Forms.DialogResult.OK) {
				saveFileLogoNum = selector.selectedIndex;
			}
			else if (d == System.Windows.Forms.DialogResult.Cancel) {
				saveFile.Close();
				return;
			}

			// skip first 0x10 bytes
			saveFile.Seek(0xC6010 + (saveFileLogoNum * 16656) + 0x10, SeekOrigin.Begin);
			ReadPalette(saveFile);
			ReadPixels(saveFile);
			saveFile.Close(); // we don't need the file to be open anymore.
			UpdateImage();
			statusLabel.Text = String.Format("Loaded logo #{0}", saveFileLogoNum+1);
		}

		/* load raw FPR save (e.g. BISLPM-66082, BASLUS-21702, BESLES-55041) */
		private void LoadFPRSave_Raw(string inFile) {
			// reset array
			for (int i = 0; i < validLogos.Length; i++) {
				validLogos[i] = false;
			}

			// try loading save file
			FileStream saveFile = new FileStream(inFile, FileMode.Open);
			if (saveFile == null) {
				MessageBox.Show(String.Format("Unable to open {0}", inFile));
				return;
			}

			/* look for valid logos in save file */
			/* a typical logo is 16,656 bytes (0x4110). logos in raw saves start at 0xC5810 */
			for (int i = 0; i < 6; i++) {
				saveFile.Seek(0xC5810 + (i * 16656), SeekOrigin.Begin);
				//read first byte; it will be 1 if a logo exists in this slot.
				validLogos[i] = saveFile.ReadByte() == 1 && true || false;
			}

			// modify entries in the selector
			LogoDialog selector = new LogoDialog();
			string s = "";
			for(int i = 0; i < 6; i++){
				if(validLogos[i]){
					s = "Logo Exists";
				}
				else{
					s = "No Logo";
				}
				selector.listboxLogos.Items[i] = String.Format("Logo {0} ({1})",i+1,s);
			}

			// ask which logo to load
			int saveFileLogoNum = 0;
			DialogResult d = selector.ShowDialog();
			if (d == System.Windows.Forms.DialogResult.OK) {
				saveFileLogoNum = selector.selectedIndex;
			}
			else if (d == System.Windows.Forms.DialogResult.Cancel) {
				saveFile.Close();
				return;
			}

			// skip first 0x10 bytes
			saveFile.Seek(0xC5810 + (saveFileLogoNum * 16656) + 0x10, SeekOrigin.Begin);
			ReadPalette(saveFile);
			ReadPixels(saveFile);
			saveFile.Close(); // we don't need the file to be open anymore.
			UpdateImage();
			statusLabel.Text = String.Format("Loaded logo #{0}", saveFileLogoNum+1);
		}

		/* load .bin format ripped logo */
		private void LoadRippedLogo(string inFile) {
			// the logo is pre-ripped and assumed to exist
			FileStream f = new FileStream(inFile, FileMode.Open);
			if (f == null) {
				MessageBox.Show(String.Format("Unable to open {0}",inFile));
				return;
			}

			/* skip first 0x10 bytes */
			f.Seek(0x10, SeekOrigin.Begin);
			ReadPalette(f);
			ReadPixels(f);
			f.Close(); // we don't need the file to be open anymore.
			UpdateImage();
			statusLabel.Text = "Loaded .bin rip";
		}

		private void ReadPalette(FileStream f) {
			/* write palette data to logoPalette; first three bytes are hex color; last one is transparent indicator */
			byte[] curColor = new byte[4];
			// first eight colors ($00-$07)
			for (int i = 0; i < 8; i++) {
				f.Read(curColor, 0, 4);
				// multiply alpha by 2 (this is an assumption that may not be true!)
				curColor[3] = (byte)Math.Min((int)curColor[3] * 2, 255);
				logoPalette[i] = Color.FromArgb(curColor[3], curColor[0], curColor[1], curColor[2]);
			}
			// then it goes to $10-$17
			for (int i = 16; i < 24; i++) {
				f.Read(curColor, 0, 4);
				// multiply alpha by 2 (this is an assumption that may not be true!)
				curColor[3] = (byte)Math.Min((int)curColor[3] * 2, 255);
				logoPalette[i] = Color.FromArgb(curColor[3], curColor[0], curColor[1], curColor[2]);
			}
			// then $08-$0F
			for (int i = 8; i < 16; i++) {
				f.Read(curColor, 0, 4);
				// multiply alpha by 2 (this is an assumption that may not be true!)
				curColor[3] = (byte)Math.Min((int)curColor[3] * 2, 255);
				logoPalette[i] = Color.FromArgb(curColor[3], curColor[0], curColor[1], curColor[2]);
			}
			// then $18-$1F
			for (int i = 24; i < 32; i++) {
				f.Read(curColor, 0, 4);
				// multiply alpha by 2 (this is an assumption that may not be true!)
				curColor[3] = (byte)Math.Min((int)curColor[3] * 2, 255);
				logoPalette[i] = Color.FromArgb(curColor[3], curColor[0], curColor[1], curColor[2]);
			}
			// then $20-$27
			for (int i = 32; i < 40; i++) {
				f.Read(curColor, 0, 4);
				// multiply alpha by 2 (this is an assumption that may not be true!)
				curColor[3] = (byte)Math.Min((int)curColor[3] * 2, 255);
				logoPalette[i] = Color.FromArgb(curColor[3], curColor[0], curColor[1], curColor[2]);
			}
			// then $30-$37
			for (int i = 48; i < 56; i++) {
				f.Read(curColor, 0, 4);
				// multiply alpha by 2 (this is an assumption that may not be true!)
				curColor[3] = (byte)Math.Min((int)curColor[3] * 2, 255);
				logoPalette[i] = Color.FromArgb(curColor[3], curColor[0], curColor[1], curColor[2]);
			}
			// then $28-$2F
			for (int i = 40; i < 48; i++) {
				f.Read(curColor, 0, 4);
				// multiply alpha by 2 (this is an assumption that may not be true!)
				curColor[3] = (byte)Math.Min((int)curColor[3] * 2, 255);
				logoPalette[i] = Color.FromArgb(curColor[3], curColor[0], curColor[1], curColor[2]);
			}
			// then $38-$3F
			for (int i = 56; i < 64; i++) {
				f.Read(curColor, 0, 4);
				// multiply alpha by 2 (this is an assumption that may not be true!)
				curColor[3] = (byte)Math.Min((int)curColor[3] * 2, 255);
				logoPalette[i] = Color.FromArgb(curColor[3], curColor[0], curColor[1], curColor[2]);
			}

			// update dropdown box
			for (int i = 0; i < 64; i++) {
				cboxColorTable.Items[i] = String.Format("0x{0:X2} | #{1:X2}{2:X2}{3:X2}", i, logoPalette[i].R, logoPalette[i].G, logoPalette[i].B);
			}
		}

		private void ReadPixels(FileStream f) {
			/* write image palette indexes to logoData */
			f.Read(logoData, 0, 0x4000);
		}

		private void UpdateImage() {
			// oh boy, this is the hard part.

			// 1) convert logoData to bitmap
			for (int y = 0; y < 128; y++) {
				for (int x = 0; x < 128; x++) {
					int pixelLoc = (y * 128) + x;
					if (logoData[pixelLoc] < 0x3F) {
						logoBitmap.SetPixel(x, y, logoPalette[logoData[pixelLoc]]);
					}
					else {
						string note = String.Format("Unexpected value 0x{3:X2} at x={0:D},y={1:D}; file location=0x{2:X4}", x, y, pixelLoc, logoData[pixelLoc]);
						MessageBox.Show(note, "Unexpected Value", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					}
				}
			}
			// 2) draw to image
			this.picboxLogo.Image = logoBitmap;
		}

		private void picboxLogo_MouseMove(object sender, MouseEventArgs e) {
			// find cursor location
			int xLoc = Math.Min(e.X - picboxLogo.ClientRectangle.Left,127);
			int yLoc = Math.Min(e.Y - picboxLogo.ClientRectangle.Top,127);
			int pixelLoc = (yLoc * 128) + xLoc;
			statusLabel.Text = String.Format("X:{0:D3}/127,Y:{1:D3}/127,V:0x{2:X2}/{2:D3}", xLoc, yLoc, logoData[pixelLoc]);
			// only change color for valid palette indexes
			if (logoData[pixelLoc] < 0x3F) {
				panelCursorColor.BackColor = logoPalette[logoData[pixelLoc]];
			}
		}

		private void cboxColorTable_SelectedIndexChanged(object sender, EventArgs e) {
			panelColor.BackColor = logoPalette[cboxColorTable.SelectedIndex];
		}

		private void picboxLogo_MouseClick(object sender, MouseEventArgs e) {
			// change active color in color set to the color under the cursor
			int xLoc = e.X - picboxLogo.ClientRectangle.Left;
			int yLoc = e.Y - picboxLogo.ClientRectangle.Top;
			int pixelLoc = (yLoc * 128) + xLoc;
			// only change color for valid palette indexes
			if (logoData[pixelLoc] < 0x3C) {
				cboxColorTable.SelectedIndex = logoData[pixelLoc];
			}
		}
	}
}