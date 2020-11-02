using RegistroPedidos.UI.Consultas;
using RegistroPedidos.UI.Registros;
using System.Windows;

namespace Alvin_P2_API
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void rPartidasItem_Click(object sender, RoutedEventArgs e)
        {
            new rPartidas().Show();
        }

        private void cPartidasItem_Click(object sender, RoutedEventArgs e)
        {
            new cPartidas().Show();
        }
    }
}
