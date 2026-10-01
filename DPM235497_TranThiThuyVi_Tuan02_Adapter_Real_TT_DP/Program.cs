using System;

namespace DPM235497_TranThiThuyVi_Tuan02_Adapter_Real_TT_DP
{
    public interface IPaymentProcessor
    {
        void Pay(double amount);
    }

    // Hệ thống thanh toán cũ/bên thứ 3
    public class PayPalService
    {
        public void MakePayment(double dollars)
        {
            Console.WriteLine($"Đã thanh toán {dollars}$ thành công qua PayPal.");
        }
    }

    // Adapter
    public class PayPalAdapter : IPaymentProcessor
    {
        private readonly PayPalService _payPalService;

        public PayPalAdapter(PayPalService payPalService)
        {
            _payPalService = payPalService;
        }

        public void Pay(double amount)
        {
            _payPalService.MakePayment(amount);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            PayPalService paypal = new PayPalService();
            IPaymentProcessor processor = new PayPalAdapter(paypal);

            processor.Pay(150.0);
        }
    }
}