using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Biblioteca.Modelo.Atributos
{
    /// <summary>
    /// Atributo para ser utilizados nas classes Modelo
    /// </summary>
    [System.AttributeUsage(System.AttributeTargets.Class)]
    public class AtributoClasse : System.Attribute
    {
        /// <summary>
        /// Nome da tabela no banco
        /// </summary>
        public string NomeTabela;

        /// <summary>
        /// Tipo de log para manutenção da tabela
        /// </summary>
        public Log.LogTipo TipoLog;

        /// <summary>
        /// Nome da propriedade (DateTime) que irá conter a data e hora de inativação do cadastro
        /// </summary>
        public string DataHoraInativacao;

        /// <summary>
        /// Nome da propriedade (Bool) que definirá se um cadastro está inativo ou não
        /// </summary>
        public string FlagInativacao;

    }
}
