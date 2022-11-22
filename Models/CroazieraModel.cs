using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS2AProject.Models
{
    public class CroazieraModel : BaseModel
    {
        private Int32 _idCroaziera;
        private String _sezon;
        private String _tara;
        private String _traseu;
        private DateTime _inceputPerioada;
        private DateTime _sfarsitPerioada;
        private String _categorieVas;
        private String _facilitati;
        private String _viziteIncluse;
        private Double _pretTransport;
        private Double _pretCazare;

        public CroazieraModel(int idCroaziera, string sezon, string tara, string traseu, DateTime inceputPerioada, DateTime sfarsitPerioada,
            string categorieVas, string facilitati, string viziteIncluse, double pretTransport, double pretCazare)
        {
            _idCroaziera = idCroaziera;
            _sezon = sezon;
            _tara = tara;
            _traseu = traseu;
            _inceputPerioada = inceputPerioada;
            _sfarsitPerioada = sfarsitPerioada;
            _categorieVas = categorieVas;
            _facilitati = facilitati;
            _viziteIncluse = viziteIncluse;
            _pretTransport = pretTransport;
            _pretCazare = pretCazare;
        }

        public Int32 IdCroaziera
        {
            get => _idCroaziera;
            set
            {
                _idCroaziera = value;
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
            get=> _sfarsitPerioada;
            set
            {
                _sfarsitPerioada = value;
                OnPropertyChanged();
            }
        }

        public String CategorieVas
        {
            get => _categorieVas;
            set
            {
                _categorieVas = value;
                OnPropertyChanged();
            }
        }

        public String Facilitati
        {
            get => _facilitati; 
            set
            {
                _facilitati = value;
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
