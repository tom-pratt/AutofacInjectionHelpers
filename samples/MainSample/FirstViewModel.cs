using System;
using System.Collections.Generic;
using System.Text;

namespace MainSample
{
    public class FirstViewModel : IDisposable
    {
        public string Title { get; }
        public IReadOnlyList<string> Items { get; }

        public FirstViewModel(/* Any dependencies also registered with autofac */)
        {
            Title = "Hello world";
            Items = new List<string> { "Item 1", "Item 2", "Item 3", "Item 4", "Item 5" };
        }

        public void Dispose()
        {
        }
    }
}
