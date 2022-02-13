
namespace Chat_application_with_windows_forms.Client
{
    partial class MessagesLayout
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MessagesLayout));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.download_button = new System.Windows.Forms.Button();
            this.chat_files_ListView = new System.Windows.Forms.ListView();
            this.attachment_button = new System.Windows.Forms.Button();
            this.deleteChat_Button = new Chat_application_with_windows_forms.Utils.ChatButton();
            this.message = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.chats_groupBox = new System.Windows.Forms.GroupBox();
            this.chat_panel = new System.Windows.Forms.Panel();
            this.contacts_groupBox = new System.Windows.Forms.GroupBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.name = new System.Windows.Forms.Label();
            this.last_name = new System.Windows.Forms.Label();
            this.phone_number = new System.Windows.Forms.Label();
            this.new_contact = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.update_info = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.viewGroup_button = new System.Windows.Forms.Button();
            this.groupsListView = new System.Windows.Forms.ListView();
            this.button2 = new System.Windows.Forms.Button();
            this.reports_Group = new System.Windows.Forms.Button();
            this.new_conversation = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.chats_groupBox.SuspendLayout();
            this.contacts_groupBox.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBox1.Font = new System.Drawing.Font("Bookman Old Style", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(16, 60);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(400, 393);
            this.textBox1.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Azure;
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.download_button);
            this.groupBox1.Controls.Add(this.chat_files_ListView);
            this.groupBox1.Controls.Add(this.attachment_button);
            this.groupBox1.Controls.Add(this.deleteChat_Button);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.message);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Location = new System.Drawing.Point(508, 33);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(635, 527);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Communication Centre";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bookman Old Style", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(421, 34);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 19);
            this.label1.TabIndex = 14;
            this.label1.Text = "Files";
            // 
            // download_button
            // 
            this.download_button.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("download_button.BackgroundImage")));
            this.download_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.download_button.Location = new System.Drawing.Point(570, 411);
            this.download_button.Margin = new System.Windows.Forms.Padding(2);
            this.download_button.Name = "download_button";
            this.download_button.Size = new System.Drawing.Size(61, 55);
            this.download_button.TabIndex = 15;
            this.download_button.UseVisualStyleBackColor = true;
            this.download_button.Click += new System.EventHandler(this.download_button_Click);
            // 
            // chat_files_ListView
            // 
            this.chat_files_ListView.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.chat_files_ListView.Font = new System.Drawing.Font("Book Antiqua", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chat_files_ListView.HideSelection = false;
            this.chat_files_ListView.Location = new System.Drawing.Point(420, 60);
            this.chat_files_ListView.Margin = new System.Windows.Forms.Padding(2);
            this.chat_files_ListView.Name = "chat_files_ListView";
            this.chat_files_ListView.Size = new System.Drawing.Size(211, 347);
            this.chat_files_ListView.TabIndex = 1;
            this.chat_files_ListView.UseCompatibleStateImageBehavior = false;
            this.chat_files_ListView.View = System.Windows.Forms.View.List;
            // 
            // attachment_button
            // 
            this.attachment_button.AutoEllipsis = true;
            this.attachment_button.BackColor = System.Drawing.Color.Transparent;
            this.attachment_button.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("attachment_button.BackgroundImage")));
            this.attachment_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.attachment_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.attachment_button.ForeColor = System.Drawing.Color.SeaGreen;
            this.attachment_button.Location = new System.Drawing.Point(420, 411);
            this.attachment_button.Margin = new System.Windows.Forms.Padding(2);
            this.attachment_button.Name = "attachment_button";
            this.attachment_button.Size = new System.Drawing.Size(62, 55);
            this.attachment_button.TabIndex = 7;
            this.attachment_button.UseVisualStyleBackColor = false;
            this.attachment_button.Click += new System.EventHandler(this.attachment_button_Click);
            // 
            // deleteChat_Button
            // 
            this.deleteChat_Button.BackgroundImage = global::Chat_application_with_windows_forms.Properties.Resources.icon_delete_16;
            this.deleteChat_Button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.deleteChat_Button.Location = new System.Drawing.Point(16, 18);
            this.deleteChat_Button.Name = "deleteChat_Button";
            this.deleteChat_Button.phoneNumber = null;
            this.deleteChat_Button.Size = new System.Drawing.Size(45, 40);
            this.deleteChat_Button.TabIndex = 6;
            this.deleteChat_Button.UseVisualStyleBackColor = true;
            this.deleteChat_Button.Click += new System.EventHandler(this.deleteChat_Button_Click);
            // 
            // message
            // 
            this.message.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.message.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.message.Font = new System.Drawing.Font("Bookman Old Style", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.message.Location = new System.Drawing.Point(16, 470);
            this.message.Margin = new System.Windows.Forms.Padding(2);
            this.message.Multiline = true;
            this.message.Name = "message";
            this.message.Size = new System.Drawing.Size(400, 43);
            this.message.TabIndex = 3;
            this.message.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.message_KeyPress);
            // 
            // button1
            // 
            this.button1.AutoEllipsis = true;
            this.button1.BackColor = System.Drawing.Color.DarkGreen;
            this.button1.BackgroundImage = global::Chat_application_with_windows_forms.Properties.Resources._74_749231_png_file_svg_send_message_icon_png_transparent;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.ForeColor = System.Drawing.Color.SeaGreen;
            this.button1.Location = new System.Drawing.Point(420, 470);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(57, 42);
            this.button1.TabIndex = 2;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // chats_groupBox
            // 
            this.chats_groupBox.BackColor = System.Drawing.Color.MintCream;
            this.chats_groupBox.Controls.Add(this.chat_panel);
            this.chats_groupBox.Location = new System.Drawing.Point(264, 33);
            this.chats_groupBox.Margin = new System.Windows.Forms.Padding(2);
            this.chats_groupBox.Name = "chats_groupBox";
            this.chats_groupBox.Padding = new System.Windows.Forms.Padding(2);
            this.chats_groupBox.Size = new System.Drawing.Size(233, 306);
            this.chats_groupBox.TabIndex = 6;
            this.chats_groupBox.TabStop = false;
            this.chats_groupBox.Text = "Chats";
            // 
            // chat_panel
            // 
            this.chat_panel.AutoScroll = true;
            this.chat_panel.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.chat_panel.Location = new System.Drawing.Point(20, 28);
            this.chat_panel.Margin = new System.Windows.Forms.Padding(2);
            this.chat_panel.Name = "chat_panel";
            this.chat_panel.Size = new System.Drawing.Size(187, 245);
            this.chat_panel.TabIndex = 0;
            // 
            // contacts_groupBox
            // 
            this.contacts_groupBox.BackColor = System.Drawing.Color.LightGreen;
            this.contacts_groupBox.Controls.Add(this.listView1);
            this.contacts_groupBox.Location = new System.Drawing.Point(16, 171);
            this.contacts_groupBox.Margin = new System.Windows.Forms.Padding(2);
            this.contacts_groupBox.Name = "contacts_groupBox";
            this.contacts_groupBox.Padding = new System.Windows.Forms.Padding(2);
            this.contacts_groupBox.Size = new System.Drawing.Size(160, 301);
            this.contacts_groupBox.TabIndex = 7;
            this.contacts_groupBox.TabStop = false;
            this.contacts_groupBox.Text = "Contacts";
            // 
            // listView1
            // 
            this.listView1.Font = new System.Drawing.Font("Book Antiqua", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(4, 17);
            this.listView1.Margin = new System.Windows.Forms.Padding(2);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(145, 270);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.List;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            this.listView1.DoubleClick += new System.EventHandler(this.listView1_DoubleClick);
            // 
            // name
            // 
            this.name.AutoSize = true;
            this.name.Font = new System.Drawing.Font("Bookman Old Style", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.name.Location = new System.Drawing.Point(4, 24);
            this.name.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(57, 19);
            this.name.TabIndex = 8;
            this.name.Text = "label1";
            // 
            // last_name
            // 
            this.last_name.AutoSize = true;
            this.last_name.Font = new System.Drawing.Font("Bookman Old Style", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.last_name.Location = new System.Drawing.Point(4, 46);
            this.last_name.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.last_name.Name = "last_name";
            this.last_name.Size = new System.Drawing.Size(58, 19);
            this.last_name.TabIndex = 9;
            this.last_name.Text = "label2";
            // 
            // phone_number
            // 
            this.phone_number.AutoSize = true;
            this.phone_number.Font = new System.Drawing.Font("Book Antiqua", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phone_number.Location = new System.Drawing.Point(4, 81);
            this.phone_number.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.phone_number.Name = "phone_number";
            this.phone_number.Size = new System.Drawing.Size(48, 19);
            this.phone_number.TabIndex = 10;
            this.phone_number.Text = "label3";
            this.phone_number.Click += new System.EventHandler(this.phone_number_Click);
            // 
            // new_contact
            // 
            this.new_contact.Location = new System.Drawing.Point(94, 140);
            this.new_contact.Margin = new System.Windows.Forms.Padding(2);
            this.new_contact.Name = "new_contact";
            this.new_contact.Size = new System.Drawing.Size(82, 27);
            this.new_contact.TabIndex = 11;
            this.new_contact.Text = "New Contact";
            this.new_contact.UseVisualStyleBackColor = true;
            this.new_contact.Click += new System.EventHandler(this.new_contact_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.MintCream;
            this.groupBox2.Controls.Add(this.update_info);
            this.groupBox2.Controls.Add(this.name);
            this.groupBox2.Controls.Add(this.last_name);
            this.groupBox2.Controls.Add(this.phone_number);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox2.ImeMode = System.Windows.Forms.ImeMode.Katakana;
            this.groupBox2.Location = new System.Drawing.Point(16, 10);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(223, 125);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "User Info";
            // 
            // update_info
            // 
            this.update_info.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.update_info.BackgroundImage = global::Chat_application_with_windows_forms.Properties.Resources._28725582_7cba90da_7383_11e7_9a78_a5356c305a6e;
            this.update_info.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.update_info.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.update_info.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.update_info.Location = new System.Drawing.Point(170, 80);
            this.update_info.Margin = new System.Windows.Forms.Padding(2);
            this.update_info.Name = "update_info";
            this.update_info.Size = new System.Drawing.Size(49, 41);
            this.update_info.TabIndex = 13;
            this.update_info.UseVisualStyleBackColor = false;
            this.update_info.Click += new System.EventHandler(this.update_info_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Honeydew;
            this.groupBox3.Controls.Add(this.viewGroup_button);
            this.groupBox3.Controls.Add(this.groupsListView);
            this.groupBox3.Location = new System.Drawing.Point(264, 343);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(233, 217);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Groups";
            // 
            // viewGroup_button
            // 
            this.viewGroup_button.Location = new System.Drawing.Point(132, 170);
            this.viewGroup_button.Name = "viewGroup_button";
            this.viewGroup_button.Size = new System.Drawing.Size(75, 23);
            this.viewGroup_button.TabIndex = 14;
            this.viewGroup_button.Text = "View Group";
            this.viewGroup_button.UseVisualStyleBackColor = true;
            this.viewGroup_button.Click += new System.EventHandler(this.viewGroup_button_Click);
            // 
            // groupsListView
            // 
            this.groupsListView.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.groupsListView.Font = new System.Drawing.Font("Book Antiqua", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupsListView.HideSelection = false;
            this.groupsListView.Location = new System.Drawing.Point(19, 25);
            this.groupsListView.Margin = new System.Windows.Forms.Padding(2);
            this.groupsListView.Name = "groupsListView";
            this.groupsListView.Size = new System.Drawing.Size(188, 140);
            this.groupsListView.TabIndex = 1;
            this.groupsListView.UseCompatibleStateImageBehavior = false;
            this.groupsListView.View = System.Windows.Forms.View.List;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Green;
            this.button2.Font = new System.Drawing.Font("Book Antiqua", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.FloralWhite;
            this.button2.Location = new System.Drawing.Point(38, 477);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(138, 31);
            this.button2.TabIndex = 13;
            this.button2.Text = "Create Group";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // reports_Group
            // 
            this.reports_Group.BackColor = System.Drawing.Color.RoyalBlue;
            this.reports_Group.Font = new System.Drawing.Font("Bell MT", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reports_Group.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.reports_Group.Location = new System.Drawing.Point(16, 514);
            this.reports_Group.Name = "reports_Group";
            this.reports_Group.Size = new System.Drawing.Size(219, 46);
            this.reports_Group.TabIndex = 14;
            this.reports_Group.Text = "Raporte Statistikore";
            this.reports_Group.UseVisualStyleBackColor = false;
            this.reports_Group.Click += new System.EventHandler(this.reports_Group_Click);
            // 
            // new_conversation
            // 
            this.new_conversation.BackgroundImage = global::Chat_application_with_windows_forms.Properties.Resources.Message_Free_Icon_fidswo;
            this.new_conversation.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.new_conversation.Location = new System.Drawing.Point(187, 171);
            this.new_conversation.Margin = new System.Windows.Forms.Padding(2);
            this.new_conversation.Name = "new_conversation";
            this.new_conversation.Size = new System.Drawing.Size(48, 47);
            this.new_conversation.TabIndex = 12;
            this.new_conversation.UseVisualStyleBackColor = true;
            this.new_conversation.Click += new System.EventHandler(this.new_conversation_Click);
            // 
            // MessagesLayout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1168, 571);
            this.Controls.Add(this.reports_Group);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.new_conversation);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.new_contact);
            this.Controls.Add(this.chats_groupBox);
            this.Controls.Add(this.contacts_groupBox);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MessagesLayout";
            this.Text = "Chat ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MessagesLayout_FormClosing);
            this.Load += new System.EventHandler(this.MessagesLayout_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.chats_groupBox.ResumeLayout(false);
            this.contacts_groupBox.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox chats_groupBox;
        private System.Windows.Forms.GroupBox contacts_groupBox;
        private System.Windows.Forms.TextBox message;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button new_conversation;
        private System.Windows.Forms.Label name;
        private System.Windows.Forms.Label last_name;
        private System.Windows.Forms.Label phone_number;
        private System.Windows.Forms.Button new_contact;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Panel chat_panel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button update_info;
        private Utils.ChatButton deleteChat_Button;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListView groupsListView;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button viewGroup_button;
        private System.Windows.Forms.Button reports_Group;
        private System.Windows.Forms.Button attachment_button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button download_button;
        private System.Windows.Forms.ListView chat_files_ListView;
    }
}