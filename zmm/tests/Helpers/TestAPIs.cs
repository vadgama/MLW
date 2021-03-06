using System;
using System.Diagnostics;

namespace ZMM.Helpers.Tests
{
    public static class TestAPIs
    {
        public static readonly string wCurlCommand = "curl";
        static internal char DirectoryPathSeperator = System.IO.Path.DirectorySeparatorChar;
        static internal string TestDir = Environment.CurrentDirectory + DirectoryPathSeperator + "ZMOD";
        public static void ProcessStart(string ParamString)
        {
            Process process = new Process();
            string filename = wCurlCommand;
            process.StartInfo.FileName = filename;
            process.StartInfo.Arguments = " -LJO " + ParamString;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.WorkingDirectory = TestDir;

            process.Start();
            process.WaitForExit();
            if (process.ExitCode > 0)
            {
                Console.WriteLine("Error occured:{0}", process.ExitCode);
            }
        }
    }
}