using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using ExamenParcial2.Model.DataSet1TableAdapters;

namespace ExamenParcial2.Controller
{
    class ControllerUsuario : Interface
    {
        List<Usuarios> listausuarios = new List<Usuarios>();
        Usuarios u = new Usuarios();
        public bool Actualizar(int id, string nombre, int edad, DateTime fechanac, string correo)
        {
            try
            {
                using (personasTableAdapter usuarios = new personasTableAdapter())
                {
                    usuarios.UpdateUusario(nombre, edad, fechanac, correo, id);
                    return true;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool AgregarPersona(string nombre, int edad, DateTime fechanac, string correo)
        {
            try
            {
                using (personasTableAdapter usuarios = new personasTableAdapter())
                {
                    usuarios.InsertUsuario(nombre, edad, fechanac, correo);
                    return true;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Eliminar(int id)
        {
            try
            {
                using (personasTableAdapter usuarios = new personasTableAdapter())
                {
                    usuarios.DeleteUsuario(id);
                    return true;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Usuarios> Mostrar()
        {
            try
            {
                using (personasTableAdapter usuarios = new personasTableAdapter())
                {
                    var datos = usuarios.GetData();
                    foreach (DataRow row in datos)
                    {
                        u.idpersona = Convert.ToInt32(row["ID"]);
                        u.nombre = Convert.ToString(row["Nombre"]);
                        u.edad = Convert.ToInt32(row["Edad"]);
                        u.fechanac = Convert.ToDateTime(row["FechaNacimiento"]);
                        u.correo = Convert.ToString(row["CorreoElectronico"]);
                        listausuarios.Add(new Usuarios(u.idpersona, u.nombre, u.edad, u.fechanac, u.correo));
                    }

                }
            }
            catch (Exception)
            {

                throw;
            }
            return listausuarios;
        }
    }
}
