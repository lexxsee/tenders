FROM mcr.microsoft.com/dotnet/aspnet:5.0-alpine AS base
RUN apk add --no-cache tzdata
RUN apk add --no-cache icu-libs

ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
ENV TZ=Europe/Moscow

WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0-alpine AS build
WORKDIR /src
COPY ./Solution/ Solution/

WORKDIR /src/Solution/Tenders.Api
RUN dotnet build -c Release 

FROM build AS publish
RUN dotnet publish --no-restore --no-build -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Tenders.Api.dll"]