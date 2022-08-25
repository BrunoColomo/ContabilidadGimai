using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Contabilidad_GIMAI
{
    public partial class BuscarContacto : Form
    {
        
        public object[,] parametros;
        public Contabilidad menuInicio;
        string ruta;
        public object[,] contactos;

        public BuscarContacto(Contabilidad menu)
        {
            menuInicio = menu;
            ruta = menu.ruta;
            InitializeComponent();
            NombreTBX.AutoCompleteCustomSource = ExtraerContactos();    
        }

        /* Autocomplete Cliente */

        private AutoCompleteStringCollection ExtraerContactos()
        {
            var nombres = new AutoCompleteStringCollection();
            Excel_Manipulation excel = new Excel_Manipulation();
            contactos = excel.Leer(ruta + "Bases de Datos\\BBDD - Contactos.xlsx", 1);

            for (int i = 2; i <= contactos.GetUpperBound(0); i++)
            {
                nombres.Add(contactos[i, 3].ToString());
            }
            return nombres;
        }
        
        /* Trae el Tipo de Contacto en el CBX */

        private void NombreTBX_TextChanged(object sender, EventArgs e)
        {
            for (int i = 2; i <= contactos.GetUpperBound(0); i++)
            {
                if (contactos[i, 3].ToString().ToLower() == NombreTBX.Text.ToLower())
                {
                    TipoCBX.Text = contactos[i, 2].ToString();
                }
            }
        }

        /* Chekeo que se ha seleccionado un cliente */

        private bool ClienteSeleccionado()
        {
            bool clienteSeleccionado = false;

            for (int i = 2; i <= contactos.GetUpperBound(0); i++)
            {
                if (contactos[i, 3].ToString().ToLower() == NombreTBX.Text.ToLower())
                {
                    clienteSeleccionado = true;
                    i = contactos.GetUpperBound(0);
                }
            }
            return clienteSeleccionado;
        }

        /* BOTONES */


        private void FacturarBTN_Click(object sender, EventArgs e)
        {
            if (ClienteSeleccionado())
            {
                IngresarMovimiento NuevoIngreso = new IngresarMovimiento(menuInicio, contactos, NombreTBX.Text);
                NuevoIngreso.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Elija un contacto");
            }
        }
        
        private void EditarBTN_Click(object sender, EventArgs e)
        {
            if (ClienteSeleccionado())
            { 
                NuevoContacto nuevoContacto = new NuevoContacto(menuInicio, "editar", NombreTBX.Text,contactos);
                nuevoContacto.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Elija un Contacto a editar");
            }
        }

        private void CrearContacto_Click(object sender, EventArgs e)
        {
            if (ClienteSeleccionado())
            {
                MessageBox.Show("El contacto ya existe, no se puede volver a crear, intente editarlo");
            }
            else if(TipoCBX.Text == "")
            {
                MessageBox.Show("Elija el tipo de contacto");
            }
            else
            {
                NuevoContacto nuevoContacto = new NuevoContacto(menuInicio, TipoCBX.Text, NombreTBX.Text, contactos);
                nuevoContacto.Show();
                this.Hide();
            }
        }

        private void SalirBTN_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void BuscarContacto_Closed(object sender, FormClosedEventArgs e)
        {
            menuInicio.Show();
        }
    }
}
