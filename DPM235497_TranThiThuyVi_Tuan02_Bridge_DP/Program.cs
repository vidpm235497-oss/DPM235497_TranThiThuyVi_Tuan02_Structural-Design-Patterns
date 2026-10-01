using System;

namespace DPM235497_TranThiThuyVi_Tuan02_Bridge_DP
{
    // Implementation
    public interface IImplementation
    {
        string OperationImplementation();
    }

    public class ConcreteImplementationA : IImplementation
    {
        public string OperationImplementation()
        {
            return "ConcreteImplementationA: Kết quả trên nền tảng A.";
        }
    }

    // Abstraction
    public class Abstraction
    {
        protected IImplementation _implementation;

        public Abstraction(IImplementation implementation)
        {
            _implementation = implementation;
        }

        public virtual string Operation()
        {
            return "Abstraction: Thao tác cơ sở với:\n" + _implementation.OperationImplementation();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Abstraction abstraction = new Abstraction(new ConcreteImplementationA());
            Console.WriteLine(abstraction.Operation());
        }
    }
}