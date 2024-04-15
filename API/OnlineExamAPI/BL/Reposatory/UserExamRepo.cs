using Microsoft.EntityFrameworkCore;
using OnlineExamAPI.BL.Interfaces;
using OnlineExamAPI.DAL.Database;
using OnlineExamAPI.DAL.Entities;

namespace OnlineExamAPI.BL.Reposatory
{
    public class UserExamRepo : IUserExam
    {
        private readonly DataBase db;

        public UserExamRepo(DataBase db)
        {
            this.db = db;
        }
        public void create(UserExam userExam)
        {
            db.userExams.Add(userExam);
           db.SaveChanges();
        }

        public void delete(string userid, int examid)
        {
            db.userExams.Remove(db.userExams.Where(a => a.AppUserID == userid && a.ExamID == examid).FirstOrDefault());
            db.SaveChanges();
        }

        public IEnumerable<UserExam> getAll()
        {
            return db.userExams.Select(a => a).Include("user");
        }

        public IEnumerable<UserExam> getById(string id)
        {
            var data = db.userExams.Where(a => a.AppUserID == id).Include("Exam");
            return data;
        }

        public IEnumerable<UserExam> getToppers(int examid)
        {
            return db.userExams.Where(a => a.ExamID == examid).Include("user");

        }

        public void update(UserExam userExam)
        {
            db.Entry(userExam).State=Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
        }
    }
}
