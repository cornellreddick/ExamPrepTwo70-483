using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ExamPrepTwo70_483
{
    public interface IPlugin
        //Creating an interface that can be found thorough reflection
    {
        string Name { get; }
        string Description { get; }
        bool Load(MyApplication application);
    }

    public class MyPlugin : IPlugin
    {
        public string Name => throw new NotImplementedException();

        public string Description => throw new NotImplementedException();

        public bool Load(MyApplication application)
        {
            throw new NotImplementedException();
        }
    }

    public class Reflection
    {
        // Getting the value of a field thorugh reflection
        static void DumpObject(object obj)
        {
            FieldInfo[] fields = obj.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic);

            foreach (FieldInfo field in fields)
            {
                Console.WriteLine(field.GetValue(obj));
            }
        }
        
    }
}
