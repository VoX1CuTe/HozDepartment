using Guna.UI2.WinForms;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Ocsp;
using Org.BouncyCastle.Tls.Crypto;
using System.ComponentModel.Design.Serialization;
using System.Data;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Transactions;
using System.Windows.Forms;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using Excel = Microsoft.Office.Interop.Excel;

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

                    if (role == "User")
                    {
                        UserLb.Text = $"Ðîëü: {FuelName}";
                        BtRedactUser.Visible = false;
                    }


                    TextSearchStaff.Visible = true;
                    CbFilterStaff.Visible = true;
                    TbUser.Visible = true;

                    BtSeal.Visible = false;
                    CbFilterShift.Visible = false;

                    fillTableStaff();
                    fillTableSclad();
                    fillTabelShift();
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
                inv.Unit_Measurements,
                ent.Quantity AS Entrance_Quantity,
                ent.Access_Date,
                pay.QuantityP AS Payout_Quantity,
                pay.Release_date,
                pay.Return_date,
                cat.Category_name,
                CONCAT(st.Surname, ' ', st.Name, ' ', st.Middle_name) AS FIO,

                inv.Id_Inventory
                FROM Inventory inv
                LEFT JOIN Category_material cat ON inv.Id_Category = cat.Id_Category
                LEFT JOIN Entrance ent ON inv.Id_Inventory = ent.Id_Inventory
                LEFT JOIN Payout_in_work pay ON inv.Id_Inventory = pay.Id_Inventory
                LEFT JOIN Staff st ON pay.Id_Employee = st.Id_Employee
                WHERE inv.is_deleted = 0
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
            TbUser.Visible = false;
            BtSeal.Visible = false;
            TextSearchStaff.Visible = false;
            CbFilterStaff.Visible = false;
            CbFilterShift.Visible = false;

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

        private bool clickedEmptySpace;
        private void TbSclad_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                activeTable = TbSclad;
                var hit = TbSclad.HitTest(e.X, e.Y);

                if (hit.RowIndex >= 0)
                {
                    TbSclad.ClearSelection();
                    TbSclad.Rows[hit.RowIndex].Selected = true;

                    TbSclad.CurrentCell = TbSclad.Rows[hit.RowIndex].Cells[hit.ColumnIndex];

                    StripMenuRedactSclad.Visible = true;
                    StripMenuDleteSclad.Visible = true;
                    StripMenuAddSclad.Visible = true;
                }

                else
                {
                    TbSclad.ClearSelection();

                    StripMenuRedactSclad.Visible = false;
                    StripMenuDleteSclad.Visible = false;

                    StripMenuAddSclad.Visible = true;
                }

                ContextMenuSclad.Show(TbSclad, e.Location);
            }
        }

        private void StripMenuAddSclad_Click(object sender, EventArgs e)
        {
            if (activeTable == TbSclad || clickedEmptySpace)
            {
                using (ReadactAndAddSclad readactAndAddSclad = new ReadactAndAddSclad(connString))
                {
                    if (readactAndAddSclad.ShowDialog() == DialogResult.OK)
                    {
                        readactAndAddSclad.LbRedactAndAdd.Text = "Äîáàâëåíèå";

                        int idEmployee = Convert.ToInt32(readactAndAddSclad.CbEmployee.SelectedValue);
                        int idCategory = Convert.ToInt32(readactAndAddSclad.CbCategory.SelectedValue);

                        long actualInventoryId;
                        long finalInventoryId;

                        using (MySqlConnection conn = new MySqlConnection(this.connString))
                        {
                            conn.Open();

                            using (MySqlTransaction transaction = conn.BeginTransaction())
                            {

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
                                transaction.Commit();
                            }
                        }
                    }

                    fillTableSclad();
                }
            }
        }

        private void StripMenuRedactSclad_Click(object sender, EventArgs e)
        {
            if (activeTable == TbSclad || clickedEmptySpace)
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

                            using (MySqlTransaction transaction = conn.BeginTransaction())
                            {

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
                                transaction.Commit();
                            }
                        }
                    }

                    fillTableSclad();
                }
            }
        }

        private void StripMenuDleteSclad_Click(object sender, EventArgs e)
        {
            if (activeTable == TbSclad || clickedEmptySpace)
            {
                using (MySqlConnection conn = new MySqlConnection(this.connString))
                {
                    int idInv = Convert.ToInt32(TbSclad.CurrentRow.Cells["Id_Inventory"].Value);
                    conn.Open();

                    using (MySqlTransaction trancaction = conn.BeginTransaction())
                    {
                        try
                        {
                            string sqlDeletePayoutInWork = "DELETE FROM Payout_in_work WHERE Id_Inventory = @id";
                            using (MySqlCommand cmd = new MySqlCommand(sqlDeletePayoutInWork, conn, trancaction))
                            {
                                cmd.Parameters.AddWithValue("@id", idInv);
                                cmd.ExecuteNonQuery();
                            }

                            string sqlDeleteEntrance = "DELETE FROM entrance WHERE Id_Inventory = @id";
                            using (MySqlCommand cmd = new MySqlCommand(sqlDeleteEntrance, conn, trancaction))
                            {
                                cmd.Parameters.AddWithValue("@id", idInv);
                                cmd.ExecuteNonQuery();
                            }

                            string sqlDeleteInventory = "DELETE FROM Inventory WHERE Id_Inventory = @id";
                            using (MySqlCommand cmd = new MySqlCommand(sqlDeleteInventory, conn, trancaction))
                            {
                                cmd.Parameters.AddWithValue("@id", idInv);
                                cmd.ExecuteNonQuery();
                            }

                            trancaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            trancaction.Rollback();
                            MessageBox.Show("Îøèáêà: " + ex.Message);
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
                ash.Fact_Shifts,
    
                ash.Id_Grahy,
                st.Id_Employee,
                sh.Id_Tvm_Smena,
                pw.Id_Place,
                b.Id_Body,
                f.Id_Floor

                FROM The_actual_shift ash
                LEFT JOIN Planned_scheduló ps ON ps.Id_Grahy = ash.Id_Grahy
                LEFT JOIN Staff st ON st.Id_Employee = ps.Id_Employee
                LEFT JOIN Shift_type sh ON sh.Id_Tvm_Smena = ash.`Id_ Type_of_Substitution`
                LEFT JOIN Place_work pw ON pw.Id_Place = ash.Id_Place
                LEFT JOIN Body b ON b.Id_Body = pw.Id_Body
                LEFT JOIN Floor f ON f.Id_Floor = pw.Id_Floor";

            if (role == "User")
            {
                sqlShift += " WHERE ash.Date_of_shift BETWEEN CURDATE() AND DATE_ADD(CURDATE(), INTERVAL 14 DAY)"; // Ïîïðàâèòü îøèáêó ïðè âõîäå âûëåò!!!!
            }

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
            BtSeal.Visible = true;
            CbFilterShift.Visible = true;

            TbSclad.Visible = false;
            TbUser.Visible = false;
            TextSearchStaff.Visible = false;
            CbFilterStaff.Visible = false;


            fillTabelShift();
        }
        private void TbShift_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                activeTable = TbShift;
                ContextMenuShift.Show(TbShift, e.Location);
            }
        }
        private void TbShift_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {

        }
        private bool clickedEmptySpaceShift;
        private void TbShift_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                activeTable = TbShift;
                var hit = TbShift.HitTest(e.X, e.Y);

                if (hit.RowIndex >= 0)
                {
                    TbShift.ClearSelection();
                    TbShift.Rows[hit.RowIndex].Selected = true;

                    TbShift.CurrentCell = TbShift.Rows[hit.RowIndex].Cells[hit.ColumnIndex];

                    StripMenuRedact.Visible = true;
                    StripMenuDelete.Visible = true;

                    ContextMenuShift.Show(TbShift, e.Location);
                }
                else
                {
                    TbShift.ClearSelection();

                    StripMenuRedact.Visible = false;
                    StripMenuDelete.Visible = false;

                    ContextMenuShift.Show(TbShift, e.Location);
                }
            }
        }

        private void StripMenuAdd_Click(object sender, EventArgs e)
        {
            if (activeTable == TbShift || clickedEmptySpaceShift)
            {
                using (RedactAndAddShift readactAndAddShift = new RedactAndAddShift(connString))
                {
                    if (readactAndAddShift.ShowDialog() == DialogResult.OK)
                    {
                        int idEmployee = Convert.ToInt32(readactAndAddShift.CbStaff.SelectedValue);
                        int idBody = Convert.ToInt32(readactAndAddShift.CbBody.SelectedValue);
                        int idFloor = Convert.ToInt32(readactAndAddShift.GbFloorNumber.SelectedValue);

                        long idShiftType;
                        long idPlace;
                        long idPlannedGrahy;

                        using (MySqlConnection conn = new MySqlConnection(this.connString))
                        {
                            conn.Open();

                            // 19  òðàíçàêöèÿ
                            using (MySqlTransaction trancaction = conn.BeginTransaction())
                            {
                                // 1 Place_work

                                string sqlPlace = @"INSERT INTO Place_work (Id_Body, Id_Floor) VALUES (@Id_Body, @Id_Floor) ";
                                using (MySqlCommand cmd = new MySqlCommand(sqlPlace, conn, trancaction))
                                {
                                    cmd.Parameters.AddWithValue("@Id_Body", idBody);
                                    cmd.Parameters.AddWithValue("@Id_Floor", idFloor);
                                    cmd.ExecuteNonQuery();
                                    idPlace = cmd.LastInsertedId;
                                }

                                // 2 Shift_type
                                if (readactAndAddShift.CbTypeSmena.SelectedValue is DataRowView drv)
                                {
                                    idShiftType = Convert.ToInt64(drv["Id_Tvm_Smena"]);
                                }
                                else
                                {
                                    idShiftType = Convert.ToInt64(readactAndAddShift.CbTypeSmena.SelectedValue);
                                }

                                if (idShiftType <= 0)
                                {
                                    return;
                                }

                                // 3 Planned_scheduló
                                string sqlAddShiftPlannedScheduló = @"INSERT INTO Planned_scheduló (Id_Employee,Schedule_assignment_date) VALUES (@Id_Employee,@Schedule_assignment_date)";

                                using (MySqlCommand cmd = new MySqlCommand(sqlAddShiftPlannedScheduló, conn, trancaction))
                                {

                                    cmd.Parameters.AddWithValue("@Id_Employee", idEmployee);
                                    cmd.Parameters.AddWithValue("@Schedule_assignment_date", readactAndAddShift.DtNzGraf.Value);
                                    cmd.ExecuteNonQuery();
                                    idPlannedGrahy = cmd.LastInsertedId;
                                }
                                // 4 The_actual_shift
                                string sqlAddShiftTheActualShift = @"INSERT INTO The_actual_shift (Id_Grahy, Id_Place, `Id_ Type_of_Substitution`, Date_of_shift, Fact_Shifts) 
                                    VALUES (@Id_Grahy, @Id_Place, @Id_Type_of_Substitution, @Date_of_shift, @Fact_Shifts)";

                                using (MySqlCommand cmd = new MySqlCommand(sqlAddShiftTheActualShift, conn, trancaction))
                                {
                                    cmd.Parameters.AddWithValue("@Id_Type_of_Substitution", idShiftType);
                                    cmd.Parameters.AddWithValue("@Id_Grahy", idPlannedGrahy);
                                    cmd.Parameters.AddWithValue("@Id_Place", idPlace);
                                    cmd.Parameters.AddWithValue("@Date_of_shift", readactAndAddShift.DtShift.Value);
                                    cmd.Parameters.AddWithValue("@Fact_Shifts", readactAndAddShift.TbPrichIzmen.Text);
                                    cmd.ExecuteNonQuery();
                                }
                                trancaction.Commit();
                            }

                            fillTabelShift();
                        }

                    }
                }
            }
        }

        private void StripMenuRedact_Click(object sender, EventArgs e)
        {
            if (activeTable == TbShift || clickedEmptySpaceShift)
            {
                using (RedactAndAddShift readactAndAddShift = new RedactAndAddShift(connString))
                {
                    readactAndAddShift.DtNzGraf.Value = Convert.ToDateTime(TbShift.CurrentRow.Cells["Schedule_assignment_date"].Value);
                    readactAndAddShift.DtShift.Value = Convert.ToDateTime(TbShift.CurrentRow.Cells["Date_of_shift"].Value);
                    readactAndAddShift.TbPrichIzmen.Text = TbShift.CurrentRow.Cells["Fact_Shifts"].Value.ToString();

                    if (readactAndAddShift.ShowDialog() == DialogResult.OK)
                    {

                        int Id_Grahy = Convert.ToInt32(TbShift.CurrentRow.Cells["Id_Grahy"].Value);
                        int Id_Tvm_Smena = Convert.ToInt32(TbShift.CurrentRow.Cells["Id_Tvm_Smena"].Value);
                        int Id_Place = Convert.ToInt32(TbShift.CurrentRow.Cells["Id_Place"].Value);
                        int Id_Body = Convert.ToInt32(readactAndAddShift.CbBody.SelectedValue);
                        int Id_Floor = Convert.ToInt32(readactAndAddShift.GbFloorNumber.SelectedValue);
                        int Id_Employee = Convert.ToInt32(readactAndAddShift.CbStaff.SelectedValue);

                        object selectedValue = readactAndAddShift.CbTypeSmena.SelectedValue;
                        int Id_ShiftType;

                        if (selectedValue is DataRowView row)
                        {
                            Id_ShiftType = Convert.ToInt32(row["Id_Tvm_Smena"]);
                        }
                        else
                        {
                            Id_ShiftType = Convert.ToInt32(selectedValue);
                        }

                        using (MySqlConnection conn = new MySqlConnection(this.connString))
                        {
                            conn.Open();

                            using (MySqlTransaction trancaction = conn.BeginTransaction())
                            {
                                string sqlRedactPlaceAdd = @"UPDATE Place_work SET Id_Body = @Id_Body, Id_Floor=@Id_Floor WHERE Id_Place = @Id_Place";

                                using (MySqlCommand cmd = new MySqlCommand(sqlRedactPlaceAdd, conn, trancaction))
                                {
                                    cmd.Parameters.AddWithValue("@Id_Place", Id_Place);
                                    cmd.Parameters.AddWithValue("@Id_Body", Id_Body);
                                    cmd.Parameters.AddWithValue("@Id_Floor", Id_Floor);
                                    cmd.ExecuteNonQuery();
                                }

                                string sqlRedactPlannedScheduló = @"UPDATE Planned_scheduló SET Id_Employee = @Id_Employee, Schedule_assignment_date = @Schedule_assignment_date WHERE Id_Grahy = @Id_Grahy";

                                using (MySqlCommand cmd = new MySqlCommand(sqlRedactPlannedScheduló, conn, trancaction))
                                {
                                    cmd.Parameters.AddWithValue("@Id_Grahy", Id_Grahy);
                                    cmd.Parameters.AddWithValue("@Id_Employee", Id_Employee);
                                    cmd.Parameters.AddWithValue("@Schedule_assignment_date", readactAndAddShift.DtNzGraf.Value);
                                    cmd.ExecuteNonQuery();
                                }

                                string sqlRedactTheActualShift = @"UPDATE The_actual_shift SET Id_Place = @Id_Place,`Id_ Type_of_Substitution` = @Id_Type_of_Substitution, Date_of_shift = @Date_of_shift, 
                                    Fact_Shifts = @Fact_Shifts WHERE Id_Grahy = @Id_Grahy;";

                                using (MySqlCommand cmd = new MySqlCommand(sqlRedactTheActualShift, conn, trancaction))
                                {
                                    cmd.Parameters.AddWithValue("@Id_Grahy", Id_Grahy);
                                    cmd.Parameters.AddWithValue("@Id_Place", Id_Place);
                                    cmd.Parameters.AddWithValue("@Id_Type_of_Substitution", Id_ShiftType);
                                    cmd.Parameters.AddWithValue("@Date_of_shift", readactAndAddShift.DtShift.Value);
                                    cmd.Parameters.AddWithValue("@Fact_Shifts", readactAndAddShift.TbPrichIzmen.Text);
                                    cmd.ExecuteNonQuery();
                                }
                                trancaction.Commit();
                            }

                            fillTabelShift();
                        }
                    }
                }
            }
        }

        private void StripMenuDelete_Click(object sender, EventArgs e)
        {
            if (activeTable == TbShift || clickedEmptySpaceShift)
            {
                using (MySqlConnection conn = new MySqlConnection(this.connString))
                {
                    conn.Open();
                    using (MySqlTransaction transaction = conn.BeginTransaction())
                    {
                        int Id_Grahy = Convert.ToInt32(TbShift.CurrentRow.Cells["Id_Grahy"].Value);
                        string sqlDeleteTheActualShift = "DELETE FROM The_actual_shift WHERE Id_Grahy = @Id_Grahy";
                        using (MySqlCommand cmd = new MySqlCommand(sqlDeleteTheActualShift, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@Id_Grahy", Id_Grahy);
                            cmd.ExecuteNonQuery();
                        }

                        string sqlDeletePlannedScheduló = "DELETE FROM Planned_scheduló WHERE Id_Grahy = @Id_Grahy";
                        using (MySqlCommand cmd = new MySqlCommand(sqlDeletePlannedScheduló, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@Id_Grahy", Id_Grahy);
                            cmd.ExecuteNonQuery();
                        }

                        string sqlPlace = "DELETE FROM Place_work WHERE Id_Place = @Id_Place";
                        int Id_Place = Convert.ToInt32(TbShift.CurrentRow.Cells["Id_Place"].Value);
                        using (MySqlCommand cmd = new MySqlCommand(sqlPlace, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@Id_Place", Id_Place);
                            cmd.ExecuteNonQuery();
                        }
                        transaction.Commit();
                    }
                    fillTabelShift();
                }
            }
        }

        private void TbUser_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                activeTable = TbUser;
                ContextMenuStaff.Show(TbUser, e.Location);
            }
        }
        private bool clickedEmptySpaceStaff;
        private void TbUser_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                activeTable = TbUser;
                var hit = TbUser.HitTest(e.X, e.Y);

                if (hit.RowIndex >= 0)
                {
                    TbUser.ClearSelection();
                    TbUser.Rows[hit.RowIndex].Selected = true;

                    TbUser.CurrentCell = TbUser.Rows[hit.RowIndex].Cells[hit.ColumnIndex];

                    StripMenuRedactStaff.Visible = true;
                    StripMenuDeleteStaff.Visible = true;
                    StripMenuAddStaff.Visible = true;
                }
                else
                {
                    TbUser.ClearSelection();

                    StripMenuRedactStaff.Visible = false;
                    StripMenuDeleteStaff.Visible = false;

                    StripMenuAddStaff.Visible = true;
                }

                ContextMenuStaff.Show(TbSclad, e.Location);
            }
        }

        void fillTableStaff()
        {
            string sqlStaff = @"SELECT Staff.Id_Employee, CONCAT(Staff.Name,' ', Staff.Surname,' ', Staff.Middle_name) AS Staff_FIO,
                Staff.Birthday, Staff.Pol, Staff.Number_Pass, Staff.Seria_Pass, Staff.Phone_number, Staff.Acceptance_date, Staff.Post, Staff.Type_graphy
                FROM Staff;";

            using (MySqlConnection conn = new MySqlConnection(this.connString))
            {
                conn.Open();
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(sqlStaff, conn))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    TbUser.DataSource = dt;
                }
            }
        }

        private void BtStaff_Click(object sender, EventArgs e)
        {
            TbUser.Visible = true;
            TextSearchStaff.Visible = true;
            CbFilterStaff.Visible = true;

            TbSclad.Visible = false;
            TbShift.Visible = false;
            BtSeal.Visible = false;
            CbFilterShift.Visible = false;
        }

        private void StripMenuAddStaff_Click(object sender, EventArgs e)
        {
            if (activeTable == TbUser || clickedEmptySpaceStaff)
            {
                using (RedactAndAddUsers readactAndAddUser = new RedactAndAddUsers())
                {

                    if (readactAndAddUser.ShowDialog() == DialogResult.OK)
                    {
                        using (MySqlConnection conn = new MySqlConnection(connString))
                        {
                            string selectedPol = readactAndAddUser.rbMale.Checked ? readactAndAddUser.rbMale.Text : readactAndAddUser.rbFemale.Text;
                            conn.Open();
                            using (MySqlCommand cmd = new MySqlCommand("AddEmployee", conn))
                            {
                                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("p_Post", readactAndAddUser.TextPost.Text);
                                cmd.Parameters.AddWithValue("p_Type_graphy", readactAndAddUser.TextTypeGraphy.Text);
                                cmd.Parameters.AddWithValue("p_Acceptance_date", readactAndAddUser.CalendarAcceptanceDate.SelectionStart);
                                cmd.Parameters.AddWithValue("p_Birthday", readactAndAddUser.CalendarBirthday.SelectionStart);
                                cmd.Parameters.AddWithValue("p_Surname", readactAndAddUser.TextSurname.Text);
                                cmd.Parameters.AddWithValue("p_Name", readactAndAddUser.TextName.Text);
                                cmd.Parameters.AddWithValue("p_Middle_name", readactAndAddUser.TextMiddleName.Text);
                                cmd.Parameters.AddWithValue("p_Seria_Pass", readactAndAddUser.TextSeriaPass.Text);
                                cmd.Parameters.AddWithValue("p_Number_Pass", readactAndAddUser.TextNumberPass.Text);
                                cmd.Parameters.AddWithValue("p_Pol", selectedPol);
                                cmd.Parameters.AddWithValue("p_Phone_number", readactAndAddUser.TextPhone.Text);
                                cmd.ExecuteNonQuery();
                            }
                            fillTableStaff();
                        }
                    }
                }
            }

        }

        private void StripMenuRedactStaff_Click(object sender, EventArgs e)
        {
            if (activeTable == TbUser || clickedEmptySpaceStaff)
            {
                int Id_Employee = Convert.ToInt32(TbUser.CurrentRow.Cells["Id_Employye"].Value);
                using (RedactAndAddUsers readactAndAddUser = new RedactAndAddUsers())
                {
                    readactAndAddUser.TextPost.Text = TbUser.CurrentRow.Cells["Post"].Value.ToString();
                    readactAndAddUser.TextTypeGraphy.Text = TbUser.CurrentRow.Cells["Type_graphy"].Value.ToString();
                    readactAndAddUser.CalendarAcceptanceDate.SelectionStart = Convert.ToDateTime(TbUser.CurrentRow.Cells["Acceptance_date"].Value);
                    readactAndAddUser.CalendarBirthday.SelectionStart = Convert.ToDateTime(TbUser.CurrentRow.Cells["Birthday"].Value);

                    string fullName = TbUser.CurrentRow.Cells["Staff_FIO"].Value.ToString();
                    string[] parts = fullName.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    if (parts.Length >= 1) readactAndAddUser.TextSurname.Text = parts[0];
                    if (parts.Length >= 2) readactAndAddUser.TextName.Text = parts[1];
                    if (parts.Length >= 3) readactAndAddUser.TextMiddleName.Text = parts[2];

                    readactAndAddUser.TextSeriaPass.Text = TbUser.CurrentRow.Cells["Seria_Pass"].Value.ToString();
                    readactAndAddUser.TextNumberPass.Text = TbUser.CurrentRow.Cells["Number_Pass"].Value.ToString();
                    readactAndAddUser.TextPhone.Text = TbUser.CurrentRow.Cells["Phone_number"].Value.ToString();

                    if (readactAndAddUser.ShowDialog() == DialogResult.OK)
                    {
                        using (MySqlConnection conn = new MySqlConnection(connString))
                        {
                            conn.Open();
                            string selectedPol = readactAndAddUser.rbMale.Checked ? readactAndAddUser.rbMale.Text : readactAndAddUser.rbFemale.Text;

                            string sqlRedactStaff = @"UPDATE Staff SET Post = @Post, Type_graphy = @Type_graphy, Acceptance_date = @Acceptance_date, Birthday = @Birthday, Phone_number = @Phone_number,
                                Surname = @Surname, Name = @Name, Middle_name = @Middle_name, Pol = @Pol, Seria_Pass = @Seria_Pass, Number_Pass = @Number_Pass WHERE Id_Employee = @Id_Employee";

                            using (MySqlCommand cmd = new MySqlCommand(sqlRedactStaff, conn))
                            {
                                cmd.Parameters.AddWithValue("@Id_Employee", Id_Employee);
                                cmd.Parameters.AddWithValue("@Post", readactAndAddUser.TextPost.Text);
                                cmd.Parameters.AddWithValue("@Type_graphy", readactAndAddUser.TextTypeGraphy.Text);
                                cmd.Parameters.AddWithValue("@Acceptance_date", readactAndAddUser.CalendarAcceptanceDate.SelectionStart);
                                cmd.Parameters.AddWithValue("@Birthday", readactAndAddUser.CalendarBirthday.SelectionStart);
                                cmd.Parameters.AddWithValue("@Surname", readactAndAddUser.TextSurname.Text);
                                cmd.Parameters.AddWithValue("@Name", readactAndAddUser.TextName.Text);
                                cmd.Parameters.AddWithValue("@Middle_name", readactAndAddUser.TextMiddleName.Text);
                                cmd.Parameters.AddWithValue("@Seria_Pass", readactAndAddUser.TextSeriaPass.Text);
                                cmd.Parameters.AddWithValue("@Number_Pass", readactAndAddUser.TextNumberPass.Text);
                                cmd.Parameters.AddWithValue("@Pol", selectedPol);
                                cmd.Parameters.AddWithValue("@Phone_number", readactAndAddUser.TextPhone.Text);
                                cmd.ExecuteNonQuery();
                            }
                            fillTableStaff();
                        }
                    }
                }
            }
        }

        private void StripMenuDeleteStaff_Click(object sender, EventArgs e)
        {
            if (activeTable == TbUser || clickedEmptySpaceStaff)
            {
                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    conn.Open();

                    int Id_Employee = Convert.ToInt32(TbUser.CurrentRow.Cells["Id_Employye"].Value);
                    string sqlDeleteStaff = "DELETE FROM Staff WHERE Id_Employee = @Id_Employee";

                    using (MySqlCommand cmd = new MySqlCommand(sqlDeleteStaff, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id_Employee", Id_Employee);
                        cmd.ExecuteNonQuery();
                    }
                }
            }

            fillTableStaff();
        }

        private void TextSearchStaff_TextChanged(object sender, EventArgs e)
        {
            if (TbUser.DataSource is DataTable dt)
            {
                dt.DefaultView.RowFilter = string.Format("Staff_FIO LIKE '%{0}%'", TextSearchStaff.Text);
                dt.DefaultView.RowFilter = string.Format("Post LIKE '%{0}%'", TextSearchStaff.Text);
                dt.DefaultView.RowFilter = string.Format("Phone_number LIKE '%{0}%'", TextSearchStaff.Text);
                dt.DefaultView.RowFilter = string.Format("Type_graphy LIKE '%{0}%'", TextSearchStaff.Text);
            }
        }

        private void CbFilterStaff_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TbUser.DataSource is DataTable dt)
            {
                string selected = CbFilterStaff.SelectedItem.ToString();
                DataView dv = dt.DefaultView;

                switch (selected)
                {
                    case "Ñáðîñèòü âñ¸":
                        dv.RowFilter = "";
                        dv.Sort = "";
                        break;

                    case "Ïîë (À-ß)":
                        dv.RowFilter = "";
                        dv.Sort = "Pol ASC";
                        break;

                    case "Ïîë (ß-À)":
                        dv.RowFilter = "";
                        dv.Sort = "Pol DESC";
                        break;

                    case "Äîëæíîñòü (À-ß)":
                        dv.RowFilter = "";
                        dv.Sort = "Post ASC";
                        break;

                    case "Äîëæíîñòü (ß-À)":
                        dv.RowFilter = "";
                        dv.Sort = "Post DESC";
                        break;

                    case "Äàòà ïðèåìà (Íîâûå)":
                        dv.RowFilter = "";
                        dv.Sort = "Acceptance_date DESC";
                        break;

                    case "Äàòà ïðèåìà (Ñòàðûé)":
                        dv.RowFilter = "";
                        dv.Sort = "Acceptance_date ASC";
                        break;

                    default:

                        dv.RowFilter = string.Format("Post = '{0}'", selected);
                        dv.Sort = "";
                        break;
                }
            }
        }

        private void BtnBackup_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(connString))
            {
                MessageBox.Show("Îøèáêà: Äàííûå ïîäêëþ÷åíèÿ íå çàãðóæåíû èç config.ini");
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "SQL Files (*.sql)|*.sql";
            sfd.FileName = "data_HouseholdDepartment" + DateTime.Now.ToString("yyyy-MM-dd_HH-mm");

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        using (MySqlBackup mb = new MySqlBackup(cmd))
                        {
                            try
                            {
                                cmd.Connection = conn;
                                conn.Open();

                                mb.ExportToFile(sfd.FileName);

                                conn.Close();
                                MessageBox.Show("Ðåçåðâíàÿ êîïèÿ óñïåøíî ñîçäàíà!", "Óñïåõ");
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Îøèáêà ïðè ñîçäàíèè êîïèè: " + ex.Message);
                            }
                        }
                    }
                }
            }
        }

        private void BtSeal_Click(object sender, EventArgs e)
        {

            if (TbShift.DataSource is DataTable dt)
            {
                DialogResult result = MessageBox.Show(
                    "Ðàñïå÷àòàòü ãðàôèê çà áëèæàéøèå 2 íåäåëè?\n\n(Íàæìèòå 'Íåò', ÷òîáû ðàñïå÷àòàòü âåñü ãðàôèê)",
                    "Âûáîð ïåðèîäà",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Cancel) return;

                string reportTitle = "ÏÎËÍÛÉ ÃÐÀÔÈÊ ÑÌÅÍ";

                if (result == DialogResult.Yes)
                {
                    DateTime today = DateTime.Now.Date;
                    DateTime end = today.AddDays(14);

                    dt.DefaultView.RowFilter = string.Format(System.Globalization.CultureInfo.InvariantCulture,
                        "Date_of_shift >= #{0:MM/dd/yyyy}# AND Date_of_shift <= #{1:MM/dd/yyyy}#", today, end); ;

                    reportTitle = "ÃÐÀÔÈÊ ÑÌÅÍ ÍÀ 2 ÍÅÄÅËÈ";
                }
                else
                {
                    dt.DefaultView.RowFilter = "";
                }

                TbShift.Refresh();
                ExportToExcel(TbShift, reportTitle);

                dt.DefaultView.RowFilter = "";
            }
        }

        private void ExportToExcel(DataGridView dgv, string periodName)
        {
            Excel.Application excelApp = new Excel.Application();
            excelApp.Workbooks.Add();
            Excel._Worksheet sheet = excelApp.ActiveSheet;

            sheet.Cells[1, 1] = periodName;
            sheet.Range["A1", "H1"].Merge();
            sheet.Range["A1"].Font.Size = 14;
            sheet.Range["A1"].Font.Bold = true;
            sheet.Range["A1"].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

            int excelCol = 1;
            for (int j = 0; j < dgv.Columns.Count; j++)
            {
                if (dgv.Columns[j].Visible)
                {
                    sheet.Cells[3, excelCol] = dgv.Columns[j].HeaderText;
                    sheet.Cells[3, excelCol].Font.Bold = true;
                    sheet.Cells[3, excelCol].Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                    excelCol++;
                }
            }

            DataTable dt = (DataTable)dgv.DataSource;
            DataView dv = dt.DefaultView;

            int excelRow = 4;
            for (int i = 0; i < dv.Count; i++)
            {
                excelCol = 1;
                for (int j = 0; j < dgv.Columns.Count; j++)
                {
                    if (dgv.Columns[j].Visible)
                    {
                        string columnName = dgv.Columns[j].DataPropertyName;

                        if (!string.IsNullOrEmpty(columnName))
                        {
                            object val = dv[i][columnName];
                            sheet.Cells[excelRow, excelCol] = val?.ToString() ?? "";
                        }

                        sheet.Cells[excelRow, excelCol].Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                        excelCol++;
                    }
                }
                excelRow++;
            }

            sheet.Columns.AutoFit();
            excelApp.Visible = true;
        }

        private void TextSearchShift_TextChanged(object sender, EventArgs e)
        {
            if (TbShift.DataSource is DataTable dt)
            {
                dt.DefaultView.RowFilter = string.Format("FIO_Shift LIKE '%{0}%'", TextSearchShift.Text);
                dt.DefaultView.RowFilter = string.Format("Body_name LIKE '%{0}%'", TextSearchShift.Text);
                dt.DefaultView.RowFilter = string.Format("Change_name LIKE '%{0}%'", TextSearchShift.Text);
            }
        }

        private void CbFilterShift_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TbShift.DataSource is DataTable dt)
            {
                string selected = CbFilterShift.SelectedItem.ToString();
                DataView dv = dt.DefaultView;

                switch (selected)
                {
                    case "Ñáðîñèòü âñ¸":
                        dv.RowFilter = "";
                        dv.Sort = "";
                        break;

                    case "Îòðàáîòàíà ñìåíà (îò -)":
                        dv.RowFilter = "";
                        dv.Sort = "Fact_Shifts ASC";
                        break;

                    case "Îòðàáîòàíà ñìåíà (îò +)":
                        dv.RowFilter = "";
                        dv.Sort = "Fact_Shifts DESC";
                        break;

                    case "Íîìåð ýòàæà (îò áîëüøåãî)":
                        dv.RowFilter = "";
                        dv.Sort = "Floor_number DESC";
                        break;

                    case "Íîìåð ýòàæà (îò ìåíüøåãî)":
                        dv.RowFilter = "";
                        dv.Sort = "Floor_number ASC";
                        break;

                    default:

                        dv.RowFilter = string.Format("Post = '{0}'", selected);
                        dv.Sort = "";
                        break;
                }
            }
        }

        private void CbFilterSclad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TbSclad.DataSource is DataTable dt)
            {
                string selected = CbFilterSclad.SelectedItem.ToString();
                DataView dv = dt.DefaultView;

                switch (selected)
                {
                    case "Ñáðîñèòü âñ¸":
                        dv.RowFilter = "";
                        dv.Sort = "";
                        break;

                    case "Êàòåãîðèè (À-ß)":
                        dv.RowFilter = "";
                        dv.Sort = "Category_name ASC";
                        break;

                    case "Êàòåãîðèè (ß-À)":
                        dv.RowFilter = "";
                        dv.Sort = "Category_name DESC";
                        break;

                    case "Êîë-âî ïîñòóïëåíèé (îò áîëüøåãî)":
                        dv.RowFilter = "";
                        dv.Sort = "Entrance_Quantity DESC";
                        break;

                    case "Êîë-âî ïîñòóïëåíèé (îò ìåíüøåãî)":
                        dv.RowFilter = "";
                        dv.Sort = "Entrance_Quantity ASC";
                        break;

                    case "Âûäàíî â ðàáîòó (îò áîëüøåãî)":
                        dv.RowFilter = "";
                        dv.Sort = "Payout_Quantity DESC";
                        break;

                    case "Âûäàíî â ðàáîòó (îò ìåíüøåãî)":
                        dv.RowFilter = "";
                        dv.Sort = "Payout_Quantity ASC";
                        break;

                    default:
                        dv.RowFilter = string.Format("Body_name = '{0}'", selected);
                        dv.Sort = "";
                        break;
                }
            }
        }

        private void TextSearchSclad_TextChanged(object sender, EventArgs e)
        {
            if (TbSclad.DataSource is DataTable dt)
            {
                dt.DefaultView.RowFilter = string.Format("FIO LIKE '%{0}%'", TextSearchSclad.Text);
                dt.DefaultView.RowFilter = string.Format("Inventory_Name LIKE '%{0}%'", TextSearchSclad.Text);
            }
        }
    }
}