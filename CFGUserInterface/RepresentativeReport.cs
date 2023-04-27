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
using MySql.Data.MySqlClient;

namespace CFGUserInterface
{
    public partial class RepresentativeReport : Form
    {
        public RepresentativeReport()
        {
            InitializeComponent();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DAO DAOinstance = new DAO();
            dataGridView1.DataSource = DAOinstance.RepReport();
        }
        /*
        * Generate a report that for each representative, listing the number of customers
        assigned to the representative and the average balance of the representative’s
        customers along with the representative's first and last name; 
        */



    }
}
