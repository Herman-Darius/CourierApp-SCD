namespace ManagementUI_CourierApp
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.labelShowCurrentUser = new System.Windows.Forms.Label();
            this.buttonComplete = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonAccept = new System.Windows.Forms.Button();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.comboBoxNewDeliveries = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboBoxMyDeliveries = new System.Windows.Forms.ComboBox();
            this.listBoxCouriers = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelShowCurrentUser
            // 
            this.labelShowCurrentUser.AutoSize = true;
            this.labelShowCurrentUser.Location = new System.Drawing.Point(12, 9);
            this.labelShowCurrentUser.Name = "labelShowCurrentUser";
            this.labelShowCurrentUser.Size = new System.Drawing.Size(76, 13);
            this.labelShowCurrentUser.TabIndex = 0;
            this.labelShowCurrentUser.Text = "Connected as:";
            this.labelShowCurrentUser.Click += new System.EventHandler(this.labelShowCurrentUser_Click);
            // 
            // buttonComplete
            // 
            this.buttonComplete.Location = new System.Drawing.Point(89, 152);
            this.buttonComplete.Name = "buttonComplete";
            this.buttonComplete.Size = new System.Drawing.Size(75, 23);
            this.buttonComplete.TabIndex = 3;
            this.buttonComplete.Text = "Complete";
            this.buttonComplete.UseVisualStyleBackColor = true;
            this.buttonComplete.Click += new System.EventHandler(this.buttonComplete_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "My deliveries:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(423, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 6;
            // 
            // buttonAccept
            // 
            this.buttonAccept.Location = new System.Drawing.Point(8, 152);
            this.buttonAccept.Name = "buttonAccept";
            this.buttonAccept.Size = new System.Drawing.Size(75, 23);
            this.buttonAccept.TabIndex = 7;
            this.buttonAccept.Text = "Accept";
            this.buttonAccept.UseVisualStyleBackColor = true;
            this.buttonAccept.Click += new System.EventHandler(this.buttonAccept_Click);
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Image = ((System.Drawing.Image)(resources.GetObject("buttonRefresh.Image")));
            this.buttonRefresh.Location = new System.Drawing.Point(170, 143);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(34, 32);
            this.buttonRefresh.TabIndex = 9;
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.Location = new System.Drawing.Point(332, 4);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(75, 23);
            this.buttonExit.TabIndex = 10;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.button5_Click);
            // 
            // comboBoxNewDeliveries
            // 
            this.comboBoxNewDeliveries.FormattingEnabled = true;
            this.comboBoxNewDeliveries.Location = new System.Drawing.Point(89, 15);
            this.comboBoxNewDeliveries.Name = "comboBoxNewDeliveries";
            this.comboBoxNewDeliveries.Size = new System.Drawing.Size(110, 21);
            this.comboBoxNewDeliveries.TabIndex = 14;
            this.comboBoxNewDeliveries.SelectedIndexChanged += new System.EventHandler(this.comboBoxNewDeliveries_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.comboBoxMyDeliveries);
            this.panel1.Controls.Add(this.listBoxCouriers);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.comboBoxNewDeliveries);
            this.panel1.Controls.Add(this.buttonAccept);
            this.panel1.Controls.Add(this.buttonComplete);
            this.panel1.Controls.Add(this.buttonRefresh);
            this.panel1.Location = new System.Drawing.Point(13, 33);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(394, 192);
            this.panel1.TabIndex = 15;
            // 
            // comboBoxMyDeliveries
            // 
            this.comboBoxMyDeliveries.FormattingEnabled = true;
            this.comboBoxMyDeliveries.Location = new System.Drawing.Point(89, 46);
            this.comboBoxMyDeliveries.Name = "comboBoxMyDeliveries";
            this.comboBoxMyDeliveries.Size = new System.Drawing.Size(110, 21);
            this.comboBoxMyDeliveries.TabIndex = 17;
            this.comboBoxMyDeliveries.SelectedIndexChanged += new System.EventHandler(this.comboBoxMyDeliveries_SelectedIndexChanged);
            // 
            // listBoxCouriers
            // 
            this.listBoxCouriers.FormattingEnabled = true;
            this.listBoxCouriers.Location = new System.Drawing.Point(210, 15);
            this.listBoxCouriers.Name = "listBoxCouriers";
            this.listBoxCouriers.Size = new System.Drawing.Size(179, 160);
            this.listBoxCouriers.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "New deliveries:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 241);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelShowCurrentUser);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelShowCurrentUser;
        private System.Windows.Forms.Button buttonComplete;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonAccept;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.ComboBox comboBoxNewDeliveries;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox comboBoxMyDeliveries;
        private System.Windows.Forms.ListBox listBoxCouriers;
        private System.Windows.Forms.Label label5;
    }
}