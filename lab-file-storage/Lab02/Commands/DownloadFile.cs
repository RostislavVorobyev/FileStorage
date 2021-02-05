namespace Lab02.Commands
{
    internal class DownloadFile : ConsoleCommand
    {
        public override bool Execute()
        {
            _repository.Download(Options[0], Options[1]);
            return true;
        }

    }
}
