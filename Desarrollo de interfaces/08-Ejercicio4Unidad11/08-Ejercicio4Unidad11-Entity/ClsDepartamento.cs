
namespace _08_Ejercicio4Unidad11_Entity
{
    public class ClsDepartamento
    {
        public ClsDepartamento()
        {
            Id = -1;
            Nombre = "";
        }

        public ClsDepartamento(int id, string nombre)
        {
            Id = id;
            Nombre = nombre;
        }

        public int Id { get; set; }

        public string Nombre { get; set; }

    }
}
