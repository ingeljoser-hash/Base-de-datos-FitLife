using Microsoft.Data.Sqlite;

namespace MiembroCase.Database;

class Database(string dbPath)
{
  private readonly string _connectionPath = $"Data Source={dbPath}";

  public SqliteConnection GetConnection()
  {
    var connection = new SqliteConnection(_connectionPath);
    connection.Open();


    var command = connection.CreateCommand();
    command.CommandText = @"
      CREATE TABLE IF NOT EXISTS Miembros (
        cedula INTEGER PRIMARY KEY,
        nombre_completo TEXT NOT NULL,
        telefono TEXT NOT NULL
      );
    ";
    command.ExecuteNonQuery();

    return connection;
  }
}