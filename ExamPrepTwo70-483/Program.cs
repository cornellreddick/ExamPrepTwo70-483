﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Excel;
using System.CodeDom;
using System.Linq.Expressions;
using System.Text;
using System.Xml;
using System.Globalization;

using System.Security.Cryptography;
using System.Security;
using System.Diagnostics;

namespace ExamPrepTwo70_483
{
    class Program
    {

        const int numberOfIterations = 1000000;
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

            //dynamic obj = new SampleObject();
            //Console.WriteLine(obj.SomeProperty);

            //Console.ReadKey();




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

            //    List<Order> orders = new List<Order>
            //{
            //    new Order { Created = new DateTime(2012, 12, 1 )},
            //    new Order { Created = new DateTime(2012, 1, 6 )},
            //    new Order { Created = new DateTime(2012, 7, 8 )},
            //    new Order { Created = new DateTime(2012, 2, 20 )},


            //};

            //    //orders.Sort();

            //    // Syntactic sugar of the foreach statemnet 
            //    List<int> numbers = new List<int> { 1, 2, 3, 5, 7, 9 };

            //    using (List<int>.Enumerator enumerator = numbers.GetEnumerator()) 
            //    {
            //        while (enumerator.MoveNext())
            //        {
            //            Console.WriteLine(enumerator.Current);
            //        }

            //    }


            //int i = 42;
            //System.Type type = i.GetType();
            //Console.ReadKey();

            // insp3cting an assembly for types that implement a custom interface
            //Assembly pluginAssembly = Assembly.Load("assemblyname");

            //var plugins = from type in pluginAssembly.GetTypes()
            //              where typeof(IPlugin).IsAssignableFrom(type) && !type.IsInterface
            //              select type;

            //foreach (Type pluginType  in plugins)
            //{
            //    IPlugin plugin = Activator.CreateInstance(pluginType) as IPlugin;
            //}

            //int i = 42;
            //MethodInfo compareToMethod = i.GetType().GetMethod("CompareTo", new Type[] { typeof(int) });
            //int result = (int)compareToMethod.Invoke(i, new object[] { 41 });

            //Creating a Func type with a lambda
            //Func<int, int, int> addFunc = (x, y) => x + y;
            //Console.WriteLine(addFunc(2, 3));

            // Creating "Hello World!" with an expression tree
            //BlockExpression blockeExpr = Expression.Block(
            //    Expression.Call(
            //    null,
            //    typeof(Console).GetMethod("Write", new Type[] { typeof(String) }), Expression.Constant("Hello")),

            //    Expression.Call(
            //        null,
            //        typeof(Console).GetMethod("WriteLine", new Type[] { typeof(String) }),
            //        Expression.Constant("World!"))
            //        );

            //Expression.Lambda<Action>(blockeExpr).Compile()();
            //// Forcing a garbage collection

            //StreamWriter stream = File.CreateText("temp.dat");
            //stream.Write("some data");
            //stream.Dispose();
            //File.Delete("temp.dat");

            //string s = string.Empty;

            //for (int i = 0; i < 10000; i++)
            //{
            //    s += "x";
            //}

            //Changing a character with a StringBulder
            //System.Text.StringBuilder sb = new System.Text.StringBuilder("A initial value");
            //sb[0] = 'B';

            //StringBuilder stringBuilder = new StringBuilder(string.Empty);

            //for (int i = 0; i < 10000; i++)
            //{
            //    stringBuilder.Append("x");

            //}
            // Using a StringReader as the input for an XmlReader

            //var stringReader = new StringReader(xml);
            //using (XmlReader reader = XmlReader.Create(stringReader))
            //{
            //    reader.ReadToFollowing(“price”);
            //    decimal price = decimal.Parse(reader.ReadInnerXml(),
            //    new CultureInfo(“en - US”)); // Make sure that you read the decimal part correctly
            //}


            // Using IndexOf and LastIndexOf

            //string value = "My Sample Value";
            //int indexOfp = value.IndexOf('p');
            //int lastIndexOfm = value.LastIndexOf('m');

            //Using StartsWith and EndsWith
            //string value = "<mycustominput>";
            //if (value.StartsWith("<")) { }
            //if (value.EndsWith(">")) { }

            ////Reading a Substring
            //string value = "My Sample Value";
            //string subString = value.Substring(3, 6);



            // Deserializing an object with the JavaScriptSerializer

            //Exporting a public key 

            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            //string publicKeyXML = rsa.ToXmlString(false);
            //string privateKeyXML = rsa.ToXmlString(true);
            //Console.WriteLine(publicKeyXML);
            //Console.WriteLine(privateKeyXML);

            ////Using a public and private key to encrypt and decrypt data
            //UnicodeEncoding ByteConverter = new UnicodeEncoding();
            //byte[] dataToEncrypt = ByteConverter.GetBytes("MySecretData");
            //byte[] encryptedData;
            //using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
            //{
            //    RSA.FromXmlString(publicKeyXML);
            //    encryptedData = RSA.Encrypt(dataToEncrypt, false);
            //}
            //byte[] decryptedData;
            //using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
            //{
            //    RSA.FromXmlString(privateKeyXML);
            //    decryptedData = RSA.Decrypt(encryptedData, false);
            //}
            //string decryptedString = ByteConverter.GetString(decryptedData);
            //Console.WriteLine(decryptedString);

            //Using a key container for storing an asymmetric key
            //string containerName ="SecretContainer";
            //CspParameters csp = new CspParameters() { KeyContainerName = containerName };
            //byte[] encryptedData;
            //using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider(csp))
            //{
            //    encryptedData = RSA.Encrypt(dataToEncrypt, false);
            //}

