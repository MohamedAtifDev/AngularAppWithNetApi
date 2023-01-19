using OnlineExamAPI.DAL.Entities;

namespace OnlineExamAPI.BL.Interfaces
{
    public interface IExam
    {
        Exam getExam(int id);
        public IEnumerable<Exam> getAll();
        int create(Exam exam);
        void update(Exam exam);
        void delete(int id);

    }
}
