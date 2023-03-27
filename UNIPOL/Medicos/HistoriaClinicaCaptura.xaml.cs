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
using System.Xml.Linq;
using UNIPOL.EN;
using UNIPOL.General;

namespace UNIPOL.Medicos
{
    /// <summary>
    /// Lógica de interacción para HistoriaClinicaCaptura.xaml
    /// </summary>
    public partial class HistoriaClinicaCaptura : Window
    {
        HistoriaClinicaCapturaVM _vm = null;
        public HistoriaClinicaCaptura()
        {
            InitializeComponent();
            _vm = new HistoriaClinicaCapturaVM();
            this.DataContext = _vm;
        }

        private void btnBuscarPaciente_Click(object sender, RoutedEventArgs e)
        {
            Buscador buscador = new Buscador(1);
            buscador.Owner = this;
            buscador.ShowDialog();
            if (buscador.itemBusqueda != null && buscador.itemBusqueda.seleccionado)
            {
                _vm.pacienteCodigo = buscador.itemBusqueda.Codigo;
                _vm.pacienteNombre = buscador.itemBusqueda.Descripcion;
                _vm.ConsultaPaciente();
            }
        }

        #region Globales
        private void btnSiguiente_Click(object sender, RoutedEventArgs e)
        {
            int newIndex = tbHistoria.SelectedIndex + 1;
            if (newIndex >= tbHistoria.Items.Count)
                newIndex = 0;
            tbHistoria.SelectedIndex = newIndex;
            BotonesTab();
        }

        private void btnAnterior_Click(object sender, RoutedEventArgs e)
        {
            int newIndex = tbHistoria.SelectedIndex - 1;
            if (newIndex < 0)
                newIndex = tbHistoria.Items.Count - 1;
            tbHistoria.SelectedIndex = newIndex;
            BotonesTab();
        }
        private void tbHistoria_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BotonesTab();
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(_vm.pacienteCodigo == 0)
                {
                    MessageBox.Show("Favor de seleccionar un paciente");
                    btnBuscarPaciente.Focus();
                    tbHistoria.SelectedIndex = 0;
                    return;
                }

                var historia = new HC();

                var hc = new HistoriaClinica();
                hc.CodPaciente = _vm.pacienteCodigo;
                hc.Modalidad = txtModalidad.Text.Trim();
                hc.IdEstatoCivil = _vm.EstadoCivilSeleccionado != null ? _vm.EstadoCivilSeleccionado.Codigo : 0;
                hc.IdGenero = _vm.GeneroSeleccionado != null ? _vm.GeneroSeleccionado.Codigo : 0;
                hc.SenasParticulares = txtSParticulares.Text.Trim();
                hc.Escolaridad = txtEscolaridad.Text.Trim();
                hc.Originario = txtOriginario.Text.Trim();
                hc.Domicilio = txtDomicilio.Text.Trim();
                hc.Procedencia = txtProcedencia.Text.Trim();
                hc.Trabajo = txtTrabajo.Text.Trim();
                historia.hc = hc;

                var hca = new HistoriaClinicaAntecedentes();
                hca.HeredoFamiliares = txtHeredoFamiliares.Text.Trim();
                hca.PersonalesNoPatologicos = txtPersonalesPatologicos.Text.Trim();
                hca.AntecedentesCronicoDegenerativos = txtCronicoDegenerativos.Text.Trim();
                hca.AntecedentesQuirurgicos = txtQuirurgicos.Text.Trim();
                hca.AntecedentesTraumatologicos = txtTraumatologicos.Text.Trim();
                hca.Transfuciones = txtTransfusiones.Text.Trim();
                hca.Infectocontagiosos = txtInfectocontagiosos.Text.Trim();
                hca.Hospitalizaiones = txtHozpitalizaciones.Text.Trim();
                hca.COVID19 = txtCovid.Text.Trim();
                hca.Menarca = !string.IsNullOrEmpty(txtMenarca.Text.Trim()) ? int.Parse(txtMenarca.Text.Trim()) : 0;
                hca.Embarazo = !string.IsNullOrEmpty(txtEmbarazo.Text.Trim()) ? int.Parse(txtEmbarazo.Text.Trim()) : 0;
                hca.Parto = !string.IsNullOrEmpty(txtParto.Text.Trim()) ? int.Parse(txtParto.Text.Trim()) : 0;
                hca.Cesarea = !string.IsNullOrEmpty(txtCesarea.Text.Trim()) ? int.Parse(txtCesarea.Text.Trim()) : 0;
                hca.Aborto = !string.IsNullOrEmpty(txtAborto.Text.Trim()) ? int.Parse(txtAborto.Text.Trim()) : 0;
                hca.IVSA = !string.IsNullOrEmpty(txtIVSA.Text.Trim()) ? int.Parse(txtIVSA.Text.Trim()) : 0;
                hca.IdMPF = _vm.MPFSeleccionado != null ? _vm.MPFSeleccionado.Codigo : 0;
                hca.UltimoPapanicolaoUltrasonido = txtUltimoPapanicolao.Text.Trim();
                hca.OtraObservacion = txtOtraObservacion.Text.Trim();
                hca.PadecimientoActual = txtPadecimientoActual.Text.Trim();
                historia.hca = hca;

