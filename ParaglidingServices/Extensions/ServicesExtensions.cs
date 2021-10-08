using Microsoft.Extensions.DependencyInjection;
using ParaglidingServices.Infrastructure;
using System.Linq;
using System.Reflection;

namespace ParaglidingServices.Api.Extensions
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddCommands(this IServiceCollection services)
        {
            var assembly = Assembly.GetAssembly(typeof(Command<>));
            var commandTypes = assembly.ExportedTypes.Where(type =>
                type.BaseType != null && (type.BaseType == typeof(Command) || (type.BaseType.IsConstructedGenericType &&
                    (type.BaseType.GetGenericTypeDefinition() == typeof(Command<>) || type.BaseType.GetGenericTypeDefinition() == typeof(Command<,>)))));

            foreach (var commandType in commandTypes)
            {
                services.AddTransient(commandType);
            }

            return services;
        }

        public static IServiceCollection AddQueries(this IServiceCollection services)
        {
            var assembly = Assembly.GetAssembly(typeof(Query<>));
            var queryTypes = assembly.ExportedTypes.Where(type =>
                type.BaseType != null && type.BaseType.IsConstructedGenericType &&
                (type.BaseType.GetGenericTypeDefinition() == typeof(Query<>) || type.BaseType.GetGenericTypeDefinition() == typeof(Query<,>)));

            foreach (var queryType in queryTypes)
            {
                services.AddTransient(queryType);
            }

            return services;
        }
    }


}
