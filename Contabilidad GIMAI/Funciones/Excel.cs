using System;
using System.Collections.Generic;
using System.Linq;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using System.IO;
using System.Threading.Tasks;


namespace Contabilidad_GIMAI
{
    public class Excel_Manipulation
    {

        public bool IsOpened(string wbook)
        {
            try
            {
                
                File.Open(wbook, FileMode.Open, FileAccess.ReadWrite, FileShare.None).Dispose();
                return false;
            }
            catch (Exception ex)
            {
                char[] caracter = wbook.ToArray();
                string limite = "";
                string nombreArchivo = "";

                for (int i = caracter.Length-1; i > 0; i--)
                {
                    limite = string.Concat( caracter[i] , caracter[i - 1]);
                    if (caracter[i] == '\\' )
                    {
                        break;
                    }
                    else
                    {
                        nombreArchivo = string.Concat(caracter[i], nombreArchivo);
                    }
                }
                ReleaseExcel();
                ReleaseExcel();
                System.Windows.Forms.MessageBox.Show("Error archivo abierto: " + nombreArchivo);
                
                return true;
            }
        }

        public bool AbrirExcel(string rutaP)
        {
            if (IsOpened(rutaP)) {  return false; }

            try
            {
                Excel.Application xlApp = new Excel.Application();
                Excel.Workbook archivo = xlApp.Workbooks.Open(rutaP, 0, false, 5, "", "", true, Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);

                Excel._Worksheet hoja = archivo.Sheets[1];
                Excel.Range rango = hoja.UsedRange;

                xlApp.Visible = true;
                return true;
            }
            
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error al trabajar con el Excel");
                return false;
            }
        }

        
        public object[,] Leer(string rutaP, int hojaP)
        {
            if (IsOpened(rutaP)) { return null; }
            try
            {
                Excel.Application xlApp = new Excel.Application();
                Excel.Workbooks archivo = xlApp.Workbooks;
                Excel.Workbook arch = archivo.Open(rutaP);
                Excel.Worksheet hoja = arch.Sheets[hojaP];
                Excel.Range rango = hoja.UsedRange;
                
                object[,] tabla = rango.Value2;

                Marshal.ReleaseComObject(rango);
                Marshal.ReleaseComObject(hoja);
                arch.Close(true);
                Marshal.ReleaseComObject(arch);
                Marshal.ReleaseComObject(archivo);

                xlApp.Application.Quit();
                xlApp.Quit();
                Marshal.ReleaseComObject(xlApp);

                GC.Collect();
                GC.WaitForPendingFinalizers();

                return tabla;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error al trabajar con el Excel");
                return null;
            }
        }

        public void ReleaseExcel()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        public bool IngresarMovimiento(string rutaP, int hojaP, object[] valores)
        {
            if (IsOpened(rutaP)) { return false; }
            try
            {
                Excel.Application xlApp = new Excel.Application();
                Excel.Workbook archivo = xlApp.Workbooks.Open(rutaP, 0, false, 5, "", "", true, Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                Excel.Worksheet hoja = archivo.Sheets[hojaP];

                Excel.Range ultimaFila = hoja.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell, Type.Missing);


                object ultimoId = hoja.Range["a" + ultimaFila.Row].Value2;
                int uID = Convert.ToInt32(ultimoId);
                uID += 1;

                int proximaFila = ultimaFila.Row;
                proximaFila++;

                Excel.Range rango = hoja.Range["b" + proximaFila, "ac" + proximaFila];

                rango.Value2 = valores;

                hoja.Range["h" + proximaFila].Value2 = Convert.ToDateTime(valores[6]).ToOADate();

                rango = hoja.Cells[proximaFila, 1];

                rango.Value2 = uID;

                archivo.Save();

                GC.Collect();
                GC.WaitForPendingFinalizers();

                Marshal.ReleaseComObject(rango);
                Marshal.ReleaseComObject(hoja);

                archivo.Close(true);
                Marshal.ReleaseComObject(archivo);

                xlApp.Quit();
                Marshal.ReleaseComObject(xlApp);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error al trabajar con el Excel");
                return false;
            }
            return true;
        }

