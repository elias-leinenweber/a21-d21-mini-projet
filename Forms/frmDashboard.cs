﻿using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
 
using TorreDeBabel.baseLangueDataSetTableAdapters;
using TorreDeBabel.Forms;
using TorreDeBabel.Properties;

using static TorreDeBabel.baseLangueDataSet;

namespace TorreDeBabel {
class frmDashboard : Form {
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
	Font = Settings.Default.DisplayFont;
	this.mnuMain = new System.Windows.Forms.MenuStrip();
	this.mniUser = new System.Windows.Forms.ToolStripMenuItem();
	this.administrationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
	this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
	this.déconnecterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
	this.quitterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
	this.splMain = new System.Windows.Forms.SplitContainer();
	this.tvwProgress = new System.Windows.Forms.TreeView();
	this.tlpInfo = new System.Windows.Forms.TableLayoutPanel();
	this.lblCourseTitle = new System.Windows.Forms.Label();
	this.lblCourseComment = new System.Windows.Forms.Label();
	this.lblLessonTitle = new System.Windows.Forms.Label();
	this.lblLessonComment = new System.Windows.Forms.Label();
	this.btnStartLesson = new System.Windows.Forms.Button();
	this.usernameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
	this.mnuMain.Size = new System.Drawing.Size(624, 24);
	this.mnuMain.TabIndex = 0;
	// 
	// mniUser
	// 
	this.mniUser.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usernameToolStripMenuItem,
            this.administrationToolStripMenuItem,
            this.toolStripSeparator1,
            this.déconnecterToolStripMenuItem,
            this.quitterToolStripMenuItem
	});
	this.mniUser.Name = "mniUser";
	this.mniUser.Size = new System.Drawing.Size(72, 20);
	this.mniUser.Text = "Utilisateur";
	// 
	// administrationToolStripMenuItem
	// 
	this.administrationToolStripMenuItem.Name = "administrationToolStripMenuItem";
	this.administrationToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
	this.administrationToolStripMenuItem.Text = "Administration...";
	this.administrationToolStripMenuItem.Click += new System.EventHandler(this.administrationToolStripMenuItem_Click);
	// 
	// toolStripSeparator1
	// 
	this.toolStripSeparator1.Name = "toolStripSeparator1";
	this.toolStripSeparator1.Size = new System.Drawing.Size(159, 6);
	// 
	// déconnecterToolStripMenuItem
	// 
	this.déconnecterToolStripMenuItem.Name = "déconnecterToolStripMenuItem";
	this.déconnecterToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
	this.déconnecterToolStripMenuItem.Text = "Se déconnecter";
	this.déconnecterToolStripMenuItem.Click += new System.EventHandler(this.déconnecterToolStripMenuItem_Click);
	// 
	// quitterToolStripMenuItem
	// 
	this.quitterToolStripMenuItem.Name = "quitterToolStripMenuItem";
	this.quitterToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
	this.quitterToolStripMenuItem.Text = "Quitter";
	this.quitterToolStripMenuItem.Click += new System.EventHandler(this.quitterToolStripMenuItem_Click);
	// 
	// splMain
	// 
	this.splMain.Dock = System.Windows.Forms.DockStyle.Fill;
	this.splMain.Location = new System.Drawing.Point(0, 24);
	this.splMain.Name = "splMain";
	// 
	// splMain.Panel1
	// 
	this.splMain.Panel1.Controls.Add(this.tvwProgress);
	// 
	// splMain.Panel2
	// 
	this.splMain.Panel2.Controls.Add(this.tlpInfo);
	this.splMain.Size = new System.Drawing.Size(624, 417);
	this.splMain.SplitterDistance = 240;
	this.splMain.TabIndex = 1;
	// 
	// treeView1
	// 
	this.tvwProgress.Dock = System.Windows.Forms.DockStyle.Fill;
	this.tvwProgress.Location = new System.Drawing.Point(0, 0);
	this.tvwProgress.Name = "treeView1";
	this.tvwProgress.Size = new System.Drawing.Size(240, 417);
	this.tvwProgress.TabIndex = 0;
	this.tvwProgress.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvwProgress_NodeMouseClick);
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
	this.tlpInfo.Size = new System.Drawing.Size(380, 417);
	this.tlpInfo.TabIndex = 0;
	// 
	// lblCourseTitle
	// 
	this.lblCourseTitle.AutoSize = true;
	this.lblCourseTitle.Location = new System.Drawing.Point(3, 0);
	this.lblCourseTitle.Name = "lblCourseTitle";
	this.lblCourseTitle.Size = new System.Drawing.Size(52, 21);
	this.lblCourseTitle.TabIndex = 0;
	this.lblCourseTitle.Text = "";
	lblCourseTitle.Font = new Font(Font.FontFamily, 26, FontStyle.Bold, GraphicsUnit.Pixel);
	// 
	// lblCourseComment
	// 
	this.lblCourseComment.AutoSize = true;
	this.lblCourseComment.Location = new System.Drawing.Point(3, 83);
	this.lblCourseComment.Name = "lblCourseComment";
	this.lblCourseComment.Size = new System.Drawing.Size(52, 21);
	this.lblCourseComment.TabIndex = 1;
	this.lblCourseComment.Text = "";
	// 
	// lblLessonTitle
	// 
	this.lblLessonTitle.AutoSize = true;
	this.lblLessonTitle.Location = new System.Drawing.Point(3, 166);
	this.lblLessonTitle.Name = "lblLessonTitle";
	this.lblLessonTitle.Size = new System.Drawing.Size(52, 21);
	this.lblLessonTitle.TabIndex = 2;
	this.lblLessonTitle.Text = "";
	lblLessonTitle.Font = new Font(Font.FontFamily, 16, FontStyle.Bold, GraphicsUnit.Pixel);
	// 
	// lblLessonComment
	// 
	this.lblLessonComment.AutoSize = true;
	this.lblLessonComment.Location = new System.Drawing.Point(3, 249);
	this.lblLessonComment.Name = "lblLessonComment";
	this.lblLessonComment.Size = new System.Drawing.Size(52, 21);
	this.lblLessonComment.TabIndex = 3;
	this.lblLessonComment.Text = "";
	// 
	// btnStartLesson
	// 
	this.btnStartLesson.AutoSize = true;
	this.btnStartLesson.Location = new System.Drawing.Point(3, 335);
	this.btnStartLesson.Name = "btnStartLesson";
	this.btnStartLesson.Size = new System.Drawing.Size(162, 31);
	this.btnStartLesson.TabIndex = 4;
	this.btnStartLesson.Text = "Commencer la leçon";
	this.btnStartLesson.UseVisualStyleBackColor = true;
	this.btnStartLesson.Enabled = false;
	this.btnStartLesson.Click += new System.EventHandler(this.StartLesson);
	// 
	// usernameToolStripMenuItem
	// 
	this.usernameToolStripMenuItem.Name = "usernameToolStripMenuItem";
	this.usernameToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
	this.usernameToolStripMenuItem.Text = "username";
	// 
	// frmDashboard
	// 
	this.ClientSize = new System.Drawing.Size(624, 441);
	this.Controls.Add(this.splMain);
	this.Controls.Add(this.mnuMain);
	this.Font = global::TorreDeBabel.Properties.Settings.Default.DisplayFont;
	this.Icon = global::TorreDeBabel.Properties.Resources.babel;
	this.MainMenuStrip = this.mnuMain;
	this.MaximizeBox = false;
	this.MinimizeBox = false;
	this.Name = "frmDashboard";
	this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
	this.Text = "Tableau de bord";
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

