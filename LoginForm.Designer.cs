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
            txb_password = new TextBox();
            txb_userName = new TextBox();
            btn_login = new Button();
            lbl_password = new Label();
            lbl_userName = new Label();
            comboBox1 = new ComboBox();
            btn_register = new Button();
            label2 = new Label();
            label3 = new Label();
            pnl_login = new Panel();
            label4 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            pnl_login.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(91, 268);
            label1.Name = "label1";
            label1.Size = new Size(257, 36);
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
            // txb_password
            // 
            txb_password.AccessibleName = "txb_password";
            txb_password.Location = new Point(96, 232);
            txb_password.Name = "txb_password";
            txb_password.Size = new Size(219, 27);
            txb_password.TabIndex = 4;
            // 
            // txb_userName
            // 
            txb_userName.AccessibleName = "txb_userName";
            txb_userName.Location = new Point(96, 166);
            txb_userName.Name = "txb_userName";
            txb_userName.Size = new Size(219, 27);
            txb_userName.TabIndex = 4;
            txb_userName.TextChanged += txb_userName_TextChanged;
            // 
            // btn_login
            // 
            btn_login.AccessibleName = "btn_login";
            btn_login.Location = new Point(97, 275);
            btn_login.Name = "btn_login";
            btn_login.Size = new Size(218, 29);
            btn_login.TabIndex = 5;
            btn_login.Text = "Login";
            btn_login.UseVisualStyleBackColor = true;
            btn_login.Click += btn_login_Click;
            // 
            // lbl_password
            // 
            lbl_password.AccessibleName = "lbl_password";
            lbl_password.AutoSize = true;
            lbl_password.Location = new Point(93, 209);
            lbl_password.Name = "lbl_password";
            lbl_password.Size = new Size(70, 20);
            lbl_password.TabIndex = 3;
            lbl_password.Text = "Password";
            // 
            // lbl_userName
            // 
            lbl_userName.AccessibleName = "lbl_userName";
            lbl_userName.AutoSize = true;
            lbl_userName.Location = new Point(96, 143);
            lbl_userName.Name = "lbl_userName";
            lbl_userName.Size = new Size(82, 20);
            lbl_userName.TabIndex = 2;
            lbl_userName.Text = "User Name";
            // 
            // comboBox1
            // 
            comboBox1.FlatStyle = FlatStyle.System;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Customer", "Admin" });
            comboBox1.Location = new Point(155, 100);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(160, 28);
            comboBox1.TabIndex = 6;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // btn_register
            // 
            btn_register.AccessibleName = "btn_register";
            btn_register.Location = new Point(292, 410);
            btn_register.Name = "btn_register";
            btn_register.Size = new Size(94, 29);
            btn_register.TabIndex = 5;
            btn_register.Text = "Register";
            btn_register.UseVisualStyleBackColor = true;
            btn_register.Click += btn_register_Click;
            // 
            // label2
            // 
            label2.AccessibleName = "lbl_userName";
            label2.AutoSize = true;
            label2.Location = new Point(97, 103);
            label2.Name = "label2";
            label2.Size = new Size(39, 20);
            label2.TabIndex = 7;
            label2.Text = "Role";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AccessibleName = "lbl_userName";
            label3.AutoSize = true;
            label3.Location = new Point(123, 414);
            label3.Name = "label3";
            label3.Size = new Size(163, 20);
            label3.TabIndex = 8;
            label3.Text = "Don't have an account?";
            label3.Click += label3_Click;
            // 
            // pnl_login
            // 
            pnl_login.AccessibleName = "pnl_login";
            pnl_login.Controls.Add(label4);
            pnl_login.Controls.Add(label3);
            pnl_login.Controls.Add(label2);
            pnl_login.Controls.Add(btn_register);
            pnl_login.Controls.Add(comboBox1);
            pnl_login.Controls.Add(lbl_userName);
            pnl_login.Controls.Add(lbl_password);
            pnl_login.Controls.Add(btn_login);
            pnl_login.Controls.Add(txb_userName);
            pnl_login.Controls.Add(txb_password);
            pnl_login.Location = new Point(448, 0);
            pnl_login.Name = "pnl_login";
            pnl_login.Size = new Size(399, 452);
            pnl_login.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label4.Location = new Point(155, 20);
            label4.Name = "label4";
            label4.Size = new Size(89, 37);
            label4.TabIndex = 9;
            label4.Text = "Login";
            label4.Click += label4_Click;
            // 
            // mainForm
            // 
            AccessibleName = "LoginForm";
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(846, 451);
            ControlBox = false;
            Controls.Add(pnl_login);
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
        private TextBox txb_password;
        private TextBox txb_userName;
        private Button btn_login;
        private Label lbl_password;
        private Label lbl_userName;
        private ComboBox comboBox1;
        private Button btn_register;
        private Label label2;
        private Label label3;
        private Panel pnl_login;
        private Label label4;
    }
}
