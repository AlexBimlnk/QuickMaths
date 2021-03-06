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
        private string stringEquals = "1";
        public Function(string _function) : base(_function)
        {
            stringEquals = _function;
        }
        public static void DS()
        {
            Console.WriteLine("REQ");
        }
        static bool is_complex(ref string s)
        {
            int fsk = s.IndexOf('(');
            int lsk = s.LastIndexOf(')');

            if (fsk == -1 || lsk == -1)
                return false;

            s = s.Substring(fsk + 1, lsk - fsk - 1);

            return true;
        }
        static List<string> split(string s, char c)
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

        static bool is_correct(ref string s)
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

        static TypeFuncion _GetType(string s)
        {
            if (s[s.Length - 1] == ')')
            {
                if (s[0] == '(')
                    return TypeFuncion.LinearFunction;
            }
            if (s.Length >= 3 && s.Substring(0, 3) == "log")
                return TypeFuncion.LogarithmicFunction;

            if (s[0] == 'e')
                return TypeFuncion.ExponentialFunction;

            if (s.Contains('^') == true)
                return TypeFuncion.PowerFunction;

            if (s[0] >= '0' && s[0] <= '9')
                return TypeFuncion.NumberFunction;

            if (s[0] == 'x')
                return TypeFuncion.LinearFunction;
            return TypeFuncion.Unkown;
        }

        static Tree f(string s)
        {
            List<string> a = split(s, '+');

            List<List<string>> b = new List<List<string>>();

            foreach (string func in a)
            {
                List<string> tmp = split(func, '*');
                b.Add(tmp);

                foreach (string test in tmp)
                {
                    string ttp = "";
                    switch (_GetType(test))
                    {
                        case TypeFuncion.Unkown:
                            ttp = "Hz";
                            break;
                        case TypeFuncion.ExponentialFunction:
                            ttp = "E^X";
                            break;
                        case TypeFuncion.LogarithmicFunction:
                            ttp = "Log X";
                            break;
                        case TypeFuncion.NumberFunction:
                            ttp = "C";
                            break;
                        case TypeFuncion.PowerFunction:
                            ttp = "x^n";
                            break;
                        case TypeFuncion.LinearFunction:
                            ttp = "x";
                            break;
                    }
                    Console.WriteLine($"{test} - {ttp}");
                }
            }
            Node head = null;


            int n = 0;
            foreach (var slog in b)
            {
                Node Line = null;

                foreach (var str in slog)
                {
                    Node t = new Node();
                    string tmpp = str;

                    t.Data = str;
                    t.Type = _GetType(str);
                    if (Line == null)
                        Line = t;
                    else
                        Line.Add(t, '+');

                }
                if (head == null)
                    head = Line;
                else
                    Line.Add(Line, '*');
            }
            return new Tree(head);
        }
    }
}
