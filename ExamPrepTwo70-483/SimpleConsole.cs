using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using System.Threading;

namespace ExamPrepTwo70_483
{
    class SimpleConsole
    {
        //Applying the ConditionalAttribute
        [Conditional("DEBUG")]
        private static void Log(string message)
        {
            Console.WriteLine("mdessage");
        }

        //Applying the DebuggerDisplayAttribute
        [DebuggerDisplay("Name ={FirstName} {LastName}")]
        public class Person
        {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        }
        
    }


}   
