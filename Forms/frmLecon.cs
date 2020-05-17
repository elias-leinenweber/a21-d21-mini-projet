using System.Data;
using System.Drawing;
using System.Windows.Forms;

using static TorreDeBabel.baseLangueDataSet;

namespace TorreDeBabel {
public partial class frmLecon : Form {
#region Propriétés
DataTableReader		Exercices;
TableLayoutPanel	tlpMain;
TableLayoutPanel	tlpHeader;
Button			btnRetour;
ProgressBar		pgbAvancement;
Exercice		exoMain;
Button			btnSkip, btnCheck;
#endregion
#region Constructeurs
public
frmLecon(LeconsRow lecon)
{
	ExercicesDataTable dt = new ExercicesDataTable();
	Exercices = dt.CreateDataReader();

	SuspendLayout();

	Name		= "frmLecon";
	Text		= lecon.titreLecon;
	BackColor	= Color.White;
	ForeColor	= Color.FromArgb(60, 60, 60);

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
	tlpMain.Controls.Add(exoMain, 0, 1);
	Controls.Add(tlpMain);

	ResumeLayout(false);
}
#endregion
#region Méthodes
private void
NextExercise()
{
	Exercices.Read();
	//exoMain = Exercice.GetExercice(Exercices.GetValues)
}
#endregion Méthodes
}
}
