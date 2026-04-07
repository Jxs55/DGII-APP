FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY DGII.sln ./
COPY DGII.API/DGII.API.csproj DGII.API/
COPY DGII.Core/DGII.Core.csproj DGII.Core/
COPY DGII.Infrastructure/DGII.Infrastructure.csproj DGII.Infrastructure/

RUN dotnet restore DGII.API/DGII.API.csproj

COPY . ./
WORKDIR /src/DGII.API
RUN dotnet publish DGII.API.csproj -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

COPY --from=build /app/publish ./

ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

ENTRYPOINT ["dotnet", "DGII.API.dll"]
