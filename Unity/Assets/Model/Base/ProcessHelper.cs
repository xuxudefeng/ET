using System;
using System.Diagnostics;

namespace ETModel
{
    public static class ProcessHelper
    {
        public static Process Run(string exe, string arguments, string workingDirectory = ".", bool useShellExecute = false, bool createNoWindow = true)
        {
            try
            {
                ProcessStartInfo info = new ProcessStartInfo
                {
                    FileName = exe,
                    Arguments = arguments,
                    CreateNoWindow = createNoWindow,
                    UseShellExecute = useShellExecute,
                    WorkingDirectory = workingDirectory,
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                };
                
                Process process = Process.Start(info);
                
                process.WaitForExit();
                if (process.ExitCode != 0)
                {
                    throw new Exception(process.StandardOutput.ReadToEnd() + process.StandardError.ReadToEnd() + "\n"
                    + $"请在terminal中执行，目录{workingDirectory}, 命令{exe} {arguments}");
                }

                return process;
            }
            catch (Exception e)
            {
                throw new Exception($"请在terminal中执行，目录{workingDirectory}, 命令{exe} {arguments}");
            }
        }
    }
}