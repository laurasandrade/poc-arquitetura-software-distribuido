#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["NuGet.Config", "."]
COPY ["poc.pos.arquiteturasoftwaredistribuido.api.WebApi/poc.pos.arquiteturasoftwaredistribuido.api.WebApi.csproj", "poc.pos.arquiteturasoftwaredistribuido.api.WebApi/"]
COPY ["poc.pos.arquiteturasoftwaredistribuido.api.Service/poc.pos.arquiteturasoftwaredistribuido.api.Service.csproj", "poc.pos.arquiteturasoftwaredistribuido.api.Service/"]
COPY ["poc.pos.arquiteturasoftwaredistribuido.api.Domain/poc.pos.arquiteturasoftwaredistribuido.api.Domain.csproj", "poc.pos.arquiteturasoftwaredistribuido.api.Domain/"]
COPY ["poc.pos.arquiteturasoftwaredistribuido.api.Infra.Entity/poc.pos.arquiteturasoftwaredistribuido.api.Infra.Entity.csproj", "poc.pos.arquiteturasoftwaredistribuido.api.Infra.Entity/"]
RUN dotnet restore "poc.pos.arquiteturasoftwaredistribuido.api.WebApi/poc.pos.arquiteturasoftwaredistribuido.api.WebApi.csproj"
COPY . .
WORKDIR "/src/poc.pos.arquiteturasoftwaredistribuido.api.WebApi"
RUN dotnet build "poc.pos.arquiteturasoftwaredistribuido.api.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "poc.pos.arquiteturasoftwaredistribuido.api.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "poc.pos.arquiteturasoftwaredistribuido.api.WebApi.dll"]