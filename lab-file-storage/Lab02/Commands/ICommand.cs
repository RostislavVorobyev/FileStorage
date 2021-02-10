using System.Collections.Generic;

namespace Lab02.Commands
{
    public interface ICommand
    {
        List<string>  Options { get; }
        bool Execute();
        string GetResultMessage();

    }
}