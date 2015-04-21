using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using MySql.Data.MySqlClient;

namespace Dados
{
    public class GerenciadorDB : IDisposable
    {
        #region Propriedades

        /// <summary>
        /// Nome do NameSpace do banco de dados
        /// </summary>
        public static string NameSpaceDB
        {
            get
            {
                return "homeon";
            }
        }

        public static string _Server { get; set; }
        public static string _Port { get; set; }

        private string sConnectionString
        {
            get
            {
                return string.Format("Server={0};Port={1};Database={2};Uid=AppUser;Pwd=AppUser;", _Server, _Port, NameSpaceDB);
            }
        }
        private Conexao _objConexao;
        private Transacao _objTransacao;
        private bool bConfirmado;
        private bool bAbriuConexao;
        private bool bAbriuTransacao;
        private bool bDisposed;
        #endregion

        #region Construtores - Classe não pode ser instanciada
        /// <summary>
        /// Devolve Conexão aberta para a base de dados.
        /// Deve ser utilizado dentro da clausula using(Conexao xpto = getConexao(false))
        /// </summary>
        /// <param name="bTransacionada">Define se deve ser aberta transação na Conexão solicitada</param>
        /// <returns></returns>
        public GerenciadorDB(bool bAbreTransacao)
            : this(bAbreTransacao, null)
        {
        }

        public GerenciadorDB(bool bAbreTransacao, Conexao objConexao)
        {
            if (objConexao == null)
                objConexao = new Conexao(sConnectionString);

            _objConexao = objConexao;

            bDisposed = false;
            bConfirmado = false;
            bAbriuTransacao = false;
            bAbriuConexao = _objConexao.AbreConexao();

            if (bAbreTransacao)
            {
                if (_objConexao._objTransacao == null)
                {
                    _objTransacao = new Transacao();
                    _objTransacao.AbreTransacao(_objConexao);
                    bAbriuTransacao = true;
                }
            }
        }
        #endregion

        #region Métodos
        public void ConfirmaTransacao()
        {
            if (bDisposed)
                throw new ObjectDisposedException("GerenciadorDB", "Acionado método ConfirmaTransacao para objeto já disposed");
            bConfirmado = true;
        }

        public void Dispose()
        {
            try
            {
                // Valida Transação
                if (_objTransacao != null)
                {
                    // Se ocorreu erro, faz RollBack
                    if (!bConfirmado)
                        _objTransacao.RollBack();
                    // Caso sucesso, faz commit apenas se abriu transação
                    else if (bAbriuTransacao)
                        _objTransacao.Commit();
                }
            }
            finally
            {
                // Valida Conexão
                if (_objConexao != null)
                {
                    if (bAbriuConexao) _objConexao.FechaConexao();
                }

                _objTransacao = null;
                _objConexao = null;
            }
        }

        public DbCommand getCommand()
        {
            return getCommand("");
        }

        public DbCommand getCommand(string sSQL)
        {
            return new MySqlCommand(sSQL, ((MySqlConnection)_objConexao._Connection), _objTransacao != null ? ((MySqlTransaction)_objTransacao._Transaction) : null);
        }

        public DbDataAdapter getAdapter(DbCommand objCommand, bool bBuilder)
        {
            MySqlCommand mSqlCommand = (MySqlCommand)objCommand;
            DbDataAdapter objAdapter = new MySqlDataAdapter(mSqlCommand);

            if (bBuilder)
            {
                MySqlCommandBuilder builder = new MySqlCommandBuilder((MySqlDataAdapter)objAdapter);
            }

            return objAdapter;
        }

        public DbParameter getParameter()
        {
            MySqlParameter mSqlParameter = new MySqlParameter();
            return mSqlParameter;
        }
        #endregion
    }
}
