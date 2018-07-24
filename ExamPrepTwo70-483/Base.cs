using System;
using System.Collections.Generic;
using System.Text;

namespace ExamPrepTwo70_483
{//Overriding a virtual method

    class Base
    {
        public virtual int MyMethod()
        {
            return 42;
        }
    }

    class Derived : Base
    {
        public sealed override int MyMethod() //Using the sealed keyword on a method 
        {
            return base.MyMethod() * 2;
                
        }
    }
    class Derived2 : Derived
    {
        // This line would give a compile error
        //public override int MyMethod() { return 1; }
    }
}

