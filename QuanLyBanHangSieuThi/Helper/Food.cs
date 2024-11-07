using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHangSieuThi.Entity
{
    [Serializable]
    public class Food : Product
    {
        public DateTime ExpirationDate { get; set; }

        public Food(string code, string name, decimal price, decimal qty, DateTime expirationDate)
            : base(code, name, price, qty)
        {
            ExpirationDate = expirationDate;
        }

        public override string DisplayInfo()
        {
            return ($"Thực phẩm. Ngày hết hạn: {ExpirationDate.ToShortDateString()}");
        }
    }
}
