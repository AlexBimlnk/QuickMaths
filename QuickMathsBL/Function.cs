using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickMathsBL
{
    public class Function : SimpleFunction
    {
        //TODO
        public string FunctionString { get; set; }

        private Tree functionTree;

        public Function(string _function) : base(_function)
        {
            FunctionString = _function;
            if (IsCorrect(ref _function))
                functionTree = BuildTree(_function);
        }

        private static bool IsComplex(ref string s)
        {
            int fsk = s.IndexOf('(');
            int lsk = s.LastIndexOf(')');

            if (fsk == -1 || lsk == -1)
                return false;

            s = s.Substring(fsk + 1, lsk - fsk - 1);

            return true;
        }

        private static List<string> Split(string s, char c)
        {
            s += c;
            int start = 0;
            List<string> ans = new List<string>();
            int skobka_check = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                    skobka_check++;
                if (s[i] == ')')
                    skobka_check--;

                if (skobka_check == 0)
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
   
        private static Tree BuildTree(string s)
        {
            List<string> a = Split(s, '+');

            List<List<string>> b = new List<List<string>>();

            //Делим слагаемые по умножению
            foreach (string func in a)
            {
                List<string> tmp = Split(func, '*');
                b.Add(tmp);
            }

            Node head = null;

            foreach (var slog in b)
            {
                Node Line = new Node(new SimpleFunction(slog[0]));

                for (int i = 1; i <slog.Count; i++)
                {
                    Node node = new Node(new SimpleFunction(slog[i]));

                    //Если фун-ция сложная, строим для нее дерево
                    string tmpp = slog[i];
                    if(IsComplex(ref tmpp))
                        node.SubFuncTree = BuildTree(tmpp);

                    Line.Add(node, true);
                }
                if (head == null)
                    head = Line;
                else
                    head.Add(Line, false);
            }
            return new Tree(head);
        }
    }
}
