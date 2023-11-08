
using DWAApi.Data;
using DWAApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace WBAAPI
{
    public class Program
    {
        private readonly IServiceProvider _serviceProvider;
        public Program(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public static void Main(string[] args)
        {
            
       

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddDbContext<UserContext>();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddAuthorization();
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = AuthOptions.ISSUER,
                        ValidateAudience = true,
                        ValidAudience = AuthOptions.AUDIENCE,
                        ValidateLifetime = true,
                        IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
                        ValidateIssuerSigningKey = true,
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

            //app.UseDefaultFiles();
            //app.UseStaticFiles();

            app.MapPost("/login", (User loginData, HttpContext httpContext) =>
            {
                // находим пользователя 
           
                UserContext _userContext = httpContext.RequestServices.GetRequiredService<UserContext>();
                
                User? user = _userContext.Users.FirstOrDefault(p => (p.Login == loginData.Login));
                if (user is null) return Results.Unauthorized();
                if (!BCrypt.Net.BCrypt.Verify(loginData.Password, user.Password)) return Results.Unauthorized();
                var claims = new List<Claim> { new Claim(ClaimTypes.Name, user.Login) };
                // создаем JWT-токен
                var jwt = new JwtSecurityToken(
                        issuer: AuthOptions.ISSUER,
                        audience: AuthOptions.AUDIENCE,
                        claims: claims,
                        expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(2)),
                        signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
                var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

                // формируем ответ
                var response = new
                {
                    access_token = encodedJwt,
                    username = user.Login
                };

                return Results.Json(response);
            });
            app.UseAuthentication();

            app.UseAuthorization();

            //app.Map("/hello", [Authorize] () => "Hello World!");
            //app.Map("/", () => "Home Page");
            /* app.Map("/login/{username}", (string username) =>
            {
                var claims = new List<Claim> { new Claim(ClaimTypes.Name, username) };
                var jwt = new JwtSecurityToken(
                        issuer: AuthOptions.ISSUER,
                        audience: AuthOptions.AUDIENCE,
                        claims: claims,
                        expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(2)), // время действия 2 минуты
                        signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

                return new JwtSecurityTokenHandler().WriteToken(jwt);
            });*/
            app.MapControllers();

            app.Run();
        }

        public class AuthOptions
        {
            public const string ISSUER = "MyAuthServer";
            public const string AUDIENCE = "MyAuthClient";
            const string KEY = "mysupersecret_secretkey!123";
            public static SymmetricSecurityKey GetSymmetricSecurityKey() =>
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
        }
         
    }
}
