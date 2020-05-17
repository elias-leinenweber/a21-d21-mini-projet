using System;
using System.Drawing;
using System.Windows.Forms;

using TorreDeBabel.baseLangueDataSetTableAdapters;
using static TorreDeBabel.baseLangueDataSet;

namespace TorreDeBabel {
partial class frmLogin : Form {
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
	components = new System.ComponentModel.Container();

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
	Load += new EventHandler(FillCboUsers);
}
#endregion
#region Méthodes
private void
FillCboUsers(object sender, EventArgs e)
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
