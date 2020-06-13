using MySql.Data.MySqlClient;
using Renci.SshNet.Security.Cryptography;
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

            Console.WriteLine("\t|\t  Number \t|\t  Name  \t|\t Direction  |");

            while (reader.Read())
            {
                Console.WriteLine($"\t|\t{reader.GetInt32(0)}\t|\t Congratulations: {reader.GetString(1)}\t|\t From: {reader.GetString(2)}");
            }
        }

        public void getCustomer(string name, string direction)
        {
            string sql = "SELECT * FROM customer where name = 'Becky Sullivan'"+ name;
            using var cmd = new MySqlCommand(sql, con);

            using MySqlDataReader reader = cmd.ExecuteReader();

            Console.WriteLine("Number |\t  Name  \t\t|\t Direction  |");

            while (reader.Read())
            {
                Console.WriteLine($"{reader.GetInt32(0)}\t|\t{reader.GetString(1)}\t|\t{reader.GetString(2)}");
            }
        }
        public void insertData(string name, string direction)
        {
            using var cmd = new MySqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "INSERT INTO customer (name, direction) VALUES ('Freaky Friday', 'North West')";
            cmd.ExecuteNonQuery();
        }
    }
}
