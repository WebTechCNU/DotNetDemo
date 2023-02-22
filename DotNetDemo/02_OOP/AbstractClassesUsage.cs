using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetDemo._02_OOP
{
    public abstract class AbstractService
    {
        public int result;

        public void GetResult() 
        {
            Console.WriteLine(result);
        }
        
        public abstract void DoStuffRedefine(int a, int b);

        public virtual void SomeMethod() 
        {
            Console.WriteLine("This is abstract class");
        }
    }

    public class AddService : AbstractService
    {
        public override void DoStuffRedefine(int a, int b)
        {
            //throw new NotImplementedException();
            result = a + b;
        }

        public override void SomeMethod()
        {
            base.SomeMethod();
            Console.WriteLine("Add Service");
        }
    }

    public class MultiplyService : AbstractService
    {
        public override void DoStuffRedefine(int a, int b)
        {
            result = a * b;
        }

        public override void SomeMethod()
        {
            //base.SomeMethod();
            Console.WriteLine("Multiply Service");
        }
    }
}
