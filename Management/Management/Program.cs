using Management.Database;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("school", x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});
#endregion

#region DATABASE
builder.Services.AddDbContext<SchoolDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("sql"));
});

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("school");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
