namespace LabFileStorage.UI.Commands
{
    internal class UploadFile : ConsoleCommand
    {
        public override bool Execute()
        {
            _fileService.Upload(Options[0]);
            ResultMessage = $"The file {Options[0]} has been uploaded";
            return true;
        }
    }

}
