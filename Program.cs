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
    static class Program
    {
        static void Main(string[] args)
        {
            new ClassC().Method();
            UsedMethods();
            //UnusedMethods();
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

        private static HashSet<MethodDefinition> visitedMethods = new HashSet<MethodDefinition>();
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
