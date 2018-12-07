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
    public partial class FormMenuOptionDialog : Form
    {
        //public event EventHandler<EventArgs> OnColdSelected;
        //public event EventHandler<EventArgs> OnHotSelected;
                
        private string _SelectedMenuInfo;
        [Browsable(false)]
        public string SelectedMenuInfo {
            get { return _SelectedMenuInfo; }
            set { this.label_SelectedMenuInfo.Text = _SelectedMenuInfo = value; Invalidate(); }
        }
                
        private string _SelectedMenuType;
        [Browsable(false)]
        public string SelectedMenuType {
            get{ return _SelectedMenuType; }
        }

        public FormMenuOptionDialog()
        {
            InitializeComponent();
        }

        private void bunifuFlatButton_Hot_Click(object sender, EventArgs e)
        {
            //if(OnHotSelected != null)
            //    OnHotSelected(this, EventArgs.Empty);

            DialogResult = DialogResult.OK;
            this._SelectedMenuType = "HOT";
        }

        private void bunifuFlatButton_Cold_Click(object sender, EventArgs e)
        {       
            //if(OnColdSelected != null)
            //    OnColdSelected(this, EventArgs.Empty);

            DialogResult = DialogResult.OK;
            this._SelectedMenuType = "COLD";
        }
    }
}
