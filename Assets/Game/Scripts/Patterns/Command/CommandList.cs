using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class CommandList
{
    private const int MAXCOMMAND = 100;
    private Stack<ICommand> commandList = new Stack<ICommand>();

    public void Execute(ICommand command)
    {
        command.Execute();
        if (commandList.Count < MAXCOMMAND)
            commandList.Push(command);
    }

    public void Undo()
    {
        if (commandList.Count <= 0)
            return;
        commandList.Pop().Undo();
    }

  
}
