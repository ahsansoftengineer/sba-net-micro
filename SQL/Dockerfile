FROM mcr.microsoft.com/mssql/server:2022-latest
ENV ACCEPT_EULA=Y
ENV MSSQL_SA_PASSWORD=P@55w0rd!123

EXPOSE 1433
CMD ["/opt/mssql/bin/sqlservr"]

# FROM mcr.microsoft.com/mssql/server:2022-latest

# ENV ACCEPT_EULA=Y
# ENV MSSQL_SA_PASSWORD=Pa55word!

# Persistent Data (Container Dir)
# VOLUME /var/opt/mssql

# # COPY ./setup.sql /usr/config/setup.sql

# EXPOSE 1430

# CMD /bin/bash -c "/opt/mssql/bin/sqlservr & sleep 20 && /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P Pa55word! -i usr/config/setup.sql && wait"