using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineExamAPI.BL;
using OnlineExamAPI.BL.CustomResonse;
using OnlineExamAPI.DAL.Entities;
using System.Security.Claims;
using WebApplication28.BL.VM;

namespace OnlineExamAPI.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    [EnableCors]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> usermanager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly IMapper mapper;

        public AccountController(UserManager<AppUser> usermanager, SignInManager<AppUser> signInManager,IMapper mapper)
        {
            this.usermanager = usermanager;
            this.signInManager = signInManager;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("~/Account/getuser/{id}")]
        public async Task<Response<AppUser>> getuser(string id)
        {
            var user = await usermanager.FindByIdAsync(id);
          if(user == null)
            {
                return new Response<AppUser> { statusCode = 200, message = "No user", result = null };

            }
            else
            {
                return new Response<AppUser> { statusCode = 200, message = "User is exist", result = user };
            }
        }

        [HttpPost]
        [Route("~/Account/signin")]
        public async Task<Response<AppUser>> SignIn([FromBody]SigninVM sign)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await signInManager.PasswordSignInAsync(sign.userName, sign.Password, sign.remember, false);
             
                    var user=await usermanager.FindByNameAsync(sign.userName);
                   

                    if (result.Succeeded)
                    {
                        return new Response<AppUser> { statusCode = 200, message = "sign in successfully", result = user };
                    }
                    else
                    {
                        return new Response<AppUser> { statusCode = 400, message = "invalid username or password", result = null };

                    }

                }
                
                var message = "";
                foreach (var item in ModelState.Values)
                {
                    message += item.Errors.ToString();
                }
                return new Response<AppUser> { statusCode = 400, message = message, result = null };



            }
            catch (Exception e)
            {
                return new Response<AppUser>  { statusCode = 400, message = e.Message, result = null };
            }


        }


        [HttpPost]
        [Route("~/Account/signup")]
        public async Task<Response<AppUser>> SignUp([FromBody]SignupVM signup)
        {
            var message = "";
            try
            {
                if (ModelState.IsValid)
                {
                    var user = new AppUser();
                    user.Email = signup.mail;
                    user.UserName = signup.userName;
                 
                    var result = await usermanager.CreateAsync(user, signup.password);
                    
                    if (result.Succeeded)
                    {
                        var appuser=await usermanager.FindByEmailAsync(user.Email);
                       

                        return new Response<AppUser> { statusCode = 200, message = "sign up successfully", result = appuser};
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            message += error.Description;
                        }
                      
                        
                        return new Response<AppUser> { statusCode = 400, message = message, result = null };

                    }
                }


                var errors = ModelState.Values.SelectMany(e => e.Errors.Select(er => er.ErrorMessage));
             


                return new Response<AppUser> { statusCode = 400, message = errors, result = null };

            }
            catch (Exception e) {
                return new Response<AppUser> { statusCode = 400, message = message, result = null };
            }
        }

        [HttpPost]
        [Route("~/Account/logout")]

        public Response<bool> logout()
        {
            try
            {
                signInManager.SignOutAsync();
                return new Response<bool> { statusCode = 200, message = "log out successfully", result = true };

            }
            catch (Exception e)
            {
                return new Response<bool> { statusCode = 400, message =e.Message, result = false };

            }


        }
    }
}
