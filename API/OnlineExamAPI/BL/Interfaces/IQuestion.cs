using OnlineExamAPI.DAL.Entities;

namespace OnlineExamAPI.BL.Interfaces
{
    public interface IQuestion
    {
        Question GetQuestion(int id);
        public IEnumerable<Question> getAll();
        int create(Question question);
        void update(Question question);
        void delete(int id);
    }
}
