namespace Lab02.Commands
{
    internal class UploadFile : ConsoleCommand
    {
        public override bool Execute()
        {
            _repository.Upload(Options[0]);
            return true;
        }

    }
}
