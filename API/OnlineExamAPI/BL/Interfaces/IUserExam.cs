using OnlineExamAPI.DAL.Entities;

namespace OnlineExamAPI.BL.Interfaces
{
    public interface IUserExam
    {
        IEnumerable<UserExam> getAll();
        IEnumerable<UserExam> getById(string id);
        void create(UserExam userExam); 
        void update(UserExam userExam);
        void delete(string userid, int examid);
        IEnumerable<UserExam> getToppers(int examid);
    }
}
