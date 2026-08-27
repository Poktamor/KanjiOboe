using KanjiOboe.Server.Interfaces;
using KanjiOboe.Server.Repositories;
using KanjiOboe.Server.Service;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace KanjiOboe.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IDeckRepository, DeckRepository>();
            builder.Services.AddScoped<ICardRepository, CardRepository>();

            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IDeckService, DeckService>();
            builder.Services.AddScoped<ICardService, CardService>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<AppDbContext>();
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/api/user/login";
                    options.LogoutPath = "/api/user/logout";
                    options.ExpireTimeSpan = TimeSpan.FromDays(7);
                });

            builder.Services.AddAuthorization();

            var app = builder.Build();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseDefaultFiles();
            app.UseStaticFiles();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.MapFallbackToFile("/index.html");

            app.Run();
        }
    }
}
