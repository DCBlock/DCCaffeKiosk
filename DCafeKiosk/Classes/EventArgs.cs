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
        public PayTypeEventArgs(PAY_TYPE aPayType)
        {
            this.selected_paytype = aPayType;
        }

        public PAY_TYPE selected_paytype { get; set; }
    }
    #endregion
}
