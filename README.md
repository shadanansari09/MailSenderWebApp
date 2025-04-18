# MailSender

# Simple Email Sender Web App 📬

This ASP.NET Core MVC web application allows you to send a job application email to any email address by simply entering the recipient's email and company name.

## Features

- Sends personalized job application emails
- Includes a resume as an attachment
- Uses SMTP (Gmail)
- Success/error messages shown after sending

## How to Use

1. Clone the repository
2. Open in Visual Studio
3. Replace the following in `MailController.cs`:
   ```csharp
   var sender = new MailAddress("your-email@gmail.com", "Your Name");
   const string senderPassword = "your-app-password";
Update the resume path if needed

Run the project and send your email!

Note
⚠️ This project uses Gmail SMTP. You'll need to enable App Passwords in your Gmail account if you have 2FA enabled.