                var hco = new HistoriaClinicaOtros();
                hco.IdInmunizacion = _vm.InmunizacionSeleccionado != null ? _vm.InmunizacionSeleccionado.Codigo : 0;
                hco.Religion = txtReligion.Text.Trim();
                hco.IdGrupoSanguineo = _vm.GrupoSanguineoSeleccionado != null ? _vm.GrupoSanguineoSeleccionado.Codigo : 0;
                hco.IdFactor = _vm.FactorSeleccionado != null ? _vm.FactorSeleccionado.Codigo : 0;
                hco.AlergicoPenicilina = _vm.PenicilinaSeleccionado != null ? (_vm.PenicilinaSeleccionado.Codigo == 1 ? true : false) : false;
                hco.Otros = txtOtros.Text.Trim();
                hco.ETS = _vm.TransmisionSexualSeleccionado != null ? (_vm.TransmisionSexualSeleccionado.Codigo == 1 ? true : false) : false;
                hco.EspecifiqueETS = txtEspecifique.Text.Trim();
                hco.SIDA = _vm.SidaSeleccionado != null ? (_vm.SidaSeleccionado.Codigo == 1 ? true : false) : false;
                hco.Seropositivo = txtSeropositivo.Text.Trim();
                hco.Drogas = _vm.DrogaSeleccionado != null ? (_vm.DrogaSeleccionado.Codigo == 1 ? true : false) : false;
                hco.Cocaina = _vm.CocainaSeleccionado != null ? (_vm.CocainaSeleccionado.Codigo == 1 ? true : false) : false;
                hco.Mariguana = _vm.MariguanaSeleccionado != null ? (_vm.MariguanaSeleccionado.Codigo == 1 ? true : false) : false;
                hco.TiempoConsumo = txtTiempoConsumo.Text.Trim();
                hco.Psicofarmacos = _vm.PsicofarmacosSeleccionado != null ? (_vm.PsicofarmacosSeleccionado.Codigo == 1 ? true : false) : false;
                hco.IngestaAlcohol = _vm.AlcoholSeleccionado!= null ? (_vm.AlcoholSeleccionado.Codigo == 1 ? true : false) : false;
                hco.Tabaquisto = _vm.TabaquismoSeleccionado != null ? (_vm.TabaquismoSeleccionado.Codigo == 1 ? true : false) : false;
                hco.IdCantidadTatuajes = _vm.TatuajeSeleccionado != null ? _vm.TatuajeSeleccionado.Codigo : 0;
                hco.TatuajesDescripcion = txtDescripcion.Text.Trim();
                hco.TatuajesLocalizacion = txtLocalizacion.Text.Trim();
                hco.Deportes = _vm.DeporteSeleccionado != null ? (_vm.DeporteSeleccionado.Codigo == 1 ? true : false) : false;
                hco.DeportesPractica = txtCualPractica.Text.Trim();
                hco.TratamientoPsiquiatrico = _vm.PsiquiatricoSeleccionado != null ? (_vm.PsiquiatricoSeleccionado.Codigo == 1 ? true : false) : false;
                hco.TratamientoPsicologico = _vm.PsicologicoSeleccionado != null ? (_vm.PsicologicoSeleccionado.Codigo == 1 ? true : false) : false;
                historia.hco = hco;

