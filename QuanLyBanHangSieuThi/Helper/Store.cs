using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyBanHangSieuThi.Entity;

namespace QuanLyBanHangSieuThi.Helper
{
    [Serializable]
    public class Store
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public virtual Manager Manager { get; set; }
        public virtual List<Product> Products { get; set; } = new List<Product>();
        public virtual List<Customer> Customers { get; set; } = new List<Customer>();

    }
}
