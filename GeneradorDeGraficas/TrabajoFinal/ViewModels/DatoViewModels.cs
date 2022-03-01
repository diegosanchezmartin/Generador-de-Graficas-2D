using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabajoFinal.Models;

namespace TrabajoFinal.ViewModels
{
    public class DatoViewModels
    {
        public ObservableCollection<Dato> coleccionDatosPrograma { get; set; }
        public ObservableCollection<Dato> coleccionDatosGeneracionAutomatica { get; set; } 

        public DatoViewModels()
        {
            coleccionDatosPrograma = new ObservableCollection<Dato>();
            coleccionDatosGeneracionAutomatica = new ObservableCollection<Dato>();
        }
    }
}
