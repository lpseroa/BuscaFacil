using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BuscaFacil
{
    public partial class frmResultados : Form
    {
        public frmResultados()
        {
            InitializeComponent();
        }

        public void RtbResultado_TextChanged(object sender, EventArgs e)
        {
            RtbResultado.Show();        // iimagino quye seja o refresh do text box
        }
    }
}
