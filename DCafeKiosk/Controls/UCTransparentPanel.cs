using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

public class TransparentPanel : Panel
{
    private const int WS_EX_TRANSPARENT = 0x20;

    public TransparentPanel()
    {
        SetStyle(ControlStyles.Opaque, true);
    }

    private int opacity = 50;
    [DefaultValue(50)]
    public int Opacity
    {
        get
        {
            return this.opacity;
        }
        set
        {
            if (value < 0 || value > 100)
                throw new ArgumentException("value must be between 0 and 100");
            this.opacity = value;

            Invalidate();
        }
    }

    protected override CreateParams CreateParams
    {
        get
        {
            CreateParams cp = base.CreateParams;
            cp.ExStyle |= 0x00000020; // WS_EX_TRANSPARENT
            return cp;
        }
    }

    protected override void OnPaintBackground(PaintEventArgs e)
    {
        base.OnPaintBackground(e);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        using (var brush = new SolidBrush(Color.FromArgb(this.opacity * 255 / 100, this.BackColor)))
        {
            e.Graphics.FillRectangle(brush, this.ClientRectangle);
        }

        base.OnPaint(e);
    }

    private void InitializeComponent()
    {
            this.SuspendLayout();
            this.ResumeLayout(false);
    }
}