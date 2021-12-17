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
        // GET: Questions
        public ActionResult Index()
        {
            IEnumerable<Courses> courses_List = MasterContext.ReturnList<Courses>
                ("SP_getTotalQuestionsPerCourse", null);
            return View(courses_List);
        }

        public ActionResult DisplayQuestions(string course_title)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@course_title", course_title);
            IEnumerable<Questions> Questions_List = MasterContext.ReturnList<Questions>
                ("getQuestionsofCourse", parameters);
            return View(Questions_List);
        }

        [HttpPost]
        [ActionName("DisplayQuestions")]
        public ActionResult Validate()
        {
            return RedirectToAction("Index");
        }

        public ActionResult AddQuestion()
        {
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

        public ActionResult NextQuestion()
        {
            int qNo = 1;
            ViewBag.questionNo = qNo;
            Questions a = (Questions)TempData["qData"];

            return View(a);

        }
        [HttpPost]
        public ActionResult NextQuestion(Questions aaa)
        {
            if (aaa.Correct_Ans == aaa.SelectedAns && aaa.id != 1)
            {
                Session["correctAns"] = Convert.ToInt32(Session["correctAns"]) + 1;
            }
            else if (aaa.Correct_Ans == aaa.SelectedAns && aaa.id == 1)
            {
                Session["correctAns"] = 1;
            }

            if (aaa.id == 10)
            {
                return RedirectToAction("Create", "Result");

            }
            int qId = (int)aaa.id + 1;
            var parameters = new DynamicParameters();
            Questions SingleQuestion = MasterContext.ReturnList<Questions>
                ("getQuestionsofCourse", parameters).SingleOrDefault();


            ViewBag.questionNo = qId;
            TempData["a"] = SingleQuestion.id;
            TempData["qData"] = SingleQuestion;
            return RedirectToAction("NextQuestion");

        }
    }
}