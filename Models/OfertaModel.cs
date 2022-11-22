using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS2AProject.Models
{
    public class OfertaModel : BaseModel
    {
        private Int32 _idOferta;
        private String _tipOferta;
        private String _tipExcursie;
        private Int32 _idExcursie;
        private Byte _reducere;

        public OfertaModel(int idOferta, string tipOferta, string tipExcursie, int idExcursie, byte reducere)
        {
            _idOferta = idOferta;
            _tipOferta = tipOferta;
            _tipExcursie = tipExcursie;
            _idExcursie = idExcursie;
            _reducere = reducere;
        }

        public Int32 IdOferta
        {
            get => _idOferta;
            set
            {
                _idOferta = value;
                OnPropertyChanged();
            }
        }
       
        public String TipOferta
        {
            get => _tipOferta;
            set
            {
                _tipOferta = value;
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
            get => _idExcursie;
            set
            {
                _idExcursie = value;
                OnPropertyChanged();
            }
        }

        public Byte Reducere
        {
            get => _reducere;
            set
            {
                _reducere = value;
                OnPropertyChanged();
            }
        }
    }
}
