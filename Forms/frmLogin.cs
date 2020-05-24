using System;
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
	AutoScaleMode = AutoScaleMode.Font;
	ClientSize = new Size(320, 48);
	Text = "frmLogin";
	Font = Properties.Settings.Default.DisplayFont;

	cboUsers = new ComboBox() {
		Name		= "cboUsers",
		DropDownStyle	= ComboBoxStyle.DropDownList,
		Dock		= DockStyle.Top
	};

	btnOK = new Button() {
		Name		= "btnOK",
		Text		= "OK",
		DialogResult	= DialogResult.OK,
		Dock		= DockStyle.Bottom
	};
	btnOK.Click += new EventHandler(Return);

	Controls.Add(cboUsers);
	Controls.Add(btnOK);
}
#endregion
#region Propriétés
public UtilisateursRow SelectedUser {
	get => (UtilisateursRow)tblUsers.Select("codeUtil = " + cboUsers.SelectedValue)[0];
}
#endregion
#region Champs
private UtilisateursDataTable tblUsers;
private ComboBox cboUsers;
private Button btnOK;
#endregion
#region Constructeurs
public
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
	UtilisateursTableAdapter da;

	da = new UtilisateursTableAdapter();
	tblUsers = new UtilisateursDataTable();
	da.Fill(tblUsers);
	tblUsers.Columns.Add("ncUtil", typeof(string), "pnUtil + ' ' + nomUtil");
	cboUsers.DataSource = tblUsers;
	cboUsers.DisplayMember = "ncUtil";
	cboUsers.ValueMember = "codeUtil";
}

private void
Return(object sender, EventArgs e)
{
	Close();
}
#endregion
}
}
