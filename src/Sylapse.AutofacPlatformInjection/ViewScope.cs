using Autofac;
using Autofac.Builder;
using System;

namespace Sylapse.AutofacPlatformInjection
{
    public static class ViewScope
    {
        public const string ViewLifetimeScope = "viewlifetimescope";
        public const string ViewInstanceScope = "viewinstancescope";
        public const string ViewLayoutScope = "viewlayoutscope";

        public static IRegistrationBuilder<TLimit, TActivatorData, TStyle>
            InstancePerViewLifetime<TLimit, TActivatorData, TStyle>(
                this IRegistrationBuilder<TLimit, TActivatorData, TStyle> registration)
        {
            if (registration == null) throw new ArgumentNullException(nameof(registration));

            return registration.InstancePerMatchingLifetimeScope(ViewLifetimeScope);
        }

        public static IRegistrationBuilder<TLimit, TActivatorData, TStyle>
            InstancePerViewInstance<TLimit, TActivatorData, TStyle>(
                this IRegistrationBuilder<TLimit, TActivatorData, TStyle> registration)
        {
            if (registration == null) throw new ArgumentNullException(nameof(registration));

            return registration.InstancePerMatchingLifetimeScope(ViewInstanceScope);
        }

        public static IRegistrationBuilder<TLimit, TActivatorData, TStyle>
            InstancePerViewLayout<TLimit, TActivatorData, TStyle>(
                this IRegistrationBuilder<TLimit, TActivatorData, TStyle> registration)
        {
            if (registration == null) throw new ArgumentNullException(nameof(registration));

            return registration.InstancePerMatchingLifetimeScope(ViewLayoutScope);
        }

        public static ILifetimeScope BeginViewLifetimeScope(this ILifetimeScope scope)
        {
            return scope.BeginLifetimeScope(ViewLifetimeScope);
        }

        public static ILifetimeScope BeginViewLifetimeScope(this ILifetimeScope scope, Action<ContainerBuilder> configurationAction)
        {
            return scope.BeginLifetimeScope(ViewLifetimeScope, configurationAction);
        }

        public static ILifetimeScope BeginViewInstanceScope(this ILifetimeScope scope)
        {
            return scope.BeginLifetimeScope(ViewInstanceScope);
        }

        public static ILifetimeScope BeginViewInstanceScope(this ILifetimeScope scope, Action<ContainerBuilder> configurationAction)
        {
            return scope.BeginLifetimeScope(ViewInstanceScope, configurationAction);
        }

        public static ILifetimeScope BeginViewLayoutScope(this ILifetimeScope scope)
        {
            return scope.BeginLifetimeScope(ViewLayoutScope);
        }

        public static ILifetimeScope BeginViewLayoutScope(this ILifetimeScope scope, Action<ContainerBuilder> configurationAction)
        {
            return scope.BeginLifetimeScope(ViewLayoutScope, configurationAction);
        }
    }
}