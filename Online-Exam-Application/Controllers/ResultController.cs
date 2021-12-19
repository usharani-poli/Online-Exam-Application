using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Online_Exam_Application.Controllers
{
    public class ResultController : Controller
    {
        // GET: Result
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "admin,student")]
        public ActionResult Create()
        {
            if (Session["correctAns"] == null)
            {
                Session["correctAns"] = 0;
            }
            
            int score = (int)Session["correctAns"];
            int totalQuestions = (int)Session["Total_Questions"];
            float resultPercentatge = ((float)score /(float)totalQuestions)*100;
            if (resultPercentatge >= 90)
            {
                ViewBag.grade = "A+";
                ViewBag.quality = "Best";
            }
            else if (resultPercentatge >= 80)
            {
                ViewBag.grade = "A";
                ViewBag.quality = "Better";
            }
            else if (resultPercentatge >= 50)
            {
                ViewBag.grade = "B";
                ViewBag.quality = "Good";
            }
            else
            {
                ViewBag.grade = "F";
                ViewBag.quality = "Fail";
            }
            
            Session["grade"] = ViewBag.grade;
            Session["quality"] = ViewBag.quality;

            /*ViewBag.candidate_id = 1;
            ViewBag.exam_id = 1;*/
            return RedirectToAction("ShowResult");
        }

        [Authorize(Roles = "admin,student")]
        public ActionResult ShowResult()
        {
            return View();
        }

    }
}