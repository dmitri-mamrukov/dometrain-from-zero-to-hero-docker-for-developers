FROM mcr.microsoft.com/mssql/server:2022-latest

COPY ./Database/wait-and-run.sh /wait-and-run.sh
COPY ./Database/CreateDatabaseAndSeed.sql /CreateDatabaseAndSeed.sql

CMD /wait-and-run.sh
