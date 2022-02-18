using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuickMaths.BL.Functions;
using QuickMaths.BL.Enums;
using QuickMaths.BL.Validation;
using System.Text.RegularExpressions;

namespace QuickMaths.BL.DataStructure
{
    public static class TreeBuilder
    {
        public static Tree BuildTree(string s)
        {
            Tree summands = null;
            IsCorrect(ref s);
            List<string> tmpSummdsLisr = Split(s, "+-"); // разбиение строки по + или -

            for(int i = 0;i < tmpSummdsLisr.Count;i++)
            {
                bool useReversePlusOperator = false;
                if (tmpSummdsLisr[i][0] == '!') // проверка нужно ли использовать - для связи слогаемых
                {
                    useReversePlusOperator = true;
                    tmpSummdsLisr[i] = tmpSummdsLisr[i].TrimStart('!');
                }

                List<string> tmpMultipList = Split(tmpSummdsLisr[i], "*/"); // разбиение строки по * или /
                Tree multipliers = null; 

                for (int y = 0;y < tmpMultipList.Count;y++)
                {
                    bool useRevMultOperator = false;

                    if (tmpMultipList[y][0] == '!') // проверка нужно ли использовать / для связи множителей
                    {
                        useRevMultOperator = true;
                        tmpMultipList[y] = tmpMultipList[i].TrimStart('!');
                    }

                    IFunction newFunc = GetFunc(tmpMultipList[y]); 

                    if (i == 0 && useReversePlusOperator) // обработка исключения когда - стоит в начале уравнения т.е. он используется как унарный оперетор
                    {
                        Tree.Merge(multipliers, new Tree(newFunc), MathOperation.Minus);
                        useReversePlusOperator=false;
                        continue;
                    }

                     multipliers = Tree.Merge(multipliers, new Tree(newFunc), ((useRevMultOperator) ? MathOperation.Divide : MathOperation.Multiply)); // объединени множителей с учётом их связи
                }

                summands = Tree.Merge(summands, multipliers, ((useReversePlusOperator) ? MathOperation.Minus : MathOperation.Plus)); // объединение слогаемых с учётом их связи
            }

            return summands;
        }
        public static IFunction GetFunc(string functionString)
        {
            //ToDo регулярные выражения
            Regex patCompos = new Regex(@"");
            Regex patLinear = new Regex(@"");
            Regex patNumber = new Regex(@"");
            Regex patVariable = new Regex(@"");

            
            if (functionString[0] == '(' && functionString[functionString.Length - 1] == ')')
            {
                IsComplex(ref functionString);
                return new CompositeFunction(functionString);
            }
                
            //if (functionString.Length >= 3 && functionString.Substring(0, 3) == "log")
            //    return new LogarithmicFunction(functionString);

            ////Некорректное определение показательной функции.
            //if (functionString[0] == 'e')
            //    return new ExponentialFunction(functionString);


            //if (functionString.Contains('^') == true)
            //    return new PowerFunction(functionString);

            if(functionString == "x")
                return new Variable(functionString);

            if (functionString[0] >= '0' && functionString[0] <= '9')
                return new NumberFunction(functionString);

            return new LinearFunction(functionString, new CompositeFunction(functionString));
        }
        public static bool IsComplex(ref string s)
        {
            int firstSk = s.IndexOf('(');
            int lastSk = s.LastIndexOf(')');

            if (firstSk == -1 || lastSk == -1)
                return false;

            s = s.Substring(firstSk + 1, lastSk - firstSk - 1);

            if (!(s[0] >= '0' && s[0] <= '9') || !s.Contains('(') || !s.Contains('+') || !s.Contains('*') || !s.Contains('^'))
                return false;

            return true;
        }
        public static bool IsCorrect(ref string s)
        {
            s = s.Replace(" ", String.Empty);
            return true;
        }

      
        private static List<string> Split(string s, string chars)
        {
            if (s[0] != chars[1]) // для придания строки вида "<оператор>(текст)<оператор>...<оператор>(текст)<оператор>"
                s = chars[0] + s;
            s += chars[0];

            int start = 0;
            List<string> ans = new List<string>();
            
            int skobkaCheck = 0;
            
            for (int i = 1; i < s.Length; i++)
            {
                if (s[i] == '(')
                    skobkaCheck++;
                if (s[i] == ')')
                    skobkaCheck--;

                if (skobkaCheck == 0)
                {
                    for (int y = 0; y < chars.Length; y++)
                    {
                        if (s[i] == chars[y])
                        {
                            string tmp = ((s[start] == chars[1]) ? "!" : "");

                            tmp += s.Substring(start + 1, i - start - 1);
                            ans.Add(tmp);

                            start = i;
                            break;
                        }
                    }
                }
            }

            return ans;
        }
    }
}
