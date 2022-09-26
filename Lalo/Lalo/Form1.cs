using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
namespace Lalo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection conexion = new SqlConnection("Server=DESKTOP-R37F9HH;Database=BDPRACTICA2;Trusted_Connection=True;");
        private void btn1_Click(object sender, EventArgs e)
        {
            int registrosAfectados = 0;
            registrosAfectados = Conexion.EjecutaConsulta(txt1.Text);
            AccionesComun.Mensaje("Registros Afectados: " + registrosAfectados);
         
        }

        private void cmb1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label1.Text = cmb1.SelectedValue.ToString();
           
        }
       
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AccionesComun.LlenarData(txt1.Text, dataGridView1);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AccionesComun.LlenarListView(txt1.Text, listView1);
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
            AccionesComun.LlenarCombo(txt1.Text, cmb1, "ID", "nombre");
        }
    }
}
