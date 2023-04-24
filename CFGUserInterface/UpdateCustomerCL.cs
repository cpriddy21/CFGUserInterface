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
            Console.Write("Enter the name of the person to update: ");
            string user_input = Console.ReadLine();
            Console.Write("Enter the new : ");
            int new_age = int.Parse(Console.ReadLine());

            // create a connection to the database
            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=example;Integrated Security=True";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                // create a command with placeholders
                string query = "UPDATE people SET age = @age WHERE name = @name";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@age", new_age);
                command.Parameters.AddWithValue("@name", user_input);

                // open the connection, execute the command, and close the connection
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                Console.WriteLine("Rows affected: " + rowsAffected);
                connection.Close();
            }
        }

        private void UpdateCustomerCL_Load(object sender, EventArgs e)
        {

        }
    }

}
    }
}
