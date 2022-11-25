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

        private ObservableCollection<String> _tipExcursie = new ObservableCollection<string>() { "Sejur", "Croazieră", "Circuit" };
        private String _selectedTipExcursie = "Sejur";
        private ObservableCollection<String> _sezoane = new ObservableCollection<string>() { "Iarna", "Primăvara", "Vara", "Toamna" };
        private String _selectedSezon = "Iarna";
        private ObservableCollection<String> _tipuriCazare = new ObservableCollection<string>() { "Hotel", "Apartament", "Pensiune", "Vilă", "Cabană" };
        private String _selectedTipCazare = "Hotel";
        private ObservableCollection<Byte> _nrStele = new ObservableCollection<Byte>() { 1, 2, 3, 4, 5 };
        private Byte _selectedNrStele = 3;
        private ObservableCollection<String> _mese = new ObservableCollection<string>() { "Dejun", "Demipensiune", "Pensiune" };
        private String _selectedMese = "Dejun";
        private ObservableCollection<String> _transport = new ObservableCollection<string>() { "Fără Transport", "Automobil", "Autobuz", "Avion" };
        private String _selectedTransport = "Fără Transport";
        private ObservableCollection<String> _categoriiVase = new ObservableCollection<string>() { "Croazieră", "Pontoon", "Yacht", "Catamaran", "Pescuit" };
        private String _selectedCategorieVas = "Croazieră";
        private ObservableCollection<String> _ids = new ObservableCollection<String>() { };
        private String _selectedId = null;

        private DateTime _enteredStartDate = DateTime.Now;
        private DateTime _enteredEndDate = DateTime.Now;
        private String _enteredTara = "";
        private String _enteredLocalitate = "";
        private String _enteredDenumire = "";
        private String _enteredFacilitati = "";
        private String _enteredPretTransport = ""; 
        private String _enteredPretCazare = ""; 
        private String _calculatedNights = "1";
        private String _enteredVizite = "";
        private String _enteredTraseu = "";
        private String _enteredTipOferta = "";

        private String _selectedSejurSezon = "";
        private String _selectedCroazieraSezon = "";
        private String _selectedCircuitSezon = "";

        private ObservableCollection<SejurModel> _sejururiList = new ObservableCollection<SejurModel>();
        private ObservableCollection<CroazieraModel> _croaziereList = new ObservableCollection<CroazieraModel>();
        private ObservableCollection<CircuitModel> _circuiteList = new ObservableCollection<CircuitModel>();
        private ObservableCollection<OfertaModel> _oferteList = new ObservableCollection<OfertaModel>();
        private ObservableCollection<IncasareModel> _incasariList = new ObservableCollection<IncasareModel>();
        private ObservableCollection<ClientModel> _clientiList = new ObservableCollection<ClientModel>();

        private SejurModel _selectedSejur = null;
        private CroazieraModel _selectedCroaziera = null;
        private CircuitModel _selectedCircuit = null;
        private OfertaModel _selectedOferta = null;
        private IncasareModel _selectedIncasare = null;
        private ClientModel _selectedClient = null;

        //Add Sejur

        private Boolean _isDialogHostOpen = false;
        private Boolean _isAddSejurDialogHostOpen = false;
        private Boolean _isAddCroazieraDialogHostOpen = false;
        private Boolean _isAddCircuitDialogHostOpen = false;
        private Boolean _isAddOfertaDialogHostOpen = false;
        private Boolean _isAddIncasareDialogHostOpen = false;
        private Boolean _isAddClientDialogHostOpen = false;
        private Boolean _isSejurCazareDialogHostOpen = false;

        //InfoControl properties
        private Boolean _tipSejurSelected = false;
        private Boolean _tipCroazieraSelected = false;
        private Boolean _tipCircuitSelected = false;


        public MainWindowViewModel()
        {
            _sqlConnection = new SqlConnection(_sqlConnectionString);
            _sqlConnection.Open();
            RefreshAllData();
        }

        public ObservableCollection<String> TipExcursie => _tipExcursie;
        public String SelectedTipExcursie
        {
            get => _selectedTipExcursie;
            set
            {
                _selectedTipExcursie = value;
                TipSejurSelected = (_selectedTipExcursie == "Sejur") ? true : false;
                TipCroazieraSelected = (_selectedTipExcursie == "Croazieră") ? true : false;
                TipCircuitSelected = (_selectedTipExcursie == "Circuit") ? true : false;
                SetIDs();
                OnPropertyChanged();
            }
        }

        public Boolean TipSejurSelected
        {
            get => _tipSejurSelected;
            set
            {
                _tipSejurSelected = value;
                OnPropertyChanged();
            }
        }

        public Boolean TipCroazieraSelected
        {
            get => _tipCroazieraSelected;
            set
            {
                _tipCroazieraSelected = value;
                OnPropertyChanged();
            }
        }

        public Boolean TipCircuitSelected
        {
            get => _tipCircuitSelected;
            set
            {
                _tipCircuitSelected = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<String> Sezoane => _sezoane;
        public String SelectedSezon
        {
            get => _selectedSezon;
            set
            {
                _selectedSezon = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<String> TipuriCazare => _tipuriCazare;
        public String SelectedTipCazare
        {
            get => _selectedTipCazare;
            set
            {
                _selectedTipCazare = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Byte> NrStele => _nrStele;
        public Byte SelectedNrStele
        {
            get => _selectedNrStele;
            set
            {
                _selectedNrStele = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<String> Mese => _mese;
        public String SelectedMese
        {
            get => _selectedMese;
            set
            {
                _selectedMese = value;
                OnPropertyChanged();
            }
        }
        
        public ObservableCollection<String> IDs => _ids;
        public String SelectedId
        {
            get => _selectedId;
            set
            {
                _selectedId = value;
                switch (SelectedTipExcursie)
                {
                    case "Sejur":
                        SelectedSejur = SejururiList.Where(X => X.IdSejur.ToString() == _selectedId).FirstOrDefault();
                        break;
                        
                    case "Croazieră":
                        SelectedCroaziera = CroaziereList.Where(X => X.IdCroaziera.ToString() == _selectedId).FirstOrDefault();
                        break;
                        
                    case "Circuit":
                        SelectedCircuit = CircuiteList.Where(X => X.IdCircuit.ToString() == _selectedId).FirstOrDefault();
                        break;

                    default:
                        break;

                }
                OnPropertyChanged();
            }
        }

        public ObservableCollection<String> Transport => _transport;
        public String SelectedTransport
        {
            get => _selectedTransport;
            set
            {
                _selectedTransport = value;
                if (_selectedTransport == "Fără Transport" && IsAddSejurDialogHostOpen)
                    EnteredPretTransport = "0";
                OnPropertyChanged();
            }
        }

        public ObservableCollection<String> CategoriiVase => _categoriiVase;
        public String SelectedCategorieVas
        {
            get => _selectedCategorieVas;
            set
            {
                _selectedCategorieVas = value;
                OnPropertyChanged();
            }
        }

        public DateTime EnteredStartDate
        {
            get => _enteredStartDate;
            set
            {
                _enteredStartDate = value;
                OnPropertyChanged();
            }
        }

        public DateTime EnteredEndDate
        {
            get => _enteredEndDate;
            set
            {
                _enteredEndDate = value;
                EnteredStartDate = _enteredStartDate;
                CalculateNights();
                OnPropertyChanged();
            }
        }

        public String EnteredTara
        {
            get => _enteredTara;
            set
            {
                _enteredTara = value;
                OnPropertyChanged();
            }
        }

        public String EnteredLocalitate
        {
            get => _enteredLocalitate;
            set
            {
                _enteredLocalitate = value;
                OnPropertyChanged();
            }
        }

        public String EnteredDenumire
        {
            get => _enteredDenumire;
            set
            {
                _enteredDenumire = value;
                OnPropertyChanged();
            }
        }

        public String EnteredFacilitati
        {
            get => _enteredFacilitati;
            set
            {
                _enteredFacilitati = value;
                OnPropertyChanged();
            }
        }

        public String EnteredPretTransport
        {
            get => _enteredPretTransport;
            set
            {
                _enteredPretTransport = value;
                if (_selectedTransport == "Fără Transport" && IsAddSejurDialogHostOpen)
                    _enteredPretTransport = "0";
                OnPropertyChanged();
            }
        }

        public String EnteredPretCazare
        {
            get => _enteredPretCazare;
            set
            {
                _enteredPretCazare = value;
                OnPropertyChanged();
            }
        }

        public String CalculatedNights
        {
            get => _calculatedNights;
            set
            {
                _calculatedNights = value;
                OnPropertyChanged();
            }
        }
        

        public String EnteredVizite
        {
            get => _enteredVizite;
            set
            {
                _enteredVizite = value;
                OnPropertyChanged();
            }
        }

        public String EnteredTraseu
        {
            get => _enteredTraseu;
            set
            {
                _enteredTraseu = value;
                OnPropertyChanged();
            }
        }

        public String EnteredTipOferta
        {
            get => _enteredTipOferta;
            set
            {
                _enteredTipOferta = value;
                OnPropertyChanged();
            }
        }

        public String SelectedSejurSezon
        {
            get => _selectedSejurSezon;
            set
            {
                _selectedSejurSezon = value;
                RefreshSejururiData();
                OnPropertyChanged();
            }
        }

        public String SelectedCroazieraSezon
        {
            get => _selectedCroazieraSezon;
            set
            {
                _selectedCroazieraSezon = value;
                RefreshCroaziereData();
                OnPropertyChanged();
            }
        }

        public String SelectedCircuitSezon
        {
            get => _selectedCircuitSezon;
            set
            {
                _selectedCircuitSezon = value;
                RefreshCircuiteData();
                OnPropertyChanged();
            }
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

        public SejurModel SelectedSejur
        {
            get => _selectedSejur;
            set
            {
                _selectedSejur = value;
                OnPropertyChanged();
            }
        }
        public CroazieraModel SelectedCroaziera
        {
            get => _selectedCroaziera;
            set
            {
                _selectedCroaziera = value;
                OnPropertyChanged();
            }
        }
        public CircuitModel SelectedCircuit
        {
            get => _selectedCircuit;
            set
            {
                _selectedCircuit = value;
                OnPropertyChanged();
            }
        }
        public OfertaModel SelectedOferta
        {
            get => _selectedOferta;
            set
            {
                _selectedOferta = value;
                OnPropertyChanged();
            }
        }
        public ClientModel SelectedClient
        {
            get => _selectedClient;
            set
            {
                _selectedClient = value;
                OnPropertyChanged();
            }
        }
        public IncasareModel SelectedIncasare
        {
            get => _selectedIncasare;
            set
            {
                _selectedIncasare = value;
                OnPropertyChanged();
            }
        }

        public Boolean IsDialogHostOpen
        {
            get => _isDialogHostOpen;
            set
            {
                _isDialogHostOpen = value;
                OnPropertyChanged();
            }
        }
        public Boolean IsAddSejurDialogHostOpen
        {
            get => _isAddSejurDialogHostOpen;
            set
            {
                _isAddSejurDialogHostOpen = value;
                OnPropertyChanged();
            }
        }

        public Boolean IsAddCroazieraDialogHostOpen
        {
            get => _isAddCroazieraDialogHostOpen;
            set
            {
                _isAddCroazieraDialogHostOpen = value;
                OnPropertyChanged();
            }
        }

        public Boolean IsAddCircuitDialogHostOpen
        {
            get => _isAddCircuitDialogHostOpen;
            set
            {
                _isAddCircuitDialogHostOpen = value;
                OnPropertyChanged();
            }
        }

        public Boolean IsAddOfertaDialogHostOpen
        {
            get => _isAddOfertaDialogHostOpen;
            set
            {
                _isAddOfertaDialogHostOpen = value;
                OnPropertyChanged();
            }
        }

        public Boolean IsAddIncasareDialogHostOpen
        {
            get => _isAddIncasareDialogHostOpen;
            set
            {
                _isAddIncasareDialogHostOpen = value;
                OnPropertyChanged();
            }
        }

        public Boolean IsAddClientDialogHostOpen
        {
            get => _isAddClientDialogHostOpen;
            set
            {
                _isAddClientDialogHostOpen = value;
                OnPropertyChanged();
            }
        }

        public Boolean IsSejurCazareDialogHostOpen
        {
            get => _isSejurCazareDialogHostOpen;
            set
            {
                _isSejurCazareDialogHostOpen= value;
                OnPropertyChanged();
            }
        }

    }
}
