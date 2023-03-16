#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Net_Core_Common_API/Net_Core_Common_API.csproj", "Net_Core_Common_API/"]
COPY ["Net_Core_Common_Model/Net_Core_Common_Model.csproj", "Net_Core_Common_Model/"]
COPY ["Net_Core_Common_Repository/Net_Core_Common_Repository.csproj", "Net_Core_Common_Repository/"]
COPY ["Net_Core_Common_Services/Net_Core_Common_Services.csproj", "Net_Core_Common_Services/"]
RUN dotnet restore "Net_Core_Common_API/Net_Core_Common_API.csproj"
COPY . .
WORKDIR "/src/Net_Core_Common_API"
RUN dotnet build "Net_Core_Common_API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Net_Core_Common_API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Net_Core_Common_API.dll"]