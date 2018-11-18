FROM microsoft/dotnet:2.1-sdk-alpine AS build
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
COPY ./bugTracker.Core.Api/bugTracker.Core.Api.csproj ./bugTracker.Core.Api/bugTracker.Core.Api.csproj

# Restore all packages
RUN dotnet restore ./bugTracker.Core.Api/bugTracker.Core.Api.csproj --force --no-cache

# Copy the remaining source
COPY ./bugTracker.Core.Common/ ./bugTracker.Core.Common/
COPY ./bugTracker.Core.DAL/ ./bugTracker.Core.DAL/
COPY ./bugTracker.Core.DTO/ ./bugTracker.Core.DTO/
COPY ./bugTracker.Core.Entities/ ./bugTracker.Core.Entities/
COPY ./bugTracker.Core.Persistence/ ./bugTracker.Core.Persistence/
COPY ./bugTracker.Core.Tests/ ./bugTracker.Core.Tests/
COPY ./bugTracker.Core.Api/ ./bugTracker.Core.Api/

# Build the source code
RUN dotnet build ./bugTracker.Core.Api/bugTracker.Core.Api.csproj --configuration Release --no-restore

# Ensure that we generate and migrate the database 
WORKDIR ./bugTracker.Core.Persistence
RUN dotnet ef database update

# # Run all tests
# WORKDIR ./bugTracker.Core.Tests
# RUN dotnet xunit

# Publish application
WORKDIR ..
RUN dotnet publish ./bugTracker.Core.Api/bugTracker.Core.Api.csproj --configuration Release --output "../dist"

# Copy the created database
RUN cp ./bugTracker.Core.Persistence/bugTracker.db ./dist/bugTracker.db

# Build runtime image
FROM microsoft/dotnet:2.1-aspnetcore-runtime-alpine AS app
WORKDIR /app
COPY --from=build /build/dist .
ENV ASPNETCORE_URLS http://+:80

ENTRYPOINT ["dotnet", "bugTracker.Core.Api.dll"]