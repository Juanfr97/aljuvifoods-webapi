using aljuvifoods_webapi.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
//builder.Services.AddDbContext<ApplicationDbContext>(opt => opt.UseNpgsql(builder.Configuration.GetConnectionString("defaultConnection")));
builder.Services.AddCors(options =>
{
    options.AddPolicy(
      "CorsPolicy",
      builder => builder.WithOrigins(new string[2] { "http://localhost:4200", "http://localhost:52921" })
      .AllowAnyMethod()
      .AllowAnyHeader()
      .AllowCredentials());
});

builder.Services.AddDbContext<ApplicationDbContext>(opt => 

    {
        opt.UseSqlServer(builder.Configuration.GetConnectionString("defaultConnection"));
    });
var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors("CorsPolicy");
app.MapControllers();

app.Run();
