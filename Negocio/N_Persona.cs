using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Negocio
{
    public class N_Persona : D_Persona
    {


        public DataTable list()
        {
            return this.D_listado();
        }

    }
}
