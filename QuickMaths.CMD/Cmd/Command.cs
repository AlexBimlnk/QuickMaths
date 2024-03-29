﻿using System;

namespace QuickMaths.CMD.Cmd;

internal class Command
{
    public Command(string name, string description, Action action)
    {
        Name = name;
        Description = description;
        Action = action;
    }

    public string Name { get; }
    public string Description { get; }

    public Action Action { get; }
}
