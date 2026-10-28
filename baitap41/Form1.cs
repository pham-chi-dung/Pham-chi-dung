using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace baitap41
{
    public partial class Form1 : Form
    {
        // Chuỗi kết nối CSDL sử dụng Server ADMIN-PC của bạn
        private string connectionString = @"Server=ADMIN-PC;Database=QLHocVien;Integrated Security=True;";

        public Form1()
        {
            InitializeComponent();
            
            // Gán thuộc tính ẩn mật khẩu mặc định
            txtPassword.UseSystemPasswordChar = true;

            // Gán sự kiện cho phím Enter và Esc
            this.AcceptButton = btnLogin;
            this.CancelButton = btnExit;
        }

        // 1. Xử lý nút Đăng nhập + Kiểm tra Validation + Truy vấn CSDL
        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Xóa báo lỗi cũ
            errorProvider1.Clear();

            // Validation: Kiểm tra không để trống Tên đăng nhập & Mật khẩu
            bool isValid = true;
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                errorProvider1.SetError(txtUsername, "Vui lòng nhập Tên đăng nhập!");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                errorProvider1.SetError(txtPassword, "Vui lòng nhập Mật khẩu!");
                isValid = false;
            }

            if (!isValid) return; // Nếu có ô trống thì dừng lại

            // NÂNG CẤP: Kết nối CSDL SQL Server để kiểm tra tài khoản
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT COUNT(*) FROM Users WHERE Username = @user AND Password = @pass";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@user", txtUsername.Text.Trim());
                    cmd.Parameters.AddWithValue("@pass", txtPassword.Text.Trim());

                    conn.Open();
                    int count = (int)cmd.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // Code chuyển sang Form chính ở đây nếu cần
                    }
                    else
                    {
                        MessageBox.Show("Tên đăng nhập hoặc mật khẩu không chính xác!", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối CSDL: " + ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 2. Xử lý ẩn/hiện mật khẩu
        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            // Tick chọn -> Hiện mật khẩu (UseSystemPasswordChar = false)
            // Bỏ chọn -> Ẩn mật khẩu (*)
            txtPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
        }

        // 3. Nút Thoát
        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
