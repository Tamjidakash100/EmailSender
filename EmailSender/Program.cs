using EmailSender;

string toEmail = "tamjidxda@gmail.com", subject = "Test", body = "Successfully";

EmailService emailService = new();
await emailService.SendEmailAsync(toEmail, subject, body);