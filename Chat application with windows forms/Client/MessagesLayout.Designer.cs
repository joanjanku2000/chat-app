
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.new_conversation = new System.Windows.Forms.Button();
            this.message = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.chats_groupBox = new System.Windows.Forms.GroupBox();
            this.contacts_groupBox = new System.Windows.Forms.GroupBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.name = new System.Windows.Forms.Label();
            this.last_name = new System.Windows.Forms.Label();
            this.phone_number = new System.Windows.Forms.Label();
            this.new_contact = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.contacts_groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(21, 53);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(613, 358);
            this.textBox1.TabIndex = 5;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.new_conversation);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.message);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Location = new System.Drawing.Point(660, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(658, 511);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Communication Centre";
            // 
            // new_conversation
            // 
            this.new_conversation.Location = new System.Drawing.Point(483, 14);
            this.new_conversation.Name = "new_conversation";
            this.new_conversation.Size = new System.Drawing.Size(151, 33);
            this.new_conversation.TabIndex = 12;
            this.new_conversation.Text = "New Conversation";
            this.new_conversation.UseVisualStyleBackColor = true;
            this.new_conversation.Click += new System.EventHandler(this.new_conversation_Click);
            // 
            // message
            // 
            this.message.Location = new System.Drawing.Point(21, 435);
            this.message.Multiline = true;
            this.message.Name = "message";
            this.message.Size = new System.Drawing.Size(487, 52);
            this.message.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(514, 435);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 52);
            this.button1.TabIndex = 2;
            this.button1.Text = "Send";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // chats_groupBox
            // 
            this.chats_groupBox.Location = new System.Drawing.Point(281, 80);
            this.chats_groupBox.Name = "chats_groupBox";
            this.chats_groupBox.Size = new System.Drawing.Size(311, 480);
            this.chats_groupBox.TabIndex = 6;
            this.chats_groupBox.TabStop = false;
            this.chats_groupBox.Text = "Chats";
            // 
            // contacts_groupBox
            // 
            this.contacts_groupBox.Controls.Add(this.listView1);
            this.contacts_groupBox.Location = new System.Drawing.Point(38, 80);
            this.contacts_groupBox.Name = "contacts_groupBox";
            this.contacts_groupBox.Size = new System.Drawing.Size(214, 480);
            this.contacts_groupBox.TabIndex = 7;
            this.contacts_groupBox.TabStop = false;
            this.contacts_groupBox.Text = "Contacts";
            // 
            // listView1
            // 
            this.listView1.Font = new System.Drawing.Font("Book Antiqua", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(16, 21);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(192, 449);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.List;
            // 
            // name
            // 
            this.name.AutoSize = true;
            this.name.Location = new System.Drawing.Point(35, 18);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(46, 17);
            this.name.TabIndex = 8;
            this.name.Text = "label1";
            // 
            // last_name
            // 
            this.last_name.AutoSize = true;
            this.last_name.Location = new System.Drawing.Point(104, 18);
            this.last_name.Name = "last_name";
            this.last_name.Size = new System.Drawing.Size(46, 17);
            this.last_name.TabIndex = 9;
            this.last_name.Text = "label2";
            // 
            // phone_number
            // 
            this.phone_number.AutoSize = true;
            this.phone_number.Location = new System.Drawing.Point(179, 18);
            this.phone_number.Name = "phone_number";
            this.phone_number.Size = new System.Drawing.Size(46, 17);
            this.phone_number.TabIndex = 10;
            this.phone_number.Text = "label3";
            this.phone_number.Click += new System.EventHandler(this.phone_number_Click);
            // 
            // new_contact
            // 
            this.new_contact.Location = new System.Drawing.Point(142, 50);
            this.new_contact.Name = "new_contact";
            this.new_contact.Size = new System.Drawing.Size(110, 33);
            this.new_contact.TabIndex = 11;
            this.new_contact.Text = "New Contact";
            this.new_contact.UseVisualStyleBackColor = true;
            this.new_contact.Click += new System.EventHandler(this.new_contact_Click);
            // 
            // MessagesLayout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1348, 605);
            this.Controls.Add(this.new_contact);
            this.Controls.Add(this.phone_number);
            this.Controls.Add(this.last_name);
            this.Controls.Add(this.name);
            this.Controls.Add(this.chats_groupBox);
            this.Controls.Add(this.contacts_groupBox);
            this.Controls.Add(this.groupBox1);
            this.Name = "MessagesLayout";
            this.Text = "Chat ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MessagesLayout_FormClosing);
            this.Load += new System.EventHandler(this.MessagesLayout_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.contacts_groupBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}