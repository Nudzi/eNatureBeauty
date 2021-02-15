
namespace eNatureBeauty.WinUI.Inputs
{
    partial class frmOutputProductsAdd
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
            this.dgvProducts = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.dgvInputProducts = new System.Windows.Forms.DataGridView();
            this.ProdId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NewName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSave = new System.Windows.Forms.Button();
            this.numProducts = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtFiltered = new System.Windows.Forms.Button();
            this.btnModify = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.numModify = new System.Windows.Forms.NumericUpDown();
            this.btnRemove = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInputProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numModify)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 38F);
            this.label1.Location = new System.Drawing.Point(13, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(674, 86);
            this.label1.TabIndex = 0;
            this.label1.Text = "Products for output";
            // 
            // dgvProducts
            // 
            this.dgvProducts.AllowUserToAddRows = false;
            this.dgvProducts.AllowUserToDeleteRows = false;
            this.dgvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProducts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.ProductName});
            this.dgvProducts.Location = new System.Drawing.Point(12, 199);
            this.dgvProducts.Name = "dgvProducts";
            this.dgvProducts.ReadOnly = true;
            this.dgvProducts.RowHeadersWidth = 62;
            this.dgvProducts.RowTemplate.Height = 28;
            this.dgvProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProducts.Size = new System.Drawing.Size(379, 182);
            this.dgvProducts.TabIndex = 0;
            this.dgvProducts.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProducts_CellClick);
            this.dgvProducts.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProducts_CellContentClick);
            this.dgvProducts.Click += new System.EventHandler(this.dgvProducts_Click);
            this.dgvProducts.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgvProducts_MouseDoubleClick);
            this.dgvProducts.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvProducts_MouseDoubleClick);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.MinimumWidth = 8;
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            this.Id.Width = 150;
            // 
            // ProductName
            // 
            this.ProductName.DataPropertyName = "Name";
            this.ProductName.HeaderText = "Product Name";
            this.ProductName.MinimumWidth = 8;
            this.ProductName.Name = "ProductName";
            this.ProductName.ReadOnly = true;
            this.ProductName.Width = 150;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(12, 144);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(270, 26);
            this.txtSearch.TabIndex = 2;
            // 
            // dgvInputProducts
            // 
            this.dgvInputProducts.AllowUserToAddRows = false;
            this.dgvInputProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInputProducts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProdId,
            this.NewName,
            this.Quantity});
            this.dgvInputProducts.Location = new System.Drawing.Point(397, 199);
            this.dgvInputProducts.Name = "dgvInputProducts";
            this.dgvInputProducts.ReadOnly = true;
            this.dgvInputProducts.RowHeadersWidth = 62;
            this.dgvInputProducts.RowTemplate.Height = 28;
            this.dgvInputProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInputProducts.Size = new System.Drawing.Size(544, 182);
            this.dgvInputProducts.TabIndex = 4;
            this.dgvInputProducts.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvInputProducts_CellBeginEdit);
            this.dgvInputProducts.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInputProducts_CellClick);
            this.dgvInputProducts.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInputProducts_CellContentClick);
            this.dgvInputProducts.Click += new System.EventHandler(this.dgvInputProducts_Click);
            // 
            // ProdId
            // 
            this.ProdId.DataPropertyName = "Id";
            this.ProdId.HeaderText = "Id";
            this.ProdId.MinimumWidth = 8;
            this.ProdId.Name = "ProdId";
            this.ProdId.ReadOnly = true;
            this.ProdId.Visible = false;
            this.ProdId.Width = 150;
            // 
            // NewName
            // 
            this.NewName.DataPropertyName = "Name";
            this.NewName.HeaderText = "Product Name";
            this.NewName.MinimumWidth = 8;
            this.NewName.Name = "NewName";
            this.NewName.ReadOnly = true;
            this.NewName.Width = 150;
            // 
            // Quantity
            // 
            this.Quantity.DataPropertyName = "Quantity";
            this.Quantity.HeaderText = "Quantity";
            this.Quantity.MinimumWidth = 8;
            this.Quantity.Name = "Quantity";
            this.Quantity.ReadOnly = true;
            this.Quantity.Width = 150;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSave.Location = new System.Drawing.Point(803, 545);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(138, 60);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // numProducts
            // 
            this.numProducts.Location = new System.Drawing.Point(287, 409);
            this.numProducts.Name = "numProducts";
            this.numProducts.Size = new System.Drawing.Size(104, 26);
            this.numProducts.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 411);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(268, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Choose qunatity of selected product:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 121);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(193, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "Search by Product Name: ";
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAdd.Location = new System.Drawing.Point(287, 441);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(104, 39);
            this.btnAdd.TabIndex = 11;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtFiltered
            // 
            this.txtFiltered.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtFiltered.Location = new System.Drawing.Point(288, 138);
            this.txtFiltered.Name = "txtFiltered";
            this.txtFiltered.Size = new System.Drawing.Size(103, 39);
            this.txtFiltered.TabIndex = 12;
            this.txtFiltered.Text = "Search";
            this.txtFiltered.UseVisualStyleBackColor = false;
            this.txtFiltered.Click += new System.EventHandler(this.txtFiltered_Click);
            // 
            // btnModify
            // 
            this.btnModify.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnModify.Location = new System.Drawing.Point(730, 441);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(104, 39);
            this.btnModify.TabIndex = 15;
            this.btnModify.Text = "Modify";
            this.btnModify.UseVisualStyleBackColor = false;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(512, 411);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(212, 20);
            this.label5.TabIndex = 14;
            this.label5.Text = "Qunatity of selected product:";
            // 
            // numModify
            // 
            this.numModify.Location = new System.Drawing.Point(730, 409);
            this.numModify.Name = "numModify";
            this.numModify.Size = new System.Drawing.Size(104, 26);
            this.numModify.TabIndex = 13;
            // 
            // btnRemove
            // 
            this.btnRemove.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnRemove.Location = new System.Drawing.Point(840, 441);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(104, 39);
            this.btnRemove.TabIndex = 16;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = false;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::eNatureBeauty.WinUI.Properties.Resources.logo;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Location = new System.Drawing.Point(880, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(67, 52);
            this.panel1.TabIndex = 17;
            // 
            // frmOutputProductsAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(953, 617);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnModify);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.numModify);
            this.Controls.Add(this.txtFiltered);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numProducts);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dgvInputProducts);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.dgvProducts);
            this.Controls.Add(this.label1);
            this.Name = "frmOutputProductsAdd";
            this.Text = "frmOutputProductsAdd";
            this.Load += new System.EventHandler(this.frmInputProductsAdd_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInputProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numModify)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DataGridView dgvInputProducts;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.NumericUpDown numProducts;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button txtFiltered;
        private System.Windows.Forms.Button btnModify;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numModify;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProdId;
        private System.Windows.Forms.DataGridViewTextBoxColumn NewName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.Panel panel1;
    }
}