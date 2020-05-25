using System.Linq;
using System.Windows.Forms;

using static TorreDeBabel.baseLangueDataSet;

namespace TorreDeBabel {
class exoMissingWords : exoSentence {
internal
exoMissingWords(ExercicesRow data) : base(data)
{
	PhrasesRow sentence = (PhrasesRow)Phrases.Select("codePhrase = '" + data.codePhrase + "'")[0];
	lblSentence.Text = sentence.traducPhrase;
	CreateChallenge(sentence.textePhrase, data.listeMots);
}

private void
CreateChallenge(string sentence, string wordList)
{
	string[] words;
	bool[] hide;

	words = sentence.Split(' ');
	hide = new bool[words.Length];
	foreach (string word in wordList.Split('/'))
		hide[int.Parse(word) - 1] = true;
	for (int i = 0; i < words.Length; ++i) {
		if (hide[i])
			flp.Controls.Add(new TextBox());
		else
			flp.Controls.Add(new Label(){ Text = words[i], AutoSize = true });
	}
}
}
}
