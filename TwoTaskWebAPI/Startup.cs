

using TwoTaskLibrary.Application;
using TwoTaskLibrary.Internal.DataAccess;

namespace TwoTaskWebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ISqlDataAccess, SqlDataAccess>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IGroupRepository, GroupRepository>();
            services.AddScoped<IListsCategoryRepository, ListsCategoryRepository>();
            services.AddScoped<ILocationRepository, LocationRepository>();
            services.AddScoped<IRegionRepository, RegionRepository>();
            services.AddScoped<ITodoTaskRepository, TodoTaskRepository>();
            services.AddScoped<ITodoTasksListRepository, TodoTasksListRepository>();
        }

    }
}
