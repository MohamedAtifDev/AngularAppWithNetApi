using OnlineExamAPI.DAL.Entities;
using System.ComponentModel.DataAnnotations;
namespace OnlineExamAPI.BL.VM
{
    public class QuestionVM
    {
        public int id { get; set; }
        [Required(ErrorMessage = "question Correct Answer is Required")]

        public string CorrectAnswer { get; set; }

        [Required(ErrorMessage = "question text  is Required")]
        [MinLength(10, ErrorMessage = "question description must be equal or greater than 10 letters")]
        public string text { get; set; }
        public IEnumerable<Answer>? answers { get; set; }
        [Required(ErrorMessage = "ExamID id is Required")]
        [Range(1, 100, ErrorMessage = " ExamID is required")]
        public int examID { get; set; }
        public Exam? exam
        { get; set; }
    }
}
