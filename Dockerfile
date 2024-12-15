# Use the .NET SDK to build the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Set the working directory inside the container
WORKDIR /src

# Copy the project file and restore dependencies
COPY ["LibraryManagement/LibraryManagement.csproj", "LibraryManagement/"]
RUN dotnet restore "LibraryManagement/LibraryManagement.csproj"

# Copy the entire project source code into the container
COPY . .
WORKDIR "/src/LibraryManagement"

# Build the application in Release mode
RUN dotnet build "LibraryManagement.csproj" -c Release -o /app/build

# Publish the application
RUN dotnet publish "LibraryManagement.csproj" -c Release -o /app/publish

# Use the runtime image for running the application
FROM mcr.microsoft.com/dotnet/runtime:8.0 AS runtime

# Set the working directory for the runtime
WORKDIR /app

# Copy the published application from the previous stage
COPY --from=build /app/publish .

# Specify the entry point for the application
ENTRYPOINT ["dotnet", "LibraryManagement.dll"]
 