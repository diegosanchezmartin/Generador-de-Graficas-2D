using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabajoFinal.Models
{
    public class Rango
    {
        private int _desde;

        public int desde
        {
            get { return _desde; }
            set { _desde = value; }
        }

        private int _hasta;

        public int hasta
        {
            get { return _hasta; }
            set { _hasta = value; }
        }
        
        public Rango(int valorDesde, int valorHasta)
        {
            _desde = valorDesde;
            _hasta = valorHasta;
        }

    }
}
