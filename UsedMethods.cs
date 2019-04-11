using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGraph
{
    public class ClassA
    {
        public void Method()
        {
        }
    }

    public class ClassB
    {
        public void Method()
        {
            new ClassA().Method();
        }

        public void UnusedMethod()
        {
        }
    }


    public class ClassC
    {
        public void Method()
        {
            new ClassB().Method();
        }
    }

    public class UnusedClass
    {
        public void UnusedMethod()
        {
        }
    }

}
