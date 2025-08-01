using Microsoft.Data.SqlClient;

namespace GLOB.Infra.Extz;

public static partial class Exts_Infra
{
    public static void EnsureDatabaseExists(this string con)
  {
    "Ensuring DB Exsist".Print("EF Core");
    var builder = new SqlConnectionStringBuilder(con);
    string db = builder.InitialCatalog;

    // Use 'master' DB for checking and creation
    builder.InitialCatalog = "master";

    using var connection = new SqlConnection(builder.ConnectionString);
    connection.Open();

    var cmdText = $@"
        IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'{db}')
        BEGIN
            CREATE DATABASE [{db}];
        END";

    using var command = new SqlCommand(cmdText, connection);
    command.ExecuteNonQuery();
  }
}