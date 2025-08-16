using System.Windows;

namespace EsercizioTPSIT
{
    public partial class MainWindow : Window
    {
        private string pinCorretto = "1234";
        private int tentativi = 0;
        private double saldo = 1000.00;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (txtPIN.Password == pinCorretto)
            {
                menuPanel.Visibility = Visibility.Visible;
                txtPIN.Visibility = Visibility.Collapsed;
                tentativi = 0;
            }
            else
            {
                tentativi++;
                MessageBox.Show("PIN errato!");
                if (tentativi >= 3)
                {
                    MessageBox.Show("PIN errato 3 volte. Operazione bloccata e inviato SMS.");
                    Close();
                }
            }
        }

        private void BtnPrelievo_Click(object sender, RoutedEventArgs e)
        {
            prelievoPanel.Visibility = Visibility.Visible;
            lblSaldo.Visibility = Visibility.Collapsed;
        }

        private void BtnSaldo_Click(object sender, RoutedEventArgs e)
        {
            lblSaldo.Text = $"Saldo disponibile: {saldo} €";
            lblSaldo.Visibility = Visibility.Visible;
            prelievoPanel.Visibility = Visibility.Collapsed;
        }

        private void BtnConfermaPrelievo_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(txtImporto.Text, out double importo))
            {
                if (importo <= saldo && importo > 0)
                {
                    saldo -= importo;
                    MessageBox.Show($"Prelievo di {importo} € effettuato.");
                    lblSaldo.Text = $"Saldo disponibile: {saldo} €";
                    lblSaldo.Visibility = Visibility.Visible;
                    prelievoPanel.Visibility = Visibility.Collapsed;
                }
                else
                {
                    MessageBox.Show("Importo non valido o saldo insufficiente.");
                }
            }
            else
            {
                MessageBox.Show("Inserire un importo numerico.");
            }
        }
    }
}
