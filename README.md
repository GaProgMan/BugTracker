# bugTracker.Core - .NET Core

## Licence

[![License: MIT](https://img.shields.io/cran/l/devtools.svg)](https://opensource.org/licenses/GPL-3.0)

## Support This Project

If you have found this project helpful, either as a library that you use or as a learning tool, please consider buying me a coffee:

<a href="https://www.buymeacoffee.com/dotnetcoreshow" target="_blank"><img src="https://www.buymeacoffee.com/assets/img/custom_images/orange_img.png" alt="Buy Me A Coffee" style="height: 41px !important;width: 174px !important" ></a>

## Description

This project is a .NET core implemented Web API for listing Bugs and assigning users to them. For a list of the project aims and whether they have been attained, see the [Project Aims](./ProjectAims.md) file.

It uses Entity Framework Core to communicate with a Sqlite database, which contains a record for each of the Discworld novels.

It has been released, as is, using an MIT licence. For more information on the MIT licence, please see either the `LICENSE` file in the root of the repository or see the tl;dr Legal page for [MIT](https://tldrlegal.com/license/mit-license)

## Code of Conduct
bugTracker.Core has a Code of Conduct which all contributors, maintainers and forkers must adhere to. When contributing, maintaining, forking or in any other way changing the code presented in this repository, all users must agree to this Code of Conduct.

See `Code of Conduct.md` for details.

## Pull Requests

[![PRs Welcome](https://img.shields.io/badge/PRs-welcome-brightgreen.svg?style=flat-square)](http://makeapullrequest.com)

Pull requests are welcome, but please take a moment to read the Code of Conduct before submitting them or commenting on any work in this repo.

## Creating the Database

This will need to be perfored before running the application for the first time

1. Change to the Persistence directory (i.e. `bugTracker.Core/bugTracker.Core.Persistence`)

    `cd bugTracker.Core.Persistence`

1. Issue the Entity Framework command to update the database

    `dotnet ef database update`

    This will ensure that all migrations are used to create or alter the local database instance, ready for seeding (see `Seeding the Database`)

## Building and Running - Non docker

1. Change to the api directory (i.e. `bugTracker.Core/bugTracker.Core.Api`)

    `cd bugTracker.Core.Api`

1. Issue the `dotnet` restore command (this resolves all NuGet packages)

    `dotnet restore`

1. Issue the `dotnet` build command

    `dotnet build`

1. Issue the `dotnet` run command

    `dotnet run`

    This will start the Kestrel webserver, load the `bugTracker.Core.Api` application and tell you, via the terminal, what the url to access `bugTracker.Core` will be. Usually this will be `http://localhost:5000`, but it may be different based on your system configuration.

## Building and Running - docker

1. Ensure that you are in the root directory of the project
1. Run the following command `docker build . -t bug.tracker.api`
1. Once the build process has completed, run the following command: `docker run -d -p 8000:80 bug.tracker.api`

The project should be running on port 8000 of yourt local machine. Heading to `localhost:8000/swagger` should load the swagger API documentation

## Seeding the Database

There are a series of API endpoints related to clearing and seeding the database. These can be found at:

    /Database/DropData
    /Database/SeedData

These two commands (used in conjunction with each other) will drop all data from the database, then seed the database (respectively) from a series of JSON files that can be found in the `SeedData` directory.

`bugTracker.Core.API` has been designed so that the user can add as much data as they like via the JSON files.

## Testing

The unit test library (`bugTracker.Core.Tests`) currently does not run, due to an incompatibility with Xunit's dotnet cli and .NET Core SDK 2.1.5. However, you should be able to run them in a full IDE (i.e. Visual Studio or JetBrains Rider).
