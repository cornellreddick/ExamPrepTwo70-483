using System;
using System.Collections.Generic;
using System.Text;

namespace ExamPrepTwo70_483
{
    class Order : IComparable
    {
        public DateTime Created { get; set; }

        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                return 1;
            }

            Order o = obj as Order;

            if (o == null)
            {
                throw new ArgumentException("Object is not and Order");
            }

            return this.Created.CompareTo(o.Created);
        }
    }

}
