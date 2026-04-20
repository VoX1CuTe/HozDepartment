using Microsoft.VisualBasic.ApplicationServices;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HozDepartment
{
    public partial class InfoUser : Form
    {
        public InfoUser()
        {
            InitializeComponent();
        }

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private void PanelToolbar_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, 0xA1, 2, 0);
            }
        }

        private void TbUserData_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                ContextMenuStrip.Show(TbUserData, e.Location);
            }
        }



        string connString;
        private void InfoUser_Load(object sender, EventArgs e)
        {
            Size = new Size(619, 277);

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

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    conn.Open();
                    fillTableInfoUser();
                }
            }
            catch
            {
                MessageBox.Show("Ошибка");
            }
        }

        void fillTableInfoUser()
        {
            string sqlUserData = @"SELECT `User`.id,`User`.Role, `User`.Login, `User`.`Password`,
                `User`.FuelName FROM `User`";

            using (MySqlConnection conn = new MySqlConnection(this.connString))
            {
                conn.Open();
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(sqlUserData, conn))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    TbUserData.DataSource = dt;
                }
            }
        }

        private void ClearFields()
        {
            TbLogin.Clear();
            TbPassword.Clear();
            CbRole.SelectedIndex = -1;
            TbUserName.Clear();
        }

        private enum FormMode
        {
            Add, Edit
        }
        private FormMode mode;
        private int selectId;

        private void StripMenuAdd_Click(object sender, EventArgs e)
        {
            mode = FormMode.Add;
            ClearFields();

            Size = new Size(1019, 277);

            LbLogin.Visible = true;
            LbPassword.Visible = true;
            LbRole.Visible = true;
            LbUserName.Visible = true;

            TbLogin.Visible = true;
            TbPassword.Visible = true;
            TbUserName.Visible = true;
            CbRole.Visible = true;

            btSave.Visible = true;
        }

        private void StripMenuRedact_Click(object sender, EventArgs e)
        {
            if (TbUserData.CurrentRow == null) return;

            mode = FormMode.Edit;
            selectId = Convert.ToInt32(TbUserData.CurrentRow.Cells["id"].Value);

            Size = new Size(1019, 277);

            LbLogin.Visible = true;
            LbPassword.Visible = true;
            LbRole.Visible = true;
            LbUserName.Visible = true;

            TbLogin.Visible = true;
            TbPassword.Visible = true;
            TbUserName.Visible = true;
            CbRole.Visible = true;

            btSave.Visible = true;

            TbLogin.Text = TbUserData.CurrentRow.Cells["Login"].Value.ToString();
            TbPassword.Text = TbUserData.CurrentRow.Cells["Password"].Value.ToString();
            CbRole.Text = TbUserData.CurrentRow.Cells["Role"].Value.ToString();
            TbUserName.Text = TbUserData.CurrentRow.Cells["FuelName"].Value.ToString();

        }

        private void btSave_Click(object sender, EventArgs e)
        {
            if (mode == FormMode.Add)
            {
                string sqlAddUser = "INSERT INTO User (Login, Password, Role, FuelName) VALUES (@Login, @Password, @Role, @FuelName)";

                using (MySqlConnection conn = new MySqlConnection(this.connString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(sqlAddUser, conn))
                    {
                        cmd.Parameters.AddWithValue("@Login", TbLogin.Text);
                        cmd.Parameters.AddWithValue("@Password", TbPassword.Text);
                        cmd.Parameters.AddWithValue("@Role", CbRole.Text);
                        cmd.Parameters.AddWithValue("@FuelName", TbUserName.Text);
                        cmd.ExecuteNonQuery();
                    }

                    fillTableInfoUser();
                }

                Size = new Size(619, 277);

                LbLogin.Visible = false;
                LbPassword.Visible = false;
                LbRole.Visible = false;
                LbUserName.Visible = false;

                TbLogin.Visible = false;
                TbPassword.Visible = false;
                TbUserName.Visible = false;
                CbRole.Visible = false;

                btSave.Visible = false;
            }

            else if (mode == FormMode.Edit)
            {
                int id = Convert.ToInt32(TbUserData.CurrentRow.Cells["id"].Value);


                string sqlUpdateUser = "UPDATE User SET Login = @Login, Password = @Password, Role = @Role, FuelName = @FuelName WHERE id = @Id";

                using (MySqlConnection conn = new MySqlConnection(this.connString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(sqlUpdateUser, conn))
                    {
                        cmd.Parameters.AddWithValue("@Login", TbLogin.Text);
                        cmd.Parameters.AddWithValue("@Password", TbPassword.Text);
                        cmd.Parameters.AddWithValue("@Role", CbRole.Text);
                        cmd.Parameters.AddWithValue("@FuelName", TbUserName.Text);
                        cmd.Parameters.AddWithValue("@Id", id);
                        cmd.ExecuteNonQuery();    
                    }
                    fillTableInfoUser();
                }

                if (TbLogin.Text == "")
                {
                    MessageBox.Show("Поле логин пустое!");
                }

                else if (TbPassword.Text == "")
                {
                    MessageBox.Show("Поле пароль пустое!");
                }

                else if (CbRole.Text == "")
                {
                    MessageBox.Show("Не выбрана роль!");
                }

                else if (TbUserName.Text == "")
                {
                    MessageBox.Show("Поле имя пользователя пустое!");
                }

                Size = new Size(619, 277);

                LbLogin.Visible = false;
                LbPassword.Visible = false;
                LbRole.Visible = false;
                LbUserName.Visible = false;

                TbLogin.Visible = false;
                TbPassword.Visible = false;
                TbUserName.Visible = false;
                CbRole.Visible = false;

                btSave.Visible = false;
            }
        }

        private void StripMenuDelete_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(TbUserData.CurrentRow.Cells["id"].Value);   
            using (MySqlConnection conn = new MySqlConnection(this.connString))
            {
                conn.Open(); 
                string sqlDeleteUser = "DELETE FROM User WHERE id = @id";
                using (MySqlCommand cmd = new MySqlCommand(sqlDeleteUser, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();       
                }

                fillTableInfoUser();
            }
        }
    }
}