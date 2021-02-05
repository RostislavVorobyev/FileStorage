namespace Lab02.Commands
{
    internal class InfoFile : ConsoleCommand
    {
        public override bool Execute()
        {
            System.Console.WriteLine(_repository.GetInfo(Options[0]));
            return true;
        }

    }
}
