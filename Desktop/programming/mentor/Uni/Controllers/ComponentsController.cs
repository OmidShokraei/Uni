using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mentor.Models;

namespace mentor.Controllers
{
    public class ComponentsController : Controller
    {
        sdb context = new sdb();
        // GET: Components
        public ActionResult Index()
        {
            return View();
        }
        [ChildActionOnly]
        public ActionResult _menu(string pn)
        {
            MenuModel model = new MenuModel();
            model.langs = context.tbl_Languages.Where(x => x.status == true).ToList();
            if (model.langs.Count > 1)
            {
                if (Request.Cookies["langid"] == null)
                {
                    Response.Redirect("/home/selectLang");
                }
                else
                {
                    if (Request.Cookies["langid"].Value == "")
                    {
                        Response.Redirect("/home/selectLang");
                    }
                }
            }
            else
            {
                Response.Cookies["langid"].Value = model.langs[0].pkID.ToString();
                Request.Cookies["langid"].Expires = DateTime.Now.AddDays(500);
            }
            if (Request.Cookies["langid"] != null)
            {
                int langid = int.Parse(Request.Cookies["langid"].Value);
                ViewBag.page = pn;
                model.pages = context.tbl_pages.Where(x => x.fkLangID == langid).ToList();
            }

            return PartialView(model);
           
        }
        public ActionResult _Banner(int id)
        {
            tbl_Banners banners = new tbl_Banners();
            banners = context.tbl_Banners.Where(x => x.pkID == id).Single();
            return PartialView(banners);

        }
        public ActionResult _About(int id)
        {
            tbl_About about = new tbl_About();
            about = context.tbl_About.Where(x => x.pkID == id).Single();
            return PartialView(about);
        }

    }
}