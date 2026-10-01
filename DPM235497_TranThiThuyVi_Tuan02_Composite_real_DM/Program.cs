using System;
using System.Collections.Generic;

namespace DPM235497_TranThiThuyVi_Tuan02_Composite_real_DM
{
    public abstract class FileSystemItem
    {
        public string Name { get; set; }
        public FileSystemItem(string name) { Name = name; }
        public abstract void Print(int indent = 0);
    }

    public class FileItem : FileSystemItem
    {
        public FileItem(string name) : base(name) { }
        public override void Print(int indent = 0)
        {
            Console.WriteLine(new string(' ', indent) + "- File: " + Name);
        }
    }

    public class DirectoryItem : FileSystemItem
    {
        private List<FileSystemItem> _items = new List<FileSystemItem>();

        public DirectoryItem(string name) : base(name) { }

        public void Add(FileSystemItem item) => _items.Add(item);

        public override void Print(int indent = 0)
        {
            Console.WriteLine(new string(' ', indent) + "+ Thư mục: " + Name);
            foreach (var item in _items)
            {
                item.Print(indent + 2);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            DirectoryItem root = new DirectoryItem("Document");
            root.Add(new FileItem("BaiTap1.docx"));

            DirectoryItem subFolder = new DirectoryItem("Tuan02");
            subFolder.Add(new FileItem("Code.cs"));
            root.Add(subFolder);

            root.Print();
        }
    }
}