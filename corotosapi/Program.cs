using corotosapi.Models;
using corotosapi.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);


//cors
builder.Services.AddCors();


// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//añadiendo DbContext 
builder.Services.AddDbContext<corotosapiContext>(
        options => options.UseSqlServer("name=ConnectionStrings:DefaultConnection"));

//añadiendo servicios
builder.Services.AddScoped<IServicesProducto, ServicesProducto>();

//Automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseCors(x => x.AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader());

app.UseAuthorization();

app.MapControllers();

app.Run();
