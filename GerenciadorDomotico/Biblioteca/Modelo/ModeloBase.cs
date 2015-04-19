using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Biblioteca.Modelo
{
    [Serializable]
    public abstract class ModeloBase<M>
        where M : ModeloBase<M>, new()
    {
        #region Construtores
        public ModeloBase()
        {
            this._Status = ObjetoStatus.Novo;
        }
        #endregion

        #region Propriedades

        // Coloca propriedades como Private e internal para não serem devolvidas na busca por Reflection
        private  ObjetoStatus _Status { get; set; }
        internal ModeloBase<M> _objetoOriginal { get; set; }

        /// <summary>
        /// Retorna o Estado do Objeto, se é novo, nao alterado ou alterado, calcula em tempo de execução.
        /// </summary>
        internal ObjetoStatus Status
        {
            get
            {
                if (this._Status != ObjetoStatus.Novo)
                {
                    System.Reflection.PropertyInfo[] props = typeof(M).GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
                    bool Alterado = false;
                    foreach (System.Reflection.PropertyInfo prop in props)
                    {
                        if (prop.PropertyType != null && prop.CanWrite)
                        {
                            if ((prop.GetValue(this, null) == null && prop.GetValue(this._objetoOriginal, null) != null) ||
                                (prop.GetValue(this, null) != null && prop.GetValue(this._objetoOriginal, null) == null) ||
                                (prop.GetValue(this, null) != null && prop.GetValue(this._objetoOriginal, null) != null && !prop.GetValue(this, null).Equals(prop.GetValue(this._objetoOriginal, null)))
                                )
                            {
                                _Status = ObjetoStatus.Editado;
                                Alterado = true;
                                break;
                            }
                        }
                    }
                    if (!Alterado)
                        _Status = ObjetoStatus.NaoAlterado;
                }
                return _Status;
            }
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Método para carregar o objeto Modelo com os dados da base de dados
        /// </summary>
        public void CarregaObjeto(Dictionary<string, object> dicLinha, Dictionary<string, PropertyInfo> dicPropriedades)
        {
            _objetoOriginal = new M();

            // Seta a propriedade no objeto e no _Original com base no nome coluna
            foreach (KeyValuePair<string, object> Coluna in dicLinha)
            {
                // Se nao tem NomeColuna, o nome é o mesmo da propriedade.
                if (dicPropriedades.ContainsKey(Coluna.Key.ToUpper()))
                {
                    try
                    {
                        PropertyInfo prop = dicPropriedades[Coluna.Key.ToUpper()];

                        if ((prop.PropertyType == typeof(decimal?) || prop.PropertyType == typeof(decimal)) && (Coluna.Value != null) && (Coluna.Value.GetType() == typeof(double) || Coluna.Value.GetType() == typeof(double?)))
                        {
                            prop.SetValue(this, Convert.ToDecimal(Coluna.Value), null);
                            prop.SetValue(this._objetoOriginal, Convert.ToDecimal(Coluna.Value), null);
                        }

                        else
                        {
                            prop.SetValue(this, Coluna.Value, null);
                            prop.SetValue(this._objetoOriginal, Coluna.Value, null);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message + " - Campo: " + Coluna.Key, ex);
                    }
                }
            }

            // Objeto carregado do banco, ou seja, Status não alterado
            this._Status = ObjetoStatus.NaoAlterado;
        }
        #endregion

        #region Enums
        public enum ObjetoStatus
        {
            Novo = 1,
            Editado = 2,
            NaoAlterado = 3,
        }
        #endregion
    }
}