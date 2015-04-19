using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Data;
using System.Data.Common;
using Dados;
using Biblioteca.Modelo;
using Biblioteca.Modelo.Atributos;

namespace Biblioteca.Controle
{
    public class controlBase<M> 
        where M : ModeloBase<M>, new()
    {
        #region Propriedades
        private string NomeTabela {get;set;}
        private string NomeEntidade { get; set; }
        private Modelo.Atributos.AtributoClasse atbClasse { get; set; }
        #endregion

        #region Construtores
        public controlBase()
        {
            // AtributoClasse do objeto
            object[] atributos = typeof(M).GetCustomAttributes(typeof(Modelo.Atributos.AtributoClasse), true);

            foreach (object atrib in atributos)
            {
                if (atrib is Modelo.Atributos.AtributoClasse)
                {
                    atbClasse = (Modelo.Atributos.AtributoClasse)atrib;
                    break;
                }
            }

            NomeEntidade = typeof(M).Name;
            NomeTabela = atbClasse.NomeTabela;
        }
        #endregion

        #region Métodos

        #region Operações
        /// <summary>
        /// Carrega todos objetos Modelo da tabela
        /// </summary>
        public List<M> LoadTodos(GerenciadorDB mngBD)
        {
            string sSQL = string.Format("SELECT * FROM {0}", NomeTabela);

            using (DbCommand cmd = mngBD.getCommand(sSQL))
            {
                return ListObjetosCarregados(ExecutaQuery(cmd));
            }
        }

        public bool Salva(ModeloBase<M> objModelo, GerenciadorDB mngBD)
        {
            bool bRetorno = false;
            string sDetalhesLog = string.Empty;

            if(objModelo.Status == ModeloBase<M>.ObjetoStatus.Novo)
            {
                // Insert
                Insert(getDicionarioColValores(objModelo), mngBD, ref sDetalhesLog);
            }
            else if (objModelo.Status == ModeloBase<M>.ObjetoStatus.Editado)
            {
                // Update
                Update(getDicionarioColValores(objModelo), getDicionarioColValores(objModelo._objetoOriginal), mngBD, ref sDetalhesLog);
            }
            else
            {
                throw new Exception(string.Format("Solicitado salvamento para objeto ModeloBase com STATUS inválido. Valor recebido: {0}",
                    Enum.GetName(typeof(ModeloBase<M>.ObjetoStatus), objModelo.Status)));
            }

            return bRetorno;
        }

        public bool Apaga(ModeloBase<M> objModelo, GerenciadorDB mngBD)
        {
            bool bRetorno = false;
            string sDetalhesLog = string.Empty;

            if (objModelo.Status != ModeloBase<M>.ObjetoStatus.Novo)
            {
                // Delete
                Delete(getDicionarioColValores(objModelo._objetoOriginal), mngBD, ref sDetalhesLog);
                bRetorno = true;
            }
            else
            {
                throw new Exception(string.Format("Solicitado exclusão para objeto ModeloBase com STATUS inválido. Valor recebido: {0}",
                    Enum.GetName(typeof(ModeloBase<M>.ObjetoStatus), objModelo.Status)));
            }

            return bRetorno;
        }
        #endregion

        #region Auxiliares
        /// <summary>
        /// Devolve dicionário com Coluna (base de dados) e respectivo valor da propriedade
        /// </summary>
        private static Dictionary<string, object> getDicionarioColValores(ModeloBase<M> objModelBase)
        {
            Dictionary<string, object> dicProps = new Dictionary<string, object>();
            PropertyInfo[] props = getObjectProperties();

            // Varre as propriedades do modelo
            foreach (System.Reflection.PropertyInfo prop in props)
            {
                if (prop.PropertyType != null && prop.CanWrite)
                {
                    AtributoPropriedade atbc = null;
                    object[] atributos = prop.GetCustomAttributes(typeof(AtributoPropriedade), true);

                    // Utiliza o AtributoPropriedade para obter o nome da coluna na Base de dados
                    foreach (object item in atributos)
                    {
                        if (item is AtributoPropriedade)
                        {
                            atbc = (AtributoPropriedade)item;
                            break;
                        }
                    }

                    object objValue = prop.GetValue(objModelBase);

                    // Se nao tem NomeColuna, o nome é o mesmo da propriedade.
                    if (atbc != null && !string.IsNullOrEmpty(atbc.NomeColuna))
                        dicProps.Add(atbc.NomeColuna.ToUpper(), objValue);
                    else
                        dicProps.Add(prop.Name.ToUpper(), objValue);
                }
            }

            return dicProps;
        }

        /// <summary>
        /// Devolve dicionário com nome da coluna (base de dados) e respectivo PropertyInfo do objeto
        /// </summary>
        private static Dictionary<string, PropertyInfo> getDicionarioColPropInfo(ModeloBase<M> objModelBase)
        {
            Dictionary<string, PropertyInfo> dicProps = new Dictionary<string, PropertyInfo>();
            PropertyInfo[] props = getObjectProperties();

            // Varre as propriedades do modelo
            foreach (System.Reflection.PropertyInfo prop in props)
            {
                if (prop.PropertyType != null && prop.CanWrite)
                {
                    AtributoPropriedade atbc = null;
                    object[] atributos = prop.GetCustomAttributes(typeof(AtributoPropriedade), true);

                    // Utiliza o AtributoPropriedade para obter o nome da coluna na Base de dados
                    foreach (object item in atributos)
                    {
                        if (item is AtributoPropriedade)
                        {
                            atbc = (AtributoPropriedade)item;
                            break;
                        }
                    }

                    // Se nao tem NomeColuna, o nome é o mesmo da propriedade.
                    if (atbc != null && !string.IsNullOrEmpty(atbc.NomeColuna))
                        dicProps.Add(atbc.NomeColuna.ToUpper(), prop);
                    else
                        dicProps.Add(prop.Name.ToUpper(), prop);
                }
            }

            return dicProps;
        }

        private static PropertyInfo[] getObjectProperties()
        {
            Type objectType = typeof(M);
            return objectType.GetProperties(BindingFlags.Public | BindingFlags.Instance);
        }

        /// <summary>
        /// Método para construir lista de objeto Modelos com dados da base (Data base)
        /// </summary>
        private static List<M> ListObjetosCarregados(List<Dictionary<string, object>> Linhas)
        {
            List<M> lstTodos = new List<M>();

            // obtem a lista de propriedade do objeto
            M obj = new M();
            Dictionary<string, System.Reflection.PropertyInfo> dicPropriedades = getDicionarioColPropInfo(obj);

            foreach (Dictionary<string, object> linha in Linhas)
            {
                obj = new M();
                obj.CarregaObjeto(linha, dicPropriedades);
                lstTodos.Add(obj);
            }

            return lstTodos;
        }

        /// <summary>
		/// Devolve DBParameter com base no nome (string) e no valor (object);
		/// </summary>
		private DbParameter Parametro(KeyValuePair<string, object> item, GerenciadorDB mngDB)
		{
            // Nesse momento estamos utilizando MySqlParameter, deixa todo o encapsulamento dentro da classe GerenciadorBD
			DbParameter paramRet = mngDB.getParameter();

			if (item.Value != null)
			{
                // Associa valor ao DBParameter
                paramRet.Value = item.Value;
                
                // Verifica Type da propriedade
                Type tipo = item.Value.GetType();
				paramRet.ParameterName = item.Key + Guid.NewGuid().ToString("N");

                if (item.Value.GetType() == typeof(string))
                {
                        paramRet.DbType = DbType.String;
                    
                        //if (string.IsNullOrEmpty(item.Value.ToString()))
                        //    paramRet.Value = DBNull.Value;
                }
                else if (item.Value.GetType() == typeof(decimal))
                    paramRet.DbType = DbType.Decimal;
                else if (item.Value.GetType() == typeof(int))
                    paramRet.DbType = DbType.Int32;
                else if (item.Value.GetType() == typeof(DateTime))
                {
                    if (item.Value is DateTime && ((DateTime)item.Value).Equals(((DateTime)item.Value).Date))
                        paramRet.DbType = DbType.Date;
                    else
                        paramRet.DbType = DbType.DateTime;
                }
                else if (item.Value.GetType() == typeof(bool))
                    paramRet.DbType = DbType.Boolean;
                else if (item.Value.GetType() == typeof(float) || item.Value.GetType() == typeof(Double))
                    paramRet.DbType = DbType.Double;
			}
			else
				paramRet.Value = DBNull.Value;
            
            // Retorna DBParameter
			return paramRet;
		}
        #endregion

        #region Banco de Dados
        private List<Dictionary<string, object>> ExecutaQuery(System.Data.Common.DbCommand cmd)
        {
            List<Dictionary<string, object>> Linhas = new List<Dictionary<string, object>>();

            try
            {
                if (cmd.CommandText.Contains("CALL "))
                    cmd.CommandType = CommandType.StoredProcedure;
                else
                    cmd.CommandType = CommandType.Text;

                cmd.CommandTimeout = 1800;

                using (System.Data.IDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Dictionary<string, object> linha = new Dictionary<string, object>();

                        // Colunas
                        for (int i = 0; i < reader.FieldCount; i++)
                            linha.Add(reader.GetName(i), reader.GetValue(i) == DBNull.Value ? null : reader.GetValue(i));

                        // Adiciona Dictionary da Linha
                        Linhas.Add(linha);
                    }
                }
            }
            catch (Exception ex)
            {
                string txtComando = Util.DevolveStringCommand(cmd);
                throw new Exception(string.Format("Erro ao executar comando no banco de dados.\r\nTexto: {0}\r\nDetalhes: {1}", txtComando, ex.Message), ex);
            }

            return Linhas;
        }

