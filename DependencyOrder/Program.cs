using System;
using System.Collections.Generic;
using System.Linq;

namespace DependencyOrder
{
    class Program
    {
        static void Main(string[] args)
        {
            bool flag = true;
            HashSet<Project> AllProjects = new HashSet<Project>();
            while (flag)
            {
                Console.Write($"Enter Project Name (Enter 'NA' If Don't Want To Add Next Project): ");
                string ProjectName = Console.ReadLine();
                if (!ProjectName.Equals("NA", StringComparison.OrdinalIgnoreCase))
                    AllProjects.Add(new Project(ProjectName));
                else
                    flag = false;
            }
            if (AllProjects?.Count > 1)
            {
                foreach (Project p in AllProjects)
                {
                    flag = true;
                    while (flag)
                    {
                        Console.Write($"Enter Dependency Projects for {p.Name} seperated by space (Enter 'NA' if no dependency project exists): ");
                        string DependencyProjects = Console.ReadLine();
                        if (!DependencyProjects.Equals("NA", StringComparison.OrdinalIgnoreCase))
                        {
                            string[] projects = DependencyProjects.Split(' ');
                            foreach (string project in projects)
                            {
                                var dependencyproject = AllProjects.ToList().Where(x => x.Name.Equals(project, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
                                if (dependencyproject != null)
                                {
                                    p.AddDependencyProjects(dependencyproject);
                                    flag = false;
                                }
                                else
                                    Console.WriteLine($"Project {project} does not exists. Please try again.");
                            }
                        }
                        else
                            flag = false;
                    }
                }
            }

            ResolveDependencyOrder resolveDependency = new ResolveDependencyOrder();            
            try
            {
                HashSet<Project> StartUpProjects = resolveDependency.GetStartUpProjects(AllProjects);
                foreach (Project project in StartUpProjects)
                    resolveDependency.ResolveDependency(project);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine();
            Console.WriteLine("Order of Project Execution");
            resolveDependency.ShowProjectsExecutionSequence();
            Console.ReadLine();
        }
    }    
}
