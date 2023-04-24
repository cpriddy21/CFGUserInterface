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
using System.Xml.Linq;

using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace CFGUserInterface
{
    internal class RepDAO
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
                        /*RepNum = new SqlChars(new SqlString(reader.GetString(0))),
                        LastName = new SqlChars(new SqlString(reader.GetString(1))),
                        FirstName = new SqlChars(new SqlString(reader.GetString(2))),
                        Street = new SqlChars(new SqlString(reader.GetString(3))),
                        City = new SqlChars(new SqlString(reader.GetString(4))),
                        State = new SqlChars(new SqlString(reader.GetString(5))),
                        PostalCode = new SqlChars(new SqlString(reader.GetString(6))),
                        Commission = new SqlDecimal(reader.GetFloat(7)),
                        Rate = new SqlDecimal(reader.GetFloat(8)),
                        UserName = new SqlChars(new SqlString(reader.GetString(9))),
                        PW = new SqlChars(new SqlString(reader.GetString(10)))*/

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

        public bool loginCheck(String username, String password)
        {
            bool login = false;
            string connectionString = "datasource=localhost;port=3306;username=root;password=78jm.Lkk!1lol;database=CFG;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM REP", connection);
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Rep rep = new Rep
                    {
                        /*RepNum = new SqlChars(new SqlString(reader.GetString(0))),
                        LastName = new SqlChars(new SqlString(reader.GetString(1))),
                        FirstName = new SqlChars(new SqlString(reader.GetString(2))),
                        Street = new SqlChars(new SqlString(reader.GetString(3))),
                        City = new SqlChars(new SqlString(reader.GetString(4))),
                        State = new SqlChars(new SqlString(reader.GetString(5))),
                        PostalCode = new SqlChars(new SqlString(reader.GetString(6))),
                        Commission = new SqlDecimal(reader.GetFloat(7)),
                        Rate = new SqlDecimal(reader.GetFloat(8)),
                        UserName = new SqlChars(new SqlString(reader.GetString(9))),
                        PW = new SqlChars(new SqlString(reader.GetString(10)))
                        /*RepNum = reader.GetString(0),
                        LastName = reader.GetString(1),
                        FirstName = reader.GetString(2),
                        Street = reader.GetString(3),
                        City = reader.GetString(4),
                        State = reader.GetString(5),
                        PostalCode = reader.GetString(6),
                        Commission = reader.GetFloat(7),
                        Rate = reader.GetFloat(8),
                        UserName = reader.GetString(9),
                        PW = reader.GetString(10),*/
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
            string connectionString = "datasource=localhost;port=3306;username=root;password=78jm.Lkk!1lol;database=CFG;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            //MySqlCommand cmd = new MySqlCommand("INSERT INTO REP\nVALUES\n('" + RepNum + "','" + LastName + "','" + FirstName + "','" + Street + "','" + City + "','" + State + "','" + PostalCode + "'," + Commission + "," + Rate + ", '" + UserName + "','" + Password + "');", connection);
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