        public bool IngresarContacto(string rutaP, int hojaP, object[] valores)
        {
            if (IsOpened(rutaP)) { return false; }
            try
            {
                Excel.Application xlApp = new Excel.Application();
                Excel.Workbook archivo = xlApp.Workbooks.Open(rutaP, 0, false, 5, "", "", true, Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                Excel.Worksheet hoja = archivo.Sheets[hojaP];

                Excel.Range ultimaFila = hoja.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell, Type.Missing);


                object ultimoId = hoja.Range["a" + ultimaFila.Row].Value2;
                int uID = Convert.ToInt32(ultimoId);
                uID += 1;

                int proximaFila = ultimaFila.Row;
                proximaFila++;

                Excel.Range rango = hoja.Range["b" + proximaFila, "x" + proximaFila];

                rango.Value2 = valores;
                
                rango = hoja.Cells[proximaFila, 1];

                rango.Value2 = uID;

                archivo.Save();

                GC.Collect();
                GC.WaitForPendingFinalizers();

                Marshal.ReleaseComObject(rango);
                Marshal.ReleaseComObject(hoja);

                archivo.Close(true);
                Marshal.ReleaseComObject(archivo);

                xlApp.Quit();
                Marshal.ReleaseComObject(xlApp);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error al trabajar con el Excel");
                return false;
            }
            return true;
        }

        public bool Crear(string ruta)
        {
            try
            {
                Excel.Application xlApp = new Excel.Application();
                Excel.Workbook archivo = xlApp.Workbooks.Add();

                archivo.SaveAs(ruta);
                archivo.Close(0);
                xlApp.Quit();


                GC.Collect();
                GC.WaitForPendingFinalizers();
                Marshal.ReleaseComObject(archivo);
                Marshal.ReleaseComObject(xlApp);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error al trabajar con el Excel");
                return false;
            }
            return true;
        }


        public bool informeBalanceParcial(string ruta, object[,] datos)
        {
            if (IsOpened(ruta)) { return false; }

            try
            { 
                Excel.Application xlApp = new Excel.Application();
                Excel.Workbook archivo = xlApp.Workbooks.Open(ruta);
                Excel.Worksheet hoja = archivo.Sheets[1];
                Excel.Range rango = null;
                Excel.Range rangoFormat = hoja.Range["a3", "e3"];

                rango = hoja.Range["a2", "e" + (datos.GetUpperBound(0) + 2)];

                rango.Value2 = datos;
                hoja.Columns.AutoFit();
                rangoFormat.Copy();
                rango.PasteSpecial(Excel.XlPasteType.xlPasteFormats);

                hoja.Select();
                hoja.Range["a1"].Select();
                archivo.Save();

                Marshal.ReleaseComObject(hoja);

                archivo.Close(true);
                Marshal.ReleaseComObject(archivo);

                xlApp.Quit();
                Marshal.ReleaseComObject(xlApp);


                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error al trabajar con el Excel");
                return false;
            }
            return true;
        }

