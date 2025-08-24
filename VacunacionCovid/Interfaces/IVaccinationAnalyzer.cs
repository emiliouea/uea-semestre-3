 
using VacunacionCovid.Models;

namespace VacunacionCovid.Interfaces
{
    public interface IVaccinationAnalyzer
    {
        HashSet<Ciudadano> ObtenerCiudadanosNoVacunados(HashSet<Ciudadano> todosCiudadanos, HashSet<RegistroVacunacion> todasVacunaciones);
        HashSet<Ciudadano> ObtenerCiudadanosConAmbasDosis(HashSet<Ciudadano> todosCiudadanos, HashSet<RegistroVacunacion> todasVacunaciones);
        HashSet<Ciudadano> ObtenerCiudadanosSoloPfizer(HashSet<Ciudadano> todosCiudadanos, HashSet<RegistroVacunacion> todasVacunaciones);
        HashSet<Ciudadano> ObtenerCiudadanosSoloAstraZeneca(HashSet<Ciudadano> todosCiudadanos, HashSet<RegistroVacunacion> todasVacunaciones);
    }
}
