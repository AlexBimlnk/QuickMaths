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

        

        public CompositeFunction(Tree tree)
        {
            _functionTree = tree;
        }
        public CompositeFunction(string function)
        {
            _stringFunction = function;
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
            if (_stringFunction == String.Empty)
            {
                _stringFunction = (_functionTree != null) ? _functionTree.ToString() : _stringFunction;
            }
            return _stringFunction;
        }
    }
}
