using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Infrastructure;
using SchoolManagementSystem.Models;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<SchoolManagementSystem.Infrastructure.SchoolManagementDbContext>
(
    options=>
       options.UseSqlServer(
           connectionString: "server=(local);database=SchoolManagementDb;integrated security=sspi"
       )
);
builder.Services.AddScoped<ICRUDRepository<ClassRoom, string>,ClassRoomRepository>();
builder.Services.AddScoped<ICRUDRepository<Staffclassification, int>,StaffClassificationRepository>();
builder.Services.AddScoped<ICRUDRepository<StudentDetail, int>,StudentDetailRepository>();
builder.Services.AddScoped<ICRUDRepository<TeachingStaffDetail, int>,TeachingStaffDetailRepository>();
builder.Services.AddScoped<ICRUDRepository<TimeTable, string>,TimeTableRepository>();

builder.Services.AddControllers();
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

app.UseAuthorization();

app.MapControllers();

app.Run();
