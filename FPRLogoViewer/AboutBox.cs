using System;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;

namespace FPRLogoViewer
{
	public partial class AboutBox : Form
	{
		public AboutBox() {
			InitializeComponent();
			labelVersion.Text = String.Format("v{0}",Assembly.GetExecutingAssembly().GetName().Version);
		}

		private void buttonClose_Click(object sender, EventArgs e) {
			this.Hide();
		}

		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
			// visit ajworld.net in your browser.
			System.Diagnostics.Process.Start("http://firepro.ajworld.net/");
		}
	}
}
