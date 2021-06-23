#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["AcademiaMW/AcademiaMW.csproj", "src/AcademiaMW/"]
COPY ["AcademiaMW.Infra/AcademiaMW.Infra.csproj", "src/AcademiaMW.Infra/"]
COPY ["AcademiaMW.Business/AcademiaMW.Business.csproj", "src/AcademiaMW.Business/"]
COPY ["AcademiaMW.Core/AcademiaMW.Core.csproj", "src/AcademiaMW.Core/"]
RUN dotnet restore "src/AcademiaMW/AcademiaMW.csproj"
COPY . .
WORKDIR "/src/AcademiaMW"
RUN dotnet build "AcademiaMW.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AcademiaMW.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AcademiaMW.dll"]