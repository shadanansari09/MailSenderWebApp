using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mail;

namespace MailSender.Controllers
{
    public class MailController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Send(string recAdd, string companyName)
        {

            var sender = new MailAddress("Your email address", "Your Name");
            var recipient = new MailAddress($"{recAdd}");


            const string senderPassword = "password";

            //change the subject as per your need
            const string subject = "Application for Junior Developer";

            //change the mail body as per your need
            string body = $"Dear HR,\r\n\r\nI hope this message finds you well. I am writing to express my interest in the junior developer at {companyName}. With a Master of Computer Applications degree and hands-on experience in web development through various academic projects, I am enthusiastic about the opportunity to contribute my skills and passion to your esteemed organization.\r\n\r\nThroughout my academic journey, I have worked extensively with technologies such as C#, ASP.NET, Dotnet Core, MVC, SQL Server, Bootstrap, jQuery, and JavaScript. Some of my key projects include an Online Job Portal and an Inventory Management System, where I applied my knowledge to design, develop, and optimize functional web applications following best practices.\r\n\r\nI am proficient in using tools and frameworks like Entity Framework, ADO.NET, and Visual Studio. Additionally, I have a strong foundation in MS SQL Server, which complements my web development capabilities. I am passionate about improving systems by analyzing business requirements and implementing efficient technical solutions.\r\n\r\nI am excited about the opportunity to collaborate in an agile and dynamic environment, where I can continue to grow professionally while contributing to innovative projects. I have attached my resume for your review and would appreciate the chance to discuss how my skills could benefit your team.\r\n\r\nThank you for considering my application. I look forward to the possibility of contributing to your team and am available for an interview at your convenience.\r\n\r\nBest regards,\r\nXYZ\r\n";


            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                Credentials = new NetworkCredential(sender.Address, senderPassword)
            };

            using (var message = new MailMessage(sender, recipient)
            {
                Subject = subject,
                Body = body,


            })

            {
                try
                {

                    message.Attachments.Add(new Attachment(@"path\to\your\resume.pdf"));

                    smtp.Send(message);

                    TempData["message"] = "Email sent successfully!";
                }
                catch (Exception ex)
                {
                    TempData["message"] = "An error occurred </3 " + ex.Message;
                }


            }

            return RedirectToAction(nameof(Index));
        }
    }
}
