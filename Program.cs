using AutoMapper;
using KariyerBackendApi.Data;
using KariyerBackendApi.Dtos;
using KariyerBackendApi.MapperProfiles;
using KariyerBackendApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);

builder.Services.AddDbContext<DataContext>(opt =>
{
    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddScoped<IEmployerRepo,EmployerRepo>();
builder.Services.AddScoped<IJobRepo, JobRepo>();

builder.Services.AddControllers()
     .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles)
     .ConfigureApiBehaviorOptions(options =>
     {
            //options.SuppressModelStateInvalidFilter = true;
         options.InvalidModelStateResponseFactory = actionContext =>
         {
             var modelState = actionContext.ModelState.Values;
             var errors = new List<ResponseDto>();
             foreach (var state in modelState)
             {

                 foreach (var error in state.Errors)
                 {

                     errors.Add(new ResponseDto() { Message = "", Error = error.ErrorMessage });
                 }
             }
             return new BadRequestObjectResult(errors);
         };
     });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<DataContext>();
    db.Database.Migrate();
}

app.Run();
