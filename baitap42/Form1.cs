using System;
using System.Windows.Forms;

namespace baitap42
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            // 1. Xóa tất cả các thông báo lỗi cũ của lần bấm trước
            errorProvider1.Clear();

            // 2. Kiểm tra dữ liệu: Nếu TextBox trống hoặc chỉ chứa dấu cách
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                // Gọi SetError: Gắn lỗi vào đúng ô txtName kèm thông báo cụ thể
                errorProvider1.SetError(txtName, "Vui lòng nhập họ và tên! Không được để trống.");

                // Đặt con trỏ chuột quay lại ô txtName để người dùng nhập ngay
                txtName.Focus();
            }
            else
            {
                // Nếu đã nhập hợp lệ, hiển thị thông báo thành công
                MessageBox.Show("Xác nhận thành công! Xin chào: " + txtName.Text,
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
        }
    }
}