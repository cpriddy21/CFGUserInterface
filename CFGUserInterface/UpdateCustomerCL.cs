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

namespace CFGUserInterface
{
    public partial class UpdateCustomerCL : Form
    {
        public UpdateCustomerCL()
        {
            InitializeComponent();

            // get user input
            
        }

        private void UpdateCustomerCL_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //update customer CL
            Console.Write("Enter the name of the person to update: ");
            String customerName = textBox1.Text;
            Console.Write("Enter the new Credit Limit: ");
            Decimal newCreditLimit = Convert.ToDecimal(textBox2.Text);

            // create a connection to the database
            string connectionString = "datasource=localhost;port=3306;username=root;password=78jm.Lkk!1lol;database=CFG;";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                // create a command with placeholders
                string query = "UPDATE customer SET CreditLimit = @CL WHERE CustomerName = @name";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@CL", newCreditLimit);
                command.Parameters.AddWithValue("@name", customerName);

                // open the connection, execute the command, and close the connection
                connection.Open();
                command.ExecuteNonQuery();
                //onsole.WriteLine("Rows affected: " + rowsAffected);
                connection.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //get customer table
            RepDAO DAOinstance = new RepDAO();

            BindingSource custBindingSource = new BindingSource();

            custBindingSource.DataSource = DAOinstance.getAllCust();

            dataGridView1.DataSource = custBindingSource;

        }
    }

}
    