private ToolStripMenuItem	mniUser;
private ToolStripMenuItem	déconnecterToolStripMenuItem;
private SplitContainer		splMain;
private TreeView		tvwProgress;
private TableLayoutPanel	tlpInfo;
private Label			lblCourseTitle;
private Label			lblCourseComment;
private Label			lblLessonTitle;
private Label			lblLessonComment;
private Button			btnStartLesson;
private ToolStripMenuItem	administrationToolStripMenuItem;
private ToolStripSeparator	toolStripSeparator1;
private ToolStripMenuItem	quitterToolStripMenuItem;
private ToolStripMenuItem	usernameToolStripMenuItem;
private MenuStrip		mnuMain;
#endregion
#region Champs
UtilisateursRow user;
#endregion
#region Constructeurs
public
frmDashboard(UtilisateursRow user)
{
	this.user = user;
	InitializeComponent();
	FillTreeView(tvwProgress);
	administrationToolStripMenuItem.Enabled = (((user.codeUtil & 4) >> 2) & (((user.codeUtil & 2) >> 1) ^ (user.codeUtil & 1))) == 1;
	usernameToolStripMenuItem.Enabled = false;
	usernameToolStripMenuItem.Text = user.pnUtil + " " + user.nomUtil;
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

	DataNode courseNode;

	foreach (CoursRow course in tabCourses) {
		courseNode = new DataNode(course.titreCours, course){ ImageIndex = GetImageIndex(course.numCours.CompareTo(user.codeCours)) };
		courseNode.SelectedImageIndex = courseNode.ImageIndex;
		courseNode.Nodes.AddRange(((LeconsRow[])tabLessons
		    .Select("numCours = \'" + course.numCours + "\'"))
		    .Select(lesson => new DataNode(lesson.titreLecon, lesson)
		        { ImageIndex = courseNode.ImageIndex == 2 ? 2 :
			    (courseNode.ImageIndex == 1 ? GetImageIndex(user.codeLeçon.CompareTo(lesson.numLecon)) : 0)})
		    .ToArray());
		tvw.Nodes.Add(courseNode);
	}

	tvw.ImageList = new ImageList();
	tvw.ImageList.Images.AddRange(new Image[4] {Resources.empty, Resources.partial, Resources._checked, Resources.rarrow} );
	tvw.SelectedImageIndex = 3;
}

