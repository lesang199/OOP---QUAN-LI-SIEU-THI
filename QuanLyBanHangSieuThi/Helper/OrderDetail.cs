using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHangSieuThi.Entity
{
    [Serializable]
    public class OrderDetail
    {
        public Product Product { get; set; }
        public string Code
        {
            get
            {
                if (Product == null)
                    return "";

                return this.Product.Code;
            }
        }

        public string Name
        {
            get {
                if (Product == null)
                    return "";
                return this.Product.Name; 
            }
        }

        public decimal Qty { get; set; }

        public decimal Total
        {
            get
            {
                if (Product == null)
                    return 0;

                return Product.Price * Qty;
            }
        }
    }
}
