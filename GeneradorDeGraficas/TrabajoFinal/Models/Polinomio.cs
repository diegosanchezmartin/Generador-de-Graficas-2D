using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabajoFinal.Models
{
    public class Polinomio
    {
        private int _grado;

        public int grado
        {
            get { return _grado; }
            set { _grado = value; }
        }

        private int _tercerCoef;

        public int tercerCoef
        {
            get { return _tercerCoef; }
            set { _tercerCoef = value; }
        }

        private int _segundoCoef;

        public int segundoCoef
        {
            get { return _segundoCoef; }
            set { _segundoCoef = value; }
        }

        private int _primerCoef;

        public int primerCoef
        {
            get { return _primerCoef; }
            set { _primerCoef = value; }
        }

        private int _coef;

        public int coef
        {
            get { return _coef; }
            set { _coef = value; }
        }

        public Polinomio(int gradPoli)
        {
            grado = gradPoli;
        }

        public Polinomio(int gradPoli, int tercCoef, int segCoef, int priCoef, int coe)
        {
            grado = gradPoli;
            tercerCoef = tercCoef;
            segundoCoef = segCoef;
            coef = coe;
        }


    }
}
