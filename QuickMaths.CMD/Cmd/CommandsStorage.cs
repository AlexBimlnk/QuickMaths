using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuickMaths.BL.Functions;

namespace QuickMaths.CMD.Cmd
{
    //TODO CommandsStorage:
    internal static class CommandsStorage
    {
        private static readonly Dictionary<string, Command> _commands = new Dictionary<string, Command>()
        {
            { "HELP",   new Command("HELP", "Write all command in console.", Help)},
            { "EXIT",   new Command("EXIT", "Close ConsoleHelper.", Exit)},
            { "CLEAR",  new Command("CLEAR","Clear console.", Clear)},

            { "CREATE", new Command("CREATE","Create new function.", CreateFunction)},
            { "VIEW FUNCTIONS", new Command("VIEW FUNCTIONS","Write all created functions.", WriteCreatedFunctions)}
        };

        public static IReadOnlyDictionary<string, Command> Commands { get { return _commands; } }


        #region State work commands
        private static void Help()
        {
            Console.WriteLine("\tCommands list:");
            foreach (var command in _commands.Values)
            {
                Console.WriteLine($"\t\tCommand {command.Name}");
                Console.WriteLine($"\t\t\t{command.Description}");
            }
        }

        private static void Clear()
        {
            Console.Clear();
        }

        private static void Exit()
        {
            ConsoleHelper.IsWork = false;
        }
        #endregion


        #region Сommands of create
        private static void CreateFunction()
        {
            Console.Write("\tWrite function: ");
            string functionString = Console.ReadLine();

            Console.Write($"\tWrite name for function: ");
            string functionName = Console.ReadLine();

            try
            {
                ConsoleHelper.Functions.Add(functionName, new CompositeFunction(functionString));
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine($"\tError: {ex.Message}");
            }
        }
        #endregion


        #region Commands of managment functions object
        private static void WriteCreatedFunctions()
        {
            Console.WriteLine("\tFunctions list:");
            foreach(var element in ConsoleHelper.Functions)
            {
                Console.WriteLine($"\t\tFunction: {element.Key}={element.Value}");
            }
        }

        private static void TakeVariable()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
