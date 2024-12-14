namespace VIS_Project
{
    partial class AddProduct
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
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.nameTB = new System.Windows.Forms.TextBox();
            this.priceTB = new System.Windows.Forms.TextBox();
            this.quanntityTB = new System.Windows.Forms.TextBox();
            this.sungBT = new System.Windows.Forms.RadioButton();
            this.glsBT = new System.Windows.Forms.RadioButton();
            this.desTB = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.Location = new System.Drawing.Point(12, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Category";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label3.Location = new System.Drawing.Point(12, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Description";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label4.Location = new System.Drawing.Point(12, 242);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Price";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label5.Location = new System.Drawing.Point(12, 282);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Quantity";
            // 
            // nameTB
            // 
            this.nameTB.Location = new System.Drawing.Point(141, 12);
            this.nameTB.Name = "nameTB";
            this.nameTB.Size = new System.Drawing.Size(270, 20);
            this.nameTB.TabIndex = 5;
            // 
            // priceTB
            // 
            this.priceTB.Location = new System.Drawing.Point(141, 242);
            this.priceTB.Name = "priceTB";
            this.priceTB.Size = new System.Drawing.Size(270, 20);
            this.priceTB.TabIndex = 6;
            this.priceTB.TextChanged += new System.EventHandler(this.priceTB_TextChanged);
            // 
            // quanntityTB
            // 
            this.quanntityTB.Location = new System.Drawing.Point(141, 284);
            this.quanntityTB.Name = "quanntityTB";
            this.quanntityTB.Size = new System.Drawing.Size(270, 20);
            this.quanntityTB.TabIndex = 7;
            // 
            // sungBT
            // 
            this.sungBT.AutoSize = true;
            this.sungBT.Checked = true;
            this.sungBT.Location = new System.Drawing.Point(141, 56);
            this.sungBT.Name = "sungBT";
            this.sungBT.Size = new System.Drawing.Size(79, 17);
            this.sungBT.TabIndex = 8;
            this.sungBT.TabStop = true;
            this.sungBT.Text = "Sunglasses";
            this.sungBT.UseVisualStyleBackColor = true;
            // 
            // glsBT
            // 
            this.glsBT.AutoSize = true;
            this.glsBT.Location = new System.Drawing.Point(349, 56);
            this.glsBT.Name = "glsBT";
            this.glsBT.Size = new System.Drawing.Size(62, 17);
            this.glsBT.TabIndex = 9;
            this.glsBT.TabStop = true;
            this.glsBT.Text = "Glasses";
            this.glsBT.UseVisualStyleBackColor = true;
            // 
            // desTB
            // 
            this.desTB.Location = new System.Drawing.Point(141, 113);
            this.desTB.Name = "desTB";
            this.desTB.Size = new System.Drawing.Size(270, 96);
            this.desTB.TabIndex = 10;
            this.desTB.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(57, 345);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "Add";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(261, 345);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 12;
            this.button2.Text = "Back";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // AddProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 394);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.desTB);
            this.Controls.Add(this.glsBT);
            this.Controls.Add(this.sungBT);
            this.Controls.Add(this.quanntityTB);
            this.Controls.Add(this.priceTB);
            this.Controls.Add(this.nameTB);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AddProduct";
            this.Text = "AddProduct";
            this.Load += new System.EventHandler(this.AddProduct_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox nameTB;
        private System.Windows.Forms.TextBox priceTB;
        private System.Windows.Forms.TextBox quanntityTB;
        private System.Windows.Forms.RadioButton sungBT;
        private System.Windows.Forms.RadioButton glsBT;
        private System.Windows.Forms.RichTextBox desTB;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}