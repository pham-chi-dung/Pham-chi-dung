using System;
using System.Windows.Forms;

namespace Bai43
{
    public partial class Form1 : Form
    {
        // Khai báo biến lưu kết quả và phép toán đang chọn
        private double resultValue = 0;
        private string operationPerformed = "";
        private bool isOperationPerformed = false;

        public Form1()
        {
            InitializeComponent();
        }

        // 1. GÁN CHUNG EVENT HANDLER CHO 10 NÚT BẤM SỐ (btn0 -> btn9)
        private void NumberButton_Click(object sender, EventArgs e)
        {
            // Kiểm tra nếu ô hiển thị đang là "0" hoặc vừa bấm phép toán xong thì xóa sạch để nhập số mới
            if ((txtDisplay.Text == "0") || (isOperationPerformed))
                txtDisplay.Clear();

            isOperationPerformed = false;

            // Ép kiểu sender thành Button để lấy thuộc tính Text của nút vừa bấm
            Button btn = (Button)sender;
            txtDisplay.Text += btn.Text;
        }

        // 2. GÁN CHUNG EVENT HANDLER CHO CÁC PHÉP TOÁN (+, -, *, /)
        private void OperationButton_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            if (resultValue != 0)
            {
                btnEquals.PerformClick(); // Tự động tính kết quả dồn nếu bấm liên tiếp
                operationPerformed = btn.Text;
                isOperationPerformed = true;
            }
            else
            {
                operationPerformed = btn.Text;
                resultValue = double.Parse(txtDisplay.Text);
                isOperationPerformed = true;
            }
        }

        // 3. XỬ LÝ NÚT XÓA (C)
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = "0";
            resultValue = 0;
            operationPerformed = "";
        }

        // 4. XỬ LÝ NÚT BẰNG (=)
        private void btnEquals_Click(object sender, EventArgs e)
        {
            double secondNum;
            if (!double.TryParse(txtDisplay.Text, out secondNum)) return;

            switch (operationPerformed)
            {
                case "+":
                    txtDisplay.Text = (resultValue + secondNum).ToString();
                    break;
                case "-":
                    txtDisplay.Text = (resultValue - secondNum).ToString();
                    break;
                case "*":
                    txtDisplay.Text = (resultValue * secondNum).ToString();
                    break;
                case "/":
                    if (secondNum != 0)
                        txtDisplay.Text = (resultValue / secondNum).ToString();
                    else
                        txtDisplay.Text = "Lỗi chia 0";
                    break;
                default:
                    break;
            }

            double.TryParse(txtDisplay.Text, out resultValue);
            operationPerformed = "";
        }
    }
}