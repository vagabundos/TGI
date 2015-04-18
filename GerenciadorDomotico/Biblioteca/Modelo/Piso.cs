using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.Modelo.Atributos;

namespace Biblioteca.Modelo
{
    [AtributoClasse(TipoLog = Log.LogTipo.ManutencaoTabelaPisos, NomeTabela = "pisos")]
    public class Piso : ModeloBase<Piso>
    {
        #region Propriedades
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public byte[] imagem { get; set; }
        #endregion

        #region Construtores
        public Piso()
            : base()
        {
        }
        #endregion
    }
}
