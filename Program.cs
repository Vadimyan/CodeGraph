using Mono.Cecil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGraph
{
    // Полезные ссылки:
    // Source code to IL online: https://sharplab.io/#v2
    // Mono.Cecil hello world: https://github.com/jbevain/cecil/wiki/HOWTO 
    static class Program
    {
        static void Main(string[] args)
        {
            // Задача 1 (раскомментировать для решения)
            //new ClassC().Method();
            //UsedMethods();

            // Задача 2 (раскомментировать для решения)
            //new ClassC().Method();
            //UnusedMethods();

            // Задача 3 (раскомментировать для решения)
            //Console.WriteLine($"Задача 3: {(ChechRecursion("CodeGraph.RecursionTask", "SimpleRecursion") ? "ОК" : "НеОК")}");
            //Console.WriteLine($"Задача 4: {(ChechRecursion("CodeGraph.RecursionTask", "HardRecursion") ? "ОК" : "НеОК")}");
            //Console.WriteLine($"Задача 5: {(ChechRecursion("CodeGraph.RecursionTask", "ImplicitRecursion") ? "ОК" : "НеОК")}");
        }

        private static bool ChechRecursion(string classFullName, string methodName)
        {
            throw new NotImplementedException();
        }

        private static void UnusedMethods()
        {
            Console.WriteLine("START PRINT UNUSED METHODS");
            throw new NotImplementedException();
            Console.WriteLine("END PRINT UNUSED METHODS");
            Console.WriteLine();
            Console.WriteLine();
        }

        private static void UsedMethods()
        {
            Console.WriteLine("START PRINT USED METHODS");
            AssemblyDefinition
                .ReadAssembly("CodeGraph.exe")
                .MainModule
                .Types
                .First(x => x.FullName == "CodeGraph.Program")
                .Methods
                .First(x => x.Name == "Main")
                .PrintUsedMethods();
            Console.WriteLine("END PRINT USED METHODS");
            Console.WriteLine();
            Console.WriteLine();
        }

        static void PrintUsedMethods(this MethodDefinition method)
        {
            var visitedMethods = new HashSet<MethodDefinition>();

            var notVisitedUsedMethods = method
                .Body
                .Instructions
                .Select(x => x.Operand)
                .OfType<MethodDefinition>()
                .Where(x => !visitedMethods.Contains(x));


            foreach (var usedMethod in notVisitedUsedMethods)
            {
                visitedMethods.Add(usedMethod);
                Console.WriteLine("{0} -> {1}", method.GetFullName(), usedMethod.GetFullName());
                PrintUsedMethods(usedMethod);
            }
        }

        private static string GetFullName(this IMemberDefinition method)
        {
            return $"{method.DeclaringType.Name}.{method.Name}";
        }
    }
}
