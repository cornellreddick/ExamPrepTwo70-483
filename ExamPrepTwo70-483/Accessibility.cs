using System;
using System.Collections.Generic;
using System.Text;

namespace ExamPrepTwo70_483
{
    class Accessibility
    {
        // Changing a private field without outside users noticing

        private string[] _myField;

        public string MyProperty
        {
            get { return _myField[0]; }
            set { _myField[0] = value; }

        }

        //Implemepting an interface explicitly 
        interface IInterfaceA
        {
            void MyMethod();
        }
        class Implementation : IInterfaceA
        {
            public void MyMethod()
            {
                throw new NotImplementedException();
            }
        }

        interface IRight
        {
            void Move();
        }

        interface ILeft
        {
            void Move();
        }

        class MoveableOject : ILeft, IRight
        {
           void IRight.Move() { }
           void ILeft.Move() { }
        }

    }

    internal class MyInternalClass
    {
        // Using the internal acces modifier
        public void MyMethod() { }
    }
}


