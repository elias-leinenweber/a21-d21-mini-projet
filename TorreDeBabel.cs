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
		//Application.EnableVisualStyles();
		Application.Run(new frmDemarrage());
		//Application.Run(new frmLecon());
	} catch (Exception e) {
#if DEBUG
		MessageBox.Show(e.StackTrace);
#endif
		MessageBox.Show(e.Message);
	}
}
}
}
