using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetDemo._03_delegates_events
{
    public class ExtensionMethodsDemo
    {
        public void Main()
        {
            //DemoMethods obj = new DemoMethods(); 
            Student student = new Student() { Name = "John" };

            Random rand = new Random();

            for (int i = 0; i < 10; i++)
            {
                student.AddMark(rand.Next(12));
            }

            var average = student.GetAverageMarks();

            var str = "some string here, ".AddMessage("and a message from our sponsor", 1);
            Console.WriteLine(str);
        }
    }

    public static class DemoMethods
    {
        public static void StaticMethodSample() { }

        public static float GetAverageMarks(this Student student) 
        {
            int sum = 0;
            foreach (int i in student.Marks) { sum += i; }
            return sum / student.Marks.Count;
        }

        public static string AddMessage(this string str, string message, int i) 
        {
            return str + message;
        }
    }
}
