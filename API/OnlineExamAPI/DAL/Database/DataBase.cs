using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineExamAPI.DAL.Entities;

namespace OnlineExamAPI.DAL.Database
{
    public class DataBase:IdentityDbContext<AppUser>
    {
        public DataBase(DbContextOptions<DataBase> opt):base(opt)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserExam>().HasKey(a => new { a.AppUserID, a.ExamID });
            modelBuilder.Entity<IdentityUserLogin<string>>().HasKey(a => a.UserId);
            modelBuilder.Entity<IdentityUserRole<string>>().HasKey(a => new { a.UserId, a.RoleId });
            modelBuilder.Entity<IdentityUserToken<string>>().HasNoKey();
        }

        public DbSet<Exam> Exams { get; set;}
        public DbSet<Question> questions { get; set;}
        public DbSet<Answer> answers { get; set;}
        public DbSet<UserExam>userExams { get; set;}
    }
}
