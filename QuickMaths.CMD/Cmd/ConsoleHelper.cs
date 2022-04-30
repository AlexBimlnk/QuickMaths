using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuickMaths.FunctionsBLL.Functions;

namespace QuickMaths.CMD.Cmd
{
    public static class ConsoleHelper
    {
        private static Dictionary<string, IFunction> _functions = new Dictionary<string, IFunction>();
        private static IReadOnlyDictionary<string, Command> _commands = CommandsStorage.Commands;


        public static Dictionary<string, IFunction> Functions { get { return _functions; } }
        public static bool IsWork { get; internal set; } = true;


        private static void InvokeCommand(Command command)
        {
            Console.WriteLine($"\nRun command {command.Name}...\n");
            command.Action.Invoke();
            Console.WriteLine($"\nCommand {command.Name} is complete\n\n");
        }

        private static void SearchCommand(string? inputCommand)
        {
            Console.WriteLine();
            
            if (inputCommand != null && inputCommand != String.Empty)
            {
                if (_commands.TryGetValue(inputCommand.ToUpper(), out Command? command))
                {
                    InvokeCommand(command);
                    return;
                }
            }
            Console.WriteLine($"Command {inputCommand} incorrect.\n");

            Console.WriteLine();
        }

        public static void Start()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Console Helper. Command \"help\" write list command\n");
            string? command = String.Empty;
            do
            {
                Console.Write("Input command: ");
                command = Console.ReadLine();
                command = command.Trim();
                SearchCommand(command);
            }
            while (IsWork);

            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