        /// <summary>
        /// Exclui um objeto Modelo na Base de Dados
        /// </summary>
        private void Delete(Dictionary<string, object> DadosOriginal, GerenciadorDB mngBD, ref string sDetalhesLog)
        {
            sDetalhesLog += string.Format("{0} apagado(a). Detalhes:\r\n", NomeEntidade);

            using (System.Data.Common.DbCommand cmd = mngBD.getCommand())
            {
                string sSQL = string.Format("DELETE FROM {0}.{1} WHERE ", GerenciadorDB.NameSpaceDB, NomeTabela);

                // inclui todos os parametros no where para verificar concorrencia
                foreach (KeyValuePair<string, object> itemOriginal in DadosOriginal)
                {
                    // Verifica se valor é NULL
                    string VerifNull = itemOriginal.Value == null || (itemOriginal.Value is string && string.IsNullOrEmpty((string)itemOriginal.Value)) ||
                        (itemOriginal.Value is bool && (bool)itemOriginal.Value == false) || (itemOriginal.Value is int && (int)itemOriginal.Value == 0) ? "1" : "0";

                    // SQL do parâmetro
                    sSQL += "((1=" + VerifNull + " AND " + itemOriginal.Key + " is NULL) OR (" + itemOriginal.Key + "=?" + (VerifNull == "1" && itemOriginal.Value is string ? " OR " + itemOriginal.Key + "=\'\'" : "") + ")) AND ";

                    // Adiciona parâmetro
                    cmd.Parameters.Add(Parametro(itemOriginal, mngBD));

                    // descrição LOG
                    sDetalhesLog += itemOriginal.Key + ": [" + (itemOriginal.Value == null ? "NULL" : itemOriginal.Value.ToString()) + "]\r\n";
                }

                sSQL = sSQL.Substring(0, sSQL.Length - 5);

                cmd.CommandText = sSQL;
                cmd.Prepare();

                // Executa
                int iAffectedRows = cmd.ExecuteNonQuery();

                if (!iAffectedRows.Equals(1))
                {
                    throw new Exception(string.Format("Erro ao executar delete. Não foi afetado o número esperado de linhas.\r\nLinhas afetadas: {0}.\r\nDetalhes: {1}.", iAffectedRows, sDetalhesLog));
                }
            }
        }

