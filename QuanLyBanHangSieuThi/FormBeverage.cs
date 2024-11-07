using QuanLyBanHangSieuThi.DAL;
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
    public partial class FormBeverage : Form
    {
        public FormBeverage()
        {
            InitializeComponent();
        }

        private BeverageDAL _BeverageDAL = new BeverageDAL();
        private List<Beverage> _Beverages = new List<Beverage>();

        BindingSource _src = new BindingSource();
        private void FormBeverage_Load(object sender, EventArgs e)
        {
            gridData.DataSource = _src;
            gridData.AllowUserToAddRows = false;
            gridData.ReadOnly = true;

            chkIsAlcoholic.Checked = true;
            _Beverages = _BeverageDAL.Load();
            DisplayInGrid();
        }

        private void DisplayInGrid()
        {
            _src.DataSource = _Beverages;
            _src.ResetBindings(true);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtCode.Text = "";
            txtName.Text = "";
            txtPrice.Text = "";
            txtQty.Text = "";
            chkIsAlcoholic.Checked = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCode.Text))
            {
                MessageBox.Show("Mã đồ uống không được để trống !"
                    , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Beverage Beverage = null;

            for (int i = 0; i < _Beverages.Count; i++)
            {
                if (_Beverages[i].Code.ToLower() == txtCode.Text.ToLower())
                {
                    Beverage = _Beverages[i];
                    break;
                }
            }

            if (Beverage == null)
            {
                Beverage = new Beverage(txtCode.Text, txtName.Text, txtPrice.Value, txtQty.Value, chkIsAlcoholic.Checked);
                _Beverages.Add(Beverage);
            }

            Beverage.Name = txtName.Text;
            Beverage.Price = txtPrice.Value;
            Beverage.Qty = txtQty.Value;
            Beverage.IsAlcoholic = chkIsAlcoholic.Checked;

            DisplayInGrid();

            // save data in database
            _BeverageDAL.Save(_Beverages);

            MessageBox.Show("Cập nhật thông tin đồ uống thành công !"
                , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Beverage Beverage = null;

            for (int i = 0; i < _Beverages.Count; i++)
            {
                if (_Beverages[i].Code.ToLower() == txtCode.Text.ToLower())
                {
                    Beverage = _Beverages[i];
                    break;
                }
            }

            if (Beverage != null)
            {
                _Beverages.Remove(Beverage);
            }

            DisplayInGrid();

            _BeverageDAL.Save(_Beverages);


            MessageBox.Show("Xoá thông tin đồ uống thành công !"
                , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        private void gridData_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (gridData.CurrentRow == null || gridData.CurrentRow.IsNewRow)
                return;

            Beverage Beverage = gridData.CurrentRow.DataBoundItem as Beverage;

            if (Beverage == null)
                return;

            Display(Beverage);
        }

        public void Display(Beverage Beverage)
        {
            txtCode.Text = Beverage.Code;
            txtName.Text = Beverage.Name;
            txtPrice.Value = Beverage.Price;
            txtQty.Value = Beverage.Qty;
            chkIsAlcoholic.Checked = Beverage.IsAlcoholic;
        }
    }
}
