using SolutionBootstrapper.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionBootstrapper.Models
{
    public enum ProjectState
    {
        Normal,
        Edit
    }

    public class ProjectInfo : BindableBase, IEquatable<ProjectInfo>
    {
        public Guid ProjectId { get; } = Guid.NewGuid();


        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
                OnPropertyChanged(nameof(FullName));
                OnPropertyChanged(nameof(MainFileName));
            }
        }

        private int _number;
        public int Number
        {
            get { return _number; }
            set
            {
                _number = value;
                OnPropertyChanged(nameof(Number));
                OnPropertyChanged(nameof(FullName));
            }
        }

        private ProjectState _state;
        public ProjectState State
        {
            get { return _state; }
            set
            {
                _state = value;
                OnPropertyChanged(nameof(State));
            }
        }

        public string FullName => $"{Number:00}.{Name}";

        public string MainFileName => $"{Name}Exercise";

        public ProjectInfo()
        {
            State = ProjectState.Edit;
            Name = string.Empty;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;

            return Equals((ProjectInfo)obj);
        }

        public bool Equals(ProjectInfo other)
        {
            return ProjectId == other.ProjectId;
        }

        public override int GetHashCode()
        {
            return ProjectId.GetHashCode();
        }
    }
}
