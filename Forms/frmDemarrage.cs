using System.Drawing;
using System.Windows.Forms;

namespace TorreDeBabel {
public partial class frmDemarrage : Form {
#region Propriétés
TableLayoutPanel	tlpMain;
Button			btnInscrire;
Button			btnLogin;
#endregion
#region Constructeurs
public
frmDemarrage()
{
	InitializeComponent();

	Name = "frmDemarrage";
	Text = Application.ProductName;
	BackgroundImage = Properties.Resources.TowerOfBabel;
	BackgroundImageLayout = ImageLayout.Stretch;
	Font = Properties.Settings.Default.DisplayFont;

	tlpMain = new TableLayoutPanel() {
		Name		= "tlpMain",
		ColumnCount	= 1,
		RowCount	= 2,
		Anchor		= (AnchorStyles.Top | AnchorStyles.Bottom),
		Height		= 110,
		Width		= 501,
		GrowStyle	= TableLayoutPanelGrowStyle.FixedSize,
		CellBorderStyle	= TableLayoutPanelCellBorderStyle.Inset	// debug only
	};
	tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
	tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 48F));
	tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 62F));

	btnInscrire = new Button() {
		Name	= "btnInscrire",
		Size	= new Size(320, 48),
		Text	= "S'inscrire",
		BackColor	= Color.FromArgb(88, 167, 0),
		ForeColor	= Color.White
	};

	btnLogin = new Button() {
		Name	= "btnLogin",
		Size	= new Size(320, 48),
		Text	= "Connexion"
	};

	tlpMain.Controls.Add(btnInscrire, 0, 0);
	tlpMain.Controls.Add(btnLogin, 0, 1);
	Controls.Add(tlpMain);
}
#endregion
#region Méthodes
#endregion
}
}
