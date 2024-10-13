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
    public partial class frmMsgTemp : Form
    {
        public frmMsgTemp()
        {
            InitializeComponent();
        }
        public static  void ShowTimedMessageBox(string message, string title, int timeout)
        {
            Timer timer = new Timer();
            timer.Interval = timeout;  // Define o tempo de exibição em milissegundos
            timer.Tick += (s, e) =>
            {
                timer.Stop();
                timer.Dispose();
                Form activeForm = Form.ActiveForm;
                if (activeForm != null)
                {
                    activeForm.Close();
                }
            };

            MessageBox.Show(message, title);
            timer.Start();
        }
    }
}
