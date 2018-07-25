using System;
using System.Collections.Generic;

namespace DependencyOrder
{
    class Program
    {
        static void Main(string[] args)
        {
            Project ProjectA = new Project("a");
            Project ProjectB = new Project("b");
            Project ProjectC = new Project("c");
            Project ProjectD = new Project("d");
            Project ProjectE = new Project("e");

            Project ProjectF = new Project("f");
            Project ProjectG = new Project("g");

            ProjectA.AddDependencyProjects(ProjectB);
            ProjectA.AddDependencyProjects(ProjectD);
            ProjectA.AddDependencyProjects(ProjectC);
            ProjectA.AddDependencyProjects(ProjectE);
            ProjectB.AddDependencyProjects(ProjectC);
            ProjectB.AddDependencyProjects(ProjectE);
            ProjectC.AddDependencyProjects(ProjectD);
            ProjectC.AddDependencyProjects(ProjectE);
            ProjectF.AddDependencyProjects(ProjectB);
            ProjectF.AddDependencyProjects(ProjectG);
            ProjectA.AddDependencyProjects(ProjectG);
            //ProjectD.AddDependencyProjects(ProjectB);

            HashSet<Project> AllProjects = new HashSet<Project>();
            AllProjects.Add(ProjectA);
            AllProjects.Add(ProjectB);
            AllProjects.Add(ProjectC);
            AllProjects.Add(ProjectD);
            AllProjects.Add(ProjectE);
            AllProjects.Add(ProjectF);            

            ResolveDependencyOrder resolveDependency = new ResolveDependencyOrder();
            HashSet<Project> StartUpProjects = resolveDependency.GetStartUpProjects(AllProjects);
            try
            {
                foreach(Project project in StartUpProjects)
                    resolveDependency.ResolveDependency(project);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            resolveDependency.ShowProjectsExecutionSequence();
            Console.ReadLine();
        }
    }    
}
