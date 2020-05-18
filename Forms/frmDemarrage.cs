using System;
using System.Drawing;
using System.Windows.Forms;

using static TorreDeBabel.baseLangueDataSet;

namespace TorreDeBabel {
public class frmDemarrage : Form {
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
	BackgroundImageLayout	= ImageLayout.Stretch;
	Font			= Properties.Settings.Default.DisplayFont;
	WindowState		= FormWindowState.Maximized;

	tlpMain = new TableLayoutPanel() {
		Name		= "tlpMain",
		ColumnCount	= 1,
		RowCount	= 2,
		//Size		= new Size(501, 110),
		Dock		= DockStyle.Fill,
		GrowStyle	= TableLayoutPanelGrowStyle.FixedSize,
		BackColor	= Color.Transparent
	};
	tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
	tlpMain.RowStyles.Add(new RowStyle(SizeType.AutoSize));
	tlpMain.RowStyles.Add(new RowStyle(SizeType.AutoSize));

	btnRegister = new Button() {
		Name	= "btnInscrire",
		Size	= new Size(320, 48),
		Text	= "S'inscrire",
		BackColor	= Color.FromArgb(88, 167, 0),
		ForeColor	= Color.White,
		Anchor	= AnchorStyles.None,
		FlatStyle	= FlatStyle.Flat
	};
	btnRegister.FlatAppearance.BorderSize = 0;
	btnRegister.Click += new EventHandler(Register);

	btnLogin = new Button() {
		Name	= "btnLogin",
		Size	= new Size(320, 48),
		Text	= "Connexion",
		Anchor	= AnchorStyles.None,
		FlatStyle	= FlatStyle.Flat
	};
	btnLogin.FlatAppearance.BorderSize = 0;
	btnLogin.Click += new EventHandler(Login);

	tlpMain.Controls.Add(btnRegister, 0, 0);
	tlpMain.Controls.Add(btnLogin, 0, 1);

	Controls.Add(tlpMain);

	ResumeLayout(false);
}
#endregion
#region Champs
private TableLayoutPanel	tlpMain;
private Button			btnRegister;
private Button			btnLogin;
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
	using (frmTableauBord modal = new frmTableauBord(selectedUser))
		modal.ShowDialog();
	Show();
}
#endregion
}
}
