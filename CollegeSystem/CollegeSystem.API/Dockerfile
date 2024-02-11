
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["CollegeSystem.API/CollegeSystem.API.csproj", "CollegeSystem.API/"]
COPY ["CollegeSystem.BL/CollegeSystem.BL.csproj", "CollegeSystem.BL/"]
COPY ["CollegeSystem.DAL/CollegeSystem.DAL.csproj", "CollegeSystem.DAL/"]
COPY ["User.Management.Services/User.Management.Services.csproj", "User.Management.Services/"]
RUN dotnet restore "CollegeSystem.API/CollegeSystem.API.csproj"
COPY . .
WORKDIR "/src/CollegeSystem.API"
RUN dotnet build "CollegeSystem.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CollegeSystem.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CollegeSystem.API.dll"]




#FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS build
#WORKDIR /app 
##
## copy csproj and restore as distinct layers
#COPY *.sln .
#COPY ["CollegeSystem.API/CollegeSystem.API.csproj", "CollegeSystem.API/"]
#COPY ["CollegeSystem.BL/CollegeSystem.BL.csproj", "CollegeSystem.BL/"]
#COPY ["CollegeSystem.DAL/CollegeSystem.DAL.csproj", "CollegeSystem.DAL/"]
#COPY ["User.Management.Services/User.Management.Services.csproj", "User.Management.Services/"]
#
#RUN dotnet restore "CollegeSystem.API/CollegeSystem.API.csproj"
##RUN dotnet restore "CollegeSystem.BL/CollegeSystem.BL.csproj"
##RUN dotnet restore "CollegeSystem.DAL/CollegeSystem.DAL.csproj"
##RUN dotnet restore "User.Management.Services/User.Management.Services.csproj"
#
## copy everything else and build app
#COPY CollegeSystem.API/. ./CollegeSystem.API/
#COPY CollegeSystem.BL/. ./CollegeSystem.BL/
#COPY CollegeSystem.DAL/. ./CollegeSystem.DAL/ 
##
#WORKDIR /app/CollegeSystem
#RUN dotnet publish -c Release -o out 
##
#FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
#WORKDIR /app 
##
#COPY --from=build /app/CollegeSystem/out ./
#ENTRYPOINT ["dotnet", "CollegeSystem.API.dll"]