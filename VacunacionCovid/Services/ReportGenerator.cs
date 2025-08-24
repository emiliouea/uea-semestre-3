 
using System.Text; 
using VacunacionCovid.Models;

namespace VacunacionCovid.Services
{
    public class ReportGenerator
    {
        public void GenerarReporteConsola(
            HashSet<Ciudadano> noVacunados,
            HashSet<Ciudadano> ambasDosis,
            HashSet<Ciudadano> soloPfizer,
            HashSet<Ciudadano> soloAstraZeneca,
            HashSet<Ciudadano> todosCiudadanos,
            HashSet<RegistroVacunacion> todasVacunaciones)
        {
            Console.WriteLine("=".PadRight(80, '='));
            Console.WriteLine("REPORTE DE CAMPAÑA DE VACUNACIÓN COVID-19");
            Console.WriteLine("Ministerio de Salud - Gobierno Nacional");
            Console.WriteLine($"Fecha de generación: {DateTime.Now:dd/MM/yyyy HH:mm:ss}");
            Console.WriteLine("=".PadRight(80, '='));
            Console.WriteLine();

            // Resumen estadístico
            Console.WriteLine("RESUMEN ESTADÍSTICO:");
            Console.WriteLine($"Total de ciudadanos registrados: {todosCiudadanos.Count:N0}");
            Console.WriteLine($"Total de registros de vacunación: {todasVacunaciones.Count:N0}");
            Console.WriteLine($"Ciudadanos no vacunados: {noVacunados.Count:N0} ({(double)noVacunados.Count / todosCiudadanos.Count * 100:F1}%)");
            Console.WriteLine($"Ciudadanos con esquema completo: {ambasDosis.Count:N0} ({(double)ambasDosis.Count / todosCiudadanos.Count * 100:F1}%)");
            Console.WriteLine();

            // Detalles por categoría
            MostrarCategoria("1. CIUDADANOS NO VACUNADOS", noVacunados);
            MostrarCategoria("2. CIUDADANOS CON AMBAS DOSIS", ambasDosis);
            MostrarCategoria("3. CIUDADANOS SOLO CON PFIZER", soloPfizer);
            MostrarCategoria("4. CIUDADANOS SOLO CON ASTRAZENECA", soloAstraZeneca);

            Console.WriteLine("=".PadRight(80, '='));
            Console.WriteLine("Fin del reporte");
            Console.WriteLine("=".PadRight(80, '='));
        }

        public void GenerarReporteArchivo(
            HashSet<Ciudadano> noVacunados,
            HashSet<Ciudadano> ambasDosis,
            HashSet<Ciudadano> soloPfizer,
            HashSet<Ciudadano> soloAstraZeneca,
            HashSet<Ciudadano> todosCiudadanos,
            HashSet<RegistroVacunacion> todasVacunaciones,
            string nombreArchivo = "reporte_vacunacion.txt")
        {
            // Crear carpeta Reports si no existe
            string carpetaReports = Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "..", "Reports");
            if (!Directory.Exists(carpetaReports))
            {
                Directory.CreateDirectory(carpetaReports);
            }

            // Generar nombre único con timestamp
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            string nombreArchivoConTimestamp = Path.GetFileNameWithoutExtension(nombreArchivo) +
                                             $"_{timestamp}" +
                                             Path.GetExtension(nombreArchivo);

            string rutaCompleta = Path.Combine(carpetaReports, nombreArchivoConTimestamp);

            var contenido = new StringBuilder();

            contenido.AppendLine("=".PadRight(80, '='));
            contenido.AppendLine("REPORTE DE CAMPAÑA DE VACUNACIÓN COVID-19");
            contenido.AppendLine("Ministerio de Salud - Gobierno Nacional");
            contenido.AppendLine($"Fecha de generación: {DateTime.Now:dd/MM/yyyy HH:mm:ss}");
            contenido.AppendLine("=".PadRight(80, '='));
            contenido.AppendLine();

            // Resumen estadístico
            contenido.AppendLine("RESUMEN ESTADÍSTICO:");
            contenido.AppendLine($"Total de ciudadanos registrados: {todosCiudadanos.Count:N0}");
            contenido.AppendLine($"Total de registros de vacunación: {todasVacunaciones.Count:N0}");
            contenido.AppendLine($"Ciudadanos no vacunados: {noVacunados.Count:N0} ({(double)noVacunados.Count / todosCiudadanos.Count * 100:F1}%)");
            contenido.AppendLine($"Ciudadanos con esquema completo: {ambasDosis.Count:N0} ({(double)ambasDosis.Count / todosCiudadanos.Count * 100:F1}%)");
            contenido.AppendLine();

            // Detalles por categoría
            AgregarCategoriaArchivo(contenido, "1. CIUDADANOS NO VACUNADOS", noVacunados);
            AgregarCategoriaArchivo(contenido, "2. CIUDADANOS CON AMBAS DOSIS", ambasDosis);
            AgregarCategoriaArchivo(contenido, "3. CIUDADANOS SOLO CON PFIZER", soloPfizer);
            AgregarCategoriaArchivo(contenido, "4. CIUDADANOS SOLO CON ASTRAZENECA", soloAstraZeneca);

            contenido.AppendLine("=".PadRight(80, '='));
            contenido.AppendLine("Fin del reporte");
            contenido.AppendLine("=".PadRight(80, '='));

            try
            {
                File.WriteAllText(rutaCompleta, contenido.ToString(), Encoding.UTF8);
                Console.WriteLine($"✓ Reporte guardado exitosamente en:");
                Console.WriteLine($"  {Path.GetFullPath(rutaCompleta)}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"✗ Error al guardar el reporte: {ex.Message}");
                Console.WriteLine("Intentando guardar en directorio actual...");

                // Fallback: guardar en directorio actual si falla
                string rutaFallback = Path.Combine(Directory.GetCurrentDirectory(), nombreArchivoConTimestamp);
                File.WriteAllText(rutaFallback, contenido.ToString(), Encoding.UTF8);
                Console.WriteLine($"✓ Reporte guardado en: {Path.GetFullPath(rutaFallback)}");
            }
        }

        private void MostrarCategoria(string titulo, HashSet<Ciudadano> ciudadanos)
        {
            Console.WriteLine(titulo);
            Console.WriteLine($"Total: {ciudadanos.Count:N0} ciudadanos");
            Console.WriteLine("-".PadRight(50, '-'));

            if (ciudadanos.Count > 0)
            {
                int contador = 1;
                foreach (var ciudadano in ciudadanos)
                {
                    Console.WriteLine($"{contador:D3}. {ciudadano}");
                    contador++;
                    if (contador > 10) // Limitar a 10 para no saturar la consola
                    {
                        Console.WriteLine($"... y {ciudadanos.Count - 10} más");
                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine("No hay ciudadanos en esta categoría.");
            }
            Console.WriteLine();
        }

        private void AgregarCategoriaArchivo(StringBuilder contenido, string titulo, HashSet<Ciudadano> ciudadanos)
        {
            contenido.AppendLine(titulo);
            contenido.AppendLine($"Total: {ciudadanos.Count:N0} ciudadanos");
            contenido.AppendLine("-".PadRight(50, '-'));

            if (ciudadanos.Count > 0)
            {
                int contador = 1;
                foreach (var ciudadano in ciudadanos)
                {
                    contenido.AppendLine($"{contador:D3}. {ciudadano}");
                    contador++;
                }
            }
            else
            {
                contenido.AppendLine("No hay ciudadanos en esta categoría.");
            }
            contenido.AppendLine();
        }
    }
}
