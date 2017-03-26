﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace FPRLogoViewer
{
	/// <summary>
	/// Redesign of the Fire Pro Wrestling Returns Logo Viewer for v2.0.
	/// </summary>
	public partial class LogoToolForm : Form
	{
		/// <summary>
		/// Save file types supported by the program.
		/// </summary>
		enum SaveType
		{
			SaveType_Raw, // Raw FPR save data (e.g. BISLPM-66082, BASLUS-21702, BESLES-55041)
			SaveType_Psu, // EMS Memory Linker save (no rewriting yet)
			Num_SaveType, // (count)
			SaveType_Invalid // not supported
		};

		#region Program Variables
		/// <summary>
		/// Currently selected logo slot.
		/// </summary>
		public int CurLogoSlot = -1;

		/// <summary>
		/// Currently loaded save file.
		/// </summary>
		public SaveFile_FPR CurSaveFile;

		/// <summary>
		/// Path to currently loaded save file.
		/// </summary>
		private string SaveFilePath;

		/// <summary>
		/// Current save type.
		/// </summary>
		private SaveType CurSaveType;

		/// <summary>
		/// Dummy image used for non-active slots.
		/// </summary>
		private Bitmap DummyImage = new Bitmap(128, 128);
		#endregion


		public LogoToolForm() {
			InitializeComponent();
			UpdateMenuItems();
		}

		/// <summary>
		/// Update the status of various menu items.
		/// </summary>
		private void UpdateMenuItems() {
			if (CurSaveFile == null) {
				// no save loaded.
				menuItem_File_Save.Enabled = false;
				menuItem_File_SaveAs.Enabled = false;
				menuItem_Import_Raw.Enabled = false;
				menuItem_Import_Gif.Enabled = false;
				menuItem_Export_Raw.Enabled = false;
				menuItem_Export_Png.Enabled = false;

				// these get enabled in an event elsewhere
				importRawToolStripMenuItem.Enabled = false;
				importGIFToolStripMenuItem.Enabled = false;
				exportRawLogoToolStripMenuItem.Enabled = false;
				exportPNGToolStripMenuItem.Enabled = false;
			}
			else {
				// save is loaded, but a slot may not be selected...
				menuItem_File_Save.Enabled = true;
				menuItem_File_SaveAs.Enabled = true;
				if (CurLogoSlot == -1) {
					menuItem_Import_Raw.Enabled = false;
					menuItem_Import_Gif.Enabled = false;
					menuItem_Export_Raw.Enabled = false;
					menuItem_Export_Png.Enabled = false;
				}
				else {
					menuItem_Import_Raw.Enabled = true;
					menuItem_Import_Gif.Enabled = true;
					menuItem_Export_Raw.Enabled = (CurSaveFile.Logos[CurLogoSlot].SlotUsed == true);
					menuItem_Export_Png.Enabled = (CurSaveFile.Logos[CurLogoSlot].SlotUsed == true);
				}
			}
		}

		/// <summary>
		/// Return human readable string for GIF error codes.
		/// </summary>
		/// <param name="code">Error code</param>
		/// <returns>Human readable string for error code</returns>
		private string GifErrorCodeToString(int code) {
			switch (code) {
				case 0: return "No errors";
				case 1: return "Unable to open GIF file";
				case 2: return "Wrong pixel format (should be 8BPP indexed)";
				case 3: return "Wrong image size (should be 128x128 pixels)";
				case 4: return "Too many colors in image (should be 64 or less)";
				case 5: return "Could not remap color";
				default: return String.Format("Undefined Error Code; yell at freem about it",code);
			}
		}

		#region Menu Items

		#region General Menu Items
		/// <summary>
		/// Show the about dialog.
		/// </summary>
		private void menuItem_Help_About_Click(object sender, EventArgs e) {
			AboutBox ab = new AboutBox();
			ab.ShowDialog();
		}

		/// <summary>
		/// Exit the program.
		/// </summary>
		private void menuItem_File_Exit_Click(object sender, EventArgs e) {
			this.Close();
		}
		#endregion

		#region File Menu Items
		/// <summary>
		/// Open a file.
		/// </summary>
		private void menuItem_File_Open_Click(object sender, EventArgs e) {
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Title = "Open Fire Pro Wrestling Returns Save File";
			ofd.Filter = "Raw FPR Save File (e.g. BASLUS-21702, BISLPM-66082, BESLES-55041)|*.*|EMS Memory Linker Save|*.psu|All Files|*.*";
			ofd.Multiselect = false;
			if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
				SaveFilePath = ofd.FileName;
				CurSaveFile = new SaveFile_FPR();

				// xxx: makes blind assumptions instead of attempting to figure out format on its own
				if (Path.GetExtension(SaveFilePath) == ".psu") {
					// psu save
					CurSaveFile.Load_PSU(SaveFilePath);
					CurSaveType = SaveType.SaveType_Psu;
				}
				else {
					// assumes raw data
					CurSaveFile.Load_RawSave(SaveFilePath);
					CurSaveType = SaveType.SaveType_Raw;
				}
				UpdateMenuItems();
				statusLabel.Text = SaveFilePath;
				UpdateLogoList();
			}

		}

		/// <summary>
		/// Save the currently opened file.
		/// </summary>
		private void menuItem_File_Save_Click(object sender, EventArgs e) {
			if (CurSaveFile == null) {
				return;
			}
			// todo: currently only handles raw save file properly
			switch (CurSaveType) {
				case SaveType.SaveType_Raw:
					CurSaveFile.Save_Raw(SaveFilePath);
					break;
				case SaveType.SaveType_Psu:
					CurSaveFile.Save_PSU(SaveFilePath);
					break;
			}
		}

		/// <summary>
		/// Save the currently opened file under a new name.
		/// </summary>
		private void menuItem_File_SaveAs_Click(object sender, EventArgs e) {
			SaveFileDialog sfd = new SaveFileDialog();
			sfd.Title = "Save Fire Pro Wrestling Returns Save File As...";
			sfd.Filter = "Raw FPR Save File (e.g. BASLUS-21702, BISLPM-66082, BESLES-55041)|*.*|EMS Memory Linker Save|*.psu";
			if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
				// determine what format we're saving as based on extension (wow this sucks)
				if (Path.GetExtension(sfd.FileName) == ".psu") {
					// save as psu
					CurSaveFile.Save_PSU(sfd.FileName);
				}
				else {
					// save as raw FPR save
					CurSaveFile.Save_Raw(sfd.FileName);
				}
			}
		}
		#endregion

		#region Import Menu Items
		/// <summary>
		/// Import a raw FPR logo into the current logo slot.
		/// </summary>
		private void menuItem_Import_Raw_Click(object sender, EventArgs e) {
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Title = "Import Logo from Raw Logo Data...";
			ofd.Filter = "Raw Logo Data|*.fprlogo;*.bin|All Files|*.*";
			ofd.Multiselect = false;
			if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
				CurSaveFile.Logos[CurLogoSlot].Load_RawFile(ofd.FileName);
				CurSaveFile.Logos[CurLogoSlot].SlotUsed = true; // force slot enable
				UpdateLogoList();
			}
		}

		/// <summary>
		/// Import a logo from a GIF into the current logo slot.
		/// </summary>
		private void menuItem_Import_Gif_Click(object sender, EventArgs e) {
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Title = "Import Logo from GIF...";
			ofd.Filter = "GIF Files|*.gif";
			ofd.Multiselect = false;
			if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
				int errorCode = 0;
				if (CurSaveFile.Logos[CurLogoSlot].FromGif(ofd.FileName, out errorCode) == false) {
					MessageBox.Show(String.Format("Unable to import GIF.\nError code {0}: {1}", errorCode, GifErrorCodeToString(errorCode)));
				}
				else {
					CurSaveFile.Logos[CurLogoSlot].SlotUsed = true; // force slot enable
					UpdateLogoList();
				}
			}
		}

		/// <summary>
		/// Context menu version of menuItem_Import_Raw_Click.
		/// </summary>
		private void importRawToolStripMenuItem_Click(object sender, EventArgs e) {
			menuItem_Import_Raw_Click(sender, e);
		}

		/// <summary>
		/// Context menu version of menuItem_Import_Gif_Click.
		/// </summary>
		private void importGIFToolStripMenuItem_Click(object sender, EventArgs e) {
			menuItem_Import_Gif_Click(sender, e);
		}
		#endregion

		#region Export Menu Items
		/// <summary>
		/// Export a raw FPR logo from the current logo slot.
		/// </summary>
		private void menuItem_Export_Raw_Click(object sender, EventArgs e) {
			SaveFileDialog sfd = new SaveFileDialog();
			sfd.Title = "Export Logo as Raw Logo Data...";
			sfd.Filter = "Raw Logo Data|*.fprlogo;*.bin|All Files|*.*";
			if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
				CurSaveFile.Logos[CurLogoSlot].SaveFile_RawLogo(sfd.FileName);
			}
		}

		/// <summary>
		/// Export a PNG from the current logo slot.
		/// </summary>
		private void menuItem_Export_PNG_Click(object sender, EventArgs e) {
			SaveFileDialog sfd = new SaveFileDialog();
			sfd.Title = "Export Logo as PNG...";
			sfd.Filter = "PNG Files|*.png";
			if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
				CurSaveFile.Logos[CurLogoSlot].SaveFile_PNG(sfd.FileName);
			}
		}

		/// <summary>
		/// Context menu version of menuItem_Export_Raw_Click.
		/// </summary>
		private void exportRawLogoToolStripMenuItem_Click(object sender, EventArgs e) {
			menuItem_Export_Raw_Click(sender, e);
		}

		/// <summary>
		/// Context menu version of menuItem_Export_PNG_Click.
		/// </summary>
		private void exportPNGToolStripMenuItem_Click(object sender, EventArgs e) {
			menuItem_Export_PNG_Click(sender, e);
		}
		#endregion

		#endregion // menu items

		#region Logo List Routines
		/// <summary>
		/// Updates the Logo list.
		/// </summary>
		private void UpdateLogoList() {
			imageListLogos.Images.Clear();
			listViewLogos.Items.Clear();

			listViewLogos.BeginUpdate();
			for (int i = 0; i < CurSaveFile.Logos.Length; i++) {
				if (CurSaveFile.Logos[i].SlotUsed) {
					// business as usual
					imageListLogos.Images.Add(String.Format("Logo{0}", i), CurSaveFile.Logos[i].LogoBitmap);
				}
				else {
					// handle gaps in the logo list using a dummy image
					imageListLogos.Images.Add(String.Format("Logo{0}", i), DummyImage);
				}
				listViewLogos.Items.Add(String.Format("Logo{0}", i), String.Format("Slot {0}", i + 1), i);
			}
			listViewLogos.EndUpdate();
		}

		/// <summary>
		/// Update the current active logo slot.
		/// </summary>
		private void listViewLogos_SelectedIndexChanged(object sender, EventArgs e) {
			CurLogoSlot = listViewLogos.SelectedIndices[0];
			UpdateMenuItems();
		}

		private void LogoToolForm_Click(object sender, EventArgs e) {
			CurLogoSlot = listViewLogos.SelectedIndices[0];
			UpdateMenuItems();
		}

		/// <summary>
		/// Handle the context menu on the logos properly.
		/// </summary>
		private void contextMenuStripLogoItem_Opening(object sender, CancelEventArgs e) {
			if (listViewLogos.SelectedIndices[0] == -1) {
				// disable all
				importRawToolStripMenuItem.Enabled = false;
				importGIFToolStripMenuItem.Enabled = false;
				exportRawLogoToolStripMenuItem.Enabled = false;
				exportPNGToolStripMenuItem.Enabled = false;
			}
			else {
				// enable import
				importRawToolStripMenuItem.Enabled = true;
				importGIFToolStripMenuItem.Enabled = true;

				// export depends on having a logo in this slot.
				int logoSlot = listViewLogos.SelectedIndices[0];
				exportRawLogoToolStripMenuItem.Enabled = (CurSaveFile.Logos[logoSlot].SlotUsed == true);
				exportPNGToolStripMenuItem.Enabled = (CurSaveFile.Logos[logoSlot].SlotUsed == true);
			}
		}
		#endregion


	}
}
