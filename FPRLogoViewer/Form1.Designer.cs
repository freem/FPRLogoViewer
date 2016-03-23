namespace FPRLogoViewer
{
	partial class mainForm
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
			this.menuBar = new System.Windows.Forms.MenuStrip();
			this.menuItem_File = new System.Windows.Forms.ToolStripMenuItem();
			this.menuItem_File_Open = new System.Windows.Forms.ToolStripMenuItem();
			this.menuItem_File_Save = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.menuItem_File_Exit = new System.Windows.Forms.ToolStripMenuItem();
			this.menuItem_Help = new System.Windows.Forms.ToolStripMenuItem();
			this.menuItem_Help_About = new System.Windows.Forms.ToolStripMenuItem();
			this.picboxLogo = new System.Windows.Forms.PictureBox();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.gboxColorTable = new System.Windows.Forms.GroupBox();
			this.panelColor = new System.Windows.Forms.Panel();
			this.cboxColorTable = new System.Windows.Forms.ComboBox();
			this.gboxCursorColor = new System.Windows.Forms.GroupBox();
			this.panelCursorColor = new System.Windows.Forms.Panel();
			this.menuBar.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.picboxLogo)).BeginInit();
			this.statusStrip1.SuspendLayout();
			this.gboxColorTable.SuspendLayout();
			this.gboxCursorColor.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuBar
			// 
			this.menuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem_File,
            this.menuItem_Help});
			this.menuBar.Location = new System.Drawing.Point(0, 0);
			this.menuBar.Name = "menuBar";
			this.menuBar.Size = new System.Drawing.Size(456, 24);
			this.menuBar.TabIndex = 0;
			this.menuBar.Text = "menuStrip1";
			// 
			// menuItem_File
			// 
			this.menuItem_File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem_File_Open,
            this.menuItem_File_Save,
            this.toolStripSeparator1,
            this.menuItem_File_Exit});
			this.menuItem_File.Name = "menuItem_File";
			this.menuItem_File.Size = new System.Drawing.Size(35, 20);
			this.menuItem_File.Text = "&File";
			// 
			// menuItem_File_Open
			// 
			this.menuItem_File_Open.Name = "menuItem_File_Open";
			this.menuItem_File_Open.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
			this.menuItem_File_Open.Size = new System.Drawing.Size(148, 22);
			this.menuItem_File_Open.Text = "&Open";
			this.menuItem_File_Open.ToolTipText = "Open logo data...";
			this.menuItem_File_Open.Click += new System.EventHandler(this.menuItem_File_Open_Click);
			// 
			// menuItem_File_Save
			// 
			this.menuItem_File_Save.Name = "menuItem_File_Save";
			this.menuItem_File_Save.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
			this.menuItem_File_Save.Size = new System.Drawing.Size(148, 22);
			this.menuItem_File_Save.Text = "&Save...";
			this.menuItem_File_Save.ToolTipText = "Export logo as...";
			this.menuItem_File_Save.Click += new System.EventHandler(this.menuItem_File_Save_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(145, 6);
			// 
			// menuItem_File_Exit
			// 
			this.menuItem_File_Exit.Name = "menuItem_File_Exit";
			this.menuItem_File_Exit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
			this.menuItem_File_Exit.Size = new System.Drawing.Size(148, 22);
			this.menuItem_File_Exit.Text = "E&xit";
			this.menuItem_File_Exit.ToolTipText = "You want to leave?";
			this.menuItem_File_Exit.Click += new System.EventHandler(this.menuItem_File_Exit_Click);
			// 
			// menuItem_Help
			// 
			this.menuItem_Help.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem_Help_About});
			this.menuItem_Help.Name = "menuItem_Help";
			this.menuItem_Help.Size = new System.Drawing.Size(40, 20);
			this.menuItem_Help.Text = "&Help";
			// 
			// menuItem_Help_About
			// 
			this.menuItem_Help_About.Name = "menuItem_Help_About";
			this.menuItem_Help_About.Size = new System.Drawing.Size(152, 22);
			this.menuItem_Help_About.Text = "&About...";
			this.menuItem_Help_About.ToolTipText = "About this silly little program";
			this.menuItem_Help_About.Click += new System.EventHandler(this.menuItem_Help_About_Click);
			// 
			// picboxLogo
			// 
			this.picboxLogo.BackColor = System.Drawing.Color.Black;
			this.picboxLogo.Location = new System.Drawing.Point(12, 29);
			this.picboxLogo.MaximumSize = new System.Drawing.Size(128, 128);
			this.picboxLogo.MinimumSize = new System.Drawing.Size(128, 128);
			this.picboxLogo.Name = "picboxLogo";
			this.picboxLogo.Size = new System.Drawing.Size(128, 128);
			this.picboxLogo.TabIndex = 1;
			this.picboxLogo.TabStop = false;
			this.picboxLogo.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picboxLogo_MouseClick);
			this.picboxLogo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picboxLogo_MouseMove);
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
			this.statusStrip1.Location = new System.Drawing.Point(0, 167);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(456, 22);
			this.statusStrip1.SizingGrip = false;
			this.statusStrip1.TabIndex = 2;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// statusLabel
			// 
			this.statusLabel.Name = "statusLabel";
			this.statusLabel.Size = new System.Drawing.Size(76, 17);
			this.statusLabel.Text = "No file loaded.";
			// 
			// gboxColorTable
			// 
			this.gboxColorTable.Controls.Add(this.panelColor);
			this.gboxColorTable.Controls.Add(this.cboxColorTable);
			this.gboxColorTable.Location = new System.Drawing.Point(302, 29);
			this.gboxColorTable.Name = "gboxColorTable";
			this.gboxColorTable.Size = new System.Drawing.Size(142, 128);
			this.gboxColorTable.TabIndex = 3;
			this.gboxColorTable.TabStop = false;
			this.gboxColorTable.Text = "Color Table";
			// 
			// panelColor
			// 
			this.panelColor.Location = new System.Drawing.Point(6, 48);
			this.panelColor.Name = "panelColor";
			this.panelColor.Size = new System.Drawing.Size(128, 74);
			this.panelColor.TabIndex = 1;
			// 
			// cboxColorTable
			// 
			this.cboxColorTable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboxColorTable.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cboxColorTable.FormattingEnabled = true;
			this.cboxColorTable.Items.AddRange(new object[] {
            "0x00",
            "0x01",
            "0x02",
            "0x03",
            "0x04",
            "0x05",
            "0x06",
            "0x07",
            "0x08",
            "0x09",
            "0x0A",
            "0x0B",
            "0x0C",
            "0x0D",
            "0x0E",
            "0x0F",
            "0x10",
            "0x11",
            "0x12",
            "0x13",
            "0x14",
            "0x15",
            "0x16",
            "0x17",
            "0x18",
            "0x19",
            "0x1A",
            "0x1B",
            "0x1C",
            "0x1D",
            "0x1E",
            "0x1F",
            "0x20",
            "0x21",
            "0x22",
            "0x23",
            "0x24",
            "0x25",
            "0x26",
            "0x27",
            "0x28",
            "0x29",
            "0x2A",
            "0x2B",
            "0x2C",
            "0x2D",
            "0x2E",
            "0x2F",
            "0x30",
            "0x31",
            "0x32",
            "0x33",
            "0x34",
            "0x35",
            "0x36",
            "0x37",
            "0x38",
            "0x39",
            "0x3A",
            "0x3B",
            "0x3C",
            "0x3D",
            "0x3E",
            "0x3F"});
			this.cboxColorTable.Location = new System.Drawing.Point(6, 19);
			this.cboxColorTable.Name = "cboxColorTable";
			this.cboxColorTable.Size = new System.Drawing.Size(128, 23);
			this.cboxColorTable.TabIndex = 0;
			this.cboxColorTable.SelectedIndexChanged += new System.EventHandler(this.cboxColorTable_SelectedIndexChanged);
			// 
			// gboxCursorColor
			// 
			this.gboxCursorColor.Controls.Add(this.panelCursorColor);
			this.gboxCursorColor.Location = new System.Drawing.Point(146, 29);
			this.gboxCursorColor.Name = "gboxCursorColor";
			this.gboxCursorColor.Size = new System.Drawing.Size(150, 128);
			this.gboxCursorColor.TabIndex = 4;
			this.gboxCursorColor.TabStop = false;
			this.gboxCursorColor.Text = "Cursor Color";
			// 
			// panelCursorColor
			// 
			this.panelCursorColor.Location = new System.Drawing.Point(6, 19);
			this.panelCursorColor.Name = "panelCursorColor";
			this.panelCursorColor.Size = new System.Drawing.Size(138, 103);
			this.panelCursorColor.TabIndex = 0;
			// 
			// mainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(456, 189);
			this.Controls.Add(this.gboxCursorColor);
			this.Controls.Add(this.gboxColorTable);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.picboxLogo);
			this.Controls.Add(this.menuBar);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MainMenuStrip = this.menuBar;
			this.MaximizeBox = false;
			this.Name = "mainForm";
			this.Text = "Fire Pro Returns Logo Viewer";
			this.menuBar.ResumeLayout(false);
			this.menuBar.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.picboxLogo)).EndInit();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.gboxColorTable.ResumeLayout(false);
			this.gboxCursorColor.ResumeLayout(false);
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
		private System.Windows.Forms.PictureBox picboxLogo;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel statusLabel;
		private System.Windows.Forms.GroupBox gboxColorTable;
		private System.Windows.Forms.ComboBox cboxColorTable;
		private System.Windows.Forms.Panel panelColor;
		private System.Windows.Forms.GroupBox gboxCursorColor;
		private System.Windows.Forms.Panel panelCursorColor;
	}
}

