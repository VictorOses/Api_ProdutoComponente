#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
#EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Api_Full06/Api_Full06.csproj", "Api_Full06/"]
RUN dotnet restore "Api_Full06/Api_Full06.csproj"
COPY . .
WORKDIR "/src/Api_Full06"
RUN dotnet build "Api_Full06.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Api_Full06.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Api_Full06.dll"]