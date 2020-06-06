using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using TorreDeBabel.baseLangueDataSetTableAdapters;

using static TorreDeBabel.baseLangueDataSet;

namespace TorreDeBabel {
abstract class Exercise : TableLayoutPanel {
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
	SuspendLayout();

	Size	= new Size(600, 450);
	Font	= Properties.Settings.Default.DisplayFont;

	ColumnCount	= 1;
	RowCount	= 3;

	ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
	
	rowHeader = new RowStyle(SizeType.AutoSize);
	RowStyles.Add(rowHeader);

	rowSentence = new RowStyle(SizeType.AutoSize);
	RowStyles.Add(rowSentence);

	rowChallenge = new RowStyle(SizeType.AutoSize);
	RowStyles.Add(rowChallenge);

	lblHeader = new Label() {
		Name		= "lblHeader",
		AutoSize	= true,
		Font		= new Font(Font.FontFamily, 32, FontStyle.Bold,
					   GraphicsUnit.Pixel),
		MaximumSize	= new Size(Width, 0)
	};
	Controls.Add(lblHeader, 0, 0);

	lblSentence = new Label() {
		Name		= "lblSentence",
		AutoSize	= true,
	};
	lblSentence.Margin = new Padding(lblSentence.Margin.Left,
	    lblSentence.Margin.Top + 24, lblSentence.Margin.Right,
	    lblSentence.Margin.Bottom + 24);
	Controls.Add(lblSentence, 0, 1);

	flpChallenge = new FlowLayoutPanel() {
		Name	= "flpChallenge",
		Dock	= DockStyle.Fill
	};
	Controls.Add(flpChallenge, 0, 2);

	ResumeLayout(false);
}

protected RowStyle		rowHeader;
protected Label			lblHeader;
protected RowStyle		rowSentence;
protected Label			lblSentence;
protected RowStyle		rowChallenge;
protected FlowLayoutPanel	flpChallenge;
#endregion
#region Propriétés
public readonly ExercicesRow data;
public event UserInputHandler OnUserInput;
#endregion
protected
Exercise(ExercicesRow data)
{
	UseWaitCursor = true;
	this.data = data;
	InitializeComponent();
	lblHeader.Text = data.enonceExo;
	UseWaitCursor = false;
}

public static Exercise
GetExercise(ExercicesRow data)
{
	Exercise res;

	if ((data.IscodePhraseNull() || data.codePhrase == 0) &&
	    (data.IscodeVerbeNull() || data.codeVerbe == 0))
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

public delegate void UserInputHandler(object sender, UserInputEventArgs e);

protected void
UpdateStatus()
{
	if (OnUserInput == null)
		return;
	OnUserInput(this, new UserInputEventArgs(GetUserInputStatus()));
}

protected void
CallUpdateStatus(object sender, EventArgs e)
	=> UpdateStatus();

protected abstract bool
GetUserInputStatus();

public void
Freeze()
{
	foreach (Control control in flpChallenge.Controls)
		control.Enabled = false;
}
}

public class UserInputEventArgs : EventArgs {
public bool Status { get; private set; }

public
UserInputEventArgs(bool status)
	=> Status = status;
}
}
