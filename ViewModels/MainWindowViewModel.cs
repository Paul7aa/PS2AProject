using PS2AProject.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS2AProject.ViewModels
{
    public partial class MainWindowViewModel : BaseViewModel
    {
        private SqlConnection _sqlConnection;
        private SqlCommand _sqlCommand;
        private String _sqlConnectionString = @"Data Source=DESKTOP-IVVHEO0\SQLEXPRESS;Initial Catalog=AgentieTurism;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        private ObservableCollection<SejurModel> _sejururiList = new ObservableCollection<SejurModel>();
        private ObservableCollection<CroazieraModel> _croaziereList = new ObservableCollection<CroazieraModel>();
        private ObservableCollection<CircuitModel> _circuiteList = new ObservableCollection<CircuitModel>();
        private ObservableCollection<OfertaModel> _oferteList = new ObservableCollection<OfertaModel>();
        private ObservableCollection<IncasareModel> _incasariList = new ObservableCollection<IncasareModel>();
        private ObservableCollection<ClientModel> _clientiList = new ObservableCollection<ClientModel>();

        public MainWindowViewModel()
        {
            _sqlConnection = new SqlConnection(_sqlConnectionString);
            _sqlConnection.Open();
            RefreshSejururiData();
        }
        public ObservableCollection<SejurModel> SejururiList
        {
            get
            {
                if (_sejururiList == null)
                    _sejururiList = new ObservableCollection<SejurModel>();
                return _sejururiList;
            }
            set
            {
                _sejururiList = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<CroazieraModel> CroaziereList
        {
            get
            {
                if (_croaziereList == null)
                    _croaziereList = new ObservableCollection<CroazieraModel>();
                return _croaziereList;
            }
            set
            {
                _croaziereList = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<CircuitModel> CircuiteList
        {
            get
            {
                if (_circuiteList == null)
                    _circuiteList = new ObservableCollection<CircuitModel>();
                return _circuiteList;
            }
            set
            {
                _circuiteList = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<IncasareModel> IncasareList
        {
            get
            {
                if (_incasariList == null)
                    _incasariList = new ObservableCollection<IncasareModel>();
                return _incasariList;
            }
            set
            {
                _incasariList = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<OfertaModel> OferteList
        {
            get
            {
                if (_oferteList == null)
                    _oferteList = new ObservableCollection<OfertaModel>();
                return _oferteList;
            }
            set
            {
                _oferteList = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<IncasareModel> IncasariList
        {
            get
            {
                if (_incasariList == null)
                    _incasariList = new ObservableCollection<IncasareModel>();
                return _incasariList;
            }
            set
            {
                _incasariList = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<ClientModel> ClientiList
        {
            get
            {
                if (_clientiList == null)
                    _clientiList = new ObservableCollection<ClientModel>();
                return _clientiList;
            }
            set
            {
                _clientiList = value;
                OnPropertyChanged();
            }
        }
    }

}
