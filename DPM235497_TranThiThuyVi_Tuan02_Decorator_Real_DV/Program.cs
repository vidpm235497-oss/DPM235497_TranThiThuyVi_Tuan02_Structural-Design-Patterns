using System;

namespace DPM235497_TranThiThuyVi_Tuan02_Decorator_Real_DV
{
    public abstract class Beverage
    {
        public string Description { get; protected set; } = "Đồ uống";
        public abstract double Cost();
    }

    public class Espresso : Beverage
    {
        public Espresso() { Description = "Espresso"; }
        public override double Cost() => 30000;
    }

    public abstract class CondimentDecorator : Beverage
    {
        protected Beverage _beverage;
        public CondimentDecorator(Beverage beverage) { _beverage = beverage; }
    }

    public class Milk : CondimentDecorator
    {
        public Milk(Beverage beverage) : base(beverage)
        {
            Description = _beverage.Description + ", Thêm Sữa";
        }
        public override double Cost() => _beverage.Cost() + 5000;
    }

    class Program
    {
        static void Main(string[] args)
        {
            Beverage drink = new Espresso();
            drink = new Milk(drink);

            Console.WriteLine($"Món: {drink.Description}");
            Console.WriteLine($"Giá: {drink.Cost()} VNĐ");
        }
    }
}