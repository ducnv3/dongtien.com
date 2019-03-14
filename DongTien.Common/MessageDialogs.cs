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

        public static DialogResult CloseForm(FormClosingEventArgs e)
        {
            const string message = "Bạn có chắc chắn muốn thoát ứng dụng?";
            const string caption = "Xác nhận";

            var result = MessageBox.Show(message, caption,
                             MessageBoxButtons.YesNo,
                             MessageBoxIcon.Question);

            return result;
        }

        public static void SaveSucess()
        {
            MessageBox.Show("Lưu cấu hình thành công !", "Thông báo");
        }

        public static void Error()
        {
            MessageBox.Show("Có lỗi xảy ra, vui lòng thực hiện lại !", "Error");
        }

        public static void CannotConectToServer()
        {
            MessageBox.Show("Không thể kết nối đến server", "Error");
        }

        public static void ValidateMapFail()
        {
            MessageBox.Show("Tồn tại đường dẫn sai", "Error");
        }
    }
}
