namespace LabFileStorage.UI.Commands
{
    internal class MoveFile : ConsoleCommand
    {
        public override bool Execute()
        {
            _fileService.Move(Options[0], Options[1]);
            ResultMessage = $"The file {Options[0]} has been moved to {Options[1]}";
            return true;
        }
    }
}
