using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dados;
using System.Data;
using System.Data.Common;

namespace Biblioteca.Controller
{
    public class controlUsuario
    {
        public static List<Usuario> GetUsuarios(GerenciadorDB objMnger)
        {
            List<Usuario> lstUsuarios = new List<Usuario>();
            DataTable dtt = new DataTable();
            string sSQL = "SELECT * FROM usuarios";

            using (DbCommand objCommand = objMnger.getCommand(sSQL))
            {
                using (DbDataAdapter objAdapter = objMnger.getAdapter(objCommand, false))
                {
                    objAdapter.Fill(dtt);
                }
            }


            return lstUsuarios;
        }
    }
}
