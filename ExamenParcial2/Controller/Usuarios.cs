using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenParcial2.Controller
{
    class Usuarios
    {
        public Usuarios() { }
        public Usuarios(int idpersona, string nombre, int edad, DateTime fechanac, string correo)
        {
            this.idpersona = idpersona;
            this.nombre = nombre;
            this.edad = edad;
            this.fechanac = fechanac;
            this.correo = correo;
        }

        public int idpersona { get; set; }
        public string nombre { get; set; }
        public int edad { get; set; }
        public DateTime fechanac { get; set; }
        public string correo { get; set; }
    }
}
