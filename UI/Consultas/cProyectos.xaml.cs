using Alvin_P2_API.BLL;
using Alvin_P2_API.Entidades;
using System.Collections.Generic;
using System.Windows;

namespace Alvin_P2_API.UI.Consultas
{
    public partial class cProyectos : Window
    {
        public cProyectos()
        {
            InitializeComponent();
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Proyectos>();
            listado = ProyectosBLL.GetList(c => true);
            DatosDataGrid.ItemsSource = null;
            DatosDataGrid.ItemsSource = listado;
        }
    }
}
