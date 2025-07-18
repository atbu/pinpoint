using Microsoft.Extensions.DependencyInjection;
using Pinpoint.Data.Helpers;
using Pinpoint.Data.Repositories.WorkItem;
using Pinpoint.Data.Services;

namespace Pinpoint.Data.Utilities;

public static class DependencyInjection
{
    public static IServiceCollection InjectDependencies(this IServiceCollection services)
    {
        services.AddScoped<ISaveChangesHelper, SaveChangesHelper>();
        
        services.AddScoped<IWorkItemRepository, WorkItemRepository>();

        services.AddScoped<ICreateWorkItemService, CreateWorkItemService>();
        services.AddScoped<IReadWorkItemService, ReadWorkItemService>();
        services.AddScoped<IUpdateWorkItemService, UpdateWorkItemService>();
        services.AddScoped<IDeleteWorkItemService, DeleteWorkItemService>();

        return services;
    }
}