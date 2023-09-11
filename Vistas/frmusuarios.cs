using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Modelo;
using Negocio;
namespace Vistas
{

    public partial class frmusuarios : Form
    {

        Usuario user = new Usuario();
        N_usuarios func = new N_usuarios();

         // Importa las funciones necesarias desde User32.dll
         [DllImport("user32.dll")]
        private static extern int ReleaseCapture();

        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hwnd, int msg, int wparam, int lparam);

        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;


        public frmusuarios()
        {
            InitializeComponent();
            formulario_de_ingreso.Visible = false;
            mostrar_info("");
        }

        void mostrar_info(string buscar)
        {
            tbusuarios.DataSource = func.show_info(buscar);
            //para ocultar la primera columna
            tbusuarios.Columns[1].Visible = true;
        }

        void clear()
        {
            txtUsuario.Text = "";
            txtNombre.Text = "";
            txtCorreoElectronico.Text = "";
            txtContrasena.Text = "";

        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string tipo_rol = "";

            if (txtNombre.Text.Length == 0)
            {
                MessageBox.Show("Captura tu nombre", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return;
            }

            if (txtUsuario.Text.Length == 0)
            {
                MessageBox.Show("Captura el asuario","Information",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                txtUsuario.Focus();
                return;
            }

            if (txtContrasena.Text.Length == 0)
            {
                MessageBox.Show("Captura tu contrasena", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtContrasena.Focus();
                return;
            }
            if (txtCorreoElectronico.Text.Length == 0)
            {
                MessageBox.Show("Captura tu correo electronico", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCorreoElectronico.Focus();
                return;
            }

            if (cboRol.Text.Length == 0)
            {
                MessageBox.Show("Debes de seleccionar una opcion ","Information",MessageBoxButtons.OK, MessageBoxIcon.Question);
                cboRol.Focus();
                return;
            }

            if (cboRol.SelectedIndex == 0)
            {
                tipo_rol = "Ventas";
            }else if (cboRol.SelectedIndex == 1)
            {
                tipo_rol = "Cajero";
            }else if (cboRol.SelectedIndex == 2)
            {
                tipo_rol = "Administrador";
            }


            user.Nombre_Y_Apellido = txtNombre.Text;
            user.Login = txtUsuario.Text;
            user.password = txtContrasena.Text;
            user.correo = txtCorreoElectronico.Text;
            user.rol = tipo_rol;
            user.icono = "";
            user.nombre_de_icono = "";

            if (func.add_user(user))
            {
                MessageBox.Show("Se ingresaron correctamente los datos ","!!! Success !!!",MessageBoxButtons.OK,MessageBoxIcon.Information);
                clear();
                formulario_de_ingreso.Visible = false;
                mostrar_info("");
            }
            else
            {
                MessageBox.Show("Error no se puedieron ingresar los datos");
            }



        }

        private void frmusuarios_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void frmusuarios_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void frmusuarios_MouseDown(object sender, MouseEventArgs e)
        {
            // Al hacer clic en el formulario, permite moverlo
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }

        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            // Al hacer clic en el formulario, permite moverlo
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //minimizar
            this.WindowState = FormWindowState.Minimized;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //maximizar
            if (this.WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;

        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            formulario_de_ingreso.Visible = true;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            formulario_de_ingreso.Visible = false;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            mostrar_info(txtbuscar.Text);
        }

        private void tbusuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int fila = e.RowIndex;


            lblID.Text = tbusuarios.Rows[fila].Cells[1].Value.ToString();

            user.idUsuario = int.Parse(tbusuarios.Rows[fila].Cells[1].Value.ToString());

            Usuario us = func.select_usuario(user.idUsuario);

            txtNombre.Text = us.Nombre_Y_Apellido;
            txtUsuario.Text = us.Login;
            txtContrasena.Text = us.password;
            txtCorreoElectronico.Text = us.correo;

            if (us.rol == "Administrador")
            {
                cboRol.SelectedIndex = 2;

            }else if (us.rol == "Cajero")
            {
                cboRol.SelectedIndex = 1;
            }else if (us.rol == "Ventas")
            {
                cboRol.SelectedIndex = 0;
            }

            if (e.ColumnIndex == tbusuarios.Columns["btneliminar"].Index)
            {
                if (MessageBox.Show("Deseas eliminar el registro ?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {

                    if (func.delete_user(us.idUsuario))
                    {

                        MessageBox.Show("Datos eliminados");
                        mostrar_info("");
                        clear();
                        formulario_de_ingreso.Visible = false;

                    }

                }
            }
        }

        private void tbusuarios_Click(object sender, EventArgs e)
        {
            
        }
    }
}
