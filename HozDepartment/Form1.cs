using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Ocsp;
using System.ComponentModel.Design.Serialization;
using System.Data;
using System.Diagnostics;
using System.Runtime.InteropServices;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace HozDepartment
{
    public partial class MainForm : Form
    {
        string role;
        string FuelName;
        public MainForm(string connRole, string fuelName)
        {
            InitializeComponent();
            role = connRole;
            FuelName = fuelName;
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

        string connString;
        private void MainForm_Load(object sender, EventArgs e)
        {
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

                    if (role == "Admin")
                    {
                        UserLb.Text = $"Ðîëü: {FuelName}";
                    }

                    else if (role == "Manager")
                    {
                        UserLb.Text = $"Ðîëü: {FuelName}";
                        BtRedactUser.Visible = false;
                    }

                    else if (role == "User")
                    {
                        UserLb.Text = $"Ðîëü: {FuelName}";
                        BtRedactUser.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Íå óäàëîñü ïîäêëþ÷èòüñÿ ê ñåðâåðó");
            }
        }


        private void BtRedactUser_Click(object sender, EventArgs e)
        {
            InfoUser infoUser = new InfoUser();
            infoUser.ShowDialog();
        }

        void fillTableSclad()
        {
            string sqlSclad = @"SELECT 
                inv.Name AS Inventory_Name,
                cat.Category_name,
                inv.Unit_Measurements,
                ent.Quantity AS Entrance_Quantity,
                ent.Access_Date,
                pay.QuantityP AS Payout_Quantity,
                pay.Release_date,
                pay.Return_date,
                CONCAT(st.Surname, ' ', st.Name, ' ', st.Middle_name) AS FIO,
    
                inv.Id_Inventory,
                cat.Id_Category,
                ent.Id_Entrance,
                pay.Id_Issue,
                pay.Id_Employee
    
                FROM Inventory inv
                LEFT JOIN Category_material cat ON inv.Id_Category = cat.Id_Category
                LEFT JOIN Entrance ent ON inv.Id_Inventory = ent.Id_Inventory
                LEFT JOIN Payout_in_work pay ON inv.Id_Inventory = pay.Id_Inventory
                LEFT JOIN Staff st ON pay.Id_Employee = st.Id_Employee
                ORDER BY ent.Access_Date DESC, inv.Name ASC;";

            using (MySqlConnection conn = new MySqlConnection(this.connString))
            {
                conn.Open();
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(sqlSclad, conn))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    TbSclad.DataSource = dt;
                }
            }
        }
        private void Sclad_Click(object sender, EventArgs e)
        {
            TbSclad.Visible = true;

            TbShift.Visible = false;

            fillTableSclad();
        }
        private DataGridView activeTable;
        private void TbSclad_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                activeTable = TbSclad;
                ContextMenuSclad.Show(TbSclad, e.Location);
            }
        }

        private void StripMenuAddSclad_Click(object sender, EventArgs e)
        {
            if (activeTable == TbSclad)
            {
                using (ReadactAndAddSclad readactAndAddSclad = new ReadactAndAddSclad(connString))
                {
                    if (readactAndAddSclad.ShowDialog() == DialogResult.OK)
                    {
                        readactAndAddSclad.LbRedactAndAdd.Text = "Äîáàâëåíèå";

                        int idEmployee = Convert.ToInt32(readactAndAddSclad.CbEmployee.SelectedValue);
                        int idCategory = Convert.ToInt32(readactAndAddSclad.CbCategory.SelectedValue);
                        long actualInventoryId; long finalInventoryId;

                        using (MySqlConnection conn = new MySqlConnection(this.connString))
                        {
                            conn.Open();

                            string sqlInventory = @"INSERT INTO Inventory (Id_Category, Name, Unit_Measurements) VALUES (@Id_Category, @Name, @Unit_Measurements)";

                            using (MySqlCommand cmd = new MySqlCommand(sqlInventory, conn))
                            {
                                cmd.Parameters.AddWithValue("@Id_Category", idCategory);
                                cmd.Parameters.AddWithValue("@Name", readactAndAddSclad.TbNameInventory.Text);
                                cmd.Parameters.AddWithValue("@Unit_Measurements", readactAndAddSclad.CbUnitMeasurements.Text);
                                cmd.ExecuteNonQuery();
                                actualInventoryId = cmd.LastInsertedId;
                                finalInventoryId = cmd.LastInsertedId;
                            }

                            string sqlEntrance = @"INSERT INTO Entrance (Id_Inventory, Access_Date, Quantity) VALUES (@Id_Inventory, @Access_Date, @Quantity)";

                            using (MySqlCommand cmd = new MySqlCommand(sqlEntrance, conn))
                            {
                                cmd.Parameters.AddWithValue("@Id_Inventory", actualInventoryId);
                                cmd.Parameters.AddWithValue("@Access_Date", readactAndAddSclad.DtEntranceSclad.Value);
                                cmd.Parameters.AddWithValue("@Quantity", readactAndAddSclad.TbInventoríColl.Text);
                                cmd.ExecuteNonQuery();
                            }

                            string sqlPayout = @"INSERT INTO Payout_in_work (Id_Inventory, Id_Employee, Release_date, QuantityP, Return_date) VALUES (@Id_Inventory, @Id_Employee, @Release_date, @QuantityP, @Return_date)";

                            using (MySqlCommand cmd = new MySqlCommand(sqlPayout, conn))
                            {
                                cmd.Parameters.AddWithValue("@Id_Employee", idEmployee);
                                cmd.Parameters.AddWithValue("@Id_Inventory", actualInventoryId);
                                cmd.Parameters.AddWithValue("@Release_date", readactAndAddSclad.DtPuttingWork.Value);
                                cmd.Parameters.AddWithValue("@QuantityP", readactAndAddSclad.TbQualityInventory.Text);
                                cmd.Parameters.AddWithValue("@Return_date", readactAndAddSclad.DtReturnInventory.Value);
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }

                    fillTableSclad();
                }
            }
        }

        private void StripMenuRedactSclad_Click(object sender, EventArgs e)
        {
            if (activeTable == TbSclad)
            {

                using (ReadactAndAddSclad readactAndAddSclad = new ReadactAndAddSclad(connString))
                {
                    readactAndAddSclad.TbNameInventory.Text = TbSclad.CurrentRow.Cells["Inventory_Name"].Value.ToString();
                    readactAndAddSclad.CbCategory.Text = TbSclad.CurrentRow.Cells["Category_name"].Value.ToString();
                    readactAndAddSclad.TbInventoríColl.Text = TbSclad.CurrentRow.Cells["Entrance_Quantity"].Value.ToString();
                    readactAndAddSclad.DtEntranceSclad.Value = Convert.ToDateTime(TbSclad.CurrentRow.Cells["Release_date"].Value);
                    readactAndAddSclad.DtPuttingWork.Value = Convert.ToDateTime(TbSclad.CurrentRow.Cells["Access_Date"].Value);
                    readactAndAddSclad.DtReturnInventory.Value = Convert.ToDateTime(TbSclad.CurrentRow.Cells["Return_date"].Value);
                    readactAndAddSclad.TbQualityInventory.Text = TbSclad.CurrentRow.Cells["Payout_Quantity"].Value.ToString();
                    readactAndAddSclad.CbUnitMeasurements.Text = TbSclad.CurrentRow.Cells["Unit_Measurements"].Value.ToString();
                    readactAndAddSclad.CbEmployee.Text = TbSclad.CurrentRow.Cells["FIO"].Value.ToString();


                    readactAndAddSclad.LbRedactAndAdd.Text = "Ðåäàêòèðîâàíèå";

                    if (readactAndAddSclad.ShowDialog() == DialogResult.OK)
                    {

                        int Id_Inventory = Convert.ToInt32(TbSclad.CurrentRow.Cells["Id_Inventory"].Value);
                        int Id_Entrance = Convert.ToInt32(TbSclad.CurrentRow.Cells["Id_Entrance"].Value);
                        int Id_Category = Convert.ToInt32(readactAndAddSclad.CbCategory.SelectedValue);
                        int Id_Issue = Convert.ToInt32(TbSclad.CurrentRow.Cells["Id_Issue"].Value);
                        int Id_Employee = Convert.ToInt32(TbSclad.CurrentRow.Cells["Id_Employee"].Value);

                        using (MySqlConnection conn = new MySqlConnection(this.connString))
                        {
                            conn.Open();

                            string sqlRedactInventory = @"UPDATE Inventory SET Name = @Name, Unit_Measurements = @Unit_Measurements, Id_Category = @Id_Category WHERE Id_Inventory = @Id_Inventory";

                            using (MySqlCommand cmd = new MySqlCommand(sqlRedactInventory, conn))
                            {
                                cmd.Parameters.AddWithValue("@Id_Inventory", Id_Inventory);
                                cmd.Parameters.AddWithValue("@Id_Category", Id_Category);
                                cmd.Parameters.AddWithValue("@Name", readactAndAddSclad.TbNameInventory.Text);
                                cmd.Parameters.AddWithValue("@Unit_Measurements", readactAndAddSclad.CbUnitMeasurements.Text);
                                cmd.ExecuteNonQuery();
                            }

                            string sqlRedactEntrance = "UPDATE Entrance SET Access_Date = @Access_Date, Quantity = @Quantity WHERE Id_Entrance = @Id_Entrance";

                            using (MySqlCommand cmd = new MySqlCommand(sqlRedactEntrance, conn))
                            {
                                cmd.Parameters.AddWithValue("@Id_Entrance", Id_Entrance);
                                cmd.Parameters.AddWithValue("@Access_Date", readactAndAddSclad.DtEntranceSclad.Value);
                                cmd.Parameters.AddWithValue("@Quantity", readactAndAddSclad.TbInventoríColl.Text);
                                cmd.ExecuteNonQuery();
                            }

                            string sqlRedactPayouInWork = "UPDATE Payout_in_work SET Id_Inventory = @Id_Inventory, Id_Employee = @Id_Employee, Release_date = @Release_date, QuantityP = @QuantityP, Return_date = @Return_date WHERE Id_Issue = @Id_Issue";

                            using (MySqlCommand cmd = new MySqlCommand(sqlRedactPayouInWork, conn))
                            {
                                cmd.Parameters.AddWithValue("@Id_Inventory", Id_Inventory);
                                cmd.Parameters.AddWithValue("@Id_Employee", Id_Employee);
                                cmd.Parameters.AddWithValue("@Release_date", readactAndAddSclad.DtPuttingWork.Value);
                                cmd.Parameters.AddWithValue("@QuantityP", readactAndAddSclad.TbQualityInventory.Text);
                                cmd.Parameters.AddWithValue("@Return_date", readactAndAddSclad.DtReturnInventory.Value);
                                cmd.Parameters.AddWithValue("@Id_Issue", Id_Issue);
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }

                    fillTableSclad();
                }
            }
        }

        void fillTabelShift()
        {
            string sqlShift = @"SELECT
             

	            CONCAT(st.Surname,' ',st.Name,' ',st.Middle_name) AS FIO_Shift,
                ash.Date_of_shift,
                sh.Change_name,
                CONCAT(TIME_FORMAT(sh.Start_Time, '%H:%i'), ' - ', TIME_FORMAT(sh.End_Time, '%H:%i')) AS TimeWork,
                ps.Schedule_assignment_date,
                b.Body_name,
                f.Floor_number,
                ash.Cause_change
    
                FROM The_actual_shift ash
                LEFT JOIN Planned_scheduló ps ON ps.Id_Grahy = ash.Id_Grahy
                LEFT JOIN Staff st ON st.Id_Employee = ps.Id_Employee
                LEFT JOIN Shift_type sh ON sh.Id_Tvm_Smena = ash.`Id_ Type_of_Substitution`
                LEFT JOIN Place_work pw ON pw.Id_Place = ash.Id_Place
                LEFT JOIN Body b ON b.Id_Body = pw.Id_Body
                LEFT JOIN Floor f ON f.Id_Floor = pw.Id_Floor;";

            using (MySqlConnection conn = new MySqlConnection(this.connString))
            {
                conn.Open();
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(sqlShift, conn))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    TbShift.DataSource = dt;
                }
            }
        }

        private void BtShift_Click(object sender, EventArgs e)
        {
            TbShift.Visible = true;

            TbSclad.Visible = false;

            fillTabelShift();
        }

        private void TbShift_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                activeTable = TbShift;
                ContextMenuShift.Show(TbShift, e.Location);
            }
        }

        private void StripMenuAdd_Click(object sender, EventArgs e)
        {
            if (activeTable == TbShift)
            {

                using (RedactAndAddShift readactAndAddShift = new RedactAndAddShift(connString))
                {
                    if (readactAndAddShift.ShowDialog() == DialogResult.OK)
                    {
                        using (MySqlConnection conn = new MySqlConnection(this.connString))
                        {
                            string sqlAddShiftTheActualShift = @"INSERT INTO The_actual_shift (Id_Grahy, Date_of_shift, Cause_change) VALUES (@Id_Grahy, @Date_of_shift, @Cause_change)";

                            conn.Open();
                            using (MySqlCommand cmd = new MySqlCommand(sqlAddShiftTheActualShift, conn))
                            {
                                cmd.Parameters.AddWithValue("@Date_of_shift", readactAndAddShift.DtShift.Value);
                                cmd.Parameters.AddWithValue("@Cause_change", readactAndAddShift.TbNameInventory.Text);
                                cmd.ExecuteNonQuery();
                            }

                            string sqlAddShiftChangeName = @"INSERT INTO Shift_type (Id_Tvm_Smena,Change_name,Start_Time,End_Time) VALUES(@Id_Tvm_Smena,@Change_name,@Start_Time,@End_Time)";

                            using (MySqlCommand cmd = new MySqlCommand(sqlAddShiftChangeName, conn))
                            {
                                cmd.Parameters.AddWithValue("@Change_name", readactAndAddShift.CbTypeSmena.Text);
                                string[] timeRange = readactAndAddShift.CbTimeWork.Text.Split(new[] { " - " }, StringSplitOptions.None);

                                if (timeRange.Length == 2)
                                {
                                    cmd.Parameters.AddWithValue("@Start_Time", timeRange[0].Trim());
                                    cmd.Parameters.AddWithValue("@End_Time", timeRange[1].Trim());
                                }
                                cmd.ExecuteNonQuery();
                            }

                            string sqlAddShiftBody = @"INSERT INTO Body (Id_Body, Body_name) VALUES (@Id_Body, @Body_name)";

                            using (MySqlCommand cmd = new MySqlCommand(sqlAddShiftBody, conn))
                            {
                                cmd.Parameters.AddWithValue("@Body_name", readactAndAddShift.CbBody.Text);
                            }

                            string sqlAddShiftFloor = @"INSERT INTO Floor (Id_Floor,Floor_number) VALUES (@Id_Floor,@Floor_number)";

                            using (MySqlCommand cmd = new MySqlCommand(sqlAddShiftFloor, conn))
                            {
                                cmd.Parameters.AddWithValue("@Floor_number", readactAndAddShift.GbFloorNumber.Text);
                            }
                        }
                    }
                }
            }
        }
    }
}