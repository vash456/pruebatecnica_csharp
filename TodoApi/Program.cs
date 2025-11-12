using Microsoft.EntityFrameworkCore;
using TodoApi.Data;
using TodoApi.Services;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Todo API", Version = "v1" });
});

// In-Memory EF for test / demo
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<TaskDbContext>(opt =>
    opt.UseSqlServer(connectionString));


// Register app services
builder.Services.AddScoped<ITaskService, TaskService>();

var app = builder.Build();

// Seed sample data
using(var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<TaskDbContext>();
    if(!db.Tasks.Any())
    {
        db.Tasks.AddRange(new []
        {
            new TodoApi.Models.TaskItem { Title = "Comprar leche" },
            new TodoApi.Models.TaskItem { Title = "Estudiar para la entrevista" },
            new TodoApi.Models.TaskItem { Title = "Llamar a mamá" }
        });
        db.SaveChanges();
    }
}

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
