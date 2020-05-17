using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForm_Drawing
{
    public partial class Form1 : Form
    {
        float startAngle = 0.0F;
        float sweepAngle = 0.0F;
        List<Color> colors;
        
        public Form1()
        {
            InitializeComponent();
            this.BackColor = Color.White;

            colors = new List<Color>();
            colors.Add(Color.FromArgb(255, 0, 0, 0));
            
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics gr = e.Graphics;

            Rectangle rect = new Rectangle(100, 100 , 200, 200);
            float grad = sweepAngle / colors.Count;
            for(int i = 0; i <colors.Count; i++) { 
                Pen pen = new Pen(colors[i], 10);
                gr.DrawArc(pen, rect, startAngle + grad*i, grad*i + grad);
            }
        }
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label1.Text = "" + trackBar1.Value + "%";
            sweepAngle = trackBar1.Value * 360 / 100;
            Invalidate();
        }

        private void addColor_Click(object sender, EventArgs e)
        {
            Color c = colors.Last();
            int r = c.R + 20;
            int g = c.R + 20;
            int b = c.R + 20;
            if (r > 255) r = 255;
            if (g > 255) g = 255;
            if (b > 255) b = 255;
            colors.Add(Color.FromArgb(255, r, g, b));
            Invalidate();
        }

        private void remove_Click(object sender, EventArgs e)
        {
            if(colors.Count > 1)colors.Remove(colors.Last());
            Invalidate();
        }
    }
}
