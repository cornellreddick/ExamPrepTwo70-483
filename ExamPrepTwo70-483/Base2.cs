using System;
using System.Collections.Generic;
using System.Text;

namespace ExamPrepTwo70_483
{
    public class Base2
    {
        private int _privateField = 42;
        protected int _protectedField = 42;

        private void MyPrivateMethod() { }
        protected void MyprotectedMehtod() { }
    }

    public class DerivedA : Base2// protected allow access to derived classes. 
    {
        public void MyDerivedMethod()
        {
            _protectedField = 43;
           // _privateField = 41;

            MyprotectedMehtod();
            //MyPrivateMehtod();
        }
        
    }
}
