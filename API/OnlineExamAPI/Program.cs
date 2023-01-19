using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OnlineExamAPI.BL.Auto_mapper;
using OnlineExamAPI.BL.Interfaces;
using OnlineExamAPI.BL.Reposatory;
using OnlineExamAPI.DAL.Database;
using OnlineExamAPI.DAL.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()

    .AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContextPool<DataBase>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("OnlineExam")));
builder.Services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<DataBase>()


      .AddTokenProvider<DataProtectorTokenProvider<AppUser>>(TokenOptions.DefaultProvider);
builder.Services.AddScoped<IExam,ExamRepo>();
builder.Services.AddScoped<IAnswer, AnswerRepo>();
builder.Services.AddScoped<IQuestion, QuestionRepo>();
builder.Services.AddScoped<IUserExam, UserExamRepo>();
builder.Services.AddAutoMapper(opt => opt.AddProfile(new DomainProfile()));
builder.Services.AddCors(opt =>
{
    opt.AddDefaultPolicy(opt =>
    {
        opt.AllowAnyHeader().AllowAnyHeader().AllowAnyOrigin();
    });
});





builder.Services.Configure<IdentityOptions>(options =>
{
    // Default Password settings.
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 5;
    options.Password.RequiredUniqueChars = 1;

});
        



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
