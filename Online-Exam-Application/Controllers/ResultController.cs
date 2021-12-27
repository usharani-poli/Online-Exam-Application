using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dapper;
using Online_Exam_Application.Models;

namespace Online_Exam_Application.Controllers
{
    public class ResultController : Controller
    {
        [Authorize(Roles = "admin")]
        // GET: Result
        public ActionResult Index()
        {
            IEnumerable<Results> results_list = MasterContext.ReturnList<Results>("sp_getresults", null);
            return View(results_list);
        }

        [Authorize(Roles = "admin,student")]
        public ActionResult Create()
        {
            int score = (int)Session["correctAns"];
            int totalQuestions = (int)Session["Total_Questions"];
            string course_title = (string)Session["course_title"];
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

            var parameters = new DynamicParameters();
            parameters.Add("@student_name", (string)@Session["candidate_name"]);
            parameters.Add("@course_title", course_title);
            parameters.Add("@grade", ViewBag.grade);
            parameters.Add("@quality", ViewBag.quality);
            parameters.Add("@correct_ans", score);
            parameters.Add("@total", totalQuestions);
            parameters.Add("@time", DateTime.Now);

            MasterContext.AddOrEdit<Int32>("SP_insertresult1", parameters);
           /* if (i > 0)
                return RedirectToAction("Index");
            else return View(question);*/

            return RedirectToAction("ShowResult");
        }

        [Authorize(Roles = "admin,student")]
        public ActionResult ShowResult()
        {
            return View();
        }

    }
}