using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;


namespace proyectoprogramacionIII
{
    public partial class FrmVentas : Form
    {
        

        public FrmVentas()
        {
            InitializeComponent();
        }

        private void FrmVentas_Load(object sender, EventArgs e)
        {
            LlenarGrid();
        }

        private void LlenarGrid()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["proyectoprogramacionIII.Properties.Settings.touchProyecto"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {

                    string query = "SELECT idVentas, nombreClienteVentas, dniClienteVentas, telefonoClienteVentas, marcaVentas, modeloVentas, montoVentas, impuestoVentas, totalVentas, usuarioCreacionVentas, fechaCreacionVentas FROM Ventas";

                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvVentas.DataSource = dt;

                }
                catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

             }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            
            if (txtNombreCliente.Text == "" || txtDNICliente.Text == "" || txtTelefonoCliente.Text == "" || txtMarca.Text == "" || txtModelo.Text == "" || txtMonto.Text == "" || txtUsuarioCreacion.Text == "")
            {
                MessageBox.Show("Informacion Incompleta");
                
            }

            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["proyectoprogramacionIII.Properties.Settings.touchProyecto"].ConnectionString))
                {
                    con.Open();
                    var cmd = new SqlCommand("insert into Ventas (nombreClienteVentas, dniClienteVentas, telefonoClienteVentas, marcaVentas, modeloVentas, montoVentas, impuestoVentas, totalVentas, usuarioCreacionVentas, fechaCreacionVentas) values (@nombreClienteVentas, @dniClienteVentas, @telefonoClienteVentas, @marcaVentas, @modeloVentas, @montoVentas, @impuestoVentas, @totalVentas, @usuarioCreacionVentas, GETDATE())", con);

                    
                    cmd.Parameters.AddWithValue("@nombreClienteVentas", txtNombreCliente.Text);
                    cmd.Parameters.AddWithValue("@dniClienteVentas", txtDNICliente.Text);
                    cmd.Parameters.AddWithValue("@telefonoClienteVentas", txtTelefonoCliente.Text);
                    cmd.Parameters.AddWithValue("@marcaVentas", txtMarca.Text);
                    cmd.Parameters.AddWithValue("@modeloVentas", txtModelo.Text);
                    cmd.Parameters.AddWithValue("@usuarioCreacionVentas", txtUsuarioCreacion.Text);


                    decimal monto, impuesto, total;

                    decimal.TryParse(txtMonto.Text, out monto);
                    decimal.TryParse(txtISV.Text, out impuesto);
                    decimal.TryParse(txtTotal.Text, out total);

                    cmd.Parameters.AddWithValue("@montoVentas", monto);
                    cmd.Parameters.AddWithValue("@impuestoVentas", impuesto);
                    cmd.Parameters.AddWithValue("@totalVentas", total);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Guardado Correctamente");

                    limpiarC();
                    LlenarGrid();
                }
            }
            catch (Exception ex)
            {
               
                MessageBox.Show("Error al guardar: " + ex.Message);
            }
        }

        private void txtMonto_Leave(object sender, EventArgs e)
        {
            Calcular();
        }

        private void Calcular()
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(txtMonto.Text))
                {
                    
                    decimal monto = decimal.Parse(txtMonto.Text, System.Globalization.CultureInfo.InvariantCulture);

                    decimal impuesto = monto * 0.15m;
                    decimal total = monto + impuesto;

                    txtISV.Text = impuesto.ToString("N2");
                    txtTotal.Text = total.ToString("N2");
                }
                else
                {
                    txtISV.Text = "0.00";
                    txtTotal.Text = "0.00";
                }
            }
            catch
            {
               
                txtISV.Text = "0.00";
                txtTotal.Text = "0.00";
            }
        
        }


       

        private void limpiarC()
        {
            txtNombreCliente.Clear();
            txtDNICliente.Clear();
            txtTelefonoCliente.Clear();
            txtMarca.Clear();
            txtModelo.Clear();
            txtMonto.Clear();
            txtISV.Clear();
            txtTotal.Clear();
            txtUsuarioCreacion.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
                DialogResult resultado = MessageBox.Show("Desea eliminar este usuario?", "Atencion", MessageBoxButtons.YesNo);
                if (resultado == DialogResult.Yes)
                {
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["proyectoprogramacionIII.Properties.Settings.touchProyecto"].ConnectionString);
                    con.Open();
                    var cmd = new SqlCommand("delete from Ventas where dniClienteVentas = @dniClienteVentas", con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@dniClienteVentas", txtDNICliente.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Eliminado Correctamente");
                limpiarC();
                LlenarGrid();


                txtNombreCliente.Enabled = true;
                txtDNICliente.Enabled = true;

            }
                else
                {
                    return;
                }

            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpiarC();

            txtNombreCliente.Enabled = true;
            txtDNICliente.Enabled = true;
        }

      
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (txtNombreCliente.Text == "" || txtDNICliente.Text == "" || txtTelefonoCliente.Text == "" || txtMarca.Text == "" || txtModelo.Text == "" || txtMonto.Text == "" || txtISV.Text == "" || txtTotal.Text == "" || txtUsuarioCreacion.Text == "")
            {
                MessageBox.Show("Información incompleta");
                
            }
            else
            {
             
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["proyectoprogramacionIII.Properties.Settings.touchProyecto"].ConnectionString);
                con.Open();
                var cmd = new SqlCommand("update Ventas set telefonoClienteVentas = @telefonoClienteVentas, marcaVentas = @marcaVentas, modeloVentas = @modeloVentas, montoVentas = @montoVentas, impuestoVentas = @impuestoVentas, totalVentas = @totalVentas, fechaCreacionVentas = GETDATE() WHERE dniClienteVentas = @dniClienteVentas", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@dniClienteVentas", txtDNICliente.Text);
                cmd.Parameters.AddWithValue("@telefonoClienteVentas", txtTelefonoCliente.Text);
                cmd.Parameters.AddWithValue("@marcaVentas", txtMarca.Text);
                cmd.Parameters.AddWithValue("@modeloVentas", txtModelo.Text);

                decimal monto, impuesto, total;

                decimal.TryParse(txtMonto.Text, out monto);
                decimal.TryParse(txtISV.Text, out impuesto);
                decimal.TryParse(txtTotal.Text, out total);

                cmd.Parameters.AddWithValue("@montoVentas", monto);
                cmd.Parameters.AddWithValue("@impuestoVentas", impuesto);
                cmd.Parameters.AddWithValue("@totalVentas", total);

                cmd.Parameters.AddWithValue("@fechaCreacionVentas", txtUsuarioCreacion.Text);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Actualizado correctamente");

                btnActualizar.Enabled = false;
                btnGuardar.Enabled = true;
                btnBorrar.Enabled = true;

                limpiarC();
                LlenarGrid();

            }
        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["proyectoprogramacionIII.Properties.Settings.touchProyecto"].ConnectionString);
            var cmd = new SqlCommand(@"select * from Ventas where nombreClienteVentas = '" + txtNombreCliente.Text + "'", con);//conexion a la base de datos

            SqlDataReader reader;
            con.Open();
            reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                DialogResult resultado = MessageBox.Show("Usuario ya registrado, desea modificarlo?", "Atencion", MessageBoxButtons.YesNo);
                if (resultado == DialogResult.Yes)
                {
                    
                    
                    txtDNICliente.Text = reader["dniClienteVentas"].ToString();
                    txtTelefonoCliente.Text = reader["telefonoClienteVentas"].ToString();
                    txtMarca.Text = reader["marcaVentas"].ToString();
                    txtModelo.Text = reader["modeloVentas"].ToString();
                    txtUsuarioCreacion.Text = reader["usuarioCreacionVentas"].ToString();
                   
                    btnGuardar.Enabled = false;
                    btnActualizar.Enabled = true;
                    btnBorrar.Enabled = true;

                    txtNombreCliente.Enabled = false;
                    txtDNICliente.Enabled = false;

                }
                else
                {
                    limpiarC();
                }
            }
            else
            {
                DialogResult resultado = MessageBox.Show("Usuario No registrado, Desea Agregarlo?", "Atencion", MessageBoxButtons.YesNo);
                if (resultado == DialogResult.Yes)
                {
                    
                    txtNombreCliente.Focus();
                }

            }
            con.Close();
        }


        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    
}
