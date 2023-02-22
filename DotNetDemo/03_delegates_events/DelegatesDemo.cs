namespace DotNetDemo._03_delegates_events
{
    public class DelegatesDemo
    {
        public delegate bool SomeDelegate(int i);
        public delegate string SomeDelegateString(string message);


        public void Main() 
        {
            SomeDelegateString delNew;

            if (DateTime.Now.Hour < 12)
            {
                delNew = GoodMorning;
            }
            else 
            {
                delNew = GoodEvening;

            }
            Console.WriteLine(delNew("302 group!"));
            Type type = typeof(SomeDelegate);
            // MulticastDelegate;

            //delNew = Calculate;

            delNew.Invoke("");
            PassDelegateHere(delNew);

            SomeDelegate del = Calculate;
            del += CalculateTen;
            del += CalculateNew;

            del(20); // del -> { Calculate(20); CalculateTen(20); CalculateNew(20); }

            //del -= CalculateTen; // del -> { Calculate(20); CalculateNew(20); }

            del += (int i) => { 
                Console.WriteLine(i);
                i += 20;
                return i % 4 == 0; 
            };

            var sampleDel = (int i, bool b) => { return b ? i % 2 == 0 : i % 3 == 0; };
            // anonymous method

            Predicate<string> prd = (i) => { return true; }; 
            // delegate, that always returns bool
            
            Func<int, int, string> f = (a, b) => { return (a + b).ToString(); }; 
            // del., return last param type
            
            Action<string, string> act = (a, b) => { Console.WriteLine(a + b); };
            // delegate, that points to methods with return type void 
        }

        public delegate string Messanger(int a);

        public event Messanger AccountUsage;

        public void EventsUsage() 
        {
            // Events use subscriber-publisher pattern;
            AccountUsage += MessangerCustom;
            //
            //
            Console.WriteLine( AccountUsage(100));
        }

        private string MessangerCustom(int money) 
        {
            return $"{money} usd were taken from your account";
        }

        private string MessangerTransfer(int money)
        {
            return $"{money} usd were trasfered to your account";
        }

        private bool CalculateNew(int i)
        {
            return i % 3 == 1;
        }

        private void PassDelegateHere(SomeDelegateString del) 
        {
            del.Invoke("some string");
        }

        private string GoodEvening(string message)
        {
            return "Good evening, " + message;
        }

        private string GoodMorning(string message)
        {
            return "Good morning, " + message;
        }

        private bool Calculate(int i)
        {
            return i % 2 == 0;
        }

        private bool CalculateTen(int i)
        {
            return i % 10 == 0;
        }
    }
}
