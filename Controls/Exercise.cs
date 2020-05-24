using System.Drawing;
using System.Windows.Forms;

using TorreDeBabel.baseLangueDataSetTableAdapters;

using static TorreDeBabel.baseLangueDataSet;

namespace TorreDeBabel {
abstract class Exercise : TableLayoutPanel {
#region Designer
private System.ComponentModel.IContainer components = null;
protected RowStyle	rowEnonce;
protected Label		lblEnonce;
protected RowStyle	rowPhrase;
protected Label		lblPhrase;
protected RowStyle	rowExercice;

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
	SuspendLayout();

	Width = 600;

	ColumnCount	= 1;
	RowCount	= 3;

	ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
	
	rowEnonce = new RowStyle(SizeType.Absolute, 40F);
	RowStyles.Add(rowEnonce);

	rowPhrase = new RowStyle(SizeType.Absolute, 60F);
	RowStyles.Add(rowPhrase);

	rowExercice = new RowStyle(SizeType.AutoSize);
	RowStyles.Add(rowExercice);

	lblEnonce = new Label() {
		Name	= "lblEnonce",
		Font	= new Font("Lucida Sans", 18, FontStyle.Bold),
		AutoSize	= true
	};
	Controls.Add(lblEnonce, 0, 0);

	lblPhrase = new Label() {
		Name	= "lblPhrase"
	};
	Controls.Add(lblPhrase, 0, 1);

	ResumeLayout(false);
}
#endregion
#region Champs
protected static PhrasesTableAdapter pta = new PhrasesTableAdapter();
protected static PhrasesDataTable Phrases = new PhrasesDataTable();
#endregion
protected
Exercise(ExercicesRow data)
{
	InitializeComponent();
	pta.Fill(Phrases);
	lblEnonce.Text = data.enonceExo;
	//lblPhrase.Text = ((PhrasesRow)Phrases.Select("codePhrase = '" + data.codePhrase + "'")[0]).textePhrase;
}

public static Exercise
GetExercice(ExercicesRow data)
{
	Exercise res;

	if (data.codePhrase == 0)
		res = new exoVocab(data);
	else if (data.listeMots == string.Empty)
		res = new exoPhraseDesordre(data);
	else
		res = new exoPhraseATrous(data);
	return res;
}
}
}
