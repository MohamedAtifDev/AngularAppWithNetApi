using OnlineExamAPI.DAL.Entities;

namespace OnlineExamAPI.BL.CustomResonse
{
    public class CustomToppers
    {
        public int degree { get; set; }
        public string duration { get; set; }
        public AppUser user { get; set; }
    }
}
