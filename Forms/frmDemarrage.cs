using System;
using System.Drawing;
using System.Windows.Forms;

using static TorreDeBabel.baseLangueDataSet;

namespace TorreDeBabel {
public class frmDemarrage : Form {
#region Designer
private System.ComponentModel.IContainer components = null;
private Button btnRegister;
private Button btnLogin;

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
	SuspendLayout();
	components = new System.ComponentModel.Container();

	Name			= "frmDemarrage";
	Text			= Application.ProductName;
	BackgroundImage		= Properties.Resources.TowerOfBabel;
	BackgroundImageLayout	= ImageLayout.Stretch;
	Font			= Properties.Settings.Default.DisplayFont;
	WindowState		= FormWindowState.Maximized;

	btnRegister = new Button() {
		Name		= "btnInscrire",
		Size		= new Size(320, 48),
		Location	= new Point(640, 320),
		Text		= "S'inscrire",
		BackColor	= Color.FromArgb(88, 167, 0),
		ForeColor	= Color.White
	};
	btnRegister.Click += new EventHandler(Register);

	btnLogin = new Button() {
		Name		= "btnLogin",
		Size		= new Size(320, 48),
		Location	= new Point(640, 480),
		Text		= "Connexion",
		BackColor	= Color.Transparent,
		ForeColor	= Color.White
	};
	btnLogin.Click += new EventHandler(Login);

	Controls.Add(btnRegister);
	Controls.Add(btnLogin);

	ResumeLayout(false);
}
#endregion
#region Constructeurs
public
frmDemarrage()
{
	InitializeComponent();
}
#endregion
#region Méthodes
private void
Register(object sender, EventArgs e)
{
	using (frmRegister modal = new frmRegister())
		if (modal.ShowDialog() == DialogResult.OK)
			OpenDashboard(modal.CreatedUser);
		
}

private void
Login(object sender, EventArgs e)
{
	using (frmLogin modal = new frmLogin())
		if (modal.ShowDialog() == DialogResult.OK)
			OpenDashboard(modal.SelectedUser);
}

private void
OpenDashboard(UtilisateursRow selectedUser)
{
	Hide();
	using (frmDashboard modal = new frmDashboard(selectedUser))
		modal.ShowDialog();
	Show();
}
#endregion
}
}