                var hcd = new HistoriaClinicaDetras();
                hcd.InspeccionGeneral = txtInspeccionGeneral.Text.Trim();
                hcd.LenguajeCorporal = txtLenguajeCorporal.Text.Trim();
                hcd.Resp = txtResp.Text.Trim();
                hcd.TA = !string.IsNullOrEmpty(txtTA.Text.Trim()) ? decimal.Parse(txtTA.Text.Trim()) : 0.0m;
                hcd.FR = !string.IsNullOrEmpty(txtFR.Text.Trim()) ? decimal.Parse(txtFR.Text.Trim()) : 0.0m;
                hcd.FC = !string.IsNullOrEmpty(txtFC.Text.Trim()) ? decimal.Parse(txtFC.Text.Trim()) : 0.0m;
                hcd.Peso = !string.IsNullOrEmpty(txtPeso.Text.Trim()) ? decimal.Parse(txtPeso.Text.Trim()) : 0.0m;
                hcd.Estatura = !string.IsNullOrEmpty(txtEstatura.Text.Trim()) ? decimal.Parse(txtEstatura.Text.Trim()) : 0.0m;
                hcd.Craneo = txtCraneo.Text.Trim();
                hcd.Cara = txtCara.Text.Trim();
                hcd.Ojos = txtOjos.Text.Trim();
                hcd.Vision = txtVision.Text.Trim();
                hcd.Nariz = txtNariz.Text.Trim();
                hcd.Oidos = txtOidos.Text.Trim();
                hcd.Boca = txtBoca.Text.Trim();
                hcd.Cuello = txtCuello.Text.Trim();
                hcd.Faringe = txtFaringe.Text.Trim();
                hcd.Torax = txtTorax.Text.Trim();
                hcd.Mamas = txtMamas.Text.Trim();
                hcd.Abdomen = txtAbdomen.Text.Trim();
                hcd.ADigestivo = txtADigestivo.Text.Trim();
                hcd.ARespiratorio = txtARespiratorio.Text.Trim();
                hcd.ACardiovascular = txtACardiovascular.Text.Trim();
                hcd.Genitales = txtGenitales.Text.Trim();
                hcd.SistemaNervioso = txtSistemaNervioso.Text.Trim();
                hcd.MusculoEsqueletico = txtMusculoEsqueletico.Text.Trim();
                hcd.MiembroSuperior = txtMiembroSuperior.Text.Trim();
                hcd.MiembroInferior = txtMiembroInferior.Text.Trim();
                hcd.Pelvis = txtPelvis.Text.Trim();
                hcd.ColumnaVertebral = txtColumnaVertebral.Text.Trim();
                hcd.Pie = txtPie.Text.Trim();
                hcd.Anexos = txtAnexos.Text.Trim();
                hcd.ViajesFrontera = txtViajesFrontera.Text.Trim();
                hcd.Diagnostico = txtDiagnotico.Text.Trim();
                hcd.Observaciones = txtObservaciones.Text.Trim();
                hcd.Resultado = txtResultado.Text.Trim();
                historia.hcd = hcd;


