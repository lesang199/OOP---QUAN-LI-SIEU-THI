using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHangSieuThi.Entity
{
    [Serializable]
    public class Product
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal Qty { get; set; }

        public Product(string code, string name, decimal price, decimal qty)
        {
            Code = code;
            Name = name;
            Price = price;
            Qty = qty;
        }

        public virtual string DisplayInfo()
        {
            return ($"Tên sản phẩm: {Name}, Giá: {Price}");
        }

        public string Info
        {
            get
            {
                return DisplayInfo();
            }
        }
    }
}
