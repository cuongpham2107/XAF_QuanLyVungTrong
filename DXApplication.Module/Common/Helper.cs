using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DXApplication.Module.Common
{
    public class Helper
    {
        public static void SendEmail(string from, string to, string subject, string body, string Host, int Port, string Account, string Password)
        {
            //try
            //{
            //    MailMessage message = new();
            //    SmtpClient smtp = new();
            //    message.From = new MailAddress(from);
            //    message.To.Add(new MailAddress(to));
            //    message.Subject = subject;
            //    message.IsBodyHtml = true; //to make message body as html  
            //    message.Body = body;
            //    smtp.Port = Port;
            //    smtp.Host = Host; //for gmail host  
            //    smtp.EnableSsl = true;
            //    smtp.UseDefaultCredentials = false;
            //    smtp.Credentials = new NetworkCredential(Account, Password);
            //    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            //    smtp.Send(message);
            //}
            //catch (Exception)
            //{
            //    throw new UserFriendlyException("Có lỗi trong quá trình gửi email. Hãy liên hệ với quản trị viên để xử lý.");
            //}
            try
            {
                // Thông tin tài khoản email gửi
                string senderEmail = Account;
                string senderPassword = Password;

                // Tạo đối tượng MailMessage
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(from);
                mail.To.Add(to); // Địa chỉ email người nhận
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = true;

                // Tạo đối tượng SmtpClient
                SmtpClient smtpClient = new SmtpClient(Host, Port); // Thay thế thông tin SMTP của bạn tại đây

                // Cung cấp thông tin đăng nhập SMTP
                smtpClient.Credentials = new NetworkCredential(senderEmail, senderPassword);
                smtpClient.EnableSsl = true; // Sử dụng kết nối SSL

                // Gửi email
                smtpClient.Send(mail);

                Console.WriteLine("Email đã được gửi thành công.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Đã xảy ra lỗi trong quá trình gửi email: " + ex.Message);
            }

        }

        public static string CreateBody(Dictionary<string, string> pairs, string template)
        {
            StringBuilder sb = new(template);
            foreach (var pair in pairs)
            {
                sb.Replace(pair.Key, pair.Value);
            }
            return sb.ToString();
        }
    }

}
