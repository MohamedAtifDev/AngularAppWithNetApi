using Microsoft.AspNetCore.Identity;

namespace OnlineExamAPI.DAL.Entities
{
    public class AppUser:IdentityUser
    {
        public IEnumerable<UserExam> userExams { get; set; }
    }
}
