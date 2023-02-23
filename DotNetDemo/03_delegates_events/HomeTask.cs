using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DotNetDemo._03_delegates_events.HomeTask;

namespace DotNetDemo._03_delegates_events
{
    public class HomeTask
    {
        public delegate void MyDel(int m);

        public void Main() 
        {
            Student student = new Student() { Name = "John" };
            Parent parent = new Parent();

            student.MarkChange += parent.OnMarkChange;

            Random rand = new Random();

            for (int i = 0; i < 10; i++) 
            {
                student.AddMark(rand.Next(12));
            }
        }
    }

    public class Student 
    {
        public event MyDel MarkChange;
        public string Name;
        public List<int> Marks = new List<int>();

        public void AddMark(int m) 
        {
            Marks.Add(m);
            MarkChange(m);
        }
    }

    public class Parent 
    {
        private string _api;

        public void OnMarkChange(int estimate) 
        {
            Console.WriteLine(estimate);

            //HttpClient client = new HttpClient(_api);
            //await client.SendAsync(estimate);
        }
    }
}
