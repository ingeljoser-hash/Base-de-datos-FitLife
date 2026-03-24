using MiembroCase.Repositories;
using MiembroCase.Database;
using MiembroCase.Models;

namespace MiembroCase.Repositories;

class MiembroRepository(MiembroCase.Database.Database db) {
  private readonly MiembroCase.Database.Database _db = db;

  public List<MiembroModel> SelectAll() {
    using var connection = _db.GetConnection();
    using var command = connection.CreateCommand();

    command.CommandText = "SELECT * FROM Miembros;";

    using var reader = command.ExecuteReader();

    List<MiembroModel> miembros = [];

    while (reader.Read()) {
      miembros.Add(
        new MiembroModel() {
          Cedula = reader.GetInt64(0),
          nombre_completo = reader.GetString(1),
          Telefono = reader.GetString(2)
        }
      );
    }

    return miembros;
  }


  //aqui busco la cedula
  public MiembroModel? GetByCedula(long cedula) {
    using var connection = _db.GetConnection();
    using var command = connection.CreateCommand();

    command.CommandText = "SELECT * FROM Miembros WHERE cedula = @cedula;";
    command.Parameters.AddWithValue("@cedula", cedula);

    using var reader = command.ExecuteReader();

    if (reader.Read()) {
      return new MiembroModel() {
        Cedula = reader.GetInt64(0),
        nombre_completo = reader.GetString(1),
        Telefono = reader.GetString(2)
      };
    }

    return null;
  }

  //insertar datos
  public int Insert(long cedula, string nombre_completo, string telefono) {
    using var connection = _db.GetConnection();
    using var command = connection.CreateCommand();

    command.CommandText = @"
      INSERT INTO Miembros (Cedula, nombre_completo, Telefono)
      VALUES (@Cedula, @nombre_completo, @Telefono);
    ";

    command.Parameters.AddWithValue("@Cedula", cedula);
    command.Parameters.AddWithValue("@nombre_completo", nombre_completo);
    command.Parameters.AddWithValue("@Telefono", telefono);

    return command.ExecuteNonQuery();
  }

  //actualizar telefono
  public int UpdateTelefono(long cedula, string telefono) {
    using var connection = _db.GetConnection();
    using var command = connection.CreateCommand();

    command.CommandText = @"
      UPDATE Miembros
      SET Telefono = @Telefono
      WHERE Cedula = @Cedula;
    ";

    command.Parameters.AddWithValue("@Telefono", telefono);
    command.Parameters.AddWithValue("@Cedula", cedula);

    return command.ExecuteNonQuery();
  }

  //eliminar miembro
  public int Delete(long Cedula) {
    using var connection = _db.GetConnection();
    using var command = connection.CreateCommand();

    command.CommandText = "DELETE FROM Miembros WHERE Cedula = @Cedula;";
    command.Parameters.AddWithValue("@Cedula", Cedula);

    return command.ExecuteNonQuery();
  }
}