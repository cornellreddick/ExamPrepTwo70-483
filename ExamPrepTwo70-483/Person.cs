using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ExamPrepTwo70_483
{
    class People
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public People(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public override string ToString()
        {
            return FirstName + " " + LastName;
        }


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
}
