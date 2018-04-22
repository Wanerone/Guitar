using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Guitar.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SendEmial()
        {
            int customerID = 1;
            string validataCode = System.Guid.NewGuid().ToString();
            try
            {
                System.Net.Mail.MailAddress from = new System.Net.Mail.MailAddress("xxxxxxxx@163.com", "wode"); //填写电子邮件地址，和显示名称
                System.Net.Mail.MailAddress to = new System.Net.Mail.MailAddress("xxxxx@qq.com", "nide"); //填写邮件的收件人地址和名称
                //设置好发送地址，和接收地址，接收地址可以是多个
                System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
                mail.From = from;
                mail.To.Add(to);
                mail.Subject = "主题内容";

                System.Text.StringBuilder strBody = new System.Text.StringBuilder();
                strBody.Append("点击下面链接激活账号，48小时生效，否则重新注册账号，链接只能使用一次，请尽快激活！</br>");
                strBody.Append("<a href='http://localhost:3210/Order/ActivePage?customerID=" + customerID + "&validataCode =" + validataCode + "'>点击这里</a></br>");

                mail.Body = strBody.ToString();
                mail.IsBodyHtml = true;//设置显示htmls
                //设置好发送邮件服务地址
                System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();
                client.Host = "smtp.163.com";
                //填写服务器地址相关的用户名和密码信息
                client.Credentials = new System.Net.NetworkCredential("xxxxxxxx@163.com", "xxxxxx");
                //发送邮件
                client.Send(mail);
            }
            catch { }

            return new EmptyResult();
        }
    }
}