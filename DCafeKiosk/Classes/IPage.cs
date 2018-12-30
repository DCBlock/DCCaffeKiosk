using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCafeKiosk
{
    interface IPage
    {
        /// <summary>
        /// 다음 페이지 이동
        /// </summary>
        void OnPageSuccess();
        event EventHandler<EventArgs> PageSuccess;

        /// <summary>
        /// 처음 페이지 이동
        /// </summary>
        void OnPageCancle();
        event EventHandler<EventArgs> PageCancel;

        /// <summary>
        /// 폼 데이터 초기화
        /// </summary>
        void ResetForm();
    }
}
