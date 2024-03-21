using cafe.Domain.Users.entity;
using cafe.infrastructure;
using cafe.Ioc;
using cafe.Utils;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;

var builder = WebApplication.CreateBuilder(args);

/// ********* Auth **********
builder.Services.AddIdentityApiEndpoints<CafeUser>()
   .AddEntityFrameworkStores<CafeDbContext>();

builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });

    options.OperationFilter<SecurityRequirementsOperationFilter>();
});

/// ********* IOC Container **********
builder.Services.RegisterServices(builder.Configuration);


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
app.MapIdentityApi<CafeUser>();
app.UseAuthentication();
app.UseAuthorization();

//app.ConfigureExceptionHandler();
app.MapControllers();

app.Run();
