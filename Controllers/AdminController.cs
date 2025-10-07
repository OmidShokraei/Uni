using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using mentor.Models;
using System.IO;

namespace mentor.Controllers
{
    public class AdminController : Controller
    {
        sdb context = new sdb();
        // GET: Admin
        public ActionResult dashboard()
        {
            return View();
        }
        public ActionResult login()
        {

            return View();
        }
        public ActionResult signout()
        {
            Response.Cookies["login"].Expires=DateTime.Now.AddDays(-1);
            return View("login");
        }
        public ActionResult editTem()
        {
            if (validation())
            {
                Session["editmode"] = "yes";
            }
            return View();
        }
        public ActionResult setEdit(string mode)
        {
            Session["editmode"] = mode;
            return Json(true, JsonRequestBehavior.AllowGet);

        }
        public ActionResult login_check(string e, string p)
        {
            int s = 0;
            var user = context.tbl_admins.Where(x => x.email == e).SingleOrDefault();
            if (user == null)
            {
                s = 1;//کاربر وجود ندارد
            }
            else
            {
                if (user.password == p)
                {
                    var cookieText = Encoding.UTF8.GetBytes(user.pkID.ToString());
                    var encryptedvalue= System.Convert.ToBase64String(MachineKey.Protect(cookieText));


                    Response.Cookies["login"].Value = encryptedvalue;
                    Response.Cookies["login"].Expires = DateTime.Now.AddDays(400);
                    s = 3;//اطلاعات ورود صحیح
                }
                else
                {
                    s = 2;//پسوورد اشتباه است
                }
            }
            return Json(s, JsonRequestBehavior.AllowGet);
        }
        public ActionResult courses()
        {
            ViewBag.courses = context.View_courses.OrderByDescending(x=>x.pkID).ToList();
            ViewBag.cat = context.tbl_category.ToList();
            ViewBag.teachers = context.tbl_teachers.ToList();
            return View();
        }
        public ActionResult teachers()
        {
            var teachers = context.tbl_teachers.ToList();
            ViewBag.teachers = teachers;
            return View();
        }
        public ActionResult blog()
        {
            List<blogs> posts = new List<blogs>();
            posts = context.tbl_Posts.Select(x => new blogs() {pkID= x.pkID,Title= x.Title }).ToList();
            return View(posts);
        }
        public ActionResult pages()
        {
            List<pageData> pages = new List<pageData>();
            pages = context.tbl_pages.Select(x => new pageData { pkID=x.pkID,Name= x.Name }).ToList();
            
            return View(pages);
        }
        [HttpGet]
        public ActionResult editPage(int id)
        {
            tbl_pages page = new tbl_pages();
            page = context.tbl_pages.Where(x => x.pkID == id).Single();
            return View(page);
        }
        [HttpPost]
        public ActionResult editPage(tbl_pages p)
        {
            var page = context.tbl_pages.Where(x => x.pkID == p.pkID).Single();
            page.Name = p.Name;
            p.Dis = p.Dis;
            page.Title = p.Title;
            page.keyword = p.keyword;
            context.SaveChanges();
            return View(p);
        }
        public ActionResult edit_course(string cttl,string cdis, bool cs,int ctchr, int ccat,int cID)
        {
            try { 
            var c = context.tbl_courses.Where(x => x.pkID == cID).Single();
            c.title = cttl;
            c.dis = cdis;
            c.fkTeacherID = ctchr;
            c.fkCat = ccat;
                c.status = cs;
            context.SaveChanges();
            return Json(new { status = true, m = "" }, JsonRequestBehavior.AllowGet);
            }
            catch(Exception e)
            {
                return Json(new {status=false,m=e.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult remove_course(int id)
        {
           
            if (validation())
            {
                try
                {
                    var c = context.tbl_courses.Where(x => x.pkID == id).Single();
                    context.tbl_courses.Remove(c);
                    //context.SaveChanges();
                    return Json(new { status = true, m = "" }, JsonRequestBehavior.AllowGet);
                }
                catch (Exception e)
                {
                    return Json(new { status = false, m = e.Message }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(new { status = false, m = "شما اجازه انجام این عملیات را ندارید" }, JsonRequestBehavior.AllowGet);

            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult editimg(int cid,int pid, string imgttl, string imgalt, HttpPostedFileBase imgsrc)

        {
            string fileName = "";
            if (validation())
            {
                try
                {
                    var img = context.tbl_img.Where(x => x.pkID == pid).Single();
                    if(imgsrc!=null)
                    {
                        if(imgsrc.ContentLength>10000 && imgsrc.ContentLength < 10000000)
                        {
                            string[] name = imgsrc.FileName.Split('-');
                            fileName = Path.GetFileName("ci_"+cid.ToString()+"."+name[1]);
                            var path = Path.Combine(Server.MapPath("~/adminAssets/img/imgsrc"), fileName);
                            imgsrc.SaveAs(path);
                            img.address = fileName;
                        }
                        else
                        {
                            return Json(new { status = false, m = "حجم عکس باید بین 10 کیلوبایت تا 100 مگابایت باشد" }, JsonRequestBehavior.AllowGet);
                        }
                    }
                    img.alt = imgalt;
                    img.title = imgttl;
                    context.SaveChanges();
                    return Json(new { status = true, m = "ویرایش انجام شد",reff=img.address }, JsonRequestBehavior.AllowGet);
                }
                catch (Exception e)
                {
                    return Json(new { status = false, m = e.Message }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(new { status = false, m ="شما مجاز به انجام این عملیات نیستید"}, JsonRequestBehavior.AllowGet);
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult create_Course2()
        {
            try
            {
                if (validation())
                {
                    tbl_img ni = new tbl_img();
                    ni.address = "def.jpg";
                    context.tbl_img.Add(ni);
                    tbl_courses nc = new tbl_courses();
                    nc.title = "دوره جدید";
                    nc.dis = "توضیحات دوره جدید";
                    nc.fkCat = 1;
                    nc.img = ni.pkID;
                    context.tbl_courses.Add(nc);
                    context.SaveChanges();
                    return Json(new { status = true, m = "" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { status = true, m = "شما اجازه انجام این عملیات را ندارید" }, JsonRequestBehavior.AllowGet);

                }

            }
            catch (Exception e)
            {
                return Json(new { status = false, m = e.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
           public ActionResult createCourse()
        {
            //ViewBag.cat = context.tbl_category.ToList();
            //ViewBag.courses = context.View_courses.ToList();
            //ViewBag.teachers = context.tbl_teachers.ToList();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult createCourse(string ct, string dis)
        {
            try
            {
                if (validation()){
                    tbl_img ni = new tbl_img();
                    ni.address = "def.jpg";
                    context.tbl_img.Add(ni);
                    tbl_courses nc = new tbl_courses();
                    nc.title = ct;
                    nc.dis = dis;
                    nc.fkCat=1;
                    nc.img = ni.pkID;
                    context.tbl_courses.Add(nc);
                    context.SaveChanges();
                    ViewBag.status = true;
                    ViewBag.m = "دوره ایجاد شد";
                }
                else
                {
                    ViewBag.status = false;
                    ViewBag.m = "شما اجازه انجام این عملیات را ندارید";
                }

            }
            catch(Exception e)
            {
                ViewBag.status = false;
                ViewBag.m = e.Message;
            }
            
            return View();
        }
        

        [HttpGet]
        public ActionResult editTeacher(int id)
        {
          
            var teacher = context.View_teachers.Where(x => x.pkID == id).Single();
            ViewBag.teacher = teacher;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult editTeacher(int tid,HttpPostedFileBase chf,string imgtitle,string imgalt,string Name,string Family)
        {
            string fileName = "";
            if (validation())
            {
                try
                {
                    var t = context.tbl_teachers.Where(x => x.pkID == tid).Single();
                    var img = context.tbl_img.Where(x => x.pkID == t.fkImg).Single();
                    if (chf != null)
                    {
                        if (chf.ContentLength > 10000 && chf.ContentLength < 10000000)
                        {
                            string[] fname = chf.FileName.Split('.');
                            fileName = Path.GetFileName("ti_" + tid.ToString() + "." + fname[1]);
                            var path = Path.Combine(Server.MapPath("~/adminAssets/img/imgsrc"), fileName);
                            chf.SaveAs(path);
                            img.address = fileName;
                        }
                        else
                        {
                            return Json(new { status = false, m = "حجم عکس باید بین 10 کیلوبایت تا 100 مگابایت باشد" }, JsonRequestBehavior.AllowGet);
                        }
                    }
                    img.alt = imgalt;
                    img.title = imgtitle;
                    t.Name = Name;
                    t.Family = Family;
                    context.SaveChanges();
                    return Json(new { status = true, m = "ویرایش انجام شد", reff = img.address }, JsonRequestBehavior.AllowGet);
                }
                catch (Exception e)
                {
                    return Json(new { status = false, m = e.Message }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(new { status = false, m = "شما مجاز به انجام این عملیات نیستید" }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult addTeacher(HttpPostedFileBase chf, string imgtitle, string imgalt, string Name, string Family)
        {

            string fileName = "";
            if (validation())
            {
                try
                {
                    tbl_img ni = new tbl_img();
                    tbl_teachers nt = new tbl_teachers();
                    if (chf != null)
                    {
                        if (chf.ContentLength > 10000 && chf.ContentLength < 10000000)
                        {
                            string[] fname = chf.FileName.Split('.');
                            fileName = Path.GetFileName("ti_" + nt.pkID.ToString() + "." + fname[1]);
                            var path = Path.Combine(Server.MapPath("~/adminAssets/img/imgsrc"), fileName);
                            chf.SaveAs(path);
                            ni.address = fileName;
                        }
                        else
                        {
                            return Json(new { status = false, m = "حجم عکس باید بین 10 کیلوبایت تا 100 مگابایت باشد" }, JsonRequestBehavior.AllowGet);
                        }
                    }
                    else
                    {
                        ni.address = "mdef.png";
                    }
                    
                    ni.alt = imgalt;
                    ni.title = imgtitle;
                    nt.Name = Name;
                    nt.Family = Family;
                    context.tbl_img.Add(ni);
                    context.tbl_teachers.Add(nt);
                    context.SaveChanges();
                    return Json(new { status = true, m = "اضافه شد", reff = ni.address }, JsonRequestBehavior.AllowGet);
                }
                catch (Exception e)
                {
                    return Json(new { status = false, m = e.Message }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(new { status = false, m = "شما مجاز به انجام این عملیات نیستید" }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult CEPost(int id)
        {
            PostData np = new PostData();
            if (id != 0)
            {
                var post = context.tbl_Posts.Where(x => x.pkID == id).Single();
                np.pkID = post.pkID;
                np.Title = post.Title;
                np.Dis = post.Dis;
                np.Writer = post.fkWriter;
                np.Content = post.Contents;
                np.imageUrl = post.Image;
                np.ImageAlt = post.ImageAlt;
                np.ImageTitle = post.ImageTitle;
                np.Keywords = post.KeyWords;
            }
            else
            {
                np.pkID = 0;
            }
            
            np.Writers = context.tbl_teachers.ToList();
            return View(np);
        }


        [HttpPost]
        [ValidateInput(false)]
        public ActionResult CEPost(PostData p)
        {
            try
            {
               
                string fileName = "";
                tbl_Posts np = new tbl_Posts();
                if (p.pkID == 0)
                {
                    np.Title = p.Title;
                    np.Dis = p.Dis;
                    np.Contents = p.Content;
                    np.fkWriter = p.Writer;
                    np.DateOfWrite = DateTime.Now.Date;
                    np.ImageTitle = p.ImageTitle;
                    np.ImageAlt = p.ImageAlt;
                    np.KeyWords = p.Keywords;
                    if (p.Image != null)
                    {
                        string rand = DateTime.Now.ToString();
                        rand = rand.Replace('/', '_');
                        rand = rand.Replace(':', '_');
                        if (p.Image.ContentLength > 10000 && p.Image.ContentLength < 10000000)
                        {
                            string[] fname = p.Image.FileName.Split('.');
                            fileName = Path.GetFileName("pi_" + rand + "." + fname[1]);
                            var path = Path.Combine(Server.MapPath("~/adminAssets/img/imgsrc"), fileName);
                            p.Image.SaveAs(path);
                            np.Image = fileName;
                            if (p.pkID == 0)
                            {
                                context.tbl_Posts.Add(np);
                            }
                            context.SaveChanges();
                            p = new PostData();
                            p.m = "پست ذخیره شد";
                            p.status = true;//its done
                        }
                        else
                        {
                            p.m = "حجم عکس باید بین 10 کیلوبایت تا 100 مگابایت باشد";
                            p.status = false;
                        }


                    }
                    else
                    {
                        if (p.pkID == 0)
                        {
                            p.m = "عکس شاخص انتخاب نشده";
                            p.status = false;
                        }
                    }
                }

                else
                {
                    np = context.tbl_Posts.Where(x => x.pkID == p.pkID).Single();
                    np.Title = p.Title;
                    np.Dis = p.Dis;
                    np.Contents = p.Content;
                    np.fkWriter = p.Writer;
                    np.DateOfWrite = DateTime.Now.Date;
                    np.ImageTitle = p.ImageTitle;
                    np.ImageAlt = p.ImageAlt;
                    np.KeyWords = p.Keywords;
                    if (p.Image != null)
                    {

                        if (p.Image.ContentLength > 10000 && p.Image.ContentLength < 10000000)
                        {

                            var path = Path.Combine(Server.MapPath("~/adminAssets/img/imgsrc"), np.Image);
                            p.Image.SaveAs(path);
                        }
                        else
                        {
                            p.m = "حجم عکس باید بین 10 کیلوبایت تا 100 مگابایت باشد";
                            p.status = false;
                        }
                    }
                    p.imageUrl = np.Image;
                        p.m = "پست ویرایش شد";
                        p.status = true;//its done
                        context.SaveChanges();
                    }


                }

                
            catch(Exception e)
            {
                p.m =e.Message;
                p.status = false;
            }
            p.Writers = context.tbl_teachers.ToList();
            return View(p);
        }
        public ActionResult editText(string id, string content)
        {
            string[] path = id.Split('-');
            int pkid = int.Parse(path[1]);
            if (path[0] == "Banners")
            {
                var res = context.tbl_Banners.Where(x => x.pkID == pkid).Single();
                res.GetType().GetProperty(path[2]).SetValue(res, content);
                context.SaveChanges();
            }
            else if (path[0] == "About")
            {
                var res = context.tbl_About.Where(x => x.pkID == pkid).Single();
                res.GetType().GetProperty(path[2]).SetValue(res, content);
                context.SaveChanges();
            }
            return Json(new { status = true, m ="" }, JsonRequestBehavior.AllowGet);

        }
        public ActionResult editImage(string id, string ImageAlt, string ImageTitle, HttpPostedFileBase Image) {
            string imgfile = "";
            string[] path1 = id.Split('-');
            int pkID = int.Parse(path1[1]);
            if (path1[0] == "Banners")
            {
                var res = context.tbl_Banners.Where(x => x.pkID == pkID).Single();
                res.imgAlt = ImageAlt;
                res.imgTitle = ImageTitle;
                if (Image != null)
                {
                    var path2 = Path.Combine(Server.MapPath("~/assets/img/Banners"), Image.FileName);
                    Image.SaveAs(path2);
                    res.img = Image.FileName;
                }
                imgfile = res.img;
                context.SaveChanges();
            }
        
            else if (path1[0] == "About")
            {
                var res = context.tbl_About.Where(x => x.pkID == pkID).Single();
                res.ImageAlt = ImageAlt;
                res.ImageTitle = ImageTitle;
                if (Image != null)
                {
                    var path2 = Path.Combine(Server.MapPath("~/assets/img/about"), Image.FileName);
                    Image.SaveAs(path2);
                    res.Image = Image.FileName;
                }
                
                context.SaveChanges();
            }
        
            return Json(new { status = true, m="" }, JsonRequestBehavior.AllowGet);

              
            }
        
         

        private bool validation()
        {
            if (Request.Cookies["login"] == null) { Response.Redirect("~/admin/login"); }
            else
            {
                if (Request.Cookies["login"].Value == "") { Response.Redirect("~/admin/login"); }
                else
                {
                    var bytes = Convert.FromBase64String(Request.Cookies["login"].Value);
                    var output = MachineKey.Unprotect(bytes);
                    string result = Encoding.UTF8.GetString(output);
                    int userid = int.Parse(result);
                    var user = context.tbl_admins.Where(x => x.pkID == userid).SingleOrDefault();
                    if (user.pkID == 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return false;
          
        }

    }
}