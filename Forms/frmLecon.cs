using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using TorreDeBabel.baseLangueDataSetTableAdapters;

using static TorreDeBabel.baseLangueDataSet;

namespace TorreDeBabel {
class frmLecon : Form {
#region Designer
private System.ComponentModel.IContainer components = null;
private TableLayoutPanel	tlpMain;
private TableLayoutPanel	tlpHeader;
private Button			btnReturn;
private ProgressBar		pgb;
private Exercise		exoMain;
private Panel			pnlFooter;
private Button			btnSkip, btnCheck;

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

	tlpMain = new TableLayoutPanel() {
		Name		= "tlpMain",
		ColumnCount	= 1,
		RowCount	= 3,
		Width		= 1080,
		Anchor		= AnchorStyles.Top | AnchorStyles.Bottom,
		GrowStyle	= TableLayoutPanelGrowStyle.FixedSize,
		CellBorderStyle	= TableLayoutPanelCellBorderStyle.Inset	// debug only
	};
	tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
	// Le "header" : btnRetour et Progressbar
	tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
	// Le "main" : l'exercice proprement dit
	tlpMain.RowStyles.Add(new RowStyle(SizeType.AutoSize));
	// Le "footer" : le bouton suivant, etc
	tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 140F));

	tlpHeader = new TableLayoutPanel() {
		Name		= "tlpHeader",
		ColumnCount	= 2,
		RowCount	= 1,
		GrowStyle	= TableLayoutPanelGrowStyle.FixedSize
	};
	tlpHeader.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
	tlpHeader.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 18F));

	btnReturn = new Button() {
		Name		= "btnReturn",
		Location	= new Point(40, 50),
		Size		= new Size(18, 18),
		Text		= "X",
		FlatStyle	= FlatStyle.Flat
	};
	btnReturn.Click += new EventHandler(Return);

	pgb = new ProgressBar() {
		Name		= "pgb",
		Location	= new Point(btnReturn.Left + btnReturn.Width + 18, btnReturn.Top),
		Height		= 16
	};
	pgb.Width = 1080 - pgb.Left - 40;

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
		Enabled		= false
	};
	pnlFooter.Controls.Add(btnCheck);

	tlpMain.Controls.Add(tlpHeader, 0, 0);
	//tlpMain.Controls.Add(exoMain, 0, 1);
	//Controls.Add(tlpMain);
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
frmLecon(LeconsRow lecon)
{
	ExercicesDataTable dt = new ExercicesDataTable();
	eta.Fill(dt);
	Exercises = new Queue<ExercicesRow>();
	// => LINQ
	foreach (ExercicesRow exo in dt.Select("numLecon = '" + lecon.numLecon + "' AND numCours = '" + lecon.numCours + "'", "numExo asc"))
		Exercises.Enqueue(exo);
	InitializeComponent();
	Text = lecon.titreLecon;
	CurrentExercise = 0;
	pgb.Step = 100 / Exercises.Count;
	NextExercise();
}
#endregion
#region Méthodes
private void
NextExercise()
{
	if (Exercises.Count > 0)
		exoMain = Exercise.GetExercice(Exercises.Dequeue());
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
SyncProgress()
{
	//
}
#endregion Méthodes
}
}
