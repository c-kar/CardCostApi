# Get Base SDK Image from Microsoft
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /app

# Copy the CSPROJ file and restore any dependecies
COPY ./CardCost.sln /app
COPY ./CardCost.Api/ /app/CardCost.Api/
COPY ./CardCost.Application/ /app/CardCost.Application/
COPY ./CardCost.Core/ /app/CardCost.Core/
COPY ./CardCost.Infrastructure/ /app/CardCost.Infrastructure/
COPY ./CardCost.Tests/ /app/CardCost.Tests/

RUN dotnet restore ./CardCost.sln

# Build our release
RUN dotnet publish -c Release -o out

# Generate Runtime image 
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
EXPOSE 5000/tcp
ENV ASPNETCORE_URLS http://*:5000
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "CardCost.Api.dll"]