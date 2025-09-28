using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace Nhom10_QuanLyBanVeXemPhim
{
    public partial class frmBanVe : Form
    {
        public frmBanVe()
        {
            InitializeComponent();
        }

        private void lbDSPhim_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            // Lấy text
            string text = lbDSPhim.Items[e.Index].ToString();

            // Nếu item được chọn
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.MediumPurple), e.Bounds);
                e.Graphics.DrawString(text, e.Font, Brushes.White, e.Bounds);
            }
            else
            {
                // Hover màu nhạt hơn
                e.Graphics.FillRectangle(new SolidBrush(Color.WhiteSmoke), e.Bounds);
                e.Graphics.DrawString(text, e.Font, Brushes.Black, e.Bounds);
            }

            e.DrawFocusRectangle();
        }
    }
}
