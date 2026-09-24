using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Bai42
{
    // Class dữ liệu dùng cho Binding Data vào ComboBox
    public class Course
    {
        public string CourseID { get; set; }   // Lấy giá trị ngầm (ValueMember)
        public string CourseName { get; set; } // Hiển thị ra màn hình (DisplayMember)

        public Course(string id, string name)
        {
            CourseID = id;
            CourseName = name;
        }
    }

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // 1. Sự kiện nạp dữ liệu khi Form khởi chạy
        private void Form1_Load(object sender, EventArgs e)
        {
            // Tạo danh sách khóa học mẫu
            List<Course> courseList = new List<Course>()
            {
                new Course("NET01", "Lập trình C# WinForms"),
                new Course("NET02", "Lập trình ASP.NET Core Web API"),
                new Course("JAVA01", "Lập trình Java Cơ bản"),
                new Course("PY01", "Phân tích dữ liệu với Python")
            };

            // Thực hiện Binding Data vào ComboBox
            cboCourse.DataSource = courseList;
            cboCourse.DisplayMember = "CourseName";
            cboCourse.ValueMember = "CourseID";
        }

        // 2. Sự kiện khi người dùng bấm nút "Đăng ký"
        private void btnRegister_Click(object sender, EventArgs e)
        {
            // Kiểm tra điều khoản
            if (!chkAgree.Checked)
            {
                MessageBox.Show("Bạn phải đồng ý với điều khoản trước khi đăng ký!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy thông tin từ các điều khiển trên giao diện
            string phone = mtxtPhone.Text;
            string birthDate = dtpBirthDate.Value.ToString("dd/MM/yyyy");
            string gender = rdbMale.Checked ? "Nam" : "Nữ";
            string courseName = cboCourse.Text;
            string courseID = cboCourse.SelectedValue?.ToString();

            // Tổng hợp thông tin hiển thị
            string result = $"=== THÔNG TIN ĐĂNG KÝ ===\n\n" +
                            $"• Số điện thoại: {phone}\n" +
                            $"• Ngày sinh: {birthDate}\n" +
                            $"• Giới tính: {gender}\n" +
                            $"• Khóa học: {courseName} (Mã: {courseID})\n" +
                            $"• Trạng thái: Đã đồng ý điều khoản";

            // In thông tin lên MessageBox
            MessageBox.Show(result, "Đăng ký thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}