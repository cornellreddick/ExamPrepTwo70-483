using System;
using System.Collections.Generic;
using System.Text;

namespace ExamPrepTwo70_483
{
    interface IExample
    {
        string GetResult();
        int Value { get; set; }
        event EventHandler ResultRetrieved;
        int this[string index] { get; set; }
    }

    class ExampleImplementation : IExample
    {
        public string GetResult()
        {
            return "result";
        }

        public int Value { get; set; }

        public event EventHandler ResultRetrieved;

        public int this[string index] { get { return 42; } set {} }
    }

    //Adding a set accessor to an implemented interface property
    interface IReadOnlyInteface
    {
        int Value { get; }
    }

    struct ReadAndWriteImplementation : IReadOnlyInteface
    {
        public int Value { get; set; }
    }

    //Creating an inteface with a generic type parameter
    interface IRepository<T>
    {
        T FindById(int id);
        IEnumerable<T> All();
    }
}
