using System.Linq;
using System.Windows.Forms;

using TorreDeBabel.baseLangueDataSetTableAdapters;

using static TorreDeBabel.baseLangueDataSet;

namespace TorreDeBabel {
class exoSentence : Exercise {
protected FlowLayoutPanel flp;

protected static PhrasesTableAdapter pta = new PhrasesTableAdapter();
protected static PhrasesDataTable Phrases = new PhrasesDataTable();

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
