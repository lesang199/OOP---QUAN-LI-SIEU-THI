using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyBanHangSieuThi.Entity;

namespace QuanLyBanHangSieuThi.Helper
{
    [Serializable]
    public class Beverage : Product
    {
        public bool IsAlcoholic { get; set; }

        public Beverage(string code, string name, decimal price, decimal qty, bool isAlcoholic)
            : base(code, name, price, qty)
        {
            IsAlcoholic = isAlcoholic;
        }

        public override string DisplayInfo()
        {
            return $"Đồ uống. Có chứa cồn: {IsAlcoholic}";
        }
    }
}
