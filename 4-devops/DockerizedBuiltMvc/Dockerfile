# usage instructions:
# 1. docker build -t dockerized-built-mvc:1.0 .
# 2. docker run -it --rm -p 8000:80 dockerized-built-mvc:1.0

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-alpine AS build

WORKDIR /app/src

# maybe i need a dotnet global tool like dotnet ef
# RUN dotnet tool install --global dotnet-ef

# maybe i need some library/other dep installed to the OS
# RUN apk update && apk add python3

# maybe it's not an OS package but it's just an executable we can download
# RUN wget http://some-program.com
# RUN ./some-program

# copy just csproj file (the only thing we actually need for dotnet restore)
COPY *.csproj ./
RUN dotnet restore

# if the csproj file hasn't changed, we can cache up to this point
# (saves time on subsequent builds)

# copy rest of build context into /app/src
COPY . ./

# publish to /app/publish
RUN dotnet publish -o ../publish

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-alpine AS runtime

WORKDIR /app

# copy assemblies from build stage into this stage
COPY --from=build /app/publish ./

CMD dotnet DockerizedBuiltMvc.dll
