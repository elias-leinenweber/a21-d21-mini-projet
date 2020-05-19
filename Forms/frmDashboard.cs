using System.Data;
using System.Linq;
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
		private TreeView treeView1;
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
			this.treeView1 = new System.Windows.Forms.TreeView();
			this.mnuMain.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splMain)).BeginInit();
			this.splMain.Panel1.SuspendLayout();
			this.splMain.SuspendLayout();
			this.SuspendLayout();
			// 
			// mnuMain
			// 
			this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniUser});
			this.mnuMain.Location = new System.Drawing.Point(0, 0);
			this.mnuMain.Name = "mnuMain";
			this.mnuMain.Size = new System.Drawing.Size(784, 24);
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
			this.déconnecterToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
			this.déconnecterToolStripMenuItem.Text = "Déconnecter";
			// 
			// splMain
			// 
			this.splMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splMain.Location = new System.Drawing.Point(0, 24);
			this.splMain.Name = "splMain";
			// 
			// splMain.Panel1
			// 
			this.splMain.Panel1.Controls.Add(this.treeView1);
			this.splMain.Size = new System.Drawing.Size(784, 387);
			this.splMain.SplitterDistance = 259;
			this.splMain.TabIndex = 1;
			// 
			// treeView1
			// 
			this.treeView1.Location = new System.Drawing.Point(0, 0);
			this.treeView1.Name = "treeView1";
			this.treeView1.Size = new System.Drawing.Size(256, 384);
			this.treeView1.TabIndex = 0;
			this.treeView1.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseDoubleClick);
			// 
			// frmDashboard
			// 
			this.ClientSize = new System.Drawing.Size(784, 411);
			this.Controls.Add(this.splMain);
			this.Controls.Add(this.mnuMain);
			this.MainMenuStrip = this.mnuMain;
			this.Name = "frmDashboard";
			this.mnuMain.ResumeLayout(false);
			this.mnuMain.PerformLayout();
			this.splMain.Panel1.ResumeLayout(false);
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
	FillTreeView(treeView1);
}
#endregion
#region Méthodes
private void
FillTreeView(TreeView tvw)
{
	CoursDataTable tabCourses = new CoursDataTable();
	LeconsDataTable tabLessons = new LeconsDataTable();

	new CoursTableAdapter().Fill(tabCourses);
	new LeconsTableAdapter().Fill(tabLessons);
	foreach (CoursRow course in tabCourses)
		tvw.Nodes.Add(new TreeNode(course.titreCours,
		    ((LeconsRow[])tabLessons.Select("numCours = \'" + course.numCours + "\'"))
		    .Select(lr => new TreeNode(lr.titreLecon)).ToArray())
		);
}

private void
treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
{
	//StartLesson(new LeconsRow())
}

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
