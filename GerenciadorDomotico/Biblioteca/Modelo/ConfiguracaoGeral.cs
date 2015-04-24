using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using Biblioteca.Modelo.Atributos;
using Dados;

namespace Biblioteca.Modelo
{
    [AtributoClasse(NomeTabela = "ConfiguracaoGeral")]
    public class ConfiguracaoGeral : ModeloBase<ConfiguracaoGeral>
    {
        #region Propriedades
        [AtributoPropriedade(Caption = "Identificação Servidor", IsChave = true, NomeColuna = "IdServidor", OrdemGrid = 1, Tamanho = 20)]
        public string IdServidor { get; set; }

        [AtributoPropriedade(Caption = "Servidor Web Service", IsChave = false, NomeColuna = "WsServidor", OrdemGrid = 2, Tamanho = 200)]
        public string WsServidor { get; set; }

        [AtributoPropriedade(Caption = "Porta Web Service", IsChave = false, NomeColuna = "WsPorta", OrdemGrid = 3, Tamanho = 20)]
        public string WsPorta { get; set; }
        
        [AtributoPropriedade(Caption = "Porta Serial", IsChave = false, NomeColuna = "SerialPorta", OrdemGrid = 4, Tamanho = 20)]
        public string SerialPorta { get; set; }
        
        [AtributoPropriedade(Caption = "Baud Rate", IsChave = false, NomeColuna = "SerialBaudRate", OrdemGrid = 5)]
        public int SerialBaudRate { get; set; }
        
        [AtributoPropriedade(Caption = "Paridade", IsChave = false, NomeColuna = "SerialParidade", OrdemGrid = 6)]
        public Parity SerialParidade { get; set; }
        
        [AtributoPropriedade(Caption = "Data Bits", IsChave = false, NomeColuna = "SerialDataBits", OrdemGrid = 7)]
        public int SerialDataBits { get; set; }
        
        [AtributoPropriedade(Caption = "Stop Bits", IsChave = false, NomeColuna = "SerialStopBits", OrdemGrid = 8)]
        public StopBits SerialStopBits { get; set; }
        #endregion

        #region Construtores
        public ConfiguracaoGeral()
            : base()
        {

        }
        #endregion
    }
}