using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickMathsBL
{
    public abstract class ConsoleHelper
    {
        public enum Command
        {
            HELP,
            EXIT,
            CLEAR,
            CREATE
        }

        private static Dictionary<string, string> commandDict = new Dictionary<string, string>()
        {
            {"HELP", "Write all command in console." },
            {"EXIT", "Close ConsoleHelper." },
            {"CLEAR", "Clear console." },
            {"CREATE", "This function can create different object of classes." }
        };


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
            if (command.ToUpper() == Command.HELP.ToString())
                Help();
            else if (command.ToUpper() == Command.CLEAR.ToString())
                Console.Clear();
            else if (command.ToUpper() == Command.EXIT.ToString())
                Exit();
            else if (command.ToUpper() == Command.CREATE.ToString())
                Create();
            else
            {
                Console.WriteLine($"Command {command} incorrect.\n");
                return;
            }
            Console.WriteLine($"Command {command} is complete\n");
        }

        private static void Create()
        {

        }

        private static void Help()
        {
            foreach (var i in commandDict)
            {
                Console.WriteLine($"\tCommand {i.Key}");
                Console.WriteLine($"\t\t{i.Value}\n");
            }
        }

        private static void Exit()
        {
            life = false;
        }
    }
}
