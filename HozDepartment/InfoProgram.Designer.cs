namespace HozDepartment
{
    partial class InfoProgram
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InfoProgram));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            PanelToolbar = new Panel();
            PbClose = new Guna.UI2.WinForms.Guna2PictureBox();
            LogoName = new Guna.UI2.WinForms.Guna2HtmlLabel();
            label1 = new Label();
            PanelToolbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PbClose).BeginInit();
            SuspendLayout();
            // 
            // PanelToolbar
            // 
            PanelToolbar.BackColor = Color.FromArgb(253, 253, 150);
            PanelToolbar.Controls.Add(PbClose);
            PanelToolbar.Controls.Add(LogoName);
            PanelToolbar.Dock = DockStyle.Top;
            PanelToolbar.Location = new Point(0, 0);
            PanelToolbar.Name = "PanelToolbar";
            PanelToolbar.Size = new Size(700, 25);
            PanelToolbar.TabIndex = 1;
            PanelToolbar.MouseDown += PanelToolbar_MouseDown;
            // 
            // PbClose
            // 
            PbClose.CustomizableEdges = customizableEdges1;
            PbClose.Image = (Image)resources.GetObject("PbClose.Image");
            PbClose.ImageRotate = 0F;
            PbClose.Location = new Point(668, 1);
            PbClose.Name = "PbClose";
            PbClose.ShadowDecoration.CustomizableEdges = customizableEdges2;
            PbClose.Size = new Size(29, 21);
            PbClose.SizeMode = PictureBoxSizeMode.Zoom;
            PbClose.TabIndex = 93;
            PbClose.TabStop = false;
            PbClose.Click += PbClose_Click;
            // 
            // LogoName
            // 
            LogoName.BackColor = Color.Transparent;
            LogoName.Location = new Point(3, 5);
            LogoName.Name = "LogoName";
            LogoName.Size = new Size(115, 17);
            LogoName.TabIndex = 10;
            LogoName.Text = "Информация об ПО";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label1.Location = new Point(3, 28);
            label1.Name = "label1";
            label1.Size = new Size(697, 140);
            label1.TabIndex = 2;
            label1.Text = resources.GetString("label1.Text");
            // 
            // InfoProgram
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(220, 240, 200);
            ClientSize = new Size(700, 171);
            Controls.Add(label1);
            Controls.Add(PanelToolbar);
            FormBorderStyle = FormBorderStyle.None;
            Name = "InfoProgram";
            Text = "InfoProgram";
            PanelToolbar.ResumeLayout(false);
            PanelToolbar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)PbClose).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel PanelToolbar;
        private Guna.UI2.WinForms.Guna2PictureBox PbClose;
        private Guna.UI2.WinForms.Guna2HtmlLabel LogoName;
        private Label label1;
    }
}