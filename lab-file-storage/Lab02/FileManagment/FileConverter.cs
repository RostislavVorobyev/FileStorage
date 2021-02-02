using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Lab02
{
    internal class FileConverter
    {
        internal static byte[] ConverToByteArray(string path)
        {
            byte[] fileContent = null;
            if (File.Exists(path))
            {
                fileContent = File.ReadAllBytes(path);
            }
            return fileContent;
        }
        internal static void WriteAsBinary(byte[] content, string path)
        {
            using (FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate))
            {
                BinaryWriter bw = new BinaryWriter(fileStream);
                bw.Write(content);
            }
        }

        internal static byte[] ReadBinary(string sourcePath, string destinationPath)
        {
            byte[] a = File.ReadAllBytes(sourcePath);
            Console.WriteLine($"SIZE:{a.Length}");
            Console.WriteLine(System.Text.Encoding.Default.GetString(a));
            return null;
            //todo catch file not found
        }

    }

}
