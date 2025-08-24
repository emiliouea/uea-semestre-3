 

namespace VacunacionCovid.Models
{
    public enum TipoVacuna
    {
        Pfizer,
        AstraZeneca
    }

    public enum NumeroDosis
    {
        Primera = 1,
        Segunda = 2
    }

    public class RegistroVacunacion : IEquatable<RegistroVacunacion>
    {
        public int Id { get; set; }
        public int CiudadanoId { get; set; }
        public TipoVacuna TipoVacuna { get; set; }
        public NumeroDosis NumeroDosis { get; set; }
        public DateTime FechaVacunacion { get; set; }
        public string LugarVacunacion { get; set; }

        public RegistroVacunacion(int id, int ciudadanoId, TipoVacuna tipoVacuna, NumeroDosis numeroDosis, DateTime fechaVacunacion, string lugarVacunacion)
        {
            Id = id;
            CiudadanoId = ciudadanoId;
            TipoVacuna = tipoVacuna;
            NumeroDosis = numeroDosis;
            FechaVacunacion = fechaVacunacion;
            LugarVacunacion = lugarVacunacion ?? throw new ArgumentNullException(nameof(lugarVacunacion));
        }

        public bool Equals(RegistroVacunacion other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return Id == other.Id && CiudadanoId == other.CiudadanoId &&
                   TipoVacuna == other.TipoVacuna && NumeroDosis == other.NumeroDosis;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as RegistroVacunacion);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, CiudadanoId, TipoVacuna, NumeroDosis);
        }
    }
}
