using System;
using System.Drawing;
using System.Windows.Forms;

using TorreDeBabel.baseLangueDataSetTableAdapters;

using static TorreDeBabel.baseLangueDataSet;

namespace TorreDeBabel.Forms {
class frmAdmin : Form {
#region Designer
/// <summary>
/// Required designer variable.
/// </summary>
private System.ComponentModel.IContainer components = null;

/// <summary>
/// Clean up any resources being used.
/// </summary>
/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
protected override void Dispose(bool disposing)
{
	if (disposing && components != null)
		components.Dispose();
	base.Dispose(disposing);
}

/// <summary>
/// Required method for Designer support - do not modify
/// the contents of this method with the code editor.
/// </summary>
private void InitializeComponent()
{
	components = new System.ComponentModel.Container();

	Name		= "frmAdmin";
	BackColor	= Color.White;
	ClientSize	= new Size(600, 600);
	Font		= Properties.Settings.Default.DisplayFont;
	FormBorderStyle	= FormBorderStyle.FixedSingle;
	MaximizeBox	= false;
	MinimizeBox	= false;
	ShowIcon	= false;
	ShowInTaskbar	= false;
	SizeGripStyle	= SizeGripStyle.Hide;
	StartPosition	= FormStartPosition.CenterParent;

	tlpMain	= new TableLayoutPanel() {
		Name		= "tlpMain",
		ColumnCount	= 1,
		RowCount	= 7,
		Dock		= DockStyle.Fill
	};
	tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
	for (int i = 0; i < tlpMain.RowCount; ++i)
		tlpMain.RowStyles.Add(new RowStyle(SizeType.AutoSize));

	lblTitle = new Label() {
		Name		= "lblTitle",
		Text		= "Administration",
		AutoSize	= true,
		Font		= new Font(Font.FontFamily, 26, FontStyle.Bold, GraphicsUnit.Pixel)
	};
	tlpMain.Controls.Add(lblTitle, 0, 0);

	lblCourse = new Label() {
		Name		= "lblCourse",
		Text		= "Cours",
		AutoSize	= true,
		Font		= new Font(Font.FontFamily, 16, GraphicsUnit.Pixel)
	};
	tlpMain.Controls.Add(lblCourse, 0, 1);
	cboCourse = new ComboBox() {
		Name		= "cboCourse",
		DropDownStyle	= ComboBoxStyle.DropDownList,
		Font		= new Font(Font.FontFamily, 16, GraphicsUnit.Pixel)
	};
	cboCourse.SelectedValueChanged += new EventHandler(UpdateLessons);
	cboCourse.SelectedValueChanged += new EventHandler(UpdateExercises);
	tlpMain.Controls.Add(cboCourse, 0, 2);

	lblLesson = new Label() {
		Name		= "lblLesson",
		Text		= "Leçon",
		AutoSize	= true,
		Font		= new Font(Font.FontFamily, 16, GraphicsUnit.Pixel)
	};
	tlpMain.Controls.Add(lblLesson, 0, 3);
	cboLesson = new ComboBox() {
		Name		= "cboLesson",
		DropDownStyle	= ComboBoxStyle.DropDownList,
		Font		= new Font(Font.FontFamily, 16, GraphicsUnit.Pixel)
	};
	cboLesson.SelectedValueChanged += new EventHandler(UpdateExercises);
	tlpMain.Controls.Add(cboLesson, 0, 4);

	lblExercises = new Label() {
		Name		= "lblExercises",
		Text		= "Exercices",
		AutoSize	= true,
		Font		= new Font(Font.FontFamily, 16, GraphicsUnit.Pixel)
	};
	tlpMain.Controls.Add(lblExercises, 0, 5);
	dgvExercises = new DataGridView() {
		Name			= "dvgExercises",
		Dock			= DockStyle.Fill,
		AutoSizeColumnsMode	= DataGridViewAutoSizeColumnsMode.AllCells,
		AutoSizeRowsMode	= DataGridViewAutoSizeRowsMode.AllCells,
		ReadOnly		= true
	};
	dgvExercises.DataError += new DataGridViewDataErrorEventHandler(IgnoreDataError);
	tlpMain.Controls.Add(dgvExercises, 0, 6);

	Controls.Add(tlpMain);
}

private TableLayoutPanel	tlpMain;
private Label			lblTitle;
private Label			lblCourse;
private ComboBox		cboCourse;
private Label			lblLesson;
private ComboBox		cboLesson;
private Label			lblExercises;
private DataGridView		dgvExercises;
#endregion
private static CoursTableAdapter	adpCourses	= new CoursTableAdapter();
private static CoursDataTable		tblCourses	= new CoursDataTable();
private static LeconsTableAdapter	adpLessons	= new LeconsTableAdapter();
private static LeconsDataTable		tblLessons	= new LeconsDataTable();
private static ExercicesTableAdapter	adpExercises	= new ExercicesTableAdapter();
private static ExercicesDataTable	tblExercises	= new ExercicesDataTable();

private LeconsRow[]		CurrentCourseLessons;
private ExercicesRow[]		Exercises;

static
frmAdmin()
{
	adpCourses.Fill(tblCourses);
	adpLessons.Fill(tblLessons);
	adpExercises.Fill(tblExercises);
}

internal
frmAdmin()
{
	InitializeComponent();
	frmLogin.FillComboBox(cboCourse, tblCourses, "titreCours", "numCours");
}

private void
UpdateLessons(object sender, EventArgs e)
{
	CurrentCourseLessons = (LeconsRow[])tblLessons.Select("numCours = '" + cboCourse.SelectedValue + "'");
	if (cboLesson.DataSource != null)
		cboLesson.DataSource = CurrentCourseLessons;
	else
		frmLogin.FillComboBox(cboLesson, CurrentCourseLessons, "titreLecon", "numLecon");
}

private void
UpdateExercises(object sender, EventArgs e)
{
	Exercises = (ExercicesRow[])tblExercises.Select("numCours = '" + cboCourse.SelectedValue + "' AND numLecon = '" + cboLesson.SelectedValue + "'");
	dgvExercises.DataSource = Exercises;
}

private void
IgnoreDataError(object sender, DataGridViewDataErrorEventArgs e)
{}
}
}
