using VacunacionCovid.Interfaces;
using VacunacionCovid.Models;
using VacunacionCovid.Services;

try
{
    Console.WriteLine("Iniciando Sistema de Análisis de Vacunación COVID-19...");
    Console.WriteLine();

    // Dependency Injection manual (en un proyecto real usaríamos un contenedor IoC)
    IDataGenerator dataGenerator = new DataGenerator();
    IVaccinationAnalyzer analyzer = new VaccinationAnalyzer();
    var reportGenerator = new ReportGenerator();

    // Generar datos ficticios
    Console.WriteLine("Generando datos ficticios...");
    var todosCiudadanos = dataGenerator.GenerarCiudadanos(500);
    var vacunacionesPfizer = dataGenerator.GenerarVacunacionesPfizer(todosCiudadanos, 75);
    var vacunacionesAstraZeneca = dataGenerator.GenerarVacunacionesAstraZeneca(todosCiudadanos, 75);

    // Unir todas las vacunaciones
    var todasVacunaciones = new HashSet<RegistroVacunacion>(vacunacionesPfizer);
    todasVacunaciones.UnionWith(vacunacionesAstraZeneca);

    Console.WriteLine($"✓ Generados {todosCiudadanos.Count} ciudadanos");
    Console.WriteLine($"✓ Generados {vacunacionesPfizer.Count} registros de Pfizer");
    Console.WriteLine($"✓ Generados {vacunacionesAstraZeneca.Count} registros de AstraZeneca");
    Console.WriteLine($"✓ Total de registros de vacunación: {todasVacunaciones.Count}");
    Console.WriteLine();

    // Aplicar operaciones de teoría de conjuntos
    Console.WriteLine("Aplicando operaciones de teoría de conjuntos...");

    var noVacunados = analyzer.ObtenerCiudadanosNoVacunados(todosCiudadanos, todasVacunaciones);
    var ambasDosis = analyzer.ObtenerCiudadanosConAmbasDosis(todosCiudadanos, todasVacunaciones);
    var soloPfizer = analyzer.ObtenerCiudadanosSoloPfizer(todosCiudadanos, todasVacunaciones);
    var soloAstraZeneca = analyzer.ObtenerCiudadanosSoloAstraZeneca(todosCiudadanos, todasVacunaciones);

    Console.WriteLine("✓ Análisis completado");
    Console.WriteLine();

    // Generar reportes
    Console.WriteLine("Generando reportes...");
    reportGenerator.GenerarReporteConsola(noVacunados, ambasDosis, soloPfizer, soloAstraZeneca, todosCiudadanos, todasVacunaciones);
    reportGenerator.GenerarReporteArchivo(noVacunados, ambasDosis, soloPfizer, soloAstraZeneca, todosCiudadanos, todasVacunaciones);

    Console.WriteLine();
    Console.WriteLine("Presione cualquier tecla para salir...");
    Console.ReadKey();
}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
    Console.WriteLine($"Stack trace: {ex.StackTrace}");
    Console.WriteLine("Presione cualquier tecla para salir...");
    Console.ReadKey();
}