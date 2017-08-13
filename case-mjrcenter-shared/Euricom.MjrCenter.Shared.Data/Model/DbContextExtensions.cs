using System;
using System.Reflection;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Euricom.MjrCenter.Shared.Data.Model
{
    public static class DbContextExtensions
    {
        public static void MapFromAssembly(this ModelBuilder modelBuilder, Assembly assembly,string provider = null)
        {
            var interfaceType = typeof(IEntityTypeConfiguration<>);
            foreach (Type type in assembly.GetTypes())
            {
                var entityType = GetGenericParameterOfImplementedInterface(type, interfaceType);
                if (entityType == null) continue;

                var mapping = Activator.CreateInstance(type);
                var builderMethod = typeof(ModelBuilder).GetTypeInfo().GetMethods()
                    .First(m => m.IsGenericMethod && m.Name.StartsWith(nameof(ModelBuilder.Entity))
                        && m.GetParameters().Count()==0);
                var builder = builderMethod.MakeGenericMethod(entityType).Invoke(modelBuilder, new object[] { });
                type.GetTypeInfo().GetMethod(nameof(IEntityTypeConfiguration<object>.Map)).Invoke(mapping, new object[] { builder, provider });
            }
        }

        private static Type GetGenericParameterOfImplementedInterface(Type type, Type interfaceType)
        {
            var implInt = type.GetTypeInfo().GetInterfaces().SingleOrDefault(t => t.IsConstructedGenericType &&
                t.GetGenericTypeDefinition() == interfaceType);
            return implInt?.GetTypeInfo().GetGenericArguments().Single();
        }
    }
}
