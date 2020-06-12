using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CustomerData
{
    class CustomerDBReader
    {
        private MySqlConnection con;
        public CustomerDBReader(MySqlConnection con)
        {
            this.con = con;
        }

        public void readAllData()
        {
            string sql = "SELECT * FROM customer";
            using var cmd = new MySqlCommand(sql, con);

            using MySqlDataReader reader = cmd.ExecuteReader();

            Console.WriteLine("\t|\t  Number |\t  Name  \t\t|\t Direction  |");

            while (reader.Read())
            {
                Console.WriteLine($"\t|\t{reader.GetInt32(0)}\t|\t Congratulations: {reader.GetString(1)}\t|\t From: {reader.GetString(2)}");
            }
        }
    }
}
