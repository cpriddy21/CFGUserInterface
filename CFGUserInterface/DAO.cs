using Google.Protobuf.WellKnownTypes;
using Microsoft.VisualBasic.Logging;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace CFGUserInterface
{
    internal class DAO
    {
        //fake data
        //public List<Rep> reps = new List<Rep>();
        string connectionString = "datasource=localhost;port=3306;username=root;password=78jm.Lkk!1lol;database=CFG;";
        public List<Rep> getAllRep()
        {
            //start with empty list
            List<Rep> returnThese = new List<Rep>();

            //connect to swl server
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand cmd = new MySqlCommand("SELECT * FROM REP", connection);

            using(MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Rep rep = new Rep
                    {
                        RepNum = reader.GetString(0),
                        LastName = reader.GetString(1),
                        FirstName = reader.GetString(2),
                        Street = reader.GetString(3),
                        City = reader.GetString(4),
                        State = reader.GetString(5),
                        PostalCode = reader.GetString(6),
                        Commission = reader.GetFloat(7),
                        Rate = reader.GetFloat(8),
                        UserName = reader.GetString(9),
                        PW = reader.GetString(10) 
                    };
                    returnThese.Add(rep);
                }
            }
            connection.Close();

            return returnThese;
        }

        public List<Customer> getAllCust()
        {
            //start with empty list
            List<Customer> returnThese = new List<Customer>();

            //connect to sql server
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand cmd = new MySqlCommand("SELECT * FROM CUSTOMER", connection);

            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Customer cust = new Customer
                    {
                        CustomerNum = reader.GetString(0),
                        CustomerName = reader.GetString(1),
                        Street = reader.GetString(2),
                        City = reader.GetString(3),
                        State = reader.GetString(4),
                        PostalCode = reader.GetString(5),
                        Balance = reader.GetFloat(6),
                        CreditLimit = reader.GetFloat(7),
                        RepNum = reader.GetString(8),
                        
                    };
                    returnThese.Add(cust);
                }
            }
            connection.Close();

            return returnThese;
        }

        public bool loginCheck(String username, String password)
        {
            bool login = false;
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM REP", connection);
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Rep rep = new Rep
                    {
                        RepNum = reader.GetString(0),
                        LastName = reader.GetString(1),
                        FirstName = reader.GetString(2),
                        Street = reader.GetString(3),
                        City = reader.GetString(4),
                        State = reader.GetString(5),
                        PostalCode = reader.GetString(6),
                        Commission = reader.GetFloat(7),
                        Rate = reader.GetFloat(8),
                        UserName = reader.GetString(9),
                        PW = reader.GetString(10)
                    };
                    if (Convert.ToString(rep.UserName) == username)
                    {
                        if (Convert.ToString(rep.PW) == password)
                        {
                            login = true;
                            connection.Close();
                            return login;
                        }
                    }
                }
            }
            connection.Close();
            return false;
        }

        public void AddRep(Rep rep)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            MySqlCommand cmd = new MySqlCommand("INSERT INTO REP VALUES (@RepNum,@LastName,@FirstName,@Street,@City,@State,@PostalCode,@Commission,@Rate,@UserName,@Password);", connection);
            cmd.Parameters.AddWithValue("@RepNum", rep.RepNum);
            cmd.Parameters.AddWithValue("@LastName", rep.LastName);
            cmd.Parameters.AddWithValue("@FirstName", rep.FirstName);
            cmd.Parameters.AddWithValue("@Street", rep.Street);
            cmd.Parameters.AddWithValue("@City", rep.City);
            cmd.Parameters.AddWithValue("@State", rep.State);
            cmd.Parameters.AddWithValue("@PostalCode", rep.PostalCode);
            cmd.Parameters.AddWithValue("@Commission", rep.Commission);
            cmd.Parameters.AddWithValue("@Rate", rep.Rate);
            cmd.Parameters.AddWithValue("@UserName", rep.UserName);
            cmd.Parameters.AddWithValue("@Password", rep.PW);
            int newRows = cmd.ExecuteNonQuery();
        }

        public void CreditLimit(String customerName, Decimal newCreditLimit)
        {
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

        public DataTable RepReport()
        {
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
                reader.Close();
                connection.Close();
                return dataTable;

                //dataGridView1.DataSource = dataTable;


                
            }
        }

        public DataTable CustReport(String CustomerName)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {

                //String CustomerName = textBox1.Text;
                connection.Open();
                //string query = Select

                using (MySqlCommand cmd = new MySqlCommand("SELECT c.CustomerName, SUM(ol.QuotedPrice * ol.NumOrdered) AS TotalQuotedPrice FROM Orders o JOIN OrderLine ol ON o.OrderNum = ol.OrderNum JOIN Customer c ON o.CustomerNum = c.CustomerNum JOIN Item i ON ol.ItemNum = i.ItemNum WHERE c.CustomerName = @CustomerName GROUP BY c.CustomerName;", connection))
                {
                    cmd.Parameters.AddWithValue("@CustomerName", CustomerName);
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        //dataGridView1.DataSource = dataTable;
                       
                        connection.Close();
                        return dataTable;
                    }
                }
            }
            
        }
        /*
    ✓    * Login
         * Generate a report that for each representative, listing the number of customers
            assigned to the representative and the average balance of the representative’s
            customers along with the representative's first and last name; 
         * Generate a report that displays the total quoted price of all the orders from a given
            customer, taking the customer name as input;
         * Add a new representative;
         * Update a customer’s credit limit, taking the customer name as input;
    ✓    * Exit the system. 
         */

        //public
    }
}
