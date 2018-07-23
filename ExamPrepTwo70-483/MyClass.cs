using System;
using System.Collections.Generic;
using System.Text;

namespace ExamPrepTwo70_483
{
    //using a where clause on a class definition
    class MyClass<T> where T : class, new()
    {
        public MyClass()
        {
            MyProperty = new T();
        }

        T MyProperty { get; set; }
    }
}
