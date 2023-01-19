using OnlineExamAPI.DAL.Entities;
using System.ComponentModel.DataAnnotations;
namespace OnlineExamAPI.BL.VM
{
    public class AnswerVM
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Answer text  is Required")]
        [MinLength(1, ErrorMessage = "question description must be equal or greater than 1 letter")]
        public string text { get; set; }
        [Required(ErrorMessage ="question id is required")]
        [Range(1,100,ErrorMessage = " QuestionID is required")]
        
        public int questionID { get; set; }
        public Question? Question { get; set; }
    }
}
