namespace ABCCarTraders
{
    partial class RegisterForm
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
            iptFirstName = new TextBox();
            label1 = new Label();
            label2 = new Label();
            iptLastName = new TextBox();
            label3 = new Label();
            iptEmail = new TextBox();
            label4 = new Label();
            iptPassword = new TextBox();
            label5 = new Label();
            iptUsername = new TextBox();
            label6 = new Label();
            iptRePassword = new TextBox();
            label7 = new Label();
            button1 = new Button();
            chkShowPass = new CheckBox();
            pictureBox1 = new PictureBox();
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // iptFirstName
            // 
            iptFirstName.AccessibleName = "InputFirstName";
            iptFirstName.Location = new Point(402, 118);
            iptFirstName.Name = "iptFirstName";
            iptFirstName.Size = new Size(175, 27);
            iptFirstName.TabIndex = 0;
            iptFirstName.TextChanged += iptFirstName_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(402, 95);
            label1.Name = "label1";
            label1.Size = new Size(80, 20);
            label1.TabIndex = 1;
            label1.Text = "First Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(613, 95);
            label2.Name = "label2";
            label2.Size = new Size(79, 20);
            label2.TabIndex = 3;
            label2.Text = "Last Name";
            // 
            // iptLastName
            // 
            iptLastName.AccessibleName = "InputLastName";
            iptLastName.Location = new Point(613, 118);
            iptLastName.Name = "iptLastName";
            iptLastName.Size = new Size(175, 27);
            iptLastName.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(402, 156);
            label3.Name = "label3";
            label3.Size = new Size(46, 20);
            label3.TabIndex = 5;
            label3.Text = "Email";
            label3.Click += label3_Click;
            // 
            // iptEmail
            // 
            iptEmail.AccessibleName = "InputEmail";
            iptEmail.Location = new Point(402, 179);
            iptEmail.Name = "iptEmail";
            iptEmail.Size = new Size(386, 27);
            iptEmail.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(613, 226);
            label4.Name = "label4";
            label4.Size = new Size(70, 20);
            label4.TabIndex = 9;
            label4.Text = "Password";
            // 
            // iptPassword
            // 
            iptPassword.AccessibleName = "InputPassword";
            iptPassword.Location = new Point(613, 249);
            iptPassword.Name = "iptPassword";
            iptPassword.PasswordChar = '*';
            iptPassword.Size = new Size(175, 27);
            iptPassword.TabIndex = 8;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(402, 226);
            label5.Name = "label5";
            label5.Size = new Size(75, 20);
            label5.TabIndex = 7;
            label5.Text = "Username";
            // 
            // iptUsername
            // 
            iptUsername.AccessibleName = "InputUsername";
            iptUsername.Location = new Point(402, 249);
            iptUsername.Name = "iptUsername";
            iptUsername.Size = new Size(175, 27);
            iptUsername.TabIndex = 6;
            iptUsername.TextChanged += iptUsername_TextChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(613, 302);
            label6.Name = "label6";
            label6.Size = new Size(120, 20);
            label6.TabIndex = 11;
            label6.Text = "Retype Password";
            // 
            // iptRePassword
            // 
            iptRePassword.AccessibleName = "InputRePassword";
            iptRePassword.Location = new Point(613, 325);
            iptRePassword.Name = "iptRePassword";
            iptRePassword.PasswordChar = '*';
            iptRePassword.Size = new Size(175, 27);
            iptRePassword.TabIndex = 10;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label7.Location = new Point(402, 21);
            label7.Name = "label7";
            label7.Size = new Size(244, 37);
            label7.TabIndex = 12;
            label7.Text = "Customer Sign up";
            // 
            // button1
            // 
            button1.AccessibleName = "btnRegister";
            button1.Location = new Point(402, 386);
            button1.Name = "button1";
            button1.Size = new Size(386, 35);
            button1.TabIndex = 13;
            button1.Text = "Register";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // chkShowPass
            // 
            chkShowPass.AutoSize = true;
            chkShowPass.Location = new Point(404, 324);
            chkShowPass.Name = "chkShowPass";
            chkShowPass.Size = new Size(132, 24);
            chkShowPass.TabIndex = 15;
            chkShowPass.Text = "Show Password";
            chkShowPass.UseVisualStyleBackColor = true;
            chkShowPass.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // pictureBox1
            // 
            pictureBox1.ImageLocation = "C:\\Users\\Dilan Fernando\\Downloads\\LMU\\car_traders_signup.png";
            pictureBox1.InitialImage = null;
            pictureBox1.Location = new Point(-1, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(387, 448);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 16;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // button2
            // 
            button2.AccessibleName = "registerBack";
            button2.Location = new Point(12, 12);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 17;
            button2.Text = "< Back";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click_1;
            // 
            // RegisterForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            ControlBox = false;
            Controls.Add(button2);
            Controls.Add(pictureBox1);
            Controls.Add(chkShowPass);
            Controls.Add(button1);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(iptRePassword);
            Controls.Add(label4);
            Controls.Add(iptPassword);
            Controls.Add(label5);
            Controls.Add(iptUsername);
            Controls.Add(label3);
            Controls.Add(iptEmail);
            Controls.Add(label2);
            Controls.Add(iptLastName);
            Controls.Add(label1);
            Controls.Add(iptFirstName);
            Name = "RegisterForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Register - ABC Car Traders";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox iptFirstName;
        private Label label1;
        private Label label2;
        private TextBox iptLastName;
        private Label label3;
        private TextBox iptEmail;
        private Label label4;
        private TextBox iptPassword;
        private Label label5;
        private TextBox iptUsername;
        private Label label6;
        private TextBox iptRePassword;
        private Label label7;
        private Button button1;
        private CheckBox chkShowPass;
        private PictureBox pictureBox1;
        private Button button2;
    }
}