#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build-env

WORKDIR /app
COPY ["./", "./"]

RUN dotnet restore OrderService.csproj

RUN dotnet build OrderService.csproj

RUN dotnet publish OrderService.csproj -c Release -o publish

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim
WORKDIR /app/publish
#EXPOSE 9900
#EXPOSE 80
COPY --from=build-env /app/publish .
ENTRYPOINT ["dotnet", "OrderService.dll"]