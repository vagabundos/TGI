using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using MySql.Data.MySqlClient;

namespace Dados
{
    public class Transacao
    {
        #region Propriedades
        public Conexao _objConexao;
        public DbTransaction _Transaction;
        #endregion

        #region Construtores
        public Transacao()
        {

        }
        #endregion

        #region Métodos
        public void AbreTransacao(Conexao objConexao)
        {
            this._objConexao = objConexao;
            this._Transaction = objConexao._Connection.BeginTransaction();
            objConexao._objTransacao = this;
        }

        public void Commit()
        {
            if (_Transaction != null)
            {
                _Transaction.Commit();
                _Transaction.Dispose();
                _Transaction = null;
                _objConexao._objTransacao = null;
            }
            else
            {
                throw new Exception("Solicitado Commit sem Transação definida.");
            }
        }

        public void RollBack()
        {
            if(_Transaction != null)
            {
                _Transaction.Rollback();
                _Transaction.Dispose();
                _Transaction = null;
                _objConexao._objTransacao = null;
            }
        }
        #endregion
    }
}
