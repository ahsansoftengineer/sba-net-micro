FROM mcr.microsoft.com/mssql/server:2022-latest

ENV ACCEPT_EULA=Y
ENV MSSQL_SA_PASSWORD=Pa55word!

# Persistent Data (Container Dir)
VOLUME /var/opt/mssql

EXPOSE 1433

CMD ["/opt/mssql/bin/sqlservr"]

