using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetmarbleGoldAttendance
{
    public partial class UCCircleLoading : UserControl
    {
        List<Color> colors = new List<Color>();
        int cur_color = 0;
        public UCCircleLoading()
        {
            InitializeComponent();
            colors.Add(Color.FromArgb(0, 150, 136));
            colors.Add(Color.FromArgb(0, 188, 212));
            colors.Add(Color.FromArgb(63, 81, 181));
            colors.Add(Color.FromArgb(156, 39, 176));

            this.bunifuCircleProgressbar1.ProgressColor = colors[cur_color];
        }

        public void lineProgressThickness(int value)
        {
            this.bunifuCircleProgressbar1.LineProgressThickness = value;
        }

        int dir = 5;
        private void stretch_Tick(object sender, EventArgs e)
        {
            if(this.bunifuCircleProgressbar1.Value == 90)
            {
                dir = -1;
                this.bunifuCircleProgressbar1.animationIterval = 4;
                switchColor();
            }
            else if(this.bunifuCircleProgressbar1.Value == 10)
            {
                dir = +1;
                this.bunifuCircleProgressbar1.animationIterval = 2;
            }

            this.bunifuCircleProgressbar1.Value += dir;
        }
                
        void switchColor()
        {
            this.bunifuColorTransition1.Color1 = colors[cur_color];

            if(cur_color < colors.Count -1)
            {
                cur_color++;
            }
            else
            {
                cur_color = 0;
            }

            this.bunifuColorTransition1.Color1 = colors[cur_color];
            this.bunifuColorTransition1.ProgessValue = 0;
            color_transition.Start();
        }

        private void color_transition_Tick(object sender, EventArgs e)
        {
            if(this.bunifuColorTransition1.ProgessValue<100)
            {
                this.bunifuColorTransition1.ProgessValue++;
                this.bunifuCircleProgressbar1.ProgressColor = this.bunifuColorTransition1.Value;
            }
            else
            {
                this.color_transition.Stop();
            }
        }
    }
}
