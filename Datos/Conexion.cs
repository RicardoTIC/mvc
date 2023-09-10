using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Datos
{
    public  class Conexion
    {
        
        protected SqlConnection _connection;

        private string server = "Localhost";
        private string db = "curso_csharts";
        private string user = "Ricardo";
        private string password = "rhvjinzo101212";
        private string _connectionstring;

        public Conexion()
        {
             this._connectionstring = $"Data Source={server};" +
                            $"Initial Catalog={db};User={user};Password={password};";
         }

        public void validation_conection()
        {
            if (_connection.State == ConnectionState.Open)
            {
                MessageBox.Show("Conexion establecida");
            }
            else
            {
                MessageBox.Show("No se pudo conectar a la base de datos","!!! Error !!!",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        public void Conect()
        {
            
            try
            {
                _connection = new SqlConnection(_connectionstring);
                _connection.Open();
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Error{ex.Message}","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);

            }
           
        }

         public void Close()
        {
            if (_connection != null && _connection.State == ConnectionState.Open)
            {
                _connection.Close();
            }
        }

    }
}
