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
}
