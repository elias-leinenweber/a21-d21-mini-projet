using System.Windows.Forms;

using static TorreDeBabel.baseLangueDataSet;

namespace TorreDeBabel {
abstract class Exercice : TableLayoutPanel {
ExercicesRow	data;
RowStyle	rowEnonce;
Label		lblEnonce;
RowStyle	rowPhrase;
RowStyle	rowExercice;

Exercice()
{
	lblEnonce = new Label() {
		Name = "lblEnonce",
		Text = data.enonceExo
	};
}
}
}
