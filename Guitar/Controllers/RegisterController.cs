﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;


using System.Net.Mail;
using Guitar.Models;
using System.Data.Entity.Validation;

namespace Guitar.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        GuitarEntities db = new GuitarEntities();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
   [HttpPost]
  //[AllowAnonymous]
  //[ValidateAntiForgeryToken]
          
  public ActionResult Register(Users userInfo, HttpPostedFileBase file)
  {
            string checkPwd = Request.Form["ChkUserPwd"];
      //string vCode = Request["txtverifcode1"].ToString().ToLower();
            string vCode= Request.Form["txtverifcode1"];

            if (string.IsNullOrEmpty(checkPwd))
     {
         ModelState.AddModelError("ChkUserPwd", "确认密码不能为空");
     }
     else
 {
     if ((checkPwd) != (userInfo.User_password).ToString())
         {
               ModelState.AddModelError("PwdRepeatError", "确认密码不正确");
         }
     }
             

     if (vCode != Session["ValidateCode"].ToString())
     {
          //ModelState.AddModelError("vCode", "验证码不正确");
                return Content("<script>;alert('验证码错误！');history.go(-1)</script>");
            }
 
     bool isUserExists = db.Users.Where(a => a.User_name == userInfo.User_name).Count() != 0;
     bool isEmailExists = db.Users.Where(a => a.User_email == userInfo.User_email).Count() != 0;
 
     if (isUserExists) ModelState.AddModelError("User_name", "用户名已被占用");
     if (isEmailExists) ModelState.AddModelError("User_email", "邮箱已被注册");


            if (!ModelState.IsValid)
            {
                //return View();
                return RedirectToAction("Index","Register");
            }
            userInfo.User_addtime= DateTime.Now;
     userInfo.User_password = userInfo.User_password;
     userInfo.User_img = "~/Images/head.jpg";
     try
     {
         db.Users.Add(userInfo);        
         db.SaveChanges();
        HttpContext.Session["Users_id"] = userInfo.User_id;
        HttpContext.Session["User_name"] = userInfo.User_name;
        HttpContext.Session["User_email"] = userInfo.User_email;
        HttpContext.Session["User_img"] = userInfo.User_img;
        return RedirectToAction("Test", "Home");
     }
     catch (DbEntityValidationException dbEx)
     {
         foreach (var validationErrors in dbEx.EntityValidationErrors)
         {
            foreach (var validationError in validationErrors.ValidationErrors)
             {
             System.Diagnostics.Trace.TraceInformation("Property: {0} Error: {1}",
             validationError.PropertyName,
             validationError.ErrorMessage);
             }
         }
         throw;
     }
 }

        [HttpGet]
          public JsonResult CheckUser(string username)
          {
             var exists = db.Users.Where(a => a.User_name == username).Count() != 0;
 
             return Json(exists, JsonRequestBehavior.AllowGet);
         }

        public ActionResult SendEmail(string mailTo, string mailSubject, string mailContent)
        {

            //设置发送方的邮件信息

            string smtpServer = "smtp.qq.com";//SMTP服务器(qq邮箱)

            string mailFrom = "2644897370@qq.com";//登录名称

            string userPassword = "mhrqevlwdskkeaea";//登录密码新版之后的QQ邮箱都是使用授权码,需要到邮箱-设置-账户里面找到-生成授权码-复制进来

            //邮件服务设置

            SmtpClient smtpClient = new SmtpClient();

            smtpClient.EnableSsl = true;//使用了授权码必须设置为true

            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;//指定电子邮件发送方式

            smtpClient.Host = smtpServer;

            smtpClient.Credentials = new System.Net.NetworkCredential(mailFrom, userPassword);//用户名密码

            //发送邮件设置

            MailMessage mailMessage = new MailMessage();

            mailMessage.From = new MailAddress(mailFrom, "发件人内容", System.Text.Encoding.UTF8);//发送人

            mailMessage.To.Add(mailTo);//收件人；

            mailMessage.Subject = mailSubject;//主题

            mailMessage.Body = mailContent;//内容

            mailMessage.BodyEncoding = Encoding.UTF8;//正文编码

            mailMessage.IsBodyHtml = true;//设置为Html格式

            mailMessage.Priority = MailPriority.Low;//优先级

            try

            {

                smtpClient.Send(mailMessage);

                return View();

            }

            catch (Exception)

            {

                return View();

                throw;

            }

        }


        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Users user, string returnUrl)
        {
            //if (!ModelState.IsValid)
            //{
            //    return View("Index");
            //}
            string ValidateCode = Request.Form["txtverifcode"];
            //string ValidateCode = Request["txtverifcode"];
            if (ValidateCode != Session["ValidateCode"].ToString())
            {
                //return Content("<script>;alert('验证码错误！');history.go(-1)</script>");
                return Content("<script>alert('验证码错误！';window.location.href='~/Login/Login')");
            }
            try
            {
                //if (ModelState.IsValid)
                //{
                var users = db.Users.Where(o => o.User_email == user.User_email).Where(o => o.User_password == user.User_password).FirstOrDefault();
                if (users != null)
                {

                    //以下代码将权限保存到Session
                    // var current_user = db.Users.Where(o => o.UserName == user.UserName).FirstOrDefault();
                    HttpContext.Session["Users_id"] = users.User_id;
                    HttpContext.Session["User_name"] = users.User_name;
                    HttpContext.Session["User_email"] = users.User_email;
                    HttpContext.Session["User_img"] = users.User_img;

                    return Content("<script>;alert('登录成功!返回首页!');window.location.href='/Home/Test'</script>");

                }
                else
                {
                    return Content("<script>;alert('该账号不存在!');history.go(-1)</script>");
                }

                //}
                //else
                //{

                //}

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }



        }

    }
}
