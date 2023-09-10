using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;
using Datos;

namespace Negocio
{
    public class N_usuarios : D_usuarios 
    {

        public bool add_user(Usuario user)
        {
            return add();
        }

    }
}
