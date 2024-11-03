using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProject.Models.Classes;

namespace TravelTripProject.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        Context context = new Context();
        BlogYorum blogYorum=new BlogYorum();
        public ActionResult Index()
        {
            //var bloglar = context.Blogs.ToList();
            blogYorum.Blog=context.Blogs.ToList();
            blogYorum.Blog2=context.Blogs.OrderByDescending(x => x.ID).Take(3).ToList();
           
            return View(blogYorum);
        }
        
        public ActionResult BlogDetay(int id)
        {
            //var blog = context.Blogs.Where(x=>x.ID == id).ToList();
            //bir viewda 2 tablo listelemek için yaptık.
            blogYorum.Blog=context.Blogs.Where(x => x.ID == id).ToList();
            blogYorum.Yorum=context.Yorumlars.Where(x => x.BlogID == id).ToList();
            return View(blogYorum);
        }
        [HttpGet]
        public PartialViewResult YorumYap(int id)
        {
            ViewBag.deger = id;
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult YorumYap(Yorumlar yeniyorum)
        {
            context.Yorumlars.Add(yeniyorum);
            context.SaveChanges();
            return PartialView();
        }

    }
}