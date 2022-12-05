using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PS2AProject.Views;
using System.Windows;
using PS2AProject.Models;
using System.Diagnostics;
using System.Collections.ObjectModel;
using System.Net.Sockets;
using System.Windows.Controls;

namespace PS2AProject.ViewModels
{
    public partial class MainWindowViewModel
    {
        private void CreateSqlCommand(string cmdText)
        {
            _sqlCommand = _sqlConnection.CreateCommand();
            _sqlCommand.CommandType = CommandType.Text;
            _sqlCommand.CommandText = cmdText;
        }

        private void CreateSqlProcedure(string procedureName, List<SqlParameter> parameters = null)
        {
            _sqlCommand = _sqlConnection.CreateCommand();
            _sqlCommand.CommandType = CommandType.StoredProcedure;
            _sqlCommand.CommandText = procedureName;
            if (parameters != null)
            {
                foreach (var param in parameters)
                    _sqlCommand.Parameters.Add(param);
            }
        }

        private void RefreshSejururiData()
        {
            try
            {
                SejururiList.Clear();

                CreateSqlCommand("SELECT * FROM [Sejururi] " +
                    (!String.IsNullOrEmpty(_selectedSejurSezon) ? "where Sezon='" + _selectedSejurSezon + "'" : "")
                    + (String.IsNullOrEmpty(_selectedSejurSezon) && !String.IsNullOrEmpty(_selectedTaraSejur) ? "where Tara='" + _selectedTaraSejur + "'" :
                    (!String.IsNullOrEmpty(_selectedSejurSezon) && !String.IsNullOrEmpty(_selectedTaraSejur)) ? "and Tara='" + _selectedTaraSejur + "'" : ""));
                _sqlCommand.ExecuteNonQuery();
                SqlDataReader sqlDataReader = _sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    SejurModel sejurModel = new SejurModel((int)sqlDataReader["IdSejur"], (string)sqlDataReader["Sezon"], (string)sqlDataReader["Tara"],
                        (string)sqlDataReader["Localitate"], (DateTime)sqlDataReader["InceputPerioada"], (DateTime)sqlDataReader["SfarsitPerioada"],
                        (Byte)sqlDataReader["NumarNopti"], (string)sqlDataReader["TipCazare"], (string)sqlDataReader["Denumire"],
                        (Byte)sqlDataReader["NrStele"], (string)sqlDataReader["Mese"], (string)sqlDataReader["Facilitati"],
                        (string)sqlDataReader["Transport"], (Double)sqlDataReader["PretTransport"], (Double)sqlDataReader["PretCazare"], (string)sqlDataReader["Rezervat"]);

                    SejururiList.Add(sejurModel);
                }

                sqlDataReader.Close();

            }
            catch (Exception ex)
            {
                ShowError("Eroare actualizare sejururi: " + ex.Message);
            }
        }

