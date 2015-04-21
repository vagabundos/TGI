using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca;
using Biblioteca.Modelo;
using Biblioteca.Controle;
using System.Reflection;

namespace GerenciadorDomotico.Dispositivos
{
    public class FactoryControlDispositivo
    {
        #region Construtores
        private FactoryControlDispositivo()
        {
            // Construtor Privado
        }
        #endregion

        #region Métodos
        public static ctlDispositivoBase getControleDispositivo(Dispositivo objDispModelo)
        {
            Assembly currAssembly = Assembly.GetExecutingAssembly();
            string sFullNameType = string.Format("{0}.Dispositivos.ctlDispositivo{1}", currAssembly.GetName().Name, objDispModelo.Tipo);
            Type ctlType = currAssembly.GetType(sFullNameType);

            // Se Tipo do Dispositivo não tem controle específico, devolve controle base
            if (ctlType == null)
            {
                ctlType = typeof(ctlDispositivoBase);
            }

            ctlDispositivoBase ctlDispositivo = (ctlDispositivoBase)Activator.CreateInstance(ctlType, new object[] { objDispModelo });
            return ctlDispositivo;
        }
        #endregion
    }
}
