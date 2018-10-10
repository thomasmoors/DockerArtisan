using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DockerArtisan
{
    class Docker
    {
        public List<Command> Commands = new List<Command>();
        public string container;
        public string path;
        public string arguments;

        public void RetrieveContainers(ComboBox comboBox)
        {
            using (var output = Cmd.Execute("docker", "ps -a --format '{{.Names}}'"))
            {
                string line;
                while ((line = output.ReadLine()) != null)
                {
                    line = line.Replace("'", "");
                    comboBox.Items.Add(line);
                }
            }
        }

        public void RetrieveArtisanCommands(ComboBox comboBox)
        {

            this.path = ConfigurationManager.AppSettings.Get("path");

            using (var reader = Cmd.Execute("docker", "exec " + this.container + " php " + this.path + "artisan list"))
            {
                string cmdOutput = reader.ReadToEnd();

                try
                {
                    cmdOutput = cmdOutput.Split(new string[] { "Available commands:" }, StringSplitOptions.None)[1];
                }
                catch (Exception)
                {
                    MessageBox.Show("It looks like this container has no artisan installed or the path to it is not correctly configured");
                    return;
                }

                string pattern = @"^ *(?<command>[^ \n]+) +(?<description>[^ \n].*?[^ \n]+)$";
                MatchCollection mc = Regex.Matches(cmdOutput, pattern, RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.ECMAScript);

                foreach (Match m in mc)
                {
                    this.Commands.Add(new Command
                    {
                        command = m.Groups["command"].Value,
                        description = m.Groups["description"].Value
                    });
                }

                comboBox.DataSource = this.Commands;
            }
        }

        public string SearchArtisanPath()
        {
            using (var output = Cmd.Execute("docker", "exec "+ this.container +" /bin/bash -c ' find / -type f -name artisan 2>&1 | grep -v \"Permission denied\"'"))
            {
                string response = output.ReadToEnd();
                if (response.StartsWith("/"))
                {
                    return response;
                }

                throw new Exception("Artisan not found");
            }
        }

        public void Execute(string command)
        {          
            MessageBox.Show(Cmd.Execute("docker", "exec " + this.container + " php " + this.path + "artisan " + command + this.arguments).ReadToEnd());
        }
    }
}
