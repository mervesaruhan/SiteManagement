using Microsoft.EntityFrameworkCore;
using SiteManagement.MiddleWare;
using SiteManagement.Models;
using SiteManagement.Models.UnitOfWork;
using SiteManagement.MiddleWare;
using SiteManagement.Extensions;
using SiteManagement.Models.AdminServices;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"));
});

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddUserDlContainer();

builder.Services.AddPaymentDlContainer();

builder.Services.AddInvoicesDlContainer();

builder.Services.AddApartmentsDlContainer();



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

var app = builder.Build();


//app.UseMiddleware<MiddleWareExt>();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMiddleware<JwtAuthenticationMiddleware>();
app.UseMiddleware<AuthorizationMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();
