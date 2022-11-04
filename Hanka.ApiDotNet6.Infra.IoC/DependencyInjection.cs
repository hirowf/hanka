
using Hanka.ApiDotNet6.Application.Mappings;
using Hanka.ApiDotNet6.Application.Services;
using Hanka.ApiDotNet6.Application.Services.Interfaces;
using Hanka.ApiDotNet6.Domain.Repositories;
using Hanka.ApiDotNet6.Infra.Data.Context;
using Hanka.ApiDotNet6.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Hanka.ApiDotNet6.Infra.IoC
{
  public static class DependencyInjection
  {
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
      services.AddDbContext<ApplicationDbContext>(options => 
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

      services.AddScoped<IPersonRepository, PersonRepository>();
      return services;
    }

    public static IServiceCollection AddService(this IServiceCollection services, IConfiguration configuration)
    {
      services.AddAutoMapper(typeof(DomainToDtoMapping));
      services.AddScoped<IPersonService, PersonService>();
      return services;
    }
  }
}


