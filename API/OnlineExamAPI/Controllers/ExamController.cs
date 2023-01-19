using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineExamAPI.BL;
using OnlineExamAPI.BL.CustomResonse;
using OnlineExamAPI.BL.Interfaces;
using OnlineExamAPI.BL.VM;
using OnlineExamAPI.DAL.Entities;

namespace OnlineExamAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    public class ExamController : ControllerBase
    {
        private readonly IExam _Exam;
        private readonly IMapper mapper;

        public ExamController(IExam _exam, IMapper mapper)
        {
            this._Exam = _exam;
            this.mapper = mapper;
        }
        [HttpGet]

        public Response<IEnumerable<CustomExam>> getAll()
        {
            try
            {
             
                var data = _Exam.getAll();
                var res = mapper.Map<IEnumerable<ExamVM>>(data);
                var message = "data retrived successfully";
                var finalresult = res.Select(a => new CustomExam
                {
                    Id = a.Id,
                    name = a.name,
                    description = a.description,
                    FinalDegree = a.FinalDegree,
                    imgurl = a.imgurl,
                    duration = a.duration,
                    questions = (IEnumerable<CustomQuestion>)a.questions.Select(b => new CustomQuestion
                    {
                        id = b.id,
                        examID = b.examID,
                        text = b.text,
                        CorrectAnswer = b.CorrectAnswer,
                        answers =
                    (IEnumerable<CustomAnswer>)b.answers.Select(c => new CustomAnswer
                    {

                        id = c.id,
                        text = c.text,
                        questionID = c.questionID,


                    })




                    })

                });

                return new Response<IEnumerable<CustomExam>> { statusCode = 200, message = message, result = finalresult };
            }
            catch (Exception ex)
            {

                return new Response<IEnumerable<CustomExam>> { statusCode = 400, message = ex.Message };
            }
        }

        [HttpGet("{id}")]

        public Response<CustomExam> GetById(int id)
        {
            var rand = new Random();
            try
            {
                var data = _Exam.getExam(id);
                var res = mapper.Map<ExamVM>(data);
                var message = "data retrived successfully";
                var finalresult = new CustomExam
                {
                    Id = res.Id,
                    name = res.name,
                    description = res.description,
                    FinalDegree = res.FinalDegree,
                    imgurl = res.imgurl,
                    duration = res.duration,
                    questions = res.questions.OrderBy(c => rand.Next()).Select(b => new CustomQuestion
                    {
                        id = b.id,
                        examID = b.examID,
                        text = b.text,
                        CorrectAnswer = b.CorrectAnswer,
                        answers =
                    b.answers.Select(c => new CustomAnswer
                    {

                        id = c.id,
                        text = c.text,
                        questionID = c.questionID,


                    })




                    })
                };
        
                return new Response<CustomExam>{ statusCode = 200, message = message, result = finalresult };
            }
            catch (Exception ex)
            {

                return new Response<CustomExam> { statusCode = 400, message = ex.Message };
            }

        }

        [HttpPost]

        public Response<CustomExam> create(ExamVM exam)
        { var message = "";
            try
            {
                if (ModelState.IsValid)
                {
                    var data=mapper.Map<Exam>(exam);
                    var examid=_Exam.create(data);
                     message = "exam Created successfuly";
                    var res=mapper.Map<CustomExam>(_Exam.getExam(examid));   
                    return new Response<CustomExam> { statusCode = 200, message = message,result= res };

                }
                message = "";
                foreach (var item in ModelState.Values)
                {
                    message += item.Errors.ToString();
                }
                return new Response<CustomExam> { statusCode = 400, message = message };


            }
            catch (Exception ex)
            {
                return new Response<CustomExam> { statusCode = 400, message = ex.Message  };

            }
        }

        [HttpPut]
        public Response<CustomExam> update(ExamVM exam)
        {
            var message = "";
            try
            {
                if (ModelState.IsValid)
                {
                    var data = mapper.Map<Exam>(exam);
                    _Exam.update(data);
                    message = "exam updated successfuly";
                    var res = mapper.Map<CustomExam>(_Exam.getExam(exam.Id));

                    return new Response<CustomExam> { statusCode = 200, message = message,result=res };

                }
                message = "";
                foreach (var item in ModelState.Values)
                {
                    message += item.Errors.ToString();
                }
                return new Response<CustomExam> { statusCode = 400, message = message };


            }
            catch (Exception ex)
            {
                return new Response<CustomExam> { statusCode = 400, message = ex.Message };
            }
        }

        [HttpDelete("{id}")]
        public Response<CustomExam> delete(int id)
        { var message = "";
            try
            {
                _Exam.delete(id);
                message = "exam Delted successfuly";
                return new Response<CustomExam> { statusCode = 200, message = message };
            }
            catch(Exception ex)
            {
                return new Response<CustomExam> { statusCode = 400, message = ex.Message };
            }
        }
    }
}
