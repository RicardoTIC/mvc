using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Datos
{
    public class D_Persona
    {
       SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);

        public DataTable D_listado()
        {

            string sql = "Select id as 'Id', nom as 'Nombre', \r\napeP  as 'Apellido Paterno', apeM as 'Apellido Materno', \r\nfecha_nacimiento as 'Fecha Nacimiento' \r\nfrom Empleados";
            SqlCommand cmd = new SqlCommand(sql, con);


            cmd.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;

        }


    }
}
