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
    public partial class FormPayType : Form
    {
        public event EventHandler<PayTypeEventArgs> OnSelectedPayType;

        public FormPayType()
        {
            InitializeComponent();
        }

        private void ucPayTypeButton_MonthlyDeduction_Click(object sender, EventArgs e)
        {
            if (OnSelectedPayType == null)
                return;

            OnSelectedPayType(this, new PayTypeEventArgs(PAYTYPE.MonthlyDeduction));
        }

        private void ucPayTypeButton_DigicapTokenPayment_Click(object sender, EventArgs e)
        {
            if (OnSelectedPayType == null)
                return;

            OnSelectedPayType(this, new PayTypeEventArgs(PAYTYPE.DigicapTokenPayment));
        }

        private void ucPayTypeButton_CustomerPayment_Click(object sender, EventArgs e)
        {
            if (OnSelectedPayType == null)
                return;

            OnSelectedPayType(this, new PayTypeEventArgs(PAYTYPE.CustomerPayment));
        }

        private void ucPayTypeButton_OderCancellation_Click(object sender, EventArgs e)
        {
            if (OnSelectedPayType == null)
                return;

            OnSelectedPayType(this, new PayTypeEventArgs(PAYTYPE.OderCancellation));
        }

        private void ucPayTypeButton_UserUsageHistoryInquiry_Click(object sender, EventArgs e)
        {
            if (OnSelectedPayType == null)
                return;

            OnSelectedPayType(this, new PayTypeEventArgs(PAYTYPE.UserUsageHistoryInquiry));
        }
    }
}
