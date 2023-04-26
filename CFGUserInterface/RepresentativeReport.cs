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

namespace CFGUserInterface
{
    public partial class RepresentativeReport : Form
    {
        public RepresentativeReport()
        {
            InitializeComponent();
            
        }
        
        
        private void button1_Click(object sender, EventArgs e)
        
            string connectionString = "datasource=localhost;port=3306;username=root;password=78jm.Lkk!1lol;database=CFG;";
            
            using (MySqlConnection connection = new MySqlConnection(connectionString)) 
            {
            
            string query = "SELECT Rep.LastName, Rep.FirstName, COUNT(*) AS NumCustomers, AVG(Customer.Balance) AS AvgBalance " +
                   "FROM Rep " +
                   "JOIN Customer ON Rep.RepNum = Customer.RepNum " +
                   "GROUP BY Rep.LastName, Rep.FirstName " +
                   "ORDER BY Rep.LastName, Rep.FirstName";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();

           
            DataTable dataTable = new DataTable();
            dataTable.Load(reader);
            dataGridView1.DataSource = dataTable;

       
            reader.Close();
            connection.Close();
            }
      
        }

    }
}
