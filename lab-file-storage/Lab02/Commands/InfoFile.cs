using Lab02.FileManagment;

namespace Lab02.Commands
{
    internal class InfoFile : ConsoleCommand
    {
        private FileMetaInformation fileInfo;
        public override bool Execute()
        {
            string fileName = Options[0];
            fileInfo = _repository.GetInfo(fileName);
            ResultMessage = $"name: {fileInfo.FileName}\n" +
                $"extension: {fileInfo.Extension.Substring(1)}\n" +
                $"creation date: {fileInfo.CreationDate.ToString("yyyy-MM-dd")}\n" +
                "login: Vorobey";
            return true;
        }

    }
}
