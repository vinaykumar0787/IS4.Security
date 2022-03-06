#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["LMS.UI/LMS.UI.csproj", "LMS.UI/"]
RUN dotnet restore "LMS.UI/LMS.UI.csproj"
COPY . .
WORKDIR "/src/LMS.UI"
RUN dotnet build "LMS.UI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LMS.UI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LMS.UI.dll"]