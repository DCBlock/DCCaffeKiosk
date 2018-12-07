using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCafeKiosk
{
    interface IPageEventHandler
    {
        void OnPageSuccess();
        event EventHandler<EventArgs> PageSuccess;

        void OnPageCancle();
        event EventHandler<EventArgs> PageCancle;
    }
}
