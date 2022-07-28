# Introduction 
A simple prescriptive net6 microservice template, using CQRS & DDD.

# Build and Install Template

```bash
dotnet pack ./src
dotnet new -i ./src/bin/Debug/Cqrs.Microservice.Templates.1.0.0.nupkg
dotnet new ms-cqrs-es --projectName My.Awesome.Project
```

# Edit template

Just open up `PROJECT_NAME.sln` and make the required changes. Then use the commands above to regenerate the NuGet package and update the template installed in your local machine.