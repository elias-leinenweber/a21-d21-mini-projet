using System.Windows.Forms;

using static TorreDeBabel.baseLangueDataSet;

namespace TorreDeBabel {
class frmTableauBord : Form {
#region Designer
private System.ComponentModel.IContainer components = null;
private TableLayoutPanel	tlpMain;

protected override void
Dispose(bool disposing)
{
	if (disposing && components != null) {
		components.Dispose();
	}
	base.Dispose(disposing);
}

private void
InitializeComponent()
{
	SuspendLayout();
	components = new System.ComponentModel.Container();

	tlpMain = new TableLayoutPanel() {
		ColumnCount = 1
	};

	ResumeLayout(false);
}
#endregion
#region Constructeurs
public
frmTableauBord(UtilisateursRow user)
{
	InitializeComponent();
}
#endregion
#region Méthodes
private void
ChooseLesson(LeconsRow lecon)
{
	frmLecon frmLecon;

	frmLecon = new frmLecon(lecon);

	/* Si l'utilisateur a bien terminé la lecon */
	if (frmLecon.ShowDialog() == DialogResult.OK)
		UpdateProgress();
}

private void
UpdateProgress()
{

}
#endregion
}
}
