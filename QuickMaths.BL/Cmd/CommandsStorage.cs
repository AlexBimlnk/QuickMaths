using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickMaths.BL.Cmd
{
    //TODO CommandsStorage:
    internal static class CommandsStorage
    {
        private static Dictionary<string, Command> _commands = new Dictionary<string, Command>()
        {
            { "HELP",   new Command("HELP", "Write all command in console.", Help)},
            { "EXIT",   new Command("EXIT", "Close ConsoleHelper.", Exit)},
            { "CLEAR",  new Command("CLEAR","Clear console.", Clear)},

            { "CREATE", new Command("CREATE","Create new function.", CreateFunction)}
        };

        public static Dictionary<string, Command> Commands { get { return _commands; } }

        #region State work commands
        private static void Help()
        {
            Console.WriteLine("Commands list:");
            foreach (var command in _commands.Values)
            {
                Console.WriteLine($"\tCommand {command.Name}");
                Console.WriteLine($"\t\t{command.Description}");
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


        #region Create commands
        private static void CreateFunction()
        {
            throw new NotImplementedException();
        }
        #endregion


        #region Commands of managment functions object
        private static void ReturnFunctionsList()
        {
            throw new NotImplementedException();
        }

        private static void TakeVariable()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
