using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DCafeKiosk
{
    public partial class FormTest : Form
    {
        public FormTest()
        {
            InitializeComponent();
            ucOrderItem1.OnMinusButtonClicked += UcOrderItem1_OnMinusButtonClicked;
            ucOrderItem1.OnPlusButtonClicked += UcOrderItem1_OnPlusButtonClicked;
        }

        private void UcOrderItem1_OnPlusButtonClicked(object sender, EventArgs e)
        {
            
        }

        private void UcOrderItem1_OnMinusButtonClicked(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var form = new FormMenuOptionDialog())
            {
                //form.OnColdSelected += (object i, EventArgs o) =>
                //{
                //    MessageBox.Show("COLD");
                //    form.Close();
                //};

                //form.OnHotSelected += (object i, EventArgs o) =>
                //{
                //    MessageBox.Show("HOT");
                //    form.Close();
                //};

                form.SelectedMenuInfo = "아메리카노 REGULAR ...";

                if(form.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show(form.SelectedMenuType);
                    form.Close();
                }

            }// release
        }
    }
}
