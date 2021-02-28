using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickMathsBL
{
    public abstract class ConsoleHelper
    {

        private static Dictionary<string, Action> commandDict = new Dictionary<string, Action>()
        {
            {"HELP|Write all command in console.", Help },
            {"EXIT|Close ConsoleHelper.", Exit },
            {"CLEAR|Clear console.", (Action)(()=>Console.Clear()) },
            {"CREATE|This function can create different object of classes.", Create },
            {"RETURN VARIABLE|Write list of all created variable", ReturnVariable}
        };

        private static Dictionary<string, string> classesDict = new Dictionary<string, string>()
        {
            {"SF", "SimpleFunction" },
            {"F", "Function" }
        };

        private static Dictionary<string, object> variableDict = new Dictionary<string, object>();

        private static bool life = true;

        public static void Start()
        {
            Process();
        }

        private static void Process()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Console Helper. Command help write list command\n");
            while (life)
            {
                string command = Console.ReadLine();
                Console.WriteLine();
                SearchCommand(command);
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static void SearchCommand(string command)
        {
            bool find = false;
            foreach(var i in commandDict)
            {
                string[] info = i.Key.Split('|');
                string nameCommand = info[0];
                if(command.ToUpper() == nameCommand)
                {
                    find = true;
                    i.Value();
                    break;
                }
            }

            if(!find)
            {
                Console.WriteLine($"Command {command} incorrect.\n");
                return;
            }
            Console.WriteLine($"Command {command} is complete\n");
        }

        private static void ReturnVariable()
        {
            foreach(var i in variableDict)
                Console.WriteLine($"\tVariable name: {i.Key} Class: {i.Value.GetType()}\n");
        }

        private static void Create()
        {
            foreach (var i in classesDict)
                Console.WriteLine($"\tClass key: {i.Key}, class name: {i.Value}\n");
            Console.Write("\t\tWrite need key: ");
            string className = Console.ReadLine();
            bool find = false;
            foreach (var i in classesDict)
            {
                if (className.ToUpper() == i.Key)
                {
                    find = true;
                    break;
                }
            }
            if (find)
            {
                Console.Write("\t\tWrite name of object class SF: ");
                string variableName = Console.ReadLine();
                Console.Write("\t\tWrite koef: ");
                string functionName = Console.ReadLine();
                object item = default;

                if (className.ToUpper() == "SF")
                    item = new SimpleFunction(functionName);

                if (className.ToUpper() == "F")
                    item = new Function(functionName);

                variableDict.Add(variableName, item);
            }
            else
                Console.WriteLine($"\tKey {className} incorrect.\n");
        }

        private static void Help()
        {
            foreach (var i in commandDict)
            {
                string[] info = i.Key.Split('|');
                Console.WriteLine($"\tCommand {info[0]}");
                Console.WriteLine($"\t\t{info[1]}\n");
            }
        }

        private static void Exit()
        {
            life = false;
        }
    }
}
