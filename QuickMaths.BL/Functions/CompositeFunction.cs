using System;
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
        private string StringFunction = "";

        public Tree SubFunctionTree { get; set; }
        
        public CompositeFunction(Tree _Tree)
        {
            SubFunctionTree = _Tree;
        }

        public CompositeFunction(string function)
        {
            StringFunction = function;
            SubFunctionTree = TreeBuilder.BuildTree(function);
        }

        /*
         * Заменять константы на чилса (е = 2.7 и т.д)
         * Проставлять пропущенные знаки (умножение например)
         * Приводить функцию к нормальному виду иными словами
         * Метод всегда возращает true, смысл делать его булевым?
         * Лучше наверное сделать void и просто вызывать ее в конструкторе
         * А затем вызывать построение дерева
         * Уберем лишнюю проверку и сигнатуру метода
        */
        

        //ToDo: Реализовать алгоритм нахождения сложной функции.
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
            if (StringFunction == "")
            {
                StringFunction = (SubFunctionTree != null) ? SubFunctionTree.ToString() : StringFunction;
            }
            return StringFunction;
        }
    }
}
