
using VacunacionCovid.Interfaces;
using VacunacionCovid.Models;

namespace VacunacionCovid.Services
{
    public class DataGenerator : IDataGenerator
    {
        private readonly Random _random = new Random();
        private readonly string[] _nombres = {
            "María", "Carlos", "Ana", "José", "Laura", "Miguel", "Carmen", "Antonio",
            "Isabel", "Francisco", "Pilar", "Manuel", "Rosa", "David", "Mercedes",
            "Javier", "Patricia", "Rafael", "Elena", "Fernando", "Cristina", "Luis"
        };

        private readonly string[] _apellidos = {
            "García", "Rodríguez", "González", "Fernández", "López", "Martínez",
            "Sánchez", "Pérez", "Gómez", "Martín", "Jiménez", "Ruiz", "Hernández",
            "Díaz", "Moreno", "Álvarez", "Muñoz", "Romero", "Alonso", "Gutiérrez"
        };

        private readonly string[] _lugares = {
            "Centro de Salud Norte", "Hospital General", "Clínica San José",
            "Centro Médico Central", "Hospital Metropolitano", "Clínica La Esperanza"
        };

        public HashSet<Ciudadano> GenerarCiudadanos(int cantidad)
        {
            var ciudadanos = new HashSet<Ciudadano>();

            for (int i = 1; i <= cantidad; i++)
            {
                var ciudadano = new Ciudadano(
                    id: i,
                    nombre: $"{_nombres[_random.Next(_nombres.Length)]} {_apellidos[_random.Next(_apellidos.Length)]}",
                    cedula: GenerarCedula(i),
                    fechaNacimiento: GenerarFechaNacimiento(),
                    email: $"ciudadano{i}@email.com",
                    telefono: GenerarTelefono()
                );
                ciudadanos.Add(ciudadano);
            }

            return ciudadanos;
        }

        public HashSet<RegistroVacunacion> GenerarVacunacionesPfizer(HashSet<Ciudadano> ciudadanos, int cantidad)
        {
            return GenerarVacunaciones(ciudadanos, cantidad, TipoVacuna.Pfizer);
        }

        public HashSet<RegistroVacunacion> GenerarVacunacionesAstraZeneca(HashSet<Ciudadano> ciudadanos, int cantidad)
        {
            return GenerarVacunaciones(ciudadanos, cantidad, TipoVacuna.AstraZeneca);
        }

        private HashSet<RegistroVacunacion> GenerarVacunaciones(HashSet<Ciudadano> ciudadanos, int cantidad, TipoVacuna tipoVacuna)
        {
            var vacunaciones = new HashSet<RegistroVacunacion>();
            var ciudadanosSeleccionados = ciudadanos.OrderBy(x => _random.Next()).Take(cantidad).ToList();
            int registroId = (tipoVacuna == TipoVacuna.Pfizer) ? 1 : 1000;

            foreach (var ciudadano in ciudadanosSeleccionados)
            {
                var fechaPrimera = GenerarFechaVacunacion();

                // Primera dosis
                var primeraDosis = new RegistroVacunacion(
                    id: registroId++,
                    ciudadanoId: ciudadano.Id,
                    tipoVacuna: tipoVacuna,
                    numeroDosis: NumeroDosis.Primera,
                    fechaVacunacion: fechaPrimera,
                    lugarVacunacion: _lugares[_random.Next(_lugares.Length)]
                );
                vacunaciones.Add(primeraDosis);

                // 70% de probabilidad de tener segunda dosis
                if (_random.NextDouble() < 0.7)
                {
                    var fechaSegunda = fechaPrimera.AddDays(_random.Next(21, 42));
                    var segundaDosis = new RegistroVacunacion(
                        id: registroId++,
                        ciudadanoId: ciudadano.Id,
                        tipoVacuna: tipoVacuna,
                        numeroDosis: NumeroDosis.Segunda,
                        fechaVacunacion: fechaSegunda,
                        lugarVacunacion: _lugares[_random.Next(_lugares.Length)]
                    );
                    vacunaciones.Add(segundaDosis);
                }
            }

            return vacunaciones;
        }

        private string GenerarCedula(int id)
        {
            return $"17{id:D8}";
        }

        private DateTime GenerarFechaNacimiento()
        {
            var inicio = new DateTime(1950, 1, 1);
            var fin = new DateTime(2005, 12, 31);
            var rango = fin - inicio;
            var diasAleatorios = _random.Next(rango.Days);
            return inicio.AddDays(diasAleatorios);
        }

        private string GenerarTelefono()
        {
            return $"09{_random.Next(10000000, 99999999)}";
        }

        private DateTime GenerarFechaVacunacion()
        {
            var inicio = new DateTime(2021, 1, 1);
            var fin = new DateTime(2023, 12, 31);
            var rango = fin - inicio;
            var diasAleatorios = _random.Next(rango.Days);
            return inicio.AddDays(diasAleatorios);
        }
    }
}
