using System;
using System.Configuration;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace DockerArtisan
{
    public partial class Form1 : Form
    {
        private List<Command> Commands = new List<Command>();
        string container;
        string path;


        public Form1()
        {
            InitializeComponent();
            this.RetrieveContainers();
        }

        private void RetrieveContainers()
        {
            using (var output = Form1.cmdExecute("docker", "ps -a --format '{{.Names}}'"))
            {
                string line;
                while ((line = output.ReadLine()) != null)
                {
                    line = line.Replace("'", "");
                    comboBox1.Items.Add(line);
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Enabled = true;

            this.container = comboBox1.Text;
            this.path = ConfigurationSettings.AppSettings.Get("path");
      
            using (var reader = Form1.cmdExecute("docker", "exec " + container + " php " + path + "artisan list"))
            {
                string cmdOutput = reader.ReadToEnd();

                cmdOutput = cmdOutput.Split(new string[] { "Available commands:" }, StringSplitOptions.None)[1];

          
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
                comboBox2.DataSource = this.Commands;

            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Command c = this.Commands.Find(i => i.command.Equals(comboBox2.Text));
            label1.Text = c.description;
            button1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string arg = "";
            if (textBox1.Text != "")
            {
                arg = " " + textBox1.Text;
            }
  
            MessageBox.Show(Form1.cmdExecute("docker", "exec " + container + " php " + path + "artisan " + comboBox2.Text + arg).ReadToEnd());
        }

        private static System.IO.StreamReader cmdExecute(string app, string arguments)
        {
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

    class Command
    {
        public string command;
        public string description;

        public override string ToString()
        {
            return this.command;
        }
    }
}
