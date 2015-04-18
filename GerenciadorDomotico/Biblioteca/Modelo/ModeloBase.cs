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