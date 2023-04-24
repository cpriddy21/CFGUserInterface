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
using MySql.Data.MySqlClient;
using static System.Net.Mime.MediaTypeNames;

namespace CFGUserInterface
{
    public partial class AddNewRep : Form

    {
        BindingSource repBindingSource = new BindingSource();
        public AddNewRep()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RepDAO DAOinstance = new RepDAO();
            Rep rep = new Rep()
            {
                /*RepNum = new SqlChars(new SqlString(textBox1.Text)),
                LastName = new SqlChars(new SqlString(textBox2.Text)),
                FirstName = new SqlChars(new SqlString(textBox3.Text)),
                Street = new SqlChars(new SqlString(textBox4.Text)),
                City = new SqlChars(new SqlString(textBox5.Text)),
                State = new SqlChars(new SqlString(textBox6.Text)),
                PostalCode = new SqlChars(new SqlString(textBox12.Text)),
                Commission = Convert.ToDecimal(textBox11.Text),
                Rate = Convert.ToDecimal(textBox10.Text),
                UserName = new SqlChars(new SqlString(textBox9.Text)),
                PW = new SqlChars(new SqlString(textBox8.Text)), */

                
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

            /*System.Diagnostics.Debugger.Break();
            if (DAOinstance.loginCheck(name, PW) == true)
            {
                Menu f2 = new Menu();
                f2.Show();
            }*/

        }

        private void button2_Click(object sender, EventArgs e)
        {
            RepDAO DAOinstance = new RepDAO();



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
