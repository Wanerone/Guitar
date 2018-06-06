using Guitar.Models;
using Guitar.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Guitar.Controllers
{
    public class HomeController : Controller
    {
        private GuitarEntities db = new GuitarEntities();
        public ActionResult Index()
        {
            var scores = db.MusicScore.OrderByDescending(p => p.Ms_addtime).FirstOrDefault();
            var score1 = (from p in db.MusicScore select p).OrderByDescending(p => p.Ms_addtime).Take(10);
            var musicviewmodel = (from s in (from p in db.MusicScore
                                    join o in db.MusicScoreStatistics on p.Ms_id equals o.Ms_id
                                    select new
                                    {
                                        Ms_id = p.Ms_id,
                                        Ms_title = p.Ms_title,
                                        Ms_img = p.Ms_img,
                                        Ms_label = p.Ms_label,
                                        User_id = p.User_id,
                                        ReadCount = o.ReadCount
                                    })
                         select s).OrderByDescending(s => s.ReadCount).Take(10);
            var musicviewmodel1 = (from s in musicviewmodel
                                   select new MusicViewModel
                          {
                              Ms_id = s.Ms_id,
                              Ms_title = s.Ms_title,
                              Ms_img = s.Ms_img,
                              Ms_label = s.Ms_label,
                              User_id = s.User_id,
                              ReadCount = s.ReadCount
                          });
            var users = from m in db.Users.OrderByDescending(p => p.User_addtime) select m;
            var video = (from m in db.Video.OrderByDescending(p => p.Vi_addtime) select m).Take(10);
            var score2 = new Guitar.ViewModel.IndexViewModel()
            {
                MScore = scores,
                Us=users,
                MScore1 = score1,
                MusicViewModel1=musicviewmodel1,
                Videos=video,
            };
            //var score = (from s in (from p in db.MusicScore join o in db.MusicScoreStatistics on p.Ms_id equals o.Ms_id select new { p.Ms_id, p.Ms_title, p.Ms_img, p.Ms_label, o.ReadCount }) orderby s.ReadCount descending select s).Take(3).ToList();

            //ViewData["ss"] = score;
            //orderby s.ReadCount descending
            //select s).Take(10);
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
            //              }).ToList();

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
            return View(score2);
            //return View();
        }

        //public IList<MusicViewModel> GetMusic()
        //{
        //    IList<MusicViewModel> list = (from s in (from p in db.MusicScore
        //                                         join o in db.MusicScoreStatistics on p.Ms_id equals o.Ms_id
        //                                         select new MusicViewModel
        //                                         {
        //                                             Ms_id = p.Ms_id,
        //                                             Ms_title = p.Ms_title,
        //                                             Ms_img = p.Ms_img,
        //                                             Ms_label = p.Ms_label,
        //                                             ReadCount = o.ReadCount
        //                                         })
        //                              select s).OrderByDescending(s => s.ReadCount).Take(3).ToList();
        //    return list;
        //}
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Test()
        {
            return View();
        }
    }
}