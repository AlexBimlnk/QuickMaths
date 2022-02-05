using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuickMaths.BL.Functions;
using QuickMaths.BL.Enums;
using QuickMaths.BL.Validation;

namespace QuickMaths.BL.DataStructure
{
    public static class TreeBuilder
    {
        public static Tree BuildTree(string s)
        {
            List<List<string>> funcList = new List<List<string>>();
            Split(s, '+').ForEach(func => funcList.Add(Split(func, '*')));

            bool merged = false;
            Tree tree = new Tree();
            funcList.Reverse();

            //Перебираем слагаемые в сложной функции ()+()+()
            foreach (var slog in funcList)
            {
                //Перебираем множители ()*()*()
                for (int i = 0; i < slog.Count; i++)
                {
                    IFunction currentFunc = GetFunc(slog[i]);

                    //Если функция числовая
                    if (currentFunc is NumberFunction && i + 1 < slog.Count)
                    {
                        IFunction nextFunction = GetFunc(slog[i + 1]);

                        //Если следующая функция линейная - склеиваем функцию
                        if(nextFunction is LinearFunction)
                        {
                            currentFunc = new LinearFunction(((NumberFunction)currentFunc).Digit);
                            merged = true;
                        }

                        //Если сложная, то представляем как сложную линейную
                        if(nextFunction is CompositeFunction)
                        {
                            currentFunc = new LinearFunction(((NumberFunction)currentFunc).Digit, nextFunction.SubFunctionTree);
                            merged = true;
                        }
                    }

                    if (i == 0)
                        tree.AddNewSummandInRoot(currentFunc);
                    else
                        tree.AddNewMultiplier(currentFunc);

                    if (merged)
                    {
                        merged = false;
                        i++;
                    }
                }
            }
            return tree;
        }

        public static IFunction GetFunc(string functionString)
        {
            if (functionString[0] == '(' && functionString[functionString.Length - 1] == ')')
            {
                IsComplex(ref functionString);
                return new CompositeFunction(functionString);
            }
                
            if (functionString.Length >= 3 && functionString.Substring(0, 3) == "log")
                return new LogarithmicFunction(functionString);

            if (functionString[0] == 'e')
                return new ExponentialFunction(functionString);


            if (functionString.Contains('^') == true)
                return new PowerFunction(functionString);

            if (functionString[0] >= '0' && functionString[0] <= '9')
                return new NumberFunction(functionString);

            return new LinearFunction(functionString);
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



        private static List<string> Split(string s, char c)
        {
            s += c;
            int start = 0;
            List<string> ans = new List<string>();
            int skobkaCheck = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                    skobkaCheck++;
                if (s[i] == ')')
                    skobkaCheck--;

                if (skobkaCheck == 0)
                {
                    if (s[i] == c)
                    {
                        string tmp = s.Substring(start, i - start);
                        ans.Add(tmp);
                        start = i + 1;
                    }
                }
            }

            return ans;
        }
    }
}
