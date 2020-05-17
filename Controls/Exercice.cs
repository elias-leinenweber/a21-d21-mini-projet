﻿using System.Windows.Forms;

using static TorreDeBabel.baseLangueDataSet;

namespace TorreDeBabel {
abstract partial class Exercice : TableLayoutPanel {
protected RowStyle	rowEnonce;
protected Label		lblEnonce;
RowStyle	rowPhrase;
Label		lblPhrase;
RowStyle	rowExercice;

protected
Exercice()
{
	InitializeComponent();

	ColumnCount	= 1;
	RowCount	= 3;

	ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
	
	rowEnonce = new RowStyle(SizeType.Absolute, 40F);
	RowStyles.Add(rowEnonce);

	rowPhrase = new RowStyle(SizeType.Absolute, 60F);
	RowStyles.Add(rowPhrase);

	rowExercice = new RowStyle(SizeType.AutoSize);
	RowStyles.Add(rowExercice);
}

public static Exercice
GetExercice(ExercicesRow data)
{
	Exercice res;

	if (data.codePhrase == 0)
		res = new exoVocab(data);
	else if (data.listeMots == string.Empty)
		res = new exoPhraseDesordre(data);
	else
		res = new exoPhraseATrous(data);
	return res;
}
}
}