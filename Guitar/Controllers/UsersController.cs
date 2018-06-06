using Guitar.Models;
using Guitar.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using BLL;
//using Model;

namespace Guitar.Controllers
{
    public class UsersController : Controller
    {
        private GuitarEntities db = new GuitarEntities();
        //public UsersBll usersBll = new UsersBll();
        // GET: Users
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Headimg()
        {
            return View();
        }

        public ActionResult InfoSet()
        {
            int id = 2; /*Convert.ToInt32(Session["User_id"]);*/
            var user = db.Users.Find(id);
            return View(user);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SavaInfo(Users user)
        {
            if(Session["User_id"]!=null)
            {
                int id =Convert.ToInt32(Session["User_id"]);
                user = db.Users.Find(id);
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                var birth = Request["birthday"];
                var address = Request["city"];
                var name = Request["usename"];
                var sign = Request["sign"];
                var sex = Request["browser"];
                //HttpPostedFileBase postimageBase = Request.Files["Image1"];

                if (ModelState.IsValid)
                {

                    //if (postimageBase != null)
                    //{
                    //    string filePath = postimageBase.FileName;
                    //    string filename = filePath.Substring(filePath.LastIndexOf("\\") + 1);
                    //    string serverpath = Server.MapPath(@"/Images/headimg/") + filename;
                    //    string relativepath = @"/Images/headimg/" + filename;
                    //    postimageBase.SaveAs(serverpath);
                    //    user.User_img= relativepath;
                    //}

                    //else
                    //{
                    //    user.User_img = Session["User_img"].ToString();

                    //}
                    //user.User_name = name;
                    //user.User_sign = sign;
                    user.User_birthday = birth;
                    user.User_addr = address;
                    user.User_name = name;
                    user.User_sex = sex;
                    user.User_sign = sign;
                    //db.Entry(user).State = EntityState.Modified;
                    db.SaveChanges();
                    return Content("<script>;alert('修改成功!');history.go(-1)</script>");
                }
                else
                {
                    return Content("<script>;alert('失败,请重试!');history.go(-1)</script>");
                }
            }
            else
            {
                return Content("<script>;alert('请先登录!');history.go(-1)</script>");
            }
            
        }
        //获得乐谱
        public ActionResult DisplayScore()
        {
          
            return View();
        }
        // GET: Users/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        public ActionResult Add()
        {
           
            return View();
        }
        [HttpPost]
        public ActionResult Add(Users users)
        {
            //usersBll.Add(users);
            return Redirect(Url.Action("Index"));
        }
        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Users/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Users/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
