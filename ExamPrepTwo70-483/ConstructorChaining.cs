using System;
using System.Collections.Generic;
using System.Text;

namespace ExamPrepTwo70_483
{
    class ConstructorChaining
    {
        //Chaining constructors
        private int _p;

        public ConstructorChaining() : this(3)
        {

        }
        public ConstructorChaining(int p)
        {
            this._p = p; 
        }

           
    }
}
