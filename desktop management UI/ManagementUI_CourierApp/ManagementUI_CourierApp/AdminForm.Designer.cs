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
            this.label6 = new System.Windows.Forms.Label();
            this.comboBoxManager = new System.Windows.Forms.ComboBox();
            this.buttonPromoteCourier = new System.Windows.Forms.Button();
            this.buttonRemoveManagement = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxCourier = new System.Windows.Forms.ComboBox();
            this.buttonDemoteManager = new System.Windows.Forms.Button();
            this.buttonDeleteCourier = new System.Windows.Forms.Button();
            this.listBoxCourierDetails = new System.Windows.Forms.ListBox();
            this.btnGetCouriers = new System.Windows.Forms.Button();
            this.btnAssignCourier = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.panelProducts = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.buttonEditProduct = new System.Windows.Forms.Button();
            this.buttonNewProduct = new System.Windows.Forms.Button();
            this.buttonRemoveProduct = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.panelPackage = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.buttonEditPackage = new System.Windows.Forms.Button();
            this.buttonNewPackage = new System.Windows.Forms.Button();
            this.buttonRemovePackage = new System.Windows.Forms.Button();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.buttonLogout = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.panelProducts.SuspendLayout();
            this.panelPackage.SuspendLayout();
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
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.comboBoxManager);
            this.panel2.Controls.Add(this.buttonPromoteCourier);
            this.panel2.Controls.Add(this.buttonRemoveManagement);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.comboBoxCourier);
            this.panel2.Controls.Add(this.buttonDemoteManager);
            this.panel2.Controls.Add(this.buttonDeleteCourier);
            this.panel2.Controls.Add(this.listBoxCourierDetails);
            this.panel2.Controls.Add(this.btnGetCouriers);
            this.panel2.Controls.Add(this.btnAssignCourier);
            this.panel2.Location = new System.Drawing.Point(12, 25);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(412, 220);
            this.panel2.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Manager:";
            // 
            // comboBoxManager
            // 
            this.comboBoxManager.FormattingEnabled = true;
            this.comboBoxManager.Location = new System.Drawing.Point(65, 10);
            this.comboBoxManager.Name = "comboBoxManager";
            this.comboBoxManager.Size = new System.Drawing.Size(121, 21);
            this.comboBoxManager.TabIndex = 13;
            this.comboBoxManager.SelectedIndexChanged += new System.EventHandler(this.comboBoxManager_SelectedIndexChanged);
            // 
            // buttonPromoteCourier
            // 
            this.buttonPromoteCourier.Location = new System.Drawing.Point(14, 90);
            this.buttonPromoteCourier.Name = "buttonPromoteCourier";
            this.buttonPromoteCourier.Size = new System.Drawing.Size(128, 23);
            this.buttonPromoteCourier.TabIndex = 12;
            this.buttonPromoteCourier.Text = "Promote Courier";
            this.buttonPromoteCourier.UseVisualStyleBackColor = true;
            this.buttonPromoteCourier.Click += new System.EventHandler(this.buttonPromoteCourier_Click);
            // 
            // buttonRemoveManagement
            // 
            this.buttonRemoveManagement.Location = new System.Drawing.Point(14, 61);
            this.buttonRemoveManagement.Name = "buttonRemoveManagement";
            this.buttonRemoveManagement.Size = new System.Drawing.Size(128, 23);
            this.buttonRemoveManagement.TabIndex = 11;
            this.buttonRemoveManagement.Text = "Remove Management";
            this.buttonRemoveManagement.UseVisualStyleBackColor = true;
            this.buttonRemoveManagement.Click += new System.EventHandler(this.buttonRemoveManagement_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Courier:";
            // 
            // comboBoxCourier
            // 
            this.comboBoxCourier.FormattingEnabled = true;
            this.comboBoxCourier.Location = new System.Drawing.Point(65, 34);
            this.comboBoxCourier.Name = "comboBoxCourier";
            this.comboBoxCourier.Size = new System.Drawing.Size(121, 21);
            this.comboBoxCourier.TabIndex = 9;
            this.comboBoxCourier.SelectedIndexChanged += new System.EventHandler(this.comboBoxCourier_SelectedIndexChanged);
            // 
            // buttonDemoteManager
            // 
            this.buttonDemoteManager.Location = new System.Drawing.Point(281, 121);
            this.buttonDemoteManager.Name = "buttonDemoteManager";
            this.buttonDemoteManager.Size = new System.Drawing.Size(128, 23);
            this.buttonDemoteManager.TabIndex = 8;
            this.buttonDemoteManager.Text = "Demote";
            this.buttonDemoteManager.UseVisualStyleBackColor = true;
            this.buttonDemoteManager.Click += new System.EventHandler(this.buttonDemoteManager_Click);
            // 
            // buttonDeleteCourier
            // 
            this.buttonDeleteCourier.Location = new System.Drawing.Point(14, 177);
            this.buttonDeleteCourier.Name = "buttonDeleteCourier";
            this.buttonDeleteCourier.Size = new System.Drawing.Size(128, 23);
            this.buttonDeleteCourier.TabIndex = 7;
            this.buttonDeleteCourier.Text = "Remove Courier";
            this.buttonDeleteCourier.UseVisualStyleBackColor = true;
            this.buttonDeleteCourier.Click += new System.EventHandler(this.buttonDeleteCourier_Click);
            // 
            // listBoxCourierDetails
            // 
            this.listBoxCourierDetails.FormattingEnabled = true;
            this.listBoxCourierDetails.Location = new System.Drawing.Point(192, 7);
            this.listBoxCourierDetails.Name = "listBoxCourierDetails";
            this.listBoxCourierDetails.Size = new System.Drawing.Size(217, 108);
            this.listBoxCourierDetails.TabIndex = 6;
            // 
            // btnGetCouriers
            // 
            this.btnGetCouriers.Location = new System.Drawing.Point(14, 148);
            this.btnGetCouriers.Name = "btnGetCouriers";
            this.btnGetCouriers.Size = new System.Drawing.Size(128, 23);
            this.btnGetCouriers.TabIndex = 4;
            this.btnGetCouriers.Text = "Show Couriers";
            this.btnGetCouriers.UseVisualStyleBackColor = true;
            this.btnGetCouriers.Click += new System.EventHandler(this.btnGetCouriers_Click);
            // 
            // btnAssignCourier
            // 
            this.btnAssignCourier.Location = new System.Drawing.Point(14, 119);
            this.btnAssignCourier.Name = "btnAssignCourier";
            this.btnAssignCourier.Size = new System.Drawing.Size(128, 23);
            this.btnAssignCourier.TabIndex = 3;
            this.btnAssignCourier.Text = "Assign Manager";
            this.btnAssignCourier.UseVisualStyleBackColor = true;
            this.btnAssignCourier.Click += new System.EventHandler(this.btnAssignCourier_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(606, 261);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(238, 82);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            // 
            // panelProducts
            // 
            this.panelProducts.Controls.Add(this.label4);
            this.panelProducts.Controls.Add(this.comboBox2);
            this.panelProducts.Controls.Add(this.buttonEditProduct);
            this.panelProducts.Controls.Add(this.buttonNewProduct);
            this.panelProducts.Controls.Add(this.buttonRemoveProduct);
            this.panelProducts.Controls.Add(this.listBox1);
            this.panelProducts.Location = new System.Drawing.Point(12, 251);
            this.panelProducts.Name = "panelProducts";
            this.panelProducts.Size = new System.Drawing.Size(412, 220);
            this.panelProducts.TabIndex = 11;
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
            // buttonEditProduct
            // 
            this.buttonEditProduct.Location = new System.Drawing.Point(14, 92);
            this.buttonEditProduct.Name = "buttonEditProduct";
            this.buttonEditProduct.Size = new System.Drawing.Size(128, 23);
            this.buttonEditProduct.TabIndex = 8;
            this.buttonEditProduct.Text = "Edit Product";
            this.buttonEditProduct.UseVisualStyleBackColor = true;
            // 
            // buttonNewProduct
            // 
            this.buttonNewProduct.Location = new System.Drawing.Point(14, 34);
            this.buttonNewProduct.Name = "buttonNewProduct";
            this.buttonNewProduct.Size = new System.Drawing.Size(128, 23);
            this.buttonNewProduct.TabIndex = 4;
            this.buttonNewProduct.Text = "Add new Product";
            this.buttonNewProduct.UseVisualStyleBackColor = true;
            // 
            // buttonRemoveProduct
            // 
            this.buttonRemoveProduct.Location = new System.Drawing.Point(14, 63);
            this.buttonRemoveProduct.Name = "buttonRemoveProduct";
            this.buttonRemoveProduct.Size = new System.Drawing.Size(128, 23);
            this.buttonRemoveProduct.TabIndex = 7;
            this.buttonRemoveProduct.Text = "Remove Product";
            this.buttonRemoveProduct.UseVisualStyleBackColor = true;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(171, 34);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(217, 173);
            this.listBox1.TabIndex = 6;
            // 
            // panelPackage
            // 
            this.panelPackage.Controls.Add(this.label5);
            this.panelPackage.Controls.Add(this.comboBox3);
            this.panelPackage.Controls.Add(this.buttonEditPackage);
            this.panelPackage.Controls.Add(this.buttonNewPackage);
            this.panelPackage.Controls.Add(this.buttonRemovePackage);
            this.panelPackage.Controls.Add(this.listBox2);
            this.panelPackage.Location = new System.Drawing.Point(432, 25);
            this.panelPackage.Name = "panelPackage";
            this.panelPackage.Size = new System.Drawing.Size(412, 220);
            this.panelPackage.TabIndex = 12;
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
            // buttonEditPackage
            // 
            this.buttonEditPackage.Location = new System.Drawing.Point(14, 92);
            this.buttonEditPackage.Name = "buttonEditPackage";
            this.buttonEditPackage.Size = new System.Drawing.Size(128, 23);
            this.buttonEditPackage.TabIndex = 8;
            this.buttonEditPackage.Text = "Edit Package";
            this.buttonEditPackage.UseVisualStyleBackColor = true;
            // 
            // buttonNewPackage
            // 
            this.buttonNewPackage.Location = new System.Drawing.Point(14, 34);
            this.buttonNewPackage.Name = "buttonNewPackage";
            this.buttonNewPackage.Size = new System.Drawing.Size(128, 23);
            this.buttonNewPackage.TabIndex = 4;
            this.buttonNewPackage.Text = "Add new Package";
            this.buttonNewPackage.UseVisualStyleBackColor = true;
            // 
            // buttonRemovePackage
            // 
            this.buttonRemovePackage.Location = new System.Drawing.Point(14, 63);
            this.buttonRemovePackage.Name = "buttonRemovePackage";
            this.buttonRemovePackage.Size = new System.Drawing.Size(128, 23);
            this.buttonRemovePackage.TabIndex = 7;
            this.buttonRemovePackage.Text = "Remove Package";
            this.buttonRemovePackage.UseVisualStyleBackColor = true;
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(171, 34);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(217, 173);
            this.listBox2.TabIndex = 6;
            // 
            // buttonLogout
            // 
            this.buttonLogout.Location = new System.Drawing.Point(349, 3);
            this.buttonLogout.Name = "buttonLogout";
            this.buttonLogout.Size = new System.Drawing.Size(75, 23);
            this.buttonLogout.TabIndex = 13;
            this.buttonLogout.Text = "Logout";
            this.buttonLogout.UseVisualStyleBackColor = true;
            this.buttonLogout.Click += new System.EventHandler(this.buttonLogout_Click);
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 478);
            this.ControlBox = false;
            this.Controls.Add(this.buttonLogout);
            this.Controls.Add(this.panelPackage);
            this.Controls.Add(this.panelProducts);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.labelShowCurrentUser);
            this.Controls.Add(this.richTextBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AdminForm";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.AdminForm_Load_1);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panelProducts.ResumeLayout(false);
            this.panelProducts.PerformLayout();
            this.panelPackage.ResumeLayout(false);
            this.panelPackage.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelShowCurrentUser;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnGetCouriers;
        private System.Windows.Forms.Button btnAssignCourier;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.ListBox listBoxCourierDetails;
        private System.Windows.Forms.ComboBox comboBoxCourier;
        private System.Windows.Forms.Button buttonDemoteManager;
        private System.Windows.Forms.Button buttonDeleteCourier;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelProducts;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Button buttonEditProduct;
        private System.Windows.Forms.Button buttonNewProduct;
        private System.Windows.Forms.Button buttonRemoveProduct;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Panel panelPackage;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Button buttonEditPackage;
        private System.Windows.Forms.Button buttonNewPackage;
        private System.Windows.Forms.Button buttonRemovePackage;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Button buttonPromoteCourier;
        private System.Windows.Forms.Button buttonRemoveManagement;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBoxManager;
        private System.Windows.Forms.Button buttonLogout;
    }
}