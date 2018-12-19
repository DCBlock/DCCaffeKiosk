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
        // FormPayType -> FormRFReader -> FormMenuBoard -> FormOrderResult -> FormPayType
        // FormPayType -> FormRFReader -> FormMenuBoard -> FormOrderResult -> FormPayType
        // FormPayType -> FormRFReader -> FormKeyPad -> FormCancleResult -> FormPayType
        // FormPayType -> FormRFReader -> FormInqueryResult -> FormPayType

        FormPayType,
        FormRFRead,
        FormMenuBoard,
        FormOrderResult,
        FormKeyPad,
        FormCancleResult,
        FormInqueryResult,
    }
}
