using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.IO;
using System.Data;

namespace MyBeer
{
    public class User
    {

        public string _userId { get; set; }
        public string _firstname { get; set; }
        public string _lastname { get; set; }
        public string _username { get; set; }
        public string _password { get; set; }
        public string _emailaddress { get; set; }

        //USER LOGIN METHOD
        public static string UserLogin(string user, string loc) {
            Headers.Header(user, loc);
            Console.WriteLine(" Login\r\n");
            string userId = "";
            bool loggingIn = true;
            while (loggingIn) {
      
                    //CONNECTION STRING
                    string cs = @"server=192.168.207.1; userid=dbremoteuser; password=password; database=DigitalPour; port=8889";
                    MySqlConnection conn = null;

                    conn = new MySqlConnection(cs);
                    conn.Open();
                    MySqlDataReader rdr = null;

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("                                                      Username            ");
                Console.ResetColor();
                Console.WriteLine("                                         ----------------------------------");
                Console.WriteLine("                                        |                                  |");
                Console.WriteLine("                                         ----------------------------------");
                Console.SetCursorPosition((0 + 42), Console.CursorTop - 2);
                string userName = Console.ReadLine();

                Headers.Header(user,loc);
                Console.WriteLine(" Login\r\n");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("                                                      Password            ");
                Console.ResetColor();
                Console.WriteLine("                                         ----------------------------------");
                Console.WriteLine("                                        |                                  |");
                Console.WriteLine("                                         ----------------------------------");
                Console.SetCursorPosition((0 + 42), Console.CursorTop - 2);
                string password = Console.ReadLine();

                    //SQL Statement
                    string stm = "SELECT userID, userName, password FROM Users WHERE userName = @username and password = @password;";

                    MySqlCommand cmd = new MySqlCommand(stm, conn);
                    cmd.Parameters.AddWithValue("@username", userName);
                    cmd.Parameters.AddWithValue("@password", password);

                    rdr = cmd.ExecuteReader();
                    rdr.Read();

                    if (rdr.HasRows) {
                        userId = UID(userName, password);
                        break;
                    }
                    else {
                        Headers.Header(user, loc);
                        Console.WriteLine(" The login provided did not match any records\r\n");
                        break;
                    }          
            }
            return userId;
        }

        //RETURN USER ID
        public static string UID(string userName, string password) {
            //CONNECTION STRING
            string cs = @"server=192.168.207.1; userid=dbremoteuser; password=password; database=DigitalPour; port=8889";
            MySqlConnection conn = null;
            conn = new MySqlConnection(cs);
            conn.Open();
            MySqlDataReader rdr = null;

            //SQL Statement
            string stm = "SELECT userID FROM Users WHERE userName = @username and password = @password;";
            MySqlCommand cmd = new MySqlCommand(stm, conn);
            cmd.Parameters.AddWithValue("@username", userName);
            cmd.Parameters.AddWithValue("@password", password);
            rdr = cmd.ExecuteReader();
            rdr.Read();

            return rdr["userID"].ToString();
        }

        //RETURN USERNAME
        public static string userName(string uid) {
            //CONNECTION STRING
            string cs = @"server=192.168.207.1; userid=dbremoteuser; password=password; database=DigitalPour; port=8889";
            MySqlConnection conn = null;
            conn = new MySqlConnection(cs);
            conn.Open();
            MySqlDataReader rdr = null;
            //SQL Statement
            string stm = "SELECT userName FROM Users WHERE userID = @userid;";
            MySqlCommand cmd = new MySqlCommand(stm, conn);
            cmd.Parameters.AddWithValue("@userid", uid);
            rdr = cmd.ExecuteReader();
            rdr.Read();
            string name = rdr["userName"].ToString();
            string x = $"{name, -40}";
            return x;
        }

