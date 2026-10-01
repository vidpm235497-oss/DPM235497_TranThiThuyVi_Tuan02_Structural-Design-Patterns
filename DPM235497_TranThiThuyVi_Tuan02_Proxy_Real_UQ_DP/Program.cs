using System;

namespace DPM235497_TranThiThuyVi_Tuan02_Proxy_Real_UQ_DP
{
    public interface IFolderAccess
    {
        void OpenFolder();
    }

    public class RealFolder : IFolderAccess
    {
        public void OpenFolder()
        {
            Console.WriteLine(">> Mở thư mục thành công: Dữ liệu bảo mật đã được hiển thị.");
        }
    }

    // Proxy xác thực/ủy quyền
    public class FolderProxy : IFolderAccess
    {
        private RealFolder _folder;
        private string _role;

        public FolderProxy(string role)
        {
            _role = role;
        }

        public void OpenFolder()
        {
            if (_role.Equals("Admin", StringComparison.OrdinalIgnoreCase))
            {
                _folder = new RealFolder();
                _folder.OpenFolder();
            }
            else
            {
                Console.WriteLine(">> Truy cập bị từ chối: Bạn không có quyền (Ủy quyền) Admin.");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Thử nghiệm với quyền User ---");
            IFolderAccess userProxy = new FolderProxy("User");
            userProxy.OpenFolder();

            Console.WriteLine("\n--- Thử nghiệm với quyền Admin ---");
            IFolderAccess adminProxy = new FolderProxy("Admin");
            adminProxy.OpenFolder();
        }
    }
}