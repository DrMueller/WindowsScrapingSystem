using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace Mmu.Wss.TestListener
{
    internal static class FileWriter
    {
        private static string _filePath;

        internal static void Write(string str)
        {
            Debug.WriteLine(str);
            CreateFilePath();
            File.AppendAllText(_filePath, Environment.NewLine);
            File.AppendAllText(_filePath, str);
        }

        private static void CreateFilePath()
        {
            if (!string.IsNullOrEmpty(_filePath))
            {
                return;
            }

            _filePath = Path.Combine(GetCodeBasePath(), "Output.txt");
        }

        private static string GetCodeBasePath()
        {
            var codeBase = Assembly.GetExecutingAssembly().CodeBase;
            var uri = new UriBuilder(codeBase);
            var result = Uri.UnescapeDataString(uri.Path);
            result = Path.GetDirectoryName(result);

            return result;
        }
    }
}