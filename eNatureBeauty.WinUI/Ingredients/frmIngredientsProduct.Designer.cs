
namespace eNatureBeauty.WinUI.Ingredients
{
    partial class frmIngredientsProduct
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtFiltered = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.dgvIngredientsProducts = new System.Windows.Forms.DataGridView();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.dgvIngredients = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ingredientname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnModify = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.numModify = new System.Windows.Forms.NumericUpDown();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.numMeasure = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIngredientsProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIngredients)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numModify)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMeasure)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::eNatureBeauty.WinUI.Properties.Resources.logo;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Location = new System.Drawing.Point(893, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(67, 52);
            this.panel1.TabIndex = 32;
            // 
            // txtFiltered
            // 
            this.txtFiltered.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtFiltered.Location = new System.Drawing.Point(301, 164);
            this.txtFiltered.Name = "txtFiltered";
            this.txtFiltered.Size = new System.Drawing.Size(103, 39);
            this.txtFiltered.TabIndex = 27;
            this.txtFiltered.Text = "Search";
            this.txtFiltered.UseVisualStyleBackColor = false;
            this.txtFiltered.Click += new System.EventHandler(this.txtFiltered_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(210, 20);
            this.label4.TabIndex = 25;
            this.label4.Text = "Search by Ingredient Name: ";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSave.Location = new System.Drawing.Point(829, 553);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(138, 60);
            this.btnSave.TabIndex = 22;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dgvIngredientsProducts
            // 
            this.dgvIngredientsProducts.AllowUserToAddRows = false;
            this.dgvIngredientsProducts.AllowUserToDeleteRows = false;
            this.dgvIngredientsProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIngredientsProducts.Location = new System.Drawing.Point(524, 209);
            this.dgvIngredientsProducts.Name = "dgvIngredientsProducts";
            this.dgvIngredientsProducts.ReadOnly = true;
            this.dgvIngredientsProducts.RowHeadersWidth = 62;
            this.dgvIngredientsProducts.RowTemplate.Height = 28;
            this.dgvIngredientsProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvIngredientsProducts.Size = new System.Drawing.Size(430, 182);
            this.dgvIngredientsProducts.TabIndex = 21;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(25, 170);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(270, 26);
            this.txtSearch.TabIndex = 20;
            // 
            // dgvIngredients
            // 
            this.dgvIngredients.AllowUserToAddRows = false;
            this.dgvIngredients.AllowUserToDeleteRows = false;
            this.dgvIngredients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIngredients.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Ingredientname});
            this.dgvIngredients.Location = new System.Drawing.Point(25, 209);
            this.dgvIngredients.Name = "dgvIngredients";
            this.dgvIngredients.ReadOnly = true;
            this.dgvIngredients.RowHeadersWidth = 62;
            this.dgvIngredients.RowTemplate.Height = 28;
            this.dgvIngredients.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvIngredients.Size = new System.Drawing.Size(443, 182);
            this.dgvIngredients.TabIndex = 18;
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
            // Ingredientname
            // 
            this.Ingredientname.DataPropertyName = "Name";
            this.Ingredientname.HeaderText = "Ingredient Name";
            this.Ingredientname.MinimumWidth = 8;
            this.Ingredientname.Name = "Ingredientname";
            this.Ingredientname.ReadOnly = true;
            this.Ingredientname.Width = 150;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 38F);
            this.label1.Location = new System.Drawing.Point(12, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(800, 86);
            this.label1.TabIndex = 19;
            this.label1.Text = "Ingredients for Product";
            // 
            // btnRemove
            // 
            this.btnRemove.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnRemove.Location = new System.Drawing.Point(850, 437);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(104, 39);
            this.btnRemove.TabIndex = 23;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = false;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnModify
            // 
            this.btnModify.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnModify.Location = new System.Drawing.Point(740, 437);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(104, 39);
            this.btnModify.TabIndex = 22;
            this.btnModify.Text = "Modify";
            this.btnModify.UseVisualStyleBackColor = false;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(617, 407);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(227, 20);
            this.label5.TabIndex = 21;
            this.label5.Text = "Measure of selected ingredient";
            // 
            // numModify
            // 
            this.numModify.Location = new System.Drawing.Point(850, 405);
            this.numModify.Name = "numModify";
            this.numModify.Size = new System.Drawing.Size(104, 26);
            this.numModify.TabIndex = 20;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAdd.Location = new System.Drawing.Point(364, 437);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(104, 39);
            this.btnAdd.TabIndex = 19;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 407);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(290, 20);
            this.label2.TabIndex = 18;
            this.label2.Text = "Choose measure of selected ingredient:";
            // 
            // numMeasure
            // 
            this.numMeasure.Location = new System.Drawing.Point(364, 405);
            this.numMeasure.Name = "numMeasure";
            this.numMeasure.Size = new System.Drawing.Size(104, 26);
            this.numMeasure.TabIndex = 17;
            // 
            // frmIngredientsProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(979, 625);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnModify);
            this.Controls.Add(this.txtFiltered);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numModify);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvIngredientsProducts);
            this.Controls.Add(this.numMeasure);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.dgvIngredients);
            this.Controls.Add(this.label1);
            this.Name = "frmIngredientsProduct";
            this.Text = "frmIngredientsProduct";
            this.Load += new System.EventHandler(this.frmIngredientsProduct_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvIngredientsProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIngredients)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numModify)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMeasure)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button txtFiltered;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridView dgvIngredientsProducts;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DataGridView dgvIngredients;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ingredientname;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnModify;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numModify;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numMeasure;
    }
}