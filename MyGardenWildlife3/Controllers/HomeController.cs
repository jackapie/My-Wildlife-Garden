using MyGardenWildlife3.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MyGardenWildlife3.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Section(int Id)
        {
            Models.SectionModel sectionData = GetSectionData(Id);

            return View("sectionView", sectionData);
        }

        private static Models.SectionModel GetSectionData(int Id)
        {
            var dbHelper = new DatabaseHelper();
            var sectionData = dbHelper.GetSectionById(Id);
            return sectionData;
        }

        public ActionResult HomePage()
        {
            return View("HomeScreen");
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string UserName, string Password, string ReturnUrl)
        {
            var securityHelper = new SecurityHelper();
            
            if (securityHelper.LoginUser(UserName, Password))
            {
                FormsAuthentication.SetAuthCookie(UserName, false);
                return Redirect(ReturnUrl);

            }
            return View();
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return Redirect("~/");
        }

        public ActionResult GetImgById(int id)
        {

            var dbHelper = new DatabaseHelper();
            var figure = dbHelper.GetFigureById(id);
            var imgFile = figure.ImgFile;
            var contentType = imgFile.GetType().ToString();

            return File(imgFile, contentType);
        }
    }
}