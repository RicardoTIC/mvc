using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;
namespace Datos
{
    public class D_usuarios : Conexion
    {

        public DataTable list(string buscar)
        {
            Conect();
            string sql = "mostrar_usuario";
            SqlCommand cmd = new SqlCommand(sql, _connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@buscar", buscar)
                ;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

        

            Close();

            return dt;
        }

        public Usuario select_usuario(int id)
        {
            Conect();
            Usuario user = new Usuario();
            string query = "SELECT * FROM USUARIO2 WHERE idUsuario = @id";

            SqlCommand command = new SqlCommand(query,_connection);
            SqlParameter parameter = new SqlParameter("@id",SqlDbType.Int);
            parameter.Value = id;
            command.Parameters.AddWithValue("@id", id);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {

                user.idUsuario = reader.GetInt32(0);
                user.Nombre_Y_Apellido = reader.GetString(1);
                user.Login = reader.GetString(2);
                user.password = reader.GetString(3);
                user.icono = reader.GetString(4);
                user.nombre_de_icono = reader.GetString(5);
                user.correo = reader.GetString(6);
                user.rol = reader.GetString(7);

            }
            Close();

            return user;


        }

        public bool add(Usuario user)
        {

            try
            {
                Conect();

                string query = "insertar_usuario";

                SqlCommand command = new SqlCommand(query, _connection);
                command.CommandType = CommandType.StoredProcedure;

                //SqlParameter parameterImage = new SqlParameter("@imagen", SqlDbType.Image);


                //parameterImage.Value = (Object)user.icono ?? DBNull.Value;

                command.Parameters.AddWithValue("@nombres", user.Nombre_Y_Apellido);
                command.Parameters.AddWithValue("@Login", user.Login);
                command.Parameters.AddWithValue("@Password", user.password);
                command.Parameters.AddWithValue("@Icono", user.icono);
                command.Parameters.AddWithValue("@Nombre_de_icono", user.nombre_de_icono);
                command.Parameters.AddWithValue("@Correo", user.correo);
                command.Parameters.AddWithValue("@Rol", user.rol);


                

                command.ExecuteNonQuery();

                Close();

                return true;


            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error {ex.Message}");
                return false;
            }


        }

        public bool delete(int id)
        {
            try
            {
                Conect();

                string query = "DELETE FROM USUARIO2 WHERE idUsuario = @id";

                SqlCommand command = new SqlCommand(query, _connection);
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@id", id);
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
