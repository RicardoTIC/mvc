using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;
using Datos;
using System.Data;

namespace Negocio
{
    public class N_usuarios : D_usuarios 
    {

        public bool add_user(Usuario user)
        {
            return add(user);
        }


        public DataTable show_info(string buscar)
        {
            return list(buscar);
        }

        public Usuario select_data_user(int id)
        {
            return select_usuario(id);
        }

        public bool delete_user(int id)
        {

            if (delete(id))
            {
                return true;
            }else
            {
                return false;
            }

           
        }
    }
}
