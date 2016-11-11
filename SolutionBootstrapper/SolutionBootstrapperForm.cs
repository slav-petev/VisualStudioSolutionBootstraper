using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SolutionBootstrapper
{
    public partial class SolutionBootstrapperForm : Form
    {
        private List<string> _projectNames =
            new List<string>();

        public SolutionBootstrapperForm()
        {
            InitializeComponent();
        }

        private void SolutionBootstrapperForm_Load(object sender, EventArgs e)
        {
            SetBootstrapSolutionButtonState();
            Font = new Font(FontFamily.GenericSansSerif, 24);
        }

        public string GetSolutionFolder()
        {
            return tbxSolutionFolder.Text;
        }

        public string GetSolutionName()
        {
            return tbxSolutionName.Text;
        }

        public IEnumerable<string> GetProjectNames()
        {
            return _projectNames;
        }

        private void btnSelectFolder_Click(object sender, EventArgs e)
        {
            var folderSelectionResult = 
                fbdSelectSOlutionFolder.ShowDialog();

            switch (folderSelectionResult)
            {
                case DialogResult.OK:
                case DialogResult.Yes:
                    tbxSolutionFolder.Text = fbdSelectSOlutionFolder.SelectedPath;
                    break;
            }
        }

        private void btnBootstrapSolution_Click(object sender, EventArgs e)
        {
            var trimmedProjectNames = tbxProjectNames.Text
                .Trim();
            var projectNamesWithRemovedRedundantWhitespaces =
                Regex.Replace(
                    trimmedProjectNames,
                    @"\s+",
                    " ");

            _projectNames.AddRange(
                projectNamesWithRemovedRedundantWhitespaces.Split());
            Close();
        }

        private void tbxProjectNames_TextChanged(object sender, EventArgs e)
        {
            SetBootstrapSolutionButtonState();
        }

        private void tbxSolutionFolder_TextChanged(object sender, EventArgs e)
        {
            SetBootstrapSolutionButtonState();
        }

        private void tbxSolutionName_TextChanged(object sender, EventArgs e)
        {
            SetBootstrapSolutionButtonState();
        }
        
        private void SetBootstrapSolutionButtonState()
        {
            if (string.IsNullOrWhiteSpace(tbxSolutionFolder.Text) ||
                string.IsNullOrWhiteSpace(tbxSolutionName.Text) ||
                string.IsNullOrWhiteSpace(tbxProjectNames.Text))
            {
                btnBootstrapSolution.Enabled = false;
                return;
            }

            btnBootstrapSolution.Enabled = true;
        }
    }
}