            ////Using SHA256Managed to calculate a hash code
            //UnicodeEncoding byteConverter = new UnicodeEncoding();
            //SHA256 sha256 = SHA256.Create();

            //string data ="A paragraph of text";
            //byte[] hashA = sha256.ComputeHash(byteConverter.GetBytes(data));

            //data ="A paragraph of changed text";
            //byte[] hashB = sha256.ComputeHash(byteConverter.GetBytes(data));

            //data ="A paragraphof text";

            //byte[] hashC = sha256.ComputeHash(byteConverter.GetBytes(data));
            //Console.WriteLine(hashA.SequenceEqual(hashB)); 
            //Console.WriteLine(hashA.SequenceEqual(hashC));

            //Initializing a SecureString
            //using (SecureString ss = new SecureString())
            //{
            //    Console.Write("Please enter password:");
            //    while (true)
            //    {
            //        ConsoleKeyInfo cki = Console.ReadKey(true);
            //        if (cki.Key == ConsoleKey.Enter) break;
            //        ss.AppendChar(cki.KeyChar);
            //        Console.Write("*");
            //    }
            //    ss.MakeReadOnly();
            //}

            //Getting the value of a SecureString

            // Using the Debug class
            //Debug.WriteLine("Startting application");
            //Debug.Indent();
            //int i = 1 + 2;
            //Debug.Assert(i == 3);
            //Debug.WriteLineIf(i > 0, "is is greater than 0");
            //Console.ReadLine();

            //// Using the TraceSource class
            //TraceSource traceSource = new TraceSource("myTraceSource", SourceLevels.All);
            //traceSource.TraceInformation("Tracingapplication..");
            //traceSource.TraceEvent(TraceEventType.Critical, 0,"Criticaltrace");
            //traceSource.TraceData(TraceEventType.Information, 1,
            //new object[] { "a", "b", "c" });
            //traceSource.Flush();
            //traceSource.Close();

            // Configuring Traceistener

            //Stream outputFile = File.Create("tracefile.txt");
            //TextWriterTraceListener textListener =
            //new TextWriterTraceListener(outputFile);
            //TraceSource traceSource = new TraceSource("myTraceSource",
            //SourceLevels.All);
            //traceSource.Listeners.Clear();
            //traceSource.Listeners.Add(textListener);
            //traceSource.TraceInformation("Traceoutput");
            //traceSource.Flush();
            //traceSource.Close();

            //    Stopwatch sw = new Stopwatch();
            //    sw.Start();
            //    Algorithm1();
            //    sw.Stop();
            //    Console.WriteLine(sw.Elapsed);

            //    sw.Reset();
            //    sw.Start();
            //    Algorithm2();
            //    sw.Stop();
            //    Console.WriteLine(sw.Elapsed);
            //    Console.WriteLine("Ready…");
            //    Console.ReadLine();
            //}
            //private static void Algorithm2()
            //{
            //    string result ="";
            //    for (int x = 0; x < numberOfIterations; x++)
            //    {
            //        result +='a';
            //    }
            //}
            //private static void Algorithm1()
            //{
            //    StringBuilder sb = new StringBuilder();
            //    for (int x = 0; x < numberOfIterations; x++)
            //    {
            //        sb.Append('a');
            //    }
            //    string result = sb.ToString();

            //        Thread t = new Thread(WriteX);
            //        t.Start();

            //        for (int i = 0; i < 1000; i++)
            //        {
            //            Console.Write("O");
            //        }

            //        Console.ReadLine();
            //    }

            //    static void WriteX()
            //    {
            //        for (int i = 0; i < 1000; i++)
            //        {
            //            Console.Write(".");
            //        }

            // Thread t = new Thread(Count);
            //    t.Start();

            //    Task task = Task.Run(() =>
            //    {
            //        for (int i = 0; i < 8; i++)
            //        {
            //            Thread.Sleep(500);
            //            Console.Write("BG ");
            //        }

            //    });


            //}

            //static void Count()
            //{
            //    for (int i = 0; i < 4; i++)
            //    {
            //        System.Threading.Thread.Sleep(500);
            //        Console.Write("FG ");
            //    }

            //        AsyncAwaitDemo demo = new AsyncAwaitDemo();
            //        demo.DoStuff();

            //        for (int i = 0; i < 100; i++)
            //        {
            //            Console.WriteLine("Working on the Main Thread.....");
            //        }
            //        Console.ReadKey();
            //    }


            //}

            //public class AsyncAwaitDemo
            //{
            //    public async Task DoStuff()
            //    {
            //        await Task.Run(() =>
            //        {
            //            CountToFifty();
            //        });
            //        // this will not execute until CountToFifty has completed
            //        Console.WriteLine("Counting to 50 is completed...");


            //    }

            //    private async Task<string> CountToFifty()
            //    {
            //        int counter;
            //        for (counter = 0; counter < 51;counter++)
            //        {
            //            Console.WriteLine("BG thread: " + counter);
            //        }

            //        return ("Counter = " + counter);


            ReadFile();
            Console.WriteLine("Preass enter to encrypt the file...");
            Console.ReadLine();

            EncryptFile(@"C:\test.txt");
            Console.WriteLine("Press enter to decrypt the file...");
            DecrytFile(@"C:\test.txt");
            Console.ReadKey();
        }

        public static void ReadFile()
        {
            int counter = 0;
            string line;

            // Read the file and display it line by line.

            StreamReader file = new StreamReader(@"C:\test.txt");
            while ((line = file.ReadLine()) != null)
            {
                Console.WriteLine(line);
            }
            counter++;
            file.Close();
        }

        public static void EncryptFile(string x)
        {
            File.Encrypt(x);
        }

        public static void DecrytFile(string x)
        {
            File.Decrypt(x);
        }
    }
  
}

       