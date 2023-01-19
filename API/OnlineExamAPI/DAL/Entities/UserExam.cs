using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
namespace OnlineExamAPI.DAL.Entities
{
    public class UserExam
    {

        public AppUser user { get; set; }

        public Exam Exam { get; set; }
        public string AppUserID { get; set; }
        public int ExamID { get; set; }
        public int degree { get; set; }
        public string Duration { get; set; }

    }
}
