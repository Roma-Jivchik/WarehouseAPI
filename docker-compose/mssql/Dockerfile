# We choose exact tag (not 'latest'), to be sure that new version won't break creating image
FROM mcr.microsoft.com/mssql/server:2022-latest

# Create a config directory
USER root
RUN mkdir -p /usr/src/app
WORKDIR /usr/src/app

# Bundle config source
COPY . /usr/src/app


# Grant permissions for to our scripts to be executable
USER root
RUN chmod +x /usr/src/app/entrypoint.sh
RUN chmod +x /usr/src/app/configure-db.sh

RUN apt-get update && apt-get install -y dos2unix
RUN dos2unix /usr/src/app/entrypoint.sh && dos2unix /usr/src/app/configure-db.sh
RUN apt-get --purge remove -y dos2unix && rm -rf /var/lib/apt/lists/*


# Run Microsoft SQl Server and initialization script (at the same time)
# Note: If you want to start MsSQL only (without initialization script) you can comment bellow line out, CMD entry from base image will be taken
USER mssql
ENTRYPOINT ["/usr/src/app/entrypoint.sh"]