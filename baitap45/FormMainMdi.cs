using System;
using System.Windows.Forms;

namespace baitap45
{
    public partial class FormMainMdi : Form
    {
        public FormMainMdi()
        {
            InitializeComponent();
        }

        // Hàm này tự động chạy khi bạn nhấp vào menu "Mở Form Đăng Ký"
        private void mởFormĐăngKýToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 1. Khởi tạo đối tượng Form con
            FormRegister childForm = new FormRegister();

            // 2. Gán FormMainMdi hiện tại (this) làm Form cha của childForm
            childForm.MdiParent = this;

            // 3. Hiển thị Form con lên màn hình
            childForm.Show();
        }
    }
}