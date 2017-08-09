using System;

namespace Sylapse.AutofacLateInjection
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class InjectAttribute : Attribute
    {
        public string InjectionPoint { get; }

        public InjectAttribute() : this(null)
        {
        }

        public InjectAttribute(string injectionPoint)
        {
            InjectionPoint = injectionPoint;
        }
    }
}
