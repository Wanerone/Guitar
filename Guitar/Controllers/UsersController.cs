using Guitar.Models;
using Guitar.ViewModel;
using System;
using System.Collections.Generic;
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
