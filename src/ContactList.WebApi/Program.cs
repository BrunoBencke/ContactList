using ContactList.Core.Application;
using ContactList.Core.Infrastructure.ApiDbContext.cs;
using ContactList.Core.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<PersonAppService>();
builder.Services.AddScoped<ContactAppService>();
builder.Services.AddScoped<PersonRepository>();
builder.Services.AddScoped<ContactRepository>();

builder.Services.AddDbContext<APIDbContext>(options => options.UseInMemoryDatabase("ContactListDb"));
//In case of SQL Server
//builder.Services.AddDbContext<ContactListAPIDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString")));

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors();

app.MapControllers();

app.Run();
