using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using static TorreDeBabel.baseLangueDataSet;

namespace TorreDeBabel {
class exoPhraseDesordre : exoSentence {
private FlowLayoutPanel	flpSentence;
private static Random	rnd = new Random();

internal
exoPhraseDesordre(ExercicesRow data) : base(data)
{
	PhrasesRow sentence = (PhrasesRow)Phrases.Select("codePhrase = '" + data.codePhrase + "'")[0];
	lblSentence.Text = sentence.traducPhrase;
	flpSentence = new FlowLayoutPanel() {
		BackColor	= Color.FromArgb(229, 229, 229),
		Width		= flpChallenge.Width,
		//AutoSize	= true
	};
	flpSentence.ControlAdded += new ControlEventHandler(CallUpdateStatus);
	flpSentence.ControlRemoved += new ControlEventHandler(CallUpdateStatus);
	flpChallenge.Controls.Add(flpSentence);
	_solution = sentence.textePhrase;
	CreateChallenge(_solution);
}

private void
CreateChallenge(string sentence)
{
	string[] words;
	Label lblWord;

	words = sentence.Split(' ').OrderBy(word => rnd.Next()).ToArray();
	// TODO bonus : rajouter plein de mots random pour augmenter difficulté
	foreach (string word in words) {
		lblWord = new Label() {
			Name		= "lbl" + word, //toCamelCase
			Text		= word,
			AutoSize	= true,
			Padding		= new Padding(10),
			BorderStyle	= BorderStyle.FixedSingle,
			Cursor		= Cursors.Hand
			// bordercolor e5e5e5
		};
		lblWord.Click += new EventHandler(ToggleWord);
		flpChallenge.Controls.Add(lblWord);
	}
}

public void
ToggleWord(object sender, EventArgs e)
{
	Label word = (Label)sender;

	if (word.Parent == flpChallenge) {
		flpChallenge.Controls.Remove(word);
		flpSentence.Controls.Add(word);
	} else {
		flpSentence.Controls.Remove(word);
		flpChallenge.Controls.Add(word);
	}
}

protected override bool
GetUserInputStatus()
{
	return flpSentence.Controls.Count > 0;
}

public override bool
IsValid()
{
	return string.Join(" ",
	    flpSentence.Controls.OfType<Label>()	// pour tous les Label
	    .Select(lbl => lbl.Text)			// 
	    .ToArray()) == _solution;
}
}
}
