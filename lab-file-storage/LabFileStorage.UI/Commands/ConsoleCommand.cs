using System.Collections.Generic;
using LabFileStorage.BLL.Services.Implementations;
using LabFileStorage.BLL.Services.Interfaces;

namespace LabFileStorage.UI.Commands
{
    internal abstract class ConsoleCommand : ICommand
    {
        public List<string> Options { get; }
        public string ResultMessage { get; protected set; }
        protected readonly IFileService _fileService;

        protected ConsoleCommand()
        {
            Options = new List<string>();
            _fileService = new FileService();
        }

        protected ConsoleCommand(IFileService fileService) : base()
        {
            _fileService = fileService;
        }

        public virtual string GetResultMessage()
        {
            return ResultMessage;
        }

        public abstract bool Execute();

    }
}
