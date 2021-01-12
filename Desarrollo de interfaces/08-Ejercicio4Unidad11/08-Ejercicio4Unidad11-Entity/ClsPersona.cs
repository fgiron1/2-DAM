using System;

namespace _08_Ejercicio4Unidad11_Entity
{
    public class ClsPersona
    {
        public ClsPersona()
        {
            Id = -1;
            Nombre = "";
            Apellidos = "";
            FechaNacimiento = new DateTime();
            Foto = null;
            Direccion = "";
            Telefono = "";
            IdDepartamento = -1;
        }

        public ClsPersona(int id, string nombre, string apellidos, DateTime fechaNacimiento, byte[] foto, string direccion, string telefono, int idDepartamento)
        {
            Id = id;
            Nombre = nombre;
            Apellidos = apellidos;
            FechaNacimiento = fechaNacimiento;
            Foto = foto;
            Direccion = direccion;
            Telefono = telefono;
            IdDepartamento = idDepartamento;
        }

        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Apellidos { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public byte[] Foto { get; set; }

        public string Direccion { get; set; }

        public string Telefono { get; set; }

        public int IdDepartamento { get; set; }

    }
}
