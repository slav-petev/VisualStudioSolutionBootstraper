//------------------------------------------------------------------------------
// <copyright file="SolutionBootstrapperCommand.cs" company="Company">
//     Copyright (c) Company.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

using System;
using System.ComponentModel.Design;
using Microsoft.VisualStudio.Shell;
using EnvDTE;
using EnvDTE80;
using System.IO;
using System.Linq;
using System.Windows;
using System.Collections.Generic;
using SolutionBootstrapper.SolutionBootstrapperUI;
using SolutionBootstrapper.ViewModels;

namespace SolutionBootstrapper
{
    internal sealed class SolutionManagerCommand
    {
        private readonly DTE2 _activeVisualStudioInstance = Package
                .GetGlobalService(typeof(DTE)) as DTE2;
       
        public const int BootstrapSolutionCommandId = 0x0100;
        public const int RenameInProjectAndFileNamesCommandId = 0x101;

        public static readonly Guid CommandSet = new Guid("bf8be7d9-577e-42bf-9f1a-e6d473679c6d");

        private readonly Package package;

        private SolutionManagerCommand(Package package)
        {
            if (package == null)
            {
                throw new ArgumentNullException(nameof(package));
            }

            this.package = package;

            OleMenuCommandService commandService = ServiceProvider.GetService(typeof(IMenuCommandService)) as OleMenuCommandService;
            if (commandService != null)
            {
                var bootstrapSolutionCommandId = new CommandID(CommandSet, 
                    BootstrapSolutionCommandId);
                var renameInProjectAndFileNamesCommandId = new CommandID(CommandSet, 
                    RenameInProjectAndFileNamesCommandId);

                var solutionBootstrapperCommand = new OleMenuCommand(ExecuteBootstrapSolutionCommand, 
                    bootstrapSolutionCommandId);
                
                var renameInProjectAndFileNamesCommand = new OleMenuCommand((s, e) => MessageBox.Show("Here"), 
                    renameInProjectAndFileNamesCommandId);
                commandService.AddCommand(solutionBootstrapperCommand);
                commandService.AddCommand(renameInProjectAndFileNamesCommand);
            }
        }
        
        public static SolutionManagerCommand Instance
        {
            get;
            private set;
        }

        private IServiceProvider ServiceProvider
        {
            get
            {
                return package;
            }
        }

        public static void Initialize(Package package)
        {
            Instance = new SolutionManagerCommand(package);
        }

        private void ExecuteBootstrapSolutionCommand(object sender, EventArgs e)
        {
            //var solutionBootstrapperForm = new SolutionBootstrapperForm();
            //solutionBootstrapperForm.ShowDialog();
            var solutionBootstrapperViewModel = 
                new SolutionBootstrapperViewModel();
            var solutionBootstrapperWindow = new SolutionBootstrapperWindow();
            solutionBootstrapperWindow.DataContext = solutionBootstrapperViewModel;
            solutionBootstrapperWindow.ShowDialog();

            //var solutionName = solutionBootstrapperForm.GetSolutionName();
            //var projectNames = solutionBootstrapperForm
            //    .GetProjectNames();

            //if (string.IsNullOrWhiteSpace(solutionName)) return;

            //if (!projectNames.Any()) return;

            //var solution = _activeVisualStudioInstance.Solution as Solution2;
            //var cSharpConsoleApplicationTemplatePath = solution
            //    .GetProjectTemplate("ConsoleApplication.zip", "CSharp");
            //var solutionFolder = solutionBootstrapperForm.GetSolutionFolder();
            //CreateSolution(solutionName, solution, solutionFolder);
            //CreateCSharpConsoleApplications(
            //    projectNames,
            //    solution,
            //    cSharpConsoleApplicationTemplatePath,
            //    solutionFolder);
            //RenameCSharpFiles(solution);
        }

        private static void CreateSolution(
            string solutionName, 
            Solution2 solution, 
            string solutionFolder)
        {
            solution.Create(solutionFolder, solutionName);
        }

        private static void CreateCSharpConsoleApplications(
            IEnumerable<string> projectNames, 
            Solution2 solution, 
            string cSharpConsoleApplicationTemplatePath, 
            string solutionFolder)
        {
            foreach (var projectName in projectNames)
            {
                var projectFolder = Path.Combine(
                    solutionFolder,
                    projectName);
                solution.AddFromTemplate(
                    cSharpConsoleApplicationTemplatePath,
                    Path.Combine(solutionFolder, projectFolder),
                    projectName);
            }
        }

        private static void RenameCSharpFiles(Solution2 solution)
        {
            foreach (Project project in solution.Projects)
            {
                foreach (ProjectItem projectItem in project.ProjectItems)
                {
                    if (!projectItem.Name.EndsWith(".cs")) continue;

                    projectItem.Name = string.Format("{0}Exercise.cs",
                        project.Name);
                }
            }
        }
    }
}
