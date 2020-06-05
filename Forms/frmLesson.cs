using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using TorreDeBabel.baseLangueDataSetTableAdapters;

using static TorreDeBabel.baseLangueDataSet;

namespace TorreDeBabel {
class frmLesson : Form {
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
	SuspendLayout();

	Name		= "frmLesson";
	Font		= Properties.Settings.Default.DisplayFont;
	ClientSize	= new Size(1080, 690);
	BackColor	= Color.White;
	ForeColor	= Color.FromArgb(60, 60, 60);
	ControlBox	= false;
	FormBorderStyle	= FormBorderStyle.None;
	StartPosition	= FormStartPosition.CenterScreen;

	btnReturn = new Button() {
		Name		= "btnReturn",
		Location	= new Point(40, 50),
		Size		= new Size(18, 18),
		Font		= new Font("Webdings", 10),
		Text		= "r",
		ForeColor	= Color.FromArgb(186, 186, 186),
		FlatStyle	= FlatStyle.Flat
	};
	btnReturn.FlatAppearance.BorderSize = 0;
	btnReturn.Click += new EventHandler(Return);

	pgb = new ProgressBar() {
		Name		= "pgb",
		Location	= new Point(btnReturn.Left + btnReturn.Width + 18, btnReturn.Top),
		Height		= 16
	};
	pgb.Width = 1040 - pgb.Left;

	pnlFooter = new Panel() {
		Name		= "pnlFooter",
		Dock		= DockStyle.Bottom,
		Height		= 140,
		BorderStyle	= BorderStyle.FixedSingle
	};

	btnSkip = new Button() {
		Name		= "btnSkip",
		Text		= "PASSER",
		Size		= new Size(150, 50),
		Left		= 40,
		Top		= 45,
	};
	btnSkip.Click += new EventHandler(Skip);
	pnlFooter.Controls.Add(btnSkip);

	btnCheck = new Button() {
		Name		= "btnCheck",
		Text		= "VÉRIFIER",
		Size		= new Size(150, 50),
		Top		= 45,
		Left		= Width - 190,
		//Enabled		= false
	};
	btnCheck.Click += new EventHandler(Check);
	pnlFooter.Controls.Add(btnCheck);

	btnContinue = new Button() {
		Name		= "btnContinue",
		Text		= "CONTINUER",
		Size		= btnCheck.Size,
		Location	= btnCheck.Location,
		ForeColor	= Color.White,
		Visible		= false
	};
	btnContinue.Click += new EventHandler(Continue);
	pnlFooter.Controls.Add(btnContinue);

	lblSolutionHeader = new Label() {
		Name		= "lblSolutionHeader",
		Text		= "Solution correcte :",
		Location	= new Point(96, 16),
		AutoSize	= true,
		Font		= new Font(Font.FontFamily, 24, FontStyle.Bold, GraphicsUnit.Pixel),
		ForeColor	= Color.FromArgb(234, 43, 43),
		Visible		= false
	};
	pnlFooter.Controls.Add(lblSolutionHeader);

	lblSolutionContent = new Label() {
		Name		= "lblSolutionContent",
		Top		= lblSolutionHeader.Top + lblSolutionHeader.Height,
		Left		= lblSolutionHeader.Left,
		AutoSize	= true,
		Font		= new Font(Font.FontFamily, 17, GraphicsUnit.Pixel),
		ForeColor	= Color.FromArgb(234, 43, 43),
		Visible		= false
	};
	pnlFooter.Controls.Add(lblSolutionContent);

	Controls.Add(btnReturn);
	Controls.Add(pgb);
	Controls.Add(pnlFooter);

	ResumeLayout(false);
}

private Button		btnReturn;
private ProgressBar	pgb;
private Exercise	exo;
private Panel		pnlFooter;
private Button		btnSkip;
private Button		btnCheck;
private Button		btnContinue;
private Label		lblSolutionHeader;
private Label		lblSolutionContent;
#endregion
#region Champs
private static ExercicesTableAdapter	eta = new ExercicesTableAdapter();
private static ExercicesDataTable	edt = new ExercicesDataTable();

private static Color	CorrectBack	= Color.FromArgb(184, 242, 139);
private static Color	CorrectFore	= Color.FromArgb(88, 167, 0);
private static Color	ErrorBack	= Color.FromArgb(255, 193, 193);
private static Color	ErrorFore	= Color.FromArgb(234, 43, 43);

private Queue<ExercicesRow>	Exercises;
private uint			Mistakes;
#endregion
#region Constructeurs
public
frmLesson(LeconsRow lesson)
{
	eta.Fill(edt);
	Exercises = new Queue<ExercicesRow>((ExercicesRow[])edt.Select(
	   "numLecon = '" + lesson.numLecon +
	       "' AND numCours = '" + lesson.numCours + "'",
	   "numExo asc"
	));

	if (Exercises.Count == 0) {
		MessageBox.Show("La lecon ne contient aucun exercice !");
		DialogResult = DialogResult.Cancel;
		Close();
	} else {
		InitializeComponent();
		Text = lesson.titreLecon;
		pgb.Step = 100 / Exercises.Count;
		LoadExercise();
	}
	Mistakes = 0;
}
#endregion
#region Méthodes
private void
LoadExercise()
{
	if (Exercises.Count > 0) {
		exo = Exercise.GetExercise(Exercises.Dequeue());
		exo.Location = new Point((Width - exo.Width) / 2, 100);
		Controls.Add(exo);
	} else
		Recap();
		
}

private void
NextExercise()
{
	Controls.Remove(exo);
	LoadExercise();
}

public void
Return(object sender, EventArgs e)
{
	if (MessageBox.Show(
	    "Êtes-vous sûr de vouloir quitter ? " +
	    "Tout le progrès dans cette session sera perdu.", "Confirmation",
	    MessageBoxButtons.OKCancel, MessageBoxIcon.Warning
	) == DialogResult.OK)
		Close();
}

public void
Skip(object sender, EventArgs e)
{
	Fail();
}

public void
ValidateExercise()
{
	
}

public void
Check(object sender, EventArgs e)
{
	if (exo.IsValid()) {
		pgb.PerformStep();
		pnlFooter.BackColor = CorrectBack;
		btnContinue.BackColor = pnlFooter.ForeColor = CorrectFore;
		exo.Freeze();
	} else
		Fail();
	
	btnContinue.Visible = true;
	btnContinue.BringToFront();
}

public void
Continue(object sender, EventArgs e)
{
	btnContinue.Visible = false;
	btnSkip.Visible = true;
	lblSolutionHeader.Visible = false;
	lblSolutionContent.Visible = false;
	pnlFooter.BackColor = Color.Transparent;
	pnlFooter.ForeColor = Color.FromArgb(60, 60, 60);
	NextExercise();
}

private void
UpdateProgress()
{
	
}

private void
Fail()
{
	++Mistakes;
	exo.Freeze();
	Exercises.Enqueue(exo.data);
	pnlFooter.BackColor = ErrorBack;
	btnContinue.BackColor = pnlFooter.ForeColor = ErrorFore;
	btnContinue.Visible = true;
	btnContinue.BringToFront();
	btnSkip.Visible = false;
	lblSolutionHeader.Visible = true;
	if (exo is exoSentence)
		lblSolutionContent.Text = ((exoSentence)exo).Solution;
	lblSolutionContent.Visible = true;
}

private void
Recap()
{
	MessageBox.Show("Récapitulatif : " + Mistakes + " fautes.");
	DialogResult = DialogResult.OK;
	Close();
}

public void
SyncProgress()
{
	//
}
#endregion Méthodes
}
}
