
namespace eNatureBeauty.WinUI.Orders
{
    partial class frmOrderStatus
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
            this.txtOrderNum = new System.Windows.Forms.TextBox();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnWaiting = new System.Windows.Forms.Button();
            this.btnFinished = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(46, 153);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Order Number";
            // 
            // txtOrderNum
            // 
            this.txtOrderNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOrderNum.Location = new System.Drawing.Point(261, 150);
            this.txtOrderNum.Name = "txtOrderNum";
            this.txtOrderNum.ReadOnly = true;
            this.txtOrderNum.Size = new System.Drawing.Size(179, 39);
            this.txtOrderNum.TabIndex = 1;
            // 
            // txtStatus
            // 
            this.txtStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStatus.Location = new System.Drawing.Point(261, 210);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.Size = new System.Drawing.Size(179, 39);
            this.txtStatus.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(46, 217);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 32);
            this.label2.TabIndex = 2;
            this.label2.Text = "Status";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(337, 64);
            this.label3.TabIndex = 4;
            this.label3.Text = "Order status";
            // 
            // btnWaiting
            // 
            this.btnWaiting.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnWaiting.Location = new System.Drawing.Point(99, 297);
            this.btnWaiting.Name = "btnWaiting";
            this.btnWaiting.Size = new System.Drawing.Size(125, 56);
            this.btnWaiting.TabIndex = 5;
            this.btnWaiting.Text = "Waiting";
            this.btnWaiting.UseVisualStyleBackColor = false;
            this.btnWaiting.Click += new System.EventHandler(this.btnWaiting_Click);
            // 
            // btnFinished
            // 
            this.btnFinished.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnFinished.Location = new System.Drawing.Point(261, 297);
            this.btnFinished.Name = "btnFinished";
            this.btnFinished.Size = new System.Drawing.Size(116, 56);
            this.btnFinished.TabIndex = 6;
            this.btnFinished.Text = "Finished";
            this.btnFinished.UseVisualStyleBackColor = false;
            this.btnFinished.Click += new System.EventHandler(this.btnFinished_Click);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::eNatureBeauty.WinUI.Properties.Resources.logo;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Location = new System.Drawing.Point(482, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(67, 52);
            this.panel1.TabIndex = 7;
            // 
            // frmOrderStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 401);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnFinished);
            this.Controls.Add(this.btnWaiting);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtOrderNum);
            this.Controls.Add(this.label1);
            this.Name = "frmOrderStatus";
            this.Text = "frmOrderStatus";
            this.Load += new System.EventHandler(this.frmOrderStatus_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtOrderNum;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnWaiting;
        private System.Windows.Forms.Button btnFinished;
        private System.Windows.Forms.Panel panel1;
    }
}