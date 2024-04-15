using OnlineExamAPI.DAL.Entities;

namespace OnlineExamAPI.BL.CustomResonse
{
    public class CustomQuestion
    {
        public int id { get; set; }
        public string CorrectAnswer { get; set; }
        public string text { get; set; }
        public IEnumerable<CustomAnswer> answers { get; set; }
        public int examID { get; set; }
      
    }
}
