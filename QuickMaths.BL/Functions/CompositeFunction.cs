﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuickMaths.BL.DataStructure;

namespace QuickMaths.BL.Functions
{
    //TODO: Класс "Функция"
    public class CompositeFunction : IFunction
    {
        private string _stringFunction = String.Empty;
        private Tree _functionTree;

        
        public CompositeFunction(Tree tree)
        {
            _functionTree = tree;
        }
        public CompositeFunction(string function)
        {
            _stringFunction = function;
            _functionTree = TreeBuilder.BuildTree(function);
        }


        public Tree SubFunctionTree { get { return _functionTree; } }
        public List<IFunction> Arguments => throw new NotImplementedException();


        public double Calculate()
        {
            throw new NotImplementedException();
        }
        public IFunction Derivative()
        {
            if (SubFunctionTree != null)
            { 
                return new CompositeFunction(SubFunctionTree.GetDerivative());
            }
            return null;
        }
        public override string ToString()
        {
            if (_stringFunction == String.Empty)
            {
                _stringFunction = (SubFunctionTree != null) ? SubFunctionTree.ToString() : _stringFunction;
            }
            return _stringFunction;
        }
    }
}
