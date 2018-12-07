using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DCafeKiosk
{
    public partial class UCOrderTitle : UserControl
    {
        public UCOrderTitle()
        {
            InitializeComponent();

            // 테이블레이아웃 컬럼 사이즈 조정
            SuspendLayout();
            {
                this.tableLayoutPanel1.ColumnStyles[0].SizeType = SizeType.Percent; // 품목
                this.tableLayoutPanel1.ColumnStyles[0].Width = 34;

                this.tableLayoutPanel1.ColumnStyles[1].SizeType = SizeType.Percent; // 용량
                this.tableLayoutPanel1.ColumnStyles[1].Width = 22;

                this.tableLayoutPanel1.ColumnStyles[2].SizeType = SizeType.Percent; // 종류
                this.tableLayoutPanel1.ColumnStyles[2].Width = 16;

                this.tableLayoutPanel1.ColumnStyles[3].SizeType = SizeType.Percent; // 단가
                this.tableLayoutPanel1.ColumnStyles[3].Width = 15;

                this.tableLayoutPanel1.ColumnStyles[4].SizeType = SizeType.Percent; // 수량
                this.tableLayoutPanel1.ColumnStyles[4].Width = 13;

                this.tableLayoutPanel1.ColumnStyles[5].SizeType = SizeType.Absolute;// 추가
                this.tableLayoutPanel1.ColumnStyles[5].Width = 60;

                this.tableLayoutPanel1.ColumnStyles[6].SizeType = SizeType.Absolute;// 빼기
                this.tableLayoutPanel1.ColumnStyles[6].Width = 60;
            }
            ResumeLayout();

            this.tableLayoutPanel1.Invalidate();
        }
    }
}
