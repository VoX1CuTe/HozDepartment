namespace HozDepartment
{
    partial class Registration
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            label1 = new Label();
            textLogin = new TextBox();
            label2 = new Label();
            label3 = new Label();
            textPassword = new TextBox();
            btEnter = new Guna.UI2.WinForms.Guna2Button();
            PanelToolbar = new Panel();
            UserLb = new Label();
            PanelToolbar.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label1.Location = new Point(25, 5);
            label1.Name = "label1";
            label1.Size = new Size(81, 17);
            label1.TabIndex = 2;
            label1.Text = "Регистрация";
            // 
            // textLogin
            // 
            textLogin.BackColor = SystemColors.ControlDarkDark;
            textLogin.BorderStyle = BorderStyle.FixedSingle;
            textLogin.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textLogin.ForeColor = Color.White;
            textLogin.Location = new Point(70, 155);
            textLogin.Multiline = true;
            textLogin.Name = "textLogin";
            textLogin.Size = new Size(253, 23);
            textLogin.TabIndex = 1;
            textLogin.Text = "123";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label2.Location = new Point(14, 155);
            label2.Name = "label2";
            label2.Size = new Size(52, 20);
            label2.TabIndex = 3;
            label2.Text = "Логин";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label3.Location = new Point(4, 190);
            label3.Name = "label3";
            label3.Size = new Size(62, 20);
            label3.TabIndex = 4;
            label3.Text = "Пароль";
            // 
            // textPassword
            // 
            textPassword.BackColor = SystemColors.ControlDarkDark;
            textPassword.BorderStyle = BorderStyle.FixedSingle;
            textPassword.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textPassword.ForeColor = Color.White;
            textPassword.Location = new Point(70, 190);
            textPassword.Multiline = true;
            textPassword.Name = "textPassword";
            textPassword.Size = new Size(253, 23);
            textPassword.TabIndex = 5;
            textPassword.Text = "123";
            // 
            // btEnter
            // 
            btEnter.BorderRadius = 10;
            btEnter.CustomizableEdges = customizableEdges1;
            btEnter.DisabledState.BorderColor = Color.DarkGray;
            btEnter.DisabledState.CustomBorderColor = Color.DarkGray;
            btEnter.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btEnter.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btEnter.FillColor = Color.FromArgb(253, 253, 150);
            btEnter.Font = new Font("Segoe UI", 9F);
            btEnter.ForeColor = Color.Black;
            btEnter.Location = new Point(106, 221);
            btEnter.Name = "btEnter";
            btEnter.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btEnter.Size = new Size(179, 24);
            btEnter.TabIndex = 6;
            btEnter.Text = "Войти";
            btEnter.Click += btEnter_Click;
            // 
            // PanelToolbar
            // 
            PanelToolbar.BackColor = Color.FromArgb(253, 253, 150);
            PanelToolbar.Controls.Add(label1);
            PanelToolbar.Controls.Add(UserLb);
            PanelToolbar.Dock = DockStyle.Top;
            PanelToolbar.Location = new Point(0, 0);
            PanelToolbar.Name = "PanelToolbar";
            PanelToolbar.Size = new Size(371, 25);
            PanelToolbar.TabIndex = 7;
            // 
            // UserLb
            // 
            UserLb.AutoSize = true;
            UserLb.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            UserLb.Location = new Point(817, 5);
            UserLb.Name = "UserLb";
            UserLb.Size = new Size(93, 17);
            UserLb.TabIndex = 3;
            UserLb.Text = "Пользователь";
            // 
            // Registration
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightGoldenrodYellow;
            ClientSize = new Size(371, 248);
            Controls.Add(PanelToolbar);
            Controls.Add(btEnter);
            Controls.Add(label2);
            Controls.Add(textPassword);
            Controls.Add(label3);
            Controls.Add(textLogin);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Registration";
            Text = "Registration";
            FormClosing += Registration_FormClosing;
            Load += Registration_Load;
            PanelToolbar.ResumeLayout(false);
            PanelToolbar.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private TextBox textLogin;
        private Label label2;
        private Label label3;
        private TextBox textPassword;
        private Guna.UI2.WinForms.Guna2Button btEnter;
        private Panel PanelToolbar;
        private Label UserLb;
    }
}