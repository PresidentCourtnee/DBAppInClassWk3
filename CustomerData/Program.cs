using System;
using MySql.Data.MySqlClient;


namespace CustomerData
{
    class Program
    {
        static void Main(string[] args)
        {
            string cs = @"server=54.187.154.185;userid=courtnees;password=courtnees;database=COURTNEEDB";

            using var con = new MySqlConnection(cs);
            con.Open();

            Console.WriteLine($"MySQL version:   {con.ServerVersion}");

            var stm = "SELECT VERSION()";
            var cmd = new MySqlCommand(stm, con);

            var verson = cmd.ExecuteScalar().ToString();
            Console.WriteLine($"MySQL version: {verson}");

            insertData(con);
                   
        }

        private static void insertData(MySqlConnection con)
        {
            var stm = "INSERT INTO cars (name, price) VALUES ('Limo', '65465189616')";
            var cmd = new MySqlCommand(stm, con);
            cmd.ExecuteNonQuery();
        }
    }
}
