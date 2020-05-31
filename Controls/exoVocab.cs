using System.Linq;
using System.Windows.Forms;

using TorreDeBabel.baseLangueDataSetTableAdapters;

using static TorreDeBabel.baseLangueDataSet;

namespace TorreDeBabel {
class exoVocab : Exercise {
protected static ConcerneMotsTableAdapter cmta = new ConcerneMotsTableAdapter();
protected static ConcerneMotsDataTable    cmdt = new ConcerneMotsDataTable();

internal
exoVocab(ExercicesRow data) : base(data)
{
	MotsTableAdapter mta = new MotsTableAdapter();
	MotsDataTable mdt = new MotsDataTable();
	mta.Fill(mdt);
	cmta.Fill(cmdt);
	MotsRow[] words = cmdt.Select(
	    "numCours = '" + data.numCours + "' AND numLecon = '" + data.numLecon + "' AND numExo = '" + data.numExo + "'"
	).Select(cm => mdt[((ConcerneMotsRow)cm).numMot]).ToArray();
	foreach (MotsRow word in words)
		flpChallenge.Controls.Add(new VocabCard(word));
}

public override bool
IsValid()
{
	return true;
}
}
}
