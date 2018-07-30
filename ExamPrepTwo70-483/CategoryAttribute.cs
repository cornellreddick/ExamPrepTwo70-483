using System;
using System.Collections.Generic;
using System.Text;

namespace ExamPrepTwo70_483
{
    // Creating a custom attribute
    public class CategoryAttribute : TraitAttribute
    {
        public CategoryAttribute(string value) : base("Category", value)
        {

        }
    }

    public class UnitTraitAttribute : CategoryAttribute
    {
        public UnitTraitAttribute() : base("Unit Test")
        {

        }
    }

    //Defining the targets for a custom attribute

    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Parameter)]
    public class MyMethodAndParameterAttribute : Attribute { }

    // Setting the AllowMultiple parameter for a custom attribute 
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    class MyMultipleUsageAttribute : Attribute { }

    // Adding properties to a custom attribute

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    class CompleteCustomAttribute : Attribute
    {
        public string Description  { get; set; }

        public CompleteCustomAttribute(string description)
        {
            Description = description;
        }
    }
}
