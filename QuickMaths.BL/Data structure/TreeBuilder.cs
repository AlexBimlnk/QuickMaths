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
    //ToDo: Заменить + и прочие символы на флаги из перечисления
    public static class TreeBuilder
    {
        public static Tree BuildTree(string s)
        {
            List<string> a = Split(s, '+');

            List<List<string>> b = new List<List<string>>();

            //Делим слагаемые по умножению
            foreach (string func in a)
            {
                List<string> tmp = Split(func, '*');
                b.Add(tmp);
            }

            Tree tree = new Tree();
            b.Reverse();
            foreach (var slog in b)
            {
                IFunction newFunc = GetFunc(slog[0]);
                tree.AddNewSummand(newFunc);
                for (int i = 1; i < slog.Count; i++)
                {
                    newFunc = GetFunc(slog[i]);
                    tree.AddNewMultiplier(newFunc);
                }
            }
            return tree;
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

        public static IFunction GetFunc(string FunctionString)
        {
            SimpleFunction function;
            
            if (FunctionString[FunctionString.Length - 1] == ')' && FunctionString[0] == '(')
                function = new LinearFunction(FunctionString);

            else if (FunctionString.Length >= 3 && FunctionString.Substring(0, 3) == "log")
                function = new LogarithmicFunction(FunctionString);

            else if (FunctionString[0] == 'e')
                function = new ExponentialFunction(FunctionString);


            else if (FunctionString.Contains('^') == true)
                function = new PowerFunction(FunctionString);

            else if (FunctionString[0] >= '0' && FunctionString[0] <= '9')
                function = new NumberFunction(FunctionString);

            else //if (FunctionString[0] == 'x')
                function = new LinearFunction(FunctionString);

            return function;           
        }

        public static bool IsComplex(ref string s)
        {
            int firstSk = s.IndexOf('(');
            int lastSk = s.LastIndexOf(')');

            if (firstSk == -1 || lastSk == -1)
                return false;

            s = s.Substring(firstSk + 1, lastSk - firstSk - 1);

            return true;
        }

    }
}
