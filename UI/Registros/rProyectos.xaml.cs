using Alvin_P2_API.BLL;
using Alvin_P2_API.Entidades;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
namespace Alvin_P2_API.UI.Registros
{
    public partial class rProyectos : Window
    {
        private Proyectos proyectos = new Proyectos();
        public rProyectos()
        {
            InitializeComponent();
            IniciarCombobox();
            Limpiar();
        }

        private void IniciarCombobox()
        {
            TipoTareaComboBox.ItemsSource = TiposTareasBLL.GetList();
            TipoTareaComboBox.SelectedValuePath = "TareaId";
            TipoTareaComboBox.DisplayMemberPath = "Descripcion";
            Limpiar();
        }
        private void Cargar()
        {
            TiempoTextBox.Clear();
            RequerimentoTextBox.Clear();
            this.DataContext = null;
            this.DataContext = proyectos;
            TiempoTotalTextBox.Text = proyectos.TiempoTotal.ToString();
        }
        private void Limpiar()
        {
            this.proyectos = new Proyectos();
            this.proyectos.Fecha = DateTime.Now;
            this.DataContext = proyectos;
            TiempoTotalTextBox.Clear();
        }
        private bool ValidarAgregar()
        {
            bool esValido = true;
            if (TiempoTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Ingrese el tiempo", "Advertencia",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else if (RequerimentoTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Inserte el requerimenteo", "Advertencia",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (TipoTareaComboBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Seleccione una tarea", "Advertencia",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            return esValido;
        }
        private bool ValidarGuardar()
        {
            bool esValido = true;
            if (DatosDataGrid.Items.Count == 0)
            {
                esValido = false;
                MessageBox.Show("Debe agregar tareas", "Advertencia",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            return esValido;
        }
        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            Proyectos encontrado = ProyectosBLL.Buscar(proyectos.ProyectoId);

            if (encontrado != null)
            {
                proyectos = encontrado;
                Cargar();
            }
            else
            {
                Limpiar();
                MessageBox.Show("No existe en la base de datos", "Mensaje",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            Proyectos existe = ProyectosBLL.Buscar(proyectos.ProyectoId);

            if (existe == null)
            {
                MessageBox.Show("No existe el proyecto en la base de datos", "Mensaje",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            else
            {
                ProyectosBLL.Eliminar(proyectos.ProyectoId);
                MessageBox.Show("Eliminado", "Exito",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                Limpiar();
            }
        }
        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidarGuardar())
                return;
            bool paso = false;

            if (proyectos.ProyectoId == 0)
                paso = ProyectosBLL.Guardar(proyectos);
            else
            {
                if (ExisteEnLaBaseDeDatos())
                {
                    paso = ProyectosBLL.Guardar(proyectos);
                }

                else
                    MessageBox.Show("No existe en la base de datos", "Información");
            }
            if (paso)
            {
                Limpiar();
                MessageBox.Show("Guardado!", "Exito",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("Fallo al guardar", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Error);
        }
        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }
        private bool ExisteEnLaBaseDeDatos()
        {
            Proyectos esValido = ProyectosBLL.Buscar(proyectos.ProyectoId);

            return (esValido != null);
        }
        private void Remover_Click(object sender, RoutedEventArgs e)
        {
            if (DatosDataGrid.Items.Count >= 1 && DatosDataGrid.SelectedIndex <= DatosDataGrid.Items.Count - 1)
            {
                ProyectosDetalle m = (ProyectosDetalle)DatosDataGrid.SelectedValue;
                proyectos.TiempoTotal -= m.Tiempo ;
                proyectos.Detalle.RemoveAt(DatosDataGrid.SelectedIndex);
                Cargar();
            }
        }
        private void Agregar_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidarAgregar())
                return;
            proyectos.TiempoTotal += Convert.ToInt32(TiempoTextBox.Text) ;
           
            proyectos.Detalle.Add(new ProyectosDetalle(proyectos.ProyectoId,
                Convert.ToInt32(TipoTareaComboBox.SelectedValue.ToString()),
                Convert.ToInt32(TiempoTextBox.Text),
                RequerimentoTextBox.Text.ToString()));

            Cargar();
        }

    }
}
