using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TrainingManagementService.Context;
using TrainingManagementService.Entities;
using static ITHelpDesk.Domain.Entities.IdentityCustom;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TMSDbContext>(options =>
               options.UseSqlServer(builder.Configuration.GetConnectionString("TrainingManagementSystemConnection")));

builder.Services.AddIdentity<Employee, Role>(opt =>
{
    opt.Password.RequiredLength = 7;
    opt.Password.RequireDigit = false;
    opt.Password.RequireUppercase = false;
    opt.User.RequireUniqueEmail = true;
})
 .AddEntityFrameworkStores<TMSDbContext>()
 .AddDefaultTokenProviders();

// Add services to the container.

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
