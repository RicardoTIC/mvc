using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;
namespace Datos
{
    public class D_usuarios : Conexion
    {

        public bool add(Usuario user)
        {

            try
            {
                Conect();

                string query = "insertar_usuario(@nombres,@login,@password,@icono,@nombre_de_icono,@correo,@rol)";

                SqlCommand command = new SqlCommand(query, _connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@nombres", user.Nombre_Y_Apellido);
                command.Parameters.AddWithValue("@login", user.Login);
                command.Parameters.AddWithValue("@password", user.password);
                command.Parameters.AddWithValue("@icono", user.icono);
                command.Parameters.AddWithValue("@nombre_de_icono", user.nombre_de_icono);
                command.Parameters.AddWithValue("@correo", user.correo);
                command.Parameters.AddWithValue("@rol", user.rol);

                command.ExecuteNonQuery();

                Close();

                return true;


            }
            catch (Exception)
            {

                return false;
            }


        }

    }
}
