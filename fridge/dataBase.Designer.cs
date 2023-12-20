namespace fridge
{
    partial class dataBase
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
            this.dataC1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.x = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataC1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataC1
            // 
            this.dataC1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataC1.Location = new System.Drawing.Point(12, 62);
            this.dataC1.Name = "dataC1";
            this.dataC1.RowHeadersWidth = 51;
            this.dataC1.RowTemplate.Height = 24;
            this.dataC1.Size = new System.Drawing.Size(706, 420);
            this.dataC1.TabIndex = 0;
            this.dataC1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Times New Roman", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(516, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(109, 50);
            this.button1.TabIndex = 1;
            this.button1.Text = "HOME";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // x
            // 
            this.x.BackColor = System.Drawing.Color.Red;
            this.x.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.x.Location = new System.Drawing.Point(650, 6);
            this.x.Name = "x";
            this.x.Size = new System.Drawing.Size(59, 49);
            this.x.TabIndex = 2;
            this.x.Text = "x";
            this.x.UseVisualStyleBackColor = false;
            this.x.Click += new System.EventHandler(this.x_Click);
            // 
            // dataBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(735, 494);
            this.Controls.Add(this.x);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataC1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "dataBase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "dataBase";
            this.Load += new System.EventHandler(this.dataBase_Load);
            this.Shown += new System.EventHandler(this.dataBase_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dataC1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataC1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button x;
    }
}