This is a simple console version of a dependency problem program.
The problem is solved using graph. Each project is describe by single node and dependent projects are connected with edges as sub-node.
I have also added other test samples file with the sample of test cases I executed.

The program should works as follows:  
 1. Add all the projects.
 2. Add dependency projects for each project.
 3. Output will give order of project execution. 

 Following is the exexution order:
 1. Create all the projects by entering the project name. Enter 'NA' if don't want to add next project.
 2. After all projects are added, project will ask to enter dependency projects for each project added in step # 1.
 3. Enter dependency projects seperated by space. Enter 'NA' if no dependency projects exists for any project.
 4. If dependecy projects are not in the project list created in step # 1, then system will prompt that this dependency projects does not exists and re-try to enter the dependecy projects for that particular project. 
 5. Once all the dependency projects are added, system will give the project execution.


 *** Assumptions ***

- Project name is given as single character
- Give exception message if no start project exists
- Give exception if circular dependecy exists as mentioned in test case # 6

*** The Solution ***

The solution has been developped using 'Visual Studio 2017' on 'Windows 10' targeting the '.NET Framework Core 2.1'.

The main app has no dependencies other than .NET


*** Test Solution ***

Test solution are added for unit testing & integration testing

Test Framework: Xunit & Moq 

*** Build and run ***

The solution can be built and ran (including the tests) the usual way using Visual Studio.



