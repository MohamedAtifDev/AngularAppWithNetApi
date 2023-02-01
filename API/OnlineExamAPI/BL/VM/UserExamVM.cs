using OnlineExamAPI.DAL.Entities;
using System.ComponentModel.DataAnnotations;
namespace OnlineExamAPI.BL.VM
{
    public class UserExamVM
    {
        public AppUser? user { get; set; }

        public Exam? Exam { get; set; }
        [Required(ErrorMessage ="UserID is required")]


        public string AppUserID { get; set; }
     [Range(1,long.MaxValue,ErrorMessage = "Select valid ExamID ")]
        public int ExamID { get; set; }
        [Required(ErrorMessage = "degree is required")]
        public int degree { get; set; }

        [Required(ErrorMessage = "Duration is required")]
        public string Duration { get; set; }
    }
}
