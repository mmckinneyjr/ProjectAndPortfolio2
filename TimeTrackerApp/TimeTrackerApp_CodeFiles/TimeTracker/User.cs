using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.IO;
using System.Data;

namespace TimerTracker
{
    class User
    {

        public int _userId { get; set; }

        //USER LOGIN METHOD
        public static int UserLogin() {
            Headers.Header();

            int userId = 0;
            bool loggingIn = true;
            while (loggingIn) {

                //CONNECTION STRING
                string cs = @"server=192.168.207.1; userid=dbremoteuser; password=password; database=MarkMckinney_MDV229_Database_201810; port=8889";
                MySqlConnection conn = null;

                conn = new MySqlConnection(cs);
                conn.Open();
                MySqlDataReader rdr = null;

                Console.Write(" First Name: ");
                string firstName = Console.ReadLine();
                Console.Write(" Last Name: ");
                string lastName = Console.ReadLine();

                Console.Write(" Password: ");
                string password = Console.ReadLine();

                // Form SQL Statement
                string stm = "SELECT user_Id, user_firstname, user_lastname, user_password FROM time_tracker_users WHERE user_firstname = @firstName and user_lastname = @lastName and user_password = @password ";

                // Prepare SQL Statement
                MySqlCommand cmd = new MySqlCommand(stm, conn);

                // Binding Variables 
                cmd.Parameters.AddWithValue("@firstName", firstName);
                cmd.Parameters.AddWithValue("@lastName", lastName);
                cmd.Parameters.AddWithValue("@password", password);              

                // Execute SQL statement and place the returned data into rdr
                rdr = cmd.ExecuteReader();
                rdr.Read();

                if (rdr.HasRows)  {
                    userId = UID(firstName, lastName, password);
                    break;
                }
                else  {
                    Headers.Header();
                    Console.WriteLine(" The login provided did not match any records\r\n");
                    userId = 0;
                }
            }
            return userId;
        }

        public static int UID(string fname, string lname, string password) {
            //CONNECTION STRING
            string cs = @"server=192.168.207.1; userid=dbremoteuser; password=password; database=MarkMckinney_MDV229_Database_201810; port=8889";
            MySqlConnection conn = null;

            conn = new MySqlConnection(cs);
            conn.Open();
            MySqlDataReader rdr = null;

            //SQL Statement
            string stm = "SELECT user_id from time_tracker_users WHERE user_firstname = @firstName and user_lastname = @lastName and user_password = @password;";

            MySqlCommand cmd = new MySqlCommand(stm, conn);

            cmd.Parameters.AddWithValue("@firstName", fname);
            cmd.Parameters.AddWithValue("@lastName", lname);
            cmd.Parameters.AddWithValue("@password", password);

            rdr = cmd.ExecuteReader();
            rdr.Read(); 
                
            return  Convert.ToInt32(rdr["user_id"]);
        }
    }
}
