using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
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
//using TrabajoFinal.ViewModels;


namespace TrabajoFinal
{
    /// <summary>
    /// Lógica de interacción para Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        Polyline linea;
        Polyline polilineaNueva, polilineaNueva2; //Borrado de la gráfica de puntos
        Polyline barrasNueva; //Borrado de la gráfica de barras
        Point primerPuntoPurgado = new Point();
        Point ultimoPuntoPurgado = new Point();
        Line ejeX, ejeY;
        String tipoGrafica;
        ObservableCollection<Dato> datosGrafica = new ObservableCollection<Dato>();
        Polinomio poliGraf = null;


        public Window1(ObservableCollection<Dato> datos, String grafica) //manual
        {
            InitializeComponent();
            datosGrafica = datos;
            tipoGrafica = grafica;
            linea = new Polyline();
            panelCanvas.Children.Add(linea);
            ejeX = new Line();
            ejeX.Stroke = Brushes.Black;
            ejeX.StrokeThickness = 2;
            panelCanvas.Children.Add(ejeX);
            ejeY = new Line();
            ejeY.Stroke = Brushes.Black;
            ejeY.StrokeThickness = 2; 
            panelCanvas.Children.Add(ejeY);
        }

        public Window1(ObservableCollection<Dato> datos, Polinomio poli, String grafica) //automatico
        {
            InitializeComponent();
            datosGrafica = datos;
            poliGraf = poli;
            tipoGrafica = grafica;
            linea = new Polyline();
            panelCanvas.Children.Add(linea);
            ejeX = new Line();
            ejeX.Stroke = Brushes.Black;
            ejeX.StrokeThickness = 2;
            panelCanvas.Children.Add(ejeX);
            ejeY = new Line();
            ejeY.Stroke = Brushes.Black;
            ejeY.StrokeThickness = 2;
            panelCanvas.Children.Add(ejeY);

        }

        private void cargarVentana(object sender, RoutedEventArgs e)
        {
            if (tipoGrafica.Equals("graficoPuntos"))
            {
                iniciarEjes();
            }
            if (tipoGrafica.Equals("graficoBarras"))
            {
                graficoBarras();
            }
            
        }

        private void cambiarTamañoVentana(object sender, SizeChangedEventArgs e)
        {
            if (tipoGrafica.Equals("graficoPuntos"))
            {
                iniciarEjes();
            }
            if (tipoGrafica.Equals("graficoBarras"))
            {
                graficoBarras();
            }
            
        }

