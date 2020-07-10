# usage instructions:
# 1. dotnet publish -o publish
# 2. docker build -t dockerized-mvc:1.0 .
# 3. docker run [...]

# step one of writing a new dockerfile is, what base image you want to use.

# two main things we like to see in a base image:
# 1. has most/all of the things we need already, and not too much things we don't
# 2. it's well maintained, updated, used by lots of people

# you make images from the Dockerfile recipe with "docker build"...
# docker build has several important arguments...
# positional argument: the build context.
#     (the folder which will be visible to the image building process)
#     (commonly, we type ".", current directory.)
# -f: location of the Dockerfile to use
#     (default to ./Dockerfile)
# -t: tag the image so we can reference it with some name besides a long hash

# you can have images stored locally
# (they aren't stored in any particular folder, the docker server holds them)
# but usually images come from a registry

#                       |--------tag---------|
#        registry         repository      tag
#            v                  v          v
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