        //RETURN USER'S FIRST NAME
        public static string Name(string uid) {
            //CONNECTION STRING
            string cs = @"server=192.168.207.1; userid=dbremoteuser; password=password; database=DigitalPour; port=8889";
            MySqlConnection conn = null;
            conn = new MySqlConnection(cs);
            conn.Open();
            MySqlDataReader rdr = null;
            //SQL Statement
            string stm = "SELECT userFirstName FROM Users WHERE userID = @userid;";
            MySqlCommand cmd = new MySqlCommand(stm, conn);
            cmd.Parameters.AddWithValue("@userid", uid);
            rdr = cmd.ExecuteReader();
            rdr.Read();
            string name = rdr["userFirstName"].ToString();
            return name;
        }

        //NEW USER
        public static string NewUser() {
            //CONNECTION STRING
            string cs = @"server=192.168.207.1; userid=dbremoteuser; password=password; database=DigitalPour; port=8889";
            MySqlConnection conn = null;

            conn = new MySqlConnection(cs);
            conn.Open();
            MySqlDataReader rdr = null;

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write(" First Name: ");
                Console.ResetColor();
                string firstname = Console.ReadLine();
               
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write(" Last Name: ");
                Console.ResetColor();           
                string lastname = Console.ReadLine();

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write(" Username: ");
                Console.ResetColor();
                string username = Console.ReadLine();

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write(" Password: ");
                Console.ResetColor();
                string password = Console.ReadLine();

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write(" Email Address: ");
                Console.ResetColor();
                string emailaddress = Console.ReadLine();
             
                //SQL Statement
                string stm = "INSERT INTO users (userId, userFirstName, userLastName, userName, emailAddress, password) VALUES (@userId, @firstname, @lastname, @username, @emailAddress, @password);";
                MySqlCommand cmd = new MySqlCommand(stm, conn);

                string guid = System.Guid.NewGuid().ToString();
                string userId = guid;

                cmd.Parameters.AddWithValue("@userId", userId);
                cmd.Parameters.AddWithValue("@firstname", firstname);
                cmd.Parameters.AddWithValue("@lastname", lastname);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@emailAddress", emailaddress);
                cmd.Parameters.AddWithValue("@password", password);

                rdr = cmd.ExecuteReader();

            Console.WriteLine("\r\n YOUR NEW ACCOUNT HAS BEEN CREATED ===", firstname.ToUpper());
            return userId;

        }

        //UPDATE USER INFORMATION
        public void UpdateInfo(string uid, string loc) {

            string cs = @"server=192.168.207.1; userid=dbremoteuser; password=password; database=DigitalPour; port=8889";
            MySqlConnection conn = null;

            conn = new MySqlConnection(cs);
            conn.Open();
            MySqlDataReader rdr = null;

                //New User Inputs
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write(" First Name: ");
                Console.ResetColor();
                _firstname = Validation.ValidateString();

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write(" Last Name: ");
                Console.ResetColor();
                _lastname = Validation.ValidateString();

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write(" Password: ");
                Console.ResetColor();
                _password = Validation.ValidateString();

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write(" Email Address: ");
                Console.ResetColor();
                _emailaddress = Validation.ValidateString();

                Headers.MainMenu(uid, loc);
                Console.WriteLine(" YOUR ACCOUNT HAS BEEN UPDATED");
                Headers.LineBreak();

                string stm = "UPDATE Users SET userFirstName = @firstname, userLastName = @lastname, password = @password, emailAddress = @emailAddress WHERE userID = @userId;";

                MySqlCommand cmd = new MySqlCommand(stm, conn);
                cmd.Parameters.AddWithValue("@userId", _userId);
                cmd.Parameters.AddWithValue("@firstname", _firstname);
                cmd.Parameters.AddWithValue("@lastname", _lastname);;
                cmd.Parameters.AddWithValue("@password", _password);
                cmd.Parameters.AddWithValue("@emailAddress", _emailaddress);

                rdr = cmd.ExecuteReader();
            
            conn.Close();

        }

    }
}
