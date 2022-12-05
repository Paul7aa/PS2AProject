using PS2AProject.Models;
using PS2AProject.Views;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace PS2AProject.ViewModels
{
    public partial class MainWindowViewModel
    {
        private ICommand _openDialogHostCommand;
        private ICommand _closeDialogHostCommand;

        private ICommand _openIncasareDialogHostCommand;
        private ICommand _closeIncasareDialogHostCommand;

        private ICommand _openClientDialogHostCommand;
        private ICommand _closeClientDialogHostCommand;

        private ICommand _afisareDetaliiCazareCommand;
        private ICommand _closeDetaliiCazareCommand;

        private ICommand _afisareDetaliiOfertaCommand;
        private ICommand _afisareChitantaCommand;
        private ICommand _afisareSituatieAnualaCommand;
        private ICommand _refreshDataCommand;
        private ICommand _deleteSejurCommand;
        private ICommand _deleteCroazieraCommand;
        private ICommand _deleteCircuitCommand;
        private ICommand _deleteOfertaCommand;
        private ICommand _deleteClientCommand;
        private ICommand _deleteIncasareCommand;

        private ICommand _addSejurCommand;
        private ICommand _addCroazieraCommand;
        private ICommand _addCircuitCommand;
        private ICommand _addOfertaCommand;
        private ICommand _addIncasareCommand;
        private ICommand _addClientCommand;

        private ICommand _mergiLaOfertaCommand;
        private ICommand _completarePlataCommand;
        private ICommand _anularePlataCommand;

        private ICommand _afisareClientiTopCommand;

        private ICommand _creeazaOfertaCommand;

        public ICommand CloseDialogHostCommand
        {
            get
            {
                if (_closeDialogHostCommand == null)
                    _closeDialogHostCommand = new RelayCommand((_) => { IsDialogHostOpen = false; TurnOffGridVisibility(); ResetEnteredData(); },
                        (_) => true);
                return _closeDialogHostCommand;
            }
        }


        public ICommand OpenDialogHostCommand
        {
            get
            {
                if (_openDialogHostCommand == null)
                    _openDialogHostCommand = new RelayCommand((param) => OpenDialogHostOnClick(param),
                        (_) => true);
                return _openDialogHostCommand;
            }
        }

        public ICommand OpenIncasareDialogHostCommand
        {
            get
            {
                if (_openIncasareDialogHostCommand == null)
                    _openIncasareDialogHostCommand = new RelayCommand((param) => { OpenDialogHostOnClick(param); CalculateReducere(); },
                        (_) => SelectedExcursie != null && SelectedExcursie.Rezervat == "Nu");
                return _openIncasareDialogHostCommand;
            }
        }

        public ICommand CloseIncasareDialogHostCommand
        {
            get
            {
                if (_closeIncasareDialogHostCommand == null)
                    _closeIncasareDialogHostCommand = new RelayCommand((_) => { IsDialogHostOpen = false; OpenDialogHostCommand.Execute(null); ResetRezervareData(); },
                        (_) => true);
                return _closeIncasareDialogHostCommand;
            }
        }


        public ICommand OpenClientDialogHostCommand
        {
            get
            {
                if (_openClientDialogHostCommand == null)
                    _openClientDialogHostCommand = new RelayCommand((_) => OpenClientDialogHostOnClick(),
                        (_) => true);
                return _openClientDialogHostCommand;
            }
        }

        public ICommand CloseClientDialogHostCommand
        {
            get
            {
                if (_closeClientDialogHostCommand == null)
                    _closeClientDialogHostCommand = new RelayCommand((_) =>
                    {
                        IsAddClientDialogHostOpen = false;
                        if (!IsAddDialogHostOpen())
                            ResetEnteredData();
                    },
                    (_) => true);
                return _closeClientDialogHostCommand;
            }
        }

        public ICommand AfisareDetaliiCazareCommand
        {
            get
            {
                if (_afisareDetaliiCazareCommand == null)
                    _afisareDetaliiCazareCommand = new RelayCommand((param) => OpenDialogHostOnClick(param),
                        (_) => SelectedSejur != null);
                return _afisareDetaliiCazareCommand;
            }
        }

        public ICommand CloseDetaliiCazareCommand
        {
            get
            {
                if (_closeDetaliiCazareCommand == null)
                    _closeDetaliiCazareCommand = new RelayCommand((_) => { IsDialogHostOpen = false; },
                        (_) => true);
                return _closeDetaliiCazareCommand;
            }
        }

        public ICommand AfisareDetaliiOfertaCommand
        {
            get
            {
                if (_afisareDetaliiOfertaCommand == null)
                    _afisareDetaliiOfertaCommand = new RelayCommand((param) => AfisareDetaliiOfertaOnClick(param),
                        (_) => SelectedOferta != null);
                return _afisareDetaliiOfertaCommand;
            }
        }

        public ICommand AfisareChitantaCommand
        {
            get
            {
                if (_afisareChitantaCommand == null)
                    _afisareChitantaCommand = new RelayCommand((param) => AfisareChitantaOnClick(param),
                        (_) => SelectedIncasare != null);
                return _afisareChitantaCommand;
            }
        }

        public ICommand AfisareSituatieAnualaCommand
        {
            get
            {
                if (_afisareSituatieAnualaCommand == null)
                    _afisareSituatieAnualaCommand = new RelayCommand((param) => AfisareSituatieAnualaOnClick(param),
                        (_) => true);
                return _afisareSituatieAnualaCommand;
            }
        }

        public ICommand RefreshDataCommand
        {
            get
            {
                if (_refreshDataCommand == null)
                    _refreshDataCommand = new RelayCommand((param) => RefreshDataOnClick(param),
                        (_) => true);
                return _refreshDataCommand;
            }
        }
        public ICommand DeleteSejurCommand
        {
            get
            {
                if (_deleteSejurCommand == null)
                    _deleteSejurCommand = new RelayCommand((_) => DeleteEntryOnClick("Sejururi", "IdSejur", SelectedSejur.IdSejur),
                        (_) => SelectedSejur != null);
                return _deleteSejurCommand;
            }
        }
        public ICommand DeleteCroazieraCommand
        {
            get
            {
                if (_deleteCroazieraCommand == null)
                    _deleteCroazieraCommand = new RelayCommand((_) => DeleteEntryOnClick("Croaziere", "IdCroaziera", SelectedCroaziera.IdCroaziera),
                        (_) => SelectedCroaziera != null);
                return _deleteCroazieraCommand;
            }
        }
        public ICommand DeleteCircuitCommand
        {
            get
            {
                if (_deleteCircuitCommand == null)
                    _deleteCircuitCommand = new RelayCommand((_) => DeleteEntryOnClick("Circuite", "IdCircuit", SelectedCircuit.IdCircuit),
                        (_) => SelectedCircuit != null);
                return _deleteCircuitCommand;
            }
        }
        public ICommand DeleteOfertaCommand
        {
            get
            {
                if (_deleteOfertaCommand == null)
                    _deleteOfertaCommand = new RelayCommand((_) => DeleteEntryOnClick("Oferte", "IdOferta", SelectedOferta.IdOferta),
                        (_) => SelectedOferta != null);
                return _deleteOfertaCommand;
            }
        }
        public ICommand DeleteClientCommand
        {
            get
            {
                if (_deleteClientCommand == null)
                    _deleteClientCommand = new RelayCommand((_) => DeleteEntryOnClick("Clienti", "IdClient", SelectedClient.IdClient),
                        (_) => SelectedClient != null);
                return _deleteClientCommand;
            }
        }
        public ICommand DeleteIncasareCommand
        {
            get
            {
                if (_deleteIncasareCommand == null)
                    _deleteIncasareCommand = new RelayCommand((_) => DeleteEntryOnClick("Incasari", "IdIncasare", SelectedIncasare.IdIncasare),
                        (_) => SelectedIncasare != null);
                return _deleteIncasareCommand;
            }
        }

        public ICommand AddSejurCommand
        {
            get
            {
                if (_addSejurCommand == null)
                    _addSejurCommand = new RelayCommand((_) => AddSejurOnClick(),
                        (_) => AddSejurCanExecute());
                return _addSejurCommand;
            }
        }

        public ICommand AddCroazieraCommand
        {
            get
            {
                if (_addCroazieraCommand == null)
                    _addCroazieraCommand = new RelayCommand((_) => AddCroazieraOnClick(),
                        (_) => AddCroazieraCanExecute());
                return _addCroazieraCommand;
            }
        }

        public ICommand AddCircuitCommand
        {
            get
            {
                if (_addCircuitCommand == null)
                    _addCircuitCommand = new RelayCommand((_) => AddCircuitOnClick(),
                        (_) => AddCircuitCanExecute());
                return _addCircuitCommand;
            }
        }

        public ICommand AddOfertaCommand
        {
            get
            {
                if (_addOfertaCommand == null)
                    _addOfertaCommand = new RelayCommand((_) => AddOfertaOnClick(),
                        (_) => AddOfertaCanExecute());
                return _addOfertaCommand;
            }
        }

        public ICommand MergiLaOfertaCommand
        {
            get
            {
                if (_mergiLaOfertaCommand == null)
                    _mergiLaOfertaCommand = new RelayCommand((_) => MergiLaOfertaOnClick(),
                        (_) => SelectedOferta != null);
                return _mergiLaOfertaCommand;
            }
        }

        public ICommand AddClientCommand
        {
            get
            {
                if (_addClientCommand == null)
                    _addClientCommand = new RelayCommand((_) => AddClientOnClick(),
                        (_) => AddClientCanExecute());
                return _addClientCommand;
            }
        }

        public ICommand AddIncasareCommand
        {
            get
            {
                if (_addIncasareCommand == null)
                    _addIncasareCommand = new RelayCommand((_) => AddIncasareOnClick(),
                        (_) => AddIncasareCanExecute());
                return _addIncasareCommand;
            }
        }

        public ICommand CompletarePlataCommand
        {
            get
            {
                if(_completarePlataCommand == null)
                    _completarePlataCommand = new RelayCommand((_) => CompletarePlataOnClick(),
                        (_) => CompletarePlataCanExecute());
                    return _completarePlataCommand;
            }
        }

        public ICommand AnularePlataCommand
        {
            get
            {
                if(_anularePlataCommand == null)
                    _anularePlataCommand = new RelayCommand((_) => AnularePlataOnClick(),
                        (_) => AnularePlataCanExecute());
                    return _anularePlataCommand;
            }
        }

        public ICommand AfisareClientiTopCommand
        {
            get
            {
                if(_afisareClientiTopCommand == null)
                    _afisareClientiTopCommand = new RelayCommand((_) => RefreshClientiData(true),
                        (_) => true);
                    return _afisareClientiTopCommand;
            }
        }
        public ICommand CreeazaOfertaCommand
        {
            get
            {
                if(_creeazaOfertaCommand == null)
                    _creeazaOfertaCommand = new RelayCommand((param) => CreeazaOfertaOnClick(param),
                        (_) => CreeazaOfertaCanExecute());
                    return _creeazaOfertaCommand;
            }
        }

        private bool IsAddDialogHostOpen()
        {
            return IsAddSejurDialogHostOpen || IsAddCroazieraDialogHostOpen || IsAddCircuitDialogHostOpen
                || IsAddOfertaDialogHostOpen || IsAddIncasareDialogHostOpen;

        }

        private void OpenDialogHostOnClick(object param)
        {
            try
            {
                string dialogType = param as string;
                IsAddSejurDialogHostOpen = (dialogType == "sejur") ? true : false;
                IsAddCroazieraDialogHostOpen = (dialogType == "croaziera") ? true : false;
                IsAddCircuitDialogHostOpen = (dialogType == "circuit") ? true : false;
                IsAddOfertaDialogHostOpen = (dialogType == "oferta") ? true : false;
                IsAddIncasareDialogHostOpen = (dialogType == "incasare") ? true : false;
                IsAfisareOfertaDialogHostOpen = (dialogType == "afisareoferta") ? true : false;
                IsAfisareChitantaDialogHostOpen = (dialogType == "chitanta") ? true : false;
                IsAfisareSituatieAnualaDialogHostOpen = (dialogType == "situatieanuala") ? true : false;
                if (dialogType == "sejurcazare")
                {
                    if (SelectedSejur == null)
                        throw new Exception("Selectați un sejur pentru a afișa datele!");
                    else
                        IsSejurCazareDialogHostOpen = true;
                }
                else
                    IsSejurCazareDialogHostOpen = false;

                if (dialogType == "sejur" || dialogType == "croaziera" || dialogType == "circuit")
                    ResetEnteredData();

                if (dialogType == "oferta" && String.IsNullOrEmpty(SelectedTipExcursie))
                    SelectedTipExcursie = "Sejur";

                if (param != null)
                    IsDialogHostOpen = true;
            }
            catch (Exception ex)
            {
                ShowError("Error: " + ex.Message);
            }
        }
        
        private void AfisareDetaliiOfertaOnClick(object param)
        {
            try
            {
                SelectedTipExcursie = SelectedOferta.TipExcursie;
                SelectedId = SelectedOferta.IdExcursie.ToString();
                OpenDialogHostOnClick(param);
            }
            catch (Exception ex)
            {
                ShowError("Error: " + ex.Message);
            }
        }
        
        private void AfisareChitantaOnClick(object param)
        {
            try
            {
                if (SelectedIncasare == null)
                    return;
                ClientModel currClient = ClientiList.Where(x => x.IdClient == SelectedIncasare.IdClient).FirstOrDefault();
                if (currClient == null)
                    throw new Exception("Clientul nu a fost găsit!");
                EnteredNume = currClient.Nume;
                EnteredPrenume = currClient.Prenume;

                switch (SelectedIncasare.TipExcursie)
                {
                    case "Sejur":
                        SelectedExcursie = SejururiList.Where(x => x.IdExcursie == SelectedIncasare.IdExcursie).FirstOrDefault();
                        break;
                    case "Croaziera":
                    case "Croazieră":
                        SelectedExcursie = CroaziereList.Where(x => x.IdExcursie == SelectedIncasare.IdExcursie).FirstOrDefault();
                        break;
                    case "Circuit":
                        SelectedExcursie = CircuiteList.Where(x => x.IdExcursie == SelectedIncasare.IdExcursie).FirstOrDefault();
                        break;
                    default:
                        throw new Exception("Excursia nu a fost găsită!");
                }

                if (SelectedExcursie == null)
                    throw new Exception("Excursia nu a fost găsită!");

                double pretCopii = SelectedIncasare.Copii * (SelectedExcursie.PretCazare * 50 / 100) + SelectedIncasare.Copii * SelectedExcursie.PretTransport;
                double pretAdulti = SelectedIncasare.Adulti * (SelectedExcursie.PretCazare) + SelectedIncasare.Adulti * SelectedExcursie.PretTransport;
                CalculatedPret = pretCopii + pretAdulti;
                
                OpenDialogHostOnClick(param);
            }
            catch (Exception ex)
            {
                ShowError("Error: " + ex.Message);
            }
        }
        
        
        private void AfisareSituatieAnualaOnClick(object param)
        {
            try
            {
                SelectedTipRaport = "Lunar";
                OpenDialogHostOnClick(param);
            }
            catch (Exception ex)
            {
                ShowError("Error: " + ex.Message);
            }
        }

        private void OpenClientDialogHostOnClick()
        {
            try
            {
                IsAddClientDialogHostOpen = true;
            }
            catch (Exception ex)
            {
                ShowError("Error: " + ex.Message);
            }
        }

        private void OpenRezervareDialogHostOnClick()
        {
            try
            {
                OpenDialogHostCommand.Execute(null);
                IsAddIncasareDialogHostOpen = true;
            }
            catch (Exception ex)
            {
                ShowError("Error: " + ex.Message);
            }
        }

        private void RefreshDataOnClick(object param)
        {
            try
            {
                string dataType = param as string;
                switch (dataType)
                {
                    case "sejur":
                        SelectedSejurSezon = null;
                        SelectedTaraSejur = null;
                        RefreshSejururiData();
                        break;
                    case "croaziera":
                        SelectedCroazieraSezon = null;
                        SelectedTaraCroaziera = null;
                        RefreshCroaziereData();
                        break;
                    case "circuit":
                        SelectedCircuitSezon = null;
                        SelectedTaraCircuit = null;
                        RefreshCircuiteData();
                        break;
                    case "oferta":
                        RefreshOferteData();
                        break;
                    case "client":
                        RefreshClientiData();
                        break;
                    case "incasare":
                        RefreshIncasariData();
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                ShowError(MethodBase.GetCurrentMethod().Name + "Error: " + ex.Message);
            }
        }

        private void DeleteEntryOnClick(string tableName, string idColumn, int selectedId)
        {
            try
            {
                bool? result = new CustomMessageBox("Sunteți sigur că doriți să ștergeți înregistrarea? ", MessageType.Confirmation, MessageButtons.YesNo) { Owner = Application.Current.MainWindow }.ShowDialog();
                if (result.HasValue && result == true)
                    DeleteEntry(tableName, idColumn, selectedId);

                UpdateTariLists();
            }catch(Exception ex)
            {
                ShowError("Eroare ștergere înregistrare: " + ex.Message);
            }
        }

        private void AddSejurOnClick()
        {
            try
            {
                AddSejurToTable();
                RefreshSejururiData();
                UpdateTariLists();
                CloseDialogHostCommand.Execute(null);
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        private void AddCroazieraOnClick()
        {
            try
            {
                AddCroazieraToTable();
                RefreshCroaziereData();
                UpdateTariLists();
                CloseDialogHostCommand.Execute(null);
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        private void AddCircuitOnClick()
        {
            try
            {
                AddCircuitToTable();
                RefreshCircuiteData();
                UpdateTariLists();
                CloseDialogHostCommand.Execute(null);
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        private void AddOfertaOnClick()
        {
            try
            {
                AddOfertaToTable();
                RefreshOferteData();
                UpdateTariLists();
                CloseDialogHostCommand.Execute(null);
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        private void AddClientOnClick()
        {
            try
            {
                AddClientToTable();
                RefreshClientiData();
                CloseClientDialogHostCommand.Execute(null);
                SelectedClient = ClientiList.Last();
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        private void AddIncasareOnClick() {
            try 
            {
                AddIncasareToTable();
                ClientTopUpdate();
                RefreshAllData();
                CloseIncasareDialogHostCommand.Execute(null);

            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        private void MergiLaOfertaOnClick()
        {
            try
            {
                String selectedType = SelectedOferta?.TipExcursie;
                Int32 ofertaId = SelectedOferta.IdExcursie;

                switch (selectedType)
                {
                    case "Sejur":
                        SelectedTabIndex = 0;
                        SelectedSejur = SejururiList.Where(X => X.IdSejur == ofertaId)?.FirstOrDefault();
                        break;
                    case "Croaziera":
                        SelectedTabIndex = 1;
                        SelectedCroaziera = CroaziereList.Where(X => X.IdCroaziera == ofertaId)?.FirstOrDefault();
                        break;
                    case "Circuit":
                        SelectedTabIndex = 2;
                        SelectedCircuit = CircuiteList.Where(X => X.IdCircuit == ofertaId)?.FirstOrDefault();
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }


        private bool AddSejurCanExecute()
        {
            return !String.IsNullOrEmpty(EnteredTara) && !String.IsNullOrEmpty(EnteredLocalitate) &&
                !String.IsNullOrEmpty(EnteredDenumire) && !String.IsNullOrEmpty(EnteredFacilitati) &&
                !String.IsNullOrEmpty(EnteredPretTransport) && !String.IsNullOrEmpty(EnteredPretCazare);
        }

        private bool AddCroazieraCanExecute()
        {
            return !String.IsNullOrEmpty(EnteredTara) && !String.IsNullOrEmpty(EnteredTraseu) &&
                !String.IsNullOrEmpty(EnteredVizite) && !String.IsNullOrEmpty(EnteredFacilitati) &&
                !String.IsNullOrEmpty(EnteredPretTransport) && !String.IsNullOrEmpty(EnteredPretCazare);
        }

        private bool AddCircuitCanExecute()
        {
            return !String.IsNullOrEmpty(EnteredTara) && !String.IsNullOrEmpty(EnteredTraseu) &&
                !String.IsNullOrEmpty(EnteredVizite) && !String.IsNullOrEmpty(EnteredFacilitati) &&
                !String.IsNullOrEmpty(EnteredPretTransport) && !String.IsNullOrEmpty(EnteredPretCazare);
        }

        private bool AddOfertaCanExecute()
        {
            return !String.IsNullOrEmpty(EnteredTipOferta) && !String.IsNullOrEmpty(SelectedId) &&
                !String.IsNullOrEmpty(EnteredReducere) && Int32.Parse(EnteredReducere) > 0;
        }

        private bool AddClientCanExecute()
        {
            return !String.IsNullOrEmpty(EnteredNume) && !String.IsNullOrEmpty(EnteredPrenume) &&
                !String.IsNullOrEmpty(EnteredCNP) && !String.IsNullOrEmpty(EnteredAdresa) &&
                !String.IsNullOrEmpty(EnteredTelefon);
        }

        private bool AddIncasareCanExecute()
        {
            return SelectedClient != null && !String.IsNullOrEmpty(EnteredAdulti) &&
                !String.IsNullOrEmpty(EnteredCopii) && (AchitatAvans || AchitatPretTotal);
        }

        private bool CompletarePlataCanExecute()
        {
            return SelectedIncasare != null && SelectedIncasare.ValoareIncasata < SelectedIncasare.ValoareTotala && SelectedIncasare.Status != "Rezervare anulata" 
                && SelectedIncasare.Status != "Complet achitat";
        }

        private bool AnularePlataCanExecute()
        {
            return SelectedIncasare != null && SelectedIncasare.Status != "Rezervare anulata";
        }

        private bool CreeazaOfertaCanExecute()
        {
            if(SelectedExcursie != null)
                return OferteList.Where(x=> x.IdExcursie == SelectedExcursie.IdExcursie && x.TipExcursie == CurrentTipExcursie).FirstOrDefault() == null;
            return false;
        }
    }
}
