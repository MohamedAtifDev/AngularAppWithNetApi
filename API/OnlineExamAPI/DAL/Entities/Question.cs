using System.ComponentModel.DataAnnotations.Schema;
namespace OnlineExamAPI.DAL.Entities
{
    public class Question
    {  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string CorrectAnswer { get; set; }
        public string text { get; set; }
        public IEnumerable<Answer> answers { get; set; }
        public int examID { get; set; }
        public Exam exam
            { get; set; }
    }
}
