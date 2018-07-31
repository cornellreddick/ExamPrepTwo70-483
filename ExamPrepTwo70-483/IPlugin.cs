using System;
using System.Collections.Generic;
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
}
