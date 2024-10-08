using System.Net;
using System.Net.Mail;

namespace EmailSender;

public class EmailService
{
    private readonly string smtpServer;
    private readonly int smtpPort;
    private readonly string smtpUser;
    private readonly string smtpPass;

    public EmailService()
    {
        // You can load these values from configuration settings
        smtpServer = "smtp.gmail.com";
        smtpPort = 587;  //587 for tls Or 25 for non-secure, 465 for SSL
        smtpUser = "tamjidakash100@gmail.com";
        smtpPass = "Your Password";
    }

    public async Task SendEmailAsync(string toEmail, string subject, string body)
    {
        using var message = new MailMessage();
        message.From = new MailAddress(smtpUser);
        message.To.Add(toEmail);
        message.Subject = subject;
        message.Body = body;
        message.IsBodyHtml = true;

        using var client = new SmtpClient(smtpServer, smtpPort);
        client.EnableSsl = true;
        client.Credentials = new NetworkCredential(smtpUser, smtpPass);

        try
        {
            await client.SendMailAsync(message);
            Console.WriteLine("Email sent successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error sending email: {ex.Message}");
        }

    }
}