using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

using TorreDeBabel.baseLangueDataSetTableAdapters;
using static TorreDeBabel.baseLangueDataSet;

namespace TorreDeBabel {
class frmLogin : Form {
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

	Name		= "frmLogin";
	BackColor	= Color.White;
	ClientSize	= new Size(600, 238);
	Font		= Properties.Settings.Default.DisplayFont;
	FormBorderStyle	= FormBorderStyle.FixedSingle;
	MaximizeBox	= false;
	MinimizeBox	= false;
	ShowIcon	= false;
	ShowInTaskbar	= false;
	SizeGripStyle	= SizeGripStyle.Hide;
	StartPosition	= FormStartPosition.CenterParent;

	lblLogin = new Label() {
		Name		= "lblLogin",
		Text		= "Se connecter",
		Location	= new Point(40, 30),
		Size		= new Size(ClientSize.Width - 2 * 40, 40),
		Font		= new Font(Font.FontFamily, 26, FontStyle.Bold, GraphicsUnit.Pixel)
	};

	cboUsers = new ComboBox() {
		Name		= "cboUsers",
		DropDownStyle	= ComboBoxStyle.DropDownList,
		Location	= new Point(lblLogin.Left, lblLogin.Top + lblLogin.Height + 10),
		Size		= new Size(lblLogin.Width, 64),
		Font		= new Font(Font.FontFamily, 16, GraphicsUnit.Pixel)
	};

	btnOK = new Button() {
		Name		= "btnOK",
		Text		= "SE CONNECTER",
		DialogResult	= DialogResult.OK,
		Location	= new Point(lblLogin.Left, cboUsers.Top + cboUsers.Height + 20),
		Size		= new Size(lblLogin.Width, 54),
		Font		= new Font(Font.FontFamily, 15, FontStyle.Bold, GraphicsUnit.Pixel),
		BackColor	= Color.FromArgb(28, 176, 246),
		ForeColor	= Color.White
	};
	btnOK.Click += new EventHandler(Return);

	ClientSize = new Size(ClientSize.Width, btnOK.Top + btnOK.Height + 20);
	Controls.Add(lblLogin);
	Controls.Add(cboUsers);
	Controls.Add(btnOK);
	Move += new EventHandler(PreventMove);
}

private Label		lblLogin;
private ComboBox	cboUsers;
private Button		btnOK;
#endregion
#region Propriétés
public UtilisateursRow SelectedUser {
	get => (UtilisateursRow)tblUsers.Select("codeUtil = " + cboUsers.SelectedValue)[0];
}
#endregion
#region Champs
private static UtilisateursTableAdapter	adpUsers = new UtilisateursTableAdapter();
private static UtilisateursDataTable	tblUsers = new UtilisateursDataTable();
#endregion
#region Constructeurs
static
frmLogin()
{
	adpUsers.Fill(tblUsers);
	tblUsers.Columns.Add("ncUtil", typeof(string), "pnUtil + ' ' + nomUtil");
}

internal
frmLogin()
{
	InitializeComponent();
	FillCboUsers();
}
#endregion
#region Méthodes
private void
FillCboUsers()
{
	FillComboBox(cboUsers, tblUsers, "ncUtil", "codeUtil");
}

public static void
FillComboBox(ComboBox cbo, DataTable tbl, string displayMember, string valueMember)
{
	cbo.DataSource		= tbl;
	cbo.DisplayMember	= displayMember;
	cbo.ValueMember		= valueMember;
}

public static void
FillComboBox(ComboBox cbo, DataRow[] rows, string displayMember, string valueMember)
{
	cbo.DataSource		= rows;
	cbo.DisplayMember	= displayMember;
	cbo.ValueMember		= valueMember;
}

private void
Return(object sender, EventArgs e)
{
	Close();
}

private void
PreventMove(object sender, EventArgs e)
{
	CenterToParent();
}
#endregion
}
}
