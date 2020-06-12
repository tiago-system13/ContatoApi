FROM mcr.microsoft.com/mssql/server:2017-latest
EXPOSE 1433
COPY ./db/dataset/ /home/database/
COPY ./bdiApi/ci/init_database.sh /docker-entrypoint-initdb.d/init_database.sh