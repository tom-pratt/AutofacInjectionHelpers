using System;
using Sylapse.AutofacLateInjection;

namespace Sylapse.AutofacPlatformInjection.iOS
{
	public class InjectViewDidLoad : InjectAttribute
	{
        public InjectViewDidLoad() : base(InjectionPoints.ViewDidLoad)
		{
		}
	}
}
