using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using CoreWebSite.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreWebSite.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Hakkimizda()
        {
            return View();
        }

        public IActionResult Servis()
        {
            return View();
        }

        public IActionResult Galeri()
        {
            return View();
        }

        public IActionResult Iletisim()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Iletisim(Mail mail)
        {
            try
            {
                
                var client = new SmtpClient("smtp.gmail.com", 587);
                client.UseDefaultCredentials = false;                
                client.Credentials = new NetworkCredential("username", "password");
                client.EnableSsl = true;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;

                string mesaj = "Adı Soyadı : " + mail.Adi + " " + mail.Soyadi;
                mesaj += "\nKonu : " + mail.Konu;
                mesaj += "\nE-mail: " + mail.Email;
                mesaj += "\nMesaj: " + mail.Mesaj;
                client.Send("from_email", "to_email", mail.Konu, mesaj);

                ViewBag.Success = "Mail başarılı bir şekilde gönderildi";
                return View();
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Hata oluştu";
                return View();
            }
        }
    }
}