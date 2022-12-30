using DentalClinic.Users.Api;
using DentalClinic.Shared.Core;
using FluentValidation.AspNetCore;
using DentalClinic.Shared.Core.Exceptions;
using DentalClinic.VisitSchedule.API;
using DentalClinic.Shared.Infrastructure;
using DentalClinic.MedicalRecords.Api;

namespace DentalClinicWebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var configuration = builder.Configuration;
            builder.Services.AddErrorHandling();
            builder.Services.AddFluentValidationAutoValidation();
            builder.Services.AddInfrastructure(configuration);
            builder.Services.AddSharedModule();
            builder.Services.AddUsersModule(configuration);
            builder.Services.AddVisitScheduleModule();
            builder.Services.AddMedicalRecordsModule();
            builder.Services.AddControllers();
            builder.Services.AddSwaggerGen();
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                {
                    builder.AllowAnyOrigin();
                });
            });
            
            var app = builder.Build();

            if (app.Environment.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.jeson", "Dental Clinic API");
            });
            app.UseCors("CorsPolicy");
            app.UseErrorHandling();
            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseSharedModule();
            app.UseUsersModule();
            app.UseVisitScheduleModule();
            app.UseMedicalRecordsModule();
            app.MapControllers();
            app.Run();
        }
    }
}