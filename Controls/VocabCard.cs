using System;
using System.Drawing;
using System.Windows.Forms;

using static TorreDeBabel.baseLangueDataSet;

namespace TorreDeBabel {
class VocabCard  : TableLayoutPanel {
private System.ComponentModel.IContainer components = null;

protected override void
Dispose(bool disposing)
{
	if (disposing && components != null)
		components.Dispose();
	base.Dispose(disposing);
}

private void
InitializeComponent()
{
	SuspendLayout();

	Size		= new Size(200, 300);
	BorderStyle	= BorderStyle.Fixed3D;
	ColumnCount	= 1;
	RowCount	= 3;

	rowImage = new RowStyle(SizeType.Absolute, 200F);
	RowStyles.Add(rowImage);

	pcbImage = new PictureBox() {
		Name		= "pcbImage",
		Size		= new Size(200, 200),
		SizeMode	= PictureBoxSizeMode.Zoom
	};
	Controls.Add(pcbImage, 0, 0);

	rowCaption = new RowStyle(SizeType.AutoSize);
	RowStyles.Add(rowCaption);

	lblCaption = new Label() {
		Name		= "lblCaption",
		AutoSize	= true
	};
	Controls.Add(lblCaption, 0, 1);

	rowRegion = new RowStyle(SizeType.AutoSize);
	RowStyles.Add(rowRegion);

	lblRegion = new Label() {
		Name		= "lblRegion",
		AutoSize	= true
	};
	Controls.Add(lblRegion, 0, 2);

	MouseHover += new EventHandler(ToggleTranslation);
	MouseLeave += new EventHandler(ToggleTranslation);
	foreach (Control control in Controls) {
		control.MouseHover += new EventHandler(ToggleTranslation);
		control.MouseLeave += new EventHandler(ToggleTranslation);
	}

	ResumeLayout(false);
}

private RowStyle	rowImage;
private PictureBox	pcbImage;
private RowStyle	rowCaption;
private Label		lblCaption;
private RowStyle	rowRegion;
private Label		lblRegion;

internal
VocabCard(MotsRow word)
{
	Name = "vcb" + word.numMot;
	InitializeComponent();

	if (!word.IscheminPhotoNull())
		pcbImage.Image = (Bitmap)Properties.Resources.ResourceManager
		    .GetObject(word.cheminPhoto.Remove(word.cheminPhoto.IndexOf('.')));

	lblCaption.Text = word.libMot + " (" + word.origine + ")";
	lblCaption.Tag = word.traducMot;
	//lblRegion.Text = word.origine;
}

private void
ToggleTranslation(object sender, EventArgs e)
{
	string tmp = lblCaption.Text;
	lblCaption.Text = (string)lblCaption.Tag;
	lblCaption.Tag = tmp;
}
}
}
