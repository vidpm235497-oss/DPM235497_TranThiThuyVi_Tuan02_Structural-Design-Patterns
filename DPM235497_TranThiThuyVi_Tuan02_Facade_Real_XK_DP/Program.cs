using System;

namespace DPM235497_TranThiThuyVi_Tuan02_Facade_Real_XK_DP
{
    public class InventoryService
    {
        public bool CheckStock(string itemId) => true;
    }

    public class ShippingService
    {
        public void CreateShippingOrder(string itemId)
        {
            Console.WriteLine($"Đã tạo đơn vận chuyển cho mã sản phẩm: {itemId}");
        }
    }

    // Facade
    public class ExportWarehouseFacade
    {
        private InventoryService _inventory = new InventoryService();
        private ShippingService _shipping = new ShippingService();

        public void ExportItem(string itemId)
        {
            Console.WriteLine("--- Bắt đầu quy trình xuất kho ---");
            if (_inventory.CheckStock(itemId))
            {
                _shipping.CreateShippingOrder(itemId);
                Console.WriteLine("Xuất kho thành công!");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ExportWarehouseFacade facade = new ExportWarehouseFacade();
            facade.ExportItem("SP001");
        }
    }
}