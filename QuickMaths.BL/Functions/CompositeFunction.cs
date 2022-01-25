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
        private string _functionToString;

        public Tree SubFunctionTree { get; set; }

        public CompositeFunction(string function)
        {
            _functionToString = function;
            if (IsCorrect(ref function))
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

        //ToDo: Реализовать алгоритм нахождения сложной функции.
        public IFunction Derivative()
        {
            //List<Node> plusWayList = FunctionTree.CreatePlusWayList();

            //StringBuilder stringBuilder = new StringBuilder();

            //for (int i = 0; i < plusWayList.Count; i++)
            //{
            //    //(x*y*z)' =  x'yz+xy'z+xyz'
            //    //(x*y*z*k)' = x'yzk+xy'zk+xyz'k + xyzk'
            //    //Что делать с суб. деревом у функции, как его диф?
            //    Node node = plusWayList[i];

            //    //ToDo: Расчет производной суб дерева.
            //    if (node.SubFuncTree != null)
            //        //stringBuilder.Append($"({GetDerivative(node.SubFuncTree)})");

            //    if (node.MultyWay != null)
            //    {
            //        stringBuilder.Append("(");
            //        List<Node> multyWayList = FunctionTree.CreateMultyWayList(node);
            //        List<Node> temp = new List<Node>();
            //        for (int j = 0; j < multyWayList.Count; j++)
            //        {
            //            string derivativeFunction = GetDerivative(multyWayList[j].Data);

            //            if (derivativeFunction == "0")
            //            {
            //                if (stringBuilder[stringBuilder.Length - 1] == '+')
            //                    stringBuilder.Remove(stringBuilder.Length - 1, 1);
            //                continue;
            //            }

            //            stringBuilder.Append($"{derivativeFunction}");
            //            temp = multyWayList.Where((k) => multyWayList.IndexOf(k) != j).ToList();
            //            foreach (var nodes in temp)
            //            {
            //                stringBuilder.Append($"*{nodes.Data.FunctionString}");
            //            }
            //            if (j != multyWayList.Count - 1)
            //                stringBuilder.Append("+");
            //        }
            //        stringBuilder.Append(")");
            //    }

            //    if (node.MultyWay == null)
            //        stringBuilder.Append($"({GetDerivative(node.Data)})");

            //    if (i != plusWayList.Count - 1)
            //        stringBuilder.Append("+");
            //}

            //return new Function(stringBuilder.ToString());

            throw new NotImplementedException();
        }
    }
}
