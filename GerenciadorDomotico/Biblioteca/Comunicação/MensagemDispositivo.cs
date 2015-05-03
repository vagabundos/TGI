﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Comunicação
{
    public class MensagemDispositivo
    {
        #region Propriedades
        public static char _SeparadorSegmento
        {
            get
            {
                return '\r';
            }
        }

        public static char _FimMensagem
        {
            get
            {
                return '\u0003';
            }
        }

        public static char _InicioMensagem
        {
            get
            {
                return '\u0002';
            }
        }

        public Header _Header { get; set; }

        public Command _Command { get; set; }
        #endregion

        #region Construtores
        public MensagemDispositivo()
        {
        }

        public MensagemDispositivo(string sMensagem)
        {
            if (Consiste(sMensagem))
            {
                sMensagem = sMensagem.Substring(1, sMensagem.Length - 2);
                string[] arrSegmentos = sMensagem.Split(_SeparadorSegmento);
                _Header = new Header(arrSegmentos[0]);
                _Command = new Command(arrSegmentos[1]);
            }
        }
        #endregion

        #region Métodos
        public string TextoEnvio()
        {
            StringBuilder stb = new StringBuilder();
            stb.Append(_InicioMensagem);
            stb.Append(_Header.TextoEnvio());
            stb.Append(_SeparadorSegmento);
            stb.Append(_Command.TextoEnvio());
            stb.Append(_SeparadorSegmento);
            stb.Append(_FimMensagem);
            return stb.ToString();
        }

        private bool Consiste(string sMensagem)
        {
            if (string.IsNullOrEmpty(sMensagem))
                return false;

            if (sMensagem[0] != _InicioMensagem)
                return false;

            if (sMensagem[sMensagem.Length - 1] != _FimMensagem)
                return false;

            string[] arrSegmentos = sMensagem.Split(_SeparadorSegmento);

            if (arrSegmentos.Length < 2)
                return false;

            return true;
        }
        #endregion

        #region Classes de Segmentos
        public class Header
        {
            #region Propriedades
            public string ID_Sender { get; set; }
            public string ID_Receiver { get; set; }
            #endregion

            #region Construtores
            public Header()
            {

            }

            public Header(string sSegmento)
            {
                if (Util.GetPiece(sSegmento, '|', 1).Equals("HDR"))
                {
                    ID_Sender = Util.GetPiece(sSegmento, '|', 2);
                    ID_Receiver = Util.GetPiece(sSegmento, '|', 3);
                }
            }
            #endregion

            #region Métodos
            public string TextoEnvio()
            {
                return string.Format("HDR|{0}|{1}", ID_Sender, ID_Receiver);
            }
            #endregion
        }

        public class Command
        {
            #region Propriedades
            public string ID_Dispositivo { get; set; }
            public string Disp_Value { get; set; }
            #endregion

            #region Construtores
            public Command()
            {
            }

            public Command(string sSegmento)
            {
                if (Util.GetPiece(sSegmento, '|', 1).Equals("CMD"))
                {
                    ID_Dispositivo = Util.GetPiece(sSegmento, '|', 2);
                    Disp_Value = Util.GetPiece(sSegmento, '|', 3);
                }
            }
            #endregion

            #region Métodos
            public string TextoEnvio()
            {
                return string.Format("CMD|{0}|{1}", ID_Dispositivo, Disp_Value);
            }
            #endregion
        }
        #endregion
    }
}
