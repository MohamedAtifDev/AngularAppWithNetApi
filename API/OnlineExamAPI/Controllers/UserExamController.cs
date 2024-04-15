using AutoMapper;
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
    public class UserExamController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IUserExam userexam;

        public UserExamController(IMapper mapper, IUserExam userexam)
        {
            this.mapper = mapper;
            this.userexam = userexam;
        }

        [HttpGet]
        public Response<IEnumerable<UserExamVM>> getAll()
        {
            try
            {
                var data = userexam.getAll();
                var res = mapper.Map<IEnumerable<UserExamVM>>(data);
                return new Response<IEnumerable<UserExamVM>> { statusCode = 200, message = "data retrieved successfully", result = res };

            }
            catch (Exception ex)
            {
                return new Response<IEnumerable<UserExamVM>> { statusCode = 200, message = ex.Message, result = null };

            }
        }

        [HttpGet("{id}")]
        public Response<IEnumerable<UserExamVM>> getbyid(string id)
        {
            try
            {
                var data = userexam.getById(id);
                var res = mapper.Map<IEnumerable<UserExamVM>>(data);
                return new Response<IEnumerable<UserExamVM>> { statusCode = 200, message = "data retrieved successfully", result = res };

            }
            catch (Exception ex)
            {
                return new Response<IEnumerable<UserExamVM>> { statusCode = 200, message = ex.Message, result = null };

            }
        }


        [HttpPost]
        public Response<UserExamVM> create([FromBody]UserExamVM ex)
        {
            try
            {
                var res = mapper.Map<UserExam>(ex);
                userexam.create(res);
               
                return new Response<UserExamVM> { statusCode = 200, message = "data retrieved successfully", result = ex };

            }
            catch (Exception excep)
            {
                return new Response<UserExamVM> { statusCode = 200, message = excep.Message, result = null };

            }
        }
        [HttpGet("/getToppers/{examid}")]
        public Response<IEnumerable<CustomToppers>> getToppers(int examid)
        {
            try
            {
var data=userexam.getToppers(examid).OrderByDescending(a=>a.degree).ThenByDescending(a=>a.Duration).AsEnumerable();
                foreach (var item in data)
                {
                    item.user.userExams = null;
                }
                var res=mapper.Map<IEnumerable<CustomToppers>>(data);

                return new Response<IEnumerable<CustomToppers>> { statusCode = 200, message = "data retrieved successfully", result = res };
            }catch (Exception excep)
            {
                return new Response<IEnumerable<CustomToppers>> { statusCode = 400, message = excep.Message, result = null };

            }
        }


    }
}