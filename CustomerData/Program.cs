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

            CustomerDBReader customerDBReader = new CustomerDBReader(con);
            customerDBReader.readAllData();
                               
        }
    }
}
