using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using TorreDeBabel.baseLangueDataSetTableAdapters;
using TorreDeBabel.Properties;

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
	Font		= Settings.Default.DisplayFont;
	ClientSize	= new Size(1080, 690);
	BackColor	= Color.White;
	ForeColor	= Color.FromArgb(60, 60, 60);
	ControlBox	= false;
	FormBorderStyle	= FormBorderStyle.None;
	Icon		= Resources.babel;
	StartPosition	= FormStartPosition.CenterScreen;

	btnReturn = new PictureBox() {
		Name		= "btnReturn",
		Location	= new Point(40, 50),
		Size		= new Size(18, 18),
		Image		= Resources.x,
		Cursor		= Cursors.Hand
	};
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
		Font		= new Font(Font.FontFamily, 17, FontStyle.Bold, GraphicsUnit.Pixel),
		BackColor	= Color.White
	};
	btnSkip.Click += new EventHandler(Skip);
	pnlFooter.Controls.Add(btnSkip);

	btnCheck = new Button() {
		Name		= "btnCheck",
		Text		= "VÉRIFIER",
		Size		= new Size(150, 50),
		Top		= 45,
		Left		= Width - 190,
		Font		= new Font(Font.FontFamily, 17, FontStyle.Bold, GraphicsUnit.Pixel),
		BackColor	= Color.Transparent,
		Enabled		= false
	};
	btnCheck.Click += new EventHandler(Check);
	pnlFooter.Controls.Add(btnCheck);

	btnContinue = new Button() {
		Name		= "btnContinue",
		Text		= "CONTINUER",
		Size		= btnCheck.Size,
		Location	= btnCheck.Location,
		ForeColor	= Color.White,
		Font		= new Font(Font.FontFamily, 17, FontStyle.Bold, GraphicsUnit.Pixel),
		Visible		= false
	};
	btnContinue.Click += new EventHandler(Continue);
	pnlFooter.Controls.Add(btnContinue);

	pcbStatusIcon = new PictureBox() {
		Name		= "pcbStatusIcon",
		Location	= new Point(40, 16),
		Size		= new Size(80, 80),
		Visible		= false
	};
	pnlFooter.Controls.Add(pcbStatusIcon);

	lblSolutionHeader = new Label() {
		Name		= "lblSolutionHeader",
		Text		= "Solution :",
		Location	= new Point(136, 16),
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
		MaximumSize	= new Size(640, 0),
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

private PictureBox	btnReturn;
private ProgressBar	pgb;
private Exercise	exo;
private Panel		pnlFooter;
private Button		btnSkip;
private Button		btnCheck;
private Button		btnContinue;
private PictureBox	pcbStatusIcon;
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
private Dictionary<int, string>	Mistakes;
#endregion
#region Constructeurs
public
frmLesson(LeconsRow lesson)
{
	UseWaitCursor = true;
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
	Mistakes = new Dictionary<int, string>();
	UseWaitCursor = false;
}
#endregion
#region Méthodes
private void
LoadExercise()
{
	if (Exercises.Count > 0) {
		exo = Exercise.GetExercise(Exercises.Dequeue());
		if (exo == null) {
			NextExercise();
			return;
		}// exo conjugaison; non implémenté
		exo.Location = new Point((Width - exo.Width) / 2, 100);
		exo.OnUserInput += new Exercise.UserInputHandler(UserInput);
		if (exo is exoVocab) {
			btnSkip.Enabled = false;
			btnSkip.BackColor = Color.Transparent;
		} else {
			btnSkip.Enabled = true;
			btnSkip.BackColor = Color.White;
		}
		Controls.Add(exo);
	} else
		Recap();
}

private void
UserInput(object sender, UserInputEventArgs e)
{
	if (e.Status) {
		btnCheck.BackColor	= Color.FromArgb(88, 167, 0);
		btnCheck.ForeColor	= Color.White;
		btnCheck.Enabled	= true;
	} else
		ResetBtnCheck();
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
	ValidateExercise();
	Fail();
}

public void
ValidateExercise()
{
	exo.Freeze();
	btnSkip.Visible = false;
	btnContinue.Visible = true;
	pcbStatusIcon.Visible = true;
	lblSolutionHeader.Visible = true;
	btnContinue.BringToFront();
}

public void
Check(object sender, EventArgs e)
{
	ValidateExercise();
	if (exo.IsValid())
		Success();
	else
		Fail();
}

public void
Continue(object sender, EventArgs e)
{
	pnlFooter.BackColor = Color.Transparent;
	pnlFooter.ForeColor = Color.FromArgb(60, 60, 60);

	ResetBtnCheck();

	btnSkip.Visible			= true;
	btnContinue.Visible		= false;
	pcbStatusIcon.Visible		= false;
	lblSolutionHeader.Visible	= false;
	lblSolutionContent.Visible	= false;

	NextExercise();
}

private void
ResetBtnCheck()
{
	btnCheck.BackColor	= Color.Transparent;
	btnCheck.ForeColor	= Color.FromArgb(175, 175, 175);
	btnCheck.Enabled	= false;
}

private void
Success()
{
	pgb.PerformStep();

	pnlFooter.BackColor = CorrectBack;
	btnContinue.BackColor = pnlFooter.ForeColor = CorrectFore;
	lblSolutionHeader.Text = "Correct";
	lblSolutionHeader.ForeColor = CorrectFore;
	pcbStatusIcon.Image = Resources.yes;
}

private void
Fail()
{
	if (!Mistakes.ContainsKey(exo.data.numExo))
		Mistakes.Add(exo.data.numExo, exo.data.enonceExo); // TODO user input
	Exercises.Enqueue(exo.data);

	pnlFooter.BackColor = ErrorBack;
	btnContinue.BackColor = pnlFooter.ForeColor = ErrorFore;

	pcbStatusIcon.Image = Resources.no;
	lblSolutionHeader.ForeColor = ErrorFore;
	lblSolutionHeader.Text = "Solution : ";
	if (exo is exoSentence sentence)
		lblSolutionContent.Text = sentence.Solution;
	lblSolutionContent.Visible = true;
}

private void
Recap()
{
	string message = "Récapitulatif : " + Mistakes.Count + " fautes.\n";
	foreach (KeyValuePair<int, string> mistake in Mistakes)
		message += string.Format(" - Exercice {0} : {1}\n", mistake.Key, mistake.Value);
	MessageBox.Show(message);
	DialogResult = DialogResult.OK;
	Close();
}
#endregion Méthodes
}
}
