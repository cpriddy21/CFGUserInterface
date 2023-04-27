using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Ocsp;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace CFGUserInterface
{
    public partial class AddNewRep : Form

    {
        BindingSource repBindingSource = new BindingSource();
        public AddNewRep()
        {
            InitializeComponent();
            DAO DAOinstance = new DAO();



            repBindingSource.DataSource = DAOinstance.getAllRep();

            dataGridView1.DataSource = repBindingSource;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DAO DAOinstance = new DAO();
            Rep rep = new Rep()
            {
                RepNum = textBox1.Text,
                FirstName = textBox2.Text,
                LastName = textBox3.Text,
                Street = textBox4.Text,
                City = textBox5.Text,
                State = textBox6.Text,
                PostalCode  = textBox12.Text,
                Commission = (float)Convert.ToDecimal(textBox11.Text),
                Rate = (float)Convert.ToDecimal(textBox10.Text),
                UserName = textBox9.Text,
                PW = textBox8.Text
                
            };
            
        

            DAOinstance.AddRep(rep);
            repBindingSource.DataSource = DAOinstance.getAllRep();

            dataGridView1.DataSource = repBindingSource;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DAO DAOinstance = new DAO();



            repBindingSource.DataSource = DAOinstance.getAllRep();

            dataGridView1.DataSource = repBindingSource;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }
}
