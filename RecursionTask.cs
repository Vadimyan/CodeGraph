using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGraph
{
    public class RecursionTask
    {
        public void SimpleRecursion()
        {
            int i = 3;
            if (Console.ReadKey().Key == ConsoleKey.Q)
                i = 5;
            Console.WriteLine(i);
            SimpleRecursion();
        }

        public void HardRecursion() => HardRecursion2();
        private void HardRecursion2() => HardRecursion();

        public void ImplicitRecursion() => SimpleRecursion();
    }
}
