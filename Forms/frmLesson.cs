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

	Name		= "frmLecon";
	Font		= Properties.Settings.Default.DisplayFont;
	AutoScaleMode	= AutoScaleMode.Font;
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
		Text		= "X",
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
		FlatStyle	= FlatStyle.Popup
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
#endregion
#region Champs
private static ExercicesTableAdapter eta = new ExercicesTableAdapter();
private Queue<ExercicesRow>	Exercises;
private int			ValidExos;
#endregion
#region Constructeurs
public
frmLesson(LeconsRow lesson)
{
	ExercicesDataTable dt;
	
	dt = new ExercicesDataTable();
	eta.Fill(dt);
	Exercises = new Queue<ExercicesRow>();
	// => LINQ
	foreach (ExercicesRow exo in dt.Select("numLecon = '" + lesson.numLecon +
	    "' AND numCours = '" + lesson.numCours + "'", "numExo asc"))
		Exercises.Enqueue(exo);

	InitializeComponent();

	Text = lesson.titreLecon;
	ValidExos = 0;
	pgb.Step = 100 / Exercises.Count;
	UpdateProgress();
	NextExercise();
	exo.Location = new Point((Width - exo.Width) / 2, 100);
	Controls.Add(exo);
}
#endregion
#region Méthodes
private void
NextExercise()
{
	Controls.Remove(exo);
	if (Exercises.Count > 0)
		exo = Exercise.GetExercice(Exercises.Dequeue());
	else {
		MessageBox.Show("Récapitulatif");
		Close();
	}
	exo.Location = new Point((Width - exo.Width) / 2, 100);
	Controls.Add(exo);
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
Check(object sender, EventArgs e)
{
	if (exo.IsValid()) {
		pgb.PerformStep();
		pnlFooter.BackColor = Color.FromArgb(184, 242, 139);
		btnContinue.BackColor = pnlFooter.ForeColor = Color.FromArgb(88, 167, 0);
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
	exo.Freeze();
	Exercises.Enqueue(exo.data);
	pnlFooter.BackColor = Color.FromArgb(255, 193, 193);
	btnContinue.BackColor = pnlFooter.ForeColor = Color.FromArgb(234, 43, 43);
	btnContinue.Visible = true;
	btnContinue.BringToFront();
}

public void
SyncProgress()
{
	//
}
#endregion Méthodes
}
}
