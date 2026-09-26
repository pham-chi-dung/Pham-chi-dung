using System;
using System.Windows.Forms;

namespace baitap41
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Tạo DUY NHẤT một hàm sự kiện cho tất cả các nút số
        private void btnNum_Click(object sender, EventArgs e)
        {
            // Ép kiểu object 'sender' về dạng 'Button'
            // 'sender' chính là cái nút mà người dùng vừa bấm vào
            Button btn = (Button)sender;

            // Xóa số 0 vô nghĩa ở đầu (nếu có) trước khi nối số mới
            if (txtDisplay.Text == "0")
            {
                txtDisplay.Text = "";
            }

            // Lấy thuộc tính Text của nút vừa bấm và nối vào TextBox
            txtDisplay.Text += btn.Text;
        }
    }
}