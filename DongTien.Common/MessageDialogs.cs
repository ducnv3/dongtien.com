using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DongTien.Common
{
    public static class MessageDialogs
    {

        public static void CloseForm(FormClosingEventArgs e)
        {
            const string message = "Bạn có chắc chắn muốn thoát ứng dụng?";
            const string caption = "Xác nhận";

            var result = MessageBox.Show(message, caption,
                             MessageBoxButtons.YesNo,
                             MessageBoxIcon.Question);

            e.Cancel = (result == DialogResult.No);
        }

        public static void SaveSucess()
        {
            MessageBox.Show("Lưu cấu hình thành công !");
        }

        public static void Error()
        {
            MessageBox.Show("Có lỗi xảy ra, vui lòng thực hiện lại !");
        }

        public static void CannotConectToServer()
        {
            MessageBox.Show("Không thể kết nối đến server", "Error");
        }
    }
}
