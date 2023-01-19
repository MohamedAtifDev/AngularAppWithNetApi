using System.ComponentModel.DataAnnotations.Schema;
namespace OnlineExamAPI.DAL.Entities
{
    public class Answer
    {
          [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string text { get; set; }
        public int questionID { get; set; }
        public Question Question { get; set; }
    }
}
