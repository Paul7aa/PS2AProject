using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS2AProject.Models
{
    public class ExcursieModel : BaseModel
    {
        public Int32 _idExcursie;
        public String _sezon;
        public String _tara;
        public Double _pretCazare;
        public Double _pretTransport;
        public String _rezervat;

        public Int32 IdExcursie
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

        public Double PretCazare
        {
            get => _pretCazare;
            set
            {
                _pretCazare = value;
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

        public String Rezervat
        {
            get => _rezervat;
            set
            {
                _rezervat = value;
                OnPropertyChanged();
            }
        }

        public Double PretTotal => PretCazare + PretTransport;
    }
}
