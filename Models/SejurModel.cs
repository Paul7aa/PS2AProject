using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS2AProject.Models
{
    public class SejurModel : ExcursieModel
    {
        String _localitate; //50
        DateTime _inceputPerioada;
        DateTime _sfarsitPerioada;
        Byte _numarNopti; 
        String _tipCazare; //50
        String _denumire; //50
        Byte _nrStele; 
        String _mese; //50
        String _faciltati; //100
        String _transport; //50

        public SejurModel(int idSejur, string sezon, string tara, string localitate, DateTime inceputPerioada, DateTime sfarsitPerioada,
                            byte numarNopti, string tipCazare, string denumire, byte nrStele, string mese,
                            string faciltati, string transport, double pretTransport, double pretCazare,
                            string rezervat)
        {
            _idExcursie = idSejur;
            _sezon = sezon;
            _tara = tara;
            _localitate = localitate;
            _inceputPerioada = inceputPerioada;
            _sfarsitPerioada = sfarsitPerioada;
            _numarNopti = numarNopti;
            _tipCazare = tipCazare;
            _denumire = denumire;
            _nrStele = nrStele;
            _mese = mese;
            _faciltati = faciltati;
            _transport = transport;
            _pretTransport = pretTransport;
            _pretCazare = pretCazare;
            _rezervat = rezervat;
        }

        public Int32 IdSejur
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
                _sezon = value;
                OnPropertyChanged();
            }
        }

        public String Tara
        {
            get => _tara; 
            set
            {
                _tara = value;
                OnPropertyChanged();
            }
        }

        public String Localitate
        {
            get => _localitate; 
            set
            {
                _localitate = value;
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
                _numarNopti = value;
                OnPropertyChanged();
            }
        }

        public String TipCazare
        {
            get => _tipCazare;
            set
            {
                _tipCazare = value;
                OnPropertyChanged();
            }
        }

        public String Denumire
        {
            get => _denumire;
            set
            {
                _denumire = value;
                OnPropertyChanged();
            }
        }

        public Byte NrStele
        {
            get => _nrStele;
            set
            {
                _nrStele = value;
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

        public String Facilitati
        {
            get => _faciltati;
            set
            {
                _faciltati = value;
                OnPropertyChanged();
            }
        }

        public String Transport
        {
            get => _transport;
            set
            {
                _transport = value;
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
