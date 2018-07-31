using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;



namespace ExamPrepTwo70_483
{
    [Serializable]
    class People
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        //Applying an attribute
        
        public People(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public override string ToString()
        {
            return FirstName + " " + LastName;
        }

        // Using multipe attributes. The ConditionalAttribues allow you to list multiple condition for a method. 
        [Conditional("Condition1") , Conditional("Conditionion2")]
        static void MyMethod() { }
    }

    class Human : IEnumerable<People>
    {
        People[] people;

        public Human(People[] people)
        {
            this.people = people;
        }

        public IEnumerator<People> GetEnumerator()
        {
            for (int index = 0; index < people.Length; index++)
            {
                yield return people[index];
            };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

   
    }

    public interface IDisposable
    {
        void Dispose();
    }
    //[Serializable]
    //class AttributeClass
    //{ }
    //    if (Attribute.IsDefine(typeof(AttributeClass), typeof(SerializableAttribute))) {}

    // Getting a specific attribute instance

    //ConditionalAttribute conditionalAttribute = (ConditionalAttribute)Attribute.GetCustomAttribute(typeof(ConditionalClass), typeof(ConditionalAttribute).First();

    //Using a category attribute in xUnit

    //[Fact]
    //[Trait("category", "Unit Test")]
    //public void MyUnitTest()
    //{ }

    //[Fact]
    //[Trait(“Category”, “Integration Test”)]
    //public void MyIntegrationTest()
    //{ }



}
