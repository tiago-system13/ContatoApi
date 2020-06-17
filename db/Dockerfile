FROM mcr.microsoft.com/mssql/server:2017-latest
EXPOSE 1433
ENV CHECK_POLICY=OFF
ENV ACCEPT_EULA=Y
ENV MSSQL_PID=Developer
ENV SA_PASSWORD=contato@pi10
COPY ./db/dataset/create_base_contato.sql /home/database/create_base_contato.sql
COPY ./bdiApi/ci/init_database.sh /docker-entrypoint-initdb.d/init_database.sh
