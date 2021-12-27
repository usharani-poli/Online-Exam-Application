using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Online_Exam_Application.Models;
using Dapper;

namespace Online_Exam_Application.Controllers
{
    public class QuestionsController : Controller
    {
        [Authorize(Roles = "admin,student")]
        // GET: Questions
        public ActionResult Index()
        {
            IEnumerable<Courses> courses_List = MasterContext.ReturnList<Courses>
                ("SP_getTotalQuestionsPerCourse", null);
            return View(courses_List);
        }

        [Authorize(Roles = "admin,student")]
        public ActionResult DisplayQuestions(string course_title)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@course_title", course_title);
            IEnumerable<Questions> Questions_List = MasterContext.ReturnList<Questions>
                ("getQuestionsofCourse", parameters);
            TempData["QuestionsList"] = Questions_List;
            TempData["qData"] = Questions_List.First();
            TempData["a"] = 1;
            Session["Total_Questions"] = Questions_List.Count();
            Session["course_title"] = course_title;
            Session["correctAns"] = 0;
            return RedirectToAction("NextQuestion");
        }

        /*[HttpPost]
        [ActionName("DisplayQuestions")]
        public ActionResult Validate()
        {
            return RedirectToAction("Index");
        }*/

        [Authorize(Roles = "admin")]
        public ActionResult AddQuestion()
        {
            ViewBag.Courses = new SelectList(MasterContext.ReturnList<Courses>("sp_getCourses", null).ToList(),
                "course_id", "course_title");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddQuestion(Questions question)
        {
            if (ModelState.IsValid)
            {
                var parameters = new DynamicParameters();
                parameters.Add("@course_id", question.course_id);
                parameters.Add("@question_title", question.Question_Name);
                parameters.Add("@ans1", question.Ans1);
                parameters.Add("@ans2", question.Ans2);
                parameters.Add("@ans3", question.Ans3);
                parameters.Add("@ans4", question.Ans4);
                parameters.Add("@correct_ans", question.Correct_Ans);

                Int32 i = MasterContext.AddOrEdit<Int32>("SP_insertQuestion", parameters);
                if (i > 0)
                    return RedirectToAction("Index");
                else return View(question);
            }

            return View(question);
        }

        [Authorize(Roles = "admin,student")]
        public ActionResult NextQuestion()
        {
            ViewBag.questionNo = (int)TempData["a"];
            TempData["qno"] = ViewBag.questionNo;
            Questions a = (Questions)TempData["qData"];
            return View(a);
        }

        [HttpPost]
        public ActionResult NextQuestion(Questions aaa)
        {
            int question_no = (int)TempData["qno"];
            if (aaa.Correct_Ans == aaa.SelectedAns)
            {
                Session["correctAns"] = Convert.ToInt32(Session["correctAns"]) + 1;
            }
            
            List<Questions> Questions_List = TempData["QuestionsList"] as List<Questions>;

            if (question_no == Questions_List.Count)
            {
                return RedirectToAction("Create", "Result");

            }
            
            TempData["qno"] = question_no + 1 ;
            TempData["a"] = TempData["qno"];
            TempData["qData"] = Questions_List[question_no];
            return RedirectToAction("NextQuestion");
        }
    }
}