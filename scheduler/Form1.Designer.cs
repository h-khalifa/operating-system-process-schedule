namespace scheduler
{
    partial class Form1
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
            this.select = new System.Windows.Forms.Button();
            this.comboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // select
            // 
            this.select.Font = new System.Drawing.Font("Tahoma", 12F);
            this.select.Location = new System.Drawing.Point(302, 19);
            this.select.Name = "select";
            this.select.Size = new System.Drawing.Size(75, 27);
            this.select.TabIndex = 0;
            this.select.Text = "Select";
            this.select.UseVisualStyleBackColor = true;
            this.select.Click += new System.EventHandler(this.select_Click);
            // 
            // comboBox
            // 
            this.comboBox.Font = new System.Drawing.Font("Tahoma", 12F);
            this.comboBox.FormattingEnabled = true;
            this.comboBox.Items.AddRange(new object[] {
            "FCFS",
            "SJF",
            "PRIORITY",
            "ROUND ROBIN"});
            this.comboBox.Location = new System.Drawing.Point(130, 19);
            this.comboBox.Name = "comboBox";
            this.comboBox.Size = new System.Drawing.Size(154, 27);
            this.comboBox.TabIndex = 1;
            this.comboBox.Text = "FCFS";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "select scheduler type ";
            // 
            // panel
            // 
            this.panel.Location = new System.Drawing.Point(12, 60);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(614, 359);
            this.panel.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 431);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox);
            this.Controls.Add(this.select);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "Scheduler";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button select;
        private System.Windows.Forms.ComboBox comboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel;
    }
}

