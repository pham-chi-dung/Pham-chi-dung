using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace baitap44
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Sự kiện chạy khi Form vừa khởi động
        private void Form1_Load(object sender, EventArgs e)
        {
            // Cài đặt chế độ Zoom để ảnh vừa vặn với khung hình, không bị méo
            picImage.SizeMode = PictureBoxSizeMode.Zoom;
        }

        // Sự kiện khi bấm nút "Nạp ảnh"
        private void btnLoadImage_Click(object sender, EventArgs e)
        {
            // Tạo hộp thoại chọn file
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Chọn ảnh để mở";

                // Thiết lập bộ lọc (Filter) chỉ cho phép chọn file .jpg và .png
                openFileDialog.Filter = "Image Files (*.jpg; *.png)|*.jpg;*.png";

                // Nếu người dùng chọn file và bấm OK
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Truyền đường dẫn file vào thuộc tính ImageLocation của PictureBox
                    picImage.ImageLocation = openFileDialog.FileName;
                }
            }
        }

        // Sự kiện khi bấm nút "Xuất CSV"
        private void btnExportCSV_Click(object sender, EventArgs e)
        {
            // Tạo hộp thoại lưu file
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Title = "Lưu danh sách ra file CSV";

                // Thiết lập bộ lọc chỉ lưu dưới dạng .csv
                saveFileDialog.Filter = "CSV Files (*.csv)|*.csv";
                saveFileDialog.DefaultExt = "csv";
                saveFileDialog.AddExtension = true;

                // Nếu người dùng chọn nơi lưu và bấm OK
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Tạo sẵn một chuỗi dữ liệu bảng (giả lập) để ghi vào file
                        string csvData = "Mã SP,Tên Sản Phẩm,Giá Bán\n1,Laptop Dell,15000000\n2,Chuột Logitech,300000";

                        // Ghi dữ liệu ra file tại đường dẫn người dùng vừa chọn
                        File.WriteAllText(saveFileDialog.FileName, csvData);

                        MessageBox.Show("Đã tạo và lưu file thành công tại:\n" + saveFileDialog.FileName,
                                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Có lỗi xảy ra khi lưu file: " + ex.Message,
                                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}