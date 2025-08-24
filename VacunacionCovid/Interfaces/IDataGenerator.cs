 
using VacunacionCovid.Models;

namespace VacunacionCovid.Interfaces
{
    public interface IDataGenerator
    {
        HashSet<Ciudadano> GenerarCiudadanos(int cantidad);
        HashSet<RegistroVacunacion> GenerarVacunacionesPfizer(HashSet<Ciudadano> ciudadanos, int cantidad);
        HashSet<RegistroVacunacion> GenerarVacunacionesAstraZeneca(HashSet<Ciudadano> ciudadanos, int cantidad);
    }
}
