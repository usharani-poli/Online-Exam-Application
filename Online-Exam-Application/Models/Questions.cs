using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Online_Exam_Application.Models
{
    public class Questions
    {
        public int id { get; set; }
        public int course_id { get; set; }
        public string Question_Name { get; set; }
        public string Ans1 { get; set; }
        public string Ans2 { get; set; }
        public string Ans3 { get; set; }
        public string Ans4 { get; set; }
        public string Correct_Ans { get; set; }
        public string SelectedAns { get; set; }
    }
}