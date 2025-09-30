using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mentor.Models;
using System.Globalization;

namespace mentor.Controllers
{
    public class HomeController : Controller
    {
        sdb context = new sdb();
        // GET: Home
        public ActionResult Index()
        {
            GeneralViewModel model = new GeneralViewModel();
            model.page = context.tbl_pages.Where(x => x.pkID == 1).Single();
           
            ViewBag.title = "index";
            
            return View(model);
        }
        public ActionResult About()
        {

            GeneralViewModel model = new GeneralViewModel();
            model.page = context.tbl_pages.Where(x => x.pkID == 2).Single();
            ViewBag.title = "about";
           
            return View(model);
        }
        public ActionResult courses()
        {
            ViewBag.title = "courses";
            GeneralViewModel model = new GeneralViewModel();
           model.page = context.tbl_pages.Where(x => x.pkID == 3).Single();
            model.courses = context.View_courses.ToList();
            return View(model);
        }
        public ActionResult events()
        {
            PersianCalendar pc = new PersianCalendar();
            ViewBag.title = "events";
            GeneralViewModel model = new GeneralViewModel();
            model.page = context.tbl_pages.Where(x => x.pkID == 4).Single();
            model.posts = context.tbl_Posts.ToList();
            foreach(tbl_Posts item in model.posts)
            {
                item.DateOfWrite = DateTime.Parse(string.Format("{0}/{1}/{2}", pc.GetYear(item.DateOfWrite), pc.GetMonth(item.DateOfWrite), pc.GetDayOfMonth(item.DateOfWrite)));
            }
            return View(model);
        }
        public ActionResult blog(int id)
        {
            ViewBag.title = "blog";
            GeneralViewModel model = new GeneralViewModel();
            model.post = context.tbl_Posts.Where(x => x.pkID == id).Single();
            model.page = context.tbl_pages.Where(x => x.pkID == 4).Single();
            model.page.Title = model.post.Title;
            model.page.keyword = model.post.KeyWords;
            model.page.Dis = model.post.Dis;
            return View(model);

        }
        public ActionResult trainers()
        {
            ViewBag.title = "trainers";
            GeneralViewModel model = new GeneralViewModel();
            model.page = context.tbl_pages.Where(x => x.pkID == 5).Single();
            model.teachers = context.View_teachers.ToList();
            return View(model);
        }
        public ActionResult contact()
        {
            ViewBag.title = "contact";
            GeneralViewModel model = new GeneralViewModel();
            model.page = context.tbl_pages.Where(x => x.pkID == 6).Single();
            return View(model);
        }
        public ActionResult _counter()
        {
            ViewBag.teacher = context.tbl_teachers.Count();
            ViewBag.courses = context.tbl_courses.Count();
            ViewBag.student = context.tbl_student.Count();
            ViewBag.events = context.tble_events.Count();

            return PartialView();
        }
        public ActionResult selectLang()
        {
            List<tbl_Languages> langs = new List<tbl_Languages>();
            langs = context.tbl_Languages.ToList();
            return View(langs);
        }
        public ActionResult setlang(int id)
        {
            var lang = context.tbl_Languages.Where(x => x.pkID == id).Single();
            Response.Cookies["langid"].Value = id.ToString();
            Response.Cookies["langid"].Expires = DateTime.Now.AddDays(500);
            Response.Cookies["direction"].Value = lang.direction;
            Response.Cookies["direction"].Expires = DateTime.Now.AddDays(500);
            return RedirectToAction("Index");
        }
    }
}