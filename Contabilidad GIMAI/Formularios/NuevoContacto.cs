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
    public partial class NuevoContacto : Form
    {
        public string ruta;
        public string tipoContacto;
        public object[,] contactos;
        public object[,] parametros;
        public Contabilidad menuInicio;

        public NuevoContacto(Contabilidad menu, string tipo, string contacto, object[,] contactosBBDD)
        {
            menuInicio = menu;
            ruta = menu.ruta;
            tipoContacto = tipo;
            InitializeComponent();
            contactos = contactosBBDD;
            ExtraerParametros();
            CBX_SetItems(parametros);

            if (tipoContacto == "editar")
            {
                
                for (int i=2;i<=contactos.GetUpperBound(0);i++)
                {
                    for (int j = 1; j <= contactos.GetUpperBound(1); j++)
                    {
                        if (contactos[i, j] == null)
                        {
                            contactos[i, j] = "";
                        }
                    }
                    if (contactos[i,3].ToString().ToLower()==contacto.ToLower())
                    {
                        Titulo.Text = "Editar " + contactos[i, 2].ToString();
                        NombreTBX.Text = contactos[i, 3].ToString();
                        razonSocialTBX.Text = contactos[i, 4].ToString();
                        CuitTBX.Text = contactos[i, 5].ToString();
                        condicionIVACBX.Text = contactos[i, 6].ToString();
                        cuentaCBX.Text = contactos[i, 7].ToString();
                        tipoMovCBX.Text = contactos[i, 8].ToString();
                        categoriaCBX.Text = contactos[i, 9].ToString();
                        movimientoCBX.Text = contactos[i, 10].ToString();
                        HorariosTBX.Text = contactos[i, 11].ToString();
                        formaPagoCBX.Text = contactos[i, 12].ToString();
                        LocalidadTBX.Text = contactos[i, 13].ToString();
                        CalleTBX.Text = contactos[i, 14].ToString();
                        NumeroTBX.Text = contactos[i, 15].ToString();
                        PisoTBX.Text = contactos[i, 16].ToString();
                        DepartamentoTBX.Text = contactos[i, 17].ToString();
                        Mail1TBX.Text = contactos[i, 18].ToString();
                        Mail2TBX.Text = contactos[i, 19].ToString();
                        Telefono1TBX.Text = contactos[i, 20].ToString();
                        Contacto1TBX.Text = contactos[i, 21].ToString();
                        Telefono2TBX.Text = contactos[i, 22].ToString();
                        Contacto2TBX.Text = contactos[i, 23].ToString();
                        ObservacionesTBX.Text = contactos[i, 24].ToString();
                    }
                }
            }
            else
            {
                Titulo.Text = "Nuevo " + tipo;
                NombreTBX.Text = contacto;
                cuentaCBX.Text = "Huerta";
            }

            if (tipo == "Cliente")
            {
                tipoMovCBX.Text = "Ventas";
            }
            else if (tipo == "Proveedor")
            {
                tipoMovCBX.Text = "Compras";
            }
            else if (tipo == "Banco")
            {
                tipoMovCBX.Text = "Mov. Bancario";
            }
            tipoMovCBX.Enabled = false;
        }

        private void ExtraerParametros()
        {
            Excel_Manipulation exelManip = new Excel_Manipulation();
            parametros = exelManip.Leer(ruta + "Parametros\\Contabilidad PRMT.xlsx", 1);
            exelManip.ReleaseExcel();
        }

        private object[] CBX_SetItems(string CBXValor, int filtro, int columna)
        {

            object[] itemCBX = new object[parametros.GetUpperBound(0)];
            int items = 0;

            for (int fila = 2; fila < parametros.GetUpperBound(0); fila++)
            {
                if (parametros[fila, columna] == null)
                {
                    break;
                }
                if (parametros[fila, columna].ToString() != parametros[fila - 1, columna].ToString() && parametros[fila, filtro].ToString() == CBXValor)
                {
                    itemCBX[items] = parametros[fila, columna].ToString();
                    items++;
                }
            }
            Array.Resize(ref itemCBX, items);

            return itemCBX;
        }

        private object[] Set_Parametros(object[,] prmt, int columna)
        {
            object[] itemCBX = new object[prmt.Length];
            int items = 0;

            for (int fila = 2; fila < prmt.GetUpperBound(0); fila++)
            {
                if (prmt[fila, columna] == null)
                {
                    break;
                }
                if (prmt[fila, columna].ToString() != prmt[fila - 1, columna].ToString())
                {
                    itemCBX[items] = prmt[fila, columna].ToString();
                    items++;
                }
            }
            Array.Resize(ref itemCBX, items);

            return itemCBX;
        }

        private void CBX_SetItems(object[,] prmt)
        {
            cuentaCBX.Items.Clear();
            tipoMovCBX.Items.Clear();
            categoriaCBX.Items.Clear();
            movimientoCBX.Items.Clear();
            formaPagoCBX.Items.Clear();
            

            cuentaCBX.Items.AddRange(Set_Parametros(prmt, 2));
            tipoMovCBX.Items.AddRange(Set_Parametros(prmt, 3));
            categoriaCBX.Items.AddRange(Set_Parametros(prmt, 4));
            movimientoCBX.Items.AddRange(Set_Parametros(prmt, 5));
            formaPagoCBX.Items.AddRange(Set_Parametros(prmt, 9));

        }

        //---------------------------------------------- RELACION ENTRE PARAMETROS -------------------------------------------------


        private void movimientoCBX_SelectedIndexChanged(object sender, EventArgs e)
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


        private void cuentaCBX_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void SalirBTN_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GuardarBTN_Click(object sender, EventArgs e)
        {
            object[] datosFormulario = ValidarFormulario();

            if (datosFormulario == null)
            {
                MessageBox.Show("Corrija los campo con errores");
                return;
            }

            bool archivoModificado = false;

            Excel_Manipulation excel_Manipulation = new Excel_Manipulation();

            archivoModificado = excel_Manipulation.IngresarContacto(ruta + "Bases de Datos\\BBDD - Contactos.xlsx", 1, datosFormulario);

            if (archivoModificado)
            {

                MessageBox.Show("Contacto guardado");
                this.Close();
            }
        }

        /*  Validación  */

        private void CuitTBX_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '-')
            {
                e.Handled = true;
            }
        }

        private void LocalidadTBX_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void CalleTBX_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void PisoTBX_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void NumeroTBX_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void Telefono1TBX_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void Telefono2TBX_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void Contacto1TBX_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void Contacto2TBX_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        
        private object[] ValidarFormulario()
        {

            bool formularioValido = true;
            object[] nuevoIngreso = new object[23];
            HorariosTBX.Text = "'" + HorariosTBX.Text;

            nuevoIngreso[0] = tipoContacto;
            nuevoIngreso[1] = NombreTBX;
            nuevoIngreso[2] = razonSocialTBX;
            nuevoIngreso[3] = CuitTBX;
            nuevoIngreso[4] = condicionIVACBX;

            nuevoIngreso[5] = cuentaCBX;
            nuevoIngreso[6] = tipoMovCBX;
            nuevoIngreso[7] = categoriaCBX;
            nuevoIngreso[8] = movimientoCBX;

            nuevoIngreso[9] =  HorariosTBX;
            nuevoIngreso[10] = formaPagoCBX;
            nuevoIngreso[11] = LocalidadTBX;
            nuevoIngreso[12] = CalleTBX;
            nuevoIngreso[13] = NumeroTBX;
            nuevoIngreso[14] = PisoTBX;
            nuevoIngreso[15] = DepartamentoTBX;

            nuevoIngreso[16] = Mail1TBX;
            nuevoIngreso[17] = Mail2TBX;
            nuevoIngreso[18] = Telefono1TBX;
            nuevoIngreso[19] = Contacto1TBX;
            nuevoIngreso[20] = Telefono2TBX;
            nuevoIngreso[21] = Contacto2TBX;
            nuevoIngreso[22] = ObservacionesTBX;

            for (int items = 1; items < nuevoIngreso.Length; items++)
            {
                Control controlActual = (Control)nuevoIngreso[items];
                
                if (controlActual.Text == "" && ((tipoContacto == "Banco" && (items == 5 || items == 6)) || (tipoContacto == "Proveedor" && items <= 8) || (tipoContacto == "Cliente" && items <= 10)))
                {
                    errorProvider1.SetError(controlActual, "Campo Obligatorio");
                    errorProvider1.SetIconPadding(controlActual, 5);
                    formularioValido = false;
                }
                else
                {
                    errorProvider1.SetError(controlActual, string.Empty);
                }
                nuevoIngreso[items] = controlActual.Text;
            }

            if ((CuitTBX.Text.Length == 11 || CuitTBX.Text.Length == 8)||tipoContacto == "Banco")
            {
                errorProvider1.SetError(CuitTBX, string.Empty);
            }
            else
            {
                errorProvider1.SetError(CuitTBX, "Completar Campo");
                errorProvider1.SetIconPadding(CuitTBX, 5);
                formularioValido = false;
            }
            
            if (Mail1TBX.Text != "" && (!Mail1TBX.Text.Contains("@") || !Mail1TBX.Text.Contains(".")))
            {
                errorProvider1.SetError(Mail1TBX, "Completar Campo");
                errorProvider1.SetIconPadding(Mail1TBX, 5);
                formularioValido = false;
            }
            else
            {
                errorProvider1.SetError(Mail1TBX, string.Empty);
            }

            if (Mail2TBX.Text != "" && (!Mail2TBX.Text.Contains("@") || !Mail2TBX.Text.Contains(".")))
            {
                errorProvider1.SetError(Mail2TBX, "Completar Campo");
                errorProvider1.SetIconPadding(Mail2TBX, 5);
                formularioValido = false;
            }
            else
            {
                errorProvider1.SetError(Mail2TBX, string.Empty);
            }

            if (Telefono1TBX.Text.Length < 10 && Telefono1TBX.Text != "")
            {
                errorProvider1.SetError(Telefono1TBX, "Completar Campo");
                errorProvider1.SetIconPadding(Telefono1TBX, 5);
                formularioValido = false;
            }
            else
            {
                errorProvider1.SetError(Telefono1TBX, string.Empty);
            }

            if (Telefono2TBX.Text.Length < 10 && Telefono2TBX.Text != "")
            {
                errorProvider1.SetError(Telefono2TBX, "Completar Campo");
                errorProvider1.SetIconPadding(Telefono2TBX, 5);
                formularioValido = false;
            }
            else
            {
                errorProvider1.SetError(Telefono2TBX, string.Empty);
            }

            if (formularioValido)
            {
                return nuevoIngreso;
            }
            else
            {
                return null;
            }
                
        }

        private void CuitTBX_TextChanged(object sender, EventArgs e)
        {

        }

        private void NuevoContacto_Closed(object sender, FormClosedEventArgs e)
        {
            BuscarContacto buscarContacto = new BuscarContacto(menuInicio);
            buscarContacto.Show();
        }
    }
}
