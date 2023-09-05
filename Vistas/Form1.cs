using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Datos;
using Modelo;
using Negocio;

namespace Vistas
{
    public partial class frmPersona : Form
    {
        Persona p1 = new Persona();
        N_Persona func = new N_Persona();
        Conexion con = new Conexion();

        void nombre_columnas()
        {
            //Establecemos el nombre de las columnas 
            tbdatos.AutoGenerateColumns = true;
        }
        public frmPersona()
        {
            InitializeComponent();
            tbdatos.DataSource = func.list();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            tbdatos.DataSource = func.list();

        }

        private void btnConectar_Click(object sender, EventArgs e)
        {

            con.Conect();
            con.validation_conection();
            con.Close();
        }
    }
}
