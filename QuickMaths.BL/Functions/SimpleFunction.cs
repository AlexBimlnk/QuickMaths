﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickMaths.BL.Functions
{
    internal abstract class SimpleFunction : IFunction
    {
        protected Tree subFunctionTree;

        public long Digit { get; protected set; }

        public char Variable { get; protected set; }

        public Tree SubFunctionTree { get; protected set; }

        public SimpleFunction() { }

        public SimpleFunction(long digit)
        {
            Digit = digit;
        }

        public abstract IFunction Derivative();
    }
}
