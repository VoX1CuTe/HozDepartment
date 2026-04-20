using MySql.Data.MySqlClient;
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
    public partial class ReadactAndAddSclad : Form
    {

        private string connString;

        public ReadactAndAddSclad(string connString)
        {
            InitializeComponent();
            this.connString = connString;
            LoadCategories();
            LoadEmployees();
        }

        private void LoadCategories()
        {
            string sql = "SELECT Id_Category, Category_name FROM Category_material";

            using (MySqlConnection conn = new MySqlConnection(this.connString))
            {
                conn.Open();
                using (MySqlDataAdapter da = new MySqlDataAdapter(sql, conn))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    CbCategory.DataSource = dt;
                    CbCategory.DisplayMember = "Category_name";
                    CbCategory.ValueMember = "Id_Category";
                }
            }
        }

        private void LoadEmployees()
        {
            string sql = @"SELECT Id_Employee,
               CONCAT(Surname, ' ', Name, ' ', Middle_name) AS FullName FROM Staff";

            using (MySqlConnection conn = new MySqlConnection(this.connString))
            {
                conn.Open();
                using (MySqlDataAdapter da = new MySqlDataAdapter(sql, conn))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    CbEmployee.DataSource = null;
                    CbEmployee.Items.Clear();
                    CbEmployee.DataSource = dt;
                    CbEmployee.DisplayMember = "FullName";
                    CbEmployee.ValueMember = "Id_Employee";
                }
            }
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
