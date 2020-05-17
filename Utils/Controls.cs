using System.Windows.Forms;

namespace TorreDeBabel.Utils {
public static class Controls {
public static void
CenterInParent(Control c)
{
	c.Left	= (c.Parent.Width - c.Width) / 2;
	c.Top	= (c.Parent.Height - c.Height) / 2;
}
}
}
