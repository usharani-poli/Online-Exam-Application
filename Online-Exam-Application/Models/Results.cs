using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Online_Exam_Application.Models
{
    public class Results
    {
        public int result_id { get; set; }
        [Display(Name ="Student Name")]
        public string student_Name { get; set; }
        [Display(Name = "Course Name")]
        public string course_title { get; set; }
        [Display(Name = "Grade")]
        public string grade { get; set; }
        [Display(Name = "Quality")]
        public string quality { get; set; }
        [Display(Name = "Correct Answers")]
        public int correct_ans { get; set; }
        [Display(Name = "Total Questions")]
        public int Total_Questions { get; set; }
        [Display(Name ="Date and Time")]
        [DataType(DataType.DateTime)]
        public DateTime time_of_exam { get; set; }
    }
}