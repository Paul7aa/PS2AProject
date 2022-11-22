using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS2AProject.Models
{
    public class ClientModel : BaseModel
    {
        private Int32 _idClient;
        private String _nume;
        private String _prenume;
        private String _cnp;
        private String _adresa;
        private String _nrTelefon;

        public ClientModel(int idClient, string nume, string prenume, string cnp, string adresa, string nrTelefon)
        {
            _idClient = idClient;
            _nume = nume;
            _prenume = prenume;
            _cnp = cnp;
            _adresa = adresa;
            _nrTelefon = nrTelefon;
        }

        public Int32 IdClient
        {
            get => _idClient;
            set
            {
                _idClient = value;
                OnPropertyChanged();
            }
        }

        public String Nume
        {
            get => _nume;
            set
            {
                _nume = value;
                OnPropertyChanged();
            }
        }

        public String Prenume
        {
            get => _prenume;
            set
            {
                _prenume = value;
                OnPropertyChanged();
            }
        }

        public String CNP
        {
            get => _cnp;
            set
            {
                _cnp = value;
                OnPropertyChanged();
            }
        }

        public String Adresa
        {
            get => _adresa;
            set
            {
                _adresa = value;
                OnPropertyChanged();
            }
        }

        public String NrTelefon
        {
            get => _nrTelefon;
            set
            {
                _nrTelefon = value;
                OnPropertyChanged();
            }
        }
    }
}