        /// <summary>
        /// Atualiza objeto Modelo na Base de Dados
        /// </summary>
        public void Update(Dictionary<string, object> DadosAlterados, Dictionary<string, object> DadosOriginal, GerenciadorDB mngBD, ref string sDetalhesLog)
        {
            sDetalhesLog += string.Format("{0} editado(a). Detalhes:\r\n", this.NomeEntidade);

            using (DbCommand cmd = mngBD.getCommand())
            {
                string sSQL = string.Format("UPDATE {0}.{1} SET ", GerenciadorDB.NameSpaceDB, NomeTabela);

                // Seta com os parametros atuais
                foreach (KeyValuePair<string, object> item in DadosAlterados)
                {
                    // Não faz update de campos não alterados
                    if (
                        (item.Value != null && DadosOriginal != null && DadosOriginal.ContainsKey(item.Key) && DadosOriginal[item.Key] != null && item.Value.Equals(DadosOriginal[item.Key])) ||
                        (item.Value == null && (DadosOriginal == null || !DadosOriginal.ContainsKey(item.Key) || DadosOriginal[item.Key] == null))
                        )
                        continue;

                    if ((item.Value == null && DadosOriginal[item.Key] != null) ||
                        (item.Value != null && DadosOriginal[item.Key] == null) ||
                        ((item.Value != null && DadosOriginal[item.Key] != null) && (!item.Value.Equals(DadosOriginal[item.Key])))
                        )
                    {
                        sDetalhesLog += item.Key + ": [";
                        if (DadosOriginal != null && DadosOriginal.ContainsKey(item.Key))
                            sDetalhesLog += (DadosOriginal[item.Key] == null ? "NULL" : DadosOriginal[item.Key].ToString()) + "] --> [";
                        sDetalhesLog += (item.Value == null ? "NULL" : item.Value.ToString()) + "]\r\n";
                    }

                    // SQL do parâmetro, valor novo
                    sSQL += item.Key + "=?,";

                    // Adiciona parâmetro
                    cmd.Parameters.Add(Parametro(item, mngBD));
                }

                //se nenhum campo deve ser alterado, retorna sem executar
                if (cmd.Parameters.Count == 0)
                    return;

                sSQL = sSQL.Substring(0, sSQL.Length - 1) + " Where ";

                // Verifica parametros originais para concorrencia
                // Ou seja, coloca valores anteriores na condição, pois qualquer se tabela está diferente do esperado gera Exception
                foreach (KeyValuePair<string, object> itemOriginal in DadosOriginal)
                {
                    string VerifNull = itemOriginal.Value == null || (itemOriginal.Value is string && string.IsNullOrEmpty((string)itemOriginal.Value)) ||
                        (itemOriginal.Value is bool && (bool)itemOriginal.Value == false) || (itemOriginal.Value is int && (int)itemOriginal.Value == 0) ? "1" : "0";

                    // SQL do parâmetro valor anterior (condição)
                    sSQL += "((1=" + VerifNull + " AND " + itemOriginal.Key + " is NULL) OR (" + itemOriginal.Key + "=?" + (VerifNull == "1" && itemOriginal.Value is string ? " OR " + itemOriginal.Key + "=\'\'" : "") + ")) AND ";

                    // Adiciona parâmetro
                    cmd.Parameters.Add(Parametro(itemOriginal, mngBD));
                }

                sSQL = sSQL.Substring(0, sSQL.Length - 5);

                cmd.CommandText = sSQL;
                cmd.Prepare();

                // Executa
                int iAffectedRows = cmd.ExecuteNonQuery();

                if (!iAffectedRows.Equals(1))
                {
                    throw new Exception(string.Format("Erro ao executar delete. Não foi afetado o número esperado de linhas.\r\nLinhas afetadas: {0}.\r\nDetalhes: {1}.", iAffectedRows, sDetalhesLog));
                }
            }
        }

        /// <summary>
        /// Insere objeto Modelo na Base de Dados
        /// </summary>
        public void Insert(Dictionary<string, object> DadosLinha, GerenciadorDB mngBD, ref string sDetalhesLog)
        {
            sDetalhesLog += string.Format("{0} inserido(a). Detalhes:\r\n", this.NomeEntidade);

            using (DbCommand cmd = mngBD.getCommand())
            {
                string sSQL = string.Format("INSERT INTO {0}.{1} (", GerenciadorDB.NameSpaceDB, NomeTabela);
                string campos = "";
                string values = "";

                foreach (KeyValuePair<string, object> item in DadosLinha)
                {
                    campos += item.Key + ",";
                    values += "?,";
                    // inclui parametro utilizando metodo auxiliar
                    cmd.Parameters.Add(Parametro(item, mngBD));
                    sDetalhesLog += item.Key + ": [" + (item.Value == null ? "NULL" : item.Value.ToString()) + "]\r\n";
                }

                sSQL += campos.Substring(0, campos.Length - 1) + ") VALUES (" + values.Substring(0, values.Length - 1) + ")";
                cmd.CommandText = sSQL;

                // Executa
                cmd.ExecuteNonQuery();
            }
        }
        #endregion

        #endregion
    }
}