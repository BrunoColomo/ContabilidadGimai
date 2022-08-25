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

    
namespace Contabilidad_GIMAI
{
    public partial class Informes : Form
    {
        public Contabilidad menuInicio;
        string ruta;


        public Informes(Contabilidad menu)
        {
            ruta = menu.ruta;
            menuInicio = menu;
            InitializeComponent();
        }

        private void Informes_Load(object sender, EventArgs e)
        {

        }
        private void Informes_Closed(object sender, FormClosedEventArgs e)
        {
            
            menuInicio.Show();

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        public void GenerarBTN_Click(object sender, EventArgs e)
        {
            
            if (InformeCMBX.Text == "" || TipoCMBX.Text == "" || DesdeMovsDP.Value == HastaMovsDP.Value)
            {
                MessageBox.Show("Complete todos los campos");
                return;
            }

            string informe = InformeCMBX.Text;
            string tipo = TipoCMBX.Text;
            DateTime desde = DesdeMovsDP.Value.Date;
            DateTime hasta = HastaMovsDP.Value.Date;
            string carpetaInforme = null;
            string rutaDestino = null;
            string nombreArchivo = null;
            string carpetaPlantillas = ruta + "Parametros\\Plantilla Informes\\Contabilidad - ";
            string carpetaBBDD = ruta + "Bases de Datos\\BBDD - Contabilidad.xlsx";
            string[] mes = new string[12];

            mes[0] = "Enero";
            mes[1] = "Febrero";
            mes[2] = "Marzo";
            mes[3] = "Abril";
            mes[4] = "Mayo";
            mes[5] = "Junio";
            mes[6] = "Julio";
            mes[7] = "Agosto";
            mes[8] = "Septiembre";
            mes[9] = "Octubre";
            mes[10] = "Noviembre";
            mes[11] = "Diciembre";

            
            ProcesandoLB.Visible = true;

           Excel_Manipulation excelManipulation = new Excel_Manipulation();

            try
            {
                object[,] bbddContabilidad = excelManipulation.Leer(carpetaBBDD, 1);
                excelManipulation.ReleaseExcel();

                for (int fila = 2; fila <= bbddContabilidad.GetUpperBound(0); fila++)
                {
                    
                    bbddContabilidad[fila, 8] = DateTime.FromOADate((double)bbddContabilidad[fila, 8]);
                    bbddContabilidad[fila, 2] = DateTime.FromOADate((double)bbddContabilidad[fila, 2]);
                }
                if (informe == "Ventas") { carpetaInforme = "1 - Ventas"; }
                else if (informe == "Compras") { carpetaInforme = "2 - Compras"; }
                else if (informe == "Balance") { carpetaInforme = "3 - Balance"; }
                else if (informe == "Contactos") { carpetaInforme = "5 - Contactos"; }

                for (int i = 0; i < mes.Length; i++)
                {
                    if ((i + 1).ToString() == DateTime.Today.Month.ToString())
                    {
                        rutaDestino = ruta + "Informes\\" + DateTime.Today.Year + "\\" + DateTime.Today.Month + " - " + mes[i].ToUpperInvariant() + "\\" + carpetaInforme + "\\";
                    }
                }


                if (tipo == "Movimientos")
                {
                    nombreArchivo = tipo + " " + informe + " " + desde.ToString("ddMMyy") + " - " + hasta.ToString("ddMMyy") + ".xlsx";
                    File.Copy(carpetaPlantillas + tipo + " - " + informe + ".xlsx", rutaDestino + nombreArchivo, true);
                    InformeMovimientos(bbddContabilidad, informe, desde, hasta, rutaDestino + nombreArchivo, excelManipulation);
                }
                else if (tipo == "Anual")
                {
                    nombreArchivo = tipo + " Detallado " + desde.ToString("yyyy") + ".xlsx";
                    File.Copy(carpetaPlantillas + tipo + " - Detallado.xlsx", rutaDestino + nombreArchivo, true);
                    InformeDetalle(bbddContabilidad, "Detallado", desde, hasta, rutaDestino + nombreArchivo, excelManipulation);
                    
                    nombreArchivo = tipo + " Categorías " + desde.ToString("yyyy") + ".xlsx";
                    File.Copy(carpetaPlantillas + tipo + " - Categorías.xlsx", rutaDestino + nombreArchivo, true);
                    InformeCategoria(bbddContabilidad, "Categoria", desde, hasta, rutaDestino + nombreArchivo, excelManipulation);
                    
                    nombreArchivo = tipo + " Balance " + desde.ToString("yyyy") + ".xlsx";
                    File.Copy(carpetaPlantillas + tipo + " - Balance.xlsx", rutaDestino + nombreArchivo, true);
                    InformeResumen(bbddContabilidad, "Balance", desde, hasta, rutaDestino + nombreArchivo, excelManipulation);
                    
                }
                else if (tipo == "Parcial")
                {
                    nombreArchivo = informe + " " + tipo + " " + desde.ToString("MMMM") + ".xlsx";
                    File.Copy(carpetaPlantillas + tipo + " - " + informe + ".xlsx", rutaDestino + nombreArchivo, true);
                    InformeBalanceParcial(bbddContabilidad, tipo, desde, hasta, rutaDestino + nombreArchivo, excelManipulation);
                    
                }
                else if (tipo == "Sub-Diario")
                {
                    nombreArchivo = tipo + " " + informe + " " + desde.ToString("MMMM") + ".xlsx";
                    File.Copy(carpetaPlantillas + tipo + " - " + informe + ".xlsx", rutaDestino + nombreArchivo, true);
                    InformeSubDiario(bbddContabilidad, informe, desde, hasta, rutaDestino + nombreArchivo, excelManipulation);

                }
                else if (InformeCMBX.Text == "Contactos" && TipoCMBX.Text == "Repartos")
                {
                    nombreArchivo = tipo + " " + DateTime.Today.Day.ToString() + "-" + DateTime.Today.Month.ToString() + " " + ".xlsx";
                    File.Copy(carpetaPlantillas + tipo + " - " + informe + ".xlsx", rutaDestino + nombreArchivo, true);
                    Repartos repartos = new Repartos(menuInicio, this, rutaDestino + nombreArchivo);
                    repartos.Show();
                    return;
                }

                excelManipulation.ReleaseExcel();
                System.Diagnostics.Process.Start(rutaDestino);
                ProcesandoLB.Visible = false;
            }
            catch(Exception ex)
            {
                ProcesandoLB.Visible = false;
                excelManipulation.ReleaseExcel();
                excelManipulation.ReleaseExcel();
                excelManipulation.ReleaseExcel();
                MessageBox.Show("Error al generar el informe");
                
            }
            ProcesandoLB.Visible = false;
        }
        // --------------------------------------------------- Mensual / Semanal --------------------------------------------------------

        private void InformeBalanceParcial(object[,] bbdd, string tipo, DateTime desde, DateTime hasta, string archivo, Excel_Manipulation excel)
        {
            DateTime fecha = new DateTime();
            
            int fechaCol = 8;
            
            TimeSpan diferencia = hasta - desde;
            int cantDias = diferencia.Days;
            object[,] balance = new object[cantDias, 5];
            int contador = 0;


            for (int dia = 0;dia <cantDias;dia++)
            {
                balance[dia, 0] = desde.AddDays(dia);
                balance[dia, 1] = 0;
                balance[dia, 2] = 0;
                balance[dia, 3] = 0;
                balance[dia, 4] = 0;
                for (int fila = 2; fila <= bbdd.GetUpperBound(0); fila++)
                {
                    fecha = (DateTime)bbdd[fila, fechaCol];
                    if (fecha.ToShortDateString() == (Convert.ToDateTime(balance[dia, 0])).ToShortDateString())
                    {
                        if (bbdd[fila,4].ToString() == "Compras")
                        {
                            balance[dia, 3] = Convert.ToDouble(balance[dia,3]) + Convert.ToDouble(bbdd[fila, 14]);
                            
                        }
                        else if (bbdd[fila,4].ToString() == "Ventas")
                        {
                            if (bbdd[fila,11].ToString() == "Sin Comprobante")
                            { 
                                balance[dia, 2] = Convert.ToDouble(balance[dia, 2]) + Convert.ToDouble(bbdd[fila, 14]);
                            }
                            else
                            {
                                balance[dia, 1] = Convert.ToDouble(balance[dia, 1]) + Convert.ToDouble(bbdd[fila, 14]);
                            }
                        }
                    }

                }
                if (dia == 0)
                { 
                    balance[dia, 4] =  Convert.ToDouble(balance[dia, 1]) + Convert.ToDouble(balance[dia, 2]) - Convert.ToDouble(balance[dia, 3]);
                }
                else
                {
                    balance[dia, 4] = Convert.ToDouble(balance[dia - 1, 4]) + Convert.ToDouble(balance[dia, 1]) + Convert.ToDouble(balance[dia, 2]) - Convert.ToDouble(balance[dia, 3]);
                }
            }

            excel.informeBalanceParcial(archivo, balance);
        }
        //------------------------------------------- Sub-Diario ----------------------------------------------------------------------

        private void InformeSubDiario(object[,] bbdd, string tipo, DateTime desde, DateTime hasta, string archivo, Excel_Manipulation excel)
        {

            int fechaCol = 2;
            DateTime fecha = new DateTime();
            DateTime fechaFacturacion = new DateTime();
            int cantVentas = 1;
            int cantCompras = 1;
            hasta = hasta.Date + new TimeSpan(23, 59, 59);

            for (int fila = 2; fila <= bbdd.GetUpperBound(0); fila++)
            {
                fecha = (DateTime)bbdd[fila, fechaCol];

                if (fecha >= desde && fecha <= hasta)
                {
                    if (bbdd[fila, 4].ToString() == "Ventas")
                    {
                        cantVentas++;
                    }
                    else if (bbdd[fila, 4].ToString() == "Compras")
                    {
                        cantCompras++;
                    }
                }
            }



            object[,] ventas = new object[cantVentas + 1, 11];
            object[,] compras = new object[cantCompras + 1, 21];

            ventas[0, 0] = "Fecha";
            ventas[0, 1] = "Tipo de Factura";
            ventas[0, 2] = "Nro. Comprobante";
            ventas[0, 3] = "Cliente";
            ventas[0, 4] = "CUIT / DNI";
            ventas[0, 5] = "Importe Gravado 21%";
            ventas[0, 6] = "IVA 21%";
            ventas[0, 7] = "Importe Gravado 10,5%";
            ventas[0, 8] = "IVA 10,5%";
            ventas[0, 9] = "Exento";
            ventas[0, 10] = "Total";

            compras[0, 0] = "Fecha";
            compras[0, 1] = "Tipo de Factura";
            compras[0, 2] = "Nro. Comprobante";
            compras[0, 3] = "Proveedor";
            compras[0, 4] = "CUIT";
            compras[0, 5] = "Importe Gravado 21%";
            compras[0, 6] = "IVA 21%";
            compras[0, 7] = "Importe Gravad 10,5%";
            compras[0, 8] = "IVA 10,5%";
            compras[0, 9] = "Importe Gravado 27%";
            compras[0, 10] = "IVA 27%";
            compras[0, 11] = "Perc. IVA";
            compras[0, 12] = "Perc. IIBB Bs. As.";
            compras[0, 13] = "Perc. IIBB Caba";
            compras[0, 14] = "Otros Impuestos";
            compras[0, 15] = "No Gravado";
            compras[0, 16] = "Bonificación";
            compras[0, 17] = "Total";
            compras[0, 18] = "Categoria";
            compras[0, 19] = "Movimiento";
            compras[0, 20] = "Concepto";

            int filaVenta = 1;
            int filaCompra = 1;
            string tipoFactura = "";

            for (int fila = 2; fila <= bbdd.GetUpperBound(0); fila++)
            {
                fecha = (DateTime)bbdd[fila, fechaCol];
                fechaFacturacion = (DateTime)bbdd[fila, 8];
                try
                {
                    tipoFactura = bbdd[fila, 11].ToString().Substring(0, 9);
                }
                catch
                {
                    tipoFactura = "aaa";
                }

                if (fecha >= desde && fecha <= hasta && fechaFacturacion.Month <= desde.Month && bbdd[fila, 4].ToString() == tipo)
                {


                    if (bbdd[fila, 4].ToString() == "Ventas" && (tipoFactura.Substring(0, 3) == "Fac" || tipoFactura == "Nota de C" || tipoFactura == "Nota de D"))
                    {
                        ventas[filaVenta, 0] = bbdd[fila, 8];
                        ventas[filaVenta, 1] = bbdd[fila, 11];
                        ventas[filaVenta, 2] = bbdd[fila, 12];
                        ventas[filaVenta, 3] = bbdd[fila, 9];
                        ventas[filaVenta, 4] = bbdd[fila, 10];

                        if (bbdd[fila, 17] != null)
                        {
                            if (bbdd[fila, 17].ToString() == "0,105")
                            {
                                ventas[filaVenta, 7] = bbdd[fila, 15];
                                ventas[filaVenta, 8] = bbdd[fila, 18];
                            }
                            else if (bbdd[fila, 17].ToString() == "0,21")
                            {
                                ventas[filaVenta, 5] = bbdd[fila, 15];
                                ventas[filaVenta, 6] = bbdd[fila, 18];
                            }
                            else
                            {
                                ventas[filaVenta, 5] = bbdd[fila, 14];
                            }
                        }

                        if (bbdd[fila, 26] != null)
                        {
                            if (bbdd[fila, 26].ToString() == "0,105")
                            {
                                ventas[filaVenta, 7] = bbdd[fila, 28];
                                ventas[filaVenta, 8] = bbdd[fila, 27];
                            }
                            else if (bbdd[fila, 26].ToString() == "0,21")
                            {
                                ventas[filaVenta, 5] = bbdd[fila, 28];
                                ventas[filaVenta, 6] = bbdd[fila, 27];
                            }
                        }
                        
                        ventas[filaVenta, 9] = 0;
                        ventas[filaVenta, 10] = bbdd[fila, 14];
                        filaVenta++;
                    }
                    else if (bbdd[fila, 4].ToString() == "Compras" && (tipoFactura == "Nota de D" || tipoFactura.Substring(0, 3) == "Fac" || tipoFactura == "Tiquet FC" || tipoFactura == "Nota de C"))
                    {

                        compras[filaCompra, 0] = bbdd[fila, 8];
                        compras[filaCompra, 1] = bbdd[fila, 11];
                        compras[filaCompra, 2] = bbdd[fila, 12];
                        compras[filaCompra, 3] = bbdd[fila, 9];
                        compras[filaCompra, 4] = bbdd[fila, 10];

                        compras[filaCompra, 14] = bbdd[fila, 23];
                        compras[filaCompra, 15] = bbdd[fila, 16];
                        compras[filaCompra, 16] = bbdd[fila, 24];
                        compras[filaCompra, 17] = bbdd[fila, 14];

                        compras[filaCompra, 18] = bbdd[fila, 5];
                        compras[filaCompra, 19] = bbdd[fila, 6];
                        compras[filaCompra, 20] = bbdd[fila, 7];

                        if (bbdd[fila, 17] != null)
                        {
                            if (bbdd[fila, 17].ToString() == "0,105")
                            {
                                compras[filaCompra, 7] = bbdd[fila, 15];
                                compras[filaCompra, 8] = bbdd[fila, 18];
                            }
                            else if (bbdd[fila, 17].ToString() == "0,21")
                            {
                                compras[filaCompra, 5] = bbdd[fila, 15];
                                compras[filaCompra, 6] = bbdd[fila, 18];

                            }
                            else if (bbdd[fila, 17].ToString() == "0,27")
                            {
                                compras[filaCompra, 9] = bbdd[fila, 15];
                                compras[filaCompra, 10] = bbdd[fila, 18];
                            }
                            else
                            {
                                compras[filaCompra, 5] = bbdd[fila, 14];
                            }

                        }

                        if (bbdd[fila, 26] != null)
                        {
                            if (bbdd[fila, 26].ToString() == "0,105")
                            {
                                compras[filaCompra, 7] = bbdd[fila, 28];
                                compras[filaCompra, 8] = bbdd[fila, 27];
                            }
                            else if (bbdd[fila, 26].ToString() == "0,21")
                            {
                                compras[filaCompra, 5] = bbdd[fila, 28];
                                compras[filaCompra, 6] = bbdd[fila, 27];

                            }
                            else if (bbdd[fila, 26].ToString() == "0,27")
                            {
                                compras[filaCompra, 9] = bbdd[fila, 28];
                                compras[filaCompra, 10] = bbdd[fila, 27];
                            }
                        }

                        if (bbdd[fila, 19] != null)
                        {
                            if (bbdd[fila, 19].ToString() == "Bs. As.")
                            {
                                compras[filaCompra, 12] = bbdd[fila, 20];
                            }
                            else if (bbdd[fila, 19].ToString() == "CABA")
                            {
                                compras[filaCompra, 13] = bbdd[fila, 20];
                            }
                            else if (bbdd[fila, 19].ToString() == "IVA")
                            {
                                compras[filaCompra, 11] = bbdd[fila, 20];
                            }
                        }
                        if (bbdd[fila, 21] != null)
                        {
                            if (bbdd[fila, 21].ToString() == "Bs. As.")
                            {
                                compras[filaCompra, 12] = bbdd[fila, 22];
                            }
                            else if (bbdd[fila, 21].ToString() == "CABA")
                            {
                                compras[filaCompra, 13] = bbdd[fila, 22];
                            }
                            else if (bbdd[fila, 21].ToString() == "IVA")
                            {
                                compras[filaCompra, 11] = bbdd[fila, 22];
                            }
                        }

                        filaCompra++;
                    }

                }

            }
            if (tipo == "Ventas")
            {
                excel.InformeSubDiarioVentas(archivo, ventas, desde.ToString("MMMM"));
            }
            else if (tipo == "Compras")
            {
                excel.InformeSubDiarioCompras(archivo, compras, desde.ToString("MMMM"));
            }
        }
            //------------------------------------------- Informes resumen ----------------------------------------------------------------------


            private void InformeCategoria(object[,] bbdd, string tipo, DateTime desde, DateTime hasta, string archivo, Excel_Manipulation excel)
            {
            int fechaCol = 8;
            DateTime fecha = new DateTime();
            int columnaResumen = 0;

            object[,] prmt = excel.Leer(ruta + "Parametros\\Contabilidad PRMT.xlsx", 1);

            for (int fila = 2; fila <= prmt.GetUpperBound(0); fila++)
            {
                if ((prmt[fila, 4].ToString() != prmt[fila - 1, 4].ToString()))
                {
                    columnaResumen++;
                }
            }

            object[,] resumen = new object[15, columnaResumen];
            columnaResumen = 0;

            for (int fila = 2; fila <= prmt.GetUpperBound(0); fila++)
            {
                if ((prmt[fila,4].ToString() != prmt[fila-1,4].ToString()))
                {
                    resumen[0,columnaResumen] = prmt[fila, 3];
                    resumen[1,columnaResumen] = prmt[fila, 4];
                    columnaResumen++;
                }
            }
            
                double suma = 0;
            
            int mes = 0;

            for (int fila = 2; fila <= bbdd.GetUpperBound(0); fila++)
            {
                fecha = (DateTime)bbdd[fila, fechaCol];
                mes = fecha.Month + 1;

                if (fecha.Year == desde.Year )
                {
                    for (int columna = 0; columna <= resumen.GetUpperBound(1); columna++)
                    {
                        if (resumen[1, columna].ToString() == bbdd[fila, 5].ToString())
                        {
                            suma = Convert.ToDouble(resumen[mes, columna]) + Convert.ToDouble(bbdd[fila, 14]);
                            resumen[mes, columna] = (object)suma;
                        }
                    }
                }
            }

            for (int fila = 2; fila <= resumen.GetUpperBound(0); fila++)
            {
                for (int columna = 0; columna <= resumen.GetUpperBound(1); columna++)
                {
                    if (resumen[fila, columna] == null)
                    {
                        resumen[fila, columna] = 0;
                    }
                }
            }

            
            excel.InformeCategoria(archivo, resumen, desde.Year.ToString());
        }


        private void InformeDetalle(object[,] bbdd, string tipo, DateTime desde, DateTime hasta, string archivo, Excel_Manipulation excel)
        {

            int fechaCol = 8;
            DateTime fecha = new DateTime();
            

            object[,] prmt = excel.Leer(ruta + "Parametros\\Contabilidad PRMT.xlsx", 1);

            object[,] resumen = new object[15, prmt.GetUpperBound(0)-1];

            for (int fila = 2; fila <= prmt.GetUpperBound(0); fila++)
            {
                resumen[0, fila-2] = prmt[fila, 3];
                resumen[1, fila-2] = prmt[fila, 4];
                resumen[2, fila - 2] = prmt[fila, 5];
            }

            double suma = 0;
            int mes = 0;
            

            for (int fila = 2; fila <= bbdd.GetUpperBound(0); fila++)
            {
                fecha = (DateTime)bbdd[fila, fechaCol];
                mes = fecha.Month + 2;

                if (fecha.Year == desde.Year && ( bbdd[fila,4].ToString() == "Ventas" || bbdd[fila,4].ToString() == "Compras"))
                {
                    for (int columna = 0;columna<=resumen.GetUpperBound(1);columna++)
                    {
                        if (resumen[2,columna].ToString() == bbdd[fila,6].ToString()&& resumen[1,columna].ToString() == bbdd[fila,5].ToString())
                        {
                            suma = Convert.ToDouble(resumen[mes, columna]) + Convert.ToDouble(bbdd[fila, 14]);
                            resumen[mes, columna] = (object)suma;
                        }
                    }
                }
            }

            for (int fila = 3; fila <= resumen.GetUpperBound(0); fila++)
            {
                for (int columna = 0; columna <= resumen.GetUpperBound(1); columna++)
                {
                    if (resumen[fila, columna] == null)
                    {
                        resumen[fila, columna] = 0;
                    }
                }
            }

            
            excel.InformeDetalle(archivo, resumen, desde.Year.ToString());
        }

        private void InformeResumen(object[,] bbdd, string tipo, DateTime desde, DateTime hasta, string archivo, Excel_Manipulation excel)
        {
            int fechaCol = 8;
            int tipoCol = 4;
            double[,] balance = new double[13, 3];
            DateTime fecha = new DateTime();

            for (int fila = 2; fila<=bbdd.GetUpperBound(0);fila++)
            {
                fecha = (DateTime)bbdd[fila, fechaCol];

                if (fecha.Year == desde.Year)
                {
                    if (bbdd[fila, tipoCol].ToString() == "Compras")
                    {
                        balance[fecha.Month - 1, 1] += (double)bbdd[fila, 14];       
                    }
                    else if(bbdd[fila, tipoCol].ToString() == "Ventas")
                    {
                        balance[fecha.Month - 1, 0] += Convert.ToDouble(bbdd[fila, 14]);
                    }
                }
            }
            
            for (int fila = 0; fila <= balance.GetUpperBound(0)-1;fila++)
            {
                balance[fila, 2] = balance[fila, 0] - balance[fila, 1];
                balance[12, 0] += balance[fila, 0];
                balance[12, 1] += balance[fila, 1];
                balance[12, 2] += balance[fila, 2];
            }
            excel.InformeBalance(archivo, balance, fecha.Year.ToString());

        }

        private void InformeMovimientos(object[,] bbdd, string tipo,DateTime desde, DateTime hasta, string archivo, Excel_Manipulation excel)
        {
            int fechaCol = 2;
            int tipoCol = 4;
            object[,] ventasBlanco = new object[bbdd.GetUpperBound(0),8];
            object[,] ventasNegro = new object[bbdd.GetUpperBound(0), 8];
            object[,] comprasBlanco = new object[bbdd.GetUpperBound(0), 8];
            object[,] comprasNegro = new object[bbdd.GetUpperBound(0), 8];
            int contador = 0;
            int filaVB = 0;
            int filaVN = 0;
            int filaCB = 0;
            int filaCN = 0;


            for (int fila = 2; fila <= bbdd.GetUpperBound(0); fila++)
            {
                if (Convert.ToDateTime(bbdd[fila, fechaCol]) >= desde && Convert.ToDateTime(bbdd[fila, fechaCol]) < hasta && bbdd[fila,4].ToString() == tipo)
                {
                    if (tipo == "Ventas")
                    {


                        if (bbdd[fila, 11].ToString() == "Sin Comprobante")
                        {
                            ventasNegro[filaVN, 0] = bbdd[fila, 1];
                            ventasNegro[filaVN, 1] = bbdd[fila, 8];
                            ventasNegro[filaVN, 2] = bbdd[fila, 9];
                            ventasNegro[filaVN, 3] = bbdd[fila, 7];
                            ventasNegro[filaVN, 4] = bbdd[fila, 5];
                            ventasNegro[filaVN, 5] = bbdd[fila, 6];
                            ventasNegro[filaVN, 6] = bbdd[fila, 25];
                            ventasNegro[filaVN, 7] = bbdd[fila, 14];

                            filaVN++;
                        }
                        else
                        {
                            ventasBlanco[filaVB, 0] = bbdd[fila, 1];
                            ventasBlanco[filaVB, 1] = bbdd[fila, 8];
                            ventasBlanco[filaVB, 2] = bbdd[fila, 9];
                            ventasBlanco[filaVB, 3] = bbdd[fila, 7];
                            ventasBlanco[filaVB, 4] = bbdd[fila, 5];
                            ventasBlanco[filaVB, 5] = bbdd[fila, 6];
                            ventasBlanco[filaVB, 6] = bbdd[fila, 25];
                            ventasBlanco[filaVB, 7] = bbdd[fila, 14];
                            filaVB++;
                        }
                    }
                    else if (tipo == "Compras")
                    {
                        if (bbdd[fila, 11].ToString() == "Sin Comprobante")
                        {
                            comprasNegro[filaCN, 0] = bbdd[fila, 1];
                            comprasNegro[filaCN, 1] = bbdd[fila, 8];
                            comprasNegro[filaCN, 2] = bbdd[fila, 9];
                            comprasNegro[filaCN, 3] = bbdd[fila, 7];
                            comprasNegro[filaCN, 4] = bbdd[fila, 5];
                            comprasNegro[filaCN, 5] = bbdd[fila, 6];
                            comprasNegro[filaCN, 6] = bbdd[fila, 25];
                            comprasNegro[filaCN, 7] = bbdd[fila, 14];
                            filaCN++;
                        }
                        else 
                        {
                            comprasBlanco[filaCB, 0] = bbdd[fila, 1];
                            comprasBlanco[filaCB, 1] = bbdd[fila, 8];
                            comprasBlanco[filaCB, 2] = bbdd[fila, 9];
                            comprasBlanco[filaCB, 3] = bbdd[fila, 7];
                            comprasBlanco[filaCB, 4] = bbdd[fila, 5];
                            comprasBlanco[filaCB, 5] = bbdd[fila, 6];
                            comprasBlanco[filaCB, 6] = bbdd[fila, 25];
                            comprasBlanco[filaCB, 7] = bbdd[fila, 14];
                            filaCB++;
                        }
                    }
                }
            }

            if (tipo == "Ventas")
            {
                excel.InformeMovimientosVentas(archivo, ventasBlanco, ventasNegro);
            }
            else if (tipo=="Compras")
            {
                excel.InformeMovimientosCompras(archivo, comprasBlanco, comprasNegro);
            }
            
            
        }

        private void InformeResumen(object[,] bbdd)
        {

        }
        private void InformeSubDiario(object[,] bbdd)
        {

        }

//------------------------------------------------- Desplegables y chekeo fecha --------------------------------------------------------
        private string FormatDate(DateTime fecha)
        {
            string dia = fecha.Day.ToString();
            string mes = fecha.Month.ToString();
            string año = fecha.Year.ToString();

            if (dia.Length == 1)
            {
                dia = "0" + dia;
            }

            if (mes.Length == 1)
            {
                mes = "0" + mes;
            }

            return dia + mes + año;
        }


        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (InformeCMBX.Text == "Compras" || InformeCMBX.Text == "Ventas")
            {
                TipoCMBX.SelectedIndex = -1;
                TipoCMBX.Items.Clear();
                TipoCMBX.Items.Add("Sub-Diario");
                TipoCMBX.Items.Add("Movimientos");

                label2.Text = "Desde:";
                label3.Enabled = true;
                HastaMovsDP.Enabled = true;
            }
            else if (InformeCMBX.Text == "Balance")
            {
                TipoCMBX.SelectedIndex = -1;
                TipoCMBX.Items.Clear();
                TipoCMBX.Items.Add("Anual");
                TipoCMBX.Items.Add("Parcial");

                label2.Text = "Desde:";
                label3.Enabled = true;
                HastaMovsDP.Enabled = true;

            }
            else if(InformeCMBX.Text == "Contactos")
            {
                TipoCMBX.SelectedIndex = -1;
                TipoCMBX.Items.Clear();
                TipoCMBX.Items.Add("Repartos");
                TipoCMBX.SelectedIndex = 0;
            }
        }

        private void DesdeMovsDP_ValueChanged(object sender, EventArgs e)
        {

        }

        private void TipoCMBX_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TipoCMBX.Text == "Anual")
            {
                label2.Text = "Año:";
                label3.Enabled = false;
                HastaMovsDP.Enabled = false;
            }
            else if (TipoCMBX.Text == "Parcial")
            {
                label2.Text = "Desde:";
                label3.Enabled = true;
                HastaMovsDP.Enabled = true;
            }
        }


    }
}
