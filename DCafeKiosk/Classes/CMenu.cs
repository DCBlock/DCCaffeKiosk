using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCafeKiosk
{
    enum AVAIL_SIZE
    {
        SMALL,
        REGULAR,
    }

    enum AVAIL_TYPE
    {
        HOT,
        COLD, 
        BOTH,
    }
    
    class MenuItem
    {
        public string CATEGORY { get; set; }
        public string NAMEKOR { get; set; }
        public string NAMEENG { get; set; }
        public string PRICE { get; set; }
        public string DCDIGICAP { get; set; }
        public string DCCOVISION { get; set; }
        public AVAIL_SIZE AVAILSIZE { get; set; }
        public AVAIL_TYPE AVAILTYPE { get; set; }
    }

    class MenuItems
    {
        //category - menu list mapping
        Dictionary<string, List<MenuItem>> dicMenuItems;

        MenuItems(){
        }

        ~MenuItems(){
        }

        public void AllClearMenu()
        {
            foreach (List<MenuItem> category in dicMenuItems.Values)
                category.Clear();

            dicMenuItems.Clear();
        }

        public void InsertMenu(MenuItem menuvo)
        {
            List<MenuItem> list;
            if(!dicMenuItems.TryGetValue(menuvo.CATEGORY, out list))
            {
                list = new List<MenuItem>();
                list.Add(menuvo);
                dicMenuItems.Add(menuvo.CATEGORY, list);
            }
            else
            {
                list.Add(menuvo);
            }
        }

        public Dictionary<string, List<MenuItem>> GetMenus()
        {
            return dicMenuItems;
        }
    }
}
