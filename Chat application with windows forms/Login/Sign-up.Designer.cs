
namespace Chat_application_with_windows_forms.Login
{
    partial class Sign_in
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.phone_number = new System.Windows.Forms.TextBox();
            this.password = new System.Windows.Forms.TextBox();
            this.log_in = new System.Windows.Forms.Button();
            this.sign_up = new System.Windows.Forms.Button();
            this.password_sign_up = new System.Windows.Forms.TextBox();
            this.phone_number_sign_up = new System.Windows.Forms.TextBox();
            this.confirm_password = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.name = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lastname = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Script MT Bold", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(58, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(642, 52);
            this.label1.TabIndex = 0;
            this.label1.Text = "Welcome to Joan\'s Chat Application";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Book Antiqua", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkCyan;
            this.label2.Location = new System.Drawing.Point(116, 141);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(166, 28);
            this.label2.TabIndex = 1;
            this.label2.Text = "Please Log-in ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cambria Math", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Crimson;
            this.label3.Location = new System.Drawing.Point(430, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(323, 106);
            this.label3.TabIndex = 2;
            this.label3.Text = "Or Sign up with Phone Number";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // phone_number
            // 
            this.phone_number.Location = new System.Drawing.Point(121, 194);
            this.phone_number.Name = "phone_number";
            this.phone_number.Size = new System.Drawing.Size(248, 22);
            this.phone_number.TabIndex = 3;
            // 
            // password
            // 
            this.password.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.password.Location = new System.Drawing.Point(121, 232);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(248, 27);
            this.password.TabIndex = 4;
            this.password.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.password_KeyPress);
            // 
            // log_in
            // 
            this.log_in.Font = new System.Drawing.Font("Book Antiqua", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.log_in.Location = new System.Drawing.Point(121, 277);
            this.log_in.Name = "log_in";
            this.log_in.Size = new System.Drawing.Size(89, 38);
            this.log_in.TabIndex = 5;
            this.log_in.Text = "Log In";
            this.log_in.UseVisualStyleBackColor = true;
            this.log_in.Click += new System.EventHandler(this.log_in_Click);
            // 
            // sign_up
            // 
            this.sign_up.Font = new System.Drawing.Font("Bell MT", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sign_up.Location = new System.Drawing.Point(569, 345);
            this.sign_up.Name = "sign_up";
            this.sign_up.Size = new System.Drawing.Size(99, 38);
            this.sign_up.TabIndex = 6;
            this.sign_up.Text = "Sign Up";
            this.sign_up.UseVisualStyleBackColor = true;
            this.sign_up.Click += new System.EventHandler(this.sign_up_Click);
            // 
            // password_sign_up
            // 
            this.password_sign_up.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.password_sign_up.Location = new System.Drawing.Point(520, 256);
            this.password_sign_up.Name = "password_sign_up";
            this.password_sign_up.Size = new System.Drawing.Size(233, 27);
            this.password_sign_up.TabIndex = 8;
            // 
            // phone_number_sign_up
            // 
            this.phone_number_sign_up.Location = new System.Drawing.Point(520, 225);
            this.phone_number_sign_up.Name = "phone_number_sign_up";
            this.phone_number_sign_up.Size = new System.Drawing.Size(233, 22);
            this.phone_number_sign_up.TabIndex = 7;
            // 
            // confirm_password
            // 
            this.confirm_password.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.confirm_password.Location = new System.Drawing.Point(520, 301);
            this.confirm_password.Name = "confirm_password";
            this.confirm_password.Size = new System.Drawing.Size(233, 27);
            this.confirm_password.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(411, 228);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 17);
            this.label4.TabIndex = 10;
            this.label4.Text = "Phone Number";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(393, 301);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 17);
            this.label5.TabIndex = 11;
            this.label5.Text = "Confirm Password";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(432, 259);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 17);
            this.label6.TabIndex = 12;
            this.label6.Text = "Password";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 235);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 17);
            this.label7.TabIndex = 14;
            this.label7.Text = "Password";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 197);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(103, 17);
            this.label8.TabIndex = 13;
            this.label8.Text = "Phone Number";
            // 
            // name
            // 
            this.name.Location = new System.Drawing.Point(520, 166);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(233, 22);
            this.name.TabIndex = 15;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(430, 166);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(45, 17);
            this.label9.TabIndex = 16;
            this.label9.Text = "Name";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(411, 197);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(76, 17);
            this.label10.TabIndex = 18;
            this.label10.Text = "Last Name";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lastname
            // 
            this.lastname.Location = new System.Drawing.Point(520, 197);
            this.lastname.Name = "lastname";
            this.lastname.Size = new System.Drawing.Size(233, 22);
            this.lastname.TabIndex = 17;
            // 
            // Sign_in
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 395);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lastname);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.name);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.confirm_password);
            this.Controls.Add(this.password_sign_up);
            this.Controls.Add(this.phone_number_sign_up);
            this.Controls.Add(this.sign_up);
            this.Controls.Add(this.log_in);
            this.Controls.Add(this.password);
            this.Controls.Add(this.phone_number);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Sign_in";
            this.Text = "Welcome";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox phone_number;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.Button log_in;
        private System.Windows.Forms.Button sign_up;
        private System.Windows.Forms.TextBox password_sign_up;
        private System.Windows.Forms.TextBox phone_number_sign_up;
        private System.Windows.Forms.TextBox confirm_password;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox name;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox lastname;
    }
}