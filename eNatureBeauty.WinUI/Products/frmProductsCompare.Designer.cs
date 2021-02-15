
namespace eNatureBeauty.WinUI.Products
{
    partial class frmProductsCompare
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbFirst = new System.Windows.Forms.ComboBox();
            this.cmbSecond = new System.Windows.Forms.ComboBox();
            this.btnCompare = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 38F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(658, 86);
            this.label1.TabIndex = 0;
            this.label1.Text = "Compare products";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(423, 170);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(178, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Choose second product";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 170);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(152, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Choose first product";
            // 
            // cmbFirst
            // 
            this.cmbFirst.FormattingEnabled = true;
            this.cmbFirst.Location = new System.Drawing.Point(16, 203);
            this.cmbFirst.Name = "cmbFirst";
            this.cmbFirst.Size = new System.Drawing.Size(313, 28);
            this.cmbFirst.TabIndex = 3;
            this.cmbFirst.SelectedIndexChanged += new System.EventHandler(this.cmbFirst_SelectedIndexChanged);
            this.cmbFirst.Validating += new System.ComponentModel.CancelEventHandler(this.cmbFirst_Validating);
            // 
            // cmbSecond
            // 
            this.cmbSecond.FormattingEnabled = true;
            this.cmbSecond.Location = new System.Drawing.Point(427, 203);
            this.cmbSecond.Name = "cmbSecond";
            this.cmbSecond.Size = new System.Drawing.Size(328, 28);
            this.cmbSecond.TabIndex = 4;
            this.cmbSecond.SelectedIndexChanged += new System.EventHandler(this.cmbSecond_SelectedIndexChanged);
            this.cmbSecond.Validating += new System.ComponentModel.CancelEventHandler(this.cmbSecond_Validating);
            // 
            // btnCompare
            // 
            this.btnCompare.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCompare.Location = new System.Drawing.Point(305, 334);
            this.btnCompare.Name = "btnCompare";
            this.btnCompare.Size = new System.Drawing.Size(142, 44);
            this.btnCompare.TabIndex = 5;
            this.btnCompare.Text = "Compare";
            this.btnCompare.UseVisualStyleBackColor = false;
            this.btnCompare.Click += new System.EventHandler(this.btnCompare_Click);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::eNatureBeauty.WinUI.Properties.Resources.logo;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Location = new System.Drawing.Point(692, 9);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(67, 52);
            this.panel1.TabIndex = 8;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmProductsCompare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(767, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnCompare);
            this.Controls.Add(this.cmbSecond);
            this.Controls.Add(this.cmbFirst);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmProductsCompare";
            this.Text = "frmProductsCompare";
            this.Load += new System.EventHandler(this.frmProductsCompare_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbFirst;
        private System.Windows.Forms.ComboBox cmbSecond;
        private System.Windows.Forms.Button btnCompare;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}