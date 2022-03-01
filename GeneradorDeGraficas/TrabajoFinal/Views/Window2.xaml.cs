using System;
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
using TrabajoFinal.Models;
using TrabajoFinal.ViewModels;

namespace TrabajoFinal
{
    /// <summary>
    /// Lógica de interacción para Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        Polinomio polinom;
        Rango rangoGrafica;
        DatoViewModels vistaModelo = new DatoViewModels();
        bool generacionAuto = false;
        bool introduccionManual = false;

        public Window2()
        {
            InitializeComponent();
            coleccionPuntosPro.ItemsSource = vistaModelo.coleccionDatosPrograma;
            coleccionPuntosGeneracionAutomatica.ItemsSource = vistaModelo.coleccionDatosGeneracionAutomatica;
        }



        private void clickBotonAñadir(object sender, RoutedEventArgs e)
        {

            TextBox cajaCoordX = textCoorX;
            TextBox cajaCoordY = textCoorY;
            Dato datoPrograma;

            datoPrograma = new Dato(int.Parse(cajaCoordX.Text), int.Parse(cajaCoordY.Text));
            if (!vistaModelo.coleccionDatosPrograma.Any(Dato => Dato.coordenadaX == datoPrograma.coordenadaX && Dato.coordenadaY == datoPrograma.coordenadaY)){
                vistaModelo.coleccionDatosPrograma.Add(datoPrograma);
            }
            
        }

        private void clickBotonEliminar(object sender, RoutedEventArgs e)
        {
            if (vistaModelo.coleccionDatosPrograma != null)
            {
                TextBox cajaCoordXEli = textCoorX;
                TextBox cajaCoordYEli = textCoorY;
                Dato datoProgramaEli;

                datoProgramaEli = new Dato(int.Parse(cajaCoordXEli.Text), int.Parse(cajaCoordYEli.Text));

                if (vistaModelo.coleccionDatosPrograma.Any(Dato => Dato.coordenadaX == datoProgramaEli.coordenadaX && Dato.coordenadaY == datoProgramaEli.coordenadaY))
                {
                    vistaModelo.coleccionDatosPrograma.Remove(vistaModelo.coleccionDatosPrograma.Where(Dato => Dato.coordenadaX == datoProgramaEli.coordenadaX && Dato.coordenadaY == datoProgramaEli.coordenadaY).Single());
                }
            }
        }

        private void clickBotonModificar(object sender, RoutedEventArgs e)
        {
            TextBox cajaCoordXMod = textCoorX;
            TextBox cajaCoordYMod = textCoorY;
            TextBox cajaCoordXModNew = textCoorXmodificacion;
            TextBox cajaCoordYModNew = textCoorYmodificacion;
            Dato dato = new Dato(int.Parse(textCoorX.Text), int.Parse(textCoorY.Text));

            for (int i = 0; i < vistaModelo.coleccionDatosPrograma.Count; i++)
            {
                if (dato.coordenadaX == vistaModelo.coleccionDatosPrograma[i].coordenadaX && dato.coordenadaY == vistaModelo.coleccionDatosPrograma[i].coordenadaY)
                {
                    Dato datoAmodificar = vistaModelo.coleccionDatosPrograma[i];
                    datoAmodificar.coordenadaX = int.Parse(textCoorXmodificacion.Text);
                    datoAmodificar.coordenadaY = int.Parse(textCoorYmodificacion.Text);
                }
            }
            
        }

        private void clickBotonModificarAutomatica(object sender, RoutedEventArgs e)
        {
            TextBox cajaCoordXAutomatica = textCoorXAutomatica;
            TextBox cajaCoordYAutomatica = textCoorYAutomatica;
            TextBox cajaCoordXModNew = textCoorXmodificacionAutomatica;
            TextBox cajaCoordYModNew = textCoorYmodificacionAutomatica;
            Dato dato = new Dato(int.Parse(cajaCoordXAutomatica.Text), int.Parse(cajaCoordYAutomatica.Text));

            for (int i = 0; i < vistaModelo.coleccionDatosGeneracionAutomatica.Count; i++)
            {
                if (dato.coordenadaX == vistaModelo.coleccionDatosGeneracionAutomatica[i].coordenadaX && dato.coordenadaY == vistaModelo.coleccionDatosGeneracionAutomatica[i].coordenadaY)
                {
                    Dato datoAmodificar = vistaModelo.coleccionDatosGeneracionAutomatica[i];
                    datoAmodificar.coordenadaX = int.Parse(cajaCoordXModNew.Text);
                    datoAmodificar.coordenadaY = int.Parse(cajaCoordYModNew.Text);
                }
            }

        }

