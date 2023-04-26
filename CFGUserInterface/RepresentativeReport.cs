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
    public partial class RepresentativeReport : Form
    {
        public RepresentativeReport()
        {
            InitializeComponent();
        }
        
        // 
        private void button1_Click(object sender, EventArgs e)
        {
      
            
            //Copied "..." from credit limit method. dont know if i was supposed to
            string connectionString = "datasource=localhost;port=3306;username=root;password=78jm.Lkk!1lol;database=CFG;";
            
            using (MySqlConnection connection = new MySqlConnection(connectionString)) 
            {
            // Execute query
            string query = "SELECT Rep.LastName, Rep.FirstName, COUNT(*) AS NumCustomers, AVG(Customer.Balance) AS AvgBalance " +
                   "FROM Rep " +
                   "JOIN Customer ON Rep.RepNum = Customer.RepNum " +
                   "GROUP BY Rep.LastName, Rep.FirstName " +
                   "ORDER BY Rep.LastName, Rep.FirstName";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();

            // Display results in DataGridView
            DataTable dataTable = new DataTable();
            dataTable.Load(reader);
            dataGridView1.DataSource = dataTable;

            // Close database connection
            reader.Close();
            connection.Close();
            }
      
        }

    }
}
