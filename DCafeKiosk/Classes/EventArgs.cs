using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCafeKiosk
{
    #region 'FormPayType'
    /// <summary>
    /// 선택한 결제 타입 이벤트
    /// </summary>
    public class PayTypeEventArgs : EventArgs
    {
        public PayTypeEventArgs(PAYTYPE aPayType)
        {
            this.selected_paytype = aPayType;
        }

        public PAYTYPE selected_paytype { get; set; }
    }
    #endregion
}
