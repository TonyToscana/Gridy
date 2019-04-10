
using System;
using System.Collections.Generic;
using UnityEngine;

public class CommandInvoker
{
    private readonly IDictionary<string, ICommand> Commands;
    private readonly IDictionary<string, string> Alias;
    public string ClassSufix { get; set; } = "Command";

    public CommandInvoker()
    {
        this.Commands = new Dictionary<string, ICommand>();
        this.Alias = new Dictionary<string, string>();
    }

    public void SetAlias(string from, string to)
    {
        if (this.Alias.ContainsKey(from)) return;

        this.Alias.Add(from, to);
    }

    public void SetAlias(IList<string> from, string to)
    {
        foreach (string item in from)
        {
            this.SetAlias(item, to);
        }
    }

    public ICommand GetCommand(string name)
    {
        if (this.Alias.ContainsKey(name))
        {
            name = this.Alias[name];
        }

        name = name + ClassSufix;

        if (this.Commands.ContainsKey(name))
        {
            return this.Commands[name];
        }

        Type type = Type.GetType(name);

        if (type == null)
        {
            return null;
        }

        object instance = Activator.CreateInstance(type);
        
        if (!(instance is ICommand))
        {
            return null;
        }

        this.Commands.Add(name, (ICommand)instance);

        return (ICommand) instance;
    }
}
