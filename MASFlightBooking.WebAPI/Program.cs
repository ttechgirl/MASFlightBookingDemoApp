using MASFlightBooking.DataAccess.Services.Interfaces;
using MASFlightBooking.DataAccess.Services.Repositories;
using MASFlightBooking.Domain.Context;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using static MASFlightBooking.Domain.Models.UserIdentityModel;
using System.Configuration;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

//Add services to the container.

builder.Services.AddScoped<IMASFlightInterface, MASFlightRepository>();
builder.Services.AddScoped<IPaymentInterface, PaymentRepository>();
builder.Services.AddScoped<IUserInterface, UserRepository>();
builder.Services.AddDbContext<MASFlightDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectToDB")));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opt => {

    opt.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "MASFlightBooking UI",
        Description = "Displaying Swagger UI example"

    });
});

builder.Services.AddIdentity<AppUsers, AppRoles>(opt =>
{
    opt.Password.RequireDigit = true;
    opt.Password.RequireUppercase = true;
    opt.Password.RequireLowercase = true;
    opt.Password.RequiredLength = 8;
    opt.Password.RequiredUniqueChars = 1;
    opt.SignIn.RequireConfirmedEmail = true;
})
   .AddEntityFrameworkStores<MASFlightDbContext>()
   .AddDefaultTokenProviders()
   .AddSignInManager<SignInManager<AppUsers>>();

builder.Services.AddAuthentication(opts =>
{
    opts.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opts.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    opts.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
    //adding jwt bearer
    .AddJwtBearer(options =>
    {
        options.SaveToken = true;
        options.RequireHttpsMetadata = false;
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidAudience = builder.Configuration["JWT:ValidAudience"],
            ValidIssuer =builder.Configuration["JWT:ValidIssuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"])),
            ValidateLifetime = true
        };

    });


var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
