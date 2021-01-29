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
            foreach (var b in fileContent)
            {
                Console.WriteLine(b);
            }
            return fileContent;
        }
        internal static void WriteAsbinary(byte[] content, string path)
        {
            FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate);
            BinaryWriter bw = new BinaryWriter(fileStream);
            bw.Write(content);
            bw.Flush();
        }

    }

}
