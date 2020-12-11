using Dapper.FluentMap;
using employers.application.Interfaces.Departament;
using employers.application.Interfaces.Empregado;
using employers.application.Interfaces.UseCases.Departament;
using employers.application.UseCases.Departament;
using employers.application.UseCases.Employers;
using employers.domain.Interfaces.Repositories.Departament;
using employers.domain.Interfaces.Repositories.Employers;
using employers.infrastructure.Mapping;
using employers.infrastructure.Repositories.Departament;
using employers.infrastructure.Repositories.Employer;
using Microsoft.Extensions.DependencyInjection;

namespace employers.infrastructure.Ioc
{
    public static class IOC
    {
        public static void IocConfiguration(this IServiceCollection services)
        {
            // UseCases 
            services.AddTransient<IGetDepartamentUseCaseAsync, GetDepartamentUseCaseAsync>();
            services.AddTransient<IGetDepartamentByIdUseCaseAsync, GetDepartamentByIdUseCaseAsync>();
            services.AddTransient<IGetEmployerUseCaseAsync, GetEmployerUseCaseAsync>();
            services.AddTransient<IGetEmployerByIdUseCaseAsync, GetEmployerByIdUseCaseAsync>();
            services.AddTransient<IInsertDepartmentUseCaseAsync, InsertDepartmentUseCaseAsync>();
            services.AddTransient<IInsertEmployerUseCaseAsync, InsertEmployerUseCaseAsync>();
            services.AddTransient<IDeleteEmployerUseCaseAsync, DeleteEmployerUseCaseAsync>();

            // Repositories
            services.AddTransient<IDepartmentRepository, DepartmentRepository>();
            services.AddTransient<IEmployerRepository, EmployerRepository>();
        }

        public static void Rister()
        {
            FluentMapper.Initialize( config => 
            {
                config.AddMap(new DepartamentMap());
                config.AddMap(new EmployerMap());
            });
        }
    }
}
