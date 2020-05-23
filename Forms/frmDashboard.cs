using System;
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
		private TableLayoutPanel tlpInfo;
		private Label lblCourseTitle;
		private Label lblCourseComment;
		private Label lblLessonTitle;
		private Label lblLessonComment;
		private Button btnStartLesson;
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
			this.tlpInfo = new System.Windows.Forms.TableLayoutPanel();
			this.lblCourseTitle = new System.Windows.Forms.Label();
			this.lblCourseComment = new System.Windows.Forms.Label();
			this.lblLessonTitle = new System.Windows.Forms.Label();
			this.lblLessonComment = new System.Windows.Forms.Label();
			this.btnStartLesson = new System.Windows.Forms.Button();
			this.mnuMain.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splMain)).BeginInit();
			this.splMain.Panel1.SuspendLayout();
			this.splMain.Panel2.SuspendLayout();
			this.splMain.SuspendLayout();
			this.tlpInfo.SuspendLayout();
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
			// 
			// splMain.Panel2
			// 
			this.splMain.Panel2.Controls.Add(this.tlpInfo);
			this.splMain.Size = new System.Drawing.Size(784, 387);
			this.splMain.SplitterDistance = 259;
			this.splMain.TabIndex = 1;
			// 
			// treeView1
			// 
			this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.treeView1.Location = new System.Drawing.Point(0, 0);
			this.treeView1.Name = "treeView1";
			this.treeView1.Size = new System.Drawing.Size(259, 387);
			this.treeView1.TabIndex = 0;
			this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
			// 
			// tlpInfo
			// 
			this.tlpInfo.ColumnCount = 1;
			this.tlpInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tlpInfo.Controls.Add(this.lblCourseTitle, 0, 0);
			this.tlpInfo.Controls.Add(this.lblCourseComment, 0, 1);
			this.tlpInfo.Controls.Add(this.lblLessonTitle, 0, 2);
			this.tlpInfo.Controls.Add(this.lblLessonComment, 0, 3);
			this.tlpInfo.Controls.Add(this.btnStartLesson, 0, 4);
			this.tlpInfo.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tlpInfo.Location = new System.Drawing.Point(0, 0);
			this.tlpInfo.Name = "tlpInfo";
			this.tlpInfo.RowCount = 5;
			this.tlpInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.tlpInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.tlpInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.tlpInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.tlpInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.tlpInfo.Size = new System.Drawing.Size(521, 387);
			this.tlpInfo.TabIndex = 0;
			// 
			// lblCourseTitle
			// 
			this.lblCourseTitle.AutoSize = true;
			this.lblCourseTitle.Location = new System.Drawing.Point(3, 0);
			this.lblCourseTitle.Name = "lblCourseTitle";
			this.lblCourseTitle.Size = new System.Drawing.Size(35, 13);
			this.lblCourseTitle.TabIndex = 0;
			this.lblCourseTitle.Text = "label1";
			// 
			// lblCourseComment
			// 
			this.lblCourseComment.AutoSize = true;
			this.lblCourseComment.Location = new System.Drawing.Point(3, 77);
			this.lblCourseComment.Name = "lblCourseComment";
			this.lblCourseComment.Size = new System.Drawing.Size(35, 13);
			this.lblCourseComment.TabIndex = 1;
			this.lblCourseComment.Text = "label1";
			// 
			// lblLessonTitle
			// 
			this.lblLessonTitle.AutoSize = true;
			this.lblLessonTitle.Location = new System.Drawing.Point(3, 154);
			this.lblLessonTitle.Name = "lblLessonTitle";
			this.lblLessonTitle.Size = new System.Drawing.Size(35, 13);
			this.lblLessonTitle.TabIndex = 2;
			this.lblLessonTitle.Text = "label1";
			// 
			// lblLessonComment
			// 
			this.lblLessonComment.AutoSize = true;
			this.lblLessonComment.Location = new System.Drawing.Point(3, 231);
			this.lblLessonComment.Name = "lblLessonComment";
			this.lblLessonComment.Size = new System.Drawing.Size(35, 13);
			this.lblLessonComment.TabIndex = 3;
			this.lblLessonComment.Text = "label1";
			// 
			// btnStartLesson
			// 
			this.btnStartLesson.AutoSize = true;
			this.btnStartLesson.Location = new System.Drawing.Point(3, 311);
			this.btnStartLesson.Name = "btnStartLesson";
			this.btnStartLesson.Size = new System.Drawing.Size(113, 23);
			this.btnStartLesson.TabIndex = 4;
			this.btnStartLesson.Text = "Commencer la lecon";
			this.btnStartLesson.UseVisualStyleBackColor = true;
			this.btnStartLesson.Click += new System.EventHandler(this.StartLesson);
			// 
			// frmDashboard
			// 
			this.Font = Properties.Settings.Default.DisplayFont;
			this.ClientSize = new System.Drawing.Size(784, 411);
			this.Controls.Add(this.splMain);
			this.Controls.Add(this.mnuMain);
			this.MainMenuStrip = this.mnuMain;
			this.Name = "frmDashboard";
			this.mnuMain.ResumeLayout(false);
			this.mnuMain.PerformLayout();
			this.splMain.Panel1.ResumeLayout(false);
			this.splMain.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splMain)).EndInit();
			this.splMain.ResumeLayout(false);
			this.tlpInfo.ResumeLayout(false);
			this.tlpInfo.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

}
#endregion
#region Champs
private static UtilisateursTableAdapter uta = new UtilisateursTableAdapter();
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
		tvw.Nodes.Add(new DataNode(course.titreCours, ((LeconsRow[])tabLessons
		    .Select("numCours = \'" + course.numCours + "\'"))
		    .Select(lesson => new DataNode(lesson.titreLecon, lesson)).ToArray(),
		    course)
		);
}

