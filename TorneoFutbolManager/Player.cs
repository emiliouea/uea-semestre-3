 

namespace TorneoFutbolManager
{
    class Player
    {
        public int Id { get; }
        public string Name { get; }
        public int Age { get; }

        public Player(int id, string name, int age)
        {
            Id = id;
            Name = name;
            Age = age;
        }

        public override string ToString() => $"{Id}: {Name} (Edad {Age})";
    }
}
