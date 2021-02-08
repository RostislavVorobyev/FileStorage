namespace Lab02.Commands
{
    internal class DownloadFile : ConsoleCommand
    {
        public override bool Execute()
        {
            string fileName = Options[0];
            string destinationPath = Options[1];
            _repository.Download(fileName, destinationPath);
            ResultMessage = $"The file {Options[0]} has been downloaded";
            return true;
        }
    }
}
