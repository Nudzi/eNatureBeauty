
namespace eNatureBeauty.WinUI.Ingredients
{
    partial class frmIngredients
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvIngredients = new System.Windows.Forms.DataGridView();
            this.IngredientID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IngredientName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Action = new System.Windows.Forms.DataGridViewLinkColumn();
            this.cmbIngredientTypes = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIngredients)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvIngredients
            // 
            this.dgvIngredients.AllowUserToAddRows = false;
            this.dgvIngredients.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvIngredients.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvIngredients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIngredients.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IngredientID,
            this.IngredientName,
            this.Action});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvIngredients.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvIngredients.Location = new System.Drawing.Point(12, 237);
            this.dgvIngredients.Name = "dgvIngredients";
            this.dgvIngredients.ReadOnly = true;
            this.dgvIngredients.RowHeadersWidth = 62;
            this.dgvIngredients.RowTemplate.Height = 28;
            this.dgvIngredients.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvIngredients.Size = new System.Drawing.Size(776, 182);
            this.dgvIngredients.TabIndex = 0;
            this.dgvIngredients.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvIngredients_CellContentClick);
            this.dgvIngredients.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvIngredients_CellMouseDoubleClick);
            // 
            // IngredientID
            // 
            this.IngredientID.DataPropertyName = "IngredientID";
            this.IngredientID.HeaderText = "IngredientID";
            this.IngredientID.MinimumWidth = 8;
            this.IngredientID.Name = "IngredientID";
            this.IngredientID.ReadOnly = true;
            this.IngredientID.Visible = false;
            this.IngredientID.Width = 150;
            // 
            // IngredientName
            // 
            this.IngredientName.DataPropertyName = "Name";
            this.IngredientName.HeaderText = "Ingredient Name";
            this.IngredientName.MinimumWidth = 8;
            this.IngredientName.Name = "IngredientName";
            this.IngredientName.ReadOnly = true;
            this.IngredientName.Width = 150;
            // 
            // Action
            // 
            this.Action.HeaderText = "Action";
            this.Action.MinimumWidth = 8;
            this.Action.Name = "Action";
            this.Action.ReadOnly = true;
            this.Action.Text = "Edit";
            this.Action.ToolTipText = "Edit";
            this.Action.UseColumnTextForLinkValue = true;
            this.Action.VisitedLinkColor = System.Drawing.Color.Purple;
            this.Action.Width = 150;
            // 
            // cmbIngredientTypes
            // 
            this.cmbIngredientTypes.FormattingEnabled = true;
            this.cmbIngredientTypes.Location = new System.Drawing.Point(551, 67);
            this.cmbIngredientTypes.Name = "cmbIngredientTypes";
            this.cmbIngredientTypes.Size = new System.Drawing.Size(237, 28);
            this.cmbIngredientTypes.TabIndex = 5;
            this.cmbIngredientTypes.SelectedIndexChanged += new System.EventHandler(this.cmbIngredientTypes_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 38F);
            this.label1.Location = new System.Drawing.Point(12, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(516, 86);
            this.label1.TabIndex = 4;
            this.label1.Text = "All Ingredients";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(547, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(182, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Choose Ingredient Type:";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(12, 194);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(364, 26);
            this.txtSearch.TabIndex = 8;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSearch.Location = new System.Drawing.Point(382, 188);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(114, 36);
            this.btnSearch.TabIndex = 9;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 168);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(228, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "Search Ingredient by its name: ";
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::eNatureBeauty.WinUI.Properties.Resources.logo;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Location = new System.Drawing.Point(731, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(67, 52);
            this.panel1.TabIndex = 11;
            // 
            // frmIngredients
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.dgvIngredients);
            this.Controls.Add(this.cmbIngredientTypes);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.DoubleBuffered = true;
            this.Name = "frmIngredients";
            this.Text = "frmIngredients";
            this.Load += new System.EventHandler(this.frmIngredients_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvIngredients)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvIngredients;
        private System.Windows.Forms.ComboBox cmbIngredientTypes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn IngredientID;
        private System.Windows.Forms.DataGridViewTextBoxColumn IngredientName;
        private System.Windows.Forms.DataGridViewLinkColumn Action;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
    }
}