using Alvin_P2_API.BLL;
using Alvin_P2_API.Entidades;
using System;
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
            string criterio = CriterioTextBox.Text.Trim();

            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0:
                        listado = ProyectosBLL.GetList(p => true);
                        break;
                    case 1:
                        listado = ProyectosBLL.GetList(p => p.Descripcion.ToLower().Contains(criterio.ToLower()));
                        break;
                    case 2:
                        listado = ProyectosBLL.GetList(p => p.ProyectoId == Convert.ToInt32(CriterioTextBox.Text));
                        break;
                }
            }
            else
            {
                listado = ProyectosBLL.GetList(p => true);
            }


            DatosDataGrid.ItemsSource = null;
            DatosDataGrid.ItemsSource = listado;
        }
    }
}