        private void graficoBarras()
        {
            int numPuntos = (int)panelCanvas.ActualWidth;
            double xreal, yreal, xrealmax, yrealmin, yrealmax, xrealmin;
            double xpant, ypant, xpantmax, ypantmax, ypantmin, xpantmin;

            linea.Stroke = Brushes.Black;
            linea.StrokeThickness = 2;

            xrealmax = 10;
            xrealmin = -10;
            yrealmax = 20;
            yrealmin = -10;

            xpantmax = panelCanvas.ActualWidth;
            xpantmin = 0;
            ypantmax = panelCanvas.ActualHeight;
            ypantmin = 0;

            linea.Points.Clear();

            if (poliGraf == null)
            {

                for (int i = 0; i < datosGrafica.Count; i++)
                {

                    xreal = datosGrafica[i].coordenadaX;
                    yreal = 0;

                    xpant = (xpantmax - xpantmin) * (xreal - xrealmin) / (xrealmax - xrealmin) + xpantmin;
                    ypant = (ypantmin - ypantmax) * (yreal - yrealmin) / (yrealmax - yrealmin) + ypantmax;

                    Point pt0 = new Point(xpant, ypant);
                    linea.Points.Add(pt0);

                    xreal = datosGrafica[i].coordenadaX;
                    yreal = datosGrafica[i].coordenadaY;

                    xpant = (xpantmax - xpantmin) * (xreal - xrealmin) / (xrealmax - xrealmin) + xpantmin;
                    ypant = (ypantmin - ypantmax) * (yreal - yrealmin) / (yrealmax - yrealmin) + ypantmax;

                    Point pt = new Point(xpant, ypant);
                    linea.Points.Add(pt);

                    xreal = datosGrafica[i].coordenadaX;
                    yreal = 0;

                    xpant = (xpantmax - xpantmin) * (xreal - xrealmin) / (xrealmax - xrealmin) + xpantmin;
                    ypant = (ypantmin - ypantmax) * (yreal - yrealmin) / (yrealmax - yrealmin) + ypantmax;

                    Point pt02 = new Point(xpant, ypant);
                    linea.Points.Add(pt02);

                }

            }
            else {
                for (int i = 0; i < datosGrafica.Count; i++)
                {

                    xreal = datosGrafica[i].coordenadaX;
                    yreal = 0;

                    xpant = (xpantmax - xpantmin) * (xreal - xrealmin) / (xrealmax - xrealmin) + xpantmin;
                    ypant = (ypantmin - ypantmax) * (yreal - yrealmin) / (yrealmax - yrealmin) + ypantmax;

                    Point pt0 = new Point(xpant, ypant);
                    linea.Points.Add(pt0);

                    xreal = datosGrafica[i].coordenadaX;
                    yreal = datosGrafica[i].coordenadaY;

                    xpant = (xpantmax - xpantmin) * (xreal - xrealmin) / (xrealmax - xrealmin) + xpantmin;
                    ypant = (ypantmin - ypantmax) * (yreal - yrealmin) / (yrealmax - yrealmin) + ypantmax;

                    Point pt = new Point(xpant, ypant);
                    linea.Points.Add(pt);

                    xreal = datosGrafica[i].coordenadaX;
                    yreal = 0;

                    xpant = (xpantmax - xpantmin) * (xreal - xrealmin) / (xrealmax - xrealmin) + xpantmin;
                    ypant = (ypantmin - ypantmax) * (yreal - yrealmin) / (yrealmax - yrealmin) + ypantmax;

                    Point pt02 = new Point(xpant, ypant);
                    linea.Points.Add(pt02);

                }
            }

            ejeX.X1 = xpantmin;
            ejeX.Y1 = (ypantmin - ypantmax) * (0 - yrealmin) / (yrealmax - yrealmin) + ypantmax;
            ejeX.X2 = xpantmax;
            ejeX.Y2 = (ypantmin - ypantmax) * (0 - yrealmin) / (yrealmax - yrealmin) + ypantmax;

            ejeY.X1 = (xpantmax - xpantmin) * (0 - xrealmin) / (xrealmax - xrealmin) + xpantmin; ;
            ejeY.Y1 = ypantmin;
            ejeY.X2 = (xpantmax - xpantmin) * (0 - xrealmin) / (xrealmax - xrealmin) + xpantmin;
            ejeY.Y2 = ypantmax;
        }

