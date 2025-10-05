public class GrafoVuelos
    {
        private Dictionary<string, List<Vuelo>> grafo;

        public GrafoVuelos()
        {
            grafo = new Dictionary<string, List<Vuelo>>();
        }

        public void AgregarCiudad(string ciudad)
        {
            if (!grafo.ContainsKey(ciudad))
                grafo[ciudad] = new List<Vuelo>();
        }

        public void AgregarVuelo(string origen, string destino, int costo)
        {
            AgregarCiudad(origen);
            AgregarCiudad(destino);
            grafo[origen].Add(new Vuelo(destino, costo));
        }

        public List<string> ObtenerCiudades() => grafo.Keys.ToList();

        public void VisualizarRutas()
        {
            Console.WriteLine("\n------------------------------------------------------");
            Console.WriteLine("     TODAS LAS RUTAS DE VUELO DISPONIBLES             ");
            Console.WriteLine("--------------------------------------------------------\n");

            int contador = 1;
            foreach (var ciudad in grafo.Keys.OrderBy(c => c))
            {
                if (grafo[ciudad].Count > 0)
                {
                    Console.WriteLine($" Desde {ciudad}:");
                    foreach (var vuelo in grafo[ciudad].OrderBy(v => v.Costo))
                    {
                        Console.WriteLine($"   {contador}.   → {vuelo.Destino.PadRight(20)} ${vuelo.Costo}");
                        contador++;
                    }
                    Console.WriteLine();
                }
            }
        }

        public void ConsultarVuelosDirectos(string origen)
        {
            if (!grafo.ContainsKey(origen))
            {
                Console.WriteLine($"\n La ciudad '{origen}' no existe en el sistema.");
                return;
            }

            Console.WriteLine($"\n----------------------------------------------------------");
            Console.WriteLine($"     VUELOS DIRECTOS DESDE {origen.ToUpper().PadRight(27)}");
            Console.WriteLine("-------------------------------------------------------------\n");

            if (grafo[origen].Count == 0)
            {
                Console.WriteLine(" No hay vuelos directos disponibles desde esta ciudad.\n");
                return;
            }

            int i = 1;
            foreach (var vuelo in grafo[origen].OrderBy(v => v.Costo))
            {
                Console.WriteLine($"{i}.  {origen} → {vuelo.Destino.PadRight(20)} ${vuelo.Costo}");
                i++;
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Aplica Dijkstra para encontrar la ruta más barata entre dos ciudades
        /// </summary>
        public void BuscarRutaMasBarata(string origen, string destino)
        {
            if (!grafo.ContainsKey(origen) || !grafo.ContainsKey(destino))
            {
                Console.WriteLine("\n Una o ambas ciudades no existen en el sistema.");
                return;
            }

            var distancias = new Dictionary<string, int>();
            var previos = new Dictionary<string, string>();
            var visitados = new HashSet<string>();
            var porVisitar = new SortedSet<(int costo, string ciudad)>();

            foreach (var ciudad in grafo.Keys)
                distancias[ciudad] = int.MaxValue;

            distancias[origen] = 0;
            porVisitar.Add((0, origen));

            while (porVisitar.Count > 0)
            {
                var actual = porVisitar.Min;
                porVisitar.Remove(actual);
                string ciudadActual = actual.ciudad;

                if (visitados.Contains(ciudadActual))
                    continue;

                visitados.Add(ciudadActual);
                if (ciudadActual == destino)
                    break;

                foreach (var vuelo in grafo[ciudadActual])
                {
                    if (visitados.Contains(vuelo.Destino))
                        continue;

                    int nuevaDistancia = distancias[ciudadActual] + vuelo.Costo;

                    if (nuevaDistancia < distancias[vuelo.Destino])
                    {
                        distancias[vuelo.Destino] = nuevaDistancia;
                        previos[vuelo.Destino] = ciudadActual;
                        porVisitar.Add((nuevaDistancia, vuelo.Destino));
                    }
                }
            }

            MostrarResultadoBusqueda(origen, destino, distancias, previos);
        }

        private void MostrarResultadoBusqueda(string origen, string destino,
            Dictionary<string, int> distancias, Dictionary<string, string> previos)
        {
            Console.WriteLine("\n------------------------------------------------------");
            Console.WriteLine("          RESULTADO DE BÚSQUEDA DE VUELO                ");
            Console.WriteLine("--------------------------------------------------------\n");

            if (distancias[destino] == int.MaxValue)
            {
                Console.WriteLine($" No hay ruta disponible de {origen} a {destino}\n");
                return;
            }

            var ruta = new List<string>();
            string actual = destino;
            while (actual != null)
            {
                ruta.Insert(0, actual);
                previos.TryGetValue(actual, out actual);
            }

            Console.WriteLine($" Origen:  {origen}");
            Console.WriteLine($" Destino: {destino}");
            Console.WriteLine($" Costo Total: ${distancias[destino]}");
            Console.WriteLine($" Escalas: {ruta.Count - 2}\n");
            Console.WriteLine(" Ruta completa:");

            for (int i = 0; i < ruta.Count; i++)
            {
                if (i == 0)
                    Console.Write($"   {ruta[i]}");
                else
                    Console.Write($" → {ruta[i]}");
            }
            Console.WriteLine("\n");
        }

        public void MostrarEstadisticas()
        {
            int totalCiudades = grafo.Count;
            int totalRutas = grafo.Values.Sum(lista => lista.Count);
            int costoPromedio = totalRutas > 0 ?
                grafo.Values.SelectMany(v => v).Sum(v => v.Costo) / totalRutas : 0;

            Console.WriteLine("\n------------------------------------------------------");
            Console.WriteLine("           ESTADÍSTICAS DEL SISTEMA                   ");
            Console.WriteLine("--------------------------------------------------------\n");
            Console.WriteLine($" Total de ciudades: {totalCiudades}");
            Console.WriteLine($"  Total de rutas: {totalRutas}");
            Console.WriteLine($" Costo promedio por vuelo: ${costoPromedio}");
            Console.WriteLine();
        }
    }
