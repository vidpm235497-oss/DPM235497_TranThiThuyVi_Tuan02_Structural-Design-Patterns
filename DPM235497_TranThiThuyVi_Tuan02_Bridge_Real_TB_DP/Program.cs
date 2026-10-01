using System;

namespace DPM235497_TranThiThuyVi_Tuan02_Bridge_Real_TB_DP
{
    public interface IDevice
    {
        void TurnOn();
        void TurnOff();
    }

    public class TV : IDevice
    {
        public void TurnOn() => Console.WriteLine("Tivi đã bật.");
        public void TurnOff() => Console.WriteLine("Tivi đã tắt.");
    }

    public class RemoteControl
    {
        protected IDevice _device;

        public RemoteControl(IDevice device)
        {
            _device = device;
        }

        public void TogglePower()
        {
            _device.TurnOn();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IDevice tv = new TV();
            RemoteControl remote = new RemoteControl(tv);
            remote.TogglePower();
        }
    }
}