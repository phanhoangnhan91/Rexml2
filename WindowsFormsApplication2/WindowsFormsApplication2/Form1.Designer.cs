namespace WindowsFormsApplication2
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
            this.raAll = new System.Windows.Forms.RadioButton();
            this.buttonExport = new System.Windows.Forms.Button();
            this.txtFrom = new System.Windows.Forms.TextBox();
            this.txtTo = new System.Windows.Forms.TextBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbNumberRecord = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // raAll
            // 
            this.raAll.AutoSize = true;
            this.raAll.Location = new System.Drawing.Point(23, 47);
            this.raAll.Name = "raAll";
            this.raAll.Size = new System.Drawing.Size(254, 17);
            this.raAll.TabIndex = 1;
            this.raAll.Text = "Xuất toàn bộ database (có thể lỗi out of memory)";
            this.raAll.UseVisualStyleBackColor = true;
            // 
            // buttonExport
            // 
            this.buttonExport.Location = new System.Drawing.Point(94, 70);
            this.buttonExport.Name = "buttonExport";
            this.buttonExport.Size = new System.Drawing.Size(75, 23);
            this.buttonExport.TabIndex = 4;
            this.buttonExport.Text = "Xuất file xml";
            this.buttonExport.UseVisualStyleBackColor = true;
            this.buttonExport.Click += new System.EventHandler(this.buttonExport_Click);
            // 
            // txtFrom
            // 
            this.txtFrom.Location = new System.Drawing.Point(81, 21);
            this.txtFrom.Name = "txtFrom";
            this.txtFrom.Size = new System.Drawing.Size(77, 20);
            this.txtFrom.TabIndex = 5;
            this.txtFrom.Text = "77896";
            // 
            // txtTo
            // 
            this.txtTo.Location = new System.Drawing.Point(212, 21);
            this.txtTo.Name = "txtTo";
            this.txtTo.Size = new System.Drawing.Size(85, 20);
            this.txtTo.TabIndex = 6;
            this.txtTo.Text = "100000";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(23, 21);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(52, 17);
            this.radioButton1.TabIndex = 7;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Từ ID";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(164, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Đến ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Số lượng record đã đọc";
            // 
            // lbNumberRecord
            // 
            this.lbNumberRecord.AutoSize = true;
            this.lbNumberRecord.Location = new System.Drawing.Point(164, 102);
            this.lbNumberRecord.Name = "lbNumberRecord";
            this.lbNumberRecord.Size = new System.Drawing.Size(0, 13);
            this.lbNumberRecord.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(322, 145);
            this.Controls.Add(this.lbNumberRecord);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.txtTo);
            this.Controls.Add(this.txtFrom);
            this.Controls.Add(this.buttonExport);
            this.Controls.Add(this.raAll);
            this.Name = "Form1";
            this.Text = " Extract clauses structures";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton raAll;
        private System.Windows.Forms.Button buttonExport;
        private System.Windows.Forms.TextBox txtFrom;
        private System.Windows.Forms.TextBox txtTo;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbNumberRecord;
    }
}

