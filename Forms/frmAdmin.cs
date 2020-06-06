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
	Text		= "Administration";
	BackColor	= Color.White;
	ClientSize	= new Size(1080, 690);
	Font		= Properties.Settings.Default.DisplayFont;
	FormBorderStyle	= FormBorderStyle.FixedSingle;
	MaximizeBox	= false;
	MinimizeBox	= false;
	ShowIcon	= false;
	SizeGripStyle	= SizeGripStyle.Hide;
	StartPosition	= FormStartPosition.CenterScreen;

	lblTitle = new Label() {
		Name		= "lblTitle",
		Text		= "Administration",
		Location	= new Point(40, 30),
		Size		= new Size(ClientSize.Width - 2 * 40, 40),
		Font		= new Font(Font.FontFamily, 26, FontStyle.Bold, GraphicsUnit.Pixel)
	};
	Controls.Add(lblTitle);

	lblCourse = new Label() {
		Name		= "lblCourse",
		Text		= "Cours",
		Location	= new Point(lblTitle.Left, lblTitle.Top + lblTitle.Height + 20),
		Size		= new Size(lblTitle.Width / 2 - 10, 20),
		Font		= new Font(Font.FontFamily, 16, GraphicsUnit.Pixel)
	};
	Controls.Add(lblCourse);
	cboCourse = new ComboBox() {
		Name		= "cboCourse",
		DropDownStyle	= ComboBoxStyle.DropDownList,
		Location	= new Point(lblCourse.Left, lblCourse.Top + lblCourse.Height + 10),
		Size		= new Size(lblCourse.Width, 64),
		Font		= new Font(Font.FontFamily, 16, GraphicsUnit.Pixel)
	};
	cboCourse.SelectedValueChanged += new EventHandler(UpdateLessons);
	cboCourse.SelectedValueChanged += new EventHandler(UpdateExercises);
	Controls.Add(cboCourse);

	lblLesson = new Label() {
		Name		= "lblLesson",
		Text		= "Leçon",
		Location	= new Point(lblCourse.Left + lblCourse.Width + 20, lblCourse.Top),
		Size		= new Size(lblCourse.Width, 20),
		Font		= new Font(Font.FontFamily, 16, GraphicsUnit.Pixel)
	};
	Controls.Add(lblLesson);
	cboLesson = new ComboBox() {
		Name		= "cboLesson",
		DropDownStyle	= ComboBoxStyle.DropDownList,
		Location	= new Point(cboCourse.Left + cboCourse.Width + 20, cboCourse.Top),
		Size		= new Size(cboCourse.Width, 64),
		Font		= new Font(Font.FontFamily, 16, GraphicsUnit.Pixel)
	};
	cboLesson.SelectedValueChanged += new EventHandler(UpdateExercises);
	Controls.Add(cboLesson);

	lblExercises = new Label() {
		Name		= "lblExercises",
		Text		= "Exercices",
		Location	= new Point(cboCourse.Left, cboCourse.Top + cboCourse.Height + 20),
		Size		= new Size(lblTitle.Width, 20),
		Font		= new Font(Font.FontFamily, 16, GraphicsUnit.Pixel)
	};
	Controls.Add(lblExercises);
	dgvExercises = new DataGridView() {
		Name			= "dvgExercises",
		AutoSizeColumnsMode	= DataGridViewAutoSizeColumnsMode.AllCells,
		AutoSizeRowsMode	= DataGridViewAutoSizeRowsMode.AllCells,
		Location		= new Point(lblExercises.Left, lblExercises.Top + lblExercises.Height + 10),
		Width			= lblExercises.Width,
		ReadOnly		= true
	};
	dgvExercises.Height = ClientSize.Height - dgvExercises.Top - 20;
	dgvExercises.DataError += new DataGridViewDataErrorEventHandler(IgnoreDataError);
	Controls.Add(dgvExercises);
}

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
