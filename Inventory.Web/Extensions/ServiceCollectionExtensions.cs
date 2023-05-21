using Inventory.Application.Interfaces.Repositories;
using Inventory.Persistence.DbContexts;
using Inventory.Persistence.Implementation;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Web.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddWebPersistenceLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext(configuration);
            services.AddRepositories();
        }
        public static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<ApplicationDbContext>(options =>
               options.UseSqlServer(connectionString,
                   builder => builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
        }
        private static void AddRepositories(this IServiceCollection services)
        {
            services
                .AddTransient(typeof(IUnitOfWork), typeof(UnitOfWork))
                .AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>))
                .AddTransient<IStoreRepository, StoreRepository>()
                .AddTransient<IRackRepository, RackRepository>()
                .AddTransient<IElementRepository, ElementRepository>();
        }
    }
}
