using System;
using System.Collections.Generic;
using System.Text;

namespace MainSample
{
    public class FirstViewModel
    {
        public string Title { get; set; } = "Hello world";

        public FirstViewModel(/* Any dependencies also registered with autofac */)
        {

        }
    }
}
