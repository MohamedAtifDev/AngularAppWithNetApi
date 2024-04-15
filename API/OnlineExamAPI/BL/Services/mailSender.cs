using MailKit.Net.Smtp;
using MimeKit;
using OnlineExamAPI.BL.VM;


namespace OnlineExamAPI.BL.Services
{
    public class mailSender
    {
        public static async Task sendmail(sendmailVM mail)
        {
            var email = new MimeMessage
            {
                Sender = MailboxAddress.Parse("mohamedatiffahmy@outlook.com"),
                Subject = "contact message from " + mail.mail
            };

            email.To.Add(MailboxAddress.Parse("mohamed.fci_1052@fci.kfs.edu.eg"));

            var builder = new BodyBuilder();
            builder.TextBody = mail.message;

            email.Body = builder.ToMessageBody();
            email.From.Add(new MailboxAddress("", "mohamedatiffahmy@outlook.com"));

            using var smtp = new SmtpClient();
            smtp.Connect("smtp-mail.outlook.com", 587, false);
            smtp.Authenticate("mohamedatiffahmy@outlook.com", "fullstackdeveloper@99");
            await smtp.SendAsync(email);

            smtp.Disconnect(true);
        }
    }
}
