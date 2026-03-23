using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QUANLYTHUVIENTLU
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panelMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnQLKhoSach_Click(object sender, EventArgs e)
        {
            panelMain.Controls.Clear();

            UC_QuanLyKhoSach uc = new UC_QuanLyKhoSach();
            uc.Dock = DockStyle.Fill;

            panelMain.Controls.Add(uc);
        }

        private void btnTKBCTTSach_Click(object sender, EventArgs e)
        {
            panelMain.Controls.Clear();

            UC_ThongKeBaoCaoSach uc = new UC_ThongKeBaoCaoSach();
            uc.Dock = DockStyle.Fill;

            panelMain.Controls.Add(uc);
        }
    }
}
