namespace InventorySalingSystem
{
    partial class stock
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.textBoxSerchStyle = new System.Windows.Forms.TextBox();
            this.buttonSerchStyle = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 83);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1227, 543);
            this.dataGridView1.TabIndex = 0;
            // 
            // textBoxSerchStyle
            // 
            this.textBoxSerchStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSerchStyle.Location = new System.Drawing.Point(796, 32);
            this.textBoxSerchStyle.Name = "textBoxSerchStyle";
            this.textBoxSerchStyle.Size = new System.Drawing.Size(238, 23);
            this.textBoxSerchStyle.TabIndex = 1;
            // 
            // buttonSerchStyle
            // 
            this.buttonSerchStyle.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.buttonSerchStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSerchStyle.Location = new System.Drawing.Point(1053, 29);
            this.buttonSerchStyle.Name = "buttonSerchStyle";
            this.buttonSerchStyle.Size = new System.Drawing.Size(154, 29);
            this.buttonSerchStyle.TabIndex = 2;
            this.buttonSerchStyle.Text = "Serch with style name";
            this.buttonSerchStyle.UseVisualStyleBackColor = false;
            this.buttonSerchStyle.Click += new System.EventHandler(this.buttonSerchStyle_Click);
            // 
            // stock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1251, 638);
            this.Controls.Add(this.buttonSerchStyle);
            this.Controls.Add(this.textBoxSerchStyle);
            this.Controls.Add(this.dataGridView1);
            this.Name = "stock";
            this.Text = "stock";
            this.Load += new System.EventHandler(this.stock_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox textBoxSerchStyle;
        private System.Windows.Forms.Button buttonSerchStyle;
    }
}