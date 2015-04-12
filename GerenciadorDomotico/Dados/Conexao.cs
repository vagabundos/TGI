using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Odbc;
using MySql.Data.MySqlClient;
using System.Data.Common;

namespace Dados
{
    public class Conexao
    {
        #region Propriedades
        public DbConnection _Connection;
        public Transacao _objTransacao;
        #endregion

        #region Construtores
        public Conexao(string sConnectionString)
        {
            _Connection = new MySqlConnection(sConnectionString);
        }
        #endregion

        #region Métodos
        public bool AbreConexao()
        {
            bool bRetorno = false;

            if (_Connection.State != ConnectionState.Open)
            {
                _Connection.Open();
                bRetorno = true;
            }

            return bRetorno;
        }

        public void FechaConexao()
        {
            if (_Connection != null)
            {
                if (_Connection.State != ConnectionState.Closed)
                    _Connection.Close();

                if (_objTransacao != null)
                    _objTransacao._objConexao = null;

                _Connection.Dispose();
                _Connection = null;
            }
        }
        #endregion
    }
}
