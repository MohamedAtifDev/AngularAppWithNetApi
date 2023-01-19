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
    public class QuestionController : ControllerBase
    {

        private readonly IQuestion _question;
        private readonly IMapper mapper;

        public QuestionController(IQuestion _question, IMapper mapper)
        {
           this._question = _question;
            this.mapper = mapper;
        }
        [HttpGet]

        public Response<IEnumerable<CustomQuestion>> getAll()
        {
            try
            {
                var data = _question.getAll();
                var res = mapper.Map<IEnumerable<QuestionVM>>(data);
                var message = "data retrived successfully";
                var finalresult = res.Select(a => new CustomQuestion
                {
                  id = a.id,
                  text = a.text,
                  CorrectAnswer=a.CorrectAnswer,
                  examID=a.examID,

                    answers = (IEnumerable<CustomAnswer>)a.answers.Select(b => new CustomAnswer
                    {
                        id = b.id,
                        questionID = b.questionID,
                        text = b.text,
                       
                  



                    })

                });
                return new Response<IEnumerable<CustomQuestion>> { statusCode = 200, message = message, result =finalresult  };
            }
            catch (Exception ex)
            {

                return new Response<IEnumerable<CustomQuestion>> { statusCode = 400, message = ex.Message };
            }
        }

        [HttpGet("{id}")]

        public Response<CustomQuestion> GetById(int id)
        {
            try
            {
                var data = _question.GetQuestion(id);
                var res = mapper.Map<QuestionVM>(data);
                var message = "data retrived successfully";
                var finalresult = new CustomQuestion
                {
id=res.id,
text=res.text,
CorrectAnswer=res.CorrectAnswer,
examID=res.examID,
                    answers = res.answers.Select(v => new CustomAnswer {id=v.id,text=v.text,questionID=v.questionID})
                };

                return new Response<CustomQuestion> { statusCode = 200, message = message, result = finalresult };
            }
            catch (Exception ex)
            {

                return new Response<CustomQuestion> { statusCode = 400, message = ex.Message };
            }

        }

        [HttpPost]

        public Response<CustomQuestion> create(QuestionVM question)
        {
            var message = "";
            try
            {
                if (ModelState.IsValid)
                {
                    var data = mapper.Map<Question>(question);
                    var questionid = _question.create(data);
                    message = "exam Created successfuly";
                    var res=mapper.Map<CustomQuestion>(_question.GetQuestion(questionid));
                    return new Response<CustomQuestion> { statusCode = 200, message = message, result = res };

                }
                message = "";
                foreach (var item in ModelState.Values)
                {
                    message += item.Errors.ToString();
                }
                return new Response<CustomQuestion> { statusCode = 400, message = message };


            }
            catch (Exception ex)
            {
                return new Response<CustomQuestion> { statusCode = 400, message = ex.Message };

            }
        }

        [HttpPut]
        public Response<CustomQuestion> update(QuestionVM question)
        {
            var message = "";
            try
            {
                if (ModelState.IsValid)
                {
                    var data = mapper.Map<Question>(question);
                    _question.update(data);
                    message = "exam updated successfuly";
                    var res = mapper.Map<CustomQuestion>(_question.GetQuestion(question.id));
                    return new Response<CustomQuestion> { statusCode = 200, message = message,result=res };

                }
                message = "";
                foreach (var item in ModelState.Values)
                {
                    message += item.Errors.ToString();
                }
                return new Response<CustomQuestion> { statusCode = 400, message = message };


            }
            catch (Exception ex)
            {
                return new Response<CustomQuestion> { statusCode = 400, message = ex.Message };
            }
        }

        [HttpDelete("{id}")]
        public Response<CustomQuestion> delete(int id)
        {
            var message = "";
            try
            {
                _question.delete(id);
                message = "exam Delted successfuly";
                return new Response<CustomQuestion> { statusCode = 200, message = message };
            }
            catch (Exception ex)
            {
                return new Response<CustomQuestion> { statusCode = 400, message = ex.Message };
            }
        }
    }
}
