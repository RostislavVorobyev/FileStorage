namespace Lab02.Commands
{
    internal class DeleteFile : ConsoleCommand
    {
        public override bool Execute()
        {
            string fileName = Options[0];
            _repository.Delete(fileName);
            ResultMessage = $"File {Options[0]} has been removed";
            return true;
        }

    }
}
