using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DependencyOrder.UnitTest
{
    public class ResolveDependencyOrderTest
    {
        [Fact]
        public void ResolveDependencyOrder_Test1()
        {
            Project ProjectA = new Project("a");
            Project ProjectB = new Project("b");
            Project ProjectC = new Project("c");

            ProjectA.AddDependencyProjects(ProjectB);
            ProjectB.AddDependencyProjects(ProjectC);

            HashSet<Project> AllProjects = new HashSet<Project>();
            AllProjects.Add(ProjectA);
            AllProjects.Add(ProjectB);
            AllProjects.Add(ProjectC);

            ResolveDependencyOrder resolveDependency = new ResolveDependencyOrder();
            HashSet<Project> StartUpProjects = resolveDependency.GetStartUpProjects(AllProjects);
            foreach (Project project in StartUpProjects)
                resolveDependency.ResolveDependency(project);
        }
    }
}
