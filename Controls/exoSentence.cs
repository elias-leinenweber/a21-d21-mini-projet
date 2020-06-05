using System;

using TorreDeBabel.baseLangueDataSetTableAdapters;
using static TorreDeBabel.baseLangueDataSet;

namespace TorreDeBabel {
abstract class exoSentence : Exercise {
protected static PhrasesTableAdapter	pta	= new PhrasesTableAdapter();
protected static PhrasesDataTable	Phrases	= new PhrasesDataTable();

protected string _solution;
public string Solution { get => _solution; }

internal
exoSentence(ExercicesRow data) : base(data)
{
	pta.Fill(Phrases);
}
}
}
