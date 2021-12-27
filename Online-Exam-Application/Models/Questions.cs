using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Online_Exam_Application.Models
{
    public class Questions
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Please select a course")]
        public int course_id { get; set; }
        [Required(ErrorMessage = "Please enter the question")]
        public string Question_Name { get; set; }
        [Required(ErrorMessage = "Please enter option1 for the question")]
        public string Ans1 { get; set; }
        [Required(ErrorMessage = "Please enter option2 for the question")]
        public string Ans2 { get; set; }
        [Required(ErrorMessage = "Please enter option3 for the question")]
        public string Ans3 { get; set; }
        [Required(ErrorMessage = "Please enter option4 for the question")]
        public string Ans4 { get; set; }
        [Required(ErrorMessage = "Please enter which option is correct answer for this question")]
        public string Correct_Ans { get; set; }
        //[Required(ErrorMessage = "Please select an answer for this question")]
        public string SelectedAns { get; set; }
    }
}