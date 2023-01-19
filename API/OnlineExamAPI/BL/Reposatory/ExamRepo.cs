using Microsoft.EntityFrameworkCore;
using OnlineExamAPI.BL.Interfaces;
using OnlineExamAPI.DAL.Database;
using OnlineExamAPI.DAL.Entities;

namespace OnlineExamAPI.BL.Reposatory
{
    public class ExamRepo : IExam
    {

        private readonly DataBase db;
        public ExamRepo(DataBase db)
        {
            this.db = db;
        }

        public int create(Exam exam)
        {
           var ele= db.Exams.Add(exam); 
            db.SaveChanges();
            return ele.Entity.Id;
        }

        public void delete(int id)
        {
            db.Exams.Remove(db.Exams.Find(id));
            db.SaveChanges();
        }

        public IEnumerable<Exam> getAll()
        {
            var data = db.Exams.Select(a=>a).Include("questions").Include("questions.answers");
            return data;
        }

       
       public  Exam getExam(int id)
        {
            var data = db.Exams.Select(a => a).Include("questions").Include("questions.answers");
            var res = data.Where(a=>a.Id==id).FirstOrDefault();
            return res;

        }

        public void update(Exam exam)
        {
            db.Entry(exam).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
        }
    }
}
