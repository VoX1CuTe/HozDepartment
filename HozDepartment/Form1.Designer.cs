namespace HozDepartment
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            PanelToolbar = new Panel();
            LogoName = new Guna.UI2.WinForms.Guna2HtmlLabel();
            UserLb = new Guna.UI2.WinForms.Guna2HtmlLabel();
            PanelButton = new Panel();
            BtRedactUser = new Guna.UI2.WinForms.Guna2Button();
            guna2Button5 = new Guna.UI2.WinForms.Guna2Button();
            BtShift = new Guna.UI2.WinForms.Guna2Button();
            Sclad = new Guna.UI2.WinForms.Guna2Button();
            TbSclad = new Guna.UI2.WinForms.Guna2DataGridView();
            Id_Inventory = new DataGridViewTextBoxColumn();
            Id_Category = new DataGridViewTextBoxColumn();
            Id_Entrance = new DataGridViewTextBoxColumn();
            Id_Issue = new DataGridViewTextBoxColumn();
            Id_Employee = new DataGridViewTextBoxColumn();
            Inventory_Name = new DataGridViewTextBoxColumn();
            Category_name = new DataGridViewTextBoxColumn();
            Unit_Measurements = new DataGridViewTextBoxColumn();
            Entrance_Quantity = new DataGridViewTextBoxColumn();
            Access_Date = new DataGridViewTextBoxColumn();
            Payout_Quantity = new DataGridViewTextBoxColumn();
            Release_date = new DataGridViewTextBoxColumn();
            Return_date = new DataGridViewTextBoxColumn();
            FIO = new DataGridViewTextBoxColumn();
            ContextMenuSclad = new Guna.UI2.WinForms.Guna2ContextMenuStrip();
            StripMenuAddSclad = new ToolStripMenuItem();
            StripMenuRedactSclad = new ToolStripMenuItem();
            TbShift = new Guna.UI2.WinForms.Guna2DataGridView();
            ContextMenuShift = new Guna.UI2.WinForms.Guna2ContextMenuStrip();
            StripMenuAdd = new ToolStripMenuItem();
            StripMenuRedact = new ToolStripMenuItem();
            StripMenuDelete = new ToolStripMenuItem();
            Id_Grahy = new DataGridViewTextBoxColumn();
            Id_Tvm_Smena = new DataGridViewTextBoxColumn();
            FIO_Shift = new DataGridViewTextBoxColumn();
            Date_of_shift = new DataGridViewTextBoxColumn();
            Change_name = new DataGridViewTextBoxColumn();
            TimeWork = new DataGridViewTextBoxColumn();
            Schedule_assignment_date = new DataGridViewTextBoxColumn();
            Body_name = new DataGridViewTextBoxColumn();
            Floor_number = new DataGridViewTextBoxColumn();
            Cause_change = new DataGridViewTextBoxColumn();
            PanelToolbar.SuspendLayout();
            PanelButton.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)TbSclad).BeginInit();
            ContextMenuSclad.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)TbShift).BeginInit();
            ContextMenuShift.SuspendLayout();
            SuspendLayout();
            // 
            // PanelToolbar
            // 
            PanelToolbar.BackColor = Color.FromArgb(253, 253, 150);
            PanelToolbar.Controls.Add(LogoName);
            PanelToolbar.Controls.Add(UserLb);
            PanelToolbar.Dock = DockStyle.Top;
            PanelToolbar.Location = new Point(0, 0);
            PanelToolbar.Name = "PanelToolbar";
            PanelToolbar.Size = new Size(1304, 25);
            PanelToolbar.TabIndex = 0;
            PanelToolbar.MouseDown += PanelToolbar_MouseDown;
            // 
            // LogoName
            // 
            LogoName.BackColor = Color.Transparent;
            LogoName.Location = new Point(55, 5);
            LogoName.Name = "LogoName";
            LogoName.Size = new Size(93, 17);
            LogoName.TabIndex = 10;
            LogoName.Text = "HozDepartament";
            // 
            // UserLb
            // 
            UserLb.BackColor = Color.Transparent;
            UserLb.Location = new Point(1212, 5);
            UserLb.Name = "UserLb";
            UserLb.Size = new Size(80, 17);
            UserLb.TabIndex = 8;
            UserLb.Text = "Пользователь";
            // 
            // PanelButton
            // 
            PanelButton.BackColor = Color.LightGoldenrodYellow;
            PanelButton.Controls.Add(BtRedactUser);
            PanelButton.Controls.Add(guna2Button5);
            PanelButton.Controls.Add(BtShift);
            PanelButton.Controls.Add(Sclad);
            PanelButton.Dock = DockStyle.Top;
            PanelButton.Location = new Point(0, 25);
            PanelButton.Name = "PanelButton";
            PanelButton.Size = new Size(1304, 73);
            PanelButton.TabIndex = 1;
            // 
            // BtRedactUser
            // 
            BtRedactUser.BorderRadius = 15;
            BtRedactUser.CustomizableEdges = customizableEdges1;
            BtRedactUser.DisabledState.BorderColor = Color.DarkGray;
            BtRedactUser.DisabledState.CustomBorderColor = Color.DarkGray;
            BtRedactUser.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            BtRedactUser.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            BtRedactUser.FillColor = Color.FromArgb(253, 253, 130);
            BtRedactUser.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            BtRedactUser.ForeColor = Color.Black;
            BtRedactUser.ImageSize = new Size(35, 35);
            BtRedactUser.Location = new Point(977, 6);
            BtRedactUser.Name = "BtRedactUser";
            BtRedactUser.ShadowDecoration.CustomizableEdges = customizableEdges2;
            BtRedactUser.Size = new Size(315, 59);
            BtRedactUser.TabIndex = 8;
            BtRedactUser.Text = "О пользователя";
            BtRedactUser.Click += BtRedactUser_Click;
            // 
            // guna2Button5
            // 
            guna2Button5.BorderRadius = 15;
            guna2Button5.CustomizableEdges = customizableEdges3;
            guna2Button5.DisabledState.BorderColor = Color.DarkGray;
            guna2Button5.DisabledState.CustomBorderColor = Color.DarkGray;
            guna2Button5.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            guna2Button5.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            guna2Button5.FillColor = Color.FromArgb(253, 253, 130);
            guna2Button5.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            guna2Button5.ForeColor = Color.Black;
            guna2Button5.ImageSize = new Size(35, 35);
            guna2Button5.Location = new Point(12, 6);
            guna2Button5.Name = "guna2Button5";
            guna2Button5.ShadowDecoration.CustomizableEdges = customizableEdges4;
            guna2Button5.Size = new Size(315, 59);
            guna2Button5.TabIndex = 7;
            guna2Button5.Text = "Работники";
            // 
            // BtShift
            // 
            BtShift.BorderRadius = 15;
            BtShift.CustomizableEdges = customizableEdges5;
            BtShift.DisabledState.BorderColor = Color.DarkGray;
            BtShift.DisabledState.CustomBorderColor = Color.DarkGray;
            BtShift.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            BtShift.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            BtShift.FillColor = Color.FromArgb(253, 253, 130);
            BtShift.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            BtShift.ForeColor = Color.Black;
            BtShift.ImageSize = new Size(40, 40);
            BtShift.Location = new Point(333, 6);
            BtShift.Name = "BtShift";
            BtShift.ShadowDecoration.CustomizableEdges = customizableEdges6;
            BtShift.Size = new Size(315, 59);
            BtShift.TabIndex = 6;
            BtShift.Text = "Смены";
            BtShift.Click += BtShift_Click;
            // 
            // Sclad
            // 
            Sclad.BorderRadius = 15;
            Sclad.CustomizableEdges = customizableEdges7;
            Sclad.DisabledState.BorderColor = Color.DarkGray;
            Sclad.DisabledState.CustomBorderColor = Color.DarkGray;
            Sclad.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            Sclad.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            Sclad.FillColor = Color.FromArgb(253, 253, 130);
            Sclad.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Sclad.ForeColor = Color.Black;
            Sclad.ImageSize = new Size(35, 35);
            Sclad.Location = new Point(654, 6);
            Sclad.Name = "Sclad";
            Sclad.ShadowDecoration.CustomizableEdges = customizableEdges8;
            Sclad.Size = new Size(315, 59);
            Sclad.TabIndex = 4;
            Sclad.Text = "Склад";
            Sclad.Click += Sclad_Click;
            // 
            // TbSclad
            // 
            TbSclad.AllowUserToAddRows = false;
            TbSclad.AllowUserToDeleteRows = false;
            TbSclad.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(230, 230, 230);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(220, 240, 200);
            dataGridViewCellStyle1.SelectionForeColor = Color.Black;
            TbSclad.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            TbSclad.BackgroundColor = Color.LightGoldenrodYellow;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.Silver;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = Color.Silver;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            TbSclad.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            TbSclad.ColumnHeadersHeight = 20;
            TbSclad.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            TbSclad.Columns.AddRange(new DataGridViewColumn[] { Id_Inventory, Id_Category, Id_Entrance, Id_Issue, Id_Employee, Inventory_Name, Category_name, Unit_Measurements, Entrance_Quantity, Access_Date, Payout_Quantity, Release_date, Return_date, FIO });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(230, 230, 230);
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(220, 240, 200);
            dataGridViewCellStyle3.SelectionForeColor = Color.Black;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            TbSclad.DefaultCellStyle = dataGridViewCellStyle3;
            TbSclad.GridColor = Color.FromArgb(231, 229, 255);
            TbSclad.Location = new Point(0, 133);
            TbSclad.Name = "TbSclad";
            TbSclad.ReadOnly = true;
            TbSclad.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(230, 230, 230);
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(230, 230, 230);
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            TbSclad.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            TbSclad.RowHeadersVisible = false;
            TbSclad.RowTemplate.Height = 30;
            TbSclad.Size = new Size(1304, 314);
            TbSclad.TabIndex = 4;
            TbSclad.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            TbSclad.ThemeStyle.AlternatingRowsStyle.Font = null;
            TbSclad.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            TbSclad.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            TbSclad.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            TbSclad.ThemeStyle.BackColor = Color.LightGoldenrodYellow;
            TbSclad.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            TbSclad.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            TbSclad.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            TbSclad.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F);
            TbSclad.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            TbSclad.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            TbSclad.ThemeStyle.HeaderStyle.Height = 20;
            TbSclad.ThemeStyle.ReadOnly = true;
            TbSclad.ThemeStyle.RowsStyle.BackColor = Color.White;
            TbSclad.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            TbSclad.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            TbSclad.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            TbSclad.ThemeStyle.RowsStyle.Height = 30;
            TbSclad.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            TbSclad.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            TbSclad.Visible = false;
            TbSclad.CellMouseClick += TbSclad_CellMouseClick;
            // 
            // Id_Inventory
            // 
            Id_Inventory.DataPropertyName = "Id_Inventory";
            Id_Inventory.HeaderText = "Id_Inventory";
            Id_Inventory.Name = "Id_Inventory";
            Id_Inventory.ReadOnly = true;
            Id_Inventory.Visible = false;
            // 
            // Id_Category
            // 
            Id_Category.DataPropertyName = "Id_Category";
            Id_Category.HeaderText = "Id_Category";
            Id_Category.Name = "Id_Category";
            Id_Category.ReadOnly = true;
            Id_Category.Visible = false;
            // 
            // Id_Entrance
            // 
            Id_Entrance.DataPropertyName = "Id_Entrance";
            Id_Entrance.HeaderText = "Id_Entrance";
            Id_Entrance.Name = "Id_Entrance";
            Id_Entrance.ReadOnly = true;
            Id_Entrance.Visible = false;
            // 
            // Id_Issue
            // 
            Id_Issue.DataPropertyName = "Id_Issue";
            Id_Issue.HeaderText = "Id_Issue";
            Id_Issue.Name = "Id_Issue";
            Id_Issue.ReadOnly = true;
            Id_Issue.Visible = false;
            // 
            // Id_Employee
            // 
            Id_Employee.DataPropertyName = "Id_Employee";
            Id_Employee.HeaderText = "Id_Employee";
            Id_Employee.Name = "Id_Employee";
            Id_Employee.ReadOnly = true;
            Id_Employee.Visible = false;
            // 
            // Inventory_Name
            // 
            Inventory_Name.DataPropertyName = "Inventory_Name";
            Inventory_Name.HeaderText = "Наименование инвентаря";
            Inventory_Name.Name = "Inventory_Name";
            Inventory_Name.ReadOnly = true;
            // 
            // Category_name
            // 
            Category_name.DataPropertyName = "Category_name";
            Category_name.HeaderText = "Категория";
            Category_name.Name = "Category_name";
            Category_name.ReadOnly = true;
            // 
            // Unit_Measurements
            // 
            Unit_Measurements.DataPropertyName = "Unit_Measurements";
            Unit_Measurements.HeaderText = "Ед. измерения";
            Unit_Measurements.Name = "Unit_Measurements";
            Unit_Measurements.ReadOnly = true;
            // 
            // Entrance_Quantity
            // 
            Entrance_Quantity.DataPropertyName = "Entrance_Quantity";
            Entrance_Quantity.HeaderText = "Кол-во поступления";
            Entrance_Quantity.Name = "Entrance_Quantity";
            Entrance_Quantity.ReadOnly = true;
            // 
            // Access_Date
            // 
            Access_Date.DataPropertyName = "Access_Date";
            Access_Date.HeaderText = "Дата поступления";
            Access_Date.Name = "Access_Date";
            Access_Date.ReadOnly = true;
            // 
            // Payout_Quantity
            // 
            Payout_Quantity.DataPropertyName = "Payout_Quantity";
            Payout_Quantity.HeaderText = "Выдано в работу";
            Payout_Quantity.Name = "Payout_Quantity";
            Payout_Quantity.ReadOnly = true;
            // 
            // Release_date
            // 
            Release_date.DataPropertyName = "Release_date";
            Release_date.HeaderText = "Дата выдачи";
            Release_date.Name = "Release_date";
            Release_date.ReadOnly = true;
            // 
            // Return_date
            // 
            Return_date.DataPropertyName = "Return_date";
            Return_date.HeaderText = "Дата возврата";
            Return_date.Name = "Return_date";
            Return_date.ReadOnly = true;
            // 
            // FIO
            // 
            FIO.DataPropertyName = "FIO";
            FIO.HeaderText = "Ф.И.О";
            FIO.Name = "FIO";
            FIO.ReadOnly = true;
            // 
            // ContextMenuSclad
            // 
            ContextMenuSclad.Items.AddRange(new ToolStripItem[] { StripMenuAddSclad, StripMenuRedactSclad });
            ContextMenuSclad.Name = "ContextMenuSclad";
            ContextMenuSclad.RenderStyle.ArrowColor = Color.FromArgb(151, 143, 255);
            ContextMenuSclad.RenderStyle.BorderColor = Color.Gainsboro;
            ContextMenuSclad.RenderStyle.ColorTable = null;
            ContextMenuSclad.RenderStyle.RoundedEdges = true;
            ContextMenuSclad.RenderStyle.SelectionArrowColor = Color.White;
            ContextMenuSclad.RenderStyle.SelectionBackColor = Color.FromArgb(100, 88, 255);
            ContextMenuSclad.RenderStyle.SelectionForeColor = Color.White;
            ContextMenuSclad.RenderStyle.SeparatorColor = Color.Gainsboro;
            ContextMenuSclad.RenderStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            ContextMenuSclad.Size = new Size(155, 48);
            // 
            // StripMenuAddSclad
            // 
            StripMenuAddSclad.Name = "StripMenuAddSclad";
            StripMenuAddSclad.Size = new Size(154, 22);
            StripMenuAddSclad.Text = "Добавить";
            StripMenuAddSclad.Click += StripMenuAddSclad_Click;
            // 
            // StripMenuRedactSclad
            // 
            StripMenuRedactSclad.Name = "StripMenuRedactSclad";
            StripMenuRedactSclad.Size = new Size(154, 22);
            StripMenuRedactSclad.Text = "Редактировать";
            StripMenuRedactSclad.Click += StripMenuRedactSclad_Click;
            // 
            // TbShift
            // 
            TbShift.AllowUserToAddRows = false;
            TbShift.AllowUserToDeleteRows = false;
            TbShift.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.BackColor = Color.FromArgb(230, 230, 230);
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle5.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = Color.FromArgb(220, 240, 200);
            dataGridViewCellStyle5.SelectionForeColor = Color.Black;
            TbShift.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            TbShift.BackgroundColor = Color.LightGoldenrodYellow;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = Color.Silver;
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle6.ForeColor = Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = Color.Silver;
            dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
            TbShift.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            TbShift.ColumnHeadersHeight = 20;
            TbShift.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            TbShift.Columns.AddRange(new DataGridViewColumn[] { Id_Grahy, Id_Tvm_Smena, FIO_Shift, Date_of_shift, Change_name, TimeWork, Schedule_assignment_date, Body_name, Floor_number, Cause_change });
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = Color.FromArgb(230, 230, 230);
            dataGridViewCellStyle7.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle7.ForeColor = Color.Black;
            dataGridViewCellStyle7.SelectionBackColor = Color.FromArgb(220, 240, 200);
            dataGridViewCellStyle7.SelectionForeColor = Color.Black;
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.False;
            TbShift.DefaultCellStyle = dataGridViewCellStyle7;
            TbShift.GridColor = Color.FromArgb(231, 229, 255);
            TbShift.Location = new Point(0, 133);
            TbShift.Name = "TbShift";
            TbShift.ReadOnly = true;
            TbShift.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = Color.FromArgb(230, 230, 230);
            dataGridViewCellStyle8.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle8.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = Color.FromArgb(230, 230, 230);
            dataGridViewCellStyle8.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = DataGridViewTriState.True;
            TbShift.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            TbShift.RowHeadersVisible = false;
            TbShift.RowTemplate.Height = 30;
            TbShift.Size = new Size(1304, 314);
            TbShift.TabIndex = 5;
            TbShift.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            TbShift.ThemeStyle.AlternatingRowsStyle.Font = null;
            TbShift.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            TbShift.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            TbShift.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            TbShift.ThemeStyle.BackColor = Color.LightGoldenrodYellow;
            TbShift.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            TbShift.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            TbShift.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            TbShift.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F);
            TbShift.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            TbShift.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            TbShift.ThemeStyle.HeaderStyle.Height = 20;
            TbShift.ThemeStyle.ReadOnly = true;
            TbShift.ThemeStyle.RowsStyle.BackColor = Color.White;
            TbShift.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            TbShift.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            TbShift.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            TbShift.ThemeStyle.RowsStyle.Height = 30;
            TbShift.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            TbShift.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            TbShift.Visible = false;
            TbShift.CellMouseDown += TbShift_CellMouseDown;
            // 
            // ContextMenuShift
            // 
            ContextMenuShift.Items.AddRange(new ToolStripItem[] { StripMenuAdd, StripMenuRedact, StripMenuDelete });
            ContextMenuShift.Name = "ContextMenuShift";
            ContextMenuShift.RenderStyle.ArrowColor = Color.FromArgb(151, 143, 255);
            ContextMenuShift.RenderStyle.BorderColor = Color.Gainsboro;
            ContextMenuShift.RenderStyle.ColorTable = null;
            ContextMenuShift.RenderStyle.RoundedEdges = true;
            ContextMenuShift.RenderStyle.SelectionArrowColor = Color.White;
            ContextMenuShift.RenderStyle.SelectionBackColor = Color.FromArgb(100, 88, 255);
            ContextMenuShift.RenderStyle.SelectionForeColor = Color.White;
            ContextMenuShift.RenderStyle.SeparatorColor = Color.Gainsboro;
            ContextMenuShift.RenderStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            ContextMenuShift.Size = new Size(164, 70);
            // 
            // StripMenuAdd
            // 
            StripMenuAdd.Name = "StripMenuAdd";
            StripMenuAdd.Size = new Size(163, 22);
            StripMenuAdd.Text = "Добавление";
            StripMenuAdd.Click += StripMenuAdd_Click;
            // 
            // StripMenuRedact
            // 
            StripMenuRedact.Name = "StripMenuRedact";
            StripMenuRedact.Size = new Size(163, 22);
            StripMenuRedact.Text = "Редактирование";
            // 
            // StripMenuDelete
            // 
            StripMenuDelete.Name = "StripMenuDelete";
            StripMenuDelete.Size = new Size(163, 22);
            StripMenuDelete.Text = "Удалить";
            // 
            // Id_Grahy
            // 
            Id_Grahy.DataPropertyName = "Id_Grahy";
            Id_Grahy.HeaderText = "Id_Grahy";
            Id_Grahy.Name = "Id_Grahy";
            Id_Grahy.ReadOnly = true;
            Id_Grahy.Visible = false;
            // 
            // Id_Tvm_Smena
            // 
            Id_Tvm_Smena.DataPropertyName = "Id_Tvm_Smena";
            Id_Tvm_Smena.HeaderText = "Id_Tvm_Smena";
            Id_Tvm_Smena.Name = "Id_Tvm_Smena";
            Id_Tvm_Smena.ReadOnly = true;
            Id_Tvm_Smena.Visible = false;
            // 
            // FIO_Shift
            // 
            FIO_Shift.DataPropertyName = "FIO_Shift";
            FIO_Shift.HeaderText = "Ф.И.О";
            FIO_Shift.Name = "FIO_Shift";
            FIO_Shift.ReadOnly = true;
            // 
            // Date_of_shift
            // 
            Date_of_shift.DataPropertyName = "Date_of_shift";
            Date_of_shift.HeaderText = "Дата назначения смены";
            Date_of_shift.Name = "Date_of_shift";
            Date_of_shift.ReadOnly = true;
            // 
            // Change_name
            // 
            Change_name.DataPropertyName = "Change_name";
            Change_name.HeaderText = "Тип смены";
            Change_name.Name = "Change_name";
            Change_name.ReadOnly = true;
            // 
            // TimeWork
            // 
            TimeWork.DataPropertyName = "TimeWork";
            TimeWork.HeaderText = "Время работ";
            TimeWork.Name = "TimeWork";
            TimeWork.ReadOnly = true;
            // 
            // Schedule_assignment_date
            // 
            Schedule_assignment_date.DataPropertyName = "Schedule_assignment_date";
            Schedule_assignment_date.HeaderText = "Дата назначения графика";
            Schedule_assignment_date.Name = "Schedule_assignment_date";
            Schedule_assignment_date.ReadOnly = true;
            // 
            // Body_name
            // 
            Body_name.DataPropertyName = "Body_name";
            Body_name.HeaderText = "Корпус";
            Body_name.Name = "Body_name";
            Body_name.ReadOnly = true;
            // 
            // Floor_number
            // 
            Floor_number.DataPropertyName = "Floor_number";
            Floor_number.HeaderText = "Номер этажа";
            Floor_number.Name = "Floor_number";
            Floor_number.ReadOnly = true;
            // 
            // Cause_change
            // 
            Cause_change.DataPropertyName = "Cause_change";
            Cause_change.HeaderText = "Причина изменений";
            Cause_change.Name = "Cause_change";
            Cause_change.ReadOnly = true;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(220, 240, 200);
            ClientSize = new Size(1304, 445);
            Controls.Add(TbShift);
            Controls.Add(TbSclad);
            Controls.Add(PanelButton);
            Controls.Add(PanelToolbar);
            FormBorderStyle = FormBorderStyle.None;
            Name = "MainForm";
            Text = "Главное окно";
            Load += MainForm_Load;
            PanelToolbar.ResumeLayout(false);
            PanelToolbar.PerformLayout();
            PanelButton.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)TbSclad).EndInit();
            ContextMenuSclad.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)TbShift).EndInit();
            ContextMenuShift.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel PanelToolbar;
        private Panel PanelButton;
        private Guna.UI2.WinForms.Guna2Button BtShift;
        private Guna.UI2.WinForms.Guna2Button Sclad;
        private Guna.UI2.WinForms.Guna2Button guna2Button5;
        private Guna.UI2.WinForms.Guna2Button BtRedactUser;
        private Guna.UI2.WinForms.Guna2HtmlLabel LogoName;
        private Guna.UI2.WinForms.Guna2HtmlLabel UserLb;
        private Guna.UI2.WinForms.Guna2DataGridView TbSclad;
        private Guna.UI2.WinForms.Guna2ContextMenuStrip ContextMenuSclad;
        private ToolStripMenuItem StripMenuAddSclad;
        private ToolStripMenuItem StripMenuRedactSclad;
        private DataGridViewTextBoxColumn Id_Inventory;
        private DataGridViewTextBoxColumn Id_Category;
        private DataGridViewTextBoxColumn Id_Entrance;
        private DataGridViewTextBoxColumn Id_Issue;
        private DataGridViewTextBoxColumn Id_Employee;
        private DataGridViewTextBoxColumn Inventory_Name;
        private DataGridViewTextBoxColumn Category_name;
        private DataGridViewTextBoxColumn Unit_Measurements;
        private DataGridViewTextBoxColumn Entrance_Quantity;
        private DataGridViewTextBoxColumn Access_Date;
        private DataGridViewTextBoxColumn Payout_Quantity;
        private DataGridViewTextBoxColumn Release_date;
        private DataGridViewTextBoxColumn Return_date;
        private DataGridViewTextBoxColumn FIO;
        private Guna.UI2.WinForms.Guna2DataGridView TbShift;
        private Guna.UI2.WinForms.Guna2ContextMenuStrip ContextMenuShift;
        private ToolStripMenuItem StripMenuAdd;
        private ToolStripMenuItem StripMenuRedact;
        private ToolStripMenuItem StripMenuDelete;
        private DataGridViewTextBoxColumn Id_Grahy;
        private DataGridViewTextBoxColumn Id_Tvm_Smena;
        private DataGridViewTextBoxColumn FIO_Shift;
        private DataGridViewTextBoxColumn Date_of_shift;
        private DataGridViewTextBoxColumn Change_name;
        private DataGridViewTextBoxColumn TimeWork;
        private DataGridViewTextBoxColumn Schedule_assignment_date;
        private DataGridViewTextBoxColumn Body_name;
        private DataGridViewTextBoxColumn Floor_number;
        private DataGridViewTextBoxColumn Cause_change;
    }
}
