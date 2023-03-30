using Business.Abstract;
using Core.Entites.Concrete;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;

namespace Business.Concrete
{
    public class MailManager : IMailService
    {
        IConfiguration _configuration;

        public MailManager(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendForgotPasswordAsync(string to, string email, string resetToken)
        {
            StreamReader sr = new StreamReader(Directory.GetCurrentDirectory() + "..\\..\\Business\\MailTemplate\\ForgotPassword.txt");
            string line = sr.ReadToEnd();
            line = line.Replace("Password Şifreleme linki", _configuration["Mail:Audience"] + "/recover-password/" + email + "/" + resetToken);
            await SendMailAsync(to, "Forgot Password for Bitirme Projesi", line);
        }

        public async Task SendMailAsync(string to, string subject, string body)
        {
            await SendMailAsync(new[] { to }, subject, body);
        }

        public async Task SendMailAsync(string[] to, string subject, string body)
        {
            MailMessage mail = new MailMessage();
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;
            foreach (var item in to)
            {
                mail.To.Add(item);
            }
            mail.From = new MailAddress(_configuration["Mail:UserName"], _configuration["Mail:DisplayName"], System.Text.Encoding.UTF8);
            SmtpClient smtp = new SmtpClient(_configuration["Mail:Host"]);
            smtp.Credentials = new NetworkCredential(_configuration["Mail:UserName"], _configuration["Mail:Password"]);
            smtp.Port = int.Parse(_configuration["Mail:Port"]);
            smtp.EnableSsl = true;
            await smtp.SendMailAsync(mail);
        }
    }
}
