using System;
using System.Collections.Generic;
using System.Text;

namespace ExamPrepTwo70_483
{
    public class Product
    {
        //Creating an extension method
        public decimal Price { get; set;  }
    }

    public static class MyExtensions
    {
        public static decimal Discount(this Product product)
        {
            return product.Price * .9M; 
        }
    }

    public class Calculator
    {
        public decimal CalculateDiscount(Product p)
        {
            return p.Discount();
        }

    }
}
