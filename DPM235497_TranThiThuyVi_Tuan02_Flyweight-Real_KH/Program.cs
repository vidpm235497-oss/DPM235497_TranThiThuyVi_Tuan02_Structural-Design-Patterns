using System;
using System.Collections.Generic;

namespace DPM235497_TranThiThuyVi_Tuan02_Flyweight_Real_KH
{
    // Class Flyweight chứa thông tin chung dùng lại
    public class CustomerType
    {
        public string TypeName { get; private set; }
        public double DiscountRate { get; private set; }

        public CustomerType(string typeName, double discountRate)
        {
            TypeName = typeName;
            DiscountRate = discountRate;
        }
    }

    public class CustomerFactory
    {
        private static Dictionary<string, CustomerType> _types = new Dictionary<string, CustomerType>();

        public static CustomerType GetCustomerType(string name, double discount)
        {
            if (!_types.ContainsKey(name))
            {
                _types[name] = new CustomerType(name, discount);
            }
            return _types[name];
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var vipType = CustomerFactory.GetCustomerType("VIP", 0.15);
            Console.WriteLine($"Khách hàng thuộc loại: {vipType.TypeName}, Chiết khấu: {vipType.DiscountRate * 100}%");
        }
    }
}