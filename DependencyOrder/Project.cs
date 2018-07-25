using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyOrder
{
    public class Project
    {
        public string Name { get; set; }
        public HashSet<Project> Dependency_Projects{ get; set; }

        public Project(string name)
        {
            Name = name;
            Dependency_Projects = new HashSet<Project>();
        }

        public void AddDependencyProjects(Project project)
        {
            Dependency_Projects.Add(project);
        }
    }
}
