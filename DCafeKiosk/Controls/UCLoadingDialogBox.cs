using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DCafeKiosk
{
    public partial class UCLoadingDialogBox : UserControl
    {
        private Action Worker { get; set; }
        
        public UCLoadingDialogBox()
        {
            InitializeComponent();
        }

        public void run(Action worker)
        {
            if (worker == null)
                throw new ArgumentNullException();
            Worker = worker;

            Task.Factory.StartNew(Worker).ContinueWith(
                t => { this.Hide(); }, 
                TaskScheduler.FromCurrentSynchronizationContext()
                );
        }
    }
}
