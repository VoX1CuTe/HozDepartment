using Microsoft.VisualBasic.ApplicationServices;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace HozDepartment
{
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
        }

        string connString;

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        private void PanelControl_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, 0xA1, 2, 0);
            }
        }


        private void Registration_Load(object sender, EventArgs e)
        {
            string configPath = Path.Combine(Application.StartupPath, "config.ini");

            if (!File.Exists(configPath))
            {
                string createFile = @"Server=localhost
Database=HouseholdDepartment
User=root
Password=";
                File.WriteAllText(configPath, createFile);
                MessageBox.Show("Файл успешно создан");
            }

            string[] lines = File.ReadAllLines(configPath);
            string server = "", port = "", database = "", user = "", password = "";

            foreach (string line in lines)
            {
                if (line.StartsWith("Server=")) server = line.Replace("Server=", "").Trim();
                if (line.StartsWith("Port=")) port = line.Replace("Port=", "").Trim();
                if (line.StartsWith("Database=")) database = line.Replace("Database=", "").Trim();
                if (line.StartsWith("User=")) user = line.Replace("User=", "").Trim();
                if (line.StartsWith("Password=")) password = line.Replace("Password=", "").Trim();
            }

            connString = $"Server={server};Database={database};Port={port};Uid={user};Pwd={password};";
            string connStringWithoutDB = $"Server={server};Port={port};Uid={user};Pwd={password};";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStringWithoutDB))
                {
                    conn.Open();
                    if (!DbExists(conn, database))
                    {
                        DialogResult dialog = MessageBox.Show(
                            "База данных не найдена!\nДа = Пустая база\nНет = База с тестовыми данными",
                            "Создать базу данных?",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question);

                        string dumpFile;
                        if (dialog == DialogResult.Yes)
                        {
                            dumpFile = "empty_HouseholdDepartment.sql";
                        }
                        else
                        {
                            dumpFile = "data_HouseholdDepartment.sql";
                        }

                        if (CreateDatabase(connStringWithoutDB, database))
                        {
                            ResDump(connString, dumpFile);
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Ошибка подключения");
            }
        }

        private bool DbExists(MySqlConnection conn, string databaseName)
        {
            string query = "SELECT COUNT(*) FROM INFORMATION_SCHEMA.SCHEMATA WHERE SCHEMA_NAME = @db";

            using (var cmd = new MySqlCommand(query, conn))
            {
                try
                {
                    cmd.Parameters.AddWithValue("@db", databaseName);
                    object result = cmd.ExecuteScalar();
                    return result != null && result != DBNull.Value && Convert.ToInt32(result) > 0;
                }
                catch
                {
                    MessageBox.Show("Ошибка провераки существования БД");
                    return false;
                }
            }
        }

        private bool ResDump(string connString, string dumpFile)
        {
            string dumpPath = Path.Combine(Application.StartupPath, dumpFile);

            if (!File.Exists(dumpPath))
                return false;

            try
            {
                using (var conn = new MySqlConnection(connString))
                {
                    using (var cmd = new MySqlCommand())
                    {
                        using (var mb = new MySqlBackup(cmd))
                        {
                            cmd.Connection = conn;
                            conn.Open();
                            mb.ImportFromFile(dumpPath);
                        }
                    }
                }
                    MessageBox.Show("Дамп загружен!");
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"ОШИБКА дампа: {ex.Message}");
                return false;
            }
        }

        string database = "HouseholdDepartment";
        private bool CreateDatabase(string connString, string database)
        {
            try
            {
                using (var conn = new MySqlConnection(connString))
                {
                    conn.Open();
                    string query = $"CREATE DATABASE IF NOT EXISTS `{database}`";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка создания БД: " + ex.Message);
                return false;
            }
        }

        string role = "";
        string FuelName = "";
        private void btEnter_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(this.connString))
            {
                conn.Open();
                MessageBox.Show("Подключалась кнопка Вход");

                string password = "";
                string login = "";

                string sqlRedact = "SELECT * FROM User WHERE Login = '" + textLogin.Text + "' AND Password = '" + textPassword.Text + "'";

                using (var cmd = new MySqlCommand(sqlRedact, conn))
                {
                    MySqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        role = reader["Role"].ToString();
                        password = reader["Password"].ToString();
                        login = reader["Login"].ToString();
                        FuelName = reader["FuelName"].ToString();

                        MainForm mainForm = new MainForm(role, FuelName);
                        mainForm.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Не верный логин или пароль");
                    }
                }
            }
        }
        private void Registration_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}