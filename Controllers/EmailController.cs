using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using sZamorano_Portfolio.Models;

namespace sZamorano_Portfolio.Controllers
{
    public class EmailController : Controller
    {
        // GET: Email
        public async Task EmailGo(string emailName, string emailAddress, string emailBody)
        {

            try
            {
                var body = "<p>Email From: <bold>{0}</bold>({1})</p><p>Message:</p><p>{2}</p>";
                var from = "MyPortfolio<Example@email.com>";
                //model.Body = "This is a message from your portfolio site. The name and the email of the contacting person is above.";


                var email = new MailMessage(from,
                        ConfigurationManager.AppSettings["emailto"])
                {
                    Subject = "Portfolio Contact Email",
                    Body = string.Format(body, emailName, emailAddress,
                            emailBody),
                    IsBodyHtml = true
                };
                var svc = new EmailHelper();
                await svc.SendAsync(email);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                await Task.FromResult(0);
            }
        }
    }
}
