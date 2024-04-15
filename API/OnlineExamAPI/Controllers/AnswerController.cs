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
    public class AnswerController : ControllerBase
    {

        private readonly IAnswer _answer;
        private readonly IMapper mapper;

        public AnswerController(IAnswer _answer, IMapper mapper)
        {
            this._answer = _answer;
            this.mapper = mapper;
        }
        [HttpGet]

        public Response<IEnumerable<CustomAnswer>> getAll()
        {
            try
            {
                var data = _answer.getAll();
                var res = mapper.Map<IEnumerable<AnswerVM>>(data);
                var message = "data retrived successfully";

                var finalresult = res.Select(a => new CustomAnswer
                {
                    id = a.id,
                    text = a.text,
                   questionID = a.questionID,
                 

                });
                return new Response<IEnumerable<CustomAnswer>> { statusCode = 200, message = message, result = finalresult };
            }
            catch (Exception ex)
            {

                return new Response<IEnumerable<CustomAnswer>> { statusCode = 400, message = ex.Message };
            }
        }

        [HttpGet("{id}")]

        public Response<CustomAnswer> GetById(int id)
        {
            try
            {
                var data = _answer.getAnswer(id);
                var res = mapper.Map<AnswerVM>(data);
                var message = "data retrived successfully";
                //var finalresult = new CustomAnswer
                //{
                //    id = res.id,
                //    text = res.text,
                //    questionID = res.questionID,


                //};


                var finalresult = mapper.Map<CustomAnswer>(res);
               return new Response<CustomAnswer> { statusCode = 200, message = message, result = finalresult };
            }
            catch (Exception ex)
            {

                return new Response<CustomAnswer> { statusCode = 400, message = ex.Message };
            }

        }

        [HttpPost]

        public Response<CustomAnswer> create(AnswerVM answer)
        {
            var message = "";
            try
            {
                if (ModelState.IsValid)
                {
                    var data = mapper.Map<Answer>(answer);
                    var answerid = _answer.create(data);
                    message = "Answer Created successfuly";
                    var res=mapper.Map<CustomAnswer>(_answer.getAnswer(answerid));
                    return new Response<CustomAnswer> { statusCode = 200, message = message, result =res };

                }
                message = "";
                foreach (var item in ModelState.Values)
                {
                    message += item.Errors.ToString();
                }
                return new Response<CustomAnswer> { statusCode = 400, message = message };


            }
            catch (Exception ex)
            {
                return new Response<CustomAnswer> { statusCode = 400, message = ex.Message };

            }
        }

        [HttpPut]
        public Response<CustomAnswer> update(AnswerVM answer)
        {
            var message = "";
            try
            {
                if (ModelState.IsValid)
                {
                    var data = mapper.Map<Answer>(answer);
                    _answer.update(data);
                    message = "answer updated successfuly";
                    var res = mapper.Map<CustomAnswer>(_answer.getAnswer(answer.id));
                    return new Response<CustomAnswer> { statusCode = 200, message = message ,result=res};

                }
                message = "";
                foreach (var item in ModelState.Values)
                {
                    message += item.Errors.ToString();
                }
                return new Response<CustomAnswer> { statusCode = 400, message = message };


            }
            catch (Exception ex)
            {
                return new Response<CustomAnswer> { statusCode = 400, message = ex.Message };
            }
        }

        [HttpDelete("{id}")]
        public Response<CustomAnswer> delete(int id)
        {
            var message = "";
            try
            {
                _answer.delete(id);
                message = "answer Delted successfuly";
                return new Response<CustomAnswer> { statusCode = 200, message = message };
            }
            catch (Exception ex)
            {
                return new Response<CustomAnswer> { statusCode = 400, message = ex.Message };
            }
        }
    }
}
