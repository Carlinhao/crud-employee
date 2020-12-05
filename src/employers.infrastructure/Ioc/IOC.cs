using Dapper.FluentMap;
using employers.application.Interfaces.Departament;
using employers.application.Interfaces.UseCases.Departament;
using employers.application.UseCases.Departament;
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

            // Repositories
            services.AddTransient<IDepartamentRepository, DepartamentRepository>();
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
