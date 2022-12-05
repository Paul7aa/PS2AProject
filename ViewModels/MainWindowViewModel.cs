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
        private ObservableCollection<String> _tipuriRaport = new ObservableCollection<string>() { "Lunar", "Anual" };
        private String _selectedTipRaport = "Lunar";
        private ObservableCollection<String> _availableDates = new ObservableCollection<string>() { };
        private String _selectedAvailableDate = "";
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
        private String _enteredReducere = "";

        //client
        private String _enteredNume = "";
        private String _enteredPrenume = "";
        private String _enteredCNP = "";
        private String _enteredAdresa = "";
        private String _enteredTelefon;

        private String _selectedSejurSezon = "";
        private String _selectedCroazieraSezon = "";
        private String _selectedCircuitSezon = "";
        private String _selectedTaraSejur = "";
        private String _selectedTaraCroaziera = "";
        private String _selectedTaraCircuit = "";

        private String _pretIntial = "0";
        private String _pretFinal = "0";

        private String _searchTextSejur;
        private String _searchTextCroaziera;
        private String _searchTextCircuit;
        private String _searchTextOferta;
        private String _searchTextClient;
        private String _raportSelectionType;

        //rezervare
        private String _currentTipExcursie = "";
        private String _enteredAdulti = "0";
        private String _enteredCopii = "0";
        private String _pretTotalCalculated = "";
        private String _pretAvansCalculated = "";
        private Boolean _achitatAvans = false;
        private Boolean _achitatPretTotal = false;
        private String _reducere = "0";
        private Double _totalFaraReducere = 0;
        private Double _calculatedPret;
        private Double _totalIncasat = 0;
        private Double _pierderiPeReduceri = 0;
        private Int32 _excursiiAchitateComplet = 0;
        private Int32 _excursiiAchitateAvans = 0;
        private Int32 _excursiiAnulate = 0;

        private ObservableCollection<SejurModel> _sejururiList = new ObservableCollection<SejurModel>();
        private ObservableCollection<CroazieraModel> _croaziereList = new ObservableCollection<CroazieraModel>();
        private ObservableCollection<CircuitModel> _circuiteList = new ObservableCollection<CircuitModel>();
        private ObservableCollection<OfertaModel> _oferteList = new ObservableCollection<OfertaModel>();
        private ObservableCollection<IncasareModel> _incasariList = new ObservableCollection<IncasareModel>();
        private ObservableCollection<ClientModel> _clientiList = new ObservableCollection<ClientModel>();

        private ObservableCollection<String> _tariSejururi = new ObservableCollection<string>();
        private ObservableCollection<String> _tariCroaziere = new ObservableCollection<string>();
        private ObservableCollection<String> _tariCircuite = new ObservableCollection<string>();

        private ExcursieModel _selectedExcursie = null;
        private SejurModel _selectedSejur = null;
        private CroazieraModel _selectedCroaziera = null;
        private CircuitModel _selectedCircuit = null;
        private OfertaModel _selectedOferta = null;
        private IncasareModel _selectedIncasare = null;
        private ClientModel _selectedClient = null;


        private Boolean _isDialogHostOpen = false;
        private Boolean _isAddClientDialogHostOpen = false;
        private Boolean _isAddSejurDialogHostOpen = false;
        private Boolean _isAddCroazieraDialogHostOpen = false;
        private Boolean _isAddCircuitDialogHostOpen = false;
        private Boolean _isAddOfertaDialogHostOpen = false;
        private Boolean _isAddIncasareDialogHostOpen = false;
        private Boolean _isAfisareOfertaDialogHostOpen = false;
        private Boolean _isAfisareChitantaDialogHostOpen = false;
        private Boolean _isAfisareSituatieAnualaDialogHostOpen = false;
        private Boolean _isSejurCazareDialogHostOpen = false;

        //InfoControl properties
        private Boolean _tipSejurSelected = false;
        private Boolean _tipCroazieraSelected = false;
        private Boolean _tipCircuitSelected = false;

        //TabControl Properties
        private Int32 _selectedTabIndex = 0;
        public MainWindowViewModel()
        {
            _sqlConnection = new SqlConnection(_sqlConnectionString);
            _sqlConnection.Open();
            RefreshAllData();
            ClientTopUpdate();
        }

        public ObservableCollection<String> TipExcursie => _tipExcursie;
        public String SelectedTipExcursie
        {
            get => _selectedTipExcursie;
            set
            {
                _selectedTipExcursie = value;
                TipSejurSelected = (_selectedTipExcursie == "Sejur") ? true : false;
                TipCroazieraSelected = (_selectedTipExcursie == "Croazieră" || _selectedTipExcursie == "Croaziera") ? true : false;
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
                        ItemPretInitial = (SelectedSejur != null) ? (SelectedSejur.PretCazare + SelectedSejur.PretTransport).ToString() : "0";
                        break;

                    case "Croazieră":
                    case "Croaziera":
                        SelectedCroaziera = CroaziereList.Where(X => X.IdCroaziera.ToString() == _selectedId).FirstOrDefault();
                        ItemPretInitial = (SelectedCroaziera != null) ? (SelectedCroaziera.PretCazare + SelectedCroaziera.PretTransport).ToString() : "0";
                        break;

                    case "Circuit":
                        SelectedCircuit = CircuiteList.Where(X => X.IdCircuit.ToString() == _selectedId).FirstOrDefault();
                        ItemPretInitial = (SelectedCircuit != null) ? (SelectedCircuit.PretCazare + SelectedCircuit.PretTransport).ToString() : "0";
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
                else
                    EnteredPretTransport = "";
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
        public ObservableCollection<String> TipuriRaport => _tipuriRaport;
        public String SelectedTipRaport
        {
            get => _selectedTipRaport;
            set
            {
                _selectedTipRaport = value;
                if (_selectedTipRaport != null)
                {
                    TotalIncasat = 0;
                    PierderiPeReduceri = 0;
                    ExcursiiAchitateComplet = 0;
                    ExcursiiAchitateAvans = 0;
                    ExcursiiAnulate = 0;
                    if (_selectedTipRaport == "Anual") {
                        RaportSelectionType = "Anul: ";
                    }
                    else 
                    {
                        RaportSelectionType = "Luna: ";
                    }
                    SetAvailableDates();
                }
                OnPropertyChanged();
            }
        }
        public ObservableCollection<String> AvailableDates => _availableDates;
        public String SelectedAvailableDate
        {
            get => _selectedAvailableDate;
            set
            {
                _selectedAvailableDate = value;
                if(_selectedAvailableDate!=null)
                    CalculateTotals();
                OnPropertyChanged();
            }
        }

        public String RaportSelectionType
        {
            get => _raportSelectionType;
            set
            {
                _raportSelectionType = value;
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

        public String ItemPretInitial
        {
            get => _pretIntial;
            set
            {
                _pretIntial = value;
                OnPropertyChanged();
            }
        }

        public String ItemPretFinal
        {
            get => _pretFinal;
            set
            {
                _pretFinal = value;
                OnPropertyChanged();
            }
        }

        public String EnteredReducere
        {
            get => _enteredReducere;
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    _enteredReducere = String.Format("{0:N2}", value);
                    if (!String.IsNullOrEmpty(ItemPretInitial) && Int32.Parse(EnteredReducere) > 0)
                    {
                        ItemPretFinal = String.Format("{0:N2}",
                            (Double.Parse(ItemPretInitial) - (Int32.Parse(EnteredReducere) * Double.Parse(ItemPretInitial) / 100)).ToString());
                    }
                }
                else
                    _enteredReducere = value;
                OnPropertyChanged();
            }
        }

        public String EnteredNume
        {
            get => _enteredNume;
            set
            {
                _enteredNume = value;
                OnPropertyChanged();
            }
        }

        public String EnteredPrenume
        {
            get => _enteredPrenume;
            set
            {
                _enteredPrenume = value;
                OnPropertyChanged();
            }
        }

        public String EnteredCNP
        {
            get => _enteredCNP;
            set
            {
                _enteredCNP = value;
                OnPropertyChanged();
            }
        }

        public String EnteredAdresa
        {
            get => _enteredAdresa;
            set
            {
                _enteredAdresa = value;
                OnPropertyChanged();
            }
        }

        public String EnteredTelefon
        {
            get => _enteredTelefon;
            set
            {
                _enteredTelefon = value;
                OnPropertyChanged();
            }
        }

        public String CurrentTipExcursie
        {
            get => _currentTipExcursie;
            set
            {
                _currentTipExcursie = value;
                OnPropertyChanged();
            }
        }

        public String EnteredAdulti
        {
            get => _enteredAdulti;
            set
            {
                _enteredAdulti = value;
                CalculatePretTotal();
                OnPropertyChanged();
            }
        }

        public String EnteredCopii
        {
            get => _enteredCopii;
            set
            {
                _enteredCopii = value;
                CalculatePretTotal();
                OnPropertyChanged();
            }
        }

        public String PretTotalCalculated
        {
            get => _pretTotalCalculated;
            set
            {
                _pretTotalCalculated = value;
                OnPropertyChanged();
            }
        }

        public String PretAvansCalculated
        {
            get => _pretAvansCalculated;
            set
            {
                _pretAvansCalculated = value;
                OnPropertyChanged();
            }
        }

        public Boolean AchitatAvans
        {
            get => _achitatAvans;
            set
            {
                _achitatAvans = value;
                OnPropertyChanged();
            }
        }

        public Boolean AchitatPretTotal
        {
            get => _achitatPretTotal;
            set
            {
                _achitatPretTotal = value;
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
                UpdateTariLists();
                ClearSearchTexts();
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
                UpdateTariLists();
                ClearSearchTexts();
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
                UpdateTariLists();
                ClearSearchTexts();
                OnPropertyChanged();
            }
        }

        public String SelectedTaraSejur
        {
            get => _selectedTaraSejur;
            set
            {
                _selectedTaraSejur = value;
                RefreshSejururiData();
                ClearSearchTexts();
                OnPropertyChanged();
            }
        }

        public String SelectedTaraCroaziera
        {
            get => _selectedTaraCroaziera;
            set
            {
                _selectedTaraCroaziera = value;
                RefreshCroaziereData();
                ClearSearchTexts();
                OnPropertyChanged();
            }
        }

        public String SelectedTaraCircuit
        {
            get => _selectedTaraCircuit;
            set
            {
                _selectedTaraCircuit = value;
                RefreshCircuiteData();
                ClearSearchTexts();
                OnPropertyChanged();
            }
        }

        public String SearchTextSejur
        {
            get => _searchTextSejur;
            set
            {
                _searchTextSejur = value;
                RefreshSejururiData();
                if (!String.IsNullOrEmpty(_searchTextSejur))
                    SejururiList = new ObservableCollection<SejurModel>(SejururiList
                        .Where(x => x.Tara.ToLower().Contains(_searchTextSejur.Trim().ToLower())
                        || x.Localitate.ToLower().Contains(_searchTextSejur.Trim().ToLower())).ToList());
                OnPropertyChanged();
            }
        }

        public String SearchTextCroaziera
        {
            get => _searchTextCroaziera;
            set
            {
                _searchTextCroaziera = value;
                RefreshCroaziereData();
                if (!String.IsNullOrEmpty(_searchTextCroaziera))
                    CroaziereList = new ObservableCollection<CroazieraModel>(CroaziereList
                        .Where(x => x.Tara.ToLower().Contains(_searchTextCroaziera.Trim().ToLower())
                        || x.Traseu.ToLower().Contains(_searchTextCroaziera.Trim().ToLower())
                        || x.ViziteIncluse.ToLower().Contains(_searchTextCroaziera.Trim().ToLower())).ToList());
                OnPropertyChanged();
            }
        }

        public String SearchTextCircuit
        {
            get => _searchTextCircuit;
            set
            {
                _searchTextCircuit = value;
                RefreshCircuiteData();
                if (!String.IsNullOrEmpty(_searchTextCircuit))
                    CircuiteList = new ObservableCollection<CircuitModel>(CircuiteList
                        .Where(x => x.Tara.ToLower().Contains(_searchTextCircuit.Trim().ToLower())
                        || x.Traseu.ToLower().Contains(_searchTextCircuit.Trim().ToLower())
                        || x.ViziteIncluse.ToLower().Contains(_searchTextCircuit.Trim().ToLower())).ToList());
                OnPropertyChanged();
            }
        }

        public String SearchTextOferta
        {
            get => _searchTextOferta;
            set
            {
                _searchTextOferta = value;
                RefreshOferteData();
                if (!String.IsNullOrEmpty(_searchTextOferta))
                    OferteList = new ObservableCollection<OfertaModel>(OferteList
                        .Where(x => x.TipExcursie.ToLower().Contains(_searchTextOferta.Trim().ToLower())
                        || x.TipOferta.ToLower().Contains(_searchTextOferta.Trim().ToLower())).ToList());
                OnPropertyChanged();
            }
        }
        

        public String SearchTextClient
        {
            get => _searchTextClient;
            set
            {
                _searchTextClient = value;
                RefreshClientiData();
                if (!String.IsNullOrEmpty(_searchTextClient))
                    ClientiList = new ObservableCollection<ClientModel>(ClientiList
                        .Where(x => x.Nume.ToLower().Contains(_searchTextClient.Trim().ToLower())
                        || x.IdClient.ToString().ToLower().Contains(_searchTextClient.Trim().ToLower())).ToList());
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


        public ObservableCollection<String> TariSejururi
        {
            get
            {
                if (_tariSejururi == null)
                    _tariSejururi = new ObservableCollection<String>();
                return _tariSejururi;
            }
            set
            {
                _tariSejururi = value;
                OnPropertyChanged();
            }
        }


        public ObservableCollection<String> TariCroaziere
        {
            get
            {
                if (_tariCroaziere == null)
                    _tariCroaziere = new ObservableCollection<String>();
                return _tariCroaziere;
            }
            set
            {
                _tariCroaziere = value;
                OnPropertyChanged();
            }
        }


        public ObservableCollection<String> TariCircuite
        {
            get
            {
                if (_tariCircuite == null)
                    _tariCircuite = new ObservableCollection<String>();
                return _tariCircuite;
            }
            set
            {
                _tariCircuite = value;
                OnPropertyChanged();
            }
        }

        public ExcursieModel SelectedExcursie
        {
            get => _selectedExcursie;
            set
            {
                _selectedExcursie = value;
                if (value != null)
                    if (_selectedExcursie.GetType() == typeof(SejurModel))
                        CurrentTipExcursie = "Sejur";
                    else if (_selectedExcursie.GetType() == typeof(CroazieraModel))
                        CurrentTipExcursie = "Croaziera";
                    else if (_selectedExcursie.GetType() == typeof(CircuitModel))
                        CurrentTipExcursie = "Circuit";

                OnPropertyChanged();
            }
        }

        public SejurModel SelectedSejur
        {
            get => _selectedSejur;
            set
            {
                _selectedSejur = value;
                SelectedExcursie = _selectedSejur;
                OnPropertyChanged();
            }
        }
        public CroazieraModel SelectedCroaziera
        {
            get => _selectedCroaziera;
            set
            {
                _selectedCroaziera = value;
                SelectedExcursie = _selectedCroaziera;
                OnPropertyChanged();
            }
        }
        public CircuitModel SelectedCircuit
        {
            get => _selectedCircuit;
            set
            {
                _selectedCircuit = value;
                SelectedExcursie = _selectedCircuit;

                OnPropertyChanged();
            }
        }
        public OfertaModel SelectedOferta
        {
            get => _selectedOferta;
            set
            {
                _selectedOferta = value;
                if (_selectedOferta != null)
                {
                    switch (_selectedOferta.TipExcursie)
                    {
                        case "Sejur":
                            SelectedExcursie = SejururiList.Where(x => x.IdSejur == _selectedOferta.IdExcursie).FirstOrDefault();
                            break;
                        case "Croazieră":
                        case "Croaziera":
                            SelectedExcursie = CroaziereList.Where(x => x.IdCroaziera == _selectedOferta.IdExcursie).FirstOrDefault();
                            break;
                        case "Circuit":
                            SelectedExcursie = CircuiteList.Where(x => x.IdCircuit == _selectedOferta.IdExcursie).FirstOrDefault();
                            break;
                    }
                }
                OnPropertyChanged();
            }
        }
        public ClientModel SelectedClient
        {
            get => _selectedClient;
            set
            {
                _selectedClient = value;
                CalculateReducere();
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

        public Boolean IsAddClientDialogHostOpen
        {
            get => _isAddClientDialogHostOpen;
            set
            {
                _isAddClientDialogHostOpen = value;
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

        public Boolean IsAfisareOfertaDialogHostOpen
        {
            get => _isAfisareOfertaDialogHostOpen;
            set
            {
                _isAfisareOfertaDialogHostOpen = value;
                OnPropertyChanged();
            }
        }

        public Boolean IsAfisareChitantaDialogHostOpen
        {
            get => _isAfisareChitantaDialogHostOpen;
            set
            {
                _isAfisareChitantaDialogHostOpen = value;
                OnPropertyChanged();
            }
        }

        public Boolean IsAfisareSituatieAnualaDialogHostOpen
        {
            get => _isAfisareSituatieAnualaDialogHostOpen;
            set
            {
                _isAfisareSituatieAnualaDialogHostOpen = value;
                OnPropertyChanged();
            }
        }

        public Boolean IsSejurCazareDialogHostOpen
        {
            get => _isSejurCazareDialogHostOpen;
            set
            {
                _isSejurCazareDialogHostOpen = value;
                OnPropertyChanged();
            }
        }

        public Int32 SelectedTabIndex
        {
            get => _selectedTabIndex;
            set
            {
                _selectedTabIndex = value;
                ResetSelections();
                OnPropertyChanged();
            }
        }
        

        public String Reducere
        {
            get => _reducere;
            set
            {
                _reducere = value;
                OnPropertyChanged();
            }
        }

        public Double CalculatedPret
        {
            get => _calculatedPret;
            set
            {
                _calculatedPret = value;
                OnPropertyChanged();
            }
        }

        public Double TotalIncasat
        {
            get => _totalIncasat;
            set
            {
                _totalIncasat = value;
                OnPropertyChanged();
            }
        }

        public Double PierderiPeReduceri
        {
            get => _pierderiPeReduceri;
            set
            {
                _pierderiPeReduceri = value;
                OnPropertyChanged();
            }
        }

        public Int32 ExcursiiAchitateComplet
        {
            get => _excursiiAchitateComplet;
            set
            {
                _excursiiAchitateComplet = value;
                OnPropertyChanged();
            }
        }

        public Int32 ExcursiiAchitateAvans
        {
            get => _excursiiAchitateAvans;
            set
            {
                _excursiiAchitateAvans = value;
                OnPropertyChanged();
            }
        }

        public Int32 ExcursiiAnulate
        {
            get => _excursiiAnulate;
            set
            {
                _excursiiAnulate = value;
                OnPropertyChanged();
            }
        }

    }
}
