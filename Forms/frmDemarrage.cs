using System;
using System.Drawing;
using System.Windows.Forms;

using TorreDeBabel.Forms;
using static TorreDeBabel.baseLangueDataSet;

namespace TorreDeBabel {
public partial class frmDemarrage : Form {
#region Champs
private TableLayoutPanel	tlpMain;
private Button			btnInscrire;
private Button			btnLogin;
#endregion
#region Constructeurs
public
frmDemarrage()
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

	btnInscrire = new Button() {
		Name	= "btnInscrire",
		Size	= new Size(320, 48),
		Text	= "S'inscrire",
		BackColor	= Color.FromArgb(88, 167, 0),
		ForeColor	= Color.White,
		Anchor	= AnchorStyles.None,
		FlatStyle	= FlatStyle.Flat
	};
	btnInscrire.FlatAppearance.BorderSize = 0;
	btnInscrire.Click += new EventHandler(Register);

	btnLogin = new Button() {
		Name	= "btnLogin",
		Size	= new Size(320, 48),
		Text	= "Connexion",
		Anchor	= AnchorStyles.None,
		FlatStyle	= FlatStyle.Flat
	};
	btnLogin.FlatAppearance.BorderSize = 0;
	btnLogin.Click += new EventHandler(Login);

	tlpMain.Controls.Add(btnInscrire, 0, 0);
	tlpMain.Controls.Add(btnLogin, 0, 1);

	Controls.Add(tlpMain);

	ResumeLayout(false);
}
#endregion
#region Méthodes
private void
Register(object sender, EventArgs e)
{
	frmRegister frmRegister = new frmRegister();

	/*if (frmRegister.ShowDialog() == DialogResult.OK)
		OpenDashboard(frmRegister.SelectedUser);*/
		
}

private void
Login(object sender, EventArgs e)
{
	frmLogin frmLogin = new frmLogin();

	if (frmLogin.ShowDialog() == DialogResult.OK)
		OpenDashboard(frmLogin.SelectedUser);
}

private void
OpenDashboard(UtilisateursRow selectedUser)
{
	frmTableauBord frmTableauBord;

	frmTableauBord = new frmTableauBord(selectedUser);
	Hide();
	frmTableauBord.ShowDialog();
	Show();
}
#endregion
}
}
