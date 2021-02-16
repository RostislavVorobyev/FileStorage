namespace LabFileStorage.UI.Commands
{
    internal class InfoFile : ConsoleCommand
    {
        public override bool Execute()
        {
            string fileName = Options[0];
            ResultMessage = _fileService.GetInfo(fileName);
            return true;
        }

    }
}
