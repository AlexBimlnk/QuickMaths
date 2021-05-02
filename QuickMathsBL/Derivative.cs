using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickMathsBL
{
    public static class Derivative  //Производная
    {
        /// <summary>
        /// Возвращает производную от функции.
        /// </summary>
        /// <param name="simpleFunction"> Простая функция, от которой нужно найти производную. </param>
        /// <returns> Возвращает производную функции. </returns>
        public static SimpleFunction GetDerivative(SimpleFunction simpleFunction)
        {
            SimpleFunction answer = null;
            switch (simpleFunction.TypeFunction)
            {
                case SimpleFunction.TypeFuncion.NumberFunction:
                    answer = new SimpleFunction("0", SimpleFunction.TypeFuncion.NumberFunction);
                    break;

                case SimpleFunction.TypeFuncion.LinearFunction:
                    answer = new SimpleFunction($"{simpleFunction.Digit}", SimpleFunction.TypeFuncion.NumberFunction);
                    break;

                case SimpleFunction.TypeFuncion.PowerFunction:
                    answer = new SimpleFunction($"{simpleFunction.Digit}*{simpleFunction.FunctionString.Split('^')[0]}^{simpleFunction.Digit-1}", SimpleFunction.TypeFuncion.NumberFunction);
                    break;

                //Не помню
                case SimpleFunction.TypeFuncion.ExponentialFunction:
                    break;

                //Мы знаем производную только от натурального логарифма...
                case SimpleFunction.TypeFuncion.LogarithmicFunction:
                    break;
            }

            return answer;
        }

        /// <summary>
        /// Вовзращает производную в виде строки.
        /// </summary>
        /// <param name="functionTree"> Дерево простых функций. </param>
        /// <returns> Производную дерева функций. </returns>
        public static string GetDerivative(Tree functionTree)
        {
            List<Node> plusWayList = functionTree.CreatePlusWayList();

            StringBuilder stringBuilder = new StringBuilder();

            for(int i = 0; i<plusWayList.Count; i++)
            {
                //(x*y*z)' =  x'yz+xy'z+xyz'
                //(x*y*z*k)' = x'yzk+xy'zk+xyz'k + xyzk'
                //Что делать с суб. деревом у функции, как его диф?
                Node node = plusWayList[i];


                if (node.SubFuncTree != null)
                    stringBuilder.Append($"({GetDerivative(node.SubFuncTree)})");

                if(node.MultyWay != null)
                {
                    stringBuilder.Append("(");
                    List<Node> multyWayList = functionTree.CreateMultyWayList(node);
                    List<Node> temp = new List<Node>();
                    for (int j = 0; j < multyWayList.Count; j++)
                    {
                        string derivativeFunction = GetDerivative(multyWayList[j].Data).FunctionString;
                        
                        if (derivativeFunction == "0")
                        {
                            if (stringBuilder[stringBuilder.Length - 1] == '+')
                                stringBuilder.Remove(stringBuilder.Length - 1, 1);
                            continue;
                        }
                        
                        stringBuilder.Append($"{derivativeFunction}");
                        temp = multyWayList.Where((k) => multyWayList.IndexOf(k) != j).ToList();
                        foreach(var nodes in temp)
                        {
                            stringBuilder.Append($"*{nodes.Data.FunctionString}");
                        }
                        if (j != multyWayList.Count - 1)
                            stringBuilder.Append("+");
                    }
                    stringBuilder.Append(")");
                }

                if (node.MultyWay == null)
                    stringBuilder.Append($"({GetDerivative(node.Data).FunctionString})");

                if (i != plusWayList.Count - 1)
                    stringBuilder.Append("+");
            }

            return stringBuilder.ToString();
        }

        /// <summary>
        /// Возвразает производную в виде строки.
        /// </summary>
        /// <param name="function"> Объект типа "функция". </param>
        /// <returns> Производную по функции. </returns>
        public static string GetDerivative(Function function)
        {
            return GetDerivative(function.FunctionTree);
        }
    }
}
