using Microsoft.EntityFrameworkCore;
using OnlineExamAPI.BL.Interfaces;
using OnlineExamAPI.DAL.Database;
using OnlineExamAPI.DAL.Entities;

namespace OnlineExamAPI.BL.Reposatory
{
    public class QuestionRepo : IQuestion
    {
        private readonly DataBase db;

        public QuestionRepo(DataBase db)
        {
            this.db = db;
        }
        public int create(Question question)
        {
            var ele = db.questions.Add(question);
            db.SaveChanges();
            return ele.Entity.id;
        }

        public void delete(int id)
        {
            db.questions.Remove(db.questions.Find(id));
            db.SaveChanges();
        }

        public IEnumerable<Question> getAll()
        {
            var data = db.questions.Select(a => a).Include("answers") ;
            return data;
        }


        public Question GetQuestion(int id)
        {
            var data = db.questions.Select(a => a).Include("answers");
            var res= data.Where(a=>a.id==id).FirstOrDefault();
            return res;

        }

        public void update(Question question)
        {
            db.Entry(question).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
        }
    }
}
