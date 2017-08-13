using System;
using System.Reflection;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Euricom.MjrCenter.ScheduleApi.Utilities.Model
{
    public static class DbContextExtensions
    {
        public static void MapFromAssembly(this ModelBuilder modelBuilder, Assembly assembly)
        {
            var interfaceType = typeof(IEntityTypeConfiguration<>);
            foreach (Type type in assembly.GetTypes())
            {
                var entityType = GetGenericParameterOfImplementedInterface(type, interfaceType);
                if (entityType == null) continue;

                var mapping = Activator.CreateInstance(type);
                var builderMethod = typeof(ModelBuilder).GetMethods()
                    .First(m => m.IsGenericMethod && m.Name.StartsWith(nameof(ModelBuilder.Entity))
                        && m.GetParameters().Count()==0);
                var builder = builderMethod.MakeGenericMethod(entityType).Invoke(modelBuilder, new object[] { });
                type.GetMethod(nameof(IEntityTypeConfiguration<object>.Map)).Invoke(mapping, new object[] { builder });
            }
        }

        private static Type GetGenericParameterOfImplementedInterface(Type type, Type interfaceType)
        {
            var implInt = type.GetInterfaces().SingleOrDefault(t => t.IsConstructedGenericType &&
                t.GetGenericTypeDefinition() == interfaceType);
            return implInt?.GetGenericArguments().Single();
        }
    }
}
