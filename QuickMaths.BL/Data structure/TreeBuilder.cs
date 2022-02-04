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
        //ToDo: Найс нейминг - с, а, б еще не хватает п. Исправь во всем классе.
        public static Tree BuildTree(string s)
        {
            List<string> SummList = Split(s, '+');

            List<List<string>> MultipList = new List<List<string>>();

            //Делим слагаемые по умножению
            foreach (string func in SummList)
            {
                List<string> tmp = Split(func, '*');
                MultipList.Add(tmp);
            }
            Tree tree = new Tree();
            MultipList.Reverse();

            bool MergeCheck = false;
            foreach (var slog in MultipList)
            {
                for (int i = 0;i < slog.Count; i++)
                {
                    IFunction newFunc = GetFunc(slog[i]);

                    if (newFunc is NumberFunction)
                    {
                        if (i + 1 < slog.Count)
                        {
                            MergeCheck = true;
                            IFunction subFunc = GetFunc(slog[i + 1]);
                            NumberFunction oldFunc = (NumberFunction)newFunc;

                            if (subFunc is SimpleFunction)
                            {
                                if (subFunc is LinearFunction)
                                    newFunc = new LinearFunction(oldFunc.Digit);
                                else
                                    newFunc = new LinearFunction(oldFunc.Digit,new Tree(subFunc));
                            }
                            else
                            {
                                newFunc = new LinearFunction(oldFunc.Digit, subFunc.SubFunctionTree);
                            }
                        }
                    }

                    if (i == 0)
                        tree.AddNewSummandInRoot(newFunc);
                    else
                        tree.AddNewMultiplier(newFunc);

                    if (MergeCheck)
                    {
                        MergeCheck = false;
                        i++;
                    }
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
    }
}
