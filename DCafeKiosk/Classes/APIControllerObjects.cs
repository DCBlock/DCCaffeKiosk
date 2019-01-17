using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCafeKiosk
{
    //++++++++++++++++++++++++++++++++++++++++++++++++++++++
    // 메뉴 목록 응답
    //++++++++++++++++++++++++++++++++++++++++++++++++++++++
    public class DTOGetMenusResponse
    {
        public Dictionary<string, List<VOCategoryMenuList>> dicCategoryMenus;

        // Error
        public int code { get; set; }
        public string reason { get; set; }
    }

    public class VOCategoryMenuList
    {
        public int category { get; set; }
        public int code { get; set; }
        public string name_en { get; set; }
        public string name_kr { get; set; }
        public int price { get; set; }
        public string type { get; set; }
        public string size { get; set; }
        public string event_name { get; set; }
        
        //k:company_name, value:dcprice
        public Dictionary<string, int> discounts { get; set; }
    }
    


    //++++++++++++++++++++++++++++++++++++++++++++++++++++++
    // 구매 영수증 ID 요청 응답
    //++++++++++++++++++++++++++++++++++++++++++++++++++++++
    public class DTOGetPurchaseIdRequest
    {
        public string rfid { get; set; }
    }

    public class DTOGetPurchaseIdResponse
    {
        public int receipt_id { get; set; }
        public string name { get; set; }
        public string company { get; set; }
        public string date { get; set; }

        // Error Template
        public int code { get; set; }
        public string reason { get; set; }
    }



    //++++++++++++++++++++++++++++++++++++++++++++++++++++++
    // 구매 승인 요청 응답
    //++++++++++++++++++++++++++++++++++++++++++++++++++++++
    public class DTOPurchasesRequest
    {
        public int purchase_type { get; set; }        
        public List<VOMenu> purchases { get; set; }
    }

    public class VOMenu
    {
        public int category { get; set; }  // 카테고리 코드
        public int code { get; set; }      // 메뉴 코드
        public int price { get; set; }     // 가격
        public string type { get; set; }   // COLD/HOT
        public string size { get; set; }   // SMALL/REGULAR
        public int count { get; set; }     // 개수
    }

    public class DTOPurchasesResponse
    {
        public int total_price { get; set; }
        public int total_dc_price { get; set; }
        public string purchased_date { get; set; }

        // Error Template
        public int code { get; set; }
        public string reason { get; set; }
    }



    //++++++++++++++++++++++++++++++++++++++++++++++++++++++    
    // 구매 이력 조회 임시 URL 요청 응답
    //++++++++++++++++++++++++++++++++++++++++++++++++++++++
    public class DTOPurchaseHistoryOnetimeURLRequest
    {
        public string rfid { get; set; }
        public long purchase_before { get; set; }
        public long purchase_after { get; set; }
    }

    public class DTOPurchaseHistoryOnetimeURLResponse
    {
        public string uri { get; set; }

        // Error Template
        public int code { get; set; }
        public string reason { get; set; }
    }



    //++++++++++++++++++++++++++++++++++++++++++++++++++++++
    // 구매 취소 요청 응답
    //++++++++++++++++++++++++++++++++++++++++++++++++++++++
    public class DTOPurchaseCancelRequest
    {
        public string rfid { get; set; }
    }

    public class DTOPurchaseCancelResponse
    {
        public int receipt_id { get; set; }
        public string purchased_date { get; set; }
        public List<VOPurchaseCancelMenu> purchase_cancels { get; set; }

        // Error Template
        public int code { get; set; }
        public string reason { get; set; }
    }

    public class VOPurchaseCancelMenu
    {
        public int catetory { get; set; }
        public int code { get; set; }
        public int price { get; set; }
        public int dc_price { get; set; }
        public string type { get; set; }
        public string size { get; set; }
        public int count { get; set; }
        public string menu_name_kr { get; set; }
        public int user_record_index { get; set; }
        public int receipt_id { get; set; }
        public int receip_status { get; set; }
    }
}
