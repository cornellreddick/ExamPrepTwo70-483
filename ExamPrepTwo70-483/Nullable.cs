﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ExamPrepTwo70_483
{
    // Generic Nullable<T> implementation 
    struct Nullable<T> where T : struct
    {
        private bool hasValue;
        private T value;

        public Nullable(T value)
        {
            this.hasValue = true;
            this.value = value;
        }

        public bool HasValue { get { return this.hasValue; } }

        public T Value
        {
            get
            {
                if (!this.HasValue)
                
                    throw new ArgumentException();
                    return this.value;
            }
        }

        public T GetValueOrDefault()
        {
            return this.value;
        }
    }
}
