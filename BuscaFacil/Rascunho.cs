
using System;
using System.Windows.Forms;
using System.Timers;

public class MessageBoxWithTimer
{
    private Form messageForm;
    private Label messageLabel;
    private System.Timers.Timer timer;

    public MessageBoxWithTimer(string message, int displayTimeInSeconds)
    {
        // Configuração do Form
        messageForm = new Form();
        messageForm.StartPosition = FormStartPosition.CenterScreen;
        messageForm.Size = new System.Drawing.Size(300, 150);
        messageForm.FormBorderStyle = FormBorderStyle.FixedDialog;
        messageForm.MaximizeBox = false;

        // Configuração do Label
        messageLabel = new Label();
        messageLabel.Text = message;
        messageLabel.Dock = DockStyle.Fill;
        messageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        messageForm.Controls.Add(messageLabel);

        // Configuração do Timer
        timer = new System.Timers.Timer(displayTimeInSeconds * 1000); // Convertendo para milissegundos
        timer.Elapsed += OnTimedEvent;
        timer.AutoReset = false; // Para que o timer dispare apenas uma vez
    }

    public void Show()
    {
        messageForm.Show();
        timer.Start();
    }

    private void OnTimedEvent(Object source, ElapsedEventArgs e)
    {
        // Fechar o Form no Thread do UI
        if (messageForm.InvokeRequired)
        {
            messageForm.Invoke(new Action(() => messageForm.Close()));
        }
        else
        {
            messageForm.Close();
        }
    }
}


---------------------

public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();
    }

    private void ShowMessageButton_Click(object sender, EventArgs e)
    {
        MessageBoxWithTimer messageBox = new MessageBoxWithTimer("Esta é uma mensagem temporária!", 5); // 5 segundos
        messageBox.Show();
    }
}