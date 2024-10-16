using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExamenParcial2.Controller;

namespace ExamenParcial2
{
   
    public partial class Form1 : Form
    {
        ControllerUsuario controller = new ControllerUsuario();
        public Form1()
        {
            InitializeComponent();
        }

        Control control = new Control();
        protected void LimpiarTextBox(Control control)
        {
            foreach (Control c in control.Controls)
            {
                if (c is TextBox)
                {
                    ((TextBox)c).Text = string.Empty;
                }
            }
        }

        private void BtnMostrar_Click(object sender, EventArgs e)
        {
            if (controller.Mostrar().Count > 0)
            {
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = controller.Mostrar();
            }
            else
            {
                MessageBox.Show("No existen registros aun");
            }
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombre.Text) || txtNombre.Text.Length < 3)
            {
                MessageBox.Show("El campo Nombre es obligatorio y debe tener almenos 3 caracteres");
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(txtCorreo.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Por favor, introduce un correo electrónico válido.");
            }
            else if (Convert.ToInt32(txtEdad.Text) < 0 || Convert.ToInt32(txtEdad.Text) > 100)
            {
                MessageBox.Show("La edad no puede ser menor a 0 o mayor a 99");
            }
            else 
            {
                if (controller.AgregarPersona(txtNombre.Text, Convert.ToInt32(txtEdad.Text), Convert.ToDateTime(dateTimePicker1.Value), txtCorreo.Text))
                {
                    MessageBox.Show("Se ha agregado con exito");
                }
                else
                {
                    MessageBox.Show("Hubo un error al agregar el usuario");
                }
            }
            LimpiarTextBox(this);
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombre.Text) || txtNombre.Text.Length < 3)
            {
                MessageBox.Show("El campo Nombre es obligatorio y debe tener almenos 3 caracteres");
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(txtCorreo.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Por favor, introduce un correo electrónico válido.");
            }
            else if (Convert.ToInt32(txtEdad.Text) < 0 || Convert.ToInt32(txtEdad.Text) > 100)
            {
                MessageBox.Show("La edad no puede ser menor a 0 o mayor a 99");
            }
            else
            {
                if (controller.Actualizar(Convert.ToInt32(txtid.Text), txtNombre.Text, Convert.ToInt32(txtEdad.Text), Convert.ToDateTime(dateTimePicker1.Value), txtCorreo.Text))
                {
                    MessageBox.Show("Se ha actualizado con exito el alumno");
                }
                else
                {
                    MessageBox.Show("Hubo un error al actualizar el usuario");
                }
            }
            LimpiarTextBox(this);
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (controller.Eliminar(Convert.ToInt32(txtid.Text)))
            {
                MessageBox.Show("Se ha elminado con exito el alumno");
            }
            else
            {
                MessageBox.Show("hubo un error al eliminar el alumno");
            }
            LimpiarTextBox(this);
        }
    }
}
