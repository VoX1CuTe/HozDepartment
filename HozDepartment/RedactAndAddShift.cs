using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HozDepartment
{
    public partial class RedactAndAddShift : Form
    {
        private string connString;
        public RedactAndAddShift(string connString)
        {
            InitializeComponent();
            this.connString = connString;
            LoadEmployees();
            LoadBody();
            LoadFloor();
            LoadTypeSmena();
        }

        private void LoadEmployees()
        {
            string sql = @"SELECT Id_Employee, CONCAT(Surname, ' ', Name, ' ', Middle_name) AS FullName FROM Staff";

            using (MySqlConnection conn = new MySqlConnection(this.connString))
            {
                conn.Open();
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conn))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    CbStaff.DataSource = null;
                    CbStaff.Items.Clear();
                    CbStaff.DataSource = dt;
                    CbStaff.DisplayMember = "FullName";
                    CbStaff.ValueMember = "Id_Employee";
                }
            }
        }

        private void LoadBody()
        {
            string sql = @"SELECT Id_Body,Body_name FROM Body";
            using (MySqlConnection conn = new MySqlConnection(this.connString))
            {
                conn.Open();
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conn))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    CbBody.DataSource = dt;
                    CbBody.DisplayMember = "Body_name";
                    CbBody.ValueMember = "Id_Body";
                }
            }
        }

        private void LoadFloor()
        {
            string sql = @"SELECT Id_Floor, Floor_number FROM Floor";

            using (MySqlConnection conn = new MySqlConnection(this.connString))
            {
                conn.Open();
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conn))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    GbFloorNumber.DataSource = dt;
                    GbFloorNumber.DisplayMember = "Floor_number";
                    GbFloorNumber.ValueMember = "Id_Floor";
                }
            }
        }

        private void LoadTypeSmena() 
        {
            string sql = @"SELECT Id_Tvm_Smena, Change_name,
                CONCAT(TIME_FORMAT(Start_Time, '%H:%i'), ' - ', TIME_FORMAT(End_Time, '%H:%i')) AS TimeWork FROM Shift_type";

            using (MySqlConnection conn = new MySqlConnection(this.connString))
            {
                conn.Open();
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conn))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    CbTypeSmena.DataSource = dt;
                    CbTypeSmena.DisplayMember = "Change_name";
                    CbTimeWork.DisplayMember = "TimeWork";

                    CbTimeWork.DataSource = dt;
                    CbTimeWork.DisplayMember = "TimeWork";
                    CbTimeWork.ValueMember = "Id_Tvm_Smena";
                }
            }
        }

        private void BtSave_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void BtCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
