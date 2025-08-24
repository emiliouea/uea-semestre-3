 

namespace VacunacionCovid.Models
{
    public class Ciudadano : IEquatable<Ciudadano>
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Cedula { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }

        public Ciudadano(int id, string nombre, string cedula, DateTime fechaNacimiento, string email, string telefono)
        {
            Id = id;
            Nombre = nombre ?? throw new ArgumentNullException(nameof(nombre));
            Cedula = cedula ?? throw new ArgumentNullException(nameof(cedula));
            FechaNacimiento = fechaNacimiento;
            Email = email ?? throw new ArgumentNullException(nameof(email));
            Telefono = telefono ?? throw new ArgumentNullException(nameof(telefono));
        }

        public bool Equals(Ciudadano other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return Id == other.Id && Cedula == other.Cedula;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Ciudadano);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Cedula);
        }

        public override string ToString()
        {
            return $"ID: {Id}, Nombre: {Nombre}, Cédula: {Cedula}";
        }
    }
}
