using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Excel;

namespace ExamPrepTwo70_483
{
    class Program
    {
        static void Main(string[] args)
        {
            ////Parallel Language-Intergrated Query(PLINQ). Below is how you convert a Query to a parallel queary. 
            //var numbers = Enumerable.Range(0, 10);
            //var pareallelResult = numbers.AsParallel().AsOrdered()//AsOrdered allow you to put PLINQ in order.
            //    .Where(i => i % 2 == 0).AsSequential()// This ensure that the take method doesn't mess up your order. 
            //    .ToArray();
            ////The CLR determines whether it makes sense to turn your query into parallel. It generates
            //// Task objects and starts executing them. 
            //foreach (var i in pareallelResult.Take(5))//Take method specifiy a number of element from the start of a sequence. 
            //{
            //    Console.WriteLine(i);
            //}
            //// when using parallel processing does not guarantee any particular order. 

            //Using ForAll with PLINQ

            //var numbers = Enumerable.Range(0, 20);

            //var parallelResult = numbers.AsParallel()
            //    .Where(i => i % 2 == 0);

            //parallelResult.ForAll(e => Console.WriteLine(e));
            //Console.ReadKey();

            // Catching AggregateExecption 

            //    var numbers = Enumerable.Range(0, 20);

            //    try
            //    {
            //        var parallelResult = numbers.AsParallel()
            //            .Where(i => IsEven(i));

            //        parallelResult.ForAll(e => Console.WriteLine(e));
            //    }
            //    catch (AggregateException e)
            //    {

            //        Console.WriteLine("There where {0} exceptions", e.InnerExceptions.Count);
            //    }
            //    Console.ReadKey();
            //}

            //private static bool IsEven(int i)
            //{
            //    if (i % 10 == 0)
            //      throw new ArgumentException("i");
            //        return i % 2 == 0;


            // Using concurrent collections

            // Using BlockingCollection<T> 

            //BlockingCollection<string> col = new BlockingCollection<string>();//This collection is thread-safe for adding and removing data. 
            //Task read = Task.Run(() =>
            //{
            //    while (true)
            //    {
            //        Console.WriteLine(col.Take());
            //    }
            //});

            //Task write = Task.Run(() =>
            //{
            //    while (true)
            //    {
            //        string s = Console.ReadLine();
            //        if (string.IsNullOrWhiteSpace(s)) break;
            //        col.Add(s);

            //    }
            //});
            //write.Wait();
            ////Console.ReadKey();

            //Using ConcurrentBag
            // ConcurrentBag<int> bag = new ConcurrentBag<int>();

            // //bag.Add(42);
            // //bag.Add(21);

            // //int result;
            // //if (bag.TryTake(out result))
            // //{
            // //    Console.WriteLine(result);
            // //}

            // //if (bag.TryPeek(out result))
            // //{
            // //    Console.WriteLine("There is a next item: {0}", result);
            // //}
            // //Console.ReadKey();

            // //Enumerating a ConcurrentBag

            // Task.Run(() =>
            // {
            //     bag.Add(42);
            //     Thread.Sleep(1000);
            //     bag.Add(21);
            // });
            // Task.Run(() =>
            // {
            //     foreach (int i in bag)
            //     {
            //         Console.WriteLine(i);
            //     }
            // }).Wait();
            //Console.ReadKey();

            //ConcurrentDictionary<bool, int> cd = new ConcurrentDictionary<bool, int>();
            //ConcurrentQueue<int> cq = new ConcurrentQueue<int>();
            //ConcurrentStack<int> stack = new ConcurrentStack<int>();

            //stack.Push(42);

            //int result;

            //if (stack.TryPop(out result))
            //{
            //    Console.WriteLine("Popped: {0}", result);
            //}
            //stack.PushRange(new int[] { 1, 2, 3 });

            //int[] values = new int[2];
            //stack.TryPopRange(values);

            //foreach (int i in values)
            //    Console.WriteLine(i);
            //Console.ReadLine();

            //Using a ConcurrentQuece
            //ConcurrentQueue<int> queue = new ConcurrentQueue<int>();
            //queue.Enqueue(42);

            //int result;
            //if (queue.TryDequeue(out result))
            //{
            //    Console.WriteLine("Dequeued: {0}", result);
            //}
            //Console.ReadLine();

            // using a ConcurrentDictionary 
            //var dict = new ConcurrentDictionary<string, int>();
            //if (dict.TryAdd("k1", 42))
            //{
            //    Console.WriteLine("Added");
            //}

            //if (dict.TryUpdate("k1", 21, 42))
            //{
            //    Console.WriteLine("42 updated to 21");
            //}

            //dict["k1"] = 42; // Overwrite unconditionally 

            //int r1 = dict.AddOrUpdate("k1", 3, (s, i) => i * 2);
            //int r2 = dict.GetOrAdd("k2", 3);

            //Console.ReadKey();

            //Accessing shared data in a multithreaded a;;lication 

            //int n = 0;

            //var up = Task.Run(() =>
            //{
            //    for (int i = 0; i < 1000000; i++)
            //    {
            //        n++;
            //    }
            //});

            //for (int i = 0; i < 1000000; i++)
            //{
            //    n--;
            //    up.Wait();
            //    Console.WriteLine(n);
            //}
            //using the lock keyword

            //int n = 0;

            //object _lock = new object();

            //var up = Task.Run(() =>
            //{
            //    for (int i = 0; i < 1000000; i++)
            //    {
            //        //lock (_lock)
            //            n++;
            //    }
            //});

            //for (int i = 0; i < 1000000; i++)
            //{
            //    //lock (_lock)
            //        n--;

            //    up.Wait();
            //    Console.WriteLine(n);
            //}

            // Creating a deadlock

            //object lockA = new object();
            //object lockB = new object();

            //var up = Task.Run(() =>
            //{
            //    lock (lockA)
            //    {
            //        Thread.Sleep(1000);
            //        lock (lockB)
            //        {
            //            Console.WriteLine("Locked A and B");
            //        }
            //    }
            //});

            //lock (lockB)
            //{
            //    lock (lockA)
            //    {
            //        Console.WriteLine("Locked B and A");
            //    }
            //}
            //up.Wait();

            //Generated code from a lock statement
            //You shouldn't write this code by hand. The compiler will generate it for you. 
            //object gate = new object();
            //bool _lockTaken = false;
            //try
            //{
            //    Monitor.Enter(gate, ref _lockTaken);
            //}
            //finally
            //{
            //    if (_lockTaken)
            //    {
            //        Monitor.Exit(gate);
            //    }
            //}

            //Volatile class
            // A potential problem with multithreaded code

            //Using the Interlocked class

            //int n = 0;

            //var up = Task.Run(() =>
            //{
            //    for (int i = 0; i < 1000000; i++)
            //    {
            //        Interlocked.Increment(ref n);
            //    }
            //});

            //for (int i = 0; i < 1000000; i++)
            //{
            //    Interlocked.Decrement(ref n);
            //}
            //up.Wait();
            //Console.WriteLine();

            //Understanding delegates

            //Manage_multithreading calcu = new Manage_multithreading();
            //calcu.UseDelegate();

            //Test'

            //Creating a custom struct

            //List<int> mylist = new List<int>() { 1, 3, 5 };
            //mylist[0] = 1;

            ////boxing 
            //int value = 9;
            //object objects = value;

            ////unboxing
            //objects = 9;
            //value = (int)objects;

            //string.Concat("To box or not box", 42, true);

            ////boxing an inter value
            //int i = 42;
            //object o = i;//putting in a new object on the heap and storing a refernces on the stack.
            //int x = (int)o;

            //implicity converting an integer to a double
            //int i = 42;
            //double d = i;

            //implicity converting an object to a base type
            //HttpClient client = new HttpClient();
            //object o = client;
            //IDisposable d = client;

            // Casting a doubl to an int 
            //double x = 1234.7;
            //int a;
            //// Cast dobule to int 
            //a = (int)x;

            //Explicityly casting a base type to a derived type

            //Object stream = new MemoryStream();
            //MemoryStream memoryStream = (MemoryStream)stream;

            //Using an implicit and explicit cast operator on a custom type

            //Money m = new Money(42.42M);
            //decimal amount = m;
            //int truncatedAmount = (int)m;

            // Using the built-in Convert and Parse mehtods
            //int value = Convert.ToInt32("42");
            //value = int.Parse("42");
            //bool success = int.TryParse("42,", out value);

            //var entities = new List<dynamic> {
            //new
            //{
            //    ColumnA = 1, ColumnB = "Foo"
            //},
            //new
            //{
            //    ColumnA = 2, ColumB = "Bar"
            //}
            //};

            //DisplayInExcel(entities);

            dynamic obj = new SampleObject();
            Console.WriteLine(obj.SomeProperty);

            Console.ReadKey();

        }


