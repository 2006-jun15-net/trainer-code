# usage instructions:
# 1. docker build -t dockerized-built-mvc:1.0 .
# 2. docker run -it --rm -p 8000:80 dockerized-built-mvc:1.0

FROM mcr.microsoft.com/dotnet/core/sdk:3.1

WORKDIR /app/src

# copy whole build context into /app/src
COPY . ./

# publish to /app/publish
RUN dotnet publish -o ../publish

WORKDIR /app/publish

ENV ASPNETCORE_URLS=http://+:80

CMD dotnet DockerizedBuiltMvc.dll
