 
using System.Diagnostics; 
namespace TorneoFutbolManager
{
    class Tournament
    {
        private Dictionary<int, Player> playersMap = new();
        private Dictionary<int, Team> teamsMap = new();
        private int nextPlayerId = 1, nextTeamId = 1;

        public void Run()
        {
            while (true)
            {
                ShowMenu();
                string option = Console.ReadLine();
                switch (option)
                {
                    case "1": AddPlayer(); break;
                    case "2": AddTeam(); break;
                    case "3": AssignPlayer(); break;
                    case "4": ShowPlayers(); break;
                    case "5": ShowTeams(); break;
                    case "6": RunBenchmark(); break;
                    case "0": return;
                    default:
                        Console.WriteLine("Opción inválida. Intente de nuevo.");
                        break;
                }
            }
        }

        private void ShowMenu()
        {
            Console.WriteLine("\n--- Menú Torneo de Fútbol ---");
            Console.WriteLine("1) Añadir jugador");
            Console.WriteLine("2) Añadir equipo");
            Console.WriteLine("3) Asignar jugador a equipo");
            Console.WriteLine("4) Mostrar jugadores");
            Console.WriteLine("5) Mostrar equipos");
            Console.WriteLine("6) Benchmark");
            Console.WriteLine("0) Salir");
            Console.Write("Seleccione opción: ");
        }

        private void AddPlayer()
        {
            Console.Write("Nombre: ");
            string name = Console.ReadLine();
            int age = ReadInt("Edad: ");

            var player = new Player(nextPlayerId, name, age);
            playersMap.Add(nextPlayerId++, player);

            Console.WriteLine($"Jugador registrado con ID {player.Id}");
        }

        private void AddTeam()
        {
            Console.Write("Nombre del equipo: ");
            string name = Console.ReadLine();

            var team = new Team(nextTeamId, name);
            teamsMap.Add(nextTeamId++, team);

            Console.WriteLine($"Equipo registrado con ID {team.Id}");
        }

        private void AssignPlayer()
        {
            int playerId = ReadInt("ID Jugador: ");
            int teamId = ReadInt("ID Equipo: ");

            if (playersMap.ContainsKey(playerId) && teamsMap.ContainsKey(teamId))
            {
                teamsMap[teamId].AddPlayer(playerId);
                Console.WriteLine($"Jugador {playerId} asignado a equipo {teamId}");
            }
            else
            {
                Console.WriteLine("ID inválido. Verifique los datos e intente nuevamente.");
            }
        }

        private void ShowPlayers()
        {
            if (playersMap.Count == 0)
            {
                Console.WriteLine("No hay jugadores registrados.");
                return;
            }

            Console.WriteLine("\n--- Lista de Jugadores ---");
            foreach (var player in playersMap.Values)
                Console.WriteLine(player);
        }

        private void ShowTeams()
        {
            if (teamsMap.Count == 0)
            {
                Console.WriteLine("No hay equipos registrados.");
                return;
            }

            Console.WriteLine("\n--- Lista de Equipos ---");
            foreach (var team in teamsMap.Values)
            {
                Console.WriteLine($"Equipo {team.Id} - {team.Name}");
                if (team.PlayerIds.Count == 0)
                {
                    Console.WriteLine("   Sin jugadores asignados.");
                    continue;
                }

                foreach (var pid in team.PlayerIds)
                    Console.WriteLine($"   {playersMap[pid]}");
            }
        }

        private void RunBenchmark()
        {
            int n = 10000;
            var dict = new Dictionary<int, Player>();
            var set = new HashSet<int>();
            var sw = Stopwatch.StartNew();

            for (int i = 0; i < n; i++) set.Add(i);
            sw.Stop();
            Console.WriteLine($"Tiempo HashSet.Add({n}): {sw.ElapsedMilliseconds} ms");

            sw.Restart();
            for (int i = 0; i < n; i++) dict.Add(i, new Player(i, $"P{i}", 20));
            sw.Stop();
            Console.WriteLine($"Tiempo Dictionary.Add({n}): {sw.ElapsedMilliseconds} ms");
        }

        private int ReadInt(string prompt)
        {
            int value;
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out value))
                    return value;
                Console.WriteLine("Entrada inválida. Ingrese un número entero.");
            }
        }
    }
}
