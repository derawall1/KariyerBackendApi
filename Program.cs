using AutoMapper;
using KariyerBackendApi.Data;
using KariyerBackendApi.Dtos;
using KariyerBackendApi.MapperProfiles;
using KariyerBackendApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
// GETTING CONNECTION STRING
var defaultConnectionString = string.Empty;

if (builder.Environment.EnvironmentName == "Development")
{
    defaultConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");

}
else
{
    //Use connection string provided at runtime by Heroku.
    var connectionUrl = Environment.GetEnvironmentVariable("DATABASE_URL");

    connectionUrl = connectionUrl?.Replace("postgres://", string.Empty);
    var userPassSide = connectionUrl?.Split("@")[0];
    var hostSide = connectionUrl?.Split("@")[1];

    var user = userPassSide?.Split(":")[0];
    var password = userPassSide?.Split(":")[1];
    var host = hostSide?.Split("/")[0];
    var database = hostSide?.Split("/")[1].Split("?")[0];

    defaultConnectionString = $"Host={host};Database={database};Username={user};Password={password};SSL Mode=Require;Trust Server Certificate=true";
    }


    // Add services to the container.
    {
        builder.Services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);
    builder.Services.AddDbContext<DataContext>(option =>
          option.UseNpgsql(defaultConnectionString)
       );
    //builder.Services.AddDbContext<DataContext>(opt =>
    //{
    //    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
    //});
    builder.Services.AddScoped<IEmployerRepo, EmployerRepo>();
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
}
var app = builder.Build();

// Configure the HTTP request pipeline
{
    //if (app.Environment.IsDevelopment())
    //{
        app.UseSwagger();
        app.UseSwaggerUI();
    //}

   // app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    //using (var scope = app.Services.CreateScope())
    //{
    //    var db = scope.ServiceProvider.GetRequiredService<DataContext>();
    //    var conn = db.Database.GetConnectionString();
    //    db.Database.Migrate();
    //}
}
app.Run();
