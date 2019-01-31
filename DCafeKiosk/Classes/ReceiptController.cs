using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DCafeKiosk
{
    public enum PRINT_STATUS
    {
        BXL_STS_NORMAL,
        BXL_STS_PAPER_NEAR_END,
        BXL_STS_PAPEREMPTY,
        BXL_STS_CASHDRAWER_HIGH,
        BXL_STS_CASHDRAWER_LOW,
        BXL_STS_COVEROPEN,
        BXL_STS_BATTERY_LOW,
        BXL_STS_PAPER_TO_BE_TAKEN,
        BXL_STS_ERROR, //OFFLINE
    }

    public class VOPrintMenu
    {
        public string name { get; set; }
        public string size { get; set; }
        public string type { get; set; }
        public string amount { get; set; }
    }

    /// <summary>
    /// singleton pattern class
    /// </summary>
    sealed class ReceiptController
    {
        private static volatile ReceiptController instance;
        private static object syncRoot = new Object();

        private ReceiptController(){

        }

        public static ReceiptController Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new ReceiptController();
                    }
                }

                return instance;
            }
        }

        public bool ConnectToUSB()
        {
            ////-------------
            //if (GetStatus() != PRINT_STATUS.BXL_STS_ERROR)
            //    return true;

            //-------------
            if (BXLAPI.PrinterOpen(BXLAPI.IUsb, "", 0, 0, 0, 0) != BXLAPI.BXL_SUCCESS)
            {
                return false;
            }
            return true;
        }

        public PRINT_STATUS GetStatus()
        {
            int lState = (int)BXLAPI.GetPrinterCurrentStatus();

            if (lState == BXLAPI.BXL_STS_NORMAL)
                return PRINT_STATUS.BXL_STS_NORMAL;
            if ((lState & BXLAPI.BXL_STS_PAPER_NEAR_END) == BXLAPI.BXL_STS_PAPER_NEAR_END)
                return PRINT_STATUS.BXL_STS_PAPER_NEAR_END;
            if ((lState & BXLAPI.BXL_STS_PAPEREMPTY) == BXLAPI.BXL_STS_PAPEREMPTY)
                return PRINT_STATUS.BXL_STS_PAPEREMPTY;
            if ((lState & BXLAPI.BXL_STS_CASHDRAWER_HIGH) == BXLAPI.BXL_STS_CASHDRAWER_HIGH)
                return PRINT_STATUS.BXL_STS_CASHDRAWER_HIGH;
            if ((lState & BXLAPI.BXL_STS_CASHDRAWER_LOW) == BXLAPI.BXL_STS_CASHDRAWER_LOW)
                return PRINT_STATUS.BXL_STS_CASHDRAWER_LOW;
            if ((lState & BXLAPI.BXL_STS_COVEROPEN) == BXLAPI.BXL_STS_COVEROPEN)
                return PRINT_STATUS.BXL_STS_COVEROPEN;
            if ((lState & BXLAPI.BXL_STS_BATTERY_LOW) == BXLAPI.BXL_STS_BATTERY_LOW)
                return PRINT_STATUS.BXL_STS_BATTERY_LOW;
            if ((lState & BXLAPI.BXL_STS_PAPER_TO_BE_TAKEN) == BXLAPI.BXL_STS_PAPER_TO_BE_TAKEN)
                return PRINT_STATUS.BXL_STS_PAPER_TO_BE_TAKEN;
            if ((lState & BXLAPI.BXL_STS_ERROR) == BXLAPI.BXL_STS_ERROR)
                return PRINT_STATUS.BXL_STS_ERROR;

            return PRINT_STATUS.BXL_STS_ERROR;
        }

        /// <summary>
        /// 영수증 출력
        /// </summary>
        /// <param name="aUsernameCompany"></param>
        /// <param name="aReceiptId"></param>
        /// <param name="aPaytype"></param>
        /// <param name="printList"></param>
        /*
        DigiCAP Campus Caffe
        ======================================
        구매일자: 2018-12-21 15:01
        결제방식: 월말공제
        주문자명: 정병옥(DigiCAPS)        
        
                        승인번호
                         0001
        --------------------------------------
        품목           용량       종류     개수
        --------------------------------------
        아메리카노      Regular   HOT      2
        아메리카노      Regular   ICED     2
        --------------------------------------
        결제 취소시 반드시 영수증을 지참해 
        주시기 바랍니다. 결제 취소는 1시간 이내에 
        요청해야 합니다.
        */
        public bool Print(string aUsernameCompany, string aReceiptId, string aPaytype, List<VOPrintMenu> printList, string aPurchasedDateString, string aTotalPrice, string aTotalDcPrice, string aPaymentPrice)
        {
            string str;

            // Enters 'Transaction' mode.
            BXLAPI.TransactionStart();

            BXLAPI.InitializePrinter();
            BXLAPI.SetCharacterSet(BXLAPI.BXL_CS_WPC1252);
            BXLAPI.SetInterChrSet(BXLAPI.BXL_ICS_USA);

            // 제목 출력            
            BXLAPI.PrintText("DCaffe\n", BXLAPI.BXL_ALIGNMENT_CENTER, BXLAPI.BXL_FT_BOLD | BXLAPI.BXL_FT_DEFAULT, BXLAPI.BXL_TS_1WIDTH | BXLAPI.BXL_TS_1HEIGHT);
            BXLAPI.PrintText("==========================================\n", BXLAPI.BXL_ALIGNMENT_CENTER, BXLAPI.BXL_FT_DEFAULT, BXLAPI.BXL_TS_0WIDTH | BXLAPI.BXL_TS_0HEIGHT);
            BXLAPI.LineFeed(1);

            // 정보 출력
            BXLAPI.PrintText("구매일자: " + aPurchasedDateString + "\n", BXLAPI.BXL_ALIGNMENT_LEFT, BXLAPI.BXL_FT_DEFAULT, BXLAPI.BXL_TS_0WIDTH | BXLAPI.BXL_TS_0HEIGHT);
            BXLAPI.PrintText("결제방식: " + aPaytype + "\n", BXLAPI.BXL_ALIGNMENT_LEFT, BXLAPI.BXL_FT_DEFAULT, BXLAPI.BXL_TS_0WIDTH | BXLAPI.BXL_TS_0HEIGHT);
            BXLAPI.PrintText("주문자명: " + aUsernameCompany + "\n", BXLAPI.BXL_ALIGNMENT_LEFT, BXLAPI.BXL_FT_DEFAULT, BXLAPI.BXL_TS_0WIDTH | BXLAPI.BXL_TS_0HEIGHT);

            BXLAPI.LineFeed(1);
            BXLAPI.PrintText("승인번호\n", BXLAPI.BXL_ALIGNMENT_CENTER, BXLAPI.BXL_FT_BOLD | BXLAPI.BXL_FT_DEFAULT, BXLAPI.BXL_TS_1WIDTH | BXLAPI.BXL_TS_1HEIGHT);
            BXLAPI.PrintText(aReceiptId + "\n", BXLAPI.BXL_ALIGNMENT_CENTER, BXLAPI.BXL_FT_BOLD | BXLAPI.BXL_FT_DEFAULT, BXLAPI.BXL_TS_1WIDTH | BXLAPI.BXL_TS_1HEIGHT);
            BXLAPI.LineFeed(1);

            // 목록 헤더 출력
            BXLAPI.PrintText("-----------------------------------------\n", BXLAPI.BXL_ALIGNMENT_LEFT, BXLAPI.BXL_FT_DEFAULT, BXLAPI.BXL_TS_0WIDTH | BXLAPI.BXL_TS_0HEIGHT);
            str = string.Format("{0}           {1}     {2}     {3}", "품목", "용량", "종류", "수량");
            BXLAPI.PrintText(str + "\n", BXLAPI.BXL_ALIGNMENT_LEFT, BXLAPI.BXL_FT_DEFAULT, BXLAPI.BXL_TS_0WIDTH | BXLAPI.BXL_TS_0HEIGHT);
            BXLAPI.PrintText("-----------------------------------------\n", BXLAPI.BXL_ALIGNMENT_LEFT, BXLAPI.BXL_FT_DEFAULT, BXLAPI.BXL_TS_0WIDTH | BXLAPI.BXL_TS_0HEIGHT);

            // 목록 출력
            printList.ForEach(
                item => {
                    if (item.name.Length < 8)  // 8글자 이하는 우측에 공백 패딩하여 8글자 맞추기
                        item.name = item.name.PadRight(8, ' ');

                    str = string.Format("{0}\t{1}\t{2}\t{3}", item.name, item.size, item.type, item.amount);
                    BXLAPI.PrintText(str + "\n", BXLAPI.BXL_ALIGNMENT_LEFT, BXLAPI.BXL_FT_DEFAULT, BXLAPI.BXL_TS_0WIDTH | BXLAPI.BXL_TS_0HEIGHT);
                }
                );
            BXLAPI.PrintText("-----------------------------------------\n", BXLAPI.BXL_ALIGNMENT_CENTER, BXLAPI.BXL_FT_DEFAULT, BXLAPI.BXL_TS_0WIDTH | BXLAPI.BXL_TS_0HEIGHT);
            BXLAPI.PrintText(string.Format("구매총액:{0}\n", aTotalPrice), BXLAPI.BXL_ALIGNMENT_LEFT, BXLAPI.BXL_FT_DEFAULT | BXLAPI.BXL_FT_DEFAULT, BXLAPI.BXL_TS_0WIDTH | BXLAPI.BXL_TS_0HEIGHT);
            BXLAPI.PrintText(string.Format("할인총액:{0}\n", aTotalDcPrice), BXLAPI.BXL_ALIGNMENT_LEFT, BXLAPI.BXL_FT_DEFAULT | BXLAPI.BXL_FT_DEFAULT, BXLAPI.BXL_TS_0WIDTH | BXLAPI.BXL_TS_0HEIGHT);
            BXLAPI.PrintText(string.Format("결제총액:{0}\n", aPaymentPrice), BXLAPI.BXL_ALIGNMENT_LEFT, BXLAPI.BXL_FT_DEFAULT | BXLAPI.BXL_FT_DEFAULT, BXLAPI.BXL_TS_0WIDTH | BXLAPI.BXL_TS_0HEIGHT);
            BXLAPI.LineFeed(1);

            //하단 출력
            string strFooter1 = "결제 취소시 반드시 영수증을 카운터에 제출해 주시기 바랍니다.";
            string strFooter2 = "결제 취소는 30분 이내에 요청해야 합니다.";
            BXLAPI.PrintText(strFooter1 + "\n", BXLAPI.BXL_ALIGNMENT_LEFT, BXLAPI.BXL_FT_DEFAULT, BXLAPI.BXL_TS_0WIDTH | BXLAPI.BXL_TS_0HEIGHT);
            BXLAPI.PrintText(strFooter2 + "\n", BXLAPI.BXL_ALIGNMENT_LEFT, BXLAPI.BXL_FT_DEFAULT, BXLAPI.BXL_TS_0WIDTH | BXLAPI.BXL_TS_0HEIGHT);
            //--------------------------------------------------------------------

            BXLAPI.CutPaper();

            // Leaves 'Transaction' mode, and then sends print data in the buffer to start printing.
            if (BXLAPI.TransactionEnd(true, 3000 /* 3 seconds */) != BXLAPI.BXL_SUCCESS)
            {
                // failed to read a response from the printer after sending the print-data.
                MessageBox.Show("TransactionEnd failed.", "Receipt Printer");
                return false;
            }

            return true;
        }

        public int PrinterClose()
        {
            return BXLAPI.PrinterClose();
        }
    }
}
