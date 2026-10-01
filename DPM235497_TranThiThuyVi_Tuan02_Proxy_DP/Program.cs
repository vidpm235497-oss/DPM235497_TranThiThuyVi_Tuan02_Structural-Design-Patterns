using System;

namespace DPM235497_TranThiThuyVi_Tuan02_Proxy_DP
{
    public interface ISubject
    {
        void Request();
    }

    public class RealSubject : ISubject
    {
        public void Request()
        {
            Console.WriteLine("RealSubject: Handling Request.");
        }
    }

    public class Proxy : ISubject
    {
        private RealSubject _realSubject;

        public void Request()
        {
            if (_realSubject == null)
            {
                _realSubject = new RealSubject();
            }
            Console.WriteLine("Proxy: Checking access before real request.");
            _realSubject.Request();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ISubject proxy = new Proxy();
            proxy.Request();
        }
    }
}