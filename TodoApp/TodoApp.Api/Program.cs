using Microsoft.EntityFrameworkCore;
using TodoApp.Core.Interfaces;
using TodoApp.DAL.Data;
using TodoApp.DAL.Repositories;
using TodoApp.BLL.Mappings;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<TodoAppDbContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("TodoAppConnectionString")));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ITaskRepository, TaskRepository>();
builder.Services.AddAutoMapper(options =>
{
    options.AddProfile<MappingProfile>();
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.MapControllers();


app.Run();


