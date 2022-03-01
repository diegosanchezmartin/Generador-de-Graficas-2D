using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace TrabajoFinal.Models
{
    public class Dato : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        private int _coordenadaX;

        public int coordenadaX
        {
            get { return _coordenadaX;  }
            set { _coordenadaX = value;

                OnPropertyChanged("coordenadaX");

            }
        }

        private int _coordenadaY;

        public int coordenadaY
        {
            get { return _coordenadaY; }
            set { _coordenadaY = value;

                OnPropertyChanged("coordenadaY");
            
            }
        }

        public Dato(int coorX, int coorY)
        {
            coordenadaX = coorX;
            coordenadaY = coorY;
        }

    }

}
