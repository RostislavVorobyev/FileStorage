using System.Collections.Generic;

namespace LabFileStorage.UI.Commands
{
    public interface ICommand
    {
        List<string> Options { get; }
        bool Execute();
        string GetResultMessage();

    }
}