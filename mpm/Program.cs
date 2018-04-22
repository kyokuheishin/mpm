using System;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mpm
{
    class Program
    {
        static bool CheckFolders() {
            if (Directory.Exists("chars") & File.Exists("mugen.exe"))
            {
                return true;
            }
            else {
                Console.WriteLine("Can't detect vaild M.U.G.E.N folders. Please make sure that mpm is under the root folder of M.U.G.E.N. You can use the \"-i\" arg to ignore this detection.");
                Console.ReadKey();
                Environment.Exit(0);
                return false;
            }
            
        }

        static void CloneFromGithub(string GitUrl) {
            Process process = new Process();
            process.StartInfo.FileName = "git.exe";
            process.StartInfo.WorkingDirectory = Environment.CurrentDirectory + "\\chars";
            process.StartInfo.Arguments = "clone " + GitUrl;
            try {
                process.Start();
            }

            catch {
                Console.WriteLine("Oops! It seems that Git is not installed or not in the PATH.");
            }
            
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello M.U.G.E.N");
            if (args.Length != 0) {
                if (args[0] == "-i") {
                    Console.WriteLine("Detection is ignored. Please notice that mpm will NOT add new character to select.def automaticlly.");
                    Console.ReadKey();
                }
                else {
                    CheckFolders();
                    if (args[0] == "-d") {
                        CloneFromGithub(args[1]);
                    }
                }
            }
            else{
                
            }
            
            
        }
    }
}
