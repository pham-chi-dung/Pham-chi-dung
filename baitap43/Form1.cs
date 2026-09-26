using System;
using System.ComponentModel; // Thư viện này bắt buộc phải có để dùng BindingList
using System.Windows.Forms;

namespace baitap43
{
    public partial class Form1 : Form
    {
        // Khai báo đối tượng BindingList ở cấp độ class (để dùng được ở nhiều hàm)
        BindingList<ProductModel> productList;

        public Form1()
        {
            InitializeComponent();
        }

        // Sự kiện chạy ngay khi Form vừa mở lên
        private void Form1_Load(object sender, EventArgs e)
        {
            // 1. Khởi tạo BindingList và thêm sẵn vài dữ liệu mẫu
            productList = new BindingList<ProductModel>()
            {
                new ProductModel { Id = 1, Name = "Laptop Dell", Price = 15000000 },
                new ProductModel { Id = 2, Name = "Chuột Logitech", Price = 300000 }
            };

            // 2. Tắt tính năng tự động sinh cột của DataGridView
            dgvProducts.AutoGenerateColumns = false;

            // 3. Tự thiết lập các cột tương ứng với các thuộc tính của model
            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colId",
                HeaderText = "Mã SP",
                DataPropertyName = "Id" // Tên phải khớp chính xác với thuộc tính trong ProductModel
            });

            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colName",
                HeaderText = "Tên Sản Phẩm",
                DataPropertyName = "Name",
                Width = 200 // Chỉnh độ rộng cột cho đẹp
            });

            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colPrice",
                HeaderText = "Giá Bán",
                DataPropertyName = "Price"
            });

            // 4. Gán BindingList làm DataSource cho DataGridView
            dgvProducts.DataSource = productList;
        }

        // Sự kiện khi bấm nút Thêm
        private void btnAdd_Click(object sender, EventArgs e)
        {
            // CHÚ Ý SỰ KỲ DIỆU CỦA BINDINGLIST:
            // Bạn chỉ cần thêm dữ liệu vào List (không cần đụng gì đến DataGridView)
            productList.Add(new ProductModel
            {
                Id = 3,
                Name = "Bàn phím cơ",
                Price = 850000
            });

            // Giao diện DataGridView sẽ TỰ ĐỘNG THÊM 1 DÒNG ngay lập tức!
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            productList = new BindingList<ProductModel>()
            {
                new ProductModel { Id = 1, Name = "Laptop Dell", Price = 15000000 },
                new ProductModel { Id = 2, Name = "Chuột Logitech", Price = 300000 }
            };

            // 2. Tắt tính năng tự động sinh cột của DataGridView
            dgvProducts.AutoGenerateColumns = false;

            // 3. Tự thiết lập các cột tương ứng với các thuộc tính của model
            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colId",
                HeaderText = "Mã SP",
                DataPropertyName = "Id" // Tên phải khớp chính xác với thuộc tính trong ProductModel
            });

            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colName",
                HeaderText = "Tên Sản Phẩm",
                DataPropertyName = "Name",
                Width = 200 // Chỉnh độ rộng cột cho đẹp
            });

            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colPrice",
                HeaderText = "Giá Bán",
                DataPropertyName = "Price"
            });

            // 4. Gán BindingList làm DataSource cho DataGridView
            dgvProducts.DataSource = productList;
        }
    }
}