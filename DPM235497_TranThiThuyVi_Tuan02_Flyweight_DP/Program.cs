using System;
using System.Collections.Generic;

namespace DPM235497_TranThiThuyVi_Tuan02_Flyweight_DP
{
    public class Flyweight
    {
        private string _sharedState;

        public Flyweight(string sharedState)
        {
            _sharedState = sharedState;
        }

        public void Operation(string uniqueState)
        {
            Console.WriteLine($"Shared: {_sharedState}, Unique: {uniqueState}");
        }
    }

    public class FlyweightFactory
    {
        private Dictionary<string, Flyweight> _flyweights = new Dictionary<string, Flyweight>();

        public Flyweight GetFlyweight(string key)
        {
            if (!_flyweights.ContainsKey(key))
            {
                _flyweights[key] = new Flyweight(key);
            }
            return _flyweights[key];
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            FlyweightFactory factory = new FlyweightFactory();
            Flyweight flyweight = factory.GetFlyweight("SharedState1");
            flyweight.Operation("UniqueStateA");
        }
    }
}