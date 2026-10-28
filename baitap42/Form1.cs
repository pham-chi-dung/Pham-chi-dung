using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace baitap42
{
    public partial class Form2 : Form
    {
        private string connectionString = @"Server=ADMIN-PC;Database=QLHocVien;Integrated Security=True;";

        public Form2()
        {
            InitializeComponent();
            LoadCourses();
        }

        // Nạp danh sách Khóa học vào ComboBox (DisplayMember, ValueMember)
        private void LoadCourses()
        {
            List<CourseItem> courses = new List<CourseItem>
            {
                new CourseItem { Id = "C01", Name = "Lập trình C# WinForms" },
                new CourseItem { Id = "C02", Name = "Lập trình Web ASP.NET Core" },
                new CourseItem { Id = "C03", Name = "Quản trị CSDL SQL Server" },
                new CourseItem { Id = "C04", Name = "Phân tích dữ liệu Python" }
            };

            cboCourse.DataSource = courses;
            cboCourse.DisplayMember = "Name"; // Tên hiển thị
            cboCourse.ValueMember = "Id";     // Giá trị bên dưới
        }

        // NÂNG CẤP: Nút "Đăng ký" tổng hợp dữ liệu và LƯU VÀO CSDL
        private void btnRegister_Click(object sender, EventArgs e)
        {
            // Lấy thông tin từ các Input Controls
            string phone = mtxtPhone.Text;
            DateTime birthDate = dtpBirthDate.Value;
            string courseName = cboCourse.Text;

            // Kiểm tra sơ bộ số điện thoại có bị để trống
            if (!mtxtPhone.MaskCompleted)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ số điện thoại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // NÂNG CẤP: Lưu vào bảng Students trong SQL Server
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO Students (Phone, BirthDate, Course) VALUES (@phone, @dob, @course)";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@phone", phone);
                    cmd.Parameters.AddWithValue("@dob", birthDate.Date);
                    cmd.Parameters.AddWithValue("@course", courseName);

                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();

                    if (rows > 0)
                    {
                        // In thông báo thành công
                        string info = $"ĐĂNG KÝ THÀNH CÔNG VÀ ĐÃ LƯU CSDL!\n\n" +
                                     $"- SĐT: {phone}\n" +
                                     $"- Ngày sinh: {birthDate:dd/MM/yyyy}\n" +
                                     $"- Khóa học: {courseName}";

                        MessageBox.Show(info, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu CSDL: " + ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    // Class trợ giúp đổ dữ liệu cho ComboBox
    public class CourseItem
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
