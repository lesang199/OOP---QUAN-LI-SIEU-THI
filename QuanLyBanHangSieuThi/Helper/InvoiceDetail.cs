using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHangSieuThi.Entity
{
    [Serializable]
    public class InvoiceDetail
    {
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; } = 0;
        public decimal Qty { get; set; } = 0;
        public decimal Total {
            get
            {
                return Qty * Price; 
            }
        }
    }
}
