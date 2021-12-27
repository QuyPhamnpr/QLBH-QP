using QLBH_BUS;
using QLBH_DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cau1
{
    public partial class Form1 : Form
    {
        QLBUS cusBUS = new QLBUS();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<QLDTO> lstCus = cusBUS.ReadCustomer();
            foreach (QLDTO cus in lstCus)
            {
                dgvQLKH.Rows.Add(cus.Makhachhang, cus.Tenkhachhang, cus.Sodienthoai, cus.Sotienno);
            }
        }

        private void dgvQLKH_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int idx = e.RowIndex;
            DataGridViewRow row = dgvQLKH.Rows[idx];
            if (row.Cells[0].Value != null)
            {
                tbId.Text = row.Cells[0].Value.ToString();
                tbName.Text = row.Cells[1].Value.ToString();
                tbPhone.Text = row.Cells[2].Value.ToString();
                tbNo.Text = row.Cells[3].Value.ToString();
            }
        }

        private void btnNew_Click_1(object sender, EventArgs e)
        {
            if (tbId.Text != "" && tbName.Text != "" && tbPhone.Text != "" && tbNo.Text != "")
            {
                QLDTO cus = new QLDTO();
                cus.Makhachhang = tbId.Text;
                cus.Tenkhachhang = tbName.Text;
                cus.Sodienthoai = tbPhone.Text;
                cus.Sotienno = tbNo.Text;
                cusBUS.AddCustomer(cus);
                dgvQLKH.Rows.Add(cus.Makhachhang, cus.Tenkhachhang, cus.Sodienthoai, cus.Sotienno);

            }
            else
                MessageBox.Show("Nhập đầy đủ thông tin nhân viên");

        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            if (tbId.Text == "" && tbName.Text == "" && tbPhone.Text == "" && tbNo.Text == "")
            {
                MessageBox.Show("Chọn nhân viên cần xoá");
            }
            else
            {
                if (MessageBox.Show("Bạn có muốn xoá", "Thông báo",
                   MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    QLDTO cus = new QLDTO();
                    cus.Makhachhang = tbId.Text;
                    cus.Tenkhachhang = tbName.Text;
                    cus.Sodienthoai = tbPhone.Text;
                    cus.Sotienno = tbNo.Text;

                    cusBUS.DeleteCustomer(cus);
                    int idx = dgvQLKH.CurrentCell.RowIndex;
                    dgvQLKH.Rows.RemoveAt(idx);
                }
            }
        }

        private void btnEdit_Click_1(object sender, EventArgs e)
        {
            DataGridViewRow row = dgvQLKH.CurrentRow;
            if (row != null)
            {
                QLDTO cus = new QLDTO();
                cus.Makhachhang = tbId.Text;
                cus.Tenkhachhang = tbName.Text;
                cus.Sodienthoai = tbPhone.Text;
                cus.Sotienno = tbNo.Text;
                cusBUS.EditCustomer(cus);

                row.Cells[0].Value = cus.Makhachhang;
                row.Cells[1].Value = cus.Tenkhachhang;
                row.Cells[2].Value = cus.Sodienthoai;
                row.Cells[3].Value = cus.Sotienno;

            }
            else
                MessageBox.Show("Chọn nhân viên cần sửa");
        }

        private void btnExit_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
