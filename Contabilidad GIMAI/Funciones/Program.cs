using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;


namespace Contabilidad_GIMAI
{
    static class Program
    {
        
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {

            //System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("es-AR");
            //System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo("es-AR");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new IngresarMovimiento());
            string ruta = Application.StartupPath.Substring(0, Application.StartupPath.LastIndexOf("bin\\"));
            Application.Run(new Contabilidad(ruta));
            //object[,] bbdd = new object[10,2];
            //Excel_Manipulation excel = new Excel_Manipulation();
            //excel.InformeCategoria(ruta + "Informes\\Contabilidad\\Resumen\\Contabilidad - Resumen - Categorías.xlsx", bbdd);

            

        }

        
    }
}
