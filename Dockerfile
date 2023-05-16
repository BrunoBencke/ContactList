FROM mcr.microsoft.com/dotnet/aspnet:7.0 as base
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

WORKDIR /source

#Copiar csproj e restaurar as camadas
COPY src/ContactList.Core/*.csproj ./src/ContactList.Core/
COPY src/ContactList.WebApi/*.csproj ./src/ContactList.WebApi/
RUN dotnet restore src/ContactList.WebApi/

#Copiar tudo e fazer a build
COPY . .
WORKDIR /source/src/ContactList.WebApi/
RUN dotnet publish -c Release -o /app
FROM base AS final

#Build com a imagem do runtime

WORKDIR /app
COPY --from=build /app/ .
#ENTRYPOINT ["dotnet", "ContactList.WebApi.dll"]

#Usa porta dinamica
CMD ASPNETCORE_URLS="http://*:$PORT" dotnet ContactList.WebApi.dll
