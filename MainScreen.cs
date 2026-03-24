using MiembroCase.Services;

namespace MiembroCase.Screens;

class MainScreen(MiembroService miembroService) {
  private bool running = true;
  private readonly MiembroService _miembroService = miembroService;

  private readonly (string Text, int Value)[] choices = [
    ("1. Listar miembros", 1),
    ("2. Registrar miembro", 2),
    ("3. Buscar por cédula", 3),
    ("4. Actualizar teléfono", 4),
    ("5. Eliminar miembro", 5),
    ("6. Salir", 0)
  ];

  public void Show() {
    while (running) {

      var selection = new SelectionPrompt<(string Text, int Value)>()
        .Title("📋 Sistema de Miembros")
        .AddChoices(choices)
        .UseConverter(c => $"{c.Text}");

      var choiced = AnsiConsole.Prompt(selection);

      switch (choiced.Value) {

        //listar
        case 1:
          var table = new Table();
          table.AddColumn("Cédula");
          table.AddColumn("Nombre");
          table.AddColumn("Teléfono");

          foreach (var m in _miembroService.SelectAll()) {
            table.AddRow(
              $"{m.Cedula}",
              $"{m.nombre_completo}",
              $"{m.Telefono}"
            );
          }

          AnsiConsole.Write(table);
          break;

        //registrar
        case 2:
         var cedula = AnsiConsole.Ask<long>("Cédula:");
          var nombre_completo = AnsiConsole.Ask<string>("Nombre completo:");
          var telefono = AnsiConsole.Ask<string>("Teléfono:");

          _miembroService.Insert(cedula, nombre_completo, telefono);
          AnsiConsole.WriteLine("Miembro registrado!");
          break;

        //buscar
        case 3:
          var buscarCedula = AnsiConsole.Ask<long>("Ingrese cédula:");
          var miembro = _miembroService.GetByCedula(buscarCedula);

          if (miembro != null) {
            AnsiConsole.WriteLine($"Nombre: {miembro.nombre_completo}");
            AnsiConsole.WriteLine($"Teléfono: {miembro.Telefono}");
          } else {
            AnsiConsole.WriteLine("No encontrado");
          }
          break;

        //ACTUALIZAR TELÉFONO
        case 4:
         var ced = AnsiConsole.Ask<long>("Cédula:");
          var tel = AnsiConsole.Ask<string>("Nuevo teléfono:");
          _miembroService.UpdateTelefono(ced, tel);
          AnsiConsole.WriteLine("Actualizado!");
          break;

        //ELIMINAR
        case 5:
          var delCed = AnsiConsole.Ask<long>("Cédula a eliminar:");
          _miembroService.Delete(delCed);
          AnsiConsole.WriteLine("Eliminado!");
          break;

        //SALIR
        case 0:
          running = false;
          Console.WriteLine("Saliendo...");
          break;
      }
    }
  }
}