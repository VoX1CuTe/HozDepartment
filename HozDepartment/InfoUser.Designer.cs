namespace HozDepartment
{
    partial class InfoUser
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            PanelToolbar = new Panel();
            guna2HtmlLabel5 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            TbLogin = new TextBox();
            TbPassword = new TextBox();
            TbUserName = new TextBox();
            LbLogin = new Guna.UI2.WinForms.Guna2HtmlLabel();
            LbPassword = new Guna.UI2.WinForms.Guna2HtmlLabel();
            LbRole = new Guna.UI2.WinForms.Guna2HtmlLabel();
            LbUserName = new Guna.UI2.WinForms.Guna2HtmlLabel();
            btSave = new Guna.UI2.WinForms.Guna2Button();
            BtCancel = new Guna.UI2.WinForms.Guna2Button();
            TbUserData = new Guna.UI2.WinForms.Guna2DataGridView();
            id = new DataGridViewTextBoxColumn();
            Role = new DataGridViewTextBoxColumn();
            Login = new DataGridViewTextBoxColumn();
            Password = new DataGridViewTextBoxColumn();
            FuelName = new DataGridViewTextBoxColumn();
            ContextMenuStrip = new Guna.UI2.WinForms.Guna2ContextMenuStrip();
            StripMenuAdd = new ToolStripMenuItem();
            StripMenuRedact = new ToolStripMenuItem();
            StripMenuDelete = new ToolStripMenuItem();
            CbRole = new ComboBox();
            PanelToolbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)TbUserData).BeginInit();
            ContextMenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // PanelToolbar
            // 
            PanelToolbar.BackColor = Color.FromArgb(253, 253, 150);
            PanelToolbar.Controls.Add(guna2HtmlLabel5);
            PanelToolbar.Dock = DockStyle.Top;
            PanelToolbar.Location = new Point(0, 0);
            PanelToolbar.Name = "PanelToolbar";
            PanelToolbar.Size = new Size(1019, 25);
            PanelToolbar.TabIndex = 1;
            PanelToolbar.MouseDown += PanelToolbar_MouseDown;
            // 
            // guna2HtmlLabel5
            // 
            guna2HtmlLabel5.BackColor = Color.Transparent;
            guna2HtmlLabel5.Location = new Point(55, 5);
            guna2HtmlLabel5.Name = "guna2HtmlLabel5";
            guna2HtmlLabel5.Size = new Size(93, 17);
            guna2HtmlLabel5.TabIndex = 13;
            guna2HtmlLabel5.Text = "HozDepartament";
            // 
            // TbLogin
            // 
            TbLogin.Location = new Point(767, 69);
            TbLogin.Name = "TbLogin";
            TbLogin.Size = new Size(239, 23);
            TbLogin.TabIndex = 2;
            TbLogin.Visible = false;
            // 
            // TbPassword
            // 
            TbPassword.Location = new Point(767, 98);
            TbPassword.Name = "TbPassword";
            TbPassword.Size = new Size(239, 23);
            TbPassword.TabIndex = 3;
            TbPassword.Visible = false;
            // 
            // TbUserName
            // 
            TbUserName.Location = new Point(767, 156);
            TbUserName.Name = "TbUserName";
            TbUserName.Size = new Size(239, 23);
            TbUserName.TabIndex = 5;
            TbUserName.Visible = false;
            // 
            // LbLogin
            // 
            LbLogin.BackColor = Color.Transparent;
            LbLogin.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            LbLogin.Location = new Point(628, 70);
            LbLogin.Name = "LbLogin";
            LbLogin.Size = new Size(46, 22);
            LbLogin.TabIndex = 7;
            LbLogin.Text = "Логин";
            LbLogin.Visible = false;
            // 
            // LbPassword
            // 
            LbPassword.BackColor = Color.Transparent;
            LbPassword.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            LbPassword.Location = new Point(628, 99);
            LbPassword.Name = "LbPassword";
            LbPassword.Size = new Size(56, 22);
            LbPassword.TabIndex = 8;
            LbPassword.Text = "Пароль";
            LbPassword.Visible = false;
            // 
            // LbRole
            // 
            LbRole.BackColor = Color.Transparent;
            LbRole.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            LbRole.Location = new Point(628, 128);
            LbRole.Name = "LbRole";
            LbRole.Size = new Size(36, 22);
            LbRole.TabIndex = 9;
            LbRole.Text = "Роль";
            LbRole.Visible = false;
            // 
            // LbUserName
            // 
            LbUserName.BackColor = Color.Transparent;
            LbUserName.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            LbUserName.Location = new Point(628, 156);
            LbUserName.Name = "LbUserName";
            LbUserName.Size = new Size(133, 22);
            LbUserName.TabIndex = 10;
            LbUserName.Text = "Имя пользователя";
            LbUserName.Visible = false;
            // 
            // btSave
            // 
            btSave.BorderRadius = 10;
            btSave.CustomizableEdges = customizableEdges5;
            btSave.DisabledState.BorderColor = Color.DarkGray;
            btSave.DisabledState.CustomBorderColor = Color.DarkGray;
            btSave.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btSave.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btSave.FillColor = Color.FromArgb(253, 253, 150);
            btSave.Font = new Font("Segoe UI", 9F);
            btSave.ForeColor = Color.Black;
            btSave.Location = new Point(628, 241);
            btSave.Name = "btSave";
            btSave.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btSave.Size = new Size(145, 24);
            btSave.TabIndex = 11;
            btSave.Text = "Сохранить";
            btSave.Visible = false;
            btSave.Click += btSave_Click;
            // 
            // BtCancel
            // 
            BtCancel.BorderRadius = 10;
            BtCancel.CustomizableEdges = customizableEdges7;
            BtCancel.DisabledState.BorderColor = Color.DarkGray;
            BtCancel.DisabledState.CustomBorderColor = Color.DarkGray;
            BtCancel.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            BtCancel.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            BtCancel.FillColor = Color.FromArgb(253, 253, 150);
            BtCancel.Font = new Font("Segoe UI", 9F);
            BtCancel.ForeColor = Color.Black;
            BtCancel.Location = new Point(861, 241);
            BtCancel.Name = "BtCancel";
            BtCancel.ShadowDecoration.CustomizableEdges = customizableEdges8;
            BtCancel.Size = new Size(145, 24);
            BtCancel.TabIndex = 12;
            BtCancel.Text = "Отмена";
            // 
            // TbUserData
            // 
            TbUserData.AllowUserToAddRows = false;
            TbUserData.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.BackColor = Color.White;
            TbUserData.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle5.ForeColor = Color.White;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            TbUserData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            TbUserData.ColumnHeadersHeight = 17;
            TbUserData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            TbUserData.Columns.AddRange(new DataGridViewColumn[] { id, Role, Login, Password, FuelName });
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = Color.White;
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle6.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle6.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle6.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
            TbUserData.DefaultCellStyle = dataGridViewCellStyle6;
            TbUserData.GridColor = Color.FromArgb(231, 229, 255);
            TbUserData.Location = new Point(12, 44);
            TbUserData.Name = "TbUserData";
            TbUserData.ReadOnly = true;
            TbUserData.RowHeadersVisible = false;
            TbUserData.Size = new Size(597, 222);
            TbUserData.TabIndex = 13;
            TbUserData.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            TbUserData.ThemeStyle.AlternatingRowsStyle.Font = null;
            TbUserData.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            TbUserData.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            TbUserData.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            TbUserData.ThemeStyle.BackColor = Color.White;
            TbUserData.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            TbUserData.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            TbUserData.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            TbUserData.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F);
            TbUserData.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            TbUserData.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            TbUserData.ThemeStyle.HeaderStyle.Height = 17;
            TbUserData.ThemeStyle.ReadOnly = true;
            TbUserData.ThemeStyle.RowsStyle.BackColor = Color.White;
            TbUserData.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            TbUserData.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            TbUserData.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            TbUserData.ThemeStyle.RowsStyle.Height = 25;
            TbUserData.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            TbUserData.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            TbUserData.CellMouseDown += TbUserData_CellMouseDown;
            // 
            // id
            // 
            id.DataPropertyName = "id";
            id.HeaderText = "id";
            id.Name = "id";
            id.ReadOnly = true;
            id.Visible = false;
            // 
            // Role
            // 
            Role.DataPropertyName = "Role";
            Role.HeaderText = "Роль";
            Role.Name = "Role";
            Role.ReadOnly = true;
            // 
            // Login
            // 
            Login.DataPropertyName = "Login";
            Login.HeaderText = "Логин";
            Login.Name = "Login";
            Login.ReadOnly = true;
            // 
            // Password
            // 
            Password.DataPropertyName = "Password";
            Password.HeaderText = "Пароль";
            Password.Name = "Password";
            Password.ReadOnly = true;
            // 
            // FuelName
            // 
            FuelName.DataPropertyName = "FuelName";
            FuelName.HeaderText = "Имя пол-ля";
            FuelName.Name = "FuelName";
            FuelName.ReadOnly = true;
            // 
            // ContextMenuStrip
            // 
            ContextMenuStrip.Items.AddRange(new ToolStripItem[] { StripMenuAdd, StripMenuRedact, StripMenuDelete });
            ContextMenuStrip.Name = "ContextMenuStrip";
            ContextMenuStrip.RenderMode = ToolStripRenderMode.Professional;
            ContextMenuStrip.RenderStyle.ArrowColor = Color.FromArgb(151, 143, 255);
            ContextMenuStrip.RenderStyle.BorderColor = Color.Gainsboro;
            ContextMenuStrip.RenderStyle.ColorTable = null;
            ContextMenuStrip.RenderStyle.RoundedEdges = true;
            ContextMenuStrip.RenderStyle.SelectionArrowColor = Color.White;
            ContextMenuStrip.RenderStyle.SelectionBackColor = Color.FromArgb(100, 88, 255);
            ContextMenuStrip.RenderStyle.SelectionForeColor = Color.White;
            ContextMenuStrip.RenderStyle.SeparatorColor = Color.Gainsboro;
            ContextMenuStrip.RenderStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            ContextMenuStrip.Size = new Size(181, 92);
            // 
            // StripMenuAdd
            // 
            StripMenuAdd.Name = "StripMenuAdd";
            StripMenuAdd.Size = new Size(180, 22);
            StripMenuAdd.Text = "Добавить";
            StripMenuAdd.Click += StripMenuAdd_Click;
            // 
            // StripMenuRedact
            // 
            StripMenuRedact.Name = "StripMenuRedact";
            StripMenuRedact.Size = new Size(180, 22);
            StripMenuRedact.Text = "Редактирование";
            StripMenuRedact.Click += StripMenuRedact_Click;
            // 
            // StripMenuDelete
            // 
            StripMenuDelete.Name = "StripMenuDelete";
            StripMenuDelete.Size = new Size(180, 22);
            StripMenuDelete.Text = "Удалить";
            StripMenuDelete.Click += StripMenuDelete_Click;
            // 
            // CbRole
            // 
            CbRole.FormattingEnabled = true;
            CbRole.Items.AddRange(new object[] { "Admin", "Manager", "User" });
            CbRole.Location = new Point(767, 127);
            CbRole.Name = "CbRole";
            CbRole.Size = new Size(239, 23);
            CbRole.TabIndex = 14;
            CbRole.Visible = false;
            // 
            // InfoUser
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightGoldenrodYellow;
            ClientSize = new Size(1019, 277);
            Controls.Add(CbRole);
            Controls.Add(TbUserData);
            Controls.Add(BtCancel);
            Controls.Add(LbLogin);
            Controls.Add(btSave);
            Controls.Add(LbUserName);
            Controls.Add(LbRole);
            Controls.Add(LbPassword);
            Controls.Add(TbUserName);
            Controls.Add(TbPassword);
            Controls.Add(TbLogin);
            Controls.Add(PanelToolbar);
            FormBorderStyle = FormBorderStyle.None;
            Name = "InfoUser";
            Text = "InfoUser";
            Load += InfoUser_Load;
            PanelToolbar.ResumeLayout(false);
            PanelToolbar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)TbUserData).EndInit();
            ContextMenuStrip.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridViewTextBoxColumn id;
        private DataGridViewTextBoxColumn Role;
        private DataGridViewTextBoxColumn Login;
        private DataGridViewTextBoxColumn Password;
        private DataGridViewTextBoxColumn FuelName;
        private ToolStripMenuItem StripMenuAdd;
        private ToolStripMenuItem StripMenuRedact;
        private ToolStripMenuItem StripMenuDelete;
        private TextBox TbLogin;
        private TextBox TbPassword;
        private TextBox TbUserName;
        private Guna.UI2.WinForms.Guna2HtmlLabel LbLogin;
        private Guna.UI2.WinForms.Guna2HtmlLabel LbPassword;
        private Guna.UI2.WinForms.Guna2HtmlLabel LbRole;
        private Guna.UI2.WinForms.Guna2HtmlLabel LbUserName;
        private Guna.UI2.WinForms.Guna2DataGridView TbUserData;
        private Panel PanelToolbar;
        private Guna.UI2.WinForms.Guna2Button btSave;
        private Guna.UI2.WinForms.Guna2Button BtCancel;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel5;
        private Guna.UI2.WinForms.Guna2ContextMenuStrip ContextMenuStrip;
        private ComboBox CbRole;
    }
}