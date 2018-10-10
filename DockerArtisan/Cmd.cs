using System.IO;

namespace DockerArtisan
{
    class Cmd
    {
        public static StreamReader Execute(string app, string arguments)
        {
            // TODO make this function async
            System.Diagnostics.Process pProcess = new System.Diagnostics.Process();
            pProcess.StartInfo.FileName = app;
            pProcess.StartInfo.Arguments = arguments;
            pProcess.StartInfo.UseShellExecute = false;
            pProcess.StartInfo.RedirectStandardOutput = true;
            pProcess.StartInfo.CreateNoWindow = true;
            pProcess.Start();
            return pProcess.StandardOutput;
        }
    }
}
