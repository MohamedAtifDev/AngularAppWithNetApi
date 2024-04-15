using System.ComponentModel.DataAnnotations.Schema;
namespace OnlineExamAPI.DAL.Entities
{
    public class Exam
       {[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string name { get; set; }
        public string description { get; set; } 
        public int FinalDegree { get; set; }
        public IEnumerable<UserExam> userExams { get; set; }
        public IEnumerable<Question> questions { get; set; }
        public string imgurl { get; set; }   
        public int duration { get; set; }

    }
}
