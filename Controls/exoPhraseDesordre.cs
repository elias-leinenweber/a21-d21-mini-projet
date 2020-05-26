using System;
using System.Windows.Forms;

using static TorreDeBabel.baseLangueDataSet;

namespace TorreDeBabel {
class exoPhraseDesordre : exoSentence {
internal
exoPhraseDesordre(ExercicesRow data) : base(data)
{
	PhrasesRow sentence = (PhrasesRow)Phrases.Select("codePhrase = '" + data.codePhrase + "'")[0];
	lblSentence.Text = sentence.traducPhrase;
}

private void
CreateChallenge(string sentence)
{
	throw new NotImplementedException();
}

public override bool
IsValid()
{
	throw new NotImplementedException();
}
}
}
