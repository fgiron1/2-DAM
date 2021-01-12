using _08_Ejercicio4Unidad11_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_Ejercicio4Unidad11.Models
{
    class ClsPersonaConDepartamento
    {

        public ClsPersonaConDepartamento(int id, string nombre, string apellidos, DateTime fechaNacimiento, byte[] foto, string direccion, string telefono, ClsDepartamento departamento)
        {
            Id = id;
            Nombre = nombre;
            Apellidos = apellidos;
            FechaNacimiento = fechaNacimiento;
            Foto = foto;
            Direccion = direccion;
            Telefono = telefono;
            Departamento = departamento;
        }

        public ClsPersonaConDepartamento()
        {
            Departamento = new ClsDepartamento();
        }

        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Apellidos { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public byte[] Foto { get; set; }

        public string Direccion { get; set; }

        public string Telefono { get; set; }

        public ClsDepartamento Departamento { get; set; }
    }
}
