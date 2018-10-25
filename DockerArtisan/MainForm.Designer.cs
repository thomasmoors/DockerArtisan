namespace DockerArtisan
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.comboBoxDockerContainer = new System.Windows.Forms.ComboBox();
            this.comboBoxArtisanCommand = new System.Windows.Forms.ComboBox();
            this.textBoxAdditionalArguments = new System.Windows.Forms.TextBox();
            this.buttonRunCommand = new System.Windows.Forms.Button();
            this.labelCommandDescription = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBoxDockerContainer
            // 
            this.comboBoxDockerContainer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxDockerContainer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxDockerContainer.FormattingEnabled = true;
            this.comboBoxDockerContainer.Location = new System.Drawing.Point(12, 31);
            this.comboBoxDockerContainer.Name = "comboBoxDockerContainer";
            this.comboBoxDockerContainer.Size = new System.Drawing.Size(175, 21);
            this.comboBoxDockerContainer.TabIndex = 0;
            this.comboBoxDockerContainer.SelectedIndexChanged += new System.EventHandler(this.ComboBoxDockerContainer_SelectedIndexChanged);
            // 
            // comboBoxArtisanCommand
            // 
            this.comboBoxArtisanCommand.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxArtisanCommand.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxArtisanCommand.Enabled = false;
            this.comboBoxArtisanCommand.FormattingEnabled = true;
            this.comboBoxArtisanCommand.Location = new System.Drawing.Point(193, 31);
            this.comboBoxArtisanCommand.Name = "comboBoxArtisanCommand";
            this.comboBoxArtisanCommand.Size = new System.Drawing.Size(175, 21);
            this.comboBoxArtisanCommand.TabIndex = 1;
            this.comboBoxArtisanCommand.SelectedIndexChanged += new System.EventHandler(this.ComboBoxArtisanCommand_SelectedIndexChanged);
            // 
            // textBoxAdditionalArguments
            // 
            this.textBoxAdditionalArguments.Enabled = false;
            this.textBoxAdditionalArguments.Location = new System.Drawing.Point(374, 31);
            this.textBoxAdditionalArguments.Name = "textBoxAdditionalArguments";
            this.textBoxAdditionalArguments.Size = new System.Drawing.Size(127, 20);
            this.textBoxAdditionalArguments.TabIndex = 2;
            // 
            // buttonRunCommand
            // 
            this.buttonRunCommand.Enabled = false;
            this.buttonRunCommand.Location = new System.Drawing.Point(12, 58);
            this.buttonRunCommand.Name = "buttonRunCommand";
            this.buttonRunCommand.Size = new System.Drawing.Size(489, 23);
            this.buttonRunCommand.TabIndex = 3;
            this.buttonRunCommand.Text = "RUN";
            this.buttonRunCommand.UseVisualStyleBackColor = true;
            this.buttonRunCommand.Click += new System.EventHandler(this.ButtonRunCommand_Click);
            // 
            // labelCommandDescription
            // 
            this.labelCommandDescription.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelCommandDescription.Location = new System.Drawing.Point(0, 0);
            this.labelCommandDescription.Name = "labelCommandDescription";
            this.labelCommandDescription.Size = new System.Drawing.Size(518, 13);
            this.labelCommandDescription.TabIndex = 4;
            this.labelCommandDescription.Text = "description";
            this.labelCommandDescription.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 93);
            this.Controls.Add(this.labelCommandDescription);
            this.Controls.Add(this.buttonRunCommand);
            this.Controls.Add(this.textBoxAdditionalArguments);
            this.Controls.Add(this.comboBoxArtisanCommand);
            this.Controls.Add(this.comboBoxDockerContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "DockerArtisan";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxDockerContainer;
        private System.Windows.Forms.ComboBox comboBoxArtisanCommand;
        private System.Windows.Forms.TextBox textBoxAdditionalArguments;
        private System.Windows.Forms.Button buttonRunCommand;
        private System.Windows.Forms.Label labelCommandDescription;
    }
}

