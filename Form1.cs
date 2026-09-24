using System;
using System.Windows.Forms;

namespace Bai44
{
    // Class đại diện cho Món ăn gồm Tên và Giá
    public class FoodItem
    {
        public string Name { get; set; }
        public int Price { get; set; }

        public FoodItem(string name, int price)
        {
            Name = name;
            Price = price;
        }

        // Ghi đè ToString để ListBox tự động hiển thị Tên và Giá
        public override string ToString()
        {
            return $"{Name} - {Price:N0} VNĐ";
        }
    }

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // 1. Khởi tạo danh sách món ăn ban đầu
        private void Form1_Load(object sender, EventArgs e)
        {
            lstMenu.Items.Add(new FoodItem("Hamburger", 50000));
            lstMenu.Items.Add(new FoodItem("Pizza", 120000));
            lstMenu.Items.Add(new FoodItem("Gà Rán", 35000));
            lstMenu.Items.Add(new FoodItem("Pepsi", 15000));

            UpdateTotal();
        }

        // 2. Nút > : Thêm món từ lstMenu sang lstSelected
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (lstMenu.SelectedItem != null)
            {
                FoodItem selectedItem = (FoodItem)lstMenu.SelectedItem;

                // Thêm vào danh sách đã chọn
                lstSelected.Items.Add(selectedItem);

                // Cập nhật lại tổng tiền
                UpdateTotal();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn món ăn từ thực đơn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // 3. Nút < : Xóa món đang chọn khỏi lstSelected
        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lstSelected.SelectedItem != null)
            {
                // Xóa món được chọn khỏi lstSelected
                lstSelected.Items.Remove(lstSelected.SelectedItem);

                // Cập nhật lại tổng tiền
                UpdateTotal();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn món cần xóa trong danh sách đã chọn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // 4. Hàm tự động tính toán tổng tiền các món trong lstSelected
        private void UpdateTotal()
        {
            int total = 0;
            foreach (FoodItem item in lstSelected.Items)
            {
                total += item.Price;
            }

            lblTotal.Text = $"Tổng tiền: {total:N0} VNĐ";
        }
    }
}