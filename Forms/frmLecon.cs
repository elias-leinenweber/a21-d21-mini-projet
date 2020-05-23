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
private Button			btnRetour;
private ProgressBar		pgbAvancement;
private Exercice		exoMain;
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
	ClientSize = new System.Drawing.Size(800, 450);
	Text = "frmLecon";

	Name		= "frmLecon";
	
	BackColor	= Color.White;
	ForeColor	= Color.FromArgb(60, 60, 60);
	ControlBox	= false;

	tlpMain = new TableLayoutPanel() {
		Name		= "tlpMain",
		ColumnCount	= 1,
		RowCount	= 3,
		Dock		= DockStyle.Fill,
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

	tlpMain.Controls.Add(tlpHeader, 0, 0);
	//tlpMain.Controls.Add(exoMain, 0, 1);
	Controls.Add(tlpMain);

	ResumeLayout(false);
}
#endregion
#region Champs
private static ExercicesTableAdapter eta = new ExercicesTableAdapter();
private ExercicesRow[]		Exercices;
private int CurrentExercise;
#endregion
#region Constructeurs
public
frmLecon(LeconsRow lecon)
{
	ExercicesDataTable dt = new ExercicesDataTable();
	eta.Fill(dt);
	Exercices = (ExercicesRow[])dt
	    .Select("numLecon = '" + lecon.numLecon + "' AND numCours = '" + lecon.numCours + "'");
	InitializeComponent();
	Text = lecon.titreLecon;
	CurrentExercise = 0;
	NextExercise();
}
#endregion
#region Méthodes
private void
NextExercise()
{
	if (CurrentExercise < Exercices.Length)
		CurrentExercise++;
	exoMain = Exercice.GetExercice(Exercices[CurrentExercise]);
}

public void
SyncProgress()
{
	//
}
#endregion Méthodes
}
}