        private void panelPrincipal_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            primerPuntoPurgado.X = e.GetPosition(panelCanvas).X;
            primerPuntoPurgado.Y = e.GetPosition(panelCanvas).Y;
        }

        private void panelPrincipal_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ultimoPuntoPurgado.X = e.GetPosition(panelCanvas).X;
            ultimoPuntoPurgado.Y = e.GetPosition(panelCanvas).Y;
            if (tipoGrafica.Equals("graficoPuntos"))
            {
                borrarPuntos();
            }
            if (tipoGrafica.Equals("graficoBarras"))
            {
               borrarBarras();
            }
        }

        private void borrarBarras()
        {
            int numPuntos = (int)panelCanvas.ActualWidth;
            barrasNueva = new Polyline();
            double xreal, yreal, xrealmax, yrealmin, yrealmax, xrealmin;
            double xpant, ypant, xpantmax, ypantmax, ypantmin, xpantmin;

            xrealmax = 10;
            xrealmin = -10;
            yrealmax = 20;
            yrealmin = -10;

            xpantmax = panelCanvas.ActualWidth;
            xpantmin = 0;
            ypantmax = panelCanvas.ActualHeight;
            ypantmin = 0;

            double xrealPrimerPunto = xrealmin + primerPuntoPurgado.X * (xrealmax - xrealmin) / numPuntos;
            double yrealPrimerPunto = xrealmin + primerPuntoPurgado.Y * (yrealmax - yrealmin) / numPuntos;
            double xrealUltimoPunto = xrealmin + ultimoPuntoPurgado.X * (xrealmax - xrealmin) / numPuntos;
            double yrealUltimoPunto = xrealmin + ultimoPuntoPurgado.Y * (yrealmax - yrealmin) / numPuntos;

            if (poliGraf == null)
            {

                for (int i = 0; i < datosGrafica.Count; i++)
                {

                    xreal = datosGrafica[i].coordenadaX;

                    if (xreal >= Convert.ToDouble(xrealPrimerPunto) && xreal <= Convert.ToDouble(xrealUltimoPunto))
                    {
                        yreal = 0;

                        xpant = (xpantmax - xpantmin) * (xreal - xrealmin) / (xrealmax - xrealmin) + xpantmin;
                        ypant = (ypantmin - ypantmax) * (yreal - yrealmin) / (yrealmax - yrealmin) + ypantmax;

                        Point pt0 = new Point(xpant, ypant);
                        barrasNueva.Points.Add(pt0);

                        xreal = datosGrafica[i].coordenadaX;
                        yreal = datosGrafica[i].coordenadaY;

                        xpant = (xpantmax - xpantmin) * (xreal - xrealmin) / (xrealmax - xrealmin) + xpantmin;
                        ypant = (ypantmin - ypantmax) * (yreal - yrealmin) / (yrealmax - yrealmin) + ypantmax;

                        Point pt = new Point(xpant, ypant);
                        barrasNueva.Points.Add(pt);

                        xreal = datosGrafica[i].coordenadaX;
                        yreal = 0;

                        xpant = (xpantmax - xpantmin) * (xreal - xrealmin) / (xrealmax - xrealmin) + xpantmin;
                        ypant = (ypantmin - ypantmax) * (yreal - yrealmin) / (yrealmax - yrealmin) + ypantmax;

                        Point pt02 = new Point(xpant, ypant);
                        barrasNueva.Points.Add(pt02);

                    }

                }

                panelCanvas.Children.Remove(linea);
                barrasNueva.Stroke = Brushes.Black;
                barrasNueva.StrokeThickness = 2;
                panelCanvas.Children.Add(barrasNueva);

            }
            else
            {
                for (int i = 0; i < datosGrafica.Count; i++)
                {
                    
                    xreal = datosGrafica[i].coordenadaX;

                    if (xreal >= Convert.ToDouble(xrealPrimerPunto) && xreal <= Convert.ToDouble(xrealUltimoPunto))
                    {
                        yreal = 0;

                        xpant = (xpantmax - xpantmin) * (xreal - xrealmin) / (xrealmax - xrealmin) + xpantmin;
                        ypant = (ypantmin - ypantmax) * (yreal - yrealmin) / (yrealmax - yrealmin) + ypantmax;

                        Point pt0 = new Point(xpant, ypant);
                        barrasNueva.Points.Add(pt0);

                        xreal = datosGrafica[i].coordenadaX;
                        yreal = datosGrafica[i].coordenadaY;

                        xpant = (xpantmax - xpantmin) * (xreal - xrealmin) / (xrealmax - xrealmin) + xpantmin;
                        ypant = (ypantmin - ypantmax) * (yreal - yrealmin) / (yrealmax - yrealmin) + ypantmax;

                        Point pt = new Point(xpant, ypant);
                        barrasNueva.Points.Add(pt);

                        xreal = datosGrafica[i].coordenadaX;
                        yreal = 0;

                        xpant = (xpantmax - xpantmin) * (xreal - xrealmin) / (xrealmax - xrealmin) + xpantmin;
                        ypant = (ypantmin - ypantmax) * (yreal - yrealmin) / (yrealmax - yrealmin) + ypantmax;

                        Point pt02 = new Point(xpant, ypant);
                        barrasNueva.Points.Add(pt02);

                    }

                }

                panelCanvas.Children.Remove(linea);
                barrasNueva.Stroke = Brushes.Black;
                barrasNueva.StrokeThickness = 2;
                panelCanvas.Children.Add(barrasNueva);

            }

            ejeX.X1 = xpantmin;
            ejeX.Y1 = (ypantmin - ypantmax) * (0 - yrealmin) / (yrealmax - yrealmin) + ypantmax;
            ejeX.X2 = xpantmax;
            ejeX.Y2 = (ypantmin - ypantmax) * (0 - yrealmin) / (yrealmax - yrealmin) + ypantmax;

            ejeY.X1 = (xpantmax - xpantmin) * (0 - xrealmin) / (xrealmax - xrealmin) + xpantmin; ;
            ejeY.Y1 = ypantmin;
            ejeY.X2 = (xpantmax - xpantmin) * (0 - xrealmin) / (xrealmax - xrealmin) + xpantmin;
            ejeY.Y2 = ypantmax;
        }

        private void borrarPuntos()
        {
            int numPuntos = (int)panelCanvas.ActualWidth;
            polilineaNueva = new Polyline();
            polilineaNueva2 = new Polyline();
            double xreal, yreal, xrealmax, yrealmin, yrealmax, xrealmin;
            double xpant, ypant, xpantmax, ypantmax, ypantmin, xpantmin;

            xrealmax = 10;
            xrealmin = -10;
            yrealmax = 20;
            yrealmin = -10;

            xpantmax = panelCanvas.ActualWidth;
            xpantmin = 0;
            ypantmax = panelCanvas.ActualHeight;
            ypantmin = 0;

            double xrealPrimerPunto = xrealmin + primerPuntoPurgado.X * (xrealmax - xrealmin) / numPuntos;
            double yrealPrimerPunto = xrealmin + primerPuntoPurgado.Y * (yrealmax - yrealmin) / numPuntos;
            double xrealUltimoPunto = xrealmin + ultimoPuntoPurgado.X * (xrealmax - xrealmin) / numPuntos; 
            double yrealUltimoPunto = xrealmin + ultimoPuntoPurgado.Y * (yrealmax - yrealmin) / numPuntos;

            if (poliGraf == null)
            {

                for (int i = 0; i < datosGrafica.Count; i++)
                {
                    xreal = datosGrafica[i].coordenadaX;
                    yreal = datosGrafica[i].coordenadaY;

                    if (xreal > Convert.ToDouble(datosGrafica.First().coordenadaX) && xreal < Convert.ToDouble(datosGrafica.Last().coordenadaX))
                    {

                        xpant = (xpantmax - xpantmin) * (xreal - xrealmin) / (xrealmax - xrealmin) + xpantmin;
                        ypant = (ypantmin - ypantmax) * (yreal - yrealmin) / (yrealmax - yrealmin) + ypantmax;

                        Point pt = new Point(xpant, ypant);
                        polilineaNueva.Points.Add(pt);

                    }
                }

                panelCanvas.Children.Remove(linea);
                polilineaNueva.Stroke = Brushes.Red;
                polilineaNueva.StrokeThickness = 3;
                panelCanvas.Children.Add(polilineaNueva);
                polilineaNueva2.Stroke = Brushes.Red;
                polilineaNueva2.StrokeThickness = 3;
                panelCanvas.Children.Add(polilineaNueva2);

            }
            else
            {
                for (int i = 0; i < numPuntos; i++)
                {
                    xreal = xrealmin + i * (xrealmax - xrealmin) / numPuntos;

                    
                    if (xreal > Convert.ToDouble(datosGrafica.First().coordenadaX) && xreal < Convert.ToDouble(datosGrafica.Last().coordenadaX))
                    {
                        if (xreal > Convert.ToDouble(xrealPrimerPunto) && xreal < Convert.ToDouble(xrealUltimoPunto)) //Primer trozo de la polilinea
                        {
                            yreal = (poliGraf.primerCoef * xreal) + poliGraf.coef;

                            if (poliGraf.grado == 3)
                            {
                                yreal = yreal + poliGraf.tercerCoef * (xreal * xreal * xreal);
                            }
                            if (poliGraf.grado >= 2)
                            {
                                yreal = yreal + poliGraf.segundoCoef * (xreal * xreal);
                            }

                            
                             xpant = (xpantmax - xpantmin) * (xreal - xrealmin) / (xrealmax - xrealmin) + xpantmin;
                             ypant = (ypantmin - ypantmax) * (yreal - yrealmin) / (yrealmax - yrealmin) + ypantmax;

                             Point pt = new Point(xpant, ypant);
                             polilineaNueva.Points.Add(pt);
                            

                        }
                        if (xreal > Convert.ToDouble(xrealPrimerPunto) && xreal < Convert.ToDouble(xrealUltimoPunto)) //Último trozo de la polilinea
                        {
                            yreal = (poliGraf.primerCoef * xreal) + poliGraf.coef;

                            if (poliGraf.grado == 3)
                            {
                                yreal = yreal + poliGraf.tercerCoef * (xreal * xreal * xreal);
                            }
                            if (poliGraf.grado >= 2)
                            {
                                yreal = yreal + poliGraf.segundoCoef * (xreal * xreal);
                            }

                            
                             xpant = (xpantmax - xpantmin) * (xreal - xrealmin) / (xrealmax - xrealmin) + xpantmin;
                             ypant = (ypantmin - ypantmax) * (yreal - yrealmin) / (yrealmax - yrealmin) + ypantmax;

                             Point pt = new Point(xpant, ypant);
                             polilineaNueva2.Points.Add(pt);
                            
                        }
                    }
                }

                panelCanvas.Children.Remove(linea);
                polilineaNueva.Stroke = Brushes.Red;
                polilineaNueva.StrokeThickness = 3;
                panelCanvas.Children.Add(polilineaNueva);
                polilineaNueva2.Stroke = Brushes.Red;
                polilineaNueva2.StrokeThickness = 3;
                panelCanvas.Children.Add(polilineaNueva2);

            }

            ejeX.X1 = xpantmin;
            ejeX.Y1 = (ypantmin - ypantmax) * (0 - yrealmin) / (yrealmax - yrealmin) + ypantmax;
            ejeX.X2 = xpantmax;
            ejeX.Y2 = (ypantmin - ypantmax) * (0 - yrealmin) / (yrealmax - yrealmin) + ypantmax;

            ejeY.X1 = (xpantmax - xpantmin) * (0 - xrealmin) / (xrealmax - xrealmin) + xpantmin; 
            ejeY.Y1 = ypantmin;
            ejeY.X2 = (xpantmax - xpantmin) * (0 - xrealmin) / (xrealmax - xrealmin) + xpantmin;
            ejeY.Y2 = ypantmax;
        }
    

        private void iniciarEjes()
        {
            int numPuntos = (int)panelCanvas.ActualWidth;
            double xreal, yreal, xrealmax, yrealmin, yrealmax, xrealmin;
            double xpant, ypant, xpantmax, ypantmax, ypantmin, xpantmin;

            linea.Stroke = Brushes.Red;
            linea.StrokeThickness = 3;

            xrealmax = 10;
            xrealmin = -10;
            yrealmax = 20;
            yrealmin = -10;

            xpantmax = panelCanvas.ActualWidth;
            xpantmin = 0;
            ypantmax = panelCanvas.ActualHeight;
            ypantmin = 0;

            linea.Points.Clear();

            if(poliGraf == null)
            {

                for (int i = 0; i < datosGrafica.Count; i++)
                {
                    xreal = datosGrafica[i].coordenadaX;
                    yreal = datosGrafica[i].coordenadaY;

                    xpant = (xpantmax - xpantmin) * (xreal - xrealmin) / (xrealmax - xrealmin) + xpantmin;
                    ypant = (ypantmin - ypantmax) * (yreal - yrealmin) / (yrealmax - yrealmin) + ypantmax;

                    Point pt = new Point(xpant, ypant);
                    linea.Points.Add(pt);
                    
                }

            }
            else
            {
                for (int i = 0; i < numPuntos; i++)
                {
                    xreal = xrealmin + i * (xrealmax - xrealmin) / numPuntos;

                    if (xreal > Convert.ToDouble(datosGrafica.First().coordenadaX) && xreal < Convert.ToDouble(datosGrafica.Last().coordenadaX))
                    {

                        yreal = (poliGraf.primerCoef * xreal) + poliGraf.coef;

                        if (poliGraf.grado == 3)
                        {
                            yreal = yreal + poliGraf.tercerCoef * (xreal * xreal * xreal);
                        }
                        if (poliGraf.grado >= 2)
                        {
                            yreal = yreal + poliGraf.segundoCoef * (xreal * xreal);
                        }

                        xpant = (xpantmax - xpantmin) * (xreal - xrealmin) / (xrealmax - xrealmin) + xpantmin;
                        ypant = (ypantmin - ypantmax) * (yreal - yrealmin) / (yrealmax - yrealmin) + ypantmax;

                        Point pt = new Point(xpant, ypant);
                        linea.Points.Add(pt);
                    }
                }
            }

            ejeX.X1 = xpantmin;
            ejeX.Y1 = (ypantmin - ypantmax) * (0 - yrealmin) / (yrealmax - yrealmin) + ypantmax;
            ejeX.X2 = xpantmax;
            ejeX.Y2 = (ypantmin - ypantmax) * (0 - yrealmin) / (yrealmax - yrealmin) + ypantmax;

            ejeY.X1 = (xpantmax - xpantmin) * (0 - xrealmin) / (xrealmax - xrealmin) + xpantmin; ;
            ejeY.Y1 = ypantmin;
            ejeY.X2 = (xpantmax - xpantmin) * (0 - xrealmin) / (xrealmax - xrealmin) + xpantmin;
            ejeY.Y2 = ypantmax;
        }

    }
}
