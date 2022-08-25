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
    public partial class MenuInicio : Form
    {
        public MenuInicio()
        {
            InitializeComponent();
            VentasBTN.BackgroundImageLayout = ImageLayout.Stretch;
            
        }

        private void VentasBTN_Click(object sender, EventArgs e)
        {
            
        }

        private void ContabilidadBTN_Click(object sender, EventArgs e)
        {
            //Contabilidad ModuloContable = new Contabilidad();
            //ModuloContable.Show();
            this.Hide();
        }

        private void SalirBTN_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void CerrarModulo(Form modulo)
        {
            modulo.Close();
            this.Show();
        }

    }
}
