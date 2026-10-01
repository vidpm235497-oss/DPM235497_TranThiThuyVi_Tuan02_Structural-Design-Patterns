using System;
using System.Collections.Generic;

namespace DPM235497_TranThiThuyVi_Tuan02_Composite_DP
{
    public abstract class Component
    {
        public abstract void Display(int depth);
    }

    public class Leaf : Component
    {
        private string _name;

        public Leaf(string name)
        {
            _name = name;
        }

        public override void Display(int depth)
        {
            Console.WriteLine(new string('-', depth) + " Leaf: " + _name);
        }
    }

    public class Composite : Component
    {
        private List<Component> _children = new List<Component>();
        private string _name;

        public Composite(string name)
        {
            _name = name;
        }

        public void Add(Component component) => _children.Add(component);

        public override void Display(int depth)
        {
            Console.WriteLine(new string('-', depth) + " Composite: " + _name);
            foreach (var component in _children)
            {
                component.Display(depth + 2);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Composite root = new Composite("Root");
            root.Add(new Leaf("Leaf A"));
            root.Add(new Leaf("Leaf B"));

            Composite comp = new Composite("Composite X");
            comp.Add(new Leaf("Leaf XA"));
            root.Add(comp);

            root.Display(1);
        }
    }
}