namespace LabFileStorage.UI.Commands
{
    internal class DeleteFile : ConsoleCommand
    {
        
        public override bool Execute()
        {
            string fileName = Options[0];
            _fileService.Delete(fileName);
            ResultMessage = $"File {Options[0]} has been removed";
            return true;
        }

    }
}
