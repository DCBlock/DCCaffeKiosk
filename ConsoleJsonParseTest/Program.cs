using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleJsonParseTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //ParseMenusResponse();
            DataSet ds = API_GetMenus("http://10.1.203.12:8080/api/caffe/menus");
            AddMenus(ds);

            Console.ReadKey();
        }

        static string JsonFormatting(string json)
        {
            dynamic parsedJson = JsonConvert.DeserializeObject(json);
            return JsonConvert.SerializeObject(parsedJson, Formatting.Indented);
        }

        static DataSet API_GetMenus(string uri)
        {
            string response_json = string.Empty;

            RestSharp.RestClient client = new RestSharp.RestClient();
            client.BaseUrl = new Uri(uri);

            RestSharp.RestRequest request = new RestSharp.RestRequest();
            request.AddParameter("Content-Type", "application/json;charset=UTF-8", RestSharp.ParameterType.HttpHeader);

            var t1 = client.ExecuteGetTaskAsync(request);
            t1.Wait();

            //---------------
            // error handling
            if (t1.Result.ErrorException != null)
            {
                throw new Exception(t1.Result.ErrorMessage, t1.Result.ErrorException);
            }

            string json = t1.Result.Content;

            //-------------------
            // debug output
            json = JsonFormatting(json);
            Console.WriteLine(json);

            //-----------------------
            // desirialized json data
            DataSet ds = JsonConvert.DeserializeObject<DataSet>(json);
            return ds;
        }

        static void AddMenus(DataSet ds)
        {
            string jsonMenu =
            @"{
              'Coffee':[
                {
                  'category':100,
                  'code': 1,
                  'name_en': 'americano',
                  'name_kr': '아메리카노',
                  'price': 2500,
                  'dc_digicap': 1500,
                  'dc_covision': 0,
                  'type': 'HOT',
                  'size': 'REGULAR',
                  'event_name': ''
                },
                {
                  'category': 100,
                  'code': 1,
                  'name_en': 'latte',
                  'name_kr': '라떼',
                  'price': 2500,
                  'dc_digicap': 1500,
                  'dc_covision': 0,
                  'type': 'HOT',
                  'size': 'REGULAR',
                  'event_name': ''
                }
              ],
              'Tea': [
                {
                  'category': 100,
                  'code': 1,
                  'name_en': 'Green Tea',
                  'name_kr': '녹차',
                  'price': 2500,
                  'dc_digicap': 1500,
                  'dc_covision': 0,
                  'type': 'HOT',
                  'size': 'REGULAR',
                  'event_name': ''      
                },
                {
                  'category': 100,
                  'code': 1,
                  'name_en': 'Luisbos',
                  'name_kr': '루이보스',
                  'price': 2500,
                  'dc_digicap': 1500,
                  'dc_covision': 0,
                  'type': 'HOT',
                  'size': 'REGULAR',
                  'event_name': ''      
                }
              ]
            }";
                        
            int category_cnt = ds.Tables.Count;

            for (int i = 0; i < category_cnt; i++)
            {
                // Add categories
                AddCategory(ds.Tables[i].TableName);
                //-----------------------------------
                {
                    // Add menus
                    foreach(DataRow dr in ds.Tables[i].Rows)
                    {
                        AddMenu(
                            ds.Tables[i].TableName,
                            dr["event_name"].ToString(),
                            dr["name_kr"].ToString(),
                            dr["size"].ToString(),
                            dr["type"].ToString(),
                            (int)dr["price"],
                            (int)dr["dc_digicap"],
                            (int)dr["dc_covision"]
                            );
                        //----------------------------------
                    }
                }
            }
        }

        static void AddCategory(string name)
        { }

        static void AddMenu(
            string aCategoryName,
            string aEventName,
            string aMenuName,
            string aSize,
            string aType,
            int aPrice,
            int aDCDigicap,
            int aDCCovision)
        { }
    }
}
