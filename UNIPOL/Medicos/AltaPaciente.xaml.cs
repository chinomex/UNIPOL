using System;
using System.Collections.Generic;
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
using UNIPOL.BO;
using UNIPOL.EN;

namespace UNIPOL.Medicos
{
    /// <summary>
    /// Lógica de interacción para AltaPaciente.xaml
    /// </summary>
    public partial class AltaPaciente : Window
    {
        MedicosBO _bo = null;
        CatalogosBO _boCatalogos = null;
        public List<ComboGenerico> lstGenero { get; set; }
        public ComboGenerico GeneroSeleccionado { get; set; }

        public int CodPaciente { get; set; }
        public string NombrePaciente { get; set; }
        public AltaPaciente()
        {
            CodPaciente = 0;
            NombrePaciente = "";
            _bo = new MedicosBO();
            _boCatalogos = new CatalogosBO();
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                txtCodigo.Focus();

                lstGenero = new List<ComboGenerico>();
                var rGenero = _boCatalogos.ConsultaCatGenero();
                if (rGenero.Value)
                {
                    lstGenero = rGenero.Data;
                    cmbSexo.ItemsSource = lstGenero; //rGenero.Data;
                }
                
            }
            catch (Exception ex)
            { 
            
            }
        }
        private void txtCodigo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (!string.IsNullOrEmpty(txtCodigo.Text))
                {
                    var r = _bo.ConsultaPaciente(Convert.ToInt32(txtCodigo.Text));
                    if (r.Value)
                    {
                        if (r.Data.Count > 0)
                        {
                            var d = r.Data[0];
                            txtCodigo.Text = d.CodPaciente.ToString();
                            txtNombre.Text = d.Nombre;
                            var item = lstGenero.Find(x => x.Codigo == d.IdGenero);
                            cmbSexo.SelectedItem = item;
                            txtDomicilio.Text = d.Domicilio;
                            dpFechaNacimiento.SelectedDate = d.FechaNacimiento;
                            txtTelefono.Text = d.Telefono;
                            txtCorreo.Text = d.Correo;
                            txtRFC.Text = d.RFC.ToUpper();
                            txtAlergias.Text = d.Alergias;
                        }
                        else
                        {
                            MessageBox.Show("Paciente no encontrado", "UNIPOL", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show(r.Message, "UNIPOL", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    }
                }

                txtNombre.Focus();
            }
        }

        private void txtCodigo_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9 || e.Key == Key.Enter || e.Key == Key.Back)
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void txtNombre_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                //txtDomicilio.Focus();
                cmbSexo.Focus();
            }
        }

        private void cmbSexo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                txtDomicilio.Focus();
            }
        }
        private void cmbSexo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GeneroSeleccionado = (ComboGenerico)cmbSexo.SelectedItem;
        }

        private void txtDomicilio_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                dpFechaNacimiento.Focus();
            }
        }

        private void dpFechaNacimiento_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                txtTelefono.Focus();
            }
        }

        private void txtTelefono_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                txtCorreo.Focus();
            }
        }

        private void txtCorreo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                txtRFC.Focus();
            }
        }

        private void txtRFC_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                txtAlergias.Focus();
            }
        }

        private void txtAlergias_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                btnGuardar.Focus();
            }
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            CodPaciente = 0;
            NombrePaciente = "";
            this.Close();
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (ValidaGuardar())
            {
                var codPaciente = 0;
                if (!string.IsNullOrEmpty(txtCodigo.Text))
                {
                    codPaciente = Convert.ToInt32(txtCodigo.Text);
                }

                var r = _bo.GuardarPaciente(codPaciente, txtNombre.Text.Trim(), GeneroSeleccionado.Codigo, txtDomicilio.Text.Trim(), dpFechaNacimiento.SelectedDate.Value, txtTelefono.Text.Trim(), txtCorreo.Text.Trim(), txtRFC.Text.Trim().ToUpper(), txtAlergias.Text.Trim());
                if (r.Value)
                {
                    if (r.Data.Count > 0)
                    {
                        txtCodigo.Text = r.Data[0].CodPaciente.ToString();
                        CodPaciente = r.Data[0].CodPaciente;
                        NombrePaciente = r.Data[0].Nombre;
                        MessageBox.Show("Paciente guardado correctamente", "UNIPOL", MessageBoxButton.OK);
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show(r.Message, "UNIPOL", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
            }
        }


        private bool ValidaGuardar()
        {
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                MessageBox.Show("Favor de escribir un nombre", "UNIPOL", MessageBoxButton.OK, MessageBoxImage.Information);
                txtNombre.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtRFC.Text))
            {
                MessageBox.Show("Favor de escribir un RFC valido", "UNIPOL", MessageBoxButton.OK, MessageBoxImage.Information);
                txtRFC.Focus();
                return false;
            }
            if (GeneroSeleccionado == null)
            {
                MessageBox.Show("Favor de seleccionar un sexo", "UNIPOL", MessageBoxButton.OK, MessageBoxImage.Information);
                cmbSexo.Focus();
                return false;
            }


            return true;
        }



        private void Limpiar()
        {
            txtCodigo.Text = "";
            txtNombre.Text = "";
            cmbSexo.SelectedIndex = -1;
            txtDomicilio.Text = "";
            dpFechaNacimiento.SelectedDate = null;
            txtTelefono.Text = "";
            txtCorreo.Text = "";
            txtRFC.Text = "";
            txtAlergias.Text = "";
        }

        private void txtCodigo_GotFocus(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }


    }
}
