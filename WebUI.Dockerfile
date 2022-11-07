FROM mcr.microsoft.com/dotnet/sdk:2.1-alpine AS build
# Set the working directory witin the container
WORKDIR /build

# Copy the sln and csproj files. These are the only files
# required in order to restore
COPY ./bugTracker.Core.Common/bugTracker.Core.Common.csproj ./bugTracker.Core.Common/bugTracker.Core.Common.csproj
COPY ./bugTracker.Core.DAL/bugTracker.Core.DAL.csproj ./bugTracker.Core.DAL/bugTracker.Core.DAL.csproj
COPY ./bugTracker.Core.DTO/bugTracker.Core.DTO.csproj ./bugTracker.Core.DTO/bugTracker.Core.DTO.csproj
COPY ./bugTracker.Core.Entities/bugTracker.Core.Entities.csproj ./bugTracker.Core.Entities/bugTracker.Core.Entities.csproj
COPY ./bugTracker.Core.Persistence/bugTracker.Core.Persistence.csproj ./bugTracker.Core.Persistence/bugTracker.Core.Persistence.csproj
COPY ./bugTracker.Core.Tests/bugTracker.Core.Tests.csproj ./bugTracker.Core.Tests/bugTracker.Core.Tests.csproj
COPY ./bugTracker.Core.WebUI/bugTracker.Core.WebUI.csproj ./bugTracker.Core.WebUI/bugTracker.Core.WebUI.csproj

# Restore all packages
RUN dotnet restore ./bugTracker.Core.WebUI/bugTracker.Core.WebUI.csproj --force --no-cache

# Copy the remaining source
COPY ./bugTracker.Core.Common/ ./bugTracker.Core.Common/
COPY ./bugTracker.Core.DAL/ ./bugTracker.Core.DAL/
COPY ./bugTracker.Core.DTO/ ./bugTracker.Core.DTO/
COPY ./bugTracker.Core.Entities/ ./bugTracker.Core.Entities/
COPY ./bugTracker.Core.Persistence/ ./bugTracker.Core.Persistence/
COPY ./bugTracker.Core.Tests/ ./bugTracker.Core.Tests/
COPY ./bugTracker.Core.WebUI/ ./bugTracker.Core.WebUI/

# Build the source code
RUN dotnet build ./bugTracker.Core.WebUI/bugTracker.Core.WebUI.csproj --configuration Release --no-restore

# Publish application
RUN dotnet publish ./bugTracker.Core.WebUI/bugTracker.Core.WebUI.csproj --configuration Release --output "../dist"

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:2.1-alpine AS app
WORKDIR /app
COPY --from=build /build/dist .
ENV ASPNETCORE_URLS http://+:80

ENTRYPOINT ["dotnet", "bugTracker.Core.WebUI.dll"]
