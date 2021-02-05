using System.Collections.Generic;

namespace Lab02.Commands
{
    internal abstract class ConsoleCommand : ICommand
    {
        public List<string> Options { get; }
        protected readonly FileRepository _repository;

        protected ConsoleCommand()
        {
            Options = new List<string>();
            _repository = new FileRepository();
        }

        public abstract bool Execute();

    }
}
