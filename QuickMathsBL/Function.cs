using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickMathsBL
{
    public class Function
    {
        //TODO
        private string functionString;

        private Tree functionTree;

        public Function(string _function)
        {            
            functionString = _function;
            if (IsCorrect(ref _function))
                functionTree = TreeBuilder.BuildTree(_function);
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
        private static bool IsCorrect(ref string s)
        {
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == ' ')
                {
                    s = s.Remove(i, 1);
                    i--;
                }
            }
            return true;
        }

        public string GetFunctionString
        {
            get { return functionString; }
        }
    }
}