private int
GetImageIndex(int diff)
{
	if (diff > 0)
		return 2;
	else if (diff == 0)
		return 1;
	else
		return 0;
}

private void
tvwProgress_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
{
	object row = (e.Node as DataNode).DataBoundObject;
	CoursRow course;

	if (row.GetType() == typeof(CoursRow)) {
		course = (CoursRow)row;
		UpdateCourseInfo(course.titreCours, course.commentCours);
		lblLessonTitle.Visible = lblLessonComment.Visible = btnStartLesson.Enabled = false;
	} else if (row.GetType() == typeof(LeconsRow)) {
		course = (CoursRow)(((DataNode)e.Node.Parent).DataBoundObject);
		LeconsRow lesson = (LeconsRow)row;
		UpdateCourseInfo(course.titreCours, course.commentCours);
		UpdateLessonInfo(lesson.titreLecon, lesson.IscommentLeconNull() ? "" : lesson.commentLecon);
		lblLessonTitle.Visible = lblLessonComment.Visible = btnStartLesson.Enabled = true;
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
	object dbo = (tvwProgress.SelectedNode as DataNode).DataBoundObject;

	if (dbo.GetType() == typeof(LeconsRow)) {
		LeconsRow lesson = (LeconsRow)dbo;
		using (frmLesson modal = new frmLesson(lesson)) {
			modal.ShowDialog();
			if (modal.DialogResult == DialogResult.OK) {
				user.BeginEdit();
				user.codeCours	= lesson.numCours;
				user.codeLeçon	= lesson.numLecon + 1;
				user.codeExo	= 0;
				user.AcceptChanges();
			}
			//else if (modal.DialogResult == DialogResult.Cancel)	// TODO gérer revenir au
			//	user.codeExo = modal.LastExercise;		// dernier exo
			UpdateUserProgress(user);
			//uta.Update(TorreDeBabel.tblUsers);
		}
	}
}

private static void
UpdateUserProgress(UtilisateursRow user)
{
	using (OleDbConnection connection = new OleDbConnection(Settings.Default.baseLangueConnectionString)) {
		connection.Open();

		OleDbCommand command = connection.CreateCommand();
		OleDbTransaction transaction;

		// Démarre la transaction (en local).
		transaction = connection.BeginTransaction(IsolationLevel.Chaos);

		command.Connection = connection;
		command.Transaction = transaction;

		try {
			command.CommandText =
			    "UPDATE Utilisateurs\n" +
			    "SET [codeExo] = @exercise, [codeLeçon] = @lesson, [codeCours] = @course\n" +
			    "WHERE [codeUtil] = @id";
			command.Parameters.AddWithValue("@exercise", user.codeExo);
			command.Parameters.AddWithValue("@lesson", user.codeLeçon);
			command.Parameters.AddWithValue("@course", user.codeCours);
			command.Parameters.AddWithValue("@id", user.codeUtil);
			if (command.ExecuteNonQuery() != 1)
				throw new Exception("Y a un \"couac\"");

			// Essaie de commit la transaction.
			transaction.Commit();
		} catch (Exception) {
			transaction.Rollback();
		} finally {
			connection.Close();
		}
	}
}
#endregion

private void
administrationToolStripMenuItem_Click(object sender, EventArgs e)
{
	UseWaitCursor = true;
	new frmAdmin().Show();
	UseWaitCursor = false;
}

private void
déconnecterToolStripMenuItem_Click(object sender, EventArgs e)
{
	Close();
}

private void
quitterToolStripMenuItem_Click(object sender, EventArgs e)
{
	Application.Exit();
}

private void frmDashboard_FormClosing(object sender, FormClosingEventArgs e)
{
	Application.Exit();
}
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
