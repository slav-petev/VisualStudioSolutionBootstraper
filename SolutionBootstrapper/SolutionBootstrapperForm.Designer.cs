namespace SolutionBootstrapper
{
    partial class SolutionBootstrapperForm
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
            this.tbxSolutionFolder = new System.Windows.Forms.TextBox();
            this.btnSelectFolder = new System.Windows.Forms.Button();
            this.fbdSelectSOlutionFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.lblSolutionFolder = new System.Windows.Forms.Label();
            this.lblProjectNames = new System.Windows.Forms.Label();
            this.tbxProjectNames = new System.Windows.Forms.TextBox();
            this.btnBootstrapSolution = new System.Windows.Forms.Button();
            this.lblSolutionName = new System.Windows.Forms.Label();
            this.tbxSolutionName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tbxSolutionFolder
            // 
            this.tbxSolutionFolder.Location = new System.Drawing.Point(12, 39);
            this.tbxSolutionFolder.Name = "tbxSolutionFolder";
            this.tbxSolutionFolder.ReadOnly = true;
            this.tbxSolutionFolder.Size = new System.Drawing.Size(218, 22);
            this.tbxSolutionFolder.TabIndex = 0;
            this.tbxSolutionFolder.TextChanged += new System.EventHandler(this.tbxSolutionFolder_TextChanged);
            // 
            // btnSelectFolder
            // 
            this.btnSelectFolder.Location = new System.Drawing.Point(236, 38);
            this.btnSelectFolder.Name = "btnSelectFolder";
            this.btnSelectFolder.Size = new System.Drawing.Size(35, 23);
            this.btnSelectFolder.TabIndex = 1;
            this.btnSelectFolder.Text = "...";
            this.btnSelectFolder.UseVisualStyleBackColor = true;
            this.btnSelectFolder.Click += new System.EventHandler(this.btnSelectFolder_Click);
            // 
            // lblSolutionFolder
            // 
            this.lblSolutionFolder.AutoSize = true;
            this.lblSolutionFolder.Location = new System.Drawing.Point(9, 9);
            this.lblSolutionFolder.Name = "lblSolutionFolder";
            this.lblSolutionFolder.Size = new System.Drawing.Size(107, 17);
            this.lblSolutionFolder.TabIndex = 2;
            this.lblSolutionFolder.Text = "Solution Folder:";
            // 
            // lblProjectNames
            // 
            this.lblProjectNames.AutoSize = true;
            this.lblProjectNames.Location = new System.Drawing.Point(12, 144);
            this.lblProjectNames.Name = "lblProjectNames";
            this.lblProjectNames.Size = new System.Drawing.Size(100, 17);
            this.lblProjectNames.TabIndex = 3;
            this.lblProjectNames.Text = "Project Names";
            // 
            // tbxProjectNames
            // 
            this.tbxProjectNames.Location = new System.Drawing.Point(12, 173);
            this.tbxProjectNames.Name = "tbxProjectNames";
            this.tbxProjectNames.Size = new System.Drawing.Size(218, 22);
            this.tbxProjectNames.TabIndex = 4;
            this.tbxProjectNames.TextChanged += new System.EventHandler(this.tbxProjectNames_TextChanged);
            // 
            // btnBootstrapSolution
            // 
            this.btnBootstrapSolution.Location = new System.Drawing.Point(12, 214);
            this.btnBootstrapSolution.Name = "btnBootstrapSolution";
            this.btnBootstrapSolution.Size = new System.Drawing.Size(159, 31);
            this.btnBootstrapSolution.TabIndex = 5;
            this.btnBootstrapSolution.Text = "Bootstrap Solution";
            this.btnBootstrapSolution.UseVisualStyleBackColor = true;
            this.btnBootstrapSolution.Click += new System.EventHandler(this.btnBootstrapSolution_Click);
            // 
            // lblSolutionName
            // 
            this.lblSolutionName.AutoSize = true;
            this.lblSolutionName.Location = new System.Drawing.Point(9, 80);
            this.lblSolutionName.Name = "lblSolutionName";
            this.lblSolutionName.Size = new System.Drawing.Size(104, 17);
            this.lblSolutionName.TabIndex = 6;
            this.lblSolutionName.Text = "Solution Name:";
            // 
            // tbxSolutionName
            // 
            this.tbxSolutionName.Location = new System.Drawing.Point(12, 108);
            this.tbxSolutionName.Name = "tbxSolutionName";
            this.tbxSolutionName.Size = new System.Drawing.Size(218, 22);
            this.tbxSolutionName.TabIndex = 7;
            this.tbxSolutionName.TextChanged += new System.EventHandler(this.tbxSolutionName_TextChanged);
            // 
            // SolutionBootstrapperForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 306);
            this.Controls.Add(this.tbxSolutionName);
            this.Controls.Add(this.lblSolutionName);
            this.Controls.Add(this.btnBootstrapSolution);
            this.Controls.Add(this.tbxProjectNames);
            this.Controls.Add(this.lblProjectNames);
            this.Controls.Add(this.lblSolutionFolder);
            this.Controls.Add(this.btnSelectFolder);
            this.Controls.Add(this.tbxSolutionFolder);
            this.Name = "SolutionBootstrapperForm";
            this.Text = "SolutionBootstrapperForm";
            this.Load += new System.EventHandler(this.SolutionBootstrapperForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbxSolutionFolder;
        private System.Windows.Forms.Button btnSelectFolder;
        private System.Windows.Forms.FolderBrowserDialog fbdSelectSOlutionFolder;
        private System.Windows.Forms.Label lblSolutionFolder;
        private System.Windows.Forms.Label lblProjectNames;
        private System.Windows.Forms.TextBox tbxProjectNames;
        private System.Windows.Forms.Button btnBootstrapSolution;
        private System.Windows.Forms.Label lblSolutionName;
        private System.Windows.Forms.TextBox tbxSolutionName;
    }
}