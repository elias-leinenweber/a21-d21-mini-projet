using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

using TorreDeBabel.baseLangueDataSetTableAdapters;
using static TorreDeBabel.baseLangueDataSet;

namespace TorreDeBabel {
	public partial class frmDemarrage : Form {
#region Propriétés
TableLayoutPanel	tlpMain;
Button			btnInscrire;
Button			btnLogin;
ComboBox		cboUsers;
#endregion
#region Constructeurs
public
frmDemarrage()
{
	InitializeComponent();

	Name = "frmDemarrage";
	Text = Application.ProductName;
	BackgroundImage		= Properties.Resources.TowerOfBabel;
	BackgroundImageLayout	= ImageLayout.Stretch;
	Font			= Properties.Settings.Default.DisplayFont;
	WindowState		= FormWindowState.Maximized;

	tlpMain = new TableLayoutPanel() {
		Name		= "tlpMain",
		ColumnCount	= 1,
		RowCount	= 4,
		//Size		= new Size(501, 110),
		Dock		= DockStyle.Fill,
		GrowStyle	= TableLayoutPanelGrowStyle.FixedSize,
		BackColor	= Color.Transparent
	};
	tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
	for (int i = 0; i < 4; ++i)
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

	btnLogin = new Button() {
		Name	= "btnLogin",
		Size	= new Size(320, 48),
		Text	= "Connexion",
		Anchor	= AnchorStyles.None,
		FlatStyle	= FlatStyle.Flat
	};
	btnLogin.FlatAppearance.BorderSize = 0;
	btnLogin.Click += new EventHandler(Login);

	cboUsers = new ComboBox() {
		Name	= "cboUsers",
		Size	= new Size(320, 48),
		DropDownStyle = ComboBoxStyle.DropDownList,
		Visible	= false
	};
	FillCboUsers();

	tlpMain.Controls.Add(btnInscrire, 0, 0);
	tlpMain.Controls.Add(btnLogin, 0, 2);
	tlpMain.Controls.Add(cboUsers, 0, 3);
	Controls.Add(tlpMain);
}
#endregion
#region Méthodes
private void
Login(object sender, EventArgs e)
{
	cboUsers.Visible = true;
}

private void
FillCboUsers()
{
	UtilisateursTableAdapter	da;
	UtilisateursDataTable		dt;

	da = new UtilisateursTableAdapter();
	dt = new UtilisateursDataTable();
	da.Fill(dt);
	dt.Columns.Add("ncUtil", typeof(string), "pnUtil + ' ' + nomUtil");
	cboUsers.DataSource = dt;
	cboUsers.DisplayMember = "ncUtil";
	cboUsers.ValueMember = "codeUtil";
}
#endregion
}
}
