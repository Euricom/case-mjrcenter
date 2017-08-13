using System;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Euricom.MjrCenter.Shared.DI
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddTransient(this IServiceCollection serviceCollection,
             Assembly assembly, Func<Type, bool> predicate)
        {
            Add(serviceCollection, assembly, predicate,
                (s,i,t) => s.AddTransient(i,t));
            return serviceCollection;   
        }

        public static IServiceCollection AddScoped(this IServiceCollection serviceCollection,
             Assembly assembly, Func<Type, bool> predicate)
        {
            Add(serviceCollection, assembly, predicate,
                (s,i,t) => s.AddScoped(i,t));
            return serviceCollection;   
        }

        public static IServiceCollection AddSingleton(this IServiceCollection serviceCollection,
             Assembly assembly, Func<Type, bool> predicate)
        {
            Add(serviceCollection, assembly, predicate,
                (s,i,t) => s.AddSingleton(i,t));
            return serviceCollection;   
        }

        private static void Add(IServiceCollection serviceCollection, 
            Assembly assembly, Func<Type, bool> predicate,
            Action<IServiceCollection, Type, Type> addAction)
        {
            foreach(var type in assembly.GetTypes().Where(predicate))
            {
                var typeInfo = type.GetTypeInfo();
                if(typeInfo.IsGenericType || typeInfo.IsInterface ||
                    typeInfo.IsAbstract || typeInfo.IsValueType) continue;
                    
                var interfaces = type.GetInterfaces();
                foreach (var @interface in interfaces)
                {
                    addAction(serviceCollection, @interface, type);
                }
            }
        } 
    }
}