#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["../week3App_External/week3App_External.csproj", "../week3App_External/"]
RUN dotnet restore "../week3App_External/week3App_External.csproj"
COPY . .
WORKDIR "/src/../week3App_External"
RUN dotnet build "week3App_External.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "week3App_External.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "week3App_External.dll"]
