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
    class Connection
    {

        private static MySqlConnection Conn()  {
            MySqlConnection conn = null;
            conn = new MySqlConnection(ConnectionString());
            return conn;
        }

        public static string ConnectionString()  {
            string ip = "";
            using (StreamReader sr = new StreamReader(@"C:\VFW\connect.txt")) {
                ip = sr.ReadLine();
            }

            string cs = @"server=192.168.207.1; userid=dbremoteuser; password=password; database=DigitalPour; port=8889";
            return cs;
        }

        public static void OpenConnection() {
            try  {
                Conn().Open();
            }
            catch (MySqlException e) {
                string msg = "";
                switch (e.Number) {
                    case 0: {
                            msg = e.ToString();
                        }
                        break;
                    case 1042:  {
                            msg = " Can't resolve host address.\r\n" + Conn().ConnectionString;
                        }
                        break;
                    case 1045:  {
                            msg = " Invalid username/password";
                        }
                        break;
                    default: {
                            msg = e.ToString();
                        }
                        break;
                }

                Console.WriteLine(msg);
            }
        }

        public static DataTable QueryDB(string query) {
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, Conn());
            DataTable data = new DataTable();

            adapter.SelectCommand.CommandType = CommandType.Text;
            adapter.Fill(data);

            return data;
        }

        public static void CloseConnection()  {
            Conn().Close();
        }
    }
}