        ////Exportining some data to Excel 
        //static void DisplayInExcel(IEnumerable<dynamic> entities)
        //{
        //    var excelApp = new Excel.Appliction();
        //    excelApp.Visible = true;
        //    NewMethod(excelApp);


        //  excelApp.Workbooks.Add();

        //    dynamic workSheet = excelApp.ActiveSheet;

        //    workSheet.Cells[1, "A"] = "Header A";
        //    workSheet.Cells[1, "B"] = "Header B";

        //    var row = 1;
        //    foreach (var entity in entities)
        //    {
        //        row++;
        //        workSheet.Cells[row, "A"] = entity.ColumnA;
        //        workSheet.Cells[row, "B"] = entity.ColumnB;
        //    }

        //    workSheet.Columns[1].Autofit();
        //    workSheet.Columns[2].Autofit();
        //}

        //public static void NewMethod(Appliction excelApp)
        //{
        //    Add();
        //}

        // IAnimal animal = new Dog();

        List<Order> orders = new List<Order>
        {
            new Order { Created = new DateTime(2012, 12, 1 )},
            new Order { Created = new DateTime(2012, 1, 6 )},
            new Order { Created = new DateTime(2012, 7, 8 )},
            new Order { Created = new DateTime(2012, 2, 20 )},


        };

         orders.Sort();

        
         
    }
    
}
