using OnlineExamAPI.DAL.Entities;

namespace OnlineExamAPI.BL.CustomResonse
{
    public class CustomExam
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int FinalDegree { get; set; }
       
        public IEnumerable<CustomQuestion> questions { get; set; }
        public string imgurl { get; set; }
        public int duration { get; set; }
    }
}
