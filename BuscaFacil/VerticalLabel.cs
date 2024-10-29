

using System;
using System.Drawing;
using System.Windows.Forms;

public class VerticalLabel : Control
{
    public string TextContent { get; set; }

    protected override void OnPaint(PaintEventArgs e)
    {
        // Rotaciona o texto
        e.Graphics.TranslateTransform(0, Height);
        e.Graphics.RotateTransform(-90);
        e.Graphics.DrawString(TextContent, Font, new SolidBrush(ForeColor), new Point(0, 0));
    }

    protected override Size DefaultSize => new Size(20, 100); // Tamanho padrão
}