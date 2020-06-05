using System;
using System.Linq;
using System.Windows.Forms;

using TorreDeBabel.baseLangueDataSetTableAdapters;

using static TorreDeBabel.baseLangueDataSet;

namespace TorreDeBabel {
class exoVocab : Exercise {
private static ConcerneMotsTableAdapter adpRelatedWords = new ConcerneMotsTableAdapter();
private static ConcerneMotsDataTable    tblRelatedWords = new ConcerneMotsDataTable();
private static MotsTableAdapter		adpWords	= new MotsTableAdapter();
private static MotsDataTable		tblWords	= new MotsDataTable();

static
exoVocab()
{
	adpRelatedWords.Fill(tblRelatedWords);
	adpWords.Fill(tblWords);
}

internal
exoVocab(ExercicesRow data) : base(data)
{
	VocabCard card;

	MotsRow[] words = tblRelatedWords.Select(
	    "numCours = '" + data.numCours + "' AND numLecon = '" + data.numLecon + "' AND numExo = '" + data.numExo + "'"
	).Select(cm => tblWords[((ConcerneMotsRow)cm).numMot]).ToArray();
	foreach (MotsRow word in words) {
		card = new VocabCard(word);
		card.CellPaint += new TableLayoutCellPaintEventHandler(CallUpdateStatus);
		flpChallenge.Controls.Add(card);
	}

	Width			= (words.Length > 0) ? words.Length * (flpChallenge.Controls[0].Width + 20) : 0;
	rowSentence.Height	= 0;
}

protected override bool
GetUserInputStatus()
{
	return true;
}

public override bool
IsValid()
{
	return true;
}
}
}
