using System;
using System.Drawing;
using System.Windows.Forms;

using static TorreDeBabel.baseLangueDataSet;

namespace TorreDeBabel {
public class frmSplash : Form {
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
	SuspendLayout();
	components = new System.ComponentModel.Container();

	Name			= "frmDemarrage";
	Text			= Application.ProductName;
	BackgroundImage		= Properties.Resources.TowerOfBabel;
	ClientSize		= BackgroundImage.Size;
	Font			= Properties.Settings.Default.DisplayFont;
	FormBorderStyle		= FormBorderStyle.FixedSingle;
	MaximizeBox		= false;
	StartPosition		= FormStartPosition.CenterScreen;

	lblLogo = new Label() {
		Name		= "lblLogo",
		Text		= "TORRE DE BABEL",
		Size		= new Size(153, 36),
		Location	= new Point(40, 18),
		Font		= Properties.Settings.Default.LogoFont,
		ForeColor	= Color.Crimson,
		BackColor	= Color.Transparent,
		AutoSize	= true
	};

	btnRegister = new Button() {
		Name		= "btnInscrire",
		Size		= new Size(320, 48),
		Top		= (ClientSize.Height - 110) / 2,
		Left		= (ClientSize.Width - 320) / 2,
		Text		= "S'INSCRIRE",
		BackColor	= Color.FromArgb(88, 167, 0),
		ForeColor	= Color.White,
		Font		= new Font(Font.FontFamily, 15, FontStyle.Bold, GraphicsUnit.Pixel),
		Enabled		= false
	};
	btnRegister.Click += new EventHandler(Register);

	btnLogin = new Button() {
		Name		= "btnLogin",
		Size		= new Size(320, 48),
		Top		= btnRegister.Top + btnRegister.Height + 14,
		Left		= btnRegister.Left,
		Text		= "CONNEXION",
		Font		= new Font(Font.FontFamily, 15, FontStyle.Bold, GraphicsUnit.Pixel),
		BackColor	= Color.FromArgb(35, 83, 144),
		ForeColor	= Color.White
	};
	btnLogin.Click += new EventHandler(Login);

	Controls.Add(lblLogo);
	Controls.Add(btnRegister);
	Controls.Add(btnLogin);

	ResumeLayout(false);
}

private Label	lblLogo;
private Button	btnRegister;
private Button	btnLogin;
#endregion
#region Constructeurs
internal
frmSplash()
{
	InitializeComponent();
}
#endregion
#region Méthodes
private void
Register(object sender, EventArgs e)
{
	throw new NotImplementedException();
	/*
	using (frmRegister modal = new frmRegister())
		if (modal.ShowDialog() == DialogResult.OK)
			OpenDashboard(modal.CreatedUser);
	*/
}

private void
Login(object sender, EventArgs e)
{
	Enabled = false;
	Opacity = 0.65;
	using (frmLogin modal = new frmLogin())
		if (modal.ShowDialog() == DialogResult.OK)
			OpenDashboard(modal.SelectedUser);
	Opacity = 1;
	Enabled = true;
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
