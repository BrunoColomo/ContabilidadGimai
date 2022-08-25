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
    public partial class IngresarMovimiento : Form
    {

        public object[,] parametros;
        public Contabilidad menuInicio;
        string ruta;
        public string idContacto;
        

        public IngresarMovimiento(Contabilidad menu, object[,] contactos, string contacto)
        {
            menuInicio = menu;
            ruta = menu.ruta;
            InitializeComponent();
            ExtraerParametros();
            CBX_SetItems(parametros);
            
            for (int i =2;i<=contactos.GetUpperBound(0);i++)
            {
                if (contactos[i,3].ToString().ToLower() == contacto.ToLower())
                {
                    for (int j = 1; j <= contactos.GetUpperBound(1); j++)
                    {
                        if (contactos[i, j] == null)
                        {
                            contactos[i, j] = "";
                        }
                    }
                    idContacto = contactos[i, 1].ToString();
                    cuitTBX.Text = contactos[i, 5].ToString();
                    razonSocialTBX.Text = contactos[i, 4].ToString();
                    cuentaCBX.Text = contactos[i, 7].ToString();
                    tipoMovCBX.Text = contactos[i, 8].ToString();
                    categoriaCBX.Text = contactos[i, 9].ToString();
                    movimientoCBX.Text = contactos[i, 10].ToString();
                    i = contactos.GetUpperBound(0);
                }
            }

        }

        //---------------------------------------------  Extrae parametros del formulario desde el excel  -------------------------------------

        private void ExtraerParametros()
        { 
            Excel_Manipulation exelManip = new Excel_Manipulation();
            parametros = exelManip.Leer( ruta + "Parametros\\Contabilidad PRMT.xlsx", 1);
            exelManip.ReleaseExcel();
        }

        private object[] CBX_SetItems (string CBXValor, int filtro, int columna)
        {
            
            object[] itemCBX = new object[parametros.GetUpperBound(0)];
            int items = 0;
            
            for (int fila = 2; fila < parametros.GetUpperBound(0); fila++)
            {
                if (parametros[fila, columna] == null)
                {
                    break;
                }
                if (parametros[fila, columna].ToString() != parametros[fila - 1, columna].ToString() && parametros[fila,filtro].ToString() == CBXValor)
                {
                    itemCBX[items] = parametros[fila, columna].ToString();
                    items++;
                }
            }
            Array.Resize(ref itemCBX, items);

            return itemCBX;
        }
        
        private object[] Set_Parametros(object[,] prmt,int columna)
        {
            object[] itemCBX= new object[prmt.Length];
            int items = 0;

            for (int fila = 2; fila < prmt.GetUpperBound(0); fila++)
            {
                if (prmt[fila, columna] == null)
                {
                    break;
                }
                if (prmt[fila,columna].ToString() != prmt[fila-1,columna].ToString())
                {
                    itemCBX[items] = prmt[fila, columna].ToString();
                    items++;
                }
            }
            Array.Resize(ref itemCBX, items);
            
            return itemCBX;
        }

        private void CBX_SetItems(object [,] prmt)
        {
            cuentaCBX.Items.Clear();
            tipoMovCBX.Items.Clear();
            categoriaCBX.Items.Clear();
            movimientoCBX.Items.Clear();
            formaPagoCBX.Items.Clear();

            tipoComptrobanteCBX.Items.Clear();
            IvaCMBX.Items.Clear();
            IvaCMBX2.Items.Clear();
            IibbCMBX.Items.Clear();

            cuentaCBX.Items.AddRange(Set_Parametros(prmt, 2));
            tipoMovCBX.Items.AddRange(Set_Parametros(prmt, 3));
            categoriaCBX.Items.AddRange(Set_Parametros(prmt, 4));
            movimientoCBX.Items.AddRange(Set_Parametros(prmt, 5));
            formaPagoCBX.Items.AddRange(Set_Parametros(prmt, 9));


            tipoComptrobanteCBX.Items.AddRange(Set_Parametros(prmt, 6));
            IvaCMBX.Items.AddRange(Set_Parametros(prmt, 7));
            IvaCMBX2.Items.AddRange(Set_Parametros(prmt, 7));
            IibbCMBX.Items.AddRange(Set_Parametros(prmt, 8));
            IibbCMBX2.Items.AddRange(Set_Parametros(prmt, 8));
            
            /*  Quitado para que puedan manejar las cuentas
             
            cuentaCBX.Enabled = true;
            cuentaCBX.SelectedItem = "Huerta";
            cuentaCBX.Enabled = false;
            */
        }

        
        //---------------------------------------------------------------  KEY PRESS   --------------------------------------------------------
        
        private void cuitTBX_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '-')
            {
                e.Handled = true;
            }
        }

        private void nroComprobanteTBX_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '-')
            {
                e.Handled = true;
            }
        }

        private void Moneda_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }


        //---------------------------------------------- RELACION ENTRE PARAMETROS -------------------------------------------------


        private void movimientoCBX_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (movimientoCBX.Text != "" && categoriaCBX.Text == "")
            {
                for (int fila = 1; fila < parametros.Length; fila++)
                {
                    if (parametros[fila, 5].ToString() == movimientoCBX.Text)
                    {
                        categoriaCBX.SelectedItem = parametros[fila, 4].ToString();
                        break;
                    }
                }
            }
        }

        private void categoriaCBX_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool pertenece = false;
            string movimiento = movimientoCBX.Text;
            movimientoCBX.Items.Clear();
            movimientoCBX.Items.AddRange(CBX_SetItems(categoriaCBX.Text, 4, 5));
            movimientoCBX.Text = movimiento;

            for (int fila = 1; fila < parametros.GetUpperBound(0); fila++)
            {
                if (parametros[fila, 5] != null)
                {
                    if (parametros[fila, 5].ToString() == movimiento && parametros[fila, 4].ToString() == categoriaCBX.Text)
                    {
                        pertenece = true;
                        break;
                    }
                }
            }
            if (pertenece == false)
            {
                movimientoCBX.Text = "";
            }

        }
        private void tipoMovCBX_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tipoMov = tipoMovCBX.Text;
            bool pertenece = false;
            string categoria = categoriaCBX.Text;
            categoriaCBX.Items.Clear();
            categoriaCBX.Items.AddRange(CBX_SetItems(tipoMovCBX.Text, 3, 4));
            categoriaCBX.Text = categoria;

            for (int fila = 1; fila < parametros.GetUpperBound(0); fila++)
            {
                if (parametros[fila, 4] != null)
                {
                    if (parametros[fila, 4].ToString() == categoria && parametros[fila, 3].ToString() == tipoMovCBX.Text)
                    {
                        pertenece = true;
                        break;
                    }
                }
            }
            if (pertenece == false)
            {
                movimientoCBX.SelectedIndex = -1;
                categoriaCBX.SelectedIndex = -1;
            }
            tipoMovCBX.Text = tipoMov;
        }

        private void categoriaCBX_TextChanged(object sender, EventArgs e)
        {
            if (categoriaCBX.Text == "")
            {
                movimientoCBX.Items.Clear();
                movimientoCBX.Text = "";
                movimientoCBX.Items.AddRange(CBX_SetItems(categoriaCBX.Text, 4, 5));
            }
        }

            


     //----------------------------------------------------------   VALIDACIONES  -------------------------------------------------------------

        private object[] ValidarFormulario ()
        {

            bool formularioValido = true;
            object[] nuevoIngreso = new object[28];

            nuevoIngreso[0] = DateTime.Now;
            nuevoIngreso[1] = this.cuentaCBX;
            nuevoIngreso[2] = this.tipoMovCBX;
            nuevoIngreso[3] = this.categoriaCBX;
            nuevoIngreso[4] = this.movimientoCBX;
            nuevoIngreso[5] = this.conceptoTB;
            nuevoIngreso[6] = this.fechaMTBX;
            nuevoIngreso[7] = this.razonSocialTBX;
            nuevoIngreso[8] = this.cuitTBX;
            nuevoIngreso[9] = this.tipoComptrobanteCBX;
            nuevoIngreso[10] = this.nroComprobanteTBX;
            nuevoIngreso[11] = this.observacionesTB;


            nuevoIngreso[12] = this.TotalTBX;
            nuevoIngreso[13] = this.SubtotalGravadoTBX;
            nuevoIngreso[14] = this.SubtotalNoGravadoTBX;
            nuevoIngreso[15] = this.IvaCMBX;
            nuevoIngreso[16] = this.IvaTBX;
            nuevoIngreso[17] = this.IibbCMBX;
            nuevoIngreso[18] = this.IibbTBX;
            nuevoIngreso[19] = this.IibbCMBX2;
            nuevoIngreso[20] = this.IibbTBX2;
            nuevoIngreso[21] = this.OtrosImpTBX;
            nuevoIngreso[22] = this.BonificacionTBX;
            nuevoIngreso[23] = this.formaPagoCBX;
            nuevoIngreso[24] = this.IvaCMBX2;
            nuevoIngreso[25] = this.IvaTBX2;
            nuevoIngreso[26] = this.SubtotalGravadoTBX2;
            nuevoIngreso[27] = this.idContacto;

            // Campos Obligatorios

            for (int items = 1; items < nuevoIngreso.Length; items++)
            {
                if (items != 27) /*  EXCLUYO ID de Contacto*/
                { 
                    Control controlActual = (Control)nuevoIngreso[items];

                    if ((controlActual.Text == "") && (items <= 10 || items == 12 || items == 23))
                    {
                        if ((tipoComptrobanteCBX.Text == "Sin Comprobante" || tipoComptrobanteCBX.Text == "Banco" || tipoComptrobanteCBX.Text == "Recibo") && (items == 10 || items ==8))
                        {

                        }
                        else
                        {
                            errorProvider1.SetError(controlActual, "Campo Obligatorio");
                            errorProvider1.SetIconPadding(controlActual, 5);
                            formularioValido = false;
                        }
                    
                    }
                    else
                    {
                        errorProvider1.SetError(controlActual, string.Empty);
                    }
                    nuevoIngreso[items] = controlActual.Text;
                }
            }

            // Monto vacio

            if (SubtotalGravadoTBX.Text == "0")
            {
                errorProvider1.SetError(SubtotalGravadoTBX, "Campo Obligatorio");
                errorProvider1.SetIconPadding(SubtotalGravadoTBX, 5);
                formularioValido = false;
            }
            else
            {
                errorProvider1.SetError(SubtotalGravadoTBX, string.Empty);
            }

            // Fecha vacio

            if (fechaMTBX.Text == "  /  /")
            {
                errorProvider1.SetError(fechaMTBX, "Campo Obligatorio");
                errorProvider1.SetIconPadding(fechaMTBX, 5);
            }
            else
            {
                errorProvider1.SetError(fechaMTBX, string.Empty);
            }

            // Correspondencia Iibb

            if (IibbCMBX.Text == "" && IibbTBX.Text != "0")
            {

                errorProvider1.SetError(IibbCMBX, "Completar Campo");
                errorProvider1.SetIconPadding(IibbCMBX, 5);
                formularioValido = false;

            }
            else if (IibbCMBX.Text != "" && IibbTBX.Text == "0")
            {
                errorProvider1.SetError(IibbTBX, "Completar Campo");
                errorProvider1.SetIconPadding(IibbTBX, 5);
                formularioValido = false;
            }
            else
            {
                errorProvider1.SetError(IibbTBX, string.Empty);
                errorProvider1.SetError(IibbCMBX, string.Empty);
            }
            // Correspondencia Iibb2

            if (IibbCMBX2.Text == "" && IibbTBX2.Text != "0")
            {

                errorProvider1.SetError(IibbCMBX2, "Completar Campo");
                errorProvider1.SetIconPadding(IibbCMBX2, 5);
                formularioValido = false;

            }
            else if (IibbCMBX2.Text != "" && IibbTBX2.Text == "0")
            {
                errorProvider1.SetError(IibbTBX2, "Completar Campo");
                errorProvider1.SetIconPadding(IibbTBX2, 5);
                formularioValido = false;
            }
            else
            {
                errorProvider1.SetError(IibbTBX2, string.Empty);
                errorProvider1.SetError(IibbCMBX2, string.Empty);
            }
            // Largo CUIT

            if ((cuitTBX.Text.Length == 11 || cuitTBX.Text.Length == 8) || tipoComptrobanteCBX.Text == "Sin Comprobante" || tipoComptrobanteCBX.Text == "Banco" || tipoComptrobanteCBX.Text == "Recibo")
            {
                errorProvider1.SetError(cuitTBX, string.Empty);
            }
            else
            {
                errorProvider1.SetError(cuitTBX, "Completar Campo");
                errorProvider1.SetIconPadding(cuitTBX, 5);
                formularioValido = false;
            }

            // Largo Comprobante

            int prueba = 0;
            prueba = nroComprobanteTBX.Text.IndexOf("-") +1;

            if (prueba != -1)
            {
                string numero = nroComprobanteTBX.Text.Substring(prueba, nroComprobanteTBX.Text.Length - prueba);
                if (numero.Length != 8 && tipoComptrobanteCBX.Text != "Sin Comprobante" && tipoComptrobanteCBX.Text != "Banco")
                {
                    errorProvider1.SetError(nroComprobanteTBX, "Ingreso Invalido");
                    errorProvider1.SetIconPadding(nroComprobanteTBX, 5);
                    formularioValido = false;
                }
                else
                {
                    errorProvider1.SetError(nroComprobanteTBX, string.Empty);
                }
            }
            else
            {
                errorProvider1.SetError(nroComprobanteTBX, "Falta simbolo -");
                errorProvider1.SetIconPadding(nroComprobanteTBX, 5);
                formularioValido = false;
            }

            if (this.tipoComptrobanteCBX.Text.ToString().Substring(0, 9) == "Nota de C")
            {
                nuevoIngreso[12] = float.Parse(TotalTBX.Text, System.Globalization.CultureInfo.InvariantCulture.NumberFormat) * (-1);
                nuevoIngreso[13] = float.Parse(SubtotalGravadoTBX.Text, System.Globalization.CultureInfo.InvariantCulture.NumberFormat) * (-1);
                nuevoIngreso[14] = float.Parse(SubtotalNoGravadoTBX.Text, System.Globalization.CultureInfo.InvariantCulture.NumberFormat) * (-1);
                nuevoIngreso[16] = float.Parse(IvaTBX.Text, System.Globalization.CultureInfo.InvariantCulture.NumberFormat) * (-1);
                nuevoIngreso[18] = float.Parse(IibbTBX.Text, System.Globalization.CultureInfo.InvariantCulture.NumberFormat) * (-1);
                nuevoIngreso[20] = float.Parse(IibbTBX2.Text, System.Globalization.CultureInfo.InvariantCulture.NumberFormat) * (-1);
                nuevoIngreso[21] = float.Parse(OtrosImpTBX.Text, System.Globalization.CultureInfo.InvariantCulture.NumberFormat) * (-1);
                nuevoIngreso[22] = float.Parse(BonificacionTBX.Text, System.Globalization.CultureInfo.InvariantCulture.NumberFormat) * (-1);
                nuevoIngreso[25] = float.Parse(IvaTBX2.Text, System.Globalization.CultureInfo.InvariantCulture.NumberFormat) * (-1);
                nuevoIngreso[26] = float.Parse(SubtotalGravadoTBX2.Text, System.Globalization.CultureInfo.InvariantCulture.NumberFormat) * (-1);
            }


            // Valida que todos los campos esten OK

            if (formularioValido)
            {
                return nuevoIngreso;
            }
            else
            {
                return null;
            }
        }

        
        private void FechaMTBX_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!ValidarFecha() && fechaMTBX.Text !="  /  /")
            {
                
                e.Cancel = true;
            }

        }



        //------------------------------------------------------------------  FORMULARIO  -----------------------------------------------------------


        private void FormContainer_Paint(object sender, PaintEventArgs e)
        {

        }

        private void IngresarMovimiento_Closed(object sender, FormClosedEventArgs e)
        {
            BuscarContacto buscarContacto = new BuscarContacto(menuInicio);
            buscarContacto.Show();

        }

        //------------------------------------------------------------------  BOTONES  -----------------------------------------------------------


        private void SalirBTN_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ReestablecerBTN_Click(object sender, EventArgs e)
        {
            ReestablecerCampos();
        }

        private void CargarBTN_Click(object sender, EventArgs e)
        {

            object[] datosFormulario = ValidarFormulario();

            if (datosFormulario == null)
            {
                MessageBox.Show("Corrija los campo con errores");
                return;
            }

            bool archivoModificado = false;
            
            Excel_Manipulation excel_Manipulation = new Excel_Manipulation();

            archivoModificado = excel_Manipulation.IngresarMovimiento(ruta + "Bases de Datos\\BBDD - Contabilidad.xlsx", 1, datosFormulario);

            if (archivoModificado)
            {
                MessageBox.Show("Movimiento ingresado");   
                this.Close();
            }
        }


        //------------------------------------------------------------------  ENTER  -----------------------------------------------------------


        private void SubtotalGravadoTBX_Enter(object sender, EventArgs e)
        {
            this.SubtotalGravadoTBX.SelectAll();
        }
        private void SubtotalNoGravadoTBX_Enter(object sender, EventArgs e)
        {
            this.SubtotalNoGravadoTBX.SelectAll();
        }
        private void BonificacionTBX_Enter(object sender, EventArgs e)
        {
            this.BonificacionTBX.SelectAll();
        }
        private void OtrosImpTBX_Enter(object sender, EventArgs e)
        {
            this.OtrosImpTBX.SelectAll();
        }

        private void IibbTBX_Enter(object sender, EventArgs e)
        {
            this.IibbTBX.SelectAll();
        }
        private void IibbTBX2_Enter(object sender, EventArgs e)
        {
            this.IibbTBX2.SelectAll();
        }

        private void fechaMTBX_GotFocus(object sender, EventArgs e)
        {
            this.fechaMTBX.SelectAll();
        }

        //------------------------------------------------------------------  TEXT CHANGED  -----------------------------------------------------------



        private void SubtotalGravadoTBX_TextChanged(object sender, EventArgs e)
        {
            CalcularIva();

            if (SubtotalGravadoTBX.Text == "" )
            {
                SubtotalGravadoTBX.Text = "0";
            }
            CalcularTotal();
        }

        private void SubtotalGravadoTBX2_TextChanged(object sender, EventArgs e)
        {

            CalcularIva2();

            if (SubtotalGravadoTBX2.Text == "")
            {
                SubtotalGravadoTBX2.Text = "0";
            }
            CalcularTotal();
        }

        private void SubtotalNoGravadoTBX_TextChanged(object sender, EventArgs e)
        {
            if (SubtotalNoGravadoTBX.Text == "" )
            {
                SubtotalNoGravadoTBX.Text = "0";
            }
            CalcularTotal();
        }

        private void BonificacionTBX_TextChanged(object sender, EventArgs e)
        {
            if (BonificacionTBX.Text == "" )
            {
                BonificacionTBX.Text = "0";
            }
            CalcularTotal();
        }

        private void OtrosImpTBX_TextChanged(object sender, EventArgs e)
        {
            if (OtrosImpTBX.Text == "" )
            {
                OtrosImpTBX.Text = "0";
            }
            CalcularTotal();
        }

        private void IvaTBX_TextChanged(object sender, EventArgs e)
        {
            if (IvaTBX.Text == "" )
            {
                IvaTBX.Text = "0";
            }
            CalcularTotal();
        }

        private void IvaCMBX_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IvaCMBX.Text == "0%")
            {
                IvaTBX.ReadOnly = false;
                IvaTBX.Text = "0";
            }
            else if (IvaCMBX.Text == " ")
            {
                IvaTBX.Text = "0";
            }
            else
            {
                IvaTBX.ReadOnly = true;
                CalcularIva();
            }
        }
        private void IvaTBX2_TextChanged(object sender, EventArgs e)
        {
            if (IvaTBX2.Text == "")
            {
                IvaTBX2.Text = "0";
            }
            CalcularTotal();
        }

        private void IvaCMBX2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IvaCMBX2.Text == "0%")
            {
                IvaTBX2.ReadOnly = false;
                IvaTBX2.Text = "0";
            }
            else if (IvaCMBX2.Text == " ")
            {
                IvaTBX2.Text = "0";
            }
            else
            {
                IvaTBX2.ReadOnly = true;
                CalcularIva2();
            }
        }

        private void IibbTBX_TextChanged(object sender, EventArgs e)
        {
            if (IibbTBX.Text == "" )
            {
                IibbTBX.Text = "0";
            }
            CalcularTotal();
            if(IibbTBX.Text != "0")
            {
                errorProvider1.SetError(IibbTBX, string.Empty);
            }
        }
        private void IibbTBX2_TextChanged(object sender, EventArgs e)
        {
            if (IibbTBX2.Text == "" )
            {
                IibbTBX2.Text = "0";
            }
            CalcularTotal();
            if (IibbTBX2.Text != "0")
            {
                errorProvider1.SetError(IibbTBX2, string.Empty);
            }
        }


        //-----------------------------------------------------  CALCULOS Y FUNCIONES  ---------------------------------------------------

        private void ReestablecerCampos()
        {
            
            this.tipoMovCBX.Text = null;
            this.categoriaCBX.Text = null;
            this.movimientoCBX.Text = null;
            this.conceptoTB.Text = null;
            this.observacionesTB.Text = null;

            this.fechaMTBX.Text = null;
            this.razonSocialTBX.Text = null;
            this.cuitTBX.Text = null;
            this.tipoComptrobanteCBX.Text = null;
            this.nroComprobanteTBX.Text = null;

            this.SubtotalGravadoTBX.Text = null;
            this.SubtotalNoGravadoTBX.Text = null;
            this.BonificacionTBX.Text = null;
            this.OtrosImpTBX.Text = null;
            this.IvaCMBX.Text = null;
            this.IvaTBX.Text = null;
            this.IibbCMBX.Text = null;
            this.IibbTBX.Text = null;
            this.IibbCMBX2.Text = null;
            this.IibbTBX2.Text = null;
            this.IvaCMBX2.Text = null;
            this.IvaTBX2.Text = null;
            this.SubtotalGravadoTBX2.Text = null;
            this.TotalTBX.Text = null;
        }

        private bool ValidarFecha()
        {
            try
            {
                DateTime fecha = Convert.ToDateTime(fechaMTBX.Text);
                return true;
            }
            catch
            {
                return false;
            }

        }

        private void CalcularIva()
        {
            if (SubtotalGravadoTBX.Text != "" && IvaCMBX.Text != "" && IvaCMBX.Text != " ")
            {
                float importeGravado =  float.Parse(SubtotalGravadoTBX.Text, System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
                float porcentajeIva = 0;
                string iva = null;

                porcentajeIva = float.Parse(IvaCMBX.Text.Substring(0, IvaCMBX.Text.Length - 1), System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
                //porcentajeIva = Convert.ToInt32(IvaCMBX.Text.Substring(0, IvaCMBX.Text.Length - 1));
            
                float importeIva = importeGravado * (porcentajeIva / 100);

                IvaTBX.Text = importeIva.ToString("0.00").Replace(",",".");
            }

        }
        private void CalcularIva2()
        {
            if (SubtotalGravadoTBX2.Text != "" && IvaCMBX2.Text != "" && IvaCMBX2.Text != " ")
            {
                float importeGravado = float.Parse(SubtotalGravadoTBX2.Text, System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
                float porcentajeIva = 0;
                string iva = null;

                porcentajeIva = float.Parse(IvaCMBX2.Text.Substring(0, IvaCMBX2.Text.Length - 1), System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
                //porcentajeIva = Convert.ToInt32(IvaCMBX.Text.Substring(0, IvaCMBX.Text.Length - 1));

                float importeIva = importeGravado * (porcentajeIva / 100);

                IvaTBX2.Text = importeIva.ToString("0.00").Replace(",", ".");
            }

        }

        private void CalcularTotal()
        {
            try
            {
                float gravado = float.Parse(SubtotalGravadoTBX.Text, System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
                float gravado2 = float.Parse(SubtotalGravadoTBX2.Text, System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
                float noGravado = float.Parse(SubtotalNoGravadoTBX.Text, System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
                float bonificacion = float.Parse(BonificacionTBX.Text, System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
                float otros = float.Parse(OtrosImpTBX.Text, System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
                float iva = float.Parse(IvaTBX.Text, System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
                float iva2 = float.Parse(IvaTBX2.Text, System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
                float iibb = float.Parse(IibbTBX.Text, System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
                float iibb2 = float.Parse(IibbTBX2.Text, System.Globalization.CultureInfo.InvariantCulture.NumberFormat);

                float total =  gravado + gravado2 + noGravado + otros + iva + iva2 + iibb + iibb2 - bonificacion;

                TotalTBX.Text = total.ToString("0.00").Replace(",",".");
            }
            catch (Exception ex)
            {

            }

        }

        private void IibbCMBX_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cuentaCBX_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void IngresarMovimiento_Load(object sender, EventArgs e)
        {

        }

        private void nroComprobanteTBX_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void formaPagoCBX_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}