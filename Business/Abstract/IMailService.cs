namespace Business.Abstract
{
    public interface IMailService
    {
        Task SendMailAsync(string to, string subject, string body);
        Task SendMailAsync(string[] to, string subject, string body);
        Task SendForgotPasswordAsync(string to, string email, string resetToken);
    }
}
