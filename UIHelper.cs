using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

public static class UIHelper
{
    public static void SetRoundedCorners(Control control, int radius)
    {
        if (control == null) return;

        GraphicsPath path = new GraphicsPath();
        path.AddArc(0, 0, radius * 2, radius * 2, 180, 90); // Cantonada superior esquerra
        path.AddArc(control.Width - radius * 2, 0, radius * 2, radius * 2, 270, 90); // Superior dreta
        path.AddArc(control.Width - radius * 2, control.Height - radius * 2, radius * 2, radius * 2, 0, 90); // Inferior dreta
        path.AddArc(0, control.Height - radius * 2, radius * 2, radius * 2, 90, 90); // Inferior esquerra
        path.CloseFigure();

        control.Region = new Region(path);
    }
}
