using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {

        MySqlConnection conexion = new MySqlConnection("Server=localhost;Database=mydb;Uid=root;");
        //Upassword= ;

        string tableName = "cuidadores";

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {

            conexion.Open();
            string Query = "INSERT INTO " + tableName + " (Nombre, Apellido_Mat, Apellido_Pat, Horrarios) values ('" + textBox1.Text + "' , '" + textBox2.Text + "' , '" + textBox3.Text + "' , '" + textBox4.Text + "');";
            MySqlCommand comando = new MySqlCommand(Query, conexion);
            comando.ExecuteNonQuery();
            comando = new MySqlCommand("Select * from " + tableName, conexion);
            MySqlDataAdapter adaptador = new MySqlDataAdapter();
            adaptador.SelectCommand = comando;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            dataGridView1.DataSource = tabla;
            conexion.Close();
            MessageBox.Show("Added to the table");

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                conexion.Open();
                MessageBox.Show("Conected to server");
                MySqlCommand comando = new MySqlCommand("Select * from " + tableName, conexion);
                MySqlDataAdapter adaptador = new MySqlDataAdapter();
                adaptador.SelectCommand = comando;
                DataTable tabla = new DataTable();
                adaptador.Fill(tabla);
                dataGridView1.DataSource = tabla;
                conexion.Close();

            }
            catch (Exception)
            {
                MessageBox.Show("No server Conection");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            conexion.Open();
            string Query = ("UPDATE " + tableName + " SET Nombre='" + textBox1.Text + 
                "',Apellido_Mat='" + textBox2.Text + 
                "',Apellido_Pat='" + textBox3.Text + 
                "',Horrarios='" + textBox4.Text + 
                "'WHERE idCuidadores='" + textBox5.Text + 
                "';");
            MySqlCommand comando = new MySqlCommand(Query, conexion);
            comando.ExecuteNonQuery();
            comando = new MySqlCommand("Select * from " + tableName, conexion);
            MySqlDataAdapter adaptador = new MySqlDataAdapter();
            adaptador.SelectCommand = comando;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            dataGridView1.DataSource = tabla;
            conexion.Close();
            MessageBox.Show("Update to the table");
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            conexion.Open();
            string Query = ("DELETE FROM " + tableName + " WHERE idCuidadores='" + textBox5.Text + "';");
            MySqlCommand comando = new MySqlCommand(Query, conexion);
            comando.ExecuteNonQuery();
            comando = new MySqlCommand("Select * from " + tableName, conexion);
            MySqlDataAdapter adaptador = new MySqlDataAdapter();
            adaptador.SelectCommand = comando;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            dataGridView1.DataSource = tabla;
            conexion.Close();
            MessageBox.Show("Delete from the table");
        }
    }
}
