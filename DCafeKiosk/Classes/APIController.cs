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
    public class DTOPurchaseIdResponse
    {
        public string receipt_id { get; set; }
        public string name { get; set; }
        public string company { get; set; }
        public string date { get; set; }
    }

    public class DTOMenu
    {
        public int category { get; set; }  // 카테고리 코드
        public int code { get; set; }      // 메뉴 코드
        public int price { get; set; }     // 가격
        public string type { get; set; }   // COLD/HOT
        public string size { get; set; }   // SMALL/REGULAR
        public int count { get; set; }     // 개수
    }

    public class DTOPurchaseList
    {
        public IList<DTOMenu> purchases { get; set; }
    }

    public class DTOPurchaseSuccessResponse
    {
        public string total_price { get; set; }
        public string total_dc_price { get; set; }
        public string purchased_date { get; set; }
    }

    /// <summary>
    /// API 서버로부터 데이터를 요청하고 수신하는 메서드를 구현
    /// </summary>
    class APIController
    {
        static readonly string DCCAFFE_URL = "http://10.1.203.12:8080/api/caffe";
        static readonly string MENUS_URI = "/menus";
        static readonly string PURCHASE_ID_URI = "/purchases/purchase/receipt/id";
        static readonly string PURCHASE_SUCCESS = "/purchases/purchase/receipt/{receipt_id}";

        static string JsonFormatting(string json)
        {
            dynamic parsedJson = JsonConvert.DeserializeObject(json);
            return JsonConvert.SerializeObject(parsedJson, Formatting.Indented);
        }

        /// <summary>
        /// 메뉴 목록 가져오기
        /// </summary>
        /// <returns></returns>
        public static DataSet API_GetMenus()
        {
            //---------------------------------------------
            // GET http://10.1.203.12:8080/api/caffe/menus

            Uri uri = new Uri(DCCAFFE_URL + MENUS_URI);

            RestSharp.RestClient client = new RestSharp.RestClient();
            client.BaseUrl = uri;

            RestSharp.RestRequest request = new RestSharp.RestRequest();
            request.AddHeader("Content-Type", "application/json;charset=UTF-8");

            request.Method = RestSharp.Method.GET;
            request.RequestFormat = RestSharp.DataFormat.Json;

            //
            var t1 = client.ExecuteTaskAsync(request);
            t1.Wait();

            //----------------
            // error handling
            if (t1.Result.ErrorException != null && t1.Result.StatusCode != System.Net.HttpStatusCode.OK) {
                return null;
            }

            string json = t1.Result.Content;

            //-------------------
            // debug output
            json = JsonFormatting(json);
            System.Diagnostics.Debug.WriteLine("[RESPONSE] " + json);

            //-----------------------
            // desirialized json data
            DataSet dto = null;

            try{
                dto = JsonConvert.DeserializeObject<DataSet>(json);
            }
            catch (Exception ex){
                dto = null;
                System.Diagnostics.Debug.WriteLine("[ERROR] " + ex.Message);
            }
            
            return dto;
        }

        /// <summary>
        /// 영수증 번호 요청
        /// sha256(rfid)를 인증하고, 구매 영수증 번호를 응답 받는다.
        /// </summary>
        /// <param name="aRfid"></param>
        /// <returns></returns>
        public static DTOPurchaseIdResponse API_PostPurchaseId(string aRfid)
        {
            //---------------------------------------------
            // POST http://10.1.203.12:8080/api/caffe/purchases/purchase/receipt/id

            Uri uri = new Uri(DCCAFFE_URL + PURCHASE_ID_URI);

            RestSharp.RestClient client = new RestSharp.RestClient();
            client.BaseUrl = uri;

            RestSharp.RestRequest request = new RestSharp.RestRequest();
            request.AddHeader("Content-Type", "application/json;charset=UTF-8");

            request.Method = RestSharp.Method.POST;
            request.RequestFormat = RestSharp.DataFormat.Json;

            //------------------------------------------------
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                writer.Formatting = Formatting.None;

                writer.WriteStartObject();
                writer.WritePropertyName("rfid");
                writer.WriteValue(aRfid);
                writer.WriteEndObject();
            }

            //------------------------------------------------
            request.AddParameter("application/json;charset=UTF-8", sb.ToString(), RestSharp.ParameterType.RequestBody);

            //----------------------------------------
            var t1 = client.ExecuteTaskAsync(request);
            t1.Wait();

            //----------------
            // error handling
            if (t1.Result.ErrorException != null && t1.Result.StatusCode != System.Net.HttpStatusCode.OK){
                //throw new RestAPIException(t1.Result.ErrorMessage, t1.Result.ErrorException);
                return null;
            }

            string json = t1.Result.Content;

            //--------------
            // debug output
            json = JsonFormatting(json);
            System.Diagnostics.Debug.WriteLine("[RESPONSE] " + json);

            //-----------------------
            // desirialized json data
            DTOPurchaseIdResponse dto = null;

            try{
                dto = JsonConvert.DeserializeObject<DTOPurchaseIdResponse>(json);
            }
            catch (Exception ex)
            {
                dto = null;
                System.Diagnostics.Debug.WriteLine("[ERROR] " + ex.Message);
            }

            return dto;
        }
        
        /// <summary>
        /// 구매 확정을 위한 주문 내역 전송
        /// </summary>
        /// <param name="aReceiptId"></param>
        /// <param name="aPurchaseList"></param>
        /// <returns></returns>
        public static DTOPurchaseIdResponse API_PostPurchaseSuccess(string aReceiptId, DTOPurchaseList aPurchaseList)
        {
            DTOMenu menu = new DTOMenu
            {
                category = 100,
                code = 1,
                price = 1000,
                type = "HOT",
                size = "REGULAR",
                count = 5
            };

            DTOPurchaseList obj = new DTOPurchaseList
            {               
                purchases = new List<DTOMenu>
                {
                    new DTOMenu
                    {
                        category = 100,
                        code = 1,
                        price = 1000,
                        type = "HOT",
                        size = "REGULAR",
                        count = 5
                    },
                    new DTOMenu
                    {
                        category = 200,
                        code = 8,
                        price = 1500,
                        type = "HOT",
                        size = "REGULAR",
                        count = 1
                    },
                }
            };

            string json = JsonConvert.SerializeObject(obj);

            return null;
        }
    }
}
