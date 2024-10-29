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
    public partial class TempMsg : Form
    {
        public TempMsg()
        {
            InitializeComponent();
        }

        public static async void Show(string message, int time)
        {
            // Criação do Form temporáriode forma fixa no centro da tela
            Form tempForm = new Form
            {
                StartPosition = FormStartPosition.CenterScreen,
                Size = new System.Drawing.Size(300, 150),
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false
            };

            // Criação do Label para a mensagem com o parametro passado 
            Label messageLabel = new Label
            {
                Text = message,
                Dock = DockStyle.Fill,
                TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            };

            tempForm.Controls.Add(messageLabel);        // adiçao da label ao form

            //// Criação do Timer
            //Timer timer = new Timer
            //{
            //    Interval = time
            //};

            //timer.Tick += (s, e) =>
            //{
            //    timer.Stop(); // Para o timer
            //    tempForm.Close(); // Fecha o Form
            //};

            //timer.Start(); // Inicia o timer

            //// Exibe o Form
            //tempForm.Show();


            tempForm.Show();
            await Task.Delay(time);
            tempForm.Close();

        }
    }
}
