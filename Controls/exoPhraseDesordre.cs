using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using static TorreDeBabel.baseLangueDataSet;

namespace TorreDeBabel {
class exoPhraseDesordre : exoSentence {
private FlowLayoutPanel	flpSentence;
private static Random	rnd = new Random();
private string		Answer;
internal
exoPhraseDesordre(ExercicesRow data) : base(data)
{
	PhrasesRow sentence = (PhrasesRow)Phrases.Select("codePhrase = '" + data.codePhrase + "'")[0];
	lblSentence.Text = sentence.traducPhrase;
	flpSentence = new FlowLayoutPanel() {
		BackColor	= Color.FromArgb(229, 229, 229),
		Width		= flp.Width,
		//AutoSize	= true
	};
	flp.Controls.Add(flpSentence);
	CreateChallenge(sentence.textePhrase);
}

private void
CreateChallenge(string sentence)
{
	string[] words;
	Label lblWord;

	words = sentence.Split(' ').OrderBy(word => rnd.Next()).ToArray();
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
		flp.Controls.Add(lblWord);
	}
	Answer = sentence;
}

public void
ToggleWord(object sender, EventArgs e)
{
	Label word = (Label)sender;

	if (word.Parent == flp) {
		flp.Controls.Remove(word);
		flpSentence.Controls.Add(word);
	} else {
		flpSentence.Controls.Remove(word);
		flp.Controls.Add(word);
	}
}

public override bool
IsValid()
{
	return string.Join(" ",
	    flpSentence.Controls.OfType<Label>()	// pour tous les Label
	    .Select(lbl => lbl.Text)			// 
	    .ToArray()) == Answer;
}
}
}
