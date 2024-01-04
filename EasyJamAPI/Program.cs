using EasyJamAPI.Configurations;
using EasyJamAPI.Services;
using EasyJamBLL.Services;
using EasyJamDAL.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<EasyJamContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<MusicianService>();
builder.Services.AddScoped<JamService>();
builder.Services.AddScoped<AdminService>();
builder.Services.AddScoped<LoginService>();



JwtConfiguration jwtConfiguration = builder.Configuration.GetSection("JwtSettings").Get<JwtConfiguration>();
builder.Services.AddSingleton(jwtConfiguration);
builder.Services.AddScoped<JwtSecurityTokenHandler>();
builder.Services.AddScoped<JwtService>();

builder.Services.AddAuthorization(options =>
{
    var defaultAuthorizationPolicyBuilder = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme);
    defaultAuthorizationPolicyBuilder = defaultAuthorizationPolicyBuilder.RequireAuthenticatedUser();
    options.DefaultPolicy = defaultAuthorizationPolicyBuilder.Build();

});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(
        JwtBearerDefaults.AuthenticationScheme,
        options => options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = jwtConfiguration.ValidateIssuer,
            ValidateAudience = jwtConfiguration.ValidateAudience,
            ValidateLifetime = jwtConfiguration.ValidateLifeTime,
            ValidIssuer = jwtConfiguration.Issuer,
            ValidAudience = jwtConfiguration.Audience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfiguration.Signature))
        }
    );


builder.Services.AddCors(b =>
{
    b.AddDefaultPolicy(options =>
    {
        options.AllowAnyMethod();
        options.AllowAnyOrigin();
        options.AllowAnyHeader();

    });
});

var app = builder.Build();

app.UseDeveloperExceptionPage();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();
    
app.UseHttpsRedirection();

app.UseAuthorization();
app.Map("/site", angus => { angus.UseStaticFiles(); });
app.MapControllers();

app.Run();
