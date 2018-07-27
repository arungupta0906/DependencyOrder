using System;
using System.Collections.Generic;
using System.Linq;
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

            string[] expectedResult = new string[] { "c", "b", "a"};
            ResolveDependencyOrder resolveDependency = new ResolveDependencyOrder();
            HashSet<Project> StartUpProjects = resolveDependency.GetStartUpProjects(AllProjects);
            foreach (Project project in StartUpProjects)
                resolveDependency.ResolveDependency(project);
            var actualResult = resolveDependency.ex_seq_Projects.ToArray();
            Assert.Equal(expectedResult.Length, actualResult.Length);
            for(int i = 0; i < actualResult.Length; i++)
            {
                Assert.Equal(expectedResult[i], actualResult[i].Name);
            }
        }

        [Fact]
        public void ResolveDependencyOrder_Test2()
        {
            Project ProjectA = new Project("a");
            Project ProjectB = new Project("b");
            Project ProjectC = new Project("c");

            ProjectA.AddDependencyProjects(ProjectB);
            ProjectB.AddDependencyProjects(ProjectC);
            ProjectC.AddDependencyProjects(ProjectA);

            HashSet<Project> AllProjects = new HashSet<Project>();
            AllProjects.Add(ProjectA);
            AllProjects.Add(ProjectB);
            AllProjects.Add(ProjectC);

            ResolveDependencyOrder resolveDependency = new ResolveDependencyOrder();

            var exception = Record.Exception(() => resolveDependency.GetStartUpProjects(AllProjects));
            Assert.NotNull(exception);
            Assert.IsType<Exception>(exception);
            Assert.Equal($"No Start Up Project Exists !!!", exception.Message);
        }

        [Fact]
        public void ResolveDependencyOrder_Test3()
        {
            Project ProjectA = new Project("a");
            Project ProjectB = new Project("b");
            Project ProjectC = new Project("c");

            ProjectA.AddDependencyProjects(ProjectB);
            ProjectA.AddDependencyProjects(ProjectC);

            HashSet<Project> AllProjects = new HashSet<Project>();
            AllProjects.Add(ProjectA);
            AllProjects.Add(ProjectB);
            AllProjects.Add(ProjectC);

            string[] expectedResult = new string[] { "b", "c", "a" };
            ResolveDependencyOrder resolveDependency = new ResolveDependencyOrder();
            HashSet<Project> StartUpProjects = resolveDependency.GetStartUpProjects(AllProjects);
            foreach (Project project in StartUpProjects)
                resolveDependency.ResolveDependency(project);
            var actualResult = resolveDependency.ex_seq_Projects.ToArray();
            Assert.Equal(expectedResult.Length, actualResult.Length);
            for (int i = 0; i < actualResult.Length; i++)
            {
                Assert.Equal(expectedResult[i], actualResult[i].Name);
            }
        }

        [Fact]
        public void ResolveDependencyOrder_Test4()
        {
            Project ProjectA = new Project("a");
            Project ProjectB = new Project("b");
            Project ProjectC = new Project("c");
            Project ProjectD = new Project("d");

            ProjectA.AddDependencyProjects(ProjectB);
            ProjectA.AddDependencyProjects(ProjectC);
            ProjectA.AddDependencyProjects(ProjectD);

            HashSet<Project> AllProjects = new HashSet<Project>();
            AllProjects.Add(ProjectA);
            AllProjects.Add(ProjectB);
            AllProjects.Add(ProjectC);
            AllProjects.Add(ProjectD);

            string[] expectedResult = new string[] { "b", "c", "d", "a" };
            ResolveDependencyOrder resolveDependency = new ResolveDependencyOrder();
            HashSet<Project> StartUpProjects = resolveDependency.GetStartUpProjects(AllProjects);
            foreach (Project project in StartUpProjects)
                resolveDependency.ResolveDependency(project);
            var actualResult = resolveDependency.ex_seq_Projects.ToArray();
            Assert.Equal(expectedResult.Length, actualResult.Length);
            for (int i = 0; i < actualResult.Length; i++)
            {
                Assert.Equal(expectedResult[i], actualResult[i].Name);
            }
        }

        [Fact]
        public void ResolveDependencyOrder_Test5()
        {
            Project ProjectA = new Project("a");
            Project ProjectB = new Project("b");
            Project ProjectC = new Project("c");
            Project ProjectD = new Project("d");
            Project ProjectE = new Project("e");

            ProjectA.AddDependencyProjects(ProjectB);
            ProjectA.AddDependencyProjects(ProjectD);
            ProjectC.AddDependencyProjects(ProjectD);
            ProjectB.AddDependencyProjects(ProjectC);
            ProjectB.AddDependencyProjects(ProjectE);

            HashSet<Project> AllProjects = new HashSet<Project>();
            AllProjects.Add(ProjectA);
            AllProjects.Add(ProjectB);
            AllProjects.Add(ProjectC);
            AllProjects.Add(ProjectD);
            AllProjects.Add(ProjectE);

            string[] expectedResult = new string[] { "d", "c", "e", "b", "a" };
            ResolveDependencyOrder resolveDependency = new ResolveDependencyOrder();
            HashSet<Project> StartUpProjects = resolveDependency.GetStartUpProjects(AllProjects);
            foreach (Project project in StartUpProjects)
                resolveDependency.ResolveDependency(project);
            var actualResult = resolveDependency.ex_seq_Projects.ToArray();
            Assert.Equal(expectedResult.Length, actualResult.Length);
            for (int i = 0; i < actualResult.Length; i++)
            {
                Assert.Equal(expectedResult[i], actualResult[i].Name);
            }
        }

        [Fact]
        public void ResolveDependencyOrder_Test6()
        {
            Project ProjectA = new Project("a");
            Project ProjectB = new Project("b");
            Project ProjectC = new Project("c");
            Project ProjectD = new Project("d");
            Project ProjectE = new Project("e");

            ProjectA.AddDependencyProjects(ProjectB);
            ProjectA.AddDependencyProjects(ProjectD);
            ProjectC.AddDependencyProjects(ProjectD);
            ProjectB.AddDependencyProjects(ProjectC);
            ProjectB.AddDependencyProjects(ProjectE);
            ProjectD.AddDependencyProjects(ProjectB);

            HashSet<Project> AllProjects = new HashSet<Project>();
            AllProjects.Add(ProjectA);
            AllProjects.Add(ProjectB);
            AllProjects.Add(ProjectC);
            AllProjects.Add(ProjectD);
            AllProjects.Add(ProjectE);

            ResolveDependencyOrder resolveDependency = new ResolveDependencyOrder();
            HashSet<Project> StartUpProjects = resolveDependency.GetStartUpProjects(AllProjects);
            var exception = Record.Exception(() => resolveDependency.ResolveDependency(StartUpProjects.FirstOrDefault()));
            Assert.NotNull(exception);
            Assert.IsType<Exception>(exception);
            Assert.Equal($"Circular reference detected: d -> b !!!", exception.Message);           
        }

        [Fact]
        public void ResolveDependencyOrder_Test7()
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
            ProjectA.AddDependencyProjects(ProjectF);
            ProjectA.AddDependencyProjects(ProjectG);
            ProjectC.AddDependencyProjects(ProjectD);
            ProjectB.AddDependencyProjects(ProjectC);
            ProjectB.AddDependencyProjects(ProjectE);
            ProjectF.AddDependencyProjects(ProjectE);
            ProjectF.AddDependencyProjects(ProjectG);

            HashSet<Project> AllProjects = new HashSet<Project>();
            AllProjects.Add(ProjectA);
            AllProjects.Add(ProjectB);
            AllProjects.Add(ProjectC);
            AllProjects.Add(ProjectD);
            AllProjects.Add(ProjectE);
            AllProjects.Add(ProjectF);
            AllProjects.Add(ProjectG);

            string[] expectedResult = new string[] { "d", "c", "e", "b", "g", "f", "a" };
            ResolveDependencyOrder resolveDependency = new ResolveDependencyOrder();
            HashSet<Project> StartUpProjects = resolveDependency.GetStartUpProjects(AllProjects);
            foreach (Project project in StartUpProjects)
                resolveDependency.ResolveDependency(project);
            var actualResult = resolveDependency.ex_seq_Projects.ToArray();
            Assert.Equal(expectedResult.Length, actualResult.Length);
            for (int i = 0; i < actualResult.Length; i++)
            {
                Assert.Equal(expectedResult[i], actualResult[i].Name);
            }
        }

        [Fact]
        public void ResolveDependencyOrder_Test8()
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
            ProjectA.AddDependencyProjects(ProjectF);
            ProjectC.AddDependencyProjects(ProjectD);
            ProjectB.AddDependencyProjects(ProjectC);
            ProjectB.AddDependencyProjects(ProjectE);
            ProjectF.AddDependencyProjects(ProjectE);

            HashSet<Project> AllProjects = new HashSet<Project>();
            AllProjects.Add(ProjectA);
            AllProjects.Add(ProjectB);
            AllProjects.Add(ProjectC);
            AllProjects.Add(ProjectD);
            AllProjects.Add(ProjectE);
            AllProjects.Add(ProjectF);
            AllProjects.Add(ProjectG);

            string[] expectedResult = new string[] { "d", "c", "e", "b", "f", "a", "g" };
            ResolveDependencyOrder resolveDependency = new ResolveDependencyOrder();
            HashSet<Project> StartUpProjects = resolveDependency.GetStartUpProjects(AllProjects);
            foreach (Project project in StartUpProjects)
                resolveDependency.ResolveDependency(project);
            var actualResult = resolveDependency.ex_seq_Projects.ToArray();
            Assert.Equal(expectedResult.Length, actualResult.Length);
            for (int i = 0; i < actualResult.Length; i++)
            {
                Assert.Equal(expectedResult[i], actualResult[i].Name);
            }
        }

        [Fact]
        public void ResolveDependencyOrder_Test9()
        {
            Project ProjectA = new Project("a");
            Project ProjectB = new Project("b");
            Project ProjectC = new Project("c");
            Project ProjectD = new Project("d");
            Project ProjectE = new Project("e");
            Project ProjectF = new Project("f");
            Project ProjectG = new Project("g");
            Project ProjectH = new Project("h");
            Project ProjectI = new Project("i");

            ProjectA.AddDependencyProjects(ProjectB);
            ProjectA.AddDependencyProjects(ProjectD);
            ProjectA.AddDependencyProjects(ProjectF);
            ProjectC.AddDependencyProjects(ProjectD);
            ProjectB.AddDependencyProjects(ProjectC);
            ProjectB.AddDependencyProjects(ProjectE);
            ProjectF.AddDependencyProjects(ProjectE);
            ProjectF.AddDependencyProjects(ProjectH);
            ProjectH.AddDependencyProjects(ProjectE);
            ProjectI.AddDependencyProjects(ProjectH);
            ProjectG.AddDependencyProjects(ProjectH);
            ProjectG.AddDependencyProjects(ProjectF);
            ProjectG.AddDependencyProjects(ProjectI);

            HashSet<Project> AllProjects = new HashSet<Project>();
            AllProjects.Add(ProjectA);
            AllProjects.Add(ProjectB);
            AllProjects.Add(ProjectC);
            AllProjects.Add(ProjectD);
            AllProjects.Add(ProjectE);
            AllProjects.Add(ProjectF);
            AllProjects.Add(ProjectG);
            AllProjects.Add(ProjectH);
            AllProjects.Add(ProjectI);

            string[] expectedResult = new string[] { "d", "c", "e", "b", "h", "f", "a", "i", "g" };
            ResolveDependencyOrder resolveDependency = new ResolveDependencyOrder();
            HashSet<Project> StartUpProjects = resolveDependency.GetStartUpProjects(AllProjects);
            foreach (Project project in StartUpProjects)
                resolveDependency.ResolveDependency(project);
            var actualResult = resolveDependency.ex_seq_Projects.ToArray();
            Assert.Equal(expectedResult.Length, actualResult.Length);
            for (int i = 0; i < actualResult.Length; i++)
            {
                Assert.Equal(expectedResult[i], actualResult[i].Name);
            }
        }

        [Fact]
        public void ResolveDependencyOrder_Test10()
        {
            Project ProjectA = new Project("a");
            Project ProjectB = new Project("b");
            Project ProjectC = new Project("c");
            Project ProjectD = new Project("d");
            Project ProjectE = new Project("e");
            Project ProjectF = new Project("f");
            Project ProjectG = new Project("g");
            Project ProjectH = new Project("h");
            Project ProjectI = new Project("i");
            Project ProjectJ = new Project("j");

            ProjectA.AddDependencyProjects(ProjectB);
            ProjectA.AddDependencyProjects(ProjectD);
            ProjectA.AddDependencyProjects(ProjectF);
            ProjectC.AddDependencyProjects(ProjectD);
            ProjectB.AddDependencyProjects(ProjectC);
            ProjectB.AddDependencyProjects(ProjectE);
            ProjectF.AddDependencyProjects(ProjectE);
            ProjectF.AddDependencyProjects(ProjectH);
            ProjectH.AddDependencyProjects(ProjectE);
            ProjectH.AddDependencyProjects(ProjectJ);
            ProjectI.AddDependencyProjects(ProjectH);
            ProjectI.AddDependencyProjects(ProjectJ);
            ProjectG.AddDependencyProjects(ProjectH);
            ProjectG.AddDependencyProjects(ProjectF);

            HashSet<Project> AllProjects = new HashSet<Project>();
            AllProjects.Add(ProjectA);
            AllProjects.Add(ProjectB);
            AllProjects.Add(ProjectC);
            AllProjects.Add(ProjectD);
            AllProjects.Add(ProjectE);
            AllProjects.Add(ProjectF);
            AllProjects.Add(ProjectG);
            AllProjects.Add(ProjectH);
            AllProjects.Add(ProjectI);

            string[] expectedResult = new string[] { "d", "c", "e", "b", "j", "h", "f", "a", "g", "i" };
            ResolveDependencyOrder resolveDependency = new ResolveDependencyOrder();
            HashSet<Project> StartUpProjects = resolveDependency.GetStartUpProjects(AllProjects);
            foreach (Project project in StartUpProjects)
                resolveDependency.ResolveDependency(project);
            var actualResult = resolveDependency.ex_seq_Projects.ToArray();
            Assert.Equal(expectedResult.Length, actualResult.Length);
            for (int i = 0; i < actualResult.Length; i++)
            {
                Assert.Equal(expectedResult[i], actualResult[i].Name);
            }
        }

        [Fact]
        public void ResolveDependencyOrder_Test11()
        {
            Project ProjectA = new Project("a");

            HashSet<Project> AllProjects = new HashSet<Project>();
            AllProjects.Add(ProjectA);

            string[] expectedResult = new string[] { "a" };
            ResolveDependencyOrder resolveDependency = new ResolveDependencyOrder();
            HashSet<Project> StartUpProjects = resolveDependency.GetStartUpProjects(AllProjects);
            foreach (Project project in StartUpProjects)
                resolveDependency.ResolveDependency(project);
            var actualResult = resolveDependency.ex_seq_Projects.ToArray();
            Assert.Equal(expectedResult.Length, actualResult.Length);
            for (int i = 0; i < actualResult.Length; i++)
            {
                Assert.Equal(expectedResult[i], actualResult[i].Name);
            }
        }

        [Fact]
        public void ResolveDependencyOrder_Test12()
        {
            Project ProjectA = new Project("a");
            Project ProjectB = new Project("b");

            HashSet<Project> AllProjects = new HashSet<Project>();
            AllProjects.Add(ProjectA);
            AllProjects.Add(ProjectB);

            string[] expectedResult = new string[] { "a", "b" };
            ResolveDependencyOrder resolveDependency = new ResolveDependencyOrder();
            HashSet<Project> StartUpProjects = resolveDependency.GetStartUpProjects(AllProjects);
            foreach (Project project in StartUpProjects)
                resolveDependency.ResolveDependency(project);
            var actualResult = resolveDependency.ex_seq_Projects.ToArray();
            Assert.Equal(expectedResult.Length, actualResult.Length);
            for (int i = 0; i < actualResult.Length; i++)
            {
                Assert.Equal(expectedResult[i], actualResult[i].Name);
            }
        }
    }
}
