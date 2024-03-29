﻿using System;
using System.Collections.Generic;

using QuickMaths.General.Abstractions;

namespace QuickMaths.CMD.Cmd;

public static class ConsoleHelper
{
    private static Dictionary<string, IFunction> s_functions = new Dictionary<string, IFunction>();
    private static IReadOnlyDictionary<string, Command> s_commands = CommandsStorage.Commands;


    public static Dictionary<string, IFunction> Functions => s_functions;
    public static bool IsWork { get; internal set; } = true;


    private static void InvokeCommand(Command command)
    {
        Console.WriteLine($"\nRun command {command.Name}...\n");
        command.Action.Invoke();
        Console.WriteLine($"\nCommand {command.Name} is complete\n\n");
    }

    private static void SearchCommand(string inputCommand)
    {
        Console.WriteLine();

        if (inputCommand is not null && inputCommand != String.Empty)
        {
            if (s_commands.TryGetValue(inputCommand.ToUpper(), out Command command))
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
        string command = String.Empty;
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