                _vm.guardarHistoriaClinica(historia);
            }
            catch(Exception ex)
            {

            }
        }


        private void BotonesTab()
        {
            switch (tbHistoria.SelectedIndex)
            {
                case 0:
                    btnAnterior.Visibility = Visibility.Collapsed;
                    btnSiguiente.Visibility = Visibility.Visible;
                    btnGuardar.Visibility = Visibility.Collapsed;
                    break;
                case 1:
                    btnAnterior.Visibility = Visibility.Visible;
                    btnSiguiente.Visibility = Visibility.Visible;
                    btnGuardar.Visibility = Visibility.Collapsed;
                    break;
                case 2:
                    btnAnterior.Visibility = Visibility.Visible;
                    btnSiguiente.Visibility = Visibility.Visible;
                    btnGuardar.Visibility = Visibility.Collapsed;
                    break;
                case 3:
                    btnAnterior.Visibility = Visibility.Visible;
                    btnSiguiente.Visibility = Visibility.Collapsed;
                    btnGuardar.Visibility = Visibility.Visible;
                    break;
            }
        }
        public bool ValidaNumero(bool soloEntero, string txtNumero, KeyEventArgs e)
        {
            bool respuesta = true;

            if (e.Key == Key.Right
                || e.Key == Key.Left
                || e.Key == Key.LeftShift
                || e.Key == Key.RightShift
                || e.Key == Key.Back
                || e.Key == Key.Delete
                || (e.Key >= Key.D0 && e.Key <= Key.D9)
                || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9
                || e.Key == Key.Tab
                )
            {
                respuesta = false;
            }
            else if (e.Key == Key.Decimal && !soloEntero)
            {
                if (txtNumero.Contains(".") || txtNumero.Length == 0)
                {
                    respuesta = true;
                }
                else
                {
                    respuesta = false;
                }
            }

            return respuesta;
        }

        #endregion



        #region DatosCadete

        #endregion

        #region Antecedentes
        private void txtMenarca_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = ValidaNumero(true, txtMenarca.Text,e);
        }
        private void txtEmbarazo_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = ValidaNumero(true, txtEmbarazo.Text, e);
        }

        private void txtParto_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = ValidaNumero(true, txtParto.Text, e);
        }

        private void txtCesarea_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = ValidaNumero(true, txtCesarea.Text, e);
        }

        private void txtAborto_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = ValidaNumero(true, txtAborto.Text, e);
        }

        private void txtIVSA_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = ValidaNumero(true, txtIVSA.Text, e);
        }
        #endregion

        #region Otros

        #endregion

        #region Detras

        private void txtTA_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = ValidaNumero(false, txtTA.Text, e);
        }
        private void txtFR_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = ValidaNumero(false, txtFR.Text, e);
        }
        private void txtFC_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = ValidaNumero(false, txtFC.Text, e);
        }
        private void txtPeso_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = ValidaNumero(false, txtPeso.Text, e);
        }
        private void txtPeso_KeyUp(object sender, KeyEventArgs e)
        {
            CalculaIMC();
        }

        private void txtEstatura_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = ValidaNumero(false, txtEstatura.Text, e);
        }
        private void txtEstatura_KeyUp(object sender, KeyEventArgs e)
        {
            CalculaIMC();
        }

        private void CalculaIMC()
        {
            var imc = 0.0;
            var imcInfo = "";
            var color = "#A7A7A7";
            try
            {
                if (!string.IsNullOrEmpty(txtPeso.Text) && !string.IsNullOrEmpty(txtEstatura.Text))
                {
                    var peso = 0.0;
                    var estatura = 0.0;
                  

                    var p = double.TryParse(txtPeso.Text, out peso);
                    if(p)
                    {
                        var e = double.TryParse(txtEstatura.Text, out estatura);
                        if(e)
                        {
                            imc = peso / (estatura * estatura);

                            if (imc < 18.5)
                            {
                                imcInfo = "BAJO PESO";
                                color = "#ffbf00";
                            }
                            else if (imc >= 18.5 && imc <= 24.9)
                            {
                                imcInfo = "ADECUADO";
                                color = "#00af52";
                            }
                            else if (imc >= 25.0 && imc <= 29.9)
                            {
                                imcInfo = "SOBREPESO";
                                color = "#ffc000";
                            }
                            else if (imc >= 30.0 && imc <= 34.9)
                            {
                                imcInfo = "OBESIDAD GRADO 1";
                                color = "#fe9900";
                            }
                            else if (imc >= 35.0 && imc <= 39.9)
                            {
                                imcInfo = "OBESIDAD GRADO 2";
                                color = "#ff3300";
                            }
                            else if(imc >= 40.0 && imc <= 49.9)
                            {
                                imcInfo = "OBESIDAD GRADO 3";
                                color = "#fe0002";
                            }
                            else if (imc >= 50)
                            {
                                imcInfo = "OBESIDAD GRADO 3";
                                color = "#fe0002";
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "UNIPOL", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            lblIMC.Text = imc.ToString("##0.00");
            lblIMCInfo.Text = imcInfo;
            lblIMCInfo.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString(color);
        }













        #endregion


    }
}
