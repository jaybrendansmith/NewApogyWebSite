﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using NewApogyWebSite.Models;

namespace ApogyWebsiteFull.Controllers
{
    public class ContactController : Controller
    {
        public ActionResult Index(string message)
        {
            ViewBag.Title = "Contact";
            return View();
        }

        public ActionResult Done()
        {
            return RedirectToAction("Index", "Home");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(EmailFormModel model)
        {
            if (ModelState.IsValid)
            {
                var body = "<p>Email From: {0} ({1})</p><p>Company: {3}<br/><br/>Selected Product: {4}</p><p>Message:</p><p>{2}</p>";
                var message = new MailMessage();
                message.To.Add(new MailAddress("dummyautomatic@gmail.com"));  // replace with valid value 
                message.From = new MailAddress("no-reply@apogy.com");  // replace with valid value
                message.Subject = $"Contact form from website";
                message.Body = string.Format(body, model.FromName, model.FromEmail, model.Message, model.Company, model.Products);
                message.IsBodyHtml = true;

                using (var smtp = new SmtpClient())
                {
                    var credential = new NetworkCredential
                    {
                        UserName = "server16102",  // replace with valid value
                        Password = "t4T7Pcr8WJs9z2B5"  // replace with valid value
                    };
                    smtp.Credentials = credential;
                    smtp.Host = "smtp.socketlabs.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    try
                    {
                        await smtp.SendMailAsync(message);
                        TempData["toastr"] = "success";
                    }
                    catch (Exception e)
                    {
                        TempData["toastr"] = e.Message;
                    }

                    return RedirectToAction("Done");
                }
            }
            return View(model);
        }
    }
}
