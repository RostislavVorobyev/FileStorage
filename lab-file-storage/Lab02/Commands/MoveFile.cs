namespace Lab02.Commands
{
    internal class MoveFile : ConsoleCommand
    {
        public override bool Execute()
        {
            _repository.Move(Options[0], Options[1]);
            return true;
        }
    }
}
