using System.Security.Authentication;

namespace Lab02.Commands
{
    internal class LoginUser : ConsoleCommand
    {
        private readonly string _login;
        private readonly string _password;
         
        public LoginUser() : base()
        {
            _login = ConfigLoader.GetConfiguration()["Login"];
            _password = ConfigLoader.GetConfiguration()["Password"];
        }

        public override bool Execute()
        {
            if (!OptionsAreValid())
            {
                throw new AuthenticationException("Invalid command arguments.");
            }
            string login = Options[1];
            string password = Options[3];
            return login == _login && password == _password;
        }

        private bool OptionsAreValid()
        {
            return Options.Count == 4 && Options[0] == "--l" && Options[2] == "--p";
        }
    }
}
