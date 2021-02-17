using LabFileStorage.BLL.Services.Interfaces;

namespace LabFileStorage.UI.Commands
{
    internal class InfoFile : ConsoleCommand
    {
        public InfoFile(IFileService fileService) : base(fileService)
        {
        }

        public override bool Execute()
        {
            string fileName = Options[0];
            ResultMessage = _fileService.GetInfo(fileName);
            return true;
        }

    }
}
