
namespace eNatureBeauty.WinUI.Report
{
    partial class frmReports
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReports));
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvResults = new System.Windows.Forms.DataGridView();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnOrders = new System.Windows.Forms.Button();
            this.btnInputs = new System.Windows.Forms.Button();
            this.btnOutputs = new System.Windows.Forms.Button();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.label4 = new System.Windows.Forms.Label();
            this.btnFromDisable = new System.Windows.Forms.Button();
            this.btnToDisable = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).BeginInit();
            this.SuspendLayout();
            // 
            // dtpFrom
            // 
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(605, 21);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(200, 26);
            this.dtpFrom.TabIndex = 1;
            // 
            // dtpTo
            // 
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(605, 62);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(200, 26);
            this.dtpTo.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 38F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(2, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(302, 86);
            this.label1.TabIndex = 2;
            this.label1.Text = "Reports";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(484, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "From date:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(484, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "To date:";
            // 
            // dgvResults
            // 
            this.dgvResults.AllowUserToAddRows = false;
            this.dgvResults.AllowUserToDeleteRows = false;
            this.dgvResults.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResults.Location = new System.Drawing.Point(286, 127);
            this.dgvResults.Name = "dgvResults";
            this.dgvResults.ReadOnly = true;
            this.dgvResults.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgvResults.RowTemplate.Height = 28;
            this.dgvResults.Size = new System.Drawing.Size(633, 311);
            this.dgvResults.TabIndex = 5;
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnPrint.Location = new System.Drawing.Point(17, 380);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(216, 58);
            this.btnPrint.TabIndex = 6;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnOrders
            // 
            this.btnOrders.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnOrders.Location = new System.Drawing.Point(17, 127);
            this.btnOrders.Name = "btnOrders";
            this.btnOrders.Size = new System.Drawing.Size(101, 60);
            this.btnOrders.TabIndex = 7;
            this.btnOrders.Text = "Orders";
            this.btnOrders.UseVisualStyleBackColor = false;
            this.btnOrders.Click += new System.EventHandler(this.btnOrders_Click);
            // 
            // btnInputs
            // 
            this.btnInputs.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnInputs.Location = new System.Drawing.Point(17, 193);
            this.btnInputs.Name = "btnInputs";
            this.btnInputs.Size = new System.Drawing.Size(101, 59);
            this.btnInputs.TabIndex = 8;
            this.btnInputs.Text = "Inputs";
            this.btnInputs.UseVisualStyleBackColor = false;
            this.btnInputs.Click += new System.EventHandler(this.btnInputs_Click);
            // 
            // btnOutputs
            // 
            this.btnOutputs.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnOutputs.Location = new System.Drawing.Point(17, 258);
            this.btnOutputs.Name = "btnOutputs";
            this.btnOutputs.Size = new System.Drawing.Size(101, 60);
            this.btnOutputs.TabIndex = 9;
            this.btnOutputs.Text = "Outputs";
            this.btnOutputs.UseVisualStyleBackColor = false;
            this.btnOutputs.Click += new System.EventHandler(this.btnOutputs_Click);
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Document = this.printDocument1;
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(282, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "Results to print:";
            // 
            // btnFromDisable
            // 
            this.btnFromDisable.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnFromDisable.Location = new System.Drawing.Point(828, 17);
            this.btnFromDisable.Name = "btnFromDisable";
            this.btnFromDisable.Size = new System.Drawing.Size(91, 35);
            this.btnFromDisable.TabIndex = 11;
            this.btnFromDisable.Text = "Disable";
            this.btnFromDisable.UseVisualStyleBackColor = false;
            this.btnFromDisable.Click += new System.EventHandler(this.btnFromDisable_Click);
            // 
            // btnToDisable
            // 
            this.btnToDisable.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnToDisable.Location = new System.Drawing.Point(828, 60);
            this.btnToDisable.Name = "btnToDisable";
            this.btnToDisable.Size = new System.Drawing.Size(91, 37);
            this.btnToDisable.TabIndex = 12;
            this.btnToDisable.Text = "Disable";
            this.btnToDisable.UseVisualStyleBackColor = false;
            this.btnToDisable.Click += new System.EventHandler(this.btnToDisable_Click);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::eNatureBeauty.WinUI.Properties.Resources.logo;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Location = new System.Drawing.Point(965, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(67, 52);
            this.panel1.TabIndex = 13;
            // 
            // frmReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1039, 461);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnToDisable);
            this.Controls.Add(this.btnFromDisable);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnOutputs);
            this.Controls.Add(this.btnInputs);
            this.Controls.Add(this.btnOrders);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.dgvResults);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpTo);
            this.Controls.Add(this.dtpFrom);
            this.Name = "frmReports";
            this.Text = "frmReports";
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvResults;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnOrders;
        private System.Windows.Forms.Button btnInputs;
        private System.Windows.Forms.Button btnOutputs;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnFromDisable;
        private System.Windows.Forms.Button btnToDisable;
        private System.Windows.Forms.Panel panel1;
    }
}