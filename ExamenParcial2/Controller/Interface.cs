using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenParcial2.Controller
{
    interface Interface
    {
        List<Usuarios> Mostrar();
        bool AgregarPersona(string nombre, int edad, DateTime fechanac, string correo);
        bool Actualizar(int id, string nombre, int edad, DateTime fechanac, string correo);
        bool Eliminar(int id);
    }
}