private void
treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
{
	object row = ((DataNode)e.Node).DataBoundObject;
	CoursRow course;

	if (row.GetType() == typeof(CoursRow)) {
		course = (CoursRow)row;
		UpdateCourseInfo(course.titreCours, course.commentCours);
	} else if (row.GetType() == typeof(LeconsRow)) {
		course = (CoursRow)(((DataNode)e.Node.Parent).DataBoundObject);
		LeconsRow lesson = (LeconsRow)row;
		UpdateCourseInfo(course.titreCours, course.commentCours);
		UpdateLessonInfo(lesson.titreLecon, lesson.IscommentLeconNull() ? "" : lesson.commentLecon);
	}
}

private void
UpdateCourseInfo(string courseTitle, string courseComment)
{
	lblCourseTitle.Text = courseTitle;
	lblCourseComment.Text = courseComment;
}

private void
UpdateLessonInfo(string lessonTitle, string lessonComment)
{
	lblLessonTitle.Text = lessonTitle;
	lblLessonComment.Text = lessonComment;
}

private void
StartLesson(object sender, EventArgs e)
{
	object dbo = ((DataNode)treeView1.SelectedNode).DataBoundObject;

	if (dbo.GetType() == typeof(LeconsRow)) {
		using (frmLecon modal = new frmLecon((LeconsRow)dbo)) {
			modal.ShowDialog();
			if (modal.DialogResult == DialogResult.OK)
				++user.codeLeçon;
			/*else if (modal.DialogResult == DialogResult.Cancel)
				user.codeExo = modal.LastExercise;*/
		}
	}
	//ta.Update(user);
}
#endregion
}

class DataNode : TreeNode {
#region Properties
public object DataBoundObject { get; set; }
#endregion
#region Constructors
public
DataNode(string text, object dataBoundObject)
{
	Name = "nod" + text;
	Text = text;
	DataBoundObject = dataBoundObject;
}

public
DataNode(string text, DataNode[] children, object dataBoundObject) : this(text, dataBoundObject)
{
	Nodes.AddRange(children);
}
#endregion
}
}