        private void clickBotonGeneracionAutomatica(object sender, RoutedEventArgs e)
        {
            botonGeneracionAutomatica.Visibility = Visibility.Hidden;
            botonIntroduccionManual.Visibility = Visibility.Hidden;
            rangoCoordenadasAutomaticas.Visibility = Visibility.Visible;
            desde.Visibility = Visibility.Visible;
            hasta.Visibility = Visibility.Visible;
            rangoCoordenadasDesde.Visibility = Visibility.Visible;
            rangoCoordenadasHasta.Visibility = Visibility.Visible;
            botonAñadirRango.Visibility = Visibility.Visible;
            introducirGrado.Visibility = Visibility.Visible;
            generarPolinomio.Visibility = Visibility.Visible;
            botonModificarPuntoAutomatica.Visibility = Visibility.Visible;
            verGrafica.Visibility = Visibility.Visible;
            verGraficaBarras.Visibility = Visibility.Visible;
            generacionAuto = true;
        }

        private void clickBotonIntroducionManual(object sender, RoutedEventArgs e)
        {
            botonAñadirPunto.Visibility = Visibility.Visible;
            botonEliminarPunto.Visibility = Visibility.Visible;
            botonModificarPunto.Visibility = Visibility.Visible;
            verGrafica.Visibility = Visibility.Visible;
            verGrafica.IsEnabled = true;
            verGraficaBarras.Visibility = Visibility.Visible;
            verGraficaBarras.IsEnabled = true;
            botonGeneracionAutomatica.Visibility = Visibility.Hidden;
            botonIntroduccionManual.Visibility = Visibility.Hidden;
            introduccionManualTextoX.Visibility = Visibility.Visible;
            introduccionManualTextoY.Visibility = Visibility.Visible;
            introduccionManualNuevoTextoX.Visibility = Visibility.Visible;
            introduccionManualNuevoTextoY.Visibility = Visibility.Visible;
            textCoorXmodificacion.Visibility = Visibility.Visible;
            textCoorYmodificacion.Visibility = Visibility.Visible;
            textCoorX.Visibility = Visibility.Visible;
            textCoorY.Visibility = Visibility.Visible;
            puntosAñadidosIntroduccionManual.Visibility = Visibility.Visible;
            puntosIntroduccionManual.Visibility = Visibility.Visible;
            introduccionManual = true;
        }

        private void clickBotonAñadirRango(object sender, RoutedEventArgs e)
        {
            TextBox cajaRangoMinimo = rangoCoordenadasDesde;
            TextBox cajaRangoMaximo = rangoCoordenadasHasta;

            int desde = int.Parse(cajaRangoMinimo.Text);
            int hasta = int.Parse(cajaRangoMaximo.Text);

            if (desde < hasta)
            {
                botonAñadirRango.IsEnabled = false;
                rangoGrafica = new Rango(desde, hasta);
                introducirGrado.IsEnabled = true;
                gradoDelPolinomio.Visibility = Visibility.Visible;
                gradoPolinomio.Visibility = Visibility.Visible;
            }
        }

        private void clickBotonIntroducirGrado(object sender, RoutedEventArgs e)
        {
            TextBox cajaGrado = gradoDelPolinomio;
            int grado = int.Parse(cajaGrado.Text);

            if(grado<=3 && grado >= 1)
            {
                introducirGrado.IsEnabled = false;
                polinom = new Polinomio(grado);
                generarPolinomio.IsEnabled = true;
                generarPolinomio.Visibility = Visibility.Visible;
                if(grado == 3)
                {
                    grado3.Visibility = Visibility.Visible;
                    tercerGrado.Visibility = Visibility.Visible;
                }
                
                if (grado >= 2)
                {
                    grado2.Visibility = Visibility.Visible;
                    segundoGrado.Visibility = Visibility.Visible;
                } 

                grado1.Visibility = Visibility.Visible;
                primerGrado.Visibility = Visibility.Visible;
                grado0.Visibility = Visibility.Visible;
                sinGrado.Visibility = Visibility.Visible;
                introducirGrado.IsEnabled = false;
            }
        }

