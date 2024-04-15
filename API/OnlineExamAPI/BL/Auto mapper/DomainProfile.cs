using AutoMapper;
using OnlineExamAPI.BL.CustomResonse;
using OnlineExamAPI.BL.VM;
using OnlineExamAPI.DAL.Entities;

namespace OnlineExamAPI.BL.Auto_mapper
{
    public class DomainProfile:Profile
    {
        public DomainProfile()
        {
            CreateMap<Exam, ExamVM>();
            CreateMap<Question, QuestionVM>();
            CreateMap<Answer, AnswerVM>();
            CreateMap<ExamVM, Exam>();
            CreateMap<UserExam, UserExamVM>();
            CreateMap<UserExamVM, UserExam>();
            CreateMap<QuestionVM, Question>();
            CreateMap<AnswerVM, Answer>();
            CreateMap<Answer, CustomAnswer>();
            CreateMap<CustomAnswer, Answer>();
            CreateMap<AnswerVM, CustomAnswer>();
            CreateMap<CustomAnswer, AnswerVM>();
            CreateMap<UserExam, CustomToppers>();
         
        }
    }
}
