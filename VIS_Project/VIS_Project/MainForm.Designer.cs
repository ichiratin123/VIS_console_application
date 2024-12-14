namespace VIS_Project
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
            this.buttonsPanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.profileButton = new System.Windows.Forms.Button();
            this.manageBttons = new System.Windows.Forms.Button();
            this.checkButton = new System.Windows.Forms.Button();
            this.productButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.buttonsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonsPanel
            // 
            this.buttonsPanel.Controls.Add(this.exitButton);
            this.buttonsPanel.Controls.Add(this.productButton);
            this.buttonsPanel.Controls.Add(this.checkButton);
            this.buttonsPanel.Controls.Add(this.manageBttons);
            this.buttonsPanel.Controls.Add(this.profileButton);
            this.buttonsPanel.Location = new System.Drawing.Point(2, 0);
            this.buttonsPanel.Name = "buttonsPanel";
            this.buttonsPanel.Size = new System.Drawing.Size(200, 448);
            this.buttonsPanel.TabIndex = 0;
            this.buttonsPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.buttonsPanel_Paint);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(208, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(590, 448);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // profileButton
            // 
            this.profileButton.Location = new System.Drawing.Point(35, 27);
            this.profileButton.Name = "profileButton";
            this.profileButton.Size = new System.Drawing.Size(123, 47);
            this.profileButton.TabIndex = 0;
            this.profileButton.Text = "Profile";
            this.profileButton.UseVisualStyleBackColor = true;
            this.profileButton.Click += new System.EventHandler(this.profileButton_Click);
            // 
            // manageBttons
            // 
            this.manageBttons.Location = new System.Drawing.Point(35, 104);
            this.manageBttons.Name = "manageBttons";
            this.manageBttons.Size = new System.Drawing.Size(123, 47);
            this.manageBttons.TabIndex = 1;
            this.manageBttons.Text = "Manage";
            this.manageBttons.UseVisualStyleBackColor = true;
            this.manageBttons.Click += new System.EventHandler(this.manageBttons_Click);
            // 
            // checkButton
            // 
            this.checkButton.Location = new System.Drawing.Point(35, 187);
            this.checkButton.Name = "checkButton";
            this.checkButton.Size = new System.Drawing.Size(123, 47);
            this.checkButton.TabIndex = 2;
            this.checkButton.Text = "Order Check";
            this.checkButton.UseVisualStyleBackColor = true;
            this.checkButton.Click += new System.EventHandler(this.checkButton_Click);
            // 
            // productButton
            // 
            this.productButton.Location = new System.Drawing.Point(35, 276);
            this.productButton.Name = "productButton";
            this.productButton.Size = new System.Drawing.Size(123, 47);
            this.productButton.TabIndex = 3;
            this.productButton.Text = "Product";
            this.productButton.UseVisualStyleBackColor = true;
            this.productButton.Click += new System.EventHandler(this.productButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(35, 361);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(123, 47);
            this.exitButton.TabIndex = 4;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.buttonsPanel);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.buttonsPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel buttonsPanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button productButton;
        private System.Windows.Forms.Button checkButton;
        private System.Windows.Forms.Button manageBttons;
        private System.Windows.Forms.Button profileButton;
    }
}