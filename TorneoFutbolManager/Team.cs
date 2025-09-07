 

namespace TorneoFutbolManager
{
    class Team
    {
        public int Id { get; }
        public string Name { get; }
        public HashSet<int> PlayerIds { get; } = new();

        public Team(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public void AddPlayer(int playerId) => PlayerIds.Add(playerId);
    }
}
