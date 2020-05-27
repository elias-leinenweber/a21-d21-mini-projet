using System.Windows.Forms;

using TorreDeBabel.baseLangueDataSetTableAdapters;

using static TorreDeBabel.baseLangueDataSet;

namespace TorreDeBabel {
abstract class exoSentence : Exercise {
#region Designer
protected FlowLayoutPanel flp;
#endregion

protected static PhrasesTableAdapter	pta	= new PhrasesTableAdapter();
protected static PhrasesDataTable	Phrases	= new PhrasesDataTable();

internal
exoSentence(ExercicesRow data) : base(data)
{
	flp = new FlowLayoutPanel() {
		Name	= "flp",
		Dock	= DockStyle.Fill
	};
	Controls.Add(flp, 0, 2);

	pta.Fill(Phrases);
}
}
}
