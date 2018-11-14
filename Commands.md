# Useful Commands

Unless stated otherwise, all commands are to be run from the `BugTracker.Web` directory

## AppIdentiyContext

This dbcontext stores the Identity/Auth stuff. To create the initial migration, run the following command:

``` bash
dotnet ef migrations add CreateIdentitySchema -c AppIdentityDbContext -p ../BugTracker.Repo/BugTracker.Repo.csproj -s BugTracker.Web.csproj
```

This will add the initial migration required to set up Identity in that database. To apply that migration, run the following command:

``` bash
dotnet ef database update -c AppIdentityDbContext -p ../BugTracker.Repo/BugTracker.Repo.csproj -s BugTracker.Web.csproj
```

### DataContext

This dbcontext stores the Bug (and related) entities. To creat the initial migration, run the following command:

``` bash
dotnet ef migrations add InitialMigration -c DataContext -p ../BugTracker.Repo/BugTracker.Repo.csproj -s BugTracker.Web.csproj
```

``` bash
dotnet ef database update -c DataContext -p ../BugTracker.Repo/BugTracker.Repo.csproj -s BugTracker.Web.cspr
```