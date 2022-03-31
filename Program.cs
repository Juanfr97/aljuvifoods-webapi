
using aljuvifoods_webapi.DAO;
using aljuvifoods_webapi.Repository;
using aljuvifoods_webapi.Services.Contracts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy(
                  "CorsPolicy",
                  builder => builder.WithOrigins(new string[2] { "http://localhost:4200", "http://localhost:52921" })
                  .AllowAnyMethod()
                  .AllowAnyHeader()
                  .AllowCredentials());


});
builder.Services.AddMvc(m => m.EnableEndpointRouting = false);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
//builder.Services.AddDbContext<ApplicationDbContext>(opt => opt.UseNpgsql(builder.Configuration.GetConnectionString("defaultConnection")));


builder.Services.AddDbContext<ApplicationDbContext>(opt => 
    {
        opt.UseSqlServer(builder.Configuration.GetConnectionString("defaultConnection")).EnableSensitiveDataLogging();
    });

<<<<<<< HEAD
builder.Services.AddScoped<IMailDao, UserDao>();
=======
builder.Services.AddScoped<IMailDao, UserMailDao>();
>>>>>>> 472945196e9027f2fbb455d22a313e79d309d38d

var app = builder.Build();
app.UseCors("CorsPolicy");
// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseMvc();
app.UseAuthorization();

app.MapControllers();

app.Run();
