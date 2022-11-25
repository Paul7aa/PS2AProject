using PS2AProject.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PS2AProject.ViewModels
{
    public partial class MainWindowViewModel
    {
        private ICommand _openDialogHostCommand;
        private ICommand _closeDialogHostCommand;
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

        public ICommand CloseDialogHost
        {
            get
            {
                if (_closeDialogHostCommand == null)
                    _closeDialogHostCommand = new RelayCommand((_) => { IsDialogHostOpen = false; ResetEnteredData(); },
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
                if(_addCircuitCommand == null)
                    _addCircuitCommand = new RelayCommand((_) => AddCircuitOnClick(),
                        (_) => AddCircuitCanExecute());
                return _addCircuitCommand;
            }
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
                IsAddClientDialogHostOpen = (dialogType == "client") ? true : false;
                IsAddIncasareDialogHostOpen = (dialogType == "incasare") ? true : false;
                if(dialogType == "sejurcazare")
                {
                    if (SelectedSejur == null)
                        throw new Exception("Selectați un sejur pentru a afișa datele!");
                    else
                        IsSejurCazareDialogHostOpen = true;
                }
                else
                    IsSejurCazareDialogHostOpen = false;

                if(dialogType == "sejur" || dialogType=="croaziera" || dialogType == "circuit")
                    ResetEnteredData();

                if (dialogType == "oferta")
                    SelectedTipExcursie = "Sejur";

                IsDialogHostOpen = true;
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
                        RefreshSejururiData();
                        break;
                    case "croaziera":
                        SelectedCroazieraSezon = null;
                        RefreshCroaziereData();
                        break;
                    case "circuit":
                        SelectedCircuitSezon = null;
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
            bool? result = new CustomMessageBox("Sunteți sigur că doriți să ștergeți înregistrarea? ", MessageType.Confirmation, MessageButtons.YesNo) { Owner = Application.Current.MainWindow }.ShowDialog();
            if (result.HasValue && result == true)
                DeleteEntry(tableName, idColumn, selectedId);
        }

        private void AddSejurOnClick() 
        {
            try
            {
                AddSejurToTable();
                RefreshSejururiData();
                CloseDialogHost.Execute(null);
            }catch(Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        private void AddCroazieraOnClick()
        {
            try {
            AddCroazieraToTable();
            RefreshCroaziereData();
            CloseDialogHost.Execute(null);
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
                CloseDialogHost.Execute(null);
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
                !String.IsNullOrEmpty(EnteredPretTransport) &&!String.IsNullOrEmpty(EnteredPretCazare);
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
    }
}
