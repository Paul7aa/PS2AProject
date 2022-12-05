using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS2AProject.Models
{
    public class CircuitModel:ExcursieModel
    {
        private String _traseu;
        private DateTime _inceputPerioada;
        private DateTime _sfarsitPerioada;
        private Byte _numarNopti;
        private String _facilitatiCazare;
        private String _viziteIncluse;
        private String _mese;

        public CircuitModel(int idCircuit, string sezon, string tara, string traseu, DateTime inceputPerioada, DateTime sfarsitPerioada,
            byte numarNopti, string facilitatiCazare, string viziteIncluse, string mese, double pretTransport, double pretCazare, string rezervat)
        {
            _idExcursie = idCircuit;
            _sezon = sezon;
            _tara = tara;
            _traseu = traseu;
            _inceputPerioada = inceputPerioada;
            _sfarsitPerioada = sfarsitPerioada;
            _numarNopti = numarNopti;
            _facilitatiCazare = facilitatiCazare;
            _viziteIncluse = viziteIncluse;
            _mese = mese;
            _pretTransport = pretTransport;
            _pretCazare = pretCazare;
            _rezervat = rezervat;
        }

        public Int32 IdCircuit
        {
            get => _idExcursie;
            set
            {
                _idExcursie = value;
                OnPropertyChanged();
            }
        }

        public String Sezon
        {
            get => _sezon;
            set
            {
                _sezon= value;
                OnPropertyChanged();
            }
        }

        public String Tara
        {
            get=> _tara;
            set
            {
                _tara = value;
                OnPropertyChanged();
            }
        }

        public String Traseu
        {
            get => _traseu;
            set
            {
                _traseu = value;
                OnPropertyChanged();
            }
        }

        public DateTime InceputPerioada
        {
            get => _inceputPerioada;
            set
            {
                _inceputPerioada = value;
                OnPropertyChanged();
            }
        }

        public DateTime SfarsitPerioada
        {
            get => _sfarsitPerioada;
            set
            {
                _sfarsitPerioada = value;
                OnPropertyChanged();
            }
        }
        
        public Byte NumarNopti
        {
            get => _numarNopti;
            set
            {
                _numarNopti= value;
                OnPropertyChanged();
            }
        }

        public String FacilitatiCazare
        {
            get => _facilitatiCazare;
            set
            {
                _facilitatiCazare = value;
                OnPropertyChanged();
            }
        }

        public String ViziteIncluse
        {
            get => _viziteIncluse;
            set
            {
                _viziteIncluse = value;
                OnPropertyChanged();
            }
        }
        
        public String Mese
        {
            get => _mese; 
            set
            {
                _mese = value;
                OnPropertyChanged();
            }
        }

        public Double PretTransport
        {
            get => _pretTransport;
            set
            {
                _pretTransport = value;
                OnPropertyChanged();
            }
        }

        public Double PretCazare
        {
            get => _pretCazare;
            set
            {
                _pretCazare = value;
                OnPropertyChanged();
            }
        }
    }
}
