using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ExamPrepTwo70_483
{
    class Manage_multithreading
    {
        ////Using Delegate 
        //public delegate int Calculate(int x, int y);

        //public int Add(int x, int y)
        //{
        //    return x + y;
        //}

        //public int Multiply(int x, int y)
        //{
        //    return x * y;
        //}

        //public void UseDelegate()
        //{
        //    Calculate calc = Add;
        //    Console.WriteLine(calc(3, 4));

        //    calc = Multiply;
        //    Console.WriteLine(calc(3, 4));
        //}

        //multicast delegate 

        //public void MethodOne()
        //{
        //    Console.WriteLine("MethodOne");
        //}

        //public void Methodtwo()
        //{
        //    Console.WriteLine("MethodTwo");
        //}

        //public delegate void Del();

        //public void Multicast()
        //{
        //    Del d = MethodOne;
        //    d += Methodtwo;
        //    d();
        //}

        //Convariance with delegates

        // Lambda expression to create a delegate

        // Using the Action delegate

        //Action<int, int> calc = (x, y) => 
        //{
        //    Console.WriteLine(x + y);
        //};

        //calc(3,4); 



    }

    //Using an Action to expose an event
    //public class Pub
    //{
    //    public Action OnChange { get; set; }

    //    public void Raise()
    //    {
    //        if (OnChange != null)
    //        {
    //            OnChange();
    //        }
    //    }
    //}
    //public void CreateAndRaise()
    //{
    //    Pub p = new Pub();
    //    p.OnChange += () => Console.WriteLine("Event raised to method 1");
    //    p.OnChange += () => Console.WriteLine("Event raise to method 2");
    //    p.Raise();
    //}
    //public event Action OnChange = delegate { };

    //public void Raise()
    //{
    //    OnChange();

    //Custom event arguments

    //public class MyArgs : EventArgs
    //{
    //    public int Value { get; set; }

    //    public MyArgs(int value)
    //    {
    //        Value = value;
    //    }
    //}

    //public class Pub
    //{
    //    public event EventHandler<MyArgs> OnChange = delegate { };

    //    public void Raise()
    //    {
    //        OnChange(this, new MyArgs(42));
    //    }
    //}

    //public void CreateAndRaise()
    //{
    //    Pub p = new Pub();
    //    p.OnChange += (sender, e) => Console.WriteLine("Event raised: {0}", e.Value);

    //    p.Raise();

    //}

    // Custom event accessor

    //public class Pub
    //{
    //    private event EventHandler<MyArgs> onChange = delegate { };
    //    public event EventHandler<MyArgs> OnChange
    //    {
    //      add
    //        {
    //            lock (onChange)
    //            {
    //                onChange += value;
    //            }
    //      }

    //        remove
    //        {
    //            lock (onChange)
    //            {
    //                onChange -= value;
    //            }
    //        }
    //    }

    //    public void Raise()
    //    {
    //        onChange(this, new MyArgs(42));
    //    }
        
    //}

    //public class practice
    //{
    //    //Using the FlagAttribute for an enum
    //    [Flags]
    //    enum Days
    //    {
    //        none = 0x0, 
    //        Sunday = 0x1, 
    //        Monday = 0x2,
    //        Tuesday = 0x4, 
    //        Wednesday = 0x8,
    //        Thurday = 0x10, 
    //        Friday = 0x20,
    //        Saturday =0x40
    //    }
    //    Days readingDays = Days.Monday | Days.Saturday;
    //}

    //creating a custom struct

    //public struct Point
    //{
    //    public int x, y;

    //    public Point(int p1, int p2)
    //    {
    //        x = p1;
    //        y = p2;
    //    }
    //}
}
