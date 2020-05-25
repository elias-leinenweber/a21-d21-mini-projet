﻿using System;
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
private Button		btnCheck, btnContinue, btnReturn, btnSkip;
private Exercise	exo;
private Panel		pnlFooter;
private ProgressBar	pgb;

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
	components = new System.ComponentModel.Container();
	SuspendLayout();

	AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
	ClientSize = new System.Drawing.Size(1080, 450);
	Text = "frmLecon";

	Name		= "frmLecon";
	Font		= Properties.Settings.Default.DisplayFont;
	Size		= new Size(1080, 720);
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
		Visible		= false
	};
	btnContinue.Click += new EventHandler(Continue);
	pnlFooter.Controls.Add(btnContinue);

	Controls.Add(btnReturn);
	Controls.Add(pgb);
	Controls.Add(pnlFooter);

	ResumeLayout(false);
}
#endregion
#region Champs
private static ExercicesTableAdapter eta = new ExercicesTableAdapter();
private Queue<ExercicesRow>	Exercises;
private int			CurrentExercise;
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
	CurrentExercise = 0;
	pgb.Step = 100 / Exercises.Count;
	NextExercise();
	exo.Location = new Point((Width - exo.Width) / 2, 100);
	Controls.Add(exo);
}
#endregion
#region Méthodes
private void
NextExercise()
{
	if (Exercises.Count > 0)
		exo = Exercise.GetExercice(Exercises.Dequeue());
	pgb.PerformStep();
}

public void
Return(object sender, EventArgs e)
{
	Close();
}

public void
Skip(object sender, EventArgs e)
{
	
}

public void
Check(object sender, EventArgs e)
{
	pnlFooter.BackColor = exo.IsValid() ? Color.Honeydew : Color.LightPink;
	btnContinue.Visible = true;
	btnContinue.BringToFront();
}

public void
Continue(object sender, EventArgs e)
{
	btnContinue.Visible = false;
	NextExercise();
}

public void
SyncProgress()
{
	//
}
#endregion Méthodes
}
}
