using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS2AProject.Models
{
    public class IncasareModel: BaseModel
    {
        private Int32 _idIncasare;
        private Int32 _idClient;
        private String _tipExcursie;
        private Int32 _idExcursie;
        private Byte _adulti;
        private Byte _copii;
        private Double _valoareTotala;
        private Double _valoareIncasata;
        private Byte _reducere;
        private DateTime _dataIncasarii;
        private String _status;

        public IncasareModel(int idIncasare, int idClient, string tipExcursie, int idExcursie, byte adulti, byte copii, double valoareTotala, double valoareIncasata, byte reducere, DateTime dataIncasarii, string status)
        {
            _idIncasare = idIncasare;
            _idClient = idClient;
            _tipExcursie = tipExcursie;
            _idExcursie = idExcursie;
            _adulti = adulti;
            _copii = copii;
            _valoareTotala = valoareTotala;
            _valoareIncasata = valoareIncasata;
            _reducere = reducere;
            _dataIncasarii = dataIncasarii;
            _status = status;
        }

        public Int32 IdIncasare
        {
            get => _idIncasare;
            set
            {
                _idIncasare = value;
                OnPropertyChanged();
            }
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

        public String TipExcursie
        {
            get => _tipExcursie;
            set
            {
                _tipExcursie = value;
                OnPropertyChanged();
            }
        }

        public Int32 IdExcursie
        {
            get=> _idExcursie;
            set
            {
                _idExcursie = value;
                OnPropertyChanged();
            }
        }

        public Byte Adulti
        {
            get=> _adulti;
            set
            {
                _adulti = value;
                OnPropertyChanged();
            }
        }

        public Byte Copii
        {
            get=> _copii;
            set
            {
                _copii = value;
                OnPropertyChanged();
            }
        }

        public Byte Reducere
        {
            get=> _reducere;
            set
            {
                _reducere = value;
                OnPropertyChanged();
            }
        }

        public Double ValoareTotala
        {
            get => _valoareTotala;
            set
            {
                _valoareTotala = value;
                OnPropertyChanged();
            }
        }

        public Double ValoareIncasata
        {
            get => _valoareIncasata;
            set
            {
                _valoareIncasata = value;
                OnPropertyChanged();
            }
        }

        public DateTime DataIncasarii
        {
            get => _dataIncasarii;
            set
            {
                _dataIncasarii = value;
                OnPropertyChanged();
            }
        }

        public String Status
        {
            get => _status;
            set
            {
                _status = value;
                OnPropertyChanged();
            }
        }

        public Byte NrPersoane => Convert.ToByte(Adulti + Copii);
    }
}
