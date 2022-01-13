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
    /// <summary>
    /// API 서버로부터 데이터를 요청하고 수신하는 메서드를 구현
    /// </summary>
    class APIController
    {
        static readonly string URL_DCCAFFE = "https://dcblock.io/api/caffe";
        static readonly string URI_GET_MENUS = "/menus";
        static readonly string URI_GET_PURCHASE_ID = "/purchases/purchase/receipt/id";
        static readonly string URI_POST_PURCHASE = "/purchases/purchase/receipt/{receipt_id}";
        static readonly string URI_PATCH_PURCHASE_CANCEL = "/purchases/purchase/receipt/{receipt_id}/cancel";
        static readonly string URI_POST_PURCHASE_HISTORY_TEMPORARY_URL = "/purchases/temporary";

        /// <summary>
        /// JSON 포멧팅 정렬
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        static string JsonFormatting(string json)
        {
            dynamic parsedJson = JsonConvert.DeserializeObject(json);
            return JsonConvert.SerializeObject(parsedJson, Formatting.Indented);
        }

        /// <summary>
        /// 메뉴 목록 가져오기
        /// </summary>
        /// <returns></returns>
        public static DTOGetMenusResponse API_GetMenus()
        {
            //============================================
            // GET http://10.1.203.12:8080/api/caffe/menus
            //============================================
            RestSharp.RestClient client = new RestSharp.RestClient(URL_DCCAFFE);
            RestSharp.RestRequest request = new RestSharp.RestRequest();
            request.AddHeader("Content-Type", "application/json");

            request.Method = RestSharp.Method.GET;
            request.RequestFormat = RestSharp.DataFormat.Json;
            request.Resource = URI_GET_MENUS;
            request.Timeout = 3000;

            //----------------------------------------
            var t1 = client.ExecuteTaskAsync(request);
            t1.Wait();

            //----------------
            // error handling
            if (t1.Result.ErrorException != null)
            {
                return null;
            }

            string json = t1.Result.Content;

            //--------------
            // debug output
            json = JsonFormatting(json);
            System.Diagnostics.Debug.WriteLine("[RESPONSE] " + json);

            //-----------------------
            // desirialized json data
            DTOGetMenusResponse dto = new DTOGetMenusResponse();
                        
            try
            {
                if (t1.Result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    dto.dicCategoryMenus = JsonConvert.DeserializeObject<Dictionary<string, List<VOCategoryMenuList>>>(json);
                    dto.code = (int)t1.Result.StatusCode;
                }
                else
                {
                    dto = JsonConvert.DeserializeObject<DTOGetMenusResponse>(json);
                }
            }
            catch (Exception ex)
            {
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
        public static DTOGetPurchaseIdResponse API_PostPurchaseId(string aRfid)
        {
            //=====================================================================
            // POST http://10.1.203.12:8080/api/caffe/purchases/purchase/receipt/id
            //=====================================================================

            RestSharp.RestClient client = new RestSharp.RestClient(URL_DCCAFFE);
            RestSharp.RestRequest request = new RestSharp.RestRequest();
            request.AddHeader("Content-Type", "application/json;charset=UTF-8");

            request.Method = RestSharp.Method.POST;
            request.RequestFormat = RestSharp.DataFormat.Json;
            request.Resource = URI_GET_PURCHASE_ID;

            //------------------------------------------------
            // make to request json

            /*            
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
            request.AddParameter("application/json", sb.ToString(), RestSharp.ParameterType.RequestBody);
            */

            DTOGetPurchaseIdRequest reqJson = new DTOGetPurchaseIdRequest
            {
                rfid = aRfid
            };

            request.AddJsonBody(reqJson);

            //----------------------------------------
            var t1 = client.ExecuteTaskAsync(request);
            t1.Wait();

            //----------------
            // error handling
            if (t1.Result.ErrorException != null)
            {
                System.Diagnostics.Debug.WriteLine("[RESPONSE] " + t1.Result.Content);
                return null;
            }

            string json = t1.Result.Content;

            //--------------
            // debug output
            json = JsonFormatting(json);
            System.Diagnostics.Debug.WriteLine("[RESPONSE] " + json);

            //-----------------------
            // desirialized json data
            DTOGetPurchaseIdResponse dto = new DTOGetPurchaseIdResponse();

            try
            {
                dto = JsonConvert.DeserializeObject<DTOGetPurchaseIdResponse>(json);
                dto.code = (int)t1.Result.StatusCode;
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
        public static DTOPurchasesResponse API_PostPurchaseSuccess(string aReceiptId, DTOPurchasesRequest aPurchasesRequest)
        {
            //================================================================================
            // POST http://10.1.203.12:8080/api/caffe/purchases/purchase/receipt/{receipt_id}
            //================================================================================

            //VOMenu menu = new VOMenu
            //{
            //    category = 100,
            //    code = 1,
            //    price = 1000,
            //    type = "HOT",
            //    size = "REGULAR",
            //    count = 5
            //};

            //DTOPurchasesRequest obj = new DTOPurchasesRequest
            //{               
            //    purchases = new List<VOMenu>
            //    {
            //        new VOMenu
            //        {
            //            category = 100,
            //            code = 1,
            //            price = 1000,
            //            type = "HOT",
            //            size = "REGULAR",
            //            count = 5
            //        },
            //        new VOMenu
            //        {
            //            category = 200,
            //            code = 8,
            //            price = 1500,
            //            type = "HOT",
            //            size = "REGULAR",
            //            count = 1
            //        },
            //    }
            //};
            //
            //string json = JsonConvert.SerializeObject(aPurchasesRequest);

            RestSharp.RestClient client = new RestSharp.RestClient(URL_DCCAFFE);
            RestSharp.RestRequest request = new RestSharp.RestRequest();
            request.AddHeader("Content-Type", "application/json;charset=UTF-8");

            request.Method = RestSharp.Method.POST;
            request.RequestFormat = RestSharp.DataFormat.Json;
            request.Resource = URI_POST_PURCHASE;

            request.AddParameter("receipt_id", aReceiptId, RestSharp.ParameterType.UrlSegment);
            request.AddJsonBody(aPurchasesRequest);

            //----------------------------------------
            var t1 = client.ExecuteTaskAsync(request);
            t1.Wait();

            //----------------
            // error handling
            if (t1.Result.ErrorException != null)
            {
                System.Diagnostics.Debug.WriteLine("[RESPONSE] " + t1.Result.Content);
                return null;
            }

            string json = t1.Result.Content;

            //--------------
            // debug output
            json = JsonFormatting(json);
            System.Diagnostics.Debug.WriteLine("[RESPONSE] " + json);

            //-----------------------
            // desirialized json data
            DTOPurchasesResponse dto = new DTOPurchasesResponse();

            try
            {
                dto = JsonConvert.DeserializeObject<DTOPurchasesResponse>(json);
                dto.code = (int)t1.Result.StatusCode;
            }
            catch (Exception ex)
            {
                dto = null;
                System.Diagnostics.Debug.WriteLine("[ERROR] " + ex.Message);
            }

            return dto;
        }

        /// <summary>
        /// 구매 취소
        /// </summary>
        /// <param name="aReceiptId"></param>
        /// <returns></returns>
        public static DTOPurchaseCancelResponse API_PatchPurchaseCancel(string aRfid, string aReceiptId)
        {
            //----------------------------------------
            DTOPurchaseCancelRequest req = new DTOPurchaseCancelRequest();
            {
                req.rfid = aRfid;
            }

            //----------------------------------------
            RestSharp.RestClient client = new RestSharp.RestClient(URL_DCCAFFE);
            RestSharp.RestRequest request = new RestSharp.RestRequest();
            request.AddHeader("Content-Type", "application/json;charset=UTF-8");

            request.Method = RestSharp.Method.PATCH;
            request.RequestFormat = RestSharp.DataFormat.Json;
            request.Resource = URI_PATCH_PURCHASE_CANCEL;

            request.AddParameter("receipt_id", aReceiptId, RestSharp.ParameterType.UrlSegment);
            request.AddJsonBody(req);

            //----------------------------------------
            var t1 = client.ExecuteTaskAsync(request);
            t1.Wait();

            //----------------------------------------
            // error handling
            if (t1.Result.ErrorException != null)
            {
                System.Diagnostics.Debug.WriteLine("[RESPONSE] " + t1.Result.Content);
                return null;
            }

            string json = t1.Result.Content;

            //----------------------------------------
            // debug output
            json = JsonFormatting(json);
            System.Diagnostics.Debug.WriteLine("[RESPONSE] " + json);

            //----------------------------------------
            // desirialized json data
            DTOPurchaseCancelResponse dto = new DTOPurchaseCancelResponse();

            try
            {
                dto = JsonConvert.DeserializeObject<DTOPurchaseCancelResponse>(json);
                dto.code = (int)t1.Result.StatusCode;
            }
            catch (Exception ex)
            {
                dto = null;
                System.Diagnostics.Debug.WriteLine("[ERROR] " + ex.Message);
            }

            return dto;
        }

        /// <summary>
        /// QRCode 생성을 위한 URL 요청
        /// </summary>
        /// <param name="aRfid"></param>
        /// <param name="aPurchaseHistoryOnetimeURL"></param>
        /// <returns></returns>
        public static DTOPurchaseHistoryOnetimeURLResponse API_PostPurchaseHistoryOnetimeURL(string aRfid, long aBeforeTimestamp, long aAfterTimestamp)
        {
            //----------------------------------------
            DTOPurchaseHistoryOnetimeURLRequest req = new DTOPurchaseHistoryOnetimeURLRequest();
            { 
                req.rfid = aRfid;
                req.purchase_before = aBeforeTimestamp;
                req.purchase_after = aAfterTimestamp;
            }

            //----------------------------------------
            RestSharp.RestClient client = new RestSharp.RestClient(URL_DCCAFFE);
            RestSharp.RestRequest request = new RestSharp.RestRequest();
            request.AddHeader("Content-Type", "application/json;charset=UTF-8");

            request.Method = RestSharp.Method.POST;
            request.RequestFormat = RestSharp.DataFormat.Json;
            request.Resource = URI_POST_PURCHASE_HISTORY_TEMPORARY_URL;
            request.AddJsonBody(req);

            //----------------------------------------
            var t1 = client.ExecuteTaskAsync(request);
            t1.Wait();

            //----------------------------------------
            // error handling
            if (t1.Result.ErrorException != null)
            {
                System.Diagnostics.Debug.WriteLine("[RESPONSE] " + t1.Result.Content);
                return null;
            }

            string json = t1.Result.Content;

            //----------------------------------------
            // debug output
            json = JsonFormatting(json);
            System.Diagnostics.Debug.WriteLine("[RESPONSE] " + json);

            //----------------------------------------
            // desirialized json data
            DTOPurchaseHistoryOnetimeURLResponse dto = new DTOPurchaseHistoryOnetimeURLResponse();

            try
            {
                dto = JsonConvert.DeserializeObject<DTOPurchaseHistoryOnetimeURLResponse>(json);
                dto.code = (int)t1.Result.StatusCode;
            }
            catch (Exception ex)
            {
                dto = null;
                System.Diagnostics.Debug.WriteLine("[ERROR] " + ex.Message);
            }

            return dto;
        }
    }
}
