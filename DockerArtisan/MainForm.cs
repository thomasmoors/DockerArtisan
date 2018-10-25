using System;
using System.Configuration;
using System.Windows.Forms;


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

        public static string ReplaceLastOccurrence(string Source, string Find, string Replace)
        {
            int Place = Source.LastIndexOf(Find);
            string result = Source.Remove(Place, Find.Length).Insert(Place, Replace);
            return result;
        }

        private void ComboBoxDockerContainer_SelectedIndexChanged(object sender, EventArgs e)
        {
            docker.container = comboBoxDockerContainer.Text;

            if (!Boolean.Parse(ConfigurationManager.AppSettings.Get("pathDetected")))
            {
                DialogResult dialogResult = MessageBox.Show("Shall we detect the location of the artisan file for you?", "You can specify it yourself in the config", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                { 
                    string path = docker.SearchArtisanPath();
                    path = ReplaceLastOccurrence(path, "artisan", "");
                    ConfigurationManager.AppSettings.Set("path", path);
                    ConfigurationManager.AppSettings.Set("pathDetected", "true");
                }                    
            }
            
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
