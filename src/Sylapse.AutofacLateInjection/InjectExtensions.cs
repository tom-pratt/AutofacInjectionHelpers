using Autofac;
using System;
using System.Linq;
using System.Reflection;

namespace Sylapse.AutofacLateInjection
{
    public static class InjectExtensions
    {
        public static void Inject(this ILifetimeScope scope, object obj)
        {
            Inject(scope, obj, null);
        }

        public static void Inject(this ILifetimeScope scope, object obj, string injectionPoint)
        {
            var type = obj.GetType();

            while (type != null)
            {
                var propertiesToInject = type.GetRuntimeProperties().Where(x => x.GetCustomAttributes().Any(a => a is InjectAttribute && (a as InjectAttribute).InjectionPoint == injectionPoint));

                foreach (var property in propertiesToInject)
                {
                    var dependency = scope.Resolve(property.PropertyType);
                    property.SetValue(obj, dependency);
                }

                var fieldsToInject = type.GetRuntimeFields().Where(x => x.GetCustomAttributes().Any(a => a is InjectAttribute && (a as InjectAttribute).InjectionPoint == injectionPoint));

                foreach (var field in fieldsToInject)
                {
                    var dependency = scope.Resolve(field.FieldType);
                    field.SetValue(obj, dependency);
                }

                type = type.GetTypeInfo().BaseType;
            }
        }
    }
}
