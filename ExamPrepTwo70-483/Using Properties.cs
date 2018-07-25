using System;
using System.Collections.Generic;
using System.Text;

namespace ExamPrepTwo70_483
{
    class Using_Properties
    {
        private int _field;
        public void SetValue(int value)
        {
            _field = value;
        }

        public int GetValue()
        {
            return _field;
        }
    }

    class Person
    {
        private string _firstName;

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException();
                _firstName = value;
            }
        }
    }
}
