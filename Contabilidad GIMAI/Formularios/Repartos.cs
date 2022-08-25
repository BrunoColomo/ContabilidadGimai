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
    public partial class Repartos : Form
    {

        public object[,] contactos;
        public string ruta;
        public Contabilidad menuInicio;
        public string[] clientes = new string[16];
        private string rutaArchivo;
        public Excel_Manipulation excel = new Excel_Manipulation();
        public Informes Informes;



        public Repartos(Contabilidad menu, Informes informes, string rutaa)
        {
            rutaArchivo = rutaa;
            menuInicio = menu;
            ruta = menuInicio.ruta;
            Informes = informes;

            InitializeComponent();
            AutoCompleteStringCollection autocomplete = ExtraerContactos();

            Cliente1TBX.AutoCompleteCustomSource = autocomplete;
            Cliente2TBX.AutoCompleteCustomSource = autocomplete;
            Cliente3TBX.AutoCompleteCustomSource = autocomplete;
            Cliente4TBX.AutoCompleteCustomSource = autocomplete;
            Cliente5TBX.AutoCompleteCustomSource = autocomplete;
            Cliente6TBX.AutoCompleteCustomSource = autocomplete;
            Cliente7TBX.AutoCompleteCustomSource = autocomplete;
            Cliente8TBX.AutoCompleteCustomSource = autocomplete;
            Cliente9TBX.AutoCompleteCustomSource = autocomplete;
            Cliente10TBX.AutoCompleteCustomSource = autocomplete;
            Cliente11TBX.AutoCompleteCustomSource = autocomplete;
            Cliente12TBX.AutoCompleteCustomSource = autocomplete;
            Cliente13TBX.AutoCompleteCustomSource = autocomplete;
            Cliente14TBX.AutoCompleteCustomSource = autocomplete;
            Cliente15TBX.AutoCompleteCustomSource = autocomplete;
            Cliente16TBX.AutoCompleteCustomSource = autocomplete;
        }

        private AutoCompleteStringCollection ExtraerContactos()
        {

            var nombres = new AutoCompleteStringCollection();
            
            contactos = excel.Leer(ruta + "Bases de Datos\\BBDD - Contactos.xlsx", 1);

            for (int i = 2; i <= contactos.GetUpperBound(0); i++)
            {
                if (contactos[i,2].ToString() == "Cliente")
                {
                    nombres.Add(contactos[i, 3].ToString());
                }
            }
            return nombres;
        }

        private int ClienteSeleccionado(string cliente)
        {
            for (int i = 2; i <= contactos.GetUpperBound(0); i++)
            {
                if (contactos[i, 3].ToString().ToLower() == cliente.ToLower())
                {
                    return i;
                }
            }
            return 0;
        }

        private void ExportarBTN_Click(object sender, EventArgs e)
        {
            clientes[0] = Cliente1TBX.Text;
            clientes[1] = Cliente2TBX.Text;
            clientes[2] = Cliente3TBX.Text;
            clientes[3] = Cliente4TBX.Text;
            clientes[4] = Cliente5TBX.Text;
            clientes[5] = Cliente6TBX.Text;
            clientes[6] = Cliente7TBX.Text;
            clientes[7] = Cliente8TBX.Text;
            clientes[8] = Cliente9TBX.Text;
            clientes[9] = Cliente10TBX.Text;
            clientes[10] = Cliente11TBX.Text;
            clientes[11] = Cliente12TBX.Text;
            clientes[12] = Cliente13TBX.Text;
            clientes[13] = Cliente14TBX.Text;
            clientes[14] = Cliente15TBX.Text;
            clientes[15] = Cliente16TBX.Text;

            string[,] exportList = new string[16,15];
            int j = 0;
            int contacto;

            for (int i = 0;i<=clientes.GetUpperBound(0);i++)
            {
                contacto = ClienteSeleccionado(clientes[i]);
                if (contacto == 0 && clientes[i] != "")
                {
                    MessageBox.Show("El Cliente # " + (i + 1) + " no se encuentra en el listado de Contactos");
                    return;
                }
                else if (contacto != 0)
                {
                    if (contactos[contacto, 1] != null) { exportList[j, 0] = contactos[contacto, 1].ToString(); }
                    if (contactos[contacto, 2] != null) { exportList[j, 1] = contactos[contacto, 2].ToString(); }
                    if (contactos[contacto, 3] != null) { exportList[j, 2] = contactos[contacto, 3].ToString(); }
                    if (contactos[contacto, 11] != null) { exportList[j, 3] = contactos[contacto, 11].ToString(); }
                    if (contactos[contacto, 12] != null) { exportList[j, 4] = contactos[contacto, 12].ToString(); }
                    if (contactos[contacto, 13] != null) { exportList[j, 5] = contactos[contacto, 13].ToString(); }
                    if (contactos[contacto, 14] != null) { exportList[j, 6] = contactos[contacto, 14].ToString(); }
                    if (contactos[contacto, 15] != null) { exportList[j, 7] = contactos[contacto, 15].ToString(); }
                    if (contactos[contacto, 16] != null) { exportList[j, 8] = contactos[contacto, 16].ToString(); }
                    if (contactos[contacto, 17] != null) { exportList[j, 9] = contactos[contacto, 17].ToString(); }
                    if (contactos[contacto, 20] != null) { exportList[j, 10] = contactos[contacto, 20].ToString(); }
                    if (contactos[contacto, 21] != null) { exportList[j, 11] = contactos[contacto, 21].ToString(); }
                    if (contactos[contacto, 22] != null) { exportList[j, 12] = contactos[contacto, 22].ToString(); }
                    if (contactos[contacto, 23] != null) { exportList[j, 13] = contactos[contacto, 23].ToString(); }
                    if (contactos[contacto, 24] != null) { exportList[j, 14] = contactos[contacto, 24].ToString(); }

                    j++;
                }
            }

            if(excel.InformeRepartos(rutaArchivo, 1, exportList))
            {
                MessageBox.Show("Informe de Repartos Exportado");
                excel.ReleaseExcel();
                excel.ReleaseExcel();
                this.Close();
                Informes.Close();
                System.Diagnostics.Process.Start(rutaArchivo);
            }
            else
            { 
                MessageBox.Show("ERROR - No se puedo exportar el informe");
            }
            
        }














        /*
        private void Cliente1TBX_TextChanged(object sender, EventArgs e)
        {
            if (ClienteSeleccionado(Cliente1TBX.Text))
            {
                Cliente1TBX.ReadOnly = true;
                Cliente2TBX.ReadOnly = false;
                clientes[0] = Cliente1TBX.Text;
            }
            else
            {
                Cliente2TBX.ReadOnly = true;
                clientes[0] = "";
            }
        }

        private void Cliente2TBX_TextChanged(object sender, EventArgs e)
        {
            if (ClienteSeleccionado(Cliente2TBX.Text))
            {
                Cliente2TBX.ReadOnly = true;
                Cliente3TBX.ReadOnly = false;
                clientes[1] = Cliente2TBX.Text;
            }
            else
            {
                Cliente3TBX.ReadOnly = true;
                clientes[1] = "";
            }
            if (Cliente2TBX.Text == "")
            {
                Cliente1TBX.ReadOnly = false;
            }
        }

        private void Cliente3TBX_TextChanged(object sender, EventArgs e)
        {
            if (ClienteSeleccionado(Cliente3TBX.Text))
            {
                Cliente4TBX.ReadOnly = false;
                clientes[2] = Cliente3TBX.Text;
            }
        }
        private void Cliente4TBX_TextChanged(object sender, EventArgs e)
        {
            if (ClienteSeleccionado(Cliente4TBX.Text))
            {
                Cliente5TBX.ReadOnly = false;
                clientes[3] = Cliente4TBX.Text;
            }
        }
        private void Cliente5TBX_TextChanged(object sender, EventArgs e)
        {
            if (ClienteSeleccionado(Cliente5TBX.Text))
            {
                Cliente6TBX.ReadOnly = false;
                clientes[4] = Cliente5TBX.Text;
            }
        }

        private void Cliente6TBX_TextChanged(object sender, EventArgs e)
        {
            if (ClienteSeleccionado(Cliente6TBX.Text))
            {
                Cliente7TBX.ReadOnly = false;
                clientes[5] = Cliente6TBX.Text;
            }
        }
        private void Cliente7TBX_TextChanged(object sender, EventArgs e)
        {
            if (ClienteSeleccionado(Cliente7TBX.Text))
            {
                Cliente8TBX.ReadOnly = false;
                clientes[6] = Cliente7TBX.Text;
            }
        }

        private void Cliente8TBX_TextChanged(object sender, EventArgs e)
        {
            if (ClienteSeleccionado(Cliente8TBX.Text))
            {
                Cliente9TBX.ReadOnly = false;
                clientes[7] = Cliente8TBX.Text;
            }
        }

        private void Cliente9TBX_TextChanged(object sender, EventArgs e)
        {
            if (ClienteSeleccionado(Cliente9TBX.Text))
            {
                Cliente10TBX.ReadOnly = false;
                clientes[8] = Cliente9TBX.Text;
            }
        }

        private void Cliente10TBX_TextChanged(object sender, EventArgs e)
        {
            if (ClienteSeleccionado(Cliente10TBX.Text))
            {
                Cliente11TBX.ReadOnly = false;
                clientes[9] = Cliente10TBX.Text;
            }
        }

        private void Cliente11TBX_TextChanged(object sender, EventArgs e)
        {
            if (ClienteSeleccionado(Cliente11TBX.Text))
            {
                Cliente12TBX.ReadOnly = false;
                clientes[10] = Cliente11TBX.Text;
            }
        }

        private void Cliente12TBX_TextChanged(object sender, EventArgs e)
        {
            if (ClienteSeleccionado(Cliente12TBX.Text))
            {
                Cliente13TBX.ReadOnly = false;
                clientes[11] = Cliente12TBX.Text;
            }
        }

        private void Cliente13TBX_TextChanged(object sender, EventArgs e)
        {
            if (ClienteSeleccionado(Cliente13TBX.Text))
            {
                Cliente14TBX.ReadOnly = false;
                clientes[12] = Cliente13TBX.Text;
            }
        }

        private void Cliente14TBX_TextChanged(object sender, EventArgs e)
        {
            if (ClienteSeleccionado(Cliente14TBX.Text))
            {
                Cliente15TBX.ReadOnly = false;
                clientes[13] = Cliente14TBX.Text;
            }
        }

        private void Cliente15TBX_TextChanged(object sender, EventArgs e)
        {
            if (ClienteSeleccionado(Cliente15TBX.Text))
            {
                Cliente16TBX.ReadOnly = false;
                clientes[14] = Cliente15TBX.Text;
            }
        }

        private void Cliente16TBX_TextChanged(object sender, EventArgs e)
        {
            if (ClienteSeleccionado(Cliente16TBX.Text))
            {
                clientes[15] = Cliente16TBX.Text;
            }
        }
        */
    }
}
