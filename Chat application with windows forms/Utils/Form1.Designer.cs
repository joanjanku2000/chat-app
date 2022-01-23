
namespace Chat_application_with_windows_forms.Utils
{
    partial class ContactInfoForm
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
            this.name_label = new System.Windows.Forms.Label();
            this.phoneNumber_Label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // name_label
            // 
            this.name_label.AutoSize = true;
            this.name_label.Font = new System.Drawing.Font("Bookman Old Style", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.name_label.Location = new System.Drawing.Point(12, 34);
            this.name_label.Name = "name_label";
            this.name_label.Size = new System.Drawing.Size(86, 28);
            this.name_label.TabIndex = 0;
            this.name_label.Text = "label1";
            // 
            // phoneNumber_Label
            // 
            this.phoneNumber_Label.AutoSize = true;
            this.phoneNumber_Label.Font = new System.Drawing.Font("Engravers MT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phoneNumber_Label.Location = new System.Drawing.Point(13, 84);
            this.phoneNumber_Label.Name = "phoneNumber_Label";
            this.phoneNumber_Label.Size = new System.Drawing.Size(92, 19);
            this.phoneNumber_Label.TabIndex = 2;
            this.phoneNumber_Label.Text = "label3";
            // 
            // ContactInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(290, 150);
            this.Controls.Add(this.phoneNumber_Label);
            this.Controls.Add(this.name_label);
            this.Name = "ContactInfoForm";
            this.Text = "Contact";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label name_label;
        private System.Windows.Forms.Label phoneNumber_Label;
    }
}