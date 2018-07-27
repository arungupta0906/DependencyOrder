using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyOrder
{
    public class ResolveDependencyOrder
    {
        public HashSet<Project> ex_seq_Projects = null;
        HashSet<Project> resolved_Projects = null;

        public ResolveDependencyOrder()
        {
            ex_seq_Projects = new HashSet<Project>();
            resolved_Projects = new HashSet<Project>();
        }

        public HashSet<Project> GetStartUpProjects(HashSet<Project> AllProjects)
        {
            HashSet<Project> DependencyProjects = new HashSet<Project>();
            foreach (Project project in AllProjects)
            {
                foreach (Project dependencies in project.Dependency_Projects)
                    DependencyProjects.Add(dependencies);
            }

            AllProjects.ExceptWith(DependencyProjects);
            if(AllProjects?.Count > 0)
                return AllProjects;
            else
                throw new Exception($"No Start Up Project Exists !!!");
        }

        public void ResolveDependency(Project start_Project)
        {
            //Console.WriteLine(start_Project.Name);
            resolved_Projects.Add(start_Project);
            foreach (Project dependency_Project in start_Project.Dependency_Projects)
                if (!ex_seq_Projects.Contains(dependency_Project))
                {
                    if (resolved_Projects.Contains(dependency_Project))
                        throw new Exception($"Circular reference detected: {start_Project.Name} -> {dependency_Project.Name} !!!");
                    ResolveDependency(dependency_Project);
                }
            ex_seq_Projects.Add(start_Project);
        }

        public void ShowProjectsExecutionSequence()
        {
            foreach (Project project in ex_seq_Projects)
                Console.Write($"{project.Name}  ");
        }
    }
}
