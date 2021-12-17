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

        public ActionResult Create()
        {

            int score = (int)Session["correctAns"];
            if (score >= 9)
            {
                ViewBag.grade = "A+";
                ViewBag.quality = "Best";
            }
            else if (score >= 8)
            {
                ViewBag.grade = "A";
                ViewBag.quality = "Better";
            }
            else if (score >= 5)
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

            ViewBag.candidate_id = 1;
            ViewBag.exam_id = 1;
            return RedirectToAction("ShowResult");
        }

        public ActionResult ShowResult()
        {
            return View();
        }

    }
}