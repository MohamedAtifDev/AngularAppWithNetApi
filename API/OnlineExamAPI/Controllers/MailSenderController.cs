using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineExamAPI.BL;
using OnlineExamAPI.BL.Services;
using OnlineExamAPI.BL.VM;

namespace OnlineExamAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    public class MailSenderController : ControllerBase
    {
        [HttpPost]
        public async Task<Response<bool>> sendmail([FromBody]sendmailVM sendmail)
        {
            try
            {
               await  mailSender.sendmail(sendmail);
                return new Response<bool> { statusCode=200, message="mail send successfully",result=true };

            }catch(Exception ex)
            {
                return new Response<bool> { statusCode = 400, message = ex.Message, result = false };

            }
        }
    }
}
