using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Modelo
{
    public class Usuario : ModeloBase<Usuario>
    {
        #region Propriedades
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public DateTime DataHoraCadastro { get; set; }
        public DateTime DataHoraInativacao { get; set; }
        #endregion

        #region Construtores
        public Usuario()
            : base()
        {
        }
        #endregion

        #region Enums
        public enum TipoUsuario
        {
            Master = 1,
            Padrao = 2,
            Visualizacao = 3
        }
        #endregion
    }
}
