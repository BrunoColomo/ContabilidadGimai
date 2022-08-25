using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace Contabilidad_GIMAI
{
    public partial class Contabilidad : Form
    {
        public MenuInicio menuInicio;
        public string ruta;

        public Contabilidad(string rutaa)
        {
            ruta = rutaa;
            InitializeComponent();
            

        }

        private void Contabilidad_Load(object sender, EventArgs e)
        {

        }



        private void Contabilidad_Closed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void AbrirMovBTN_Click(object sender, EventArgs e)
        {
            Excel_Manipulation excelManipulation = new Excel_Manipulation();
            if (!excelManipulation.AbrirExcel(ruta + "Bases de Datos\\BBDD - Contabilidad.xlsx"))
            {
                MessageBox.Show("No se pudo abrir el archivo");
            }
        }
        private void ExportarMovBTN_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime fechaHoy = DateTime.Now;
                string[] mesString = new string[12];

                mesString[0] = "Enero";
                mesString[1] = "Febrero";
                mesString[2] = "Marzo";
                mesString[3] = "Abril";
                mesString[4] = "Mayo";
                mesString[5] = "Junio";
                mesString[6] = "Julio";
                mesString[7] = "Agosto";
                mesString[8] = "Septiembre";
                mesString[9] = "Octubre";
                mesString[10] = "Noviembre";
                mesString[11] = "Diciembre";

                for (int i = 0; i < mesString.Length; i++)
                {
                    if ((i + 1).ToString() == DateTime.Today.Month.ToString())
                    {
                        string nombreArchivo = "BBDD - Contabilidad - " + fechaHoy.ToString("ddMMyy") + ".xlsx";
                        File.Copy(ruta + "Bases de Datos\\BBDD - Contabilidad.xlsx", ruta + "Informes\\" + DateTime.Today.Year + "\\" + DateTime.Today.Month + " - " + mesString[i] + "\\4 - Copia BBDD\\" + nombreArchivo, true);
                        System.Diagnostics.Process.Start(ruta + "Informes\\" + DateTime.Today.Year + "\\" + DateTime.Today.Month + " - " + mesString[i] + "\\4 - Copia BBDD\\");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo exportar el archivo");
            }
        }

        private void ParametrosBTN_Click(object sender, EventArgs e)
        {
            Excel_Manipulation excelManipulation = new Excel_Manipulation();
            if (!excelManipulation.AbrirExcel(ruta + "Parametros\\Contabilidad PRMT.xlsx"))
            {
                MessageBox.Show("No se pudo abrir el archivo");
            }
        }

        private void InformesBTN_Click(object sender, EventArgs e)
        {
            Informes NuevoInforme = new Informes(this);
            NuevoInforme.Show();
            this.Hide();
        }

        private void BuscarContactoBTN_Click(object sender, EventArgs e)
        {
            BuscarContacto BuscarContacto = new BuscarContacto(this);
            BuscarContacto.Show();
            this.Hide();
        }

        private void IngresarMovBTN_Click(object sender, EventArgs e)
        {

        }
    }
}