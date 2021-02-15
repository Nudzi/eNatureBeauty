
namespace eNatureBeauty.WinUI.Inputs
{
    partial class frmInputAdd
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
            this.cmbStorages = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.numPDV = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNote = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.numPDV)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 132);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "PDV (%)";
            // 
            // cmbStorages
            // 
            this.cmbStorages.FormattingEnabled = true;
            this.cmbStorages.Location = new System.Drawing.Point(138, 175);
            this.cmbStorages.Name = "cmbStorages";
            this.cmbStorages.Size = new System.Drawing.Size(121, 28);
            this.cmbStorages.TabIndex = 2;
            this.cmbStorages.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 183);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Storage";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(18, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(259, 59);
            this.label3.TabIndex = 4;
            this.label3.Text = "New Input";
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnNext.Location = new System.Drawing.Point(288, 271);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(120, 42);
            this.btnNext.TabIndex = 5;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // numPDV
            // 
            this.numPDV.Location = new System.Drawing.Point(138, 132);
            this.numPDV.Name = "numPDV";
            this.numPDV.Size = new System.Drawing.Size(120, 26);
            this.numPDV.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 234);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Note";
            // 
            // txtNote
            // 
            this.txtNote.Location = new System.Drawing.Point(138, 217);
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(120, 96);
            this.txtNote.TabIndex = 8;
            this.txtNote.Text = "";
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::eNatureBeauty.WinUI.Properties.Resources.logo;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Location = new System.Drawing.Point(364, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(67, 52);
            this.panel1.TabIndex = 9;
            // 
            // frmInputAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 325);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtNote);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numPDV);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbStorages);
            this.Controls.Add(this.label1);
            this.Name = "frmInputAdd";
            this.Text = "frmInputAdd";
            this.Load += new System.EventHandler(this.frmInputAdd_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numPDV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbStorages;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.NumericUpDown numPDV;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox txtNote;
        private System.Windows.Forms.Panel panel1;
    }
}