        public bool InformeSubDiarioVentas(string ruta, object[,] ventas, string mes)
        {
            if (IsOpened(ruta)) { return false; }

            try
            { 
                Excel.Application xlApp = new Excel.Application();
                Excel.Workbook archivo = xlApp.Workbooks.Open(ruta);
                Excel.Worksheet formatoHoja = archivo.Sheets[1];
                Excel.Worksheet hoja2 = null;
                Excel.Range rangoFormato = null;
                Excel.Range ultCelda = null;
                Excel.Range rangoVenta = null;

                hoja2 = archivo.Sheets.Add(formatoHoja);
                hoja2.Name = "Ventas";

                rangoVenta = hoja2.Range["a6", hoja2.Cells[ventas.GetUpperBound(0) + 6, 11]];

                rangoVenta.Value2 = ventas;

                hoja2.Range["a7", hoja2.Cells[ventas.GetUpperBound(0) + 6,11]].Sort(rangoVenta.Columns[1], Excel.XlSortOrder.xlAscending);

                formatoHoja.Range["a1", "f5"].Copy();
                hoja2.Range["a1", "f5"].PasteSpecial(Excel.XlPasteType.xlPasteAll);

                hoja2.Range["a2"].Value2 = hoja2.Range["a2"].Value2.ToString() + " " + mes;

                rangoFormato = formatoHoja.Range["a6", formatoHoja.Cells[ventas.GetUpperBound(0) + 6, 9]];
                rangoFormato.Copy();
                rangoVenta.PasteSpecial(Excel.XlPasteType.xlPasteFormats);

                rangoVenta.ColumnWidth = 16.14;
                hoja2.Range["a6"].RowHeight = 48;
                

                xlApp.DisplayAlerts = false;
                formatoHoja.Delete();
                xlApp.DisplayAlerts = true;
                hoja2.Range["a1"].Select();
                archivo.Save();

                GC.Collect();
                GC.WaitForPendingFinalizers();


                Marshal.ReleaseComObject(formatoHoja);
                Marshal.ReleaseComObject(hoja2);

                archivo.Close(true);
                Marshal.ReleaseComObject(archivo);

                xlApp.Quit();
                Marshal.ReleaseComObject(xlApp);
        }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error al trabajar con el Excel");
                return false;
            }
            return true;
        }

        public bool InformeSubDiarioCompras(string ruta, object[,] compras, string mes)
        {
            if (IsOpened(ruta)) { return false; }

            try
            { 
                Excel.Application xlApp = new Excel.Application();
                Excel.Workbook archivo = xlApp.Workbooks.Open(ruta);
                Excel.Worksheet formatoHoja = archivo.Sheets[1];
                Excel.Worksheet hoja2 = null;
                Excel.Range rangoFormato = null;
                Excel.Range ultCelda = null;
                Excel.Range rangoVenta = null;

                hoja2 = archivo.Sheets.Add(formatoHoja);
                hoja2.Name = "Compras";
            
                rangoVenta = hoja2.Range["a6", hoja2.Cells[compras.GetUpperBound(0) + 6, 21]];
            
                rangoVenta.Value2 = compras;

                hoja2.Range["a7", hoja2.Cells[compras.GetUpperBound(0) + 6, 21]].Sort(rangoVenta.Columns[1], Excel.XlSortOrder.xlAscending);

                formatoHoja.Range["a1", "d5"].Copy();
                hoja2.Range["a1", "d5"].PasteSpecial(Excel.XlPasteType.xlPasteAll);

                hoja2.Range["a2"].Value2 = hoja2.Range["a2"].Value2.ToString() + " " + mes;

                rangoFormato = formatoHoja.Range["a6", formatoHoja.Cells[compras.GetUpperBound(0) + 6, 21]];
                rangoFormato.Copy();
                rangoVenta.PasteSpecial(Excel.XlPasteType.xlPasteFormats);

                rangoVenta.ColumnWidth = 16.14;
                hoja2.Range["a6"].RowHeight = 48;

                xlApp.DisplayAlerts = false;
                formatoHoja.Delete();
                xlApp.DisplayAlerts = true;
                hoja2.Range["a1"].Select();
                archivo.Save();

                GC.Collect();
                GC.WaitForPendingFinalizers();


                Marshal.ReleaseComObject(formatoHoja);
                Marshal.ReleaseComObject(hoja2);

                archivo.Close(true);
                Marshal.ReleaseComObject(archivo);

                xlApp.Quit();
                Marshal.ReleaseComObject(xlApp);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error al trabajar con el Excel");
                return false;
            }
            return true;
        }


        public bool InformeCategoria(string ruta, object[,] datos, string año)
        {
            if (IsOpened(ruta)) { return false; }

            try
            { 
                Excel.Application xlApp = new Excel.Application();
                Excel.Workbook archivo = xlApp.Workbooks.Open(ruta);
                Excel.Worksheet formatoHoja = archivo.Sheets[1];
                Excel.Worksheet hoja2 = null;
                Excel.Range rangoFormato;
                Excel.Range ultCelda = null;
                int columnaAux = 0;
                int desde = 0;
                int hasta = 0;
                double subTotal = 0;
                int columnaDesde = 0;
                double totalMes = 0;
                double totalAño = 0;

                for (int columna = 0; columna <= datos.GetUpperBound(1); columna++)
                {
                    // Cambio de categoria y de hoja
                    if (columna == 0)
                    {
                        // Encabezados y formatos

                        columnaDesde = columna;
                        hoja2 = archivo.Sheets.Add(formatoHoja);
                        hoja2.Name = datos[0, columna].ToString();
                        hoja2.Cells[2, 2] = datos[0, columna] + " por Categoría";
                        hoja2.Cells[5, 2] = año;

                        columnaAux = 3;

                        formatoHoja.Range["b2", "e6"].Copy();
                        hoja2.Range["b2", "e6"].PasteSpecial(Excel.XlPasteType.xlPasteFormats);

                        formatoHoja.Range["b8", "b21"].Copy();
                        hoja2.Range["b8", "b21"].PasteSpecial(Excel.XlPasteType.xlPasteAll);
                    
                    }
                    else if ((datos[0, columna].ToString() != datos[0, columna - 1].ToString()) || columna == (datos.GetUpperBound(1)))
                    {
                        //Suma totales del Mes
                        if (columna > 1)
                        {
                            int columnaTotal = columna - columnaDesde + 3;
                            if (columna == datos.GetUpperBound(1)) { columnaTotal = columnaTotal + 1; }
                            hoja2.Cells[8, columnaTotal] = "Total";

                            for (int fila = 2; fila <= datos.GetUpperBound(0); fila++)
                            {
                                for (int col = columnaDesde; col < columna; col++)
                                {

                                    totalMes = totalMes + Convert.ToDouble(datos[fila, col]);
                                }
                                hoja2.Cells[fila + 7, columnaTotal] = totalMes;
                                totalAño = totalAño + totalMes;
                                totalMes = 0;
                            }
                            hoja2.Cells[21, columnaTotal] = totalAño;
                            totalAño = 0;
                            formatoHoja.Range["h8", "h21"].Copy();
                            rangoFormato = hoja2.Range[hoja2.Cells[8, columnaTotal], hoja2.Cells[ultCelda.Row, columnaTotal]];
                            rangoFormato.PasteSpecial(Excel.XlPasteType.xlPasteFormats);
                            hoja2.Columns.AutoFit();
                            hoja2.Range["a1"].Select();
                            columnaAux++;
                        }

                        // Encabezados y formatos
                        if (columna != datos.GetUpperBound(1))
                        { 
                            columnaDesde = columna;
                            hoja2 = archivo.Sheets.Add(formatoHoja);
                            hoja2.Name = datos[0, columna].ToString();
                            hoja2.Cells[2, 2] = datos[0, columna] + " por Categoría";
                            hoja2.Cells[5, 2] = año;

                            columnaAux = 3;

                            formatoHoja.Range["b2", "e6"].Copy();
                            hoja2.Range["b2", "e6"].PasteSpecial(Excel.XlPasteType.xlPasteFormats);

                            formatoHoja.Range["b8", "b21"].Copy();
                            hoja2.Range["b8", "b21"].PasteSpecial(Excel.XlPasteType.xlPasteAll);
                        }
                    }
                    else
                    {
                        columnaAux++;
                    }

                    //Formato Columnas

                    formatoHoja.Range["c8", "c21"].Copy();
                    ultCelda = hoja2.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell);

                    rangoFormato = hoja2.Range[hoja2.Cells[8, columnaAux], hoja2.Cells[ultCelda.Row, columnaAux]];
                    rangoFormato.PasteSpecial(Excel.XlPasteType.xlPasteFormats);

                    //Total anual por Item

                    subTotal = 0;
                    if (columna == 13)
                    {
                        string asd = " a";
                    }
                    for (int fila = 1; fila <= datos.GetUpperBound(0); fila++)
                    {
                        hoja2.Cells[fila + 7, columnaAux] = datos[fila, columna];

                        if (fila > 1)
                        {
                            subTotal = subTotal + Convert.ToDouble(datos[fila, columna]);
                        }
                    }

                    hoja2.Cells[ultCelda.Row, columnaAux] = subTotal;

                }

                //FOTMATO

                xlApp.DisplayAlerts = false;
                formatoHoja.Delete();
                xlApp.DisplayAlerts = true;

                hoja2 = archivo.Sheets[1];
                hoja2.Select();

                archivo.Save();

                GC.Collect();
                GC.WaitForPendingFinalizers();


                Marshal.ReleaseComObject(formatoHoja);
                Marshal.ReleaseComObject(hoja2);

                archivo.Close(true);
                Marshal.ReleaseComObject(archivo);

                xlApp.Quit();
                Marshal.ReleaseComObject(xlApp);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error al trabajar con el Excel");
                return false;
            }
            return true;
        }
        

        public bool InformeDetalle(string ruta, object[,] datos, string año)
        {
            if (IsOpened(ruta)) { return false; }
            try
            { 
                Excel.Application xlApp = new Excel.Application();
                Excel.Workbook archivo = xlApp.Workbooks.Open(ruta);
                Excel.Worksheet formatoHoja = archivo.Sheets[1];
                Excel.Worksheet hoja2 = null;
                Excel.Range rangoFormato;
                Excel.Range ultCelda = null;
                int columnaAux = 0;
                int desde = 0;
                int hasta = 0;
                double subTotal = 0;
                int columnaDesde = 0;
                double totalMes = 0;
                double totalAño = 0;


                for (int columna = 0; columna <= datos.GetUpperBound(1); columna++)
                {
                    // Cambio de categoria y de hoja

                    if (columna == 0)
                    {
                        // Encabezados y formatos

                        columnaDesde = columna;
                        hoja2 = archivo.Sheets.Add(formatoHoja);
                        hoja2.Name = datos[1, columna].ToString();
                        hoja2.Cells[2, 2] = datos[0, columna] + " Detallados " + año;
                        hoja2.Cells[5, 2] = datos[1, columna];

                        columnaAux = 3;

                        formatoHoja.Range["b2", "e6"].Copy();
                        hoja2.Range["b2", "e6"].PasteSpecial(Excel.XlPasteType.xlPasteFormats);

                        formatoHoja.Range["b8", "b21"].Copy();
                        hoja2.Range["b8", "b21"].PasteSpecial(Excel.XlPasteType.xlPasteAll);
                        hoja2.Range["a1"].Select();
                    }
                    else if ((datos[1, columna].ToString() != datos[1, columna - 1].ToString()) || columna == datos.GetUpperBound(1))
                    {
                        //Suma totales del Mes

                        if (columna > 1)
                        {
                            int columnaTotal = columna - columnaDesde + 3;
                            hoja2.Cells[8, columnaTotal] = "Total";
                            for (int fila = 3;fila <=datos.GetUpperBound(0);fila++)
                            {
                                for (int col = columnaDesde; col < columna; col++)
                                {

                                    totalMes = totalMes + Convert.ToDouble(datos[fila, col]);
                                }
                                hoja2.Cells[fila + 6, columnaTotal] = totalMes;
                                totalAño = totalAño + totalMes;
                                totalMes = 0;
                            }
                            hoja2.Cells[21, columnaTotal] = totalAño;
                            totalAño = 0;
                            formatoHoja.Range["h8", "h21"].Copy();
                            rangoFormato = hoja2.Range[hoja2.Cells[8, columnaTotal], hoja2.Cells[ultCelda.Row, columnaTotal]];
                            rangoFormato.PasteSpecial(Excel.XlPasteType.xlPasteFormats);
                            hoja2.Columns.AutoFit();
                            hoja2.Range["a1"].Select();
                        }

                        // Encabezados y formatos

                        columnaDesde = columna;
                        hoja2 = archivo.Sheets.Add(formatoHoja);
                        hoja2.Name = datos[1, columna].ToString();
                        hoja2.Cells[2, 2] = datos[0, columna] + " Detallados " + año;
                        hoja2.Cells[5, 2] = datos[1, columna];

                        columnaAux = 3;

                        formatoHoja.Range["b2", "e6"].Copy();
                        hoja2.Range["b2", "e6"].PasteSpecial(Excel.XlPasteType.xlPasteFormats);

                        formatoHoja.Range["b8", "b21"].Copy();
                        hoja2.Range["b8", "b21"].PasteSpecial(Excel.XlPasteType.xlPasteAll);

                    }
                    else
                    {
                        columnaAux++;
                    }

                    //Formato Columnas

                    formatoHoja.Range["c8", "c21"].Copy();
                    ultCelda = hoja2.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell);

                    rangoFormato = hoja2.Range[hoja2.Cells[8, columnaAux], hoja2.Cells[ultCelda.Row, columnaAux]];
                    rangoFormato.PasteSpecial(Excel.XlPasteType.xlPasteFormats);

                    //Total anual por Item

                    subTotal = 0;

                    for (int fila = 2;fila<=datos.GetUpperBound(0);fila++)
                    {
                        hoja2.Cells[fila + 6, columnaAux] = datos[fila, columna];

                        if (fila >2)
                        { 
                            subTotal = subTotal + Convert.ToDouble(datos[fila, columna]);
                        }
                    }
                    hoja2.Cells[ultCelda.Row, columnaAux] = subTotal;
                }

                //FOTMATO
                xlApp.DisplayAlerts = false;
                formatoHoja.Delete();
                xlApp.DisplayAlerts = true;

                hoja2 = archivo.Sheets[1];
                hoja2.Select();

                archivo.Save();

                GC.Collect();
                GC.WaitForPendingFinalizers();

            
                Marshal.ReleaseComObject(formatoHoja);

                archivo.Close(true);
                Marshal.ReleaseComObject(archivo);

                xlApp.Quit();
                Marshal.ReleaseComObject(xlApp);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error al trabajar con el Excel");
                return false;
            }
            return true;

         }

        public bool InformeMovimientosVentas(string ruta, object[,] ventasBlanco, object[,] ventasNegro)
        {
            if (IsOpened(ruta)) { return false; }

            try
            {
                Excel.Application xlApp = new Excel.Application();
                Excel.Workbook archivo = xlApp.Workbooks.Open(ruta);
                Excel.Worksheet hojaFac = archivo.Sheets[1];
                Excel.Worksheet hojaSinFac = archivo.Sheets[2];

                Excel.Range rango = hojaFac.Range["a2" , "h" + ventasBlanco.GetUpperBound(0)+2];

                rango.Value2 = ventasBlanco;
                hojaFac.Columns.AutoFit();
                
                rango = hojaSinFac.Range["a2", "h" + ventasNegro.GetUpperBound(0)+2];

                rango.Value2 = ventasNegro;

                hojaSinFac.Columns.AutoFit();

                hojaFac.Select();
                hojaFac.Range["a1"].Select();

                archivo.Save();
                
                GC.Collect();
                GC.WaitForPendingFinalizers();

                Marshal.ReleaseComObject(rango);
                Marshal.ReleaseComObject(hojaFac);

                archivo.Close(true);
                Marshal.ReleaseComObject(archivo);

                xlApp.Quit();
                Marshal.ReleaseComObject(xlApp);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error al trabajar con el Excel");
                return false;
            }
            return true;
        }
    

        public bool InformeMovimientosCompras(string ruta, object[,] comprasBlanco, object[,] comprasNegro)
        {
            if (IsOpened(ruta)) { return false; }

            try
            {
                Excel.Application xlApp = new Excel.Application();
                Excel.Workbook archivo = xlApp.Workbooks.Open(ruta);
                Excel.Worksheet hojaFac= archivo.Sheets[1];
                Excel.Worksheet hojaSinFac = archivo.Sheets[2];

                Excel.Range rango = hojaFac.Range["a2", "h" + comprasBlanco.GetUpperBound(0)+2];

                rango.Value2 = comprasBlanco;
                rango.Columns.AutoFit();

                rango = hojaSinFac.Range["a2", "h" + comprasNegro.GetUpperBound(0) + 2];

                rango.Value2 = comprasNegro;

                hojaSinFac.Columns.AutoFit();
                hojaFac.Range["a1"].Select();
                archivo.Save();

                GC.Collect();
                GC.WaitForPendingFinalizers();

                Marshal.ReleaseComObject(rango);
                Marshal.ReleaseComObject(hojaFac);

                archivo.Close(true);
                Marshal.ReleaseComObject(archivo);

                xlApp.Quit();
                Marshal.ReleaseComObject(xlApp);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error al trabajar con el Excel");
                return false;
            }
            return true;
        }
    

        public bool InformeBalance(string ruta, double[,] datos, string año)
        {
            if (IsOpened(ruta)) { return false; }

            try
            {
                Excel.Application xlApp = new Excel.Application();
                Excel.Workbook archivo = xlApp.Workbooks.Open(ruta);
                Excel.Worksheet hoja = archivo.Sheets[1];
                Excel.Range rango = hoja.Range["c7", "e" + (datos.GetUpperBound(0)+7)];


                hoja.Cells[2, 1] = hoja.Range["a2"].Text + año;

                rango.Value2 = datos;

                archivo.Save();

                GC.Collect();
                GC.WaitForPendingFinalizers();

                Marshal.ReleaseComObject(rango);
                Marshal.ReleaseComObject(hoja);

                archivo.Close(true);
                Marshal.ReleaseComObject(archivo);

                xlApp.Quit();
                Marshal.ReleaseComObject(xlApp);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error al trabajar con el Excel");
                return false;
            }
            return true;
        }
        public bool InformeRepartos(string rutaP, int hojaP, object[,] valores)
        {
            if (IsOpened(rutaP)) { return false; }
            try
            {
                Excel.Application xlApp = new Excel.Application();
                Excel.Workbook archivo = xlApp.Workbooks.Open(rutaP, 0, false, 5, "", "", true, Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                Excel.Worksheet hoja = archivo.Sheets[hojaP];

                Excel.Range ultimaFila = hoja.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell, Type.Missing);

                Excel.Range rango = hoja.Range["a7", "o22"];

                rango.Value2 = valores;
                
                archivo.Save();

                GC.Collect();
                GC.WaitForPendingFinalizers();

                Marshal.ReleaseComObject(rango);
                Marshal.ReleaseComObject(hoja);

                archivo.Close(true);
                Marshal.ReleaseComObject(archivo);

                xlApp.Quit();
                Marshal.ReleaseComObject(xlApp);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error al trabajar con el Excel");
                return false;
            }
            return true;
        }
    }
}