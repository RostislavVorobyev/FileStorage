using LabFileStorage.BLL.Services.Interfaces;

namespace LabFileStorage.UI.Commands
{
    internal class UploadFile : ConsoleCommand
    {
        public UploadFile(IFileService fileService) : base(fileService)
        {
        }

        public override bool Execute()
        {
            _fileService.Upload(Options[0]);
            ResultMessage = $"The file {Options[0]} has been uploaded";
            return true;
        }
    }

}
