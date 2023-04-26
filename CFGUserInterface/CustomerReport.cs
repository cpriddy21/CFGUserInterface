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
            string connectionString = "datasource=localhost;port=3306;username=root;password=78jm.Lkk!1lol;database=CFG;";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {

                String CustomerName = textBox1.Text;
                connection.Open();
                //string query = Select

                using (MySqlCommand cmd = new MySqlCommand("SELECT c.CustomerName, SUM(ol.QuotedPrice * ol.NumOrdered) AS TotalQuotedPrice FROM Orders o JOIN OrderLine ol ON o.OrderNum = ol.OrderNum JOIN Customer c ON o.CustomerNum = c.CustomerNum JOIN Item i ON ol.ItemNum = i.ItemNum WHERE c.CustomerName = @CustomerName GROUP BY c.CustomerName;", connection))
                {
                    cmd.Parameters.AddWithValue("@CustomerName", CustomerName);
                    using(MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dataGridView1.DataSource = dataTable;
                    }
                }
                
                /*MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();


                dataTable.Load(reader);

                dataGridView1.DataSource = dataTable;


                reader.Close(); */
                connection.Close();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
