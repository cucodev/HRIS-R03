using BusinessEntities.DataEntities;
using BusinessServices.Interface;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices.InterfaceMethod
{
    public class EmailServices : IEmail
    {
        protected void SendEmail(object sender, EventArgs e)

        {
            //calling for creating the email body with html template   

           // string body = this.createEmailBody(txt_name.Text, "Please check your account Information", txt_message.Text);

            //this.SendHtmlFormattedEmail("New article published!", body);

        }



        public string createLeaveEmailBody(string Name, string policyTypeName, List<leaveSummaryEntities> appliedDates, int Balance, string template)
        {
            string dateDIV = "";
            int sum = 0;
            string body = string.Empty;
            
            //using (StreamReader reader = new StreamReader(Server.MapPath("~/HtmlTemplate.html")))
            using (StreamReader reader = new StreamReader(template))
            {
                body = reader.ReadToEnd();
            }

            
            foreach(leaveSummaryEntities x in appliedDates)
            {
                var t = "<p class='alert alert-info'>" + x.Date + " : " + x.Duration + " Days</p>";
                dateDIV = dateDIV + t;
                sum = sum + x.Duration;
            }
            int balanceAfter = Balance - sum;
            body = body.Replace("{FullName}", Name); //replacing the required things  
            body = body.Replace("{policyTypeName}", policyTypeName);
            body = body.Replace("{balanceAfter}", balanceAfter.ToString());
            body = body.Replace("{currentBalance}", Balance.ToString());
            body = body.Replace("{appliedDate}", dateDIV);
            return body;
        }


        public void SendHtmlFormattedEmail(string subject, string body, string IDVApprovalMail)
        {
            using (MailMessage mailMessage = new MailMessage())
            {
                mailMessage.From = new MailAddress(ConfigurationManager.AppSettings["LoginMail"]);
                mailMessage.Subject = subject;
                mailMessage.Body = body;
                mailMessage.IsBodyHtml = true;
                mailMessage.To.Add(new MailAddress(IDVApprovalMail));
                SmtpClient smtp = new SmtpClient();
                smtp.Host = ConfigurationManager.AppSettings["Host"];
                smtp.EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["EnableSSL"]);
                System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
                NetworkCred.UserName = ConfigurationManager.AppSettings["LoginMail"]; //reading from web.config  
                NetworkCred.Password = ConfigurationManager.AppSettings["LoginPass"]; //reading from web.config  
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                smtp.Port = int.Parse(ConfigurationManager.AppSettings["Port"]); //reading from web.config  
                smtp.Send(mailMessage);
            }
        }
    }
}
