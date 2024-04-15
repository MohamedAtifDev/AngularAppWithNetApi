using OnlineExamAPI.DAL.Entities;

namespace OnlineExamAPI.BL.Interfaces
{
    public interface IAnswer
    {
        Answer getAnswer(int id);
        public IEnumerable<Answer> getAll();
        int create(Answer answer);
        void update(Answer answer);
        void delete(int id);
    }
}
