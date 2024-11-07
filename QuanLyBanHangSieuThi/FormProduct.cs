using QuanLyBanHangSieuThi.DAL;
using QuanLyBanHangSieuThi.Entity;
using QuanLyBanHangSieuThi.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanHangSieuThi
{
    public partial class FormProduct : Form
    {
        public FormProduct()
        {
            InitializeComponent();
        }

        private BeverageDAL beverageDAL = new BeverageDAL();
        private FoodDAL foodDAL = new FoodDAL();
        private HouseHoldItemDAL houseHoldItemDAL = new HouseHoldItemDAL();
        private List<Product> products = new List<Product>();
        BindingSource src = new BindingSource();
        private void FormProduct_Load(object sender, EventArgs e)
        {
            gridData.ReadOnly = true;
            gridData.DataSource = src;
            LoadProducts();
        }

        private void LoadProducts()
        {
            List<Beverage> beverages = beverageDAL.Load();
            List<Food> foods = foodDAL.Load();
            List<HouseHoldItem> houseHoldItems = houseHoldItemDAL.Load();

            for (int i = 0; i < beverages.Count; i++)
            {
                products.Add(beverages[i]);
            }

            for (int i = 0; i < foods.Count; i++)
            {
                products.Add(foods[i]);
            }

            for (int i = 0; i < houseHoldItems.Count; i++)
            {
                products.Add(houseHoldItems[i]);
            }

            src.DataSource = products;
            src.ResetBindings(true);
        }
    }
}
