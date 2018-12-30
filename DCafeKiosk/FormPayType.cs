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
    public partial class FormPayType : Form, IPage
    {
        public event EventHandler<PayTypeEventArgs> OnSelectedPayType;

        //-------------------------------------------------------------

        public event EventHandler<EventArgs> PageSuccess;
        public event EventHandler<EventArgs> PageCancel;

        public void OnPageSuccess()
        {
            throw new NotImplementedException();
        }

        public void OnPageCancle()
        {
            throw new NotImplementedException();
        }

        public void ResetForm()
        {
        }

        //-------------------------------------------------------------

        public PAY_TYPE XPayType { get; set; }

        public FormPayType()
        {
            InitializeComponent();
        }

        private void ucPayTypeButton_MonthlyDeduction_Click(object sender, EventArgs e)
        {
            if (OnSelectedPayType == null)
                return;

            OnSelectedPayType(this, new PayTypeEventArgs(PAY_TYPE.MonthlyDeduction));

            XPayType = PAY_TYPE.MonthlyDeduction;
        }

        private void ucPayTypeButton_DigicapTokenPayment_Click(object sender, EventArgs e)
        {
            if (OnSelectedPayType == null)
                return;

            OnSelectedPayType(this, new PayTypeEventArgs(PAY_TYPE.DigicapTokenPayment));

            XPayType = PAY_TYPE.DigicapTokenPayment;
        }

        private void ucPayTypeButton_CustomerPayment_Click(object sender, EventArgs e)
        {
            if (OnSelectedPayType == null)
                return;

            OnSelectedPayType(this, new PayTypeEventArgs(PAY_TYPE.CustomerPayment));
        }

        private void ucPayTypeButton_OderCancellation_Click(object sender, EventArgs e)
        {
            if (OnSelectedPayType == null)
                return;

            OnSelectedPayType(this, new PayTypeEventArgs(PAY_TYPE.OderCancellation));

            XPayType = PAY_TYPE.OderCancellation;
        }

        private void ucPayTypeButton_UserUsageHistoryInquiry_Click(object sender, EventArgs e)
        {
            if (OnSelectedPayType == null)
                return;

            OnSelectedPayType(this, new PayTypeEventArgs(PAY_TYPE.UserUsageHistoryInquiry));

            XPayType = PAY_TYPE.UserUsageHistoryInquiry;
        }
    }
}
