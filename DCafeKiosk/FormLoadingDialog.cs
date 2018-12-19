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
    public partial class FormLoadingDialog : Form
    {
        private Action Worker { get; set; }
        private Action Callback { get; set; }
        
        public FormLoadingDialog(Action worker/*, Action callback*/)
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            if (worker == null)
                throw new ArgumentNullException();
            Worker = worker;

            //if (callback == null)
            //    throw new ArgumentNullException();
            //Callback = callback;
        }

        protected override void OnLoad(System.EventArgs e)
        {
            base.OnLoad(e);

            Task.Factory.StartNew(Worker).ContinueWith(
                t => {
                    //this.Callback(); // StartEventCapture :: 다시 RF Reader 시작
                    this.Close();
                },
                TaskScheduler.FromCurrentSynchronizationContext()
                );
        }
    }
}
