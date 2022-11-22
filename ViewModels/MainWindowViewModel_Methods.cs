using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PS2AProject.Views;
using System.Windows;

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
                //refresh ClientiTable
                CreateSqlCommand("select * from [Sejururi]");
                _sqlCommand.ExecuteNonQuery();
                SqlDataReader sqlDataReader = _sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {

                }

                sqlDataReader.Close();
            }
            catch (Exception ex)
            {
                ShowError("Eroare actualizare clienti: " + ex.Message);
            }
        }

        private void ShowError(string msg)
        {
            new CustomMessageBox(msg, MessageType.Error, MessageButtons.Ok) { Owner = Application.Current.MainWindow }.ShowDialog();
        }
    }
}
