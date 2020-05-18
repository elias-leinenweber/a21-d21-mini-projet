using System.Drawing;
using System.Windows.Forms;
using static TorreDeBabel.baseLangueDataSet;

namespace TorreDeBabel {
public class frmRegister : Form {
#region Designer
private System.ComponentModel.IContainer components = null;

protected override void
Dispose(bool disposing)
{
	if (disposing && components != null)
		components.Dispose();
	base.Dispose(disposing);
}

private void
InitializeComponent()
{
	components = new System.ComponentModel.Container();
	AutoScaleMode = AutoScaleMode.Font;
	ClientSize = new Size(800, 450);
	Text = "frmRegister";
}
#endregion
#region Propriétés
public UtilisateursRow CreatedUser;
#endregion
public
frmRegister()
{
	InitializeComponent();
}
}
}
