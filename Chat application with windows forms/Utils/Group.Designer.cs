
namespace Chat_application_with_windows_forms.Utils
{
    partial class GroupInfoForm
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
            this.name = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.users_GBOX = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.participantsNumberLabel = new System.Windows.Forms.Label();
            this.totalCount_label = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chatbox_Box = new System.Windows.Forms.TextBox();
            this.message_Box = new System.Windows.Forms.TextBox();
            this.send_Button = new System.Windows.Forms.Button();
            this.users_GBOX.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // name
            // 
            this.name.AutoSize = true;
            this.name.Font = new System.Drawing.Font("Book Antiqua", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.name.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.name.Location = new System.Drawing.Point(24, 39);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(72, 26);
            this.name.TabIndex = 0;
            this.name.Text = "label1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Book Antiqua", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.MenuText;
            this.label1.Location = new System.Drawing.Point(25, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Admin:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Book Antiqua", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.SeaGreen;
            this.label2.Location = new System.Drawing.Point(89, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 26);
            this.label2.TabIndex = 2;
            this.label2.Text = "label1";
            // 
            // users_GBOX
            // 
            this.users_GBOX.Controls.Add(this.button2);
            this.users_GBOX.Controls.Add(this.button1);
            this.users_GBOX.Controls.Add(this.listView1);
            this.users_GBOX.Controls.Add(this.button3);
            this.users_GBOX.Location = new System.Drawing.Point(29, 202);
            this.users_GBOX.Name = "users_GBOX";
            this.users_GBOX.Size = new System.Drawing.Size(407, 211);
            this.users_GBOX.TabIndex = 3;
            this.users_GBOX.TabStop = false;
            this.users_GBOX.Text = "Anetaret";
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.DarkRed;
            this.button2.Location = new System.Drawing.Point(260, 68);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 31);
            this.button2.TabIndex = 2;
            this.button2.Text = "Fshi";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.DarkGreen;
            this.button1.Location = new System.Drawing.Point(215, 31);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(177, 31);
            this.button1.TabIndex = 1;
            this.button1.Text = "Shto pjesemarres";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(20, 19);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(189, 165);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.List;
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Bookman Old Style", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.DarkRed;
            this.button3.Location = new System.Drawing.Point(260, 105);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 54);
            this.button3.TabIndex = 4;
            this.button3.Text = "Delete Group";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(29, 148);
            this.button4.Margin = new System.Windows.Forms.Padding(2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(103, 19);
            this.button4.TabIndex = 5;
            this.button4.Text = "Ndrysho emrin";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // participantsNumberLabel
            // 
            this.participantsNumberLabel.AutoSize = true;
            this.participantsNumberLabel.Location = new System.Drawing.Point(26, 118);
            this.participantsNumberLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.participantsNumberLabel.Name = "participantsNumberLabel";
            this.participantsNumberLabel.Size = new System.Drawing.Size(96, 13);
            this.participantsNumberLabel.TabIndex = 6;
            this.participantsNumberLabel.Text = "Numri i anetareve :";
            // 
            // totalCount_label
            // 
            this.totalCount_label.AutoSize = true;
            this.totalCount_label.Location = new System.Drawing.Point(218, 118);
            this.totalCount_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.totalCount_label.Name = "totalCount_label";
            this.totalCount_label.Size = new System.Drawing.Size(0, 13);
            this.totalCount_label.TabIndex = 7;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chatbox_Box);
            this.groupBox1.Controls.Add(this.message_Box);
            this.groupBox1.Controls.Add(this.send_Button);
            this.groupBox1.Location = new System.Drawing.Point(451, 11);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(494, 403);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Communication Centre";
            // 
            // chatbox_Box
            // 
            this.chatbox_Box.Font = new System.Drawing.Font("Bookman Old Style", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chatbox_Box.Location = new System.Drawing.Point(16, 17);
            this.chatbox_Box.Margin = new System.Windows.Forms.Padding(2);
            this.chatbox_Box.Multiline = true;
            this.chatbox_Box.Name = "chatbox_Box";
            this.chatbox_Box.ReadOnly = true;
            this.chatbox_Box.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.chatbox_Box.Size = new System.Drawing.Size(461, 314);
            this.chatbox_Box.TabIndex = 5;
            // 
            // message_Box
            // 
            this.message_Box.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.message_Box.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.message_Box.Font = new System.Drawing.Font("Bookman Old Style", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.message_Box.Location = new System.Drawing.Point(16, 350);
            this.message_Box.Margin = new System.Windows.Forms.Padding(2);
            this.message_Box.Multiline = true;
            this.message_Box.Name = "message_Box";
            this.message_Box.Size = new System.Drawing.Size(388, 43);
            this.message_Box.TabIndex = 3;
            this.message_Box.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.message_Box_KeyPress);
            // 
            // send_Button
            // 
            this.send_Button.AutoEllipsis = true;
            this.send_Button.BackgroundImage = global::Chat_application_with_windows_forms.Properties.Resources._74_749231_png_file_svg_send_message_icon_png_transparent;
            this.send_Button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.send_Button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.send_Button.Location = new System.Drawing.Point(420, 350);
            this.send_Button.Margin = new System.Windows.Forms.Padding(2);
            this.send_Button.Name = "send_Button";
            this.send_Button.Size = new System.Drawing.Size(57, 42);
            this.send_Button.TabIndex = 2;
            this.send_Button.UseVisualStyleBackColor = true;
            this.send_Button.Click += new System.EventHandler(this.send_Button_Click);
            // 
            // GroupInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(981, 441);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.totalCount_label);
            this.Controls.Add(this.participantsNumberLabel);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.users_GBOX);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.name);
            this.Name = "GroupInfoForm";
            this.Text = "Group";
            this.users_GBOX.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox users_GBOX;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label participantsNumberLabel;
        private System.Windows.Forms.Label totalCount_label;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox chatbox_Box;
        private System.Windows.Forms.TextBox message_Box;
        private System.Windows.Forms.Button send_Button;
    }
}