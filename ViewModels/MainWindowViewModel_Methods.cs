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
                CreateSqlCommand("SELECT * FROM [Sejururi]" +
                    (!String.IsNullOrEmpty(_selectedSejurSezon) ? "where Sezon='" + _selectedSejurSezon + "'" : ""));
                _sqlCommand.ExecuteNonQuery();
                SqlDataReader sqlDataReader = _sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    SejurModel sejurModel = new SejurModel((int)sqlDataReader["IdSejur"], (string)sqlDataReader["Sezon"], (string)sqlDataReader["Tara"],
                        (string)sqlDataReader["Localitate"], (DateTime)sqlDataReader["InceputPerioada"], (DateTime)sqlDataReader["SfarsitPerioada"],
                        (Byte)sqlDataReader["NumarNopti"], (string)sqlDataReader["TipCazare"], (string)sqlDataReader["Denumire"],
                        (Byte)sqlDataReader["NrStele"], (string)sqlDataReader["Mese"], (string)sqlDataReader["Facilitati"],
                        (string)sqlDataReader["Transport"], (Double)sqlDataReader["PretTransport"], (Double)sqlDataReader["PretCazare"]);

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
                CreateSqlCommand("SELECT * FROM [Croaziere]" +
                    (!String.IsNullOrEmpty(_selectedCroazieraSezon) ? "where Sezon='" + _selectedCroazieraSezon + "'" : ""));
                _sqlCommand.ExecuteNonQuery();
                SqlDataReader sqlDataReader = _sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    CroazieraModel croazieraModel = new CroazieraModel((Int32)sqlDataReader["IdCroaziera"], (string)sqlDataReader["Sezon"],
                         (string)sqlDataReader["Tara"], (string)sqlDataReader["Traseu"], (DateTime)sqlDataReader["InceputPerioada"],
                         (DateTime)sqlDataReader["SfarsitPerioada"], (string)sqlDataReader["CategorieVas"], (string)sqlDataReader["Facilitati"],
                         (string)sqlDataReader["ViziteIncluse"], (double)sqlDataReader["PretTransport"], (double)sqlDataReader["PretCazare"]);

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
                CreateSqlCommand("SELECT * FROM [Circuite]" +
                    (!String.IsNullOrEmpty(_selectedCircuitSezon) ? "where Sezon='" + _selectedCircuitSezon + "'" : ""));
                _sqlCommand.ExecuteNonQuery();
                SqlDataReader sqlDataReader = _sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    CircuitModel circuitModel = new CircuitModel((Int32)sqlDataReader["IdCircuit"], (string)sqlDataReader["Sezon"],
                        (string)sqlDataReader["Tara"], (string)sqlDataReader["Traseu"], (DateTime)sqlDataReader["InceputPerioada"],
                        (DateTime)sqlDataReader["SfarsitPerioada"], (Byte)sqlDataReader["NumarNopti"],
                        (string)sqlDataReader["FacilitatiCazare"], (string)sqlDataReader["ViziteIncluse"],
                        (string)sqlDataReader["Mese"], (Double)sqlDataReader["PretTransport"], (Double)sqlDataReader["PretCazare"]);

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
                        (Double)sqlDataReader["PretInitial"], (Double)sqlDataReader["PretFinal"]) ;

                    OferteList.Add(ofertaModel);
                }

                sqlDataReader.Close();
            }
            catch (Exception ex)
            {
                ShowError("Eroare actualizare oferte: " + ex.Message);
            }
        }

        private void RefreshClientiData()
        {
            try
            {
                CircuiteList.Clear();
                CreateSqlCommand("SELECT * FROM [Clienti]");
                _sqlCommand.ExecuteNonQuery();
                SqlDataReader sqlDataReader = _sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    ClientModel clientModel = new ClientModel((Int32)sqlDataReader["IdClient"], (string)sqlDataReader["Nume"],
                        (string)sqlDataReader["Prenume"], (string)sqlDataReader["CNP"], (string)sqlDataReader["Adresa"],
                        (string)sqlDataReader["NrTelefon"]);

                    ClientiList.Add(clientModel);
                }

                sqlDataReader.Close();
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
                CircuiteList.Clear();
                CreateSqlCommand("SELECT * FROM [Incasari]");
                _sqlCommand.ExecuteNonQuery();
                SqlDataReader sqlDataReader = _sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    IncasareModel incasareModel = new IncasareModel((Int32)sqlDataReader["IdIncasare"], (Int32)sqlDataReader["IdClient"],
                        (string)sqlDataReader["TipExcursie"], (Int32)sqlDataReader["IdExcursie"], (Byte)sqlDataReader["Adulti"],
                        (Byte)sqlDataReader["Copii"], (Double)sqlDataReader["ValoareTotala"], (Double)sqlDataReader["ValoareIncasata"],
                        (Byte)sqlDataReader["Reducere"]);

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
                        break;
                    case "Croaziere":
                        RefreshCroaziereData();
                        break;
                    case "Circuite":
                        RefreshCircuiteData();
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
                    "[Transport], [PretTransport],[PretCazare]) VALUES('" +
                    SelectedSezon + "','" + EnteredTara + "','" + EnteredLocalitate + "','" +
                    EnteredStartDate.Date.ToString() + "','" + EnteredEndDate.Date.ToString() + "','" +
                    CalculatedNights + "','" + SelectedTipCazare + "','" + EnteredDenumire + "','" +
                    SelectedNrStele + "','" + SelectedMese + "','" + EnteredFacilitati + "','" +
                    SelectedTransport + "'," + EnteredPretTransport + "," + EnteredPretCazare + ")");
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
                    "[CategorieVas],[Facilitati],[ViziteIncluse],[PretTransport],[PretCazare])" +
                    " VALUES ('" +
                    SelectedSezon + "','" + EnteredTara + "','" + EnteredTraseu + "','" +
                    EnteredStartDate.Date.ToString() + "','" + EnteredEndDate.Date.ToString() + "','" +
                    SelectedCategorieVas + "','" + EnteredFacilitati + "','" + EnteredVizite + "'," +
                    EnteredPretTransport + "," + EnteredPretCazare + ")"
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
                    "[NumarNopti],[FacilitatiCazare],[ViziteIncluse],[Mese],[PretTransport] ,[PretCazare])" +
                    " VALUES('" +
                    SelectedSezon + "','" + EnteredTara + "','" + EnteredTraseu + "','" + EnteredStartDate.Date.ToString() + "','" +
                    EnteredEndDate.Date.ToString() + "','" + CalculatedNights + "','"  + EnteredFacilitati + "','" + EnteredVizite + "','"
                    + SelectedMese + "'," + EnteredPretTransport + "," + EnteredPretCazare + ")");
                _sqlCommand.ExecuteNonQuery();
                ResetEnteredData();
            }
            catch (Exception ex)
            {
                throw new Exception("Eroare adăugare circuit: " + ex.Message);
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
            EnteredStartDate = DateTime.Now;
            EnteredEndDate = DateTime.Now;
            CalculateNights();
        }

        private void CalculateNights()
        {

            var frm = EnteredStartDate < EnteredEndDate ? EnteredStartDate : EnteredEndDate;
            var to = EnteredStartDate < EnteredEndDate ? EnteredEndDate : EnteredStartDate;
            var totalNights = (int)(to - frm).TotalDays + 1;

            CalculatedNights = totalNights.ToString();
        }

        private void SetIDs()
        {
            SelectedId = null;
            IDs.Clear();
            if (TipSejurSelected)
            {
                RefreshSejururiData();
                foreach(var sejur in SejururiList)
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

        private void ShowError(string msg)
        {
            new CustomMessageBox(msg, MessageType.Error, MessageButtons.Ok) { Owner = Application.Current.MainWindow }.ShowDialog();
        }
    }
}
