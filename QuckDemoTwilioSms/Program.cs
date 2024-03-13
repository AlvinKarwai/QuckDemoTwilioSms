using Microsoft.AspNetCore.Identity;
using QuckDemoTwilioSms.Options;
using QuckDemoTwilioSms.Validator;
using QuckDemoTwilioSms.Wrapper.Classes;
using QuckDemoTwilioSms.Wrapper.Interfaces;

namespace QuckDemoTwilioSms
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.Configure<TwilioOptions>(
            builder.Configuration.GetSection(TwilioOptions.Twilio));
            builder.Services.AddScoped<ITwilioClientWrapper, TwilioClientWrapper>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Sms/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Sms}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
