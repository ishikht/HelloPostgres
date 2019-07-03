#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see http://aka.ms/containercompat 


FROM mcr.microsoft.com/dotnet/framework/sdk:4.8 AS build
WORKDIR /app

# copy csproj and restore as distinct layers
COPY *.sln .
COPY HelloPostgres/*.csproj ./HelloPostgres/
COPY HelloPostgres/*.config ./HelloPostgres/
RUN nuget restore

# copy everything else and build app
COPY HelloPostgres/. ./HelloPostgres/
WORKDIR /app/HelloPostgres
RUN msbuild /p:Configuration=Release


FROM mcr.microsoft.com/dotnet/framework/aspnet:4.7.2-windowsservercore-ltsc2019 AS runtime
WORKDIR /inetpub/wwwroot
COPY --from=build /app/HelloPostgres/. ./

