using System;

namespace DPM235497_TranThiThuyVi_Tuan02_Adapter_DB
{
    // Target
    public interface ITarget
    {
        string GetRequest();
    }

    // Adaptee
    public class Adaptee
    {
        public string GetSpecificRequest()
        {
            return "Specific request.";
        }
    }

    // Adapter
    public class Adapter : ITarget
    {
        private readonly Adaptee _adaptee;

        public Adapter(Adaptee adaptee)
        {
            _adaptee = adaptee;
        }

        public string GetRequest()
        {
            return $"This is '{_adaptee.GetSpecificRequest()}'";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Adaptee adaptee = new Adaptee();
            ITarget target = new Adapter(adaptee);

            Console.WriteLine("Adapter Pattern Demo:");
            Console.WriteLine(target.GetRequest());
        }
    }
}