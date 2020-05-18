using System.Windows.Forms;
using TorreDeBabel.baseLangueDataSetTableAdapters;
using static TorreDeBabel.baseLangueDataSet;

namespace TorreDeBabel {
class frmDashboard : Form {
#region Designer
private System.ComponentModel.IContainer components = null;
		private ToolStripMenuItem mniUser;
		private ToolStripMenuItem déconnecterToolStripMenuItem;
		private SplitContainer splMain;
		private MenuStrip mnuMain;


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
			this.mnuMain = new System.Windows.Forms.MenuStrip();
			this.mniUser = new System.Windows.Forms.ToolStripMenuItem();
			this.déconnecterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.splMain = new System.Windows.Forms.SplitContainer();
			this.mnuMain.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splMain)).BeginInit();
			this.splMain.SuspendLayout();
			this.SuspendLayout();
			// 
			// mnuMain
			// 
			this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniUser});
			this.mnuMain.Location = new System.Drawing.Point(0, 0);
			this.mnuMain.Name = "mnuMain";
			this.mnuMain.Size = new System.Drawing.Size(284, 24);
			this.mnuMain.TabIndex = 0;
			// 
			// mniUser
			// 
			this.mniUser.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.déconnecterToolStripMenuItem});
			this.mniUser.Name = "mniUser";
			this.mniUser.Size = new System.Drawing.Size(72, 20);
			this.mniUser.Text = "Utilisateur";
			// 
			// déconnecterToolStripMenuItem
			// 
			this.déconnecterToolStripMenuItem.Name = "déconnecterToolStripMenuItem";
			this.déconnecterToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.déconnecterToolStripMenuItem.Text = "Déconnecter";
			// 
			// splMain
			// 
			this.splMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splMain.Location = new System.Drawing.Point(0, 24);
			this.splMain.Name = "splMain";
			this.splMain.Size = new System.Drawing.Size(284, 237);
			this.splMain.SplitterDistance = 94;
			this.splMain.TabIndex = 1;
			// 
			// frmDashboard
			// 
			this.ClientSize = new System.Drawing.Size(284, 261);
			this.Controls.Add(this.splMain);
			this.Controls.Add(this.mnuMain);
			this.MainMenuStrip = this.mnuMain;
			this.Name = "frmDashboard";
			this.mnuMain.ResumeLayout(false);
			this.mnuMain.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.splMain)).EndInit();
			this.splMain.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

}
#endregion
#region Champs
UtilisateursTableAdapter ta;
UtilisateursRow user;
#endregion
#region Constructeurs
public
frmDashboard(UtilisateursRow user)
{
	this.user = user;
	InitializeComponent();
}
#endregion
#region Méthodes
private void
StartLesson(LeconsRow lesson)
{
	using (frmLecon modal = new frmLecon(lesson)) {
		modal.ShowDialog();
		if (modal.DialogResult == DialogResult.OK)
			++user.codeLeçon;
		/*else if (modal.DialogResult == DialogResult.Cancel)
			user.codeExo = modal.LastExercise;*/
	}
	ta.Update(user);
}
#endregion
}
}
