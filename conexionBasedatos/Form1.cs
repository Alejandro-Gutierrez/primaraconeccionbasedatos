using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace conexionBasedatos
{
    public partial class Form1 : Form
    {
        String Base = "datasource=localhost; port=3306; username=root; password=cbn2016;database=pruebaconexion;";
            
        public Form1() 
        {
            InitializeComponent();
        }


        public void mostrar()
        {

            

            String query = "";
            
            query = "SELECT Documento,Nombres, Primer_apellido, Segundo_apellido, Edad, Genero,Celular FROM Usuario WHERE Estado=true";
            

            MySqlConnection conexion = new MySqlConnection(Base);

            conexion.Open();

            MySqlCommand comando = new MySqlCommand(query, conexion);
            



            MySqlDataAdapter dap = new MySqlDataAdapter(comando);

            DataSet dast = new DataSet();

            dap.Fill(dast);

            dataGridView1.DataSource = dast.Tables[0];
            conexion.Close();


        }


        private void Form1_Load(object sender, EventArgs e)
        {
           mostrar();
            txtDocumento.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            String query1 = "";
            


            query1 = @"INSERT INTO Usuario values(?idUsuario,?Documento,?Nombres, ?Primer_apellido, ?Segundo_apellido, ?Edad, ?Genero, ?Celular,?Estado)";
            MySqlConnection conexion = new MySqlConnection(Base);

            conexion.Open();
            MySqlCommand coman = new MySqlCommand(query1, conexion);

            coman.Parameters.AddWithValue("?idUsuario", null);
            coman.Parameters.AddWithValue("?Documento", txtDocumento.Text.ToUpper());
            coman.Parameters.AddWithValue("?Nombres", txtNombre.Text.ToUpper());
            coman.Parameters.AddWithValue("?Primer_apellido", txtPrimerapellido.Text.ToUpper());
            coman.Parameters.AddWithValue("?Segundo_apellido", txtSegundoapellido.Text.ToUpper());
            coman.Parameters.AddWithValue("?Edad", Convert.ToInt64(txtEdad.Text));
            coman.Parameters.AddWithValue("?Genero", txtgenero.Text.ToUpper());
            coman.Parameters.AddWithValue("?Celular", txtCelular.Text);
            coman.Parameters.AddWithValue("?Estado", true);
            coman.ExecuteNonQuery();
            conexion.Close();
            mostrar();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            
            foreach (Control c in this.Controls)
            {
                if (c is TextBox)
                {
                    c.Text = " ";
                    c.Enabled = true;
                    txtDocumento.Focus();
                }
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            
        }

        
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dataGridView1.Enabled = true;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtDocumento.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtNombre.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtPrimerapellido.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtSegundoapellido.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtEdad.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtgenero.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            txtCelular.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            //if (txtDocumento.Text == "")
            //{
            //    MessageBox.Show("Por favor ingrese el Documento", "Aviso",MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}else
            //{
               
            //}
            String query1 = "";

            query1 = @"UPDATE Usuario SET Estado=?estado WHERE Documento='" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "'";

            MySqlConnection conexion = new MySqlConnection(Base);

            conexion.Open();
            MySqlCommand coman = new MySqlCommand(query1, conexion);
            coman.Parameters.AddWithValue("?estado", false);
            coman.ExecuteNonQuery();

            conexion.Close();
            mostrar();


            MessageBox.Show("Eliminado con exito", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        
    }
}
