using System.Collections.Generic;
using Lab02.FileManagment;


namespace Lab02.Commands
{
    internal abstract class ConsoleCommand : ICommand
    {
        public List<string> Options { get; }
        public string ResultMessage { get; protected set; }
        protected readonly FileRepository _repository;

        protected ConsoleCommand()
        {
            Options = new List<string>();
            _repository = new FileRepository();
        }

        public virtual string GetResultMessage()
        {
            return ResultMessage;
        }

        public abstract bool Execute();

    }
}
