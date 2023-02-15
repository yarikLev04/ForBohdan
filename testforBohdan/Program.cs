using Microsoft.EntityFrameworkCore;
using Serilog;
using testforBohdan;
using testforBohdan.Middlewares;
using testforBohdan.Abstractions.IRepository;
using testforBohdat.Data;
using testforBohdat.Data.Repository;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.Console()
    .CreateLogger();

builder.Logging.ClearProviders();

builder.Logging.AddSerilog();

builder.Services.AddDbContext<AppDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultSQLConnection"));
});

builder.Services.AddScoped<INoteService, NoteService>();
builder.Services.AddAutoMapper(typeof(MapperConfig));
builder.Services.AddScoped<ExceptionMiddleware>();

builder.Services.AddControllers();

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

app.UseMiddleware<ExceptionMiddleware>();

app.MapControllers();

app.Run();