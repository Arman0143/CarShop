using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using CarShop.DAL;
using CarShop.Models;

namespace CarShop.Controllers
{
    public class HomeController : Controller
    {
        BlackBirdEntities DB = new BlackBirdEntities();
        private int id;

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult AutoDetailingService()
        {
            return View();
        }

        public ActionResult RvDetailingService()
        {
            return View();
        }

        public ActionResult MotorCycleDetailingService()
        {
            return View();
        }

        public ActionResult Gallery()
        {
            return View();
        }

        public ActionResult Review()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Contact(int id = 0)
        {
            var data = DB.Contacts.FirstOrDefault(x => x.id == id);
            if (data != null)
            {
                var model = new ContactViewModel();

                model.id = data.id;
                model.name = data.name;
                model.email = data.email;
                model.number = data.number;
                model.service = data.service;
                model.message = data.message;
                model.status = (bool)data.status;
                return View(model);
            }
            else
            {
                return View();
            }

        }

        [HttpPost]
        public ActionResult Contact(ContactViewModel model)
        {
            string subject = "";
            string body = "";

            if (model.id > 0)
            {
                var data = DB.Contacts.FirstOrDefault(x => x.id == model.id);

                data.name =model.name;
                data.email =model.email;
                data.number =model.number;
                data.service =model.service;
                data.message =model.message;

                DB.Entry(data).State = EntityState.Modified;
                DB.SaveChanges();

                ViewBag.Message = "Data updated Successfully";
                model = new ContactViewModel();
                return View(model);
            }
            else
            {
                if (ModelState.IsValid)
                {

                    var Contacts = new Contact
                    {
                        name = model.name,
                        email = model.email,
                        number = model.number,
                        service = model.service,
                        message = model.message,
                        status = true
                    };
                    DB.Contacts.Add(Contacts);
                    DB.SaveChanges();

                    subject = "Car Shop : Car Shop Query";
                    body += " <table style='border-collapse:collapse;  table-layout:fixed;  margin:0 auto;  border-spacing:0;  padding:0; height:100%!important; width:100%!important' width='100%' height='100%' cellspacing='0' cellpadding='0' border='0'>";
                    body += "<tbody>";
                    body += " <tr>";
                    body += " <td style='border-collapse:collapse; background:#f8f8f8; padding-top:15px; padding-bottom:15px'>";
                    body += " <table style='width:600px!important; min-width:600px!important; max-width:600px!important; margin:auto; border-spacing:0; border-collapse:collapse; background:white; border-radius:0px 0px 10px 10px; padding-left:30px; padding-right:30px; padding-top:30px; padding-bottom:30px; display:block' width='600' cellspacing='0' cellpadding='0' border='0' align='center'>";
                    body += " <tbody>";
                    body += " <tr>";
                    body += " <td style='vertical-align:top; font-size:0; border-collapse:collapse'>";
                    body += " <table style='border-spacing:0; border-collapse:collapse' width='100%' cellspacing='0' cellpadding='0' border='0' bgcolor='#F8F8F8'>";


                    body += " <tbody>";
                    body += " <tr>";
                    body += " <td style='padding-top:30px; padding-bottom:5px; background-color:white'>";
                    body += " <span style='font-size:20px; color:#363636; '>Name :<b> " + model.name + "</b> </span>";
                    body += " </td>";
                    body += " </tr>";
                    body += " <tr>";
                    body += " <td style='padding-top:30px; padding-bottom:5px; background-color:white'>";
                    body += " <span style='font-size:20px; color:#363636; '>Email :<b> " + model.email + "</b> </span>";
                    body += " </td>";
                    body += " </tr>";
                    body += " <tr>";
                    body += " <td style='padding-top:30px; padding-bottom:5px; background-color:white'>";
                    body += " <span style='font-size:20px; color:#363636; '>Mobile :<b> " + model.number + "</b> </span>";
                    body += " </td>";
                    body += " </tr>";
                    body += " <tr>";
                    body += " <td style='padding-top:30px; padding-bottom:5px; background-color:white'>";
                    body += " <span style='font-size:20px; color:#363636; '>service :<b> " + model.service + "</b> </span>";
                    body += " </td>";
                    body += " </tr>";
                    body += " <tr>";
                    body += " <td style='padding-top:30px; padding-bottom:5px; background-color:white'>";
                    body += " <span style='font-size:20px; color:#363636; '>message :<b> " + model.message + "</b> </span>";
                    body += " </td>";
                    body += " </tr>";
                    body += " <tr><td style='background:#ffffff; height:20px'></td></tr>";
                    body += " </tbody>";
                    body += " </table>";
                    body += " </td>";
                    body += " </tr>";
                    body += " </tbody>";
                    body += " </table>";
                    body += " </td>";
                    body += " </tr>";
                    body += " </tbody>";
                    body += " </table>";
                    if (Contacts.id > 0)
                    {
                        MailMessage mail = new MailMessage();
                        mail.To.Add("armanrangrej780@gmail.com");
                        mail.From = new MailAddress("armanrangrej780@gmail.com");
                        mail.Subject = subject;

                        mail.Body = body;
                        mail.IsBodyHtml = true;
                        SmtpClient smtp = new SmtpClient();
                        smtp.Host = "smtp.gmail.com";
                        smtp.Port = 587;

                        smtp.Credentials = new System.Net.NetworkCredential("armanrangrej780@gmail.com", "bjjyuvgzhnefgrdi");
                        smtp.EnableSsl = true;
                        smtp.Send(mail);

                        ViewBag.Message = "Mail Send Successfully...Contact You Soon. Thank you";
                    }

                    ViewBag.Message = "Data Save Successfully";
                    model = new ContactViewModel();
                    ModelState.Clear();
                    return View(model);
                }
                else
                {
                    ModelState.Clear();
                    return View(model);
                }
            }
            
        }

        public ActionResult ContactList()
        {
            var Contacts = DB.Contacts.Where(x => x.status == true).OrderBy(x=>x.name).ToList();
            return View(Contacts);
        }

        public ActionResult DeleteContact(int id = 0)
        {
            var Data = DB.Contacts.FirstOrDefault(x => x.id == id);
            DB.Entry(Data).State = EntityState.Deleted;
            DB.SaveChanges();
            return RedirectToAction("ContactList","Home");
        }

    }
}