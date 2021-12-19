using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Online_Exam_Application.Models;
using System.Web.Security;
using Dapper;

namespace Online_Exam_Application.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(UserDetail user)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@username", user.username);
            parameters.Add("@password", user.password);
            var loginUser = MasterContext.ReturnList<UserDetail>("sp_checkValidUser", parameters);
            if (loginUser.Count() > 0)
            {
                FormsAuthentication.SetAuthCookie(user.username, false);
                @Session["candidate_name"] = user.username;
                return RedirectToAction("Index","Questions");
            }
            else
            {
                ViewBag.msg = "Invalid UserName/PassWord";
            }

            return View();
        }

        [Authorize(Roles = "admin,student")]
        public ActionResult Dashboard()
        {
            return View();
        }

        /*[Authorize(Roles = "admin")]
        public ActionResult AboutUs()
        {
            return View();
        }

        [Authorize(Roles = "student")]
        public ActionResult ContactUs()
        {
            return View();
        }*/

        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return Redirect("~/Login/Login");
        }
    }
}
