using SolutionBootstrapper.Infrastructure;
using SolutionBootstrapper.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SolutionBootstrapper.ViewModels
{
    public class SolutionBootstrapperViewModel : BindableBase
    {
        public ObservableCollection<ProjectInfo> SolutionProjects { get; } =
            new ObservableCollection<ProjectInfo>();
        
        public DelegateCommand AddNewProject { get; }
        public DelegateCommand EditProject { get; }
        public DelegateCommand SaveChanges { get; }

        private ProjectInfo _currentlyEditedProject;
        public ProjectInfo CurrentlyEditedProject
        {
            get  { return _currentlyEditedProject; }
            set
            {
                _currentlyEditedProject = value;
                OnPropertyChanged(nameof(CurrentlyEditedProject));
            }
        }

        public SolutionBootstrapperViewModel()
        {
            AddNewProject = new DelegateCommand(
                ExecuteAddNewProject);
            EditProject = new DelegateCommand(
                ExecuteEdit);
            SaveChanges = new DelegateCommand(
                ExecuteSaveChanges);
        }

        private void ExecuteAddNewProject(object parameter)
        {
            var newProject = new ProjectInfo();
            SolutionProjects.Add(newProject);
            CurrentlyEditedProject = newProject;
        }

        private void ExecuteEdit(object parameter)
        {
            SetSolutionProjectState(parameter, ProjectState.Edit);
        }

        private void ExecuteSaveChanges(object parameter)
        {
            SetSolutionProjectState(parameter, ProjectState.Normal);
        }

        private void SetSolutionProjectState(object projectId,
            ProjectState state)
        {
            SolutionProjects
                .Where(p => p.ProjectId.Equals(projectId))
                .First().State = state;
        }
    }
}
