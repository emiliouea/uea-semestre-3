 
using VacunacionCovid.Interfaces;
using VacunacionCovid.Models;

namespace VacunacionCovid.Services
{
    public class VaccinationAnalyzer : IVaccinationAnalyzer
    {
        public HashSet<Ciudadano> ObtenerCiudadanosNoVacunados(HashSet<Ciudadano> todosCiudadanos, HashSet<RegistroVacunacion> todasVacunaciones)
        {
            // Conjunto de ciudadanos vacunados
            var ciudadanosVacunados = new HashSet<int>(
                todasVacunaciones.Select(v => v.CiudadanoId)
            );

            // Diferencia: Todos los ciudadanos - Ciudadanos vacunados
            return new HashSet<Ciudadano>(
                todosCiudadanos.Where(c => !ciudadanosVacunados.Contains(c.Id))
            );
        }

        public HashSet<Ciudadano> ObtenerCiudadanosConAmbasDosis(HashSet<Ciudadano> todosCiudadanos, HashSet<RegistroVacunacion> todasVacunaciones)
        {
            // Agrupar vacunaciones por ciudadano
            var vacunacionesPorCiudadano = todasVacunaciones
                .GroupBy(v => v.CiudadanoId)
                .ToDictionary(g => g.Key, g => g.ToList());

            // Ciudadanos con ambas dosis (primera Y segunda)
            var ciudadanosAmbasDosis = new HashSet<int>();

            foreach (var kvp in vacunacionesPorCiudadano)
            {
                var vacunaciones = kvp.Value;
                bool tienePrimera = vacunaciones.Any(v => v.NumeroDosis == NumeroDosis.Primera);
                bool tieneSegunda = vacunaciones.Any(v => v.NumeroDosis == NumeroDosis.Segunda);

                if (tienePrimera && tieneSegunda)
                {
                    ciudadanosAmbasDosis.Add(kvp.Key);
                }
            }

            // Intersección: Todos los ciudadanos ∩ Ciudadanos con ambas dosis
            return new HashSet<Ciudadano>(
                todosCiudadanos.Where(c => ciudadanosAmbasDosis.Contains(c.Id))
            );
        }

        public HashSet<Ciudadano> ObtenerCiudadanosSoloPfizer(HashSet<Ciudadano> todosCiudadanos, HashSet<RegistroVacunacion> todasVacunaciones)
        {
            // Ciudadanos vacunados con Pfizer
            var ciudadanosPfizer = new HashSet<int>(
                todasVacunaciones
                    .Where(v => v.TipoVacuna == TipoVacuna.Pfizer)
                    .Select(v => v.CiudadanoId)
            );

            // Ciudadanos vacunados con AstraZeneca
            var ciudadanosAstraZeneca = new HashSet<int>(
                todasVacunaciones
                    .Where(v => v.TipoVacuna == TipoVacuna.AstraZeneca)
                    .Select(v => v.CiudadanoId)
            );

            // Diferencia: Ciudadanos con Pfizer - Ciudadanos con AstraZeneca
            var ciudadanosSoloPfizer = new HashSet<int>(ciudadanosPfizer);
            ciudadanosSoloPfizer.ExceptWith(ciudadanosAstraZeneca);

            return new HashSet<Ciudadano>(
                todosCiudadanos.Where(c => ciudadanosSoloPfizer.Contains(c.Id))
            );
        }

        public HashSet<Ciudadano> ObtenerCiudadanosSoloAstraZeneca(HashSet<Ciudadano> todosCiudadanos, HashSet<RegistroVacunacion> todasVacunaciones)
        {
            // Ciudadanos vacunados con AstraZeneca
            var ciudadanosAstraZeneca = new HashSet<int>(
                todasVacunaciones
                    .Where(v => v.TipoVacuna == TipoVacuna.AstraZeneca)
                    .Select(v => v.CiudadanoId)
            );

            // Ciudadanos vacunados con Pfizer
            var ciudadanosPfizer = new HashSet<int>(
                todasVacunaciones
                    .Where(v => v.TipoVacuna == TipoVacuna.Pfizer)
                    .Select(v => v.CiudadanoId)
            );

            // Diferencia: Ciudadanos con AstraZeneca - Ciudadanos con Pfizer
            var ciudadanosSoloAstraZeneca = new HashSet<int>(ciudadanosAstraZeneca);
            ciudadanosSoloAstraZeneca.ExceptWith(ciudadanosPfizer);

            return new HashSet<Ciudadano>(
                todosCiudadanos.Where(c => ciudadanosSoloAstraZeneca.Contains(c.Id))
            );
        }
    }
}
