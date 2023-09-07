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

        void showAllData(string buscar)
        {
            tbdatos.DataSource = func.list(buscar);
        }

        void clear_box()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtDireccion.Clear();
            txtTelefono.Clear();
        }
        public frmPersona()
        {
            InitializeComponent();

            timer1.Start();

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            showAllData("");
        }

        private void btnConectar_Click(object sender, EventArgs e)
        {

            con.Conect();
            con.validation_conection();
            con.Close();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {

            //validacion ingreso de datos

            if (txtNombre.Text.Length == 0)
            {
                MessageBox.Show("Ingresa un nombre en la caja de texto nombre");
                txtNombre.Focus();
                return;
            }
            if (txtApellido.Text.Length == 0)
            {
                MessageBox.Show("Ingresa un apellido en la caja de texto apellidos");
                txtApellido.Focus();
                return;
            }
            if (txtDireccion.Text.Length == 0)
            {
                MessageBox.Show("Ingresa una direccion en la caja de texto direcciones");
                txtDireccion.Focus();
                return;
            }
            if (txtTelefono.Text.Length == 0)
            {
                MessageBox.Show("Ingresa el numero de telefono");
                txtTelefono.Focus();
                return;
            }

            p1.nombre = txtNombre.Text;
            p1.apellido = txtApellido.Text;
            p1.direccion = txtDireccion.Text;
            p1.telefono = txtTelefono.Text;

            if (func.add_data(p1))
            {
                MessageBox.Show("Se han ingresado correctamente los datos");
                clear_box();
                showAllData("");

            }else
            {
                MessageBox.Show("No se pudieron ingresar los datos","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }



        }

        private void frmPersona_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            showAllData(txtbuscar.Text);
        }

        private void tbdatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int fila = e.RowIndex;
            try
            {
                p1.id = int.Parse(tbdatos.Rows[fila].Cells[0].Value.ToString());

                Persona p2 = func.select_data_person(p1.id);

                txtNombre.Text = p2.nombre;
                txtApellido.Text = p2.apellido;
                txtDireccion.Text = p2.direccion;
                txtTelefono.Text = p2.telefono;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error",MessageBoxButtons.OK,MessageBoxIcon.Error);                
            }



        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            clear_box();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Deseas actualizar los datos","Information",MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                p1.nombre = txtNombre.Text;
                p1.apellido = txtApellido.Text;
                p1.direccion = txtDireccion.Text;
                p1.telefono = txtTelefono.Text;


                if (func.update_data(p1))
                {
                    MessageBox.Show("Se actualizaron correctamente los datos");
                    showAllData("");
                    clear_box();
                }


            }

            

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseas eliminar el registro","Information",MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                if (func.delete_data(p1))
                {
                    MessageBox.Show("Se eliminaron correctamente los datos");
                    showAllData("");
                    clear_box();
                }

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblfecha.Text = "" + DateTime.Now.ToString("HH:mm:ss");
            
        }
    }
}
