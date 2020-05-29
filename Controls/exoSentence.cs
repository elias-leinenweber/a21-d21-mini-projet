using TorreDeBabel.baseLangueDataSetTableAdapters;
using static TorreDeBabel.baseLangueDataSet;

namespace TorreDeBabel {
abstract class exoSentence : Exercise {
protected static PhrasesTableAdapter	pta	= new PhrasesTableAdapter();
protected static PhrasesDataTable	Phrases	= new PhrasesDataTable();

internal
exoSentence(ExercicesRow data) : base(data)
{
	pta.Fill(Phrases);
}
}
}
