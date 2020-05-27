using System.Drawing;
using System.Windows.Forms;

using TorreDeBabel.baseLangueDataSetTableAdapters;

using static TorreDeBabel.baseLangueDataSet;

namespace TorreDeBabel {
abstract class Exercise : TableLayoutPanel {
#region Designer
private System.ComponentModel.IContainer components = null;
protected RowStyle	rowHeader;
protected Label		lblHeader;
protected RowStyle	rowSentence;
protected Label		lblSentence;
protected RowStyle	rowChallenge;

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

	Height = 450;
	Width = 600;
	Font = Properties.Settings.Default.DisplayFont;

	ColumnCount	= 1;
	RowCount	= 3;

	ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
	
	rowHeader = new RowStyle(SizeType.Absolute, 40F);
	RowStyles.Add(rowHeader);

	rowSentence = new RowStyle(SizeType.Absolute, 60F);
	RowStyles.Add(rowSentence);

	//rowChallenge = new RowStyle(SizeType.AutoSize);
	rowChallenge = new RowStyle(SizeType.Absolute, 300F);
	RowStyles.Add(rowChallenge);

	lblHeader = new Label() {
		Name	= "lblEnonce",
		Font	= new Font(Font.FontFamily, 32, FontStyle.Bold, GraphicsUnit.Pixel), 
		AutoSize	= true
	};
	Controls.Add(lblHeader, 0, 0);

	lblSentence = new Label() {
		Name	= "lblPhrase",
		AutoSize	= true
	};
	lblSentence.Height += 24;
	Controls.Add(lblSentence, 0, 1);

	ResumeLayout(false);
}
#endregion
#region Propriétés
public readonly ExercicesRow data;
#endregion
protected
Exercise(ExercicesRow data)
{
	InitializeComponent();
	this.data = data;
	lblHeader.Text = data.enonceExo;
}

public static Exercise
GetExercice(ExercicesRow data)
{
	Exercise res;

	if (data.codePhrase == 0)
	// TODO
	// Les exos de vocabulaire, sont des exos pour lesquels il n'y a pas de
	// phrase, ni de n° de verbe et par contre des lignes resultant d'une jointure
	// avec la table ConcerneMots.
		res = new exoVocab(data);
	else if (data.completeON)
		res = new exoPhraseDesordre(data);
	else
		res = new exoMissingWords(data);
	return res;
}

public abstract bool
IsValid();
}
}
