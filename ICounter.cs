using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Services
{
    public interface ICounter
    {
        int Value { get; }
    }
    public class RandomCounter : ICounter
    {
        public int Value { get => _value; }
        private int _value;
        private static readonly Random _rnd = new Random();
        public RandomCounter()
        {
            _value = _rnd.Next(0,1000000);
        }
    }

    public sealed class CounterService 
    {
        public ICounter Counter { get; }
        public CounterService(ICounter counter)
        {
            Counter = counter;
        }
    }
}
