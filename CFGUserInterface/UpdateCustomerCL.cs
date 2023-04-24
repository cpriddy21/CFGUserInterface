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
    public partial class UpdateCustomerCL : Form
    {
        public UpdateCustomerCL()
        {
            InitializeComponent();
            
        // get user input
        Console.Write("Enter the name of the person to update: ");
        string user_input = Console.ReadLine();
        Console.Write("Enter the new age: ");
        int new_age = int.Parse(Console.ReadLine());

        // create a connection to the database
        string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=example;Integrated Security=True";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            // create a command with placeholders
            string query = "UPDATE people SET age = @age WHERE name = @name";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CreditLimit", new_CreditLimit);
            command.Parameters.AddWithValue("@name", user_input);

            // open the connection, execute the command, and close the connection
            connection.Open();
            int rowsAffected = command.ExecuteNonQuery();
            Console.WriteLine("Rows affected: " + rowsAffected);
            connection.Close();
        }
    }
}

        }
    }
}
