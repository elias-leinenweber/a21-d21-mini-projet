using System;
using System.Windows.Forms;

using TorreDeBabel.baseLangueDataSetTableAdapters;

using static TorreDeBabel.baseLangueDataSet;

namespace TorreDeBabel {
static class TorreDeBabel {
public static UtilisateursTableAdapter adpUsers = new UtilisateursTableAdapter();
public static UtilisateursDataTable tblUsers = new UtilisateursDataTable();

/// <summary>
/// The main entry point for the application.
/// </summary>
[STAThread]
static void
Main()
{
	try {
		adpUsers.Fill(tblUsers);
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
