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
            //Authorize();
            //testWrite();
            //testRead();
            //MetaInformationStorage ms = new MetaInformationStorage();
            //ms.GetStorage();
            MetaInformationStorage st = new MetaInformationStorage();
            st.PrintMetainf();
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

        private static void ReadMetaInformation()
        {
            throw new NotImplementedException();
        }
        private static void testWrite()
        {
            byte[] arr = FileConverter.ConverToByteArray(@"C:\Users\r.vorobyov\Desktop\VorobyovMastery\Unit2_Net\Lab\Minsk-Rostislav-Vorobyov\lab-file-storage\Lab02\Text.txt");
            File.WriteAllBytes(@"C:\Users\r.vorobyov\Desktop\VorobyovMastery\Unit2_Net\Lab\Minsk-Rostislav-Vorobyov\lab-file-storage\Lab02\Metainf.bin", arr);
            //FileConverter.WriteAsBinary(arr, @"C:\Users\r.vorobyov\Desktop\VorobyovMastery\Unit2_Net\Lab\Minsk-Rostislav-Vorobyov\lab-file-storage\Lab02\Database\file.bin");

        }
        private static void testRead()
        {
            var a = File.ReadAllBytes(@"C:\Users\r.vorobyov\Desktop\VorobyovMastery\Unit2_Net\Lab\Minsk-Rostislav-Vorobyov\lab-file-storage\Lab02\Database\ico.bin");
            File.WriteAllBytes(@"C:\Users\r.vorobyov\Desktop\VorobyovMastery\Unit2_Net\Lab\Minsk-Rostislav-Vorobyov\lab-file-storage\Lab02\icoreaded.bmp", a);

                //FileConverter.ReadBinary(@"C:\Users\r.vorobyov\Desktop\VorobyovMastery\Unit2_Net\Lab\Minsk-Rostislav-Vorobyov\lab-file-storage\Lab02\Database\file.bin", "aa");
        }

        private static Object TestRead()
        {
            throw new NotImplementedException();

        }

    }
}

