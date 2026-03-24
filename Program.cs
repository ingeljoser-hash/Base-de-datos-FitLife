global using Spectre.Console;
using MiembroCase.Database;
using MiembroCase.Screens;
using MiembroCase.Repositories;
using MiembroCase.Services;
class Program {
  public static void Main(string[] args) {


  var db = new Database(@"C:\Users\ingel\OneDrive\Desktop\APP_Consola_Fitlife\MiembroCase.db");


    MiembroRepository miembroRepository = new(db);


    MiembroService miembroService = new(miembroRepository);


    MainScreen mainScreen = new(miembroService);

    mainScreen.Show();
  }
}