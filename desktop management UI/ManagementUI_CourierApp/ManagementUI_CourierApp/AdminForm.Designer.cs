namespace ManagementUI_CourierApp
{
    partial class AdminForm
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
            this.labelShowCurrentUser = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.listBoxCouriers = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnGetCouriers = new System.Windows.Forms.Button();
            this.btnAssignCourier = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.textAdminId = new System.Windows.Forms.TextBox();
            this.textCourierId = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelShowCurrentUser
            // 
            this.labelShowCurrentUser.AutoSize = true;
            this.labelShowCurrentUser.Location = new System.Drawing.Point(12, 9);
            this.labelShowCurrentUser.Name = "labelShowCurrentUser";
            this.labelShowCurrentUser.Size = new System.Drawing.Size(76, 13);
            this.labelShowCurrentUser.TabIndex = 1;
            this.labelShowCurrentUser.Text = "Connected as:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button11);
            this.panel2.Controls.Add(this.button10);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.comboBox1);
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.listBoxCouriers);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.btnGetCouriers);
            this.panel2.Controls.Add(this.btnAssignCourier);
            this.panel2.Controls.Add(this.textAdminId);
            this.panel2.Controls.Add(this.textCourierId);
            this.panel2.Location = new System.Drawing.Point(12, 25);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(412, 220);
            this.panel2.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(192, 124);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Courier:";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(241, 121);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 9;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(14, 182);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(128, 23);
            this.button3.TabIndex = 8;
            this.button3.Text = "Edit Courier";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(14, 124);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(128, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Add new Courier";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(14, 153);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(128, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "Remove Courier";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // listBoxCouriers
            // 
            this.listBoxCouriers.FormattingEnabled = true;
            this.listBoxCouriers.Location = new System.Drawing.Point(192, 7);
            this.listBoxCouriers.Name = "listBoxCouriers";
            this.listBoxCouriers.Size = new System.Drawing.Size(217, 108);
            this.listBoxCouriers.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Courier:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Manager:";
            // 
            // btnGetCouriers
            // 
            this.btnGetCouriers.Location = new System.Drawing.Point(14, 95);
            this.btnGetCouriers.Name = "btnGetCouriers";
            this.btnGetCouriers.Size = new System.Drawing.Size(128, 23);
            this.btnGetCouriers.TabIndex = 4;
            this.btnGetCouriers.Text = "Show Couriers";
            this.btnGetCouriers.UseVisualStyleBackColor = true;
            this.btnGetCouriers.Click += new System.EventHandler(this.btnGetCouriers_Click);
            // 
            // btnAssignCourier
            // 
            this.btnAssignCourier.Location = new System.Drawing.Point(192, 148);
            this.btnAssignCourier.Name = "btnAssignCourier";
            this.btnAssignCourier.Size = new System.Drawing.Size(128, 23);
            this.btnAssignCourier.TabIndex = 3;
            this.btnAssignCourier.Text = "Assign Manager";
            this.btnAssignCourier.UseVisualStyleBackColor = true;
            this.btnAssignCourier.Click += new System.EventHandler(this.btnAssignCourier_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(606, 435);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(238, 23);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            // 
            // textAdminId
            // 
            this.textAdminId.Location = new System.Drawing.Point(66, 7);
            this.textAdminId.Name = "textAdminId";
            this.textAdminId.Size = new System.Drawing.Size(100, 20);
            this.textAdminId.TabIndex = 1;
            // 
            // textCourierId
            // 
            this.textCourierId.Location = new System.Drawing.Point(66, 36);
            this.textCourierId.Name = "textCourierId";
            this.textCourierId.Size = new System.Drawing.Size(100, 20);
            this.textCourierId.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.comboBox2);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.button6);
            this.panel1.Controls.Add(this.listBox1);
            this.panel1.Location = new System.Drawing.Point(12, 251);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(412, 220);
            this.panel1.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Product:";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(66, 7);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 21);
            this.comboBox2.TabIndex = 9;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(14, 92);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(128, 23);
            this.button4.TabIndex = 8;
            this.button4.Text = "Edit Product";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(14, 34);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(128, 23);
            this.button5.TabIndex = 4;
            this.button5.Text = "Add new Product";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(14, 63);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(128, 23);
            this.button6.TabIndex = 7;
            this.button6.Text = "Remove Product";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(171, 34);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(217, 173);
            this.listBox1.TabIndex = 6;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.comboBox3);
            this.panel3.Controls.Add(this.button7);
            this.panel3.Controls.Add(this.button8);
            this.panel3.Controls.Add(this.button9);
            this.panel3.Controls.Add(this.listBox2);
            this.panel3.Location = new System.Drawing.Point(432, 25);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(412, 220);
            this.panel3.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Package:";
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(66, 7);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(121, 21);
            this.comboBox3.TabIndex = 9;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(14, 92);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(128, 23);
            this.button7.TabIndex = 8;
            this.button7.Text = "Edit Package";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(14, 34);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(128, 23);
            this.button8.TabIndex = 4;
            this.button8.Text = "Add new Package";
            this.button8.UseVisualStyleBackColor = true;
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(14, 63);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(128, 23);
            this.button9.TabIndex = 7;
            this.button9.Text = "Remove Package";
            this.button9.UseVisualStyleBackColor = true;
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(171, 34);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(217, 173);
            this.listBox2.TabIndex = 6;
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(192, 177);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(128, 23);
            this.button10.TabIndex = 11;
            this.button10.Text = "Remove Management";
            this.button10.UseVisualStyleBackColor = true;
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(14, 66);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(128, 23);
            this.button11.TabIndex = 12;
            this.button11.Text = "Promote Courier";
            this.button11.UseVisualStyleBackColor = true;
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(856, 478);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.labelShowCurrentUser);
            this.Controls.Add(this.richTextBox1);
            this.Name = "AdminForm";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.AdminForm_Load_1);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelShowCurrentUser;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnGetCouriers;
        private System.Windows.Forms.Button btnAssignCourier;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TextBox textAdminId;
        private System.Windows.Forms.TextBox textCourierId;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBoxCouriers;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button10;
    }
}