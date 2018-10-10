using System;
using System.Configuration;
using System.Windows.Forms;
using System.Text.RegularExpressions;


namespace DockerArtisan
{
    public partial class MainForm : Form
    {   
        Docker docker;

        public MainForm()
        {
            InitializeComponent();
            this.docker = new Docker();
            docker.RetrieveContainers(comboBoxDockerContainer);
        }       

        private void ComboBoxDockerContainer_SelectedIndexChanged(object sender, EventArgs e)
        {
            docker.container = comboBoxDockerContainer.Text;
            docker.RetrieveArtisanCommands(this.comboBoxArtisanCommand);
            comboBoxArtisanCommand.Enabled = true;
        }

        private void ComboBoxArtisanCommand_SelectedIndexChanged(object sender, EventArgs e)
        {
            Command command = docker.Commands.Find(i => i.command.Equals(comboBoxArtisanCommand.Text));
            labelCommandDescription.Text = command.description;
            textBoxAdditionalArguments.Enabled = true;
            buttonRunCommand.Enabled = true;
        }

        private void ButtonRunCommand_Click(object sender, EventArgs e)
        {
            string arguments = "";
            if (textBoxAdditionalArguments.Text != "")
            {
                arguments = " " + textBoxAdditionalArguments.Text;
            }

            docker.arguments = arguments;
            docker.Execute(comboBoxArtisanCommand.Text);
        }      
    }    
}
