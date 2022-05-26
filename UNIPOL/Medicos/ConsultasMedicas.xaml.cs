﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using UNIPOL.General;

namespace UNIPOL.Medicos
{
    /// <summary>
    /// Lógica de interacción para ConsultasMedicas.xaml
    /// </summary>
    public partial class ConsultasMedicas : Window
    {
        //List<ArticulosReceta> lstArticulos = null;

        ConsultasMedicasVM _vm = null;
        public ConsultasMedicas()
        {
            _vm = new ConsultasMedicasVM();
            InitializeComponent();
            this.DataContext = _vm;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {


            
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            _vm.AgregarMedicamento();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Guardar");
        }

        private void btnBuscarPaciente_Click(object sender, RoutedEventArgs e)
        {
            Buscador buscador = new Buscador(1);
            buscador.Owner = this;
            buscador.ShowDialog();
        }

        private void btnBuscarMedicamento_Click(object sender, RoutedEventArgs e)
        {
            Buscador buscador = new Buscador(2);
            buscador.Owner = this;
            buscador.ShowDialog();
        }

        private void dgMedicamentos_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            MessageBox.Show("Articulo seleccionado");
        }
    }
}