        private void clickBotonGenerarPolinomio(object sender, RoutedEventArgs e)
        {
            TextBox tercerG = tercerGrado;
            TextBox segundoG = segundoGrado;
            TextBox primerG = primerGrado;
            TextBox gradoCero = sinGrado;
            int i;

            generarPolinomio.IsEnabled = false;

            for (i = rangoGrafica.desde; i <= rangoGrafica.hasta; i++)
            {
                Dato datoGeneracionAuto;
                int ejeY=0;
                if (polinom.grado == 3)
                {
                    polinom.tercerCoef = int.Parse(tercerG.Text);
                    ejeY = ejeY + int.Parse(tercerG.Text) * (i * i * i);
                }
                if(polinom.grado >= 2)
                {
                    polinom.segundoCoef = int.Parse(segundoG.Text);
                    ejeY = ejeY + int.Parse(segundoG.Text) * (i * i);
                }
                polinom.primerCoef = int.Parse(primerG.Text);
                polinom.coef = int.Parse(gradoCero.Text);
                ejeY = ejeY + (int.Parse(primerG.Text) * i) + int.Parse(gradoCero.Text);

                datoGeneracionAuto = new Dato(i, ejeY);
                if (!vistaModelo.coleccionDatosGeneracionAutomatica.Any(Dato => Dato.coordenadaX == datoGeneracionAuto.coordenadaX && Dato.coordenadaY == datoGeneracionAuto.coordenadaY))
                {
                    vistaModelo.coleccionDatosGeneracionAutomatica.Add(datoGeneracionAuto);
                }

            }

            botonModificarPuntoAutomatica.IsEnabled = true;
            textCoorXmodificacionAutomatica.Visibility = Visibility.Visible;
            textCoorYmodificacionAutomatica.Visibility = Visibility.Visible;
            textCoorYAutomatica.Visibility = Visibility.Visible;
            textCoorXAutomatica.Visibility = Visibility.Visible;
            TextoXAutomatica.Visibility = Visibility.Visible;
            TextoYAutomatica.Visibility = Visibility.Visible;
            NuevoTextoXAutomatica.Visibility = Visibility.Visible;
            NuevoTextoYAutomatica.Visibility = Visibility.Visible;
            puntosGeneracionAutomatica.Visibility = Visibility.Visible;
            puntosAñadidosIntroduccionAutomatica.Visibility = Visibility.Visible;
            verGrafica.IsEnabled = true;
            verGraficaBarras.IsEnabled = true;
            
        }

        private void clickVerGrafica(object sender, RoutedEventArgs e)
        {
            if (generacionAuto == true)
            {
                Window1 ventanaPrincipal = new Window1(vistaModelo.coleccionDatosGeneracionAutomatica, polinom, "graficoPuntos");
                ventanaPrincipal.ShowDialog();
            }
            if (introduccionManual == true)
            {
                Window1 ventanaPrincipal = new Window1(vistaModelo.coleccionDatosPrograma, "graficoPuntos");
                ventanaPrincipal.ShowDialog();
            }
        }

        private void clickVerGraficaBarras(object sender, RoutedEventArgs e)
        {
            if (generacionAuto == true)
            {
                Window1 ventanaPrincipal = new Window1(vistaModelo.coleccionDatosGeneracionAutomatica, polinom, "graficoBarras");
                ventanaPrincipal.ShowDialog();
            }
            if (introduccionManual == true)
            {
                Window1 ventanaPrincipal = new Window1(vistaModelo.coleccionDatosPrograma, "graficoBarras");
                ventanaPrincipal.ShowDialog();
            }
        }
    }
}
