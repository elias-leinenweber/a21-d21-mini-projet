using System.Globalization;
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
	_solution = sentence.textePhrase;
	CreateChallenge(_solution, data.listeMots);
}

private void
CreateChallenge(string sentence, string wordList)
{
	Control toAdd;
	string[] words;
	bool[] hide;

	words = sentence.Split(' ');
	hide = new bool[words.Length];
	foreach (string word in wordList.Split('/'))
		hide[int.Parse(word) - 1] = true;
	for (int i = 0; i < words.Length; ++i) {
		if (hide[i])
			toAdd = new TextBox() {
				Name	= "txt" + i,
				Tag	= words[i]
			};
		else
			toAdd = new Label(){ Text = words[i], AutoSize = true };
		flpChallenge.Controls.Add(toAdd);
	}
}

public override bool
IsValid()
{
	TextBox[] userInputs;

	userInputs = flpChallenge.Controls.OfType<TextBox>().ToArray();
	foreach (TextBox input in userInputs)
		if (Normalize(input.Text) != Normalize((string)input.Tag))
			return false;
	return true;
}

private static string
Normalize(string input)
{
	return new string(input
	    .Trim()
	    .ToLowerInvariant()
	    .Normalize(System.Text.NormalizationForm.FormD)
	    .ToCharArray()
	    .Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
	    // TODO Supprimer ponctuation
	    .ToArray()
	);
}
}
}
