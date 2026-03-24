using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace touchProyecto
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnIngreso_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["touchProyecto.Properties.Settings.touchProyecto"].ConnectionString);
            var cmd = new SqlCommand(@"select * from Usuarios where nicknameUsuarios = '" + txtUser.Text + "'and claveUsuarios = '" + txtPass.Text + "'", con);

            SqlDataReader reader;
            con.Open();
            reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                MessageBox.Show("Bienvenido");
                //         Frmmenu frm = new Frmmenu(); 
                //       frm.Show();
                //     this.Hide();
            }
            else
            {
                MessageBox.Show("Datos Incorrectos");
            }
            con.Close();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
