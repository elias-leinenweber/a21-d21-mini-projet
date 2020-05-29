using System;
using System.Windows.Forms;

namespace TorreDeBabel {
static class TorreDeBabel {
/// <summary>
/// The main entry point for the application.
/// </summary>
[STAThread]
static void
Main()
{
	try {
		Application.EnableVisualStyles();
		Application.Run(new frmDemarrage());
	} catch (Exception e) {
		MessageBox.Show(e.Message, e.GetType().Name,
		    MessageBoxButtons.OK, MessageBoxIcon.Error);
#if DEBUG
		MessageBox.Show(e.StackTrace);
#endif
	}
}
}
}
