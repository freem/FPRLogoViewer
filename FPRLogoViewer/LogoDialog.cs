using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace FPRLogoViewer
{
	public partial class LogoDialog : Form
	{
		public int selectedIndex;
		public LogoDialog() {
			InitializeComponent();
			selectedIndex = 0;
		}

		private void buttonCancel_Click(object sender, EventArgs e) {
			// bye
			this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.Close();
		}

		private void buttonOK_Click(object sender, EventArgs e) {
			// alright, we have a logo; we need to pass that
			// this.listboxLogos.SelectedIndex
			this.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.Close();
		}

		private void listboxLogos_SelectedIndexChanged(object sender, EventArgs e) {
			selectedIndex = this.listboxLogos.SelectedIndex;
		}

		private void listboxLogos_MouseDoubleClick(object sender, MouseEventArgs e) {
			this.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.Close();
		}
	}
}
