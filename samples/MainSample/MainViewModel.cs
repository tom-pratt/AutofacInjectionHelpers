using System;
using System.Collections.Generic;
using System.Text;

namespace MainSample
{
    public class MainViewModel : IDisposable
    {
        private readonly int _randomNumber;

        public string Message { get; }

        public MainViewModel()
        {
            _randomNumber = new Random().Next();

            Message = $"Random number survives rotation: {_randomNumber}.";
        }

        public void Dispose()
        {
        }
    }
}
