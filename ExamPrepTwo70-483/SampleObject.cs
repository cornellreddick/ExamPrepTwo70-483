using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace ExamPrepTwo70_483
{
    //creating a custom DynamicObject 
    public class SampleObject : DynamicObject 
    {
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            result = binder.Name;
            return true;
        }
    }
}
