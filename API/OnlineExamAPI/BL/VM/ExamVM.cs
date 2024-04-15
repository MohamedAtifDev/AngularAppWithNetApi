using OnlineExamAPI.DAL.Entities;
using System.ComponentModel.DataAnnotations;
namespace OnlineExamAPI.BL.VM
{
    public class ExamVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Exam Name is Required")]
        [MinLength(2,ErrorMessage ="Name must be equal or greater than 2 letters")]
        public string name { get; set; }

        [Required(ErrorMessage = "Exam description is Required")]
        [MinLength(10, ErrorMessage = "Exam description must be equal or greater than 10 letters")]
        public string description { get; set; }
        [Required(ErrorMessage = "Exam final degree is Required")]
        [Range(10,100,ErrorMessage ="Exam degree must be betwee 10 and 100")]
        public int FinalDegree { get; set; }

        public IEnumerable<UserExam>? userExams { get; set; }
        public IEnumerable<Question>? questions { get; set; }

        [Required(ErrorMessage = "Exam Topic image  is Required")]
        public string imgurl { get; set; }
        [Required(ErrorMessage = "Exam Time is Required")]
        [Range(10, 100, ErrorMessage = "Exam Time must be betwee 10 and 100 minutes")]
        public int duration { get; set; }
    }
}
