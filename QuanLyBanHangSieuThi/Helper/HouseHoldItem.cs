using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHangSieuThi.Entity
{
    [Serializable]
    public class HouseHoldItem : Product
    {
        public string Brand { get; set; }

        public HouseHoldItem(string code, string name, decimal price, decimal qty, string brand)
            : base(code, name, price, qty)
        {
            Brand = brand;
        }

        public override string DisplayInfo()
        {
            return ($"Đồ gia dụng. Thương hiệu: {Brand}");
        }
    }
}
