namespace FPRLogoViewer
{
	partial class LogoToolForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogoToolForm));
			this.menuBar = new System.Windows.Forms.MenuStrip();
			this.menuItem_File = new System.Windows.Forms.ToolStripMenuItem();
			this.menuItem_File_Open = new System.Windows.Forms.ToolStripMenuItem();
			this.menuItem_File_Save = new System.Windows.Forms.ToolStripMenuItem();
			this.menuItem_File_SaveAs = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.menuItem_File_Exit = new System.Windows.Forms.ToolStripMenuItem();
			this.menuItem_Import = new System.Windows.Forms.ToolStripMenuItem();
			this.menuItem_Import_Raw = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.menuItem_Import_Gif = new System.Windows.Forms.ToolStripMenuItem();
			this.menuItem_Export = new System.Windows.Forms.ToolStripMenuItem();
			this.menuItem_Export_Raw = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.menuItem_Export_Png = new System.Windows.Forms.ToolStripMenuItem();
			this.menuItem_Help = new System.Windows.Forms.ToolStripMenuItem();
			this.menuItem_Help_About = new System.Windows.Forms.ToolStripMenuItem();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.groupBoxLogoList = new System.Windows.Forms.GroupBox();
			this.listViewLogos = new System.Windows.Forms.ListView();
			this.contextMenuStripLogoItem = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.importRawToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.importGIFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.exportRawLogoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exportPNGToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.imageListLogos = new System.Windows.Forms.ImageList(this.components);
			this.menuBar.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			this.groupBoxLogoList.SuspendLayout();
			this.contextMenuStripLogoItem.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuBar
			// 
			resources.ApplyResources(this.menuBar, "menuBar");
			this.menuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem_File,
            this.menuItem_Import,
            this.menuItem_Export,
            this.menuItem_Help});
			this.menuBar.Name = "menuBar";
			// 
			// menuItem_File
			// 
			resources.ApplyResources(this.menuItem_File, "menuItem_File");
			this.menuItem_File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem_File_Open,
            this.menuItem_File_Save,
            this.menuItem_File_SaveAs,
            this.toolStripSeparator1,
            this.menuItem_File_Exit});
			this.menuItem_File.Name = "menuItem_File";
			// 
			// menuItem_File_Open
			// 
			resources.ApplyResources(this.menuItem_File_Open, "menuItem_File_Open");
			this.menuItem_File_Open.Name = "menuItem_File_Open";
			this.menuItem_File_Open.Click += new System.EventHandler(this.menuItem_File_Open_Click);
			// 
			// menuItem_File_Save
			// 
			resources.ApplyResources(this.menuItem_File_Save, "menuItem_File_Save");
			this.menuItem_File_Save.Name = "menuItem_File_Save";
			this.menuItem_File_Save.Click += new System.EventHandler(this.menuItem_File_Save_Click);
			// 
			// menuItem_File_SaveAs
			// 
			resources.ApplyResources(this.menuItem_File_SaveAs, "menuItem_File_SaveAs");
			this.menuItem_File_SaveAs.Name = "menuItem_File_SaveAs";
			this.menuItem_File_SaveAs.Click += new System.EventHandler(this.menuItem_File_SaveAs_Click);
			// 
			// toolStripSeparator1
			// 
			resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			// 
			// menuItem_File_Exit
			// 
			resources.ApplyResources(this.menuItem_File_Exit, "menuItem_File_Exit");
			this.menuItem_File_Exit.Name = "menuItem_File_Exit";
			this.menuItem_File_Exit.Click += new System.EventHandler(this.menuItem_File_Exit_Click);
			// 
			// menuItem_Import
			// 
			resources.ApplyResources(this.menuItem_Import, "menuItem_Import");
			this.menuItem_Import.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem_Import_Raw,
            this.toolStripSeparator2,
            this.menuItem_Import_Gif});
			this.menuItem_Import.Name = "menuItem_Import";
			// 
			// menuItem_Import_Raw
			// 
			resources.ApplyResources(this.menuItem_Import_Raw, "menuItem_Import_Raw");
			this.menuItem_Import_Raw.Name = "menuItem_Import_Raw";
			this.menuItem_Import_Raw.Click += new System.EventHandler(this.menuItem_Import_Raw_Click);
			// 
			// toolStripSeparator2
			// 
			resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			// 
			// menuItem_Import_Gif
			// 
			resources.ApplyResources(this.menuItem_Import_Gif, "menuItem_Import_Gif");
			this.menuItem_Import_Gif.Name = "menuItem_Import_Gif";
			this.menuItem_Import_Gif.Click += new System.EventHandler(this.menuItem_Import_Gif_Click);
			// 
			// menuItem_Export
			// 
			resources.ApplyResources(this.menuItem_Export, "menuItem_Export");
			this.menuItem_Export.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem_Export_Raw,
            this.toolStripSeparator3,
            this.menuItem_Export_Png});
			this.menuItem_Export.Name = "menuItem_Export";
			// 
			// menuItem_Export_Raw
			// 
			resources.ApplyResources(this.menuItem_Export_Raw, "menuItem_Export_Raw");
			this.menuItem_Export_Raw.Name = "menuItem_Export_Raw";
			this.menuItem_Export_Raw.Click += new System.EventHandler(this.menuItem_Export_Raw_Click);
			// 
			// toolStripSeparator3
			// 
			resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			// 
			// menuItem_Export_Png
			// 
			resources.ApplyResources(this.menuItem_Export_Png, "menuItem_Export_Png");
			this.menuItem_Export_Png.Name = "menuItem_Export_Png";
			this.menuItem_Export_Png.Click += new System.EventHandler(this.menuItem_Export_PNG_Click);
			// 
			// menuItem_Help
			// 
			resources.ApplyResources(this.menuItem_Help, "menuItem_Help");
			this.menuItem_Help.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem_Help_About});
			this.menuItem_Help.Name = "menuItem_Help";
			// 
			// menuItem_Help_About
			// 
			resources.ApplyResources(this.menuItem_Help_About, "menuItem_Help_About");
			this.menuItem_Help_About.Name = "menuItem_Help_About";
			this.menuItem_Help_About.Click += new System.EventHandler(this.menuItem_Help_About_Click);
			// 
			// statusStrip1
			// 
			resources.ApplyResources(this.statusStrip1, "statusStrip1");
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.SizingGrip = false;
			// 
			// statusLabel
			// 
			resources.ApplyResources(this.statusLabel, "statusLabel");
			this.statusLabel.Name = "statusLabel";
			// 
			// groupBoxLogoList
			// 
			resources.ApplyResources(this.groupBoxLogoList, "groupBoxLogoList");
			this.groupBoxLogoList.Controls.Add(this.listViewLogos);
			this.groupBoxLogoList.Name = "groupBoxLogoList";
			this.groupBoxLogoList.TabStop = false;
			// 
			// listViewLogos
			// 
			resources.ApplyResources(this.listViewLogos, "listViewLogos");
			this.listViewLogos.ContextMenuStrip = this.contextMenuStripLogoItem;
			this.listViewLogos.HideSelection = false;
			this.listViewLogos.LargeImageList = this.imageListLogos;
			this.listViewLogos.MultiSelect = false;
			this.listViewLogos.Name = "listViewLogos";
			this.listViewLogos.ShowGroups = false;
			this.listViewLogos.UseCompatibleStateImageBehavior = false;
			this.listViewLogos.SelectedIndexChanged += new System.EventHandler(this.listViewLogos_SelectedIndexChanged);
			// 
			// contextMenuStripLogoItem
			// 
			resources.ApplyResources(this.contextMenuStripLogoItem, "contextMenuStripLogoItem");
			this.contextMenuStripLogoItem.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importRawToolStripMenuItem,
            this.importGIFToolStripMenuItem,
            this.toolStripSeparator4,
            this.exportRawLogoToolStripMenuItem,
            this.exportPNGToolStripMenuItem});
			this.contextMenuStripLogoItem.Name = "contextMenuStripLogoItem";
			this.contextMenuStripLogoItem.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStripLogoItem_Opening);
			// 
			// importRawToolStripMenuItem
			// 
			resources.ApplyResources(this.importRawToolStripMenuItem, "importRawToolStripMenuItem");
			this.importRawToolStripMenuItem.Name = "importRawToolStripMenuItem";
			this.importRawToolStripMenuItem.Click += new System.EventHandler(this.importRawToolStripMenuItem_Click);
			// 
			// importGIFToolStripMenuItem
			// 
			resources.ApplyResources(this.importGIFToolStripMenuItem, "importGIFToolStripMenuItem");
			this.importGIFToolStripMenuItem.Name = "importGIFToolStripMenuItem";
			this.importGIFToolStripMenuItem.Click += new System.EventHandler(this.importGIFToolStripMenuItem_Click);
			// 
			// toolStripSeparator4
			// 
			resources.ApplyResources(this.toolStripSeparator4, "toolStripSeparator4");
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			// 
			// exportRawLogoToolStripMenuItem
			// 
			resources.ApplyResources(this.exportRawLogoToolStripMenuItem, "exportRawLogoToolStripMenuItem");
			this.exportRawLogoToolStripMenuItem.Name = "exportRawLogoToolStripMenuItem";
			this.exportRawLogoToolStripMenuItem.Click += new System.EventHandler(this.exportRawLogoToolStripMenuItem_Click);
			// 
			// exportPNGToolStripMenuItem
			// 
			resources.ApplyResources(this.exportPNGToolStripMenuItem, "exportPNGToolStripMenuItem");
			this.exportPNGToolStripMenuItem.Name = "exportPNGToolStripMenuItem";
			this.exportPNGToolStripMenuItem.Click += new System.EventHandler(this.exportPNGToolStripMenuItem_Click);
			// 
			// imageListLogos
			// 
			this.imageListLogos.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
			resources.ApplyResources(this.imageListLogos, "imageListLogos");
			this.imageListLogos.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// LogoToolForm
			// 
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.groupBoxLogoList);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.menuBar);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "LogoToolForm";
			this.menuBar.ResumeLayout(false);
			this.menuBar.PerformLayout();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.groupBoxLogoList.ResumeLayout(false);
			this.contextMenuStripLogoItem.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuBar;
		private System.Windows.Forms.ToolStripMenuItem menuItem_File;
		private System.Windows.Forms.ToolStripMenuItem menuItem_File_Open;
		private System.Windows.Forms.ToolStripMenuItem menuItem_File_Save;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem menuItem_File_Exit;
		private System.Windows.Forms.ToolStripMenuItem menuItem_Help;
		private System.Windows.Forms.ToolStripMenuItem menuItem_Help_About;
		private System.Windows.Forms.ToolStripMenuItem menuItem_Import;
		private System.Windows.Forms.ToolStripMenuItem menuItem_Import_Raw;
		private System.Windows.Forms.ToolStripMenuItem menuItem_Import_Gif;
		private System.Windows.Forms.ToolStripMenuItem menuItem_Export;
		private System.Windows.Forms.ToolStripMenuItem menuItem_Export_Raw;
		private System.Windows.Forms.ToolStripMenuItem menuItem_Export_Png;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel statusLabel;
		private System.Windows.Forms.ToolStripMenuItem menuItem_File_SaveAs;
		private System.Windows.Forms.GroupBox groupBoxLogoList;
		private System.Windows.Forms.ListView listViewLogos;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ImageList imageListLogos;
		private System.Windows.Forms.ContextMenuStrip contextMenuStripLogoItem;
		private System.Windows.Forms.ToolStripMenuItem importRawToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem importGIFToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		private System.Windows.Forms.ToolStripMenuItem exportRawLogoToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exportPNGToolStripMenuItem;
	}
}