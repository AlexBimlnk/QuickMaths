using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuickMaths.BL.DataStructure;

namespace QuickMaths.BL.Functions
{
    //TODO: Класс "Функция"
    /// <summary>
    /// Составная функция.
    /// </summary>
    public class CompositeFunction : IFunction
    {
        private string _stringFunction = String.Empty;
        private Tree _functionTree;

        

        internal CompositeFunction(Tree tree)
        {
            _functionTree = tree;
        }
        public CompositeFunction(string function)
        {
            if (function == String.Empty)
                throw new ArgumentException("function");

            _stringFunction = function ?? throw new ArgumentNullException("function");
            _functionTree = TreeBuilder.BuildTree(function);
        }



        public double Calculate()
        {
            throw new NotImplementedException();
        }
        public IFunction Derivative()
        {
            if (_functionTree != null)
            { 
                return new CompositeFunction(_functionTree.GetDerivative());
            }
            return null;
        }
        public override string ToString()
        {
            //if (_stringFunction == String.Empty)
            //{
            //    _stringFunction = (_functionTree != null) ? _functionTree.ToString() : _stringFunction;
            //}
            return String.Format("({0})", (_functionTree != null) ? _functionTree.ToString() : _stringFunction); 
        }
    }
}
