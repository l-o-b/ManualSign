using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            SendMail("ulyashastar@mail.ru", "MailSubject", "MailBody"); return View();
        }
        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase upload)
        {
            if (upload != null)
            {
                // получаем имя файла
                string fileName = System.IO.Path.GetFileName(upload.FileName);
                // сохраняем файл в папку Files в проекте
                upload.SaveAs(Server.MapPath("~/Files/" + fileName));
                //считаем загруженный файл в массив
                byte[] avatar = new byte[upload.ContentLength];
                upload.InputStream.Read(avatar, 0, upload.ContentLength);
            }
            return RedirectToAction("Index");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        //МЕТОД ОТПРАВКИ ПО E.MAIL
        public static void SendMail(string email, string subject, string text)
        {
            var smtp = new SmtpClient("email.ru", 2525) // айпи нашего SMTP клиента
            {
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential(
                        "manualsign@mail.ru",
                        "123qwerty")
            };

            var message = new MailMessage(); // формируем письмо
            message.ReplyToList.Add("manualsign@mail.ru");
            message.From = new MailAddress("manualsign@mail.ru"); // отправитель
            message.To.Add(new MailAddress(email)); // адрес регистрирующегося
            message.IsBodyHtml = true; // тело письма - html
            message.Subject = subject; // заголовок письма
            message.Body = text; // текст письма

            try
            {
                smtp.Send(message); //отправляем письмо

            }
            catch
            {

            }
        }
    }
}