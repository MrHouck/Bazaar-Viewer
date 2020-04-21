namespace HypixelBazzar
{
    partial class ChildForm
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
            this.labelSellPrice = new System.Windows.Forms.Label();
            this.labelBuyPrice = new System.Windows.Forms.Label();
            this.labelBuyVolume = new System.Windows.Forms.Label();
            this.labelSellVolume = new System.Windows.Forms.Label();
            this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 15.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(493, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "{}";
            // 
            // labelSellPrice
            // 
            this.labelSellPrice.AutoSize = true;
            this.labelSellPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSellPrice.ForeColor = System.Drawing.Color.White;
            this.labelSellPrice.Location = new System.Drawing.Point(330, 56);
            this.labelSellPrice.Name = "labelSellPrice";
            this.labelSellPrice.Size = new System.Drawing.Size(92, 20);
            this.labelSellPrice.TabIndex = 1;
            this.labelSellPrice.Text = "Sell Price: {}";
            // 
            // labelBuyPrice
            // 
            this.labelBuyPrice.AutoSize = true;
            this.labelBuyPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBuyPrice.ForeColor = System.Drawing.Color.White;
            this.labelBuyPrice.Location = new System.Drawing.Point(59, 56);
            this.labelBuyPrice.Name = "labelBuyPrice";
            this.labelBuyPrice.Size = new System.Drawing.Size(93, 20);
            this.labelBuyPrice.TabIndex = 1;
            this.labelBuyPrice.Text = "Buy Price: {}";
            // 
            // labelBuyVolume
            // 
            this.labelBuyVolume.AutoSize = true;
            this.labelBuyVolume.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBuyVolume.ForeColor = System.Drawing.Color.White;
            this.labelBuyVolume.Location = new System.Drawing.Point(59, 91);
            this.labelBuyVolume.Name = "labelBuyVolume";
            this.labelBuyVolume.Size = new System.Drawing.Size(112, 20);
            this.labelBuyVolume.TabIndex = 2;
            this.labelBuyVolume.Text = "Buy Volume: {}";
            // 
            // labelSellVolume
            // 
            this.labelSellVolume.AutoSize = true;
            this.labelSellVolume.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSellVolume.ForeColor = System.Drawing.Color.White;
            this.labelSellVolume.Location = new System.Drawing.Point(330, 91);
            this.labelSellVolume.Name = "labelSellVolume";
            this.labelSellVolume.Size = new System.Drawing.Size(111, 20);
            this.labelSellVolume.TabIndex = 3;
            this.labelSellVolume.Text = "Sell Volume: {}";
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(21)))), ((int)(((byte)(32)))));
            this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBox1.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Items.AddRange(new object[] {
            "Top Sell Orders"});
            this.listBox1.Location = new System.Drawing.Point(293, 130);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(203, 351);
            this.listBox1.TabIndex = 8;
            // 
            // listBox2
            // 
            this.listBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(21)))), ((int)(((byte)(32)))));
            this.listBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBox2.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Items.AddRange(new object[] {
            "Top Buy Orders"});
            this.listBox2.Location = new System.Drawing.Point(12, 130);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(203, 351);
            this.listBox2.TabIndex = 9;
            // 
            // ChildForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(1142, 499);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.labelSellVolume);
            this.Controls.Add(this.labelBuyVolume);
            this.Controls.Add(this.labelBuyPrice);
            this.Controls.Add(this.labelSellPrice);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ChildForm";
            this.Text = "Wheat";
            this.Load += new System.EventHandler(this.ChildForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelSellPrice;
        private System.Windows.Forms.Label labelBuyPrice;
        private System.Windows.Forms.Label labelBuyVolume;
        private System.Windows.Forms.Label labelSellVolume;
        private System.Windows.Forms.PageSetupDialog pageSetupDialog1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ListBox listBox2;
    }
}