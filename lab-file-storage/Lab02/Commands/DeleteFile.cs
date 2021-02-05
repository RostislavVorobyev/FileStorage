namespace Lab02.Commands
{
    internal class DeleteFile : ConsoleCommand
    {
        public override bool Execute()
        {
            _repository.Delete(Options[0]);
            return true;
        }
    }
}
