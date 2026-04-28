using Xunit;
using System.Data;
using HozDepartment;
using MySql.Data.MySqlClient;

namespace xUnitHozDepartment
{
    public class ShiftComplexTests
    {
        private string GetConnStringFromConfig()
        {
            string connString = "";
            string configPath = Path.Combine(Application.StartupPath, "config.ini");

            if (File.Exists(configPath))
            {
                string[] lines = File.ReadAllLines(configPath);
                string server = "", port = "", database = "", user = "", password = "";


                foreach (string line in lines)
                {
                    if (line.StartsWith("Server=")) server = line.Replace("Server=", "");
                    if (line.StartsWith("Port=")) port = line.Replace("Port=", "");
                    if (line.StartsWith("Database=")) database = line.Replace("Database=", "");
                    if (line.StartsWith("User=")) user = line.Replace("User=", "");
                    if (line.StartsWith("Password=")) password = line.Replace("Password=", "");
                }

                connString = $"Server={server};Database={database};Port={port};Uid={user};Pwd={password};";
            }

            else
            {
                throw new FileNotFoundException($"Файл config.ini не найден по пути: {configPath}");
            }

            return connString;
        }

        [Fact]
        public void TestInsertStaff()
        {
            string connString = GetConnStringFromConfig();
            int countBefore = 0;
            int countAfter = 0;
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();

                using (MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM Staff", conn))
                {
                    countBefore = Convert.ToInt32(cmd.ExecuteScalar());
                }
                using (MySqlCommand cmdAdd = new MySqlCommand("AddEmployee", conn))
                {
                    cmdAdd.CommandType = CommandType.StoredProcedure;
                    cmdAdd.Parameters.AddWithValue("p_Post", "Тест");
                    cmdAdd.Parameters.AddWithValue("p_Type_graphy", "Смена");
                    cmdAdd.Parameters.AddWithValue("p_Acceptance_date", DateTime.Now);
                    cmdAdd.Parameters.AddWithValue("p_Birthday", new DateTime(2000, 1, 1));
                    cmdAdd.Parameters.AddWithValue("p_Surname", "Тестовый");
                    cmdAdd.Parameters.AddWithValue("p_Name", "Виктор");
                    cmdAdd.Parameters.AddWithValue("p_Middle_name", "Тестович");
                    cmdAdd.Parameters.AddWithValue("p_Seria_Pass", "0000");
                    cmdAdd.Parameters.AddWithValue("p_Number_Pass", "000000");
                    cmdAdd.Parameters.AddWithValue("p_Pol", "Мужской");
                    cmdAdd.Parameters.AddWithValue("p_Phone_number", "000");

                    cmdAdd.ExecuteNonQuery();
                }

                using (MySqlCommand cmdCount = new MySqlCommand("SELECT COUNT(*) FROM Staff", conn))
                {
                    countAfter = Convert.ToInt32(cmdCount.ExecuteScalar());
                }

                Assert.Equal(countBefore + 1, countAfter);
            }
        }
    }
}