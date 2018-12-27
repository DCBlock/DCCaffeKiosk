using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCafeKiosk
{
    public enum MENU_SIZE
    {
        SMALL,
        REGULAR,
    }

    public enum MENU_TYPE
    {
        HOT,
        ICED,
        BOTH,
    }

    public enum PAY_TYPE
    {
        MonthlyDeduction,           // 월공제
        CustomerPayment,            // 손님결제
        DigicapTokenPayment,        // 디지캡 토큰 결제
        OderCancellation,           // 주문 취소
        UserUsageHistoryInquiry,    // 사용자 이용 내역조회
    }

    public enum  PAGES
    {
        // FormPayType -> FormRFReader -> FormMenuBoard -> FormResultOrder -> 처음으로
        // FormPayType -> FormRFReader -> FormMenuBoard -> FormResultOrder -> 처음으로
        // FormPayType -> FormRFReader -> FormKeyPad -> FormResultCancle -> 처음으로
        // FormPayType -> FormRFReader -> FormResultInquery -> 처음으로

        FormPayType,        //common
        FormRFRead,         //common

        FormMenuBoard,      //for order
        FormResultOrder,    //for order

        FormKeyPad,         //for cancel
        FormResultCancel,   //for cancel

        FormResultInquery,  //for inquery
    }
}
