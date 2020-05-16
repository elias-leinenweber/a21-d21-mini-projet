using System.Drawing;
using System.Windows.Forms;

namespace TorreDeBabel {
public partial class frmDemarrage : Form {
#region Propriétés
Button btnInscrire, btnLogin;
#endregion
#region Constructeurs
public
frmDemarrage()
{
	InitializeComponent();

	Name = "frmDemarrage";
	Text = Application.ProductName;
	BackColor = Color.LightYellow;
	Font = Properties.Settings.Default.DisplayFont;

	btnInscrire = new Button() {
		Name	= "btnInscrire",
		Size	= new Size(320, 48),
		Text	= "S'inscrire",
		Location= new Point(300, 200),
		BackColor	= Color.FromArgb(88, 167, 0),
		ForeColor	= Color.White
	};

	btnLogin = new Button() {
		Name	= "btnLogin",
		Size	= new Size(320, 48),
		Text	= "Connexion",
		Location= new Point(300, 300)
	};

	Controls.Add(btnInscrire);
	Controls.Add(btnLogin);
}
#endregion
#region Méthodes
#endregion
}
}
