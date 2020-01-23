using LastPassApplication.Models;
using LastPassApplication.Models.LastPassApplication.Models.Extended;
//using LastPassApplication.Models.Extended;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LastPassApplication.Controllers
{
    public class HomeController : Controller
    {
        Models.LastPassDatabaseEntities1 db = new Models.LastPassDatabaseEntities1();

        [HttpGet]
        [OutputCache(Duration = 60)]
        public ActionResult AddNewPassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddNewPassword(AddPassword addpassword)
        {
            //Here i have implemented the code for doing encryption of password
            //string ePass = Helper.ComputeHash(addpassword.SitePassword, "SHA512", null);
            //addpassword.SitePassword = ePass.ToString();
            addpassword.SitePassword = Helper.Encryptdata(addpassword.SitePassword);
           

            db.AddPassword.Add(addpassword);
            db.SaveChanges();

            return RedirectToAction("AddNewPassword");
        }

        [HttpGet]
        [OutputCache(Duration = 60)]
        public ActionResult Decrypt()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Decrypt(AddPassword addPassword)
        {
            if(string.IsNullOrEmpty(addPassword.UserName))
            {
                ModelState.AddModelError("UserName", "UserName is required");
            }

            if (string.IsNullOrEmpty(addPassword.NameSite))
            {
                ModelState.AddModelError("NameSite", "Name Site is required");
            }

            if (ModelState.IsValid)
            {
                AddPassword objuser = db.AddPassword.Where(x => x.UserName == addPassword.UserName && x.NameSite == addPassword.NameSite).FirstOrDefault();


                Session["SitePassword"] = Helper.Decryptdata(objuser.SitePassword);
            }            
            return View();
        }



       


        // GET: Home
        public ActionResult Login()
        {
            return View();
        }

    
        [HttpPost]
        
        public ActionResult AddPassword(AddPassword addpassword)
        {
            //Here i have implemented the code for doing encryption of password
            string ePass = Helper.ComputeHash(addpassword.SitePassword, "SHA512", null);
            addpassword.SitePassword = ePass.ToString();
                
            db.AddPassword.Add(addpassword);
            db.SaveChanges();

            return View();

        }

      

        [HttpGet]
        public ActionResult EndPage()
        {

            return View();
        }

    }
    }








