global using Spectre.Console;
using MiembroCase.Database;
using MiembroCase.Screens;
using MiembroCase.Repositories;
using MiembroCase.Services;
class Program {
  public static void Main(string[] args) {

    // 📁 Conexión a la base de datos
  var db = new Database(@"C:\Users\ingel\OneDrive\Desktop\APP_Consola_Fitlife\MiembroCase.db");

    // 🧠 Repository (acceso SQL)
    MiembroRepository miembroRepository = new(db);

    // ⚙️ Service (lógica)
    MiembroService miembroService = new(miembroRepository);

    // 🖥️ Pantalla (menú)
    MainScreen mainScreen = new(miembroService);

    // 🚀 Ejecutar programa
    mainScreen.Show();
  }
}