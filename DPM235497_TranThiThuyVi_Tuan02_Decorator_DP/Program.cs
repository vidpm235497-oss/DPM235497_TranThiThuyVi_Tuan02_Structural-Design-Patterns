using System;

namespace DPM235497_TranThiThuyVi_Tuan02_Decorator_DP
{
    public abstract class Component
    {
        public abstract string Operation();
    }

    public class ConcreteComponent : Component
    {
        public override string Operation() => "ConcreteComponent";
    }

    public abstract class Decorator : Component
    {
        protected Component _component;

        public Decorator(Component component)
        {
            _component = component;
        }

        public override string Operation() => _component.Operation();
    }

    public class ConcreteDecoratorA : Decorator
    {
        public ConcreteDecoratorA(Component comp) : base(comp) { }

        public override string Operation()
        {
            return $"ConcreteDecoratorA({base.Operation()})";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Component simple = new ConcreteComponent();
            Component decorator = new ConcreteDecoratorA(simple);
            Console.WriteLine(decorator.Operation());
        }
    }
}