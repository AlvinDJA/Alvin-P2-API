using Alvin_P2_API.UI.Consultas;
using Alvin_P2_API.UI.Registros;
using System.Windows;

namespace Alvin_P2_API
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void rProyectosItem_Click(object sender, RoutedEventArgs e)
        {
            new rProyectos().Show();
        }

        private void cProyectosItem_Click(object sender, RoutedEventArgs e)
        {
            new cProyectos().Show();
        }
    }
}