        private void RefreshCroaziereData()
        {
            try
            {
                CroaziereList.Clear();
                CreateSqlCommand("SELECT * FROM [Croaziere] " +
                    (!String.IsNullOrEmpty(_selectedCroazieraSezon) ? "where Sezon='" + _selectedCroazieraSezon + "'" : "") +
                    (String.IsNullOrEmpty(_selectedCroazieraSezon) && !String.IsNullOrEmpty(_selectedTaraCroaziera) ? "where Tara='" + _selectedTaraCroaziera + "'" :
                    (!String.IsNullOrEmpty(_selectedCroazieraSezon) && !String.IsNullOrEmpty(_selectedTaraCroaziera)) ? "and Tara='" + _selectedTaraCroaziera + "'" : ""));
                _sqlCommand.ExecuteNonQuery();
                SqlDataReader sqlDataReader = _sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    CroazieraModel croazieraModel = new CroazieraModel((Int32)sqlDataReader["IdCroaziera"], (string)sqlDataReader["Sezon"],
                         (string)sqlDataReader["Tara"], (string)sqlDataReader["Traseu"], (DateTime)sqlDataReader["InceputPerioada"],
                         (DateTime)sqlDataReader["SfarsitPerioada"], (string)sqlDataReader["CategorieVas"], (string)sqlDataReader["Facilitati"],
                         (string)sqlDataReader["ViziteIncluse"], (double)sqlDataReader["PretTransport"], (double)sqlDataReader["PretCazare"], (string)sqlDataReader["Rezervat"]);

                    CroaziereList.Add(croazieraModel);
                }

                sqlDataReader.Close();
            }
            catch (Exception ex)
            {
                ShowError("Eroare actualizare croaziere: " + ex.Message);
            }
        }

        private void RefreshCircuiteData()
        {
            try
            {
                CircuiteList.Clear();
                CreateSqlCommand("SELECT * FROM [Circuite] " +
                    (!String.IsNullOrEmpty(_selectedCircuitSezon) ? "where Sezon='" + _selectedCircuitSezon + "'" : "") +
                    (String.IsNullOrEmpty(_selectedCircuitSezon) && !String.IsNullOrEmpty(_selectedTaraCircuit) ? "where Tara='" + _selectedTaraCircuit + "'" :
                    (!String.IsNullOrEmpty(_selectedCircuitSezon) && !String.IsNullOrEmpty(_selectedTaraCircuit)) ? "and Tara='" + _selectedTaraCircuit + "'" : ""));
                _sqlCommand.ExecuteNonQuery();
                SqlDataReader sqlDataReader = _sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    CircuitModel circuitModel = new CircuitModel((Int32)sqlDataReader["IdCircuit"], (string)sqlDataReader["Sezon"],
                        (string)sqlDataReader["Tara"], (string)sqlDataReader["Traseu"], (DateTime)sqlDataReader["InceputPerioada"],
                        (DateTime)sqlDataReader["SfarsitPerioada"], (Byte)sqlDataReader["NumarNopti"],
                        (string)sqlDataReader["FacilitatiCazare"], (string)sqlDataReader["ViziteIncluse"],
                        (string)sqlDataReader["Mese"], (Double)sqlDataReader["PretTransport"], (Double)sqlDataReader["PretCazare"], (string)sqlDataReader["Rezervat"]);

                    CircuiteList.Add(circuitModel);
                }

                sqlDataReader.Close();
            }
            catch (Exception ex)
            {
                ShowError("Eroare actualizare circuite: " + ex.Message);
            }
        }

        private void RefreshOferteData()
        {
            try
            {
                OferteList.Clear();
                CreateSqlCommand("SELECT * FROM [Oferte]");
                _sqlCommand.ExecuteNonQuery();
                SqlDataReader sqlDataReader = _sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    OfertaModel ofertaModel = new OfertaModel((Int32)sqlDataReader["IdOferta"], (string)sqlDataReader["TipOferta"],
                        (string)sqlDataReader["TipExcursie"], (Int32)sqlDataReader["IdExcursie"], (Byte)sqlDataReader["Reducere"],
                        (Double)sqlDataReader["PretInitial"], (Double)sqlDataReader["PretFinal"]);

                    OferteList.Add(ofertaModel);
                }

                sqlDataReader.Close();
            }
            catch (Exception ex)
            {
                ShowError("Eroare actualizare oferte: " + ex.Message);
            }
        }

        private void RefreshClientiData(bool topClient = false)
        {
            try
            {
                ClientiList.Clear();
                CreateSqlCommand("SELECT * FROM [Clienti] " + (topClient ? "WHERE ClientTop = 'Da'" : ""));
                _sqlCommand.ExecuteNonQuery();
                SqlDataReader sqlDataReader = _sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    ClientModel clientModel = new ClientModel((Int32)sqlDataReader["IdClient"], (string)sqlDataReader["Nume"],
                        (string)sqlDataReader["Prenume"], (string)sqlDataReader["CNP"], (string)sqlDataReader["Adresa"],
                        (string)sqlDataReader["NrTelefon"], (string)sqlDataReader["ClientTop"]);

                    ClientiList.Add(clientModel);
                }

                sqlDataReader.Close();
                ClientTopUpdate();
            }
            catch (Exception ex)
            {
                ShowError("Eroare actualizare clienti: " + ex.Message);
            }
        }

        private void RefreshIncasariData()
        {
            try
            {
                IncasariList.Clear();
                CreateSqlCommand("SELECT * FROM [Incasari]");
                _sqlCommand.ExecuteNonQuery();
                SqlDataReader sqlDataReader = _sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    IncasareModel incasareModel = new IncasareModel((Int32)sqlDataReader["IdIncasare"], (Int32)sqlDataReader["IdClient"],
                        (string)sqlDataReader["TipExcursie"], (Int32)sqlDataReader["IdExcursie"], (Byte)sqlDataReader["Adulti"],
                        (Byte)sqlDataReader["Copii"], (Double)sqlDataReader["ValoareTotala"], (Double)sqlDataReader["ValoareIncasata"],
                        (Byte)sqlDataReader["Reducere"], (DateTime)sqlDataReader["DataIncasarii"], (String)sqlDataReader["Status"]);

                    IncasariList.Add(incasareModel);
                }

                sqlDataReader.Close();
            }
            catch (Exception ex)
            {
                ShowError("Eroare actualizare incasari: " + ex.Message);
            }
        }

        public void RefreshAllData()
        {
            RefreshSejururiData();
            RefreshCroaziereData();
            RefreshCircuiteData();
            RefreshOferteData();
            RefreshClientiData();
            RefreshIncasariData();
            UpdateTariLists();
        }

        public void DeleteEntry(string tableName, string idColumn, int selectedId)
        {
            try
            {
                CreateSqlCommand("DELETE FROM [" + tableName + "] WHERE  " + idColumn + " = " + selectedId.ToString());
                _sqlCommand.ExecuteNonQuery();
                switch (tableName)
                {
                    case "Sejururi":
                        RefreshSejururiData();
                        CreateSqlCommand("DELETE FROM [Oferte] WHERE IdExcursie = " + selectedId.ToString());
                        _sqlCommand.ExecuteNonQuery();
                        RefreshOferteData();
                        break;
                    case "Croaziere":
                        RefreshCroaziereData();
                        CreateSqlCommand("DELETE FROM [Oferte] WHERE IdExcursie = " + selectedId.ToString());
                        _sqlCommand.ExecuteNonQuery();
                        RefreshOferteData();
                        break;
                    case "Circuite":
                        RefreshCircuiteData();
                        CreateSqlCommand("DELETE FROM [Oferte] WHERE IdExcursie = " + selectedId.ToString());
                        _sqlCommand.ExecuteNonQuery();
                        RefreshOferteData();
                        break;
                    case "Oferte":
                        RefreshOferteData();
                        break;
                    case "Clienti":
                        RefreshClientiData();
                        break;
                    case "Incasari":
                        RefreshIncasariData();
                        break;
                    default:
                        RefreshAllData();
                        break;

                }
            }
            catch (Exception ex)
            {
                throw new Exception("Eroare adăugare sejur: " + ex.Message);
            }
        }

        private void AddSejurToTable()
        {
            try
            {
                CreateSqlCommand("INSERT INTO [dbo].[Sejururi]" +
                    "([Sezon],[Tara],[Localitate],[InceputPerioada],[SfarsitPerioada]," +
                    "[NumarNopti],[TipCazare],[Denumire],[NrStele],[Mese],[Facilitati]," +
                    "[Transport], [PretTransport],[PretCazare],[Rezervat])" +
                    " VALUES('" +
                    SelectedSezon + "','" + EnteredTara + "','" + EnteredLocalitate + "','" +
                    EnteredStartDate.Date.ToString() + "','" + EnteredEndDate.Date.ToString() + "','" +
                    CalculatedNights + "','" + SelectedTipCazare + "','" + EnteredDenumire + "','" +
                    SelectedNrStele + "','" + SelectedMese + "','" + EnteredFacilitati + "','" +
                    SelectedTransport + "'," + EnteredPretTransport + "," + EnteredPretCazare + ",'Nu'" +")"
                    );
                _sqlCommand.ExecuteNonQuery();
                ResetEnteredData();
            }
            catch (Exception ex)
            {
                throw new Exception("Eroare adăugare sejur: " + ex.Message);
            }

        }

        private void AddCroazieraToTable()
        {
            try
            {
                CreateSqlCommand("INSERT INTO [dbo].[Croaziere]" +
                    "([Sezon],[Tara],[Traseu],[InceputPerioada],[SfarsitPerioada]," +
                    "[CategorieVas],[Facilitati],[ViziteIncluse],[PretTransport],[PretCazare]," +
                    "[Rezervat])" +
                    " VALUES ('" +
                    SelectedSezon + "','" + EnteredTara + "','" + EnteredTraseu + "','" +
                    EnteredStartDate.Date.ToString() + "','" + EnteredEndDate.Date.ToString() + "','" +
                    SelectedCategorieVas + "','" + EnteredFacilitati + "','" + EnteredVizite + "'," +
                    EnteredPretTransport + "," + EnteredPretCazare + ",'Nu'" + ")"
                    );
                _sqlCommand.ExecuteNonQuery();
                ResetEnteredData();
            }
            catch (Exception ex)
            {
                throw new Exception("Eroare adăugare croazieră: " + ex.Message);
            }
        }

        private void AddCircuitToTable()
        {
            try
            {
                CreateSqlCommand("INSERT INTO [dbo].[Circuite]" +
                    "([Sezon],[Tara],[Traseu],[InceputPerioada],[SfarsitPerioada]," +
                    "[NumarNopti],[FacilitatiCazare],[ViziteIncluse],[Mese],[PretTransport] " +
                    ",[PretCazare],[Rezervat])" +
                    " VALUES('" +
                    SelectedSezon + "','" + EnteredTara + "','" + EnteredTraseu + "','" + EnteredStartDate.Date.ToString() + "','" +
                    EnteredEndDate.Date.ToString() + "','" + CalculatedNights + "','" + EnteredFacilitati + "','" + EnteredVizite + "','"
                    + SelectedMese + "'," + EnteredPretTransport + "," + EnteredPretCazare + ",'Nu'" + ")");
                _sqlCommand.ExecuteNonQuery();
                ResetEnteredData();
            }
            catch (Exception ex)
            {
                throw new Exception("Eroare adăugare circuit: " + ex.Message);
            }
        }

        private void AddOfertaToTable()
        {

            try
            {
                CreateSqlCommand("INSERT INTO[dbo].[Oferte]" +
                    "([TipOferta],[TipExcursie],[IdExcursie]," +
                    "[Reducere],[PretInitial],[PretFinal])" +
                    "VALUES('" +
                    EnteredTipOferta + "','" + SelectedTipExcursie + "'," + SelectedId + "," +
                    EnteredReducere + "," + ItemPretInitial + "," + ItemPretFinal + ")");

                _sqlCommand.ExecuteNonQuery();
                ResetEnteredData();
            }
            catch (Exception ex)
            {
                throw new Exception("Eroare adăugare ofertă: " + ex.Message);
            }
        }

        private void AddClientToTable()
        {

            try
            {
                CreateSqlCommand("INSERT INTO [dbo].[Clienti]" +
                    " ([Nume],[Prenume],[CNP],[Adresa],[NrTelefon],[ClientTop]) " +
                    "VALUES('" +
                    EnteredNume + "','" + EnteredPrenume + "','" + EnteredCNP + "','" +
                    EnteredAdresa + "','" + EnteredTelefon + "','" + "Nu')"
                    );

                _sqlCommand.ExecuteNonQuery();
                ResetEnteredClientData();
            }
            catch (Exception ex)
            {
                throw new Exception("Eroare adăugare client: " + ex.Message);
            }
        }
        private void AddIncasareToTable()
        {
            try
            {
                CreateSqlCommand("INSERT INTO [dbo].[Incasari]" +
                   "([IdClient],[TipExcursie],[IdExcursie],[Adulti],[Copii]" +
                   ",[ValoareTotala],[ValoareIncasata],[Reducere],[Status],[DataIncasarii])" +
                   "VALUES(" +
                    SelectedClient.IdClient + ",'" + CurrentTipExcursie + "'," + SelectedExcursie.IdExcursie + "," +
                    EnteredAdulti + "," + EnteredCopii + "," +
                    (AchitatAvans ? (Math.Round((Double.Parse(PretTotalCalculated) + 5 * Double.Parse(PretTotalCalculated) / 100),2)).ToString() : PretTotalCalculated) + "," +
                    (AchitatAvans ? PretAvansCalculated : PretTotalCalculated) + "," + Reducere + ",'" +
                    (AchitatAvans ? "Avans achitat" : "Complet achitat") + "','" + DateTime.Now.Date.ToString() + "')"
                    );
                _sqlCommand.ExecuteNonQuery();


                SqlParameter excursieId = new SqlParameter("@excursieId", SqlDbType.Int)
                {
                    Value = SelectedExcursie.IdExcursie
                };
                switch (CurrentTipExcursie)
                {
                    case "Sejur":
                        CreateSqlProcedure("UpdateSejurStatus", new List<SqlParameter>() { excursieId });
                        break;
                    case "Croaziera":
                    case "Croazieră":
                        CreateSqlProcedure("UpdateCroazieraStatus", new List<SqlParameter>() { excursieId });
                        break;
                    case "Circuit":
                        CreateSqlProcedure("UpdateCircuitStatus", new List<SqlParameter>() { excursieId });
                        break;
                    default:
                        throw new Exception("Tipul excursiei nu a fost găsit!");
                }
                _sqlCommand.ExecuteNonQuery();

                ResetRezervareData();
            }
            catch (Exception ex)
            {
                throw new Exception("Eroare adăugare încasare: " + ex.Message);
            }
        }

        private void CompletarePlataOnClick()
        {
            try
            {
                bool? result = new CustomMessageBox("Sunteți sigur că doriți să completați plata? ", MessageType.Confirmation, MessageButtons.YesNo) { Owner = Application.Current.MainWindow }.ShowDialog();
                if (result.HasValue && result == true)
                {
                    CreateSqlProcedure("CompletarePlata", new List<SqlParameter>() { new SqlParameter("@idIncasare", SqlDbType.Int) { Value = SelectedIncasare.IdIncasare } });
                    _sqlCommand.ExecuteNonQuery();
                }
                RefreshIncasariData();
            }
            catch (Exception ex)
            {
                ShowError("Eroare completare plată: " + ex.Message);
            }
        }

        private void AnularePlataOnClick()
        {
            try
            {
                bool? result = new CustomMessageBox("Sunteți sigur că doriți să anulați plata? ", MessageType.Confirmation, MessageButtons.YesNo) { Owner = Application.Current.MainWindow }.ShowDialog();
                if (result.HasValue && result == true)
                {
                    SqlParameter sqlParam = new SqlParameter("@valoareIncasata", SqlDbType.Float);
                    switch (SelectedIncasare.Status)
                    {
                        case "Complet achitat":
                            sqlParam.Value = Math.Round((SelectedIncasare.ValoareIncasata - SelectedIncasare.ValoareIncasata * 80 / 100), 2);
                            break;
                        case "Avans achitat":
                            sqlParam.Value = SelectedIncasare.ValoareIncasata;
                            break;
                        default:
                            throw new Exception("Incasarea nu poate fi anulata!");
                    }

                    CreateSqlProcedure("AnularePlata", new List<SqlParameter>() { new SqlParameter("@idIncasare", SqlDbType.Int) { Value = SelectedIncasare.IdIncasare }, sqlParam });
                    _sqlCommand.ExecuteNonQuery();

                    switch (SelectedIncasare.TipExcursie)
                    {
                        case "Sejur":
                            CreateSqlCommand("UPDATE [dbo].[Sejururi] SET Rezervat='Nu' WHERE IdSejur = " + SelectedIncasare.IdExcursie);
                            break;
                        case "Croaziera":
                        case "Croazieră":
                            CreateSqlCommand("UPDATE [dbo].[Croaziere] SET Rezervat='Nu' WHERE IdCroaziera = " + SelectedIncasare.IdExcursie);
                            break;
                        case "Circuit":
                            CreateSqlCommand("UPDATE [dbo].[Circuite] SET Rezervat='Nu' WHERE IdCircuit = " + SelectedIncasare.IdExcursie);
                            break;
                        default:
                            throw new Exception("Tipul excursiei nu a fost găsit!");
                    }
                    _sqlCommand.ExecuteNonQuery();
                }
                ClientTopUpdate();
                RefreshAllData();
            }
            catch (Exception ex)
            {
                ShowError("Eroare completare plată: " + ex.Message);
            }
        }

        private void CreeazaOfertaOnClick(object param)
        {
            try
            {
                Int32 _selectedId;
                switch (CurrentTipExcursie)
                {
                    case "Sejur":
                        _selectedId = _selectedSejur.IdExcursie;
                        SelectedTipExcursie = "Sejur";
                        SelectedId = _selectedId.ToString();
                        break;
                    case "Croaziera":
                        _selectedId = _selectedCroaziera.IdExcursie;
                        SelectedTipExcursie = "Croaziera";
                        SelectedId = _selectedId.ToString();
                        break;
                    case "Circuit":
                        _selectedId = _selectedCircuit.IdExcursie;
                        SelectedTipExcursie = "Circuit";
                        SelectedId = _selectedId.ToString();
                        break;
                    default:
                        throw new Exception("Oferta nu a fost gasita");
                }
                OpenDialogHostCommand.Execute(param);
            }
            catch (Exception ex)
            {
                ShowError("Eroare creare ofertă: " + ex.Message);
            }
        }

        private void ResetEnteredData()
        {
            SelectedSezon = "Iarna";
            SelectedTipCazare = "Hotel";
            SelectedNrStele = 3;
            SelectedTransport = "Fără Transport";
            SelectedCategorieVas = "Croaziera";
            SelectedId = null;
            EnteredTara = "";
            EnteredLocalitate = "";
            EnteredDenumire = "";
            EnteredFacilitati = "";
            EnteredPretTransport = "";
            EnteredPretCazare = "";
            EnteredTraseu = "";
            EnteredVizite = "";
            EnteredTipOferta = "";
            EnteredReducere = "";
            EnteredNume = "";
            EnteredPrenume = "";
            EnteredCNP = "";
            EnteredAdresa = "";
            EnteredTelefon = "";
            ItemPretFinal = "0";
            EnteredAdulti= "0";
            EnteredCopii = "0";
            EnteredStartDate = DateTime.Now;
            EnteredEndDate = DateTime.Now;
            _totalFaraReducere = 0;
            TotalIncasat = 0;
            PierderiPeReduceri = 0;
            ExcursiiAchitateComplet = 0;
            ExcursiiAchitateAvans = 0;
            ExcursiiAnulate = 0;
            CalculateNights();
        }

        private void ResetRezervareData()
        {
            SelectedClient = null;
            AchitatAvans = false;
            AchitatPretTotal = false;
            EnteredAdulti = "0";
            EnteredCopii = "0";
        }

        private void ResetSelections()
        {
            SelectedExcursie = null;
            SelectedClient = null;
            SelectedSejur = null;
            SelectedCroaziera = null;
            SelectedCircuit = null;
            SelectedIncasare = null;
            SelectedOferta = null;
        }

        private void ResetEnteredClientData()
        {
            EnteredNume = "";
            EnteredPrenume = "";
            EnteredCNP = "";
            EnteredAdresa = "";
            EnteredTelefon = "";
        }

        private void TurnOffGridVisibility()
        {
            IsAddSejurDialogHostOpen= false;
            IsAddCircuitDialogHostOpen= false;
            IsAddClientDialogHostOpen= false;
            IsAddCroazieraDialogHostOpen= false;
            IsAddOfertaDialogHostOpen= false;
        }

        private void CalculateNights()
        {
            try
            {
                var frm = EnteredStartDate < EnteredEndDate ? EnteredStartDate : EnteredEndDate;
                var to = EnteredStartDate < EnteredEndDate ? EnteredEndDate : EnteredStartDate;
                var totalNights = (int)(to - frm).TotalDays + 1;

                CalculatedNights = totalNights.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception("Eroare adăugare client: " + ex.Message);
            }
        }

        private void CalculateReducere()
        {
            try
            {
                Int32 reducere = 0;
                if (_selectedOferta != null)
                    reducere += _selectedOferta.Reducere;
                if (_selectedClient != null && _selectedClient.ClientTop == "Da")
                    reducere += 2;
                Reducere = reducere.ToString();
                CalculatePretTotal();
            }
            catch (Exception ex)
            {
                throw new Exception("Eroare adăugare client: " + ex.Message);
            }
        }

        private void CalculatePretTotal()
        {
            try
            {

                if (SelectedExcursie == null) return;
                double pretAdulti = (SelectedExcursie.PretCazare + SelectedExcursie.PretTransport) * Int32.Parse(EnteredAdulti);
                double pretCopii = (SelectedExcursie.PretCazare * 0.5 + SelectedExcursie.PretTransport) * Int32.Parse(EnteredCopii);

                _totalFaraReducere = (pretAdulti + pretCopii) - (pretAdulti + pretCopii) * (Int32.Parse(Reducere) != 0 ? Int32.Parse(Reducere) : 1) / 100;
                _totalFaraReducere = Math.Round(_totalFaraReducere, 2);
                double pretTotal = _totalFaraReducere - _totalFaraReducere * 5 / 100;
                PretTotalCalculated = String.Format("{0:0.##}", pretTotal);
                PretAvansCalculated = String.Format("{0:0.##}", (_totalFaraReducere * 20 / 100));
            }
            catch (Exception ex)
            {
                throw new Exception("Eroare adăugare client: " + ex.Message);
            }
        }

        private void SetIDs()
        {
            try
            {
                SelectedId = null;
                IDs.Clear();
                if (TipSejurSelected)
                {
                    RefreshSejururiData();
                    foreach (var sejur in SejururiList)
                        IDs.Add(sejur.IdSejur.ToString());
                }
                else if (TipCroazieraSelected)
                {
                    RefreshCroaziereData();
                    foreach (var croaziera in CroaziereList)
                        IDs.Add(croaziera.IdCroaziera.ToString());
                }
                else if (TipCircuitSelected)
                {
                    RefreshCircuiteData();
                    foreach (var circuit in CircuiteList)
                        IDs.Add(circuit.IdCircuit.ToString());
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Eroare adăugare client: " + ex.Message);
            }
        }

        private void UpdateTariLists()
        {
            try
            {
                TariSejururi.Clear();
                foreach (var sejur in SejururiList)
                    if (!TariSejururi.Contains(sejur.Tara))
                        TariSejururi.Add(sejur.Tara);
                TariCroaziere.Clear();
                foreach (var croaziera in CroaziereList)
                    if (!TariCroaziere.Contains(croaziera.Tara))
                        TariCroaziere.Add(croaziera.Tara);
                TariCircuite.Clear();
                foreach (var circuit in CircuiteList)
                    if (!TariCircuite.Contains(circuit.Tara))
                        TariCircuite.Add(circuit.Tara);
            }
            catch (Exception ex)
            {
                throw new Exception("Eroare adăugare client: " + ex.Message);
            }
        }

        private void ClearSearchTexts()
        {
            SearchTextSejur = "";
            SearchTextCroaziera = "";
            SearchTextCircuit = "";
            SearchTextOferta = "";
            SearchTextClient = "";
        }

        private void ClientTopUpdate()
        {
            try
            {
                bool changesMade = false;
                foreach (var client in ClientiList)
                {
                    if (client.ClientTop == "Nu")
                    {
                        if (IncasariList.Where(x => x.IdClient == client.IdClient && x.Status != "Rezervare anulata" && x.Status != "Avans achitat").ToList().Count >= 2)
                        {
                            CreateSqlProcedure("SetTopClient", new List<SqlParameter>() { new SqlParameter("@clientId", SqlDbType.Int) { Value = client.IdClient } });
                            _sqlCommand.ExecuteNonQuery();
                            changesMade = true;
                        }
                    }

                }
                if (changesMade)
                    RefreshClientiData();
            }
            catch (Exception ex)
            {
                throw new Exception("Eroare setare top-clienți: " + ex.Message);
            }
        }

        private void SetAvailableDates()
        {
            SelectedAvailableDate = null;
            AvailableDates.Clear();
            if (SelectedTipRaport == "Anual") {
                foreach (var incasare in IncasariList)
                {
                    if (!AvailableDates.Contains(incasare.DataIncasarii.Year.ToString()))
                        AvailableDates.Add(incasare.DataIncasarii.Year.ToString());
                }
            }
            else
            {
                foreach (var incasare in IncasariList)
                {
                    if (!AvailableDates.Contains(incasare.DataIncasarii.Month.ToString()))
                        AvailableDates.Add(incasare.DataIncasarii.Month.ToString());
                }
            }
        }

        private void CalculateTotals()
        {
            TotalIncasat = 0;
            PierderiPeReduceri = 0;
            ExcursiiAchitateComplet = 0;
            ExcursiiAchitateAvans = 0;
            ExcursiiAnulate = 0;
            if(SelectedTipRaport == "Anual")
            {
                foreach (var incasare in IncasariList)
                {
                    if (incasare.DataIncasarii.Year.ToString() == SelectedAvailableDate)
                    {
                        switch (incasare.Status)
                        {
                            case "Complet achitat":
                                ExcursiiAchitateComplet++;
                                break;
                            case "Avans achitat":
                                ExcursiiAchitateAvans++;
                                break;
                            case "Rezervare anulata":
                                ExcursiiAnulate++;
                                break;
                            default:
                                break;
                        }
                        TotalIncasat += incasare.ValoareTotala;
                        if(incasare.Reducere > 0)
                            PierderiPeReduceri += ((incasare.ValoareTotala * 100) / (100 - incasare.Reducere)) - incasare.ValoareTotala;
                    }
                }
               
            }
            else
            {
                foreach (var incasare in IncasariList)
                {
                    if (incasare.DataIncasarii.Month.ToString() == SelectedAvailableDate && incasare.DataIncasarii.Year.ToString() == DateTime.Now.Year.ToString())
                    {
                        switch (incasare.Status)
                        {
                            case "Complet achitat":
                                ExcursiiAchitateComplet++;
                                break;
                            case "Avans achitat":
                                ExcursiiAchitateAvans++;
                                break;
                            case "Rezervare anulata":
                                ExcursiiAnulate++;
                                break;
                            default:
                                break;
                        }
                        TotalIncasat += incasare.ValoareTotala;
                        if (incasare.Reducere > 0)
                            PierderiPeReduceri += ((incasare.ValoareTotala * 100) / (100 - incasare.Reducere)) - incasare.ValoareTotala;
                    }
                }
            }

            TotalIncasat = Math.Round(TotalIncasat, 2);
            PierderiPeReduceri = Math.Round(PierderiPeReduceri, 2);
        }

        private void ShowError(string msg)
        {
            new CustomMessageBox(msg, MessageType.Error, MessageButtons.Ok) { Owner = Application.Current.MainWindow }.ShowDialog();
        }
    }
}
