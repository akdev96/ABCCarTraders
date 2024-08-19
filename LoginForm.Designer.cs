namespace ABCCarTraders
{
    partial class mainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            label1 = new Label();
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            lbl_userName = new Label();
            lbl_password = new Label();
            txb_userName = new TextBox();
            txb_password = new TextBox();
            btn_login = new Button();
            btn_register = new Button();
            pnl_login = new Panel();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            pnl_login.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Inter SemiBold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(91, 268);
            label1.Name = "label1";
            label1.Size = new Size(256, 36);
            label1.TabIndex = 0;
            label1.Text = "ABC Car Traders";
            label1.Click += label1_Click;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.AutoSize = true;
            panel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel1.BackColor = Color.FromArgb(56, 56, 56);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(448, 452);
            panel1.TabIndex = 1;
            panel1.Paint += panel1_Paint;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox1.Location = new Point(155, 100);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(128, 128);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // lbl_userName
            // 
            lbl_userName.AccessibleName = "lbl_userName";
            lbl_userName.AutoSize = true;
            lbl_userName.Location = new Point(96, 86);
            lbl_userName.Name = "lbl_userName";
            lbl_userName.Size = new Size(82, 20);
            lbl_userName.TabIndex = 2;
            lbl_userName.Text = "User Name";
            // 
            // lbl_password
            // 
            lbl_password.AccessibleName = "lbl_password";
            lbl_password.AutoSize = true;
            lbl_password.Location = new Point(93, 150);
            lbl_password.Name = "lbl_password";
            lbl_password.Size = new Size(70, 20);
            lbl_password.TabIndex = 3;
            lbl_password.Text = "Password";
            // 
            // txb_userName
            // 
            txb_userName.AccessibleName = "txb_userName";
            txb_userName.Location = new Point(96, 109);
            txb_userName.Name = "txb_userName";
            txb_userName.Size = new Size(219, 27);
            txb_userName.TabIndex = 4;
            // 
            // txb_password
            // 
            txb_password.AccessibleName = "txb_password";
            txb_password.Location = new Point(96, 173);
            txb_password.Name = "txb_password";
            txb_password.Size = new Size(219, 27);
            txb_password.TabIndex = 4;
            // 
            // btn_login
            // 
            btn_login.AccessibleName = "btn_login";
            btn_login.Location = new Point(97, 214);
            btn_login.Name = "btn_login";
            btn_login.Size = new Size(94, 29);
            btn_login.TabIndex = 5;
            btn_login.Text = "Login";
            btn_login.UseVisualStyleBackColor = true;
            // 
            // btn_register
            // 
            btn_register.AccessibleName = "btn_register";
            btn_register.Location = new Point(740, 12);
            btn_register.Name = "btn_register";
            btn_register.Size = new Size(94, 29);
            btn_register.TabIndex = 5;
            btn_register.Text = "Register";
            btn_register.UseVisualStyleBackColor = true;
            // 
            // pnl_login
            // 
            pnl_login.AccessibleName = "pnl_login";
            pnl_login.Controls.Add(lbl_userName);
            pnl_login.Controls.Add(lbl_password);
            pnl_login.Controls.Add(btn_login);
            pnl_login.Controls.Add(txb_userName);
            pnl_login.Controls.Add(txb_password);
            pnl_login.Location = new Point(454, 64);
            pnl_login.Name = "pnl_login";
            pnl_login.Size = new Size(380, 375);
            pnl_login.TabIndex = 6;
            // 
            // mainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(846, 451);
            Controls.Add(pnl_login);
            Controls.Add(btn_register);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "mainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login - ABC Car Traders";
            Load += mainForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            pnl_login.ResumeLayout(false);
            pnl_login.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Panel panel1;
        private PictureBox pictureBox1;
        private Label lbl_userName;
        private Label lbl_password;
        private TextBox txb_userName;
        private TextBox txb_password;
        private Button btn_login;
        private Button btn_register;
        private Panel pnl_login;
    }
}
