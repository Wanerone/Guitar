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
        //获得乐谱
        public ActionResult DisplayScore()
        {
            //var scores = db.MusicScore.OrderByDescending(p => p.Ms_addtime).FirstOrDefault();
            ////var score = (from s in (from p in db.MusicScore join o in db.MusicScoreStatistics on p.Ms_id equals o.Ms_id select new { p.Ms_id, p.Ms_title, p.Ms_img, p.Ms_label, o.ReadCount }) orderby s.ReadCount descending select s).Take(3).ToList();
            //var score = (from s in (from p in db.MusicScore
            //                        join o in db.MusicScoreStatistics on p.Ms_id equals o.Ms_id
            //                        select new
            //                        {
            //                            Ms_id = p.Ms_id,
            //                            Ms_title = p.Ms_title,
            //                            Ms_img = p.Ms_img,
            //                            Score = p.Score,
            //                            Ms_label = p.Ms_label,
            //                            User_id = p.User_id,
            //                            Ms_addtime = p.Ms_addtime,
            //                            ReadCount = o.ReadCount
            //                        })
            //             select s).OrderByDescending(s => s.ReadCount).Take(3);
            ////orderby s.ReadCount descending
            ////select s).Take(3);
            //var score1 = (from s in score
            //              select new
            //              {
            //                  Ms_id = s.Ms_id,
            //                  Ms_title = s.Ms_title,
            //                  Ms_img = s.Ms_img,
            //                  Ms_label = s.Ms_label,
            //                  User_id = s.User_id,
            //                  Score = s.Score,
            //                  Ms_addtime = s.Ms_addtime,
            //                  //ReadCount = s.ReadCount
            //              });
            //var score2 = new Guitar.ViewModel.MusicViewModel()
            //{
            //    mScore=scores,
            //    mScore1=score1,
            //};
            //ViewData["scored"] = score;
            //List<MusicViewModel> lstProduct = new List<MusicViewModel>();
            //foreach (var s in score1)
            //{
            //    MusicViewModel p = new MusicViewModel();
            //    p.Ms_id = s.Ms_id;
            //    p.Ms_title = s.Ms_title;
            //    p.Ms_img = s.Ms_img;
            //    p.Ms_label = s.Ms_label;
            //    p.ReadCount = s.ReadCount;
            //    lstProduct.Add(p);
            //}

            //var score1 = new Guitar.ViewModel.MusicViewModel();
            //score1 = score;
            //{
            //    //Score = score;
            //    Ms_id = score.Ms_id,
            //    Ms_title = x.Ms_title,
            //    Ms_img = x.Ms_img,
            //    Ms_label = x.Ms_label,
            //    ReadCount = x.ReadCount
            //};
            //List<MusicScore> musicView = new List<MusicScore>();
            //var score = (new MusicViewModel()
            //{
            //    //Ms_id = x.Ms_id,
            //    //Ms_title = x.Ms_title,
            //    //Ms_img = x.Ms_img,
            //    //Ms_label = x.Ms_label,
            //    //ReadCount = x.ReadCount
            //    Score = score;
            //    });

            //return View(lstProduct);
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
