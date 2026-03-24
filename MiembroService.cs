using MiembroCase.Repositories;
using MiembroCase.Models;

namespace MiembroCase.Services;
 
class MiembroService(MiembroRepository miembroRepository) {
  private readonly MiembroRepository _miembroRepository = miembroRepository;

  public List<MiembroModel> SelectAll() {
    return _miembroRepository.SelectAll();
  }

  public MiembroModel? GetByCedula(long Cedula) {
    return _miembroRepository.GetByCedula(Cedula);
  }

  public int Insert(long Cedula, string nombre_completo, string Telefono) {
    return _miembroRepository.Insert(Cedula, nombre_completo, Telefono);
  }

  public int UpdateTelefono(long Cedula, string Telefono) {
    return _miembroRepository.UpdateTelefono(Cedula, Telefono);
  }

  public int Delete(long Cedula) {
    return _miembroRepository.Delete(Cedula);
  }
}