﻿using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
using Dapper.FluentMap;
using employers.application.Interfaces.Departament;
using employers.application.Interfaces.Empregado;
using employers.application.Interfaces.ExportReport;
using employers.application.Interfaces.Occupation;
using employers.application.Interfaces.UseCases.Departament;
using employers.application.Interfaces.UserAuth;
using employers.application.Notifications;
using employers.application.UseCases.Departament;
using employers.application.UseCases.Employers;
using employers.application.UseCases.ExportReport;
using employers.application.UseCases.Occupation;
using employers.application.UseCases.Token;
using employers.application.UseCases.UserAuth;
using employers.domain.Interfaces.Repositories;
using employers.domain.Interfaces.Repositories.Departament;
using employers.domain.Interfaces.Repositories.Employers;
using employers.domain.Interfaces.Repositories.Occupation;
using employers.domain.Interfaces.Repositories.UserAuth;
using employers.domain.Token;
using employers.infrastructure.Mapping;
using employers.infrastructure.Repositories;
using employers.infrastructure.Repositories.Departament;
using employers.infrastructure.Repositories.Employer;
using employers.infrastructure.Repositories.Occupation;
using employers.infrastructure.Repositories.UserAuth;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace employers.infrastructure.Ioc
{
    [ExcludeFromCodeCoverage]
    public static class IOC
    {
        public static void IocConfiguration(this IServiceCollection services,
                                                 IConfiguration configuration)
        {
            // UseCases 
            services.AddTransient<IGetDepartamentUseCaseAsync, GetDepartamentUseCaseAsync>();
            services.AddTransient<IGetDepartamentByIdUseCaseAsync, GetDepartamentByIdUseCaseAsync>();
            services.AddTransient<IGetEmployerUseCaseAsync, GetEmployerUseCaseAsync>();
            services.AddTransient<IGetEmployerByIdUseCaseAsync, GetEmployerByIdUseCaseAsync>();
            services.AddTransient<IInsertDepartmentUseCaseAsync, InsertDepartmentUseCaseAsync>();
            services.AddTransient<IInsertEmployerUseCaseAsync, InsertEmployerUseCaseAsync>();
            services.AddTransient<IDeleteEmployerUseCaseAsync, DeleteEmployerUseCaseAsync>();
            services.AddTransient<IUpdateEmployerUseCaseAsync, UpdateEmployerUseCaseAsync>();
            services.AddTransient<IUserAuthUseCaseAsync, UserAuthUseCaseAsync>();
            services.AddTransient<IUpdateOccupationUseCaseAsync, UpdateOccupationUseCaseAsync>();
            services.AddTransient<IGetOccupationUseCaseAsync, GetOccupationUseCaseAsync>();
            services.AddTransient<IInsertOccupationUseCaseAsync, InsertOccupationUseCaseAsync>();
            services.AddTransient<IUserAuthRefreshTokenUseCaseAsync, UserAuthRefreshTokenUseCaseAsync>();
            services.AddTransient<ICreateUserUseCaseAsync, CreateUserUseCaseAsync>();   

            // Repositories
            services.AddTransient<IDepartmentRepository, DepartmentRepository>();
            services.AddTransient<IEmployerRepository, EmployerRepository>();
            services.AddTransient<IUserAuthRepository, UserAuthRepository>();
            services.AddTransient<IOccupationRepository, OccupationRepository>();
            services.AddTransient<IUserRepository, UserRepository>();

            // DbConfig
            services.AddScoped<IDbConnection>(db => new SqlConnection(configuration.GetConnectionString("sqlConnect")));
            services.AddScoped(s =>
            {
                IDbConnection connection = s.GetRequiredService<IDbConnection>();
                connection.Open();
                return connection.BeginTransaction();
            });

            // Token
            services.AddTransient<ITokenGenerate, TokenGenerate>();

            //Notification
            services.AddSingleton<INotificationMessages,NotificationMessages>();

            //Export File
            services.AddTransient<IExportCsvAsync, ExportCsvAsync>();

            // Unit of Work
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }

        public static void Rister()
        {
            FluentMapper.Initialize( config => 
            {
                config.AddMap(new DepartmentMap());
                config.AddMap(new EmployeeMap());
                config.AddMap(new OccupationEntityMap());
                config.AddMap(new UserEntityMap());
            });
        }
    }
}
