using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Timers;
using System.Windows.Forms;


namespace BuscaFacil
{
    public static class MessageBoxWithTimer
    {
        private static Form messageForm;
        private static Label messageLabel;
        private static Timer timer;


        private static void OnTimedEvent(object sender, EventArgs e)
        {
            {
                // Para o timer e fecha o Form
                timer.Stop();
                messageForm.Close();
            }
        }

        public static void Show(string message, int displayTimeInSeconds)
        {
            // Configuração do Form
            messageForm = new Form
            {
                StartPosition = FormStartPosition.CenterScreen,
                Size = new System.Drawing.Size(300, 150),
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false
            };

            // Configuração do Label
            messageLabel = new Label
            {
                Text = message,
                Dock = DockStyle.Fill,
                TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            };
            messageForm.Controls.Add(messageLabel);

            // Configuração do Timer
            timer = new Timer
            {
                Interval = displayTimeInSeconds * 1000 // Convertendo para milissegundos
            };
            //timer.Tick += OnTimedEvent; // Associando o evento Tick
            timer.Tick += OnTimedEvent; // Associando o evento Tick
            timer.Start(); // Inicia o timer

            // Exibe o formulário
            messageForm.Show();

        }

    }
}
