using Contracts;
using Domain.Models.ErrorModel;
using Domain.Models.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Repository;
using Service;
using Service.Contracts;
using Service.DataShaping;
using Shared.DataTransferObjects;
using WebApplicationOnion.ActionFilters;
using WebApplicationOnion.Extensions;
using WebApplicationOnion.Utility;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

NewtonsoftJsonPatchInputFormatter GetJsonPatchInputFormatter() =>
new ServiceCollection().AddLogging().AddMvc().AddNewtonsoftJson()
.Services.BuildServiceProvider()
.GetRequiredService<IOptions<MvcOptions>>().Value.InputFormatters
.OfType<NewtonsoftJsonPatchInputFormatter>().First();


builder.Services.AddControllers(config => {
    config.RespectBrowserAcceptHeader = true;
    config.ReturnHttpNotAcceptable = true;
    config.InputFormatters.Insert(0, GetJsonPatchInputFormatter());
}).AddXmlDataContractSerializerFormatters();

builder.Services.AddScoped<IDataShaper<EmployeeDto>, DataShaper<EmployeeDto>>();
builder.Services.AddCustomMediaTypes();
builder.Services.AddScoped<ValidateMediaTypeAttribute>();
builder.Services.AddScoped<IEmployeeLinks, EmployeeLinks>();


//builder.Services.Configure<ApiBehaviorOptions>(opt =>
//{
//    opt.SuppressModelStateInvalidFilter = true;
//});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.ConfigureSqlService(builder.Configuration);
builder.Services.ConfigureRepositoryService();
builder.Services.ConfigureServiceManager();
builder.Services.AddScoped<ValidationFilterAttribute>();
builder.Services.ConfigureVersioning();
builder.Services.AddResponseCaching();
builder.Services.ConfigureHttpCacheHeader();
builder.Services.AddAuthentication();
builder.Services.ConfigureIdentity();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//var logger = app.Services.GetRequiredService<ILogger>();

app.ConfigureExceptionHandler();

app.UseResponseCaching();
app.UseHttpCacheHeaders();
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
