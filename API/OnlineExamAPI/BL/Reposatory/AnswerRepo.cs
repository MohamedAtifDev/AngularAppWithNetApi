using OnlineExamAPI.BL.Interfaces;
using OnlineExamAPI.DAL.Database;
using OnlineExamAPI.DAL.Entities;

namespace OnlineExamAPI.BL.Reposatory
{
    public class AnswerRepo : IAnswer
    {
        private readonly DataBase db;

        public AnswerRepo(DataBase db)
        {
            this.db = db;
        }
        public int create(Answer answer)
        {
            var ele = db.answers.Add(answer);
            db.SaveChanges();
            return ele.Entity.id;
        }

        public void delete(int id)
        {
            db.answers.Remove(db.answers.Find(id));
            db.SaveChanges();
        }

        public IEnumerable<Answer> getAll()
        {
            var data = db.answers.Select(a => a);
            return data;
        }

        public Answer getAnswer(int id)
        {
          return db.answers.Find(id);
        }

        public void update(Answer answer)
        {
            db.Entry(answer).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
        }
    }
}
