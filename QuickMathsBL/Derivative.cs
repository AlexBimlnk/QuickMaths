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
        /// Возвращает производную от простой функции в виде строки.
        /// </summary>
        /// <param name="simpleFunction"> Простая функция, от которой нужно найти производную. </param>
        /// <returns> Возвращает производную функции. </returns>
        public static string GetDerivative(SimpleFunction simpleFunction)
        {
            string answer = "";
            switch (simpleFunction.TypeFunction)
            {
                case SimpleFunction.TypeFuncion.NumberFunction:
                    answer = "0";
                    break;

                case SimpleFunction.TypeFuncion.LinearFunction:
                    answer = $"{simpleFunction.Digit}";
                    break;

                case SimpleFunction.TypeFuncion.PowerFunction:
                    answer = $"{simpleFunction.Digit}*{simpleFunction.FunctionString.Split('^')[0]}^{simpleFunction.Digit-1}";
                    break;

                case SimpleFunction.TypeFuncion.ExponentialFunction:
                    answer = $"{simpleFunction.Digit}^{simpleFunction.FunctionString.Split('^')[1]}*ln({simpleFunction.Digit})";
                    break;

                case SimpleFunction.TypeFuncion.LogarithmicFunction:
                    answer = $"({simpleFunction.FunctionString.Substring(5, simpleFunction.FunctionString.IndexOf(')') - 5)}" +
                             $"*loge({simpleFunction.Digit}))^(-1)";
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
                        string derivativeFunction = GetDerivative(multyWayList[j].Data);
                        
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
                    stringBuilder.Append($"({GetDerivative(node.Data)})");

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
