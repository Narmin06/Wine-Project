FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY App.sln ./
COPY App.API/App.API.csproj App.API/
COPY App.Business/App.Business.csproj App.Business/
COPY App.Core/App.Core.csproj App.Core/
COPY App.DAL/App.DAL.csproj App.DAL/
COPY App.Shared/App.Shared.csproj App.Shared/

RUN dotnet restore App.sln

# qalan bütün faylları kopyala
COPY . ./

# publish
RUN dotnet publish App.API/App.API.csproj -c Release -o /app/publish --no-restore

# 2) Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

COPY --from=build /app/publish ./

# Səndə launchSettings-də port 5034 idi
ENV ASPNETCORE_URLS=http://+:5034
EXPOSE 5034

ENTRYPOINT ["dotnet", "App.API.dll"]
