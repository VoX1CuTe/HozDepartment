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
        }

        private void LoadEmployees()
        {
            string sql = @"SELECT Id_Employee,
               CONCAT(Surname, ' ', Name, ' ', Middle_name) AS FullName FROM Staff";

            using (MySqlConnection conn = new MySqlConnection(this.connString))
            {
                conn.Open();
                using (MySqlDataAdapter ad = new MySqlDataAdapter(sql, conn))
                {
                    DataTable dt = new DataTable();
                    ad.Fill(dt);

                    CbStaff.DataSource = null;
                    CbStaff.Items.Clear();
                    CbStaff.DataSource = dt;
                    CbStaff.DisplayMember = "FullName";
                    CbStaff.ValueMember = "Id_Employee";
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
