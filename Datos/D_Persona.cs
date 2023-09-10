using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Modelo;


namespace Datos
{
    public class D_Persona : Conexion
    {

        public Persona select_data(int id)
        {
            Conect();
            Persona p1 = new Persona();

            string query = "SELECT * FROM Empleados WHERE id = @id";
            SqlCommand command = new SqlCommand(query, _connection);
            SqlParameter parameter = new SqlParameter("@id",SqlDbType.Int);
            parameter.Value = id;
            command.Parameters.AddWithValue("@id", id);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {


                p1.id = reader.GetInt32(0);
                p1.nombre = reader.GetString(1);
                p1.apellido = reader.GetString(2);
                p1.telefono = reader.GetString(3);
                p1.direccion = reader.GetString(4);

            }
            Close();
            return p1;
           
        }

        public List<Persona> getAll(string buscar)
        {
            Conect();

            List<Persona> lts = new List<Persona>();

            string query = "SELECT * FROM Empleados WHERE nombre like '%' + @nombre + '%'";
            SqlCommand command = new SqlCommand(query, _connection);
            SqlParameter param = new SqlParameter("@nombre", SqlDbType.VarChar);
            param.Value = buscar;
            command.Parameters.AddWithValue("@nombre", buscar);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Persona p1 = new Persona();

                p1.id = reader.GetInt32(0);
                p1.nombre = reader.GetString(1);
                p1.apellido = reader.GetString(2);
                p1.telefono = reader.GetString(3);
                p1.direccion = reader.GetString(4);
                
                lts.Add(p1);
            }

            Close();
            return lts;
        } 

        public DataTable D_listado()
        {
            Conect();
            string sql = "SELECT * FROM Empleados";
            SqlCommand cmd = new SqlCommand(sql, _connection);

            cmd.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            Close();

            return dt;

        }

        public bool delete(Persona p)
        {
            Conect();
            string query = "DELETE FROM Empleados WHERE id = @id";
            SqlCommand command = new SqlCommand(query, _connection);
            command.Parameters.AddWithValue("@id", p.id);
            command.ExecuteNonQuery();
            Close();

            return true;
            
        }

        public bool update(Persona p)
        {

            try
            {

                Conect();

                string query = "UPDATE Empleados SET nombre= @nombre, apellido = @apellido, telefono = @telefono, " +
                    "direccion = @direccion WHERE id = @id";

                SqlCommand command = new SqlCommand(query,_connection);
                command.Parameters.AddWithValue("@nombre", p.nombre);
                command.Parameters.AddWithValue("@apellido", p.apellido);
                command.Parameters.AddWithValue("@telefono", p.telefono);
                command.Parameters.AddWithValue("@direccion", p.direccion);
                command.Parameters.AddWithValue("@id", p.id);


                command.ExecuteNonQuery();
                Close();

                return true;

            }
            catch (Exception)
            {

                return false;
            }

        }

        public bool add(Persona p)
        {

            try
            {
                Conect();
                string query = "INSERT INTO Empleados (nombre,apellido,telefono,direccion)" +
                    " VALUES (@nombre,@apellido,@telefono,@direccion)";

                SqlCommand command = new SqlCommand(query, _connection);

                command.Parameters.AddWithValue("@nombre", p.nombre);
                command.Parameters.AddWithValue("@apellido", p.apellido);
                command.Parameters.AddWithValue("@telefono", p.telefono);
                command.Parameters.AddWithValue("@direccion", p.direccion);

                command.ExecuteNonQuery();

                Close();

                return true;
            }
            catch (Exception)
            {
                Close();
                return false;
            }



        }

    }
}
