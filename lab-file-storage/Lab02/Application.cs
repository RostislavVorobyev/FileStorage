using Lab02.Commands;
using System;
using System.IO;
using System.Security.Authentication;

namespace Lab02
{
    public class Application
    {
        public static void Main()
        {
            Console.WriteLine("Runned");
            //MetaInformationStorage st = new MetaInformationStorage();
            //st.PrintMetainf();
            //FileRepository fr = new FileRepository();
            //fr.Upload(@"C:\Users\r.vorobyov\Desktop\VorobyovMastery\Unit2_Net\Lab\Minsk-Rostislav-Vorobyov\lab-file-storage\Lab02\text.txt");
            //st.PrintMetainf();
            //fr.Download("text.txt", @"C:\Users\r.vorobyov\Desktop\VorobyovMastery\Unit2_Net\Lab\Minsk-Rostislav-Vorobyov\lab-file-storage\Lab02");
            //fr.Move("text.txt", "edited.txt");
            //fr.Delete("text.txt");
            //st.PrintMetainf();

        }

        private static void Authorize()
        {
            bool isAuthorized = false;
            while (!isAuthorized)
            {
                Console.WriteLine("Authorize to use the programm.");
                string command = Console.ReadLine();
                ICommand authorization = CommandParser.Parse(command.Split(" "));
                if (authorization?.GetType() == typeof(LoginUser))
                {
                    try
                    {
                        isAuthorized = authorization.Execute();
                    }
                    catch (AuthenticationException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                }
            }
        }

    }
}

