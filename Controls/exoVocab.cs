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
	//MotsRow[] words = cmdt.Select("")
	// foreach mot
	// flpChallenge.Controls.Add(new VocabCard());
}

public override bool
IsValid()
{
	return true;
}
}
}
