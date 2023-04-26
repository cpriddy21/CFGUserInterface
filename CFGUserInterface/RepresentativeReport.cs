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
            string connectionString = "datasource=localhost;port=3306;username=root;password=78jm.Lkk!1lol;database=CFG;";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {

                string query = "SELECT Rep.LastName, Rep.FirstName, COUNT(*) AS NumCustomers, AVG(Customer.Balance) AS AvgBalance " +
                       "FROM Rep " +
                       "JOIN Customer ON Rep.RepNum = Customer.RepNum " +
                       "GROUP BY Rep.LastName, Rep.FirstName " +
                       "ORDER BY Rep.LastName, Rep.FirstName";
                connection.Open();
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();


                DataTable dataTable = new DataTable();
                dataTable.Load(reader);

                dataGridView1.DataSource = dataTable;


                reader.Close();
                connection.Close();
            }
        }
        /*
* Generate a report that for each representative, listing the number of customers
assigned to the representative and the average balance of the representative’s
customers along with the representative's first and last name; 
*/



    }
}
