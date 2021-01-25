using EmailApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace EmailApp.Controllers
{
    public class EmailController : Controller
    {
        // GET: EmailController
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(EmailModel model )
        {
            using(MailMessage message = new MailMessage(model.FromEmail, model.To))
            {
                message.Subject = model.Subject;
                message.Body = model.Body;
                message.IsBodyHtml = false;

                using(SmtpClient smtp = new SmtpClient())
                {
                    smtp.Host = "smtp.gmail.com";
                    smtp.EnableSsl = true;
                    //NetworkCredential credencial =
                    smtp.UseDefaultCredentials = true;
                    smtp.Credentials = new NetworkCredential(model.FromEmail, model.FromPassword);
                    smtp.Port = 587;
                    smtp.Send(message);
                    //smtp.S(message);
                    //Permitir aplicações menos seguras: ATIVADO


                    ViewBag.Message = "Email Sent Successfully";
                }
            }
            return View();
        }

    }
}
