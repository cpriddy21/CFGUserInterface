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

namespace CFGUserInterface
{
    public partial class CustomerReport : Form
    {
        public CustomerReport()
        {
            InitializeComponent();
        }

        //Generate a report that displays the total quoted price of all the orders from a given
        //customer, taking the customer name as input;


        private void button1_Click(object sender, EventArgs e)
        {
            String CustomerName = textBox1.Text;
            DAO DAOinstance = new DAO();
            dataGridView1.DataSource = DAOinstance.CustReport(CustomerName);

        }


    }
}

