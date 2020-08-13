using System;

namespace OtherRehearsal
{
    class Program
    {
        // Delegate is a representative to communicate between two parties.
        //public delegate void SomeMethodDelegate();
        static void Main(string[] args)            
        {
            Console.WriteLine("Delegate Rehearsal!");

            //we can do this
            //SomeMethodDelegate deleg = new SomeMethodDelegate(SomeMethod);
            //deleg.Invoke(); // but what are the benefits??

            MyClass obj = new MyClass();
            obj.LongRun(CB);

        }

        static void CB(int i) {
            Console.Write(i);
        }

        static void SomeMethod() {
            Console.WriteLine("SomeMethod Called");
        }
    }

    public class MyClass 
    {
        public delegate void CallBack(int i);
        // here we are gona pass a method as a parameter
        public void LongRun(CallBack obj)
        {
            for (int i = 0; i < 100; i++)
            {
                obj(i);
            }
        }
    }
}
