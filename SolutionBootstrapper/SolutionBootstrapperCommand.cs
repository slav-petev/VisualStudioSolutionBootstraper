//------------------------------------------------------------------------------
// <copyright file="SolutionBootstrapperCommand.cs" company="Company">
//     Copyright (c) Company.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

using System;
using System.ComponentModel.Design;
using System.Globalization;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using EnvDTE;
using EnvDTE80;
using System.IO;
using System.Linq;

namespace SolutionBootstrapper
{
    internal sealed class SolutionBootstrapperCommand
    {
        private static readonly string ConsoleAppTemplatePath =
            Path.Combine("ProjectTemplates", "CSharp", "csConsoleApplication.vstemplate");

        public const int CommandId = 0x0100;

        public static readonly Guid CommandSet = new Guid("bf8be7d9-577e-42bf-9f1a-e6d473679c6d");

        private readonly Package package;

        private SolutionBootstrapperCommand(Package package)
        {
            if (package == null)
            {
                throw new ArgumentNullException(nameof(package));
            }

            this.package = package;

            OleMenuCommandService commandService = ServiceProvider.GetService(typeof(IMenuCommandService)) as OleMenuCommandService;
            if (commandService != null)
            {
                var menuCommandID = new CommandID(CommandSet, CommandId);
                var menuItem = new MenuCommand(ExecuteBootstrapSolutionCommand, menuCommandID);
                commandService.AddCommand(menuItem);
            }
        }

        public static SolutionBootstrapperCommand Instance
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
            Instance = new SolutionBootstrapperCommand(package);
        }

        private void ExecuteBootstrapSolutionCommand(object sender, EventArgs e)
        {
            var solutionBootstrapperForm = new SolutionBootstrapperForm();
            solutionBootstrapperForm.ShowDialog();

            var solutionName = solutionBootstrapperForm.GetSolutionName();
            var projectNames = solutionBootstrapperForm
                .GetProjectNames();

            if (string.IsNullOrWhiteSpace(solutionName)) return;

            if (!projectNames.Any()) return;

            var activeVisualStudioInstance =
                Package.GetGlobalService(typeof(DTE)) as DTE2;
            var solution = activeVisualStudioInstance.Solution as Solution2;
            var cSharpConsoleApplicationTemplatePath = solution
                .GetProjectTemplate("ConsoleApplication.zip", "CSharp");
            var solutionFolder = solutionBootstrapperForm.GetSolutionFolder();
            solution.Create(solutionFolder, solutionName);

            foreach (var projectName in projectNames)
            {
                var projectFolder = Path.Combine(
                    solutionBootstrapperForm.GetSolutionFolder(),
                    projectName);
                solution.AddFromTemplate(
                    cSharpConsoleApplicationTemplatePath,
                    Path.Combine(solutionFolder, projectFolder),
                    projectName);
            }

            RenameCSharpFiles(solution);
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
