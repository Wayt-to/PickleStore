namespace PickleMainStoreApp.Forms
{
    partial class CategoryAndBrandsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CategoryAndBrandsForm));
            this.tsmi_delete = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_catClear = new System.Windows.Forms.Button();
            this.btn_catSave = new System.Windows.Forms.Button();
            this.check_CatActive = new System.Windows.Forms.CheckBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmi_edit = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridBrand = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_catName = new System.Windows.Forms.TextBox();
            this.tb_catDescription = new System.Windows.Forms.TextBox();
            this.tb_catID = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tb_whoCat = new System.Windows.Forms.TextBox();
            this.dataGridCategory = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_brandClear = new System.Windows.Forms.Button();
            this.btn_brandSave = new System.Windows.Forms.Button();
            this.check_brandActive = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tb_brandName = new System.Windows.Forms.TextBox();
            this.tb_brandID = new System.Windows.Forms.TextBox();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmi_edit2 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_delete2 = new System.Windows.Forms.ToolStripMenuItem();
            this.label8 = new System.Windows.Forms.Label();
            this.tb_whoBrand = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridBrand)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCategory)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsmi_delete
            // 
            this.tsmi_delete.Name = "tsmi_delete";
            this.tsmi_delete.Size = new System.Drawing.Size(116, 22);
            this.tsmi_delete.Text = "Sil";
            this.tsmi_delete.Click += new System.EventHandler(this.tsmi_delete_Click);
            // 
            // btn_catClear
            // 
            this.btn_catClear.BackColor = System.Drawing.Color.Teal;
            this.btn_catClear.FlatAppearance.BorderSize = 0;
            this.btn_catClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_catClear.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_catClear.ForeColor = System.Drawing.Color.White;
            this.btn_catClear.Location = new System.Drawing.Point(352, 219);
            this.btn_catClear.Name = "btn_catClear";
            this.btn_catClear.Size = new System.Drawing.Size(144, 36);
            this.btn_catClear.TabIndex = 4;
            this.btn_catClear.Text = "Temizle";
            this.btn_catClear.UseVisualStyleBackColor = false;
            this.btn_catClear.Click += new System.EventHandler(this.btn_catClear_Click);
            // 
            // btn_catSave
            // 
            this.btn_catSave.BackColor = System.Drawing.Color.YellowGreen;
            this.btn_catSave.FlatAppearance.BorderSize = 0;
            this.btn_catSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_catSave.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_catSave.Location = new System.Drawing.Point(502, 219);
            this.btn_catSave.Name = "btn_catSave";
            this.btn_catSave.Size = new System.Drawing.Size(144, 36);
            this.btn_catSave.TabIndex = 4;
            this.btn_catSave.Text = "Kaydet";
            this.btn_catSave.UseVisualStyleBackColor = false;
            this.btn_catSave.Click += new System.EventHandler(this.btn_catSave_Click);
            // 
            // check_CatActive
            // 
            this.check_CatActive.AutoSize = true;
            this.check_CatActive.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.check_CatActive.Location = new System.Drawing.Point(237, 213);
            this.check_CatActive.Name = "check_CatActive";
            this.check_CatActive.Size = new System.Drawing.Size(56, 22);
            this.check_CatActive.TabIndex = 2;
            this.check_CatActive.Text = "Aktif";
            this.check_CatActive.UseVisualStyleBackColor = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_edit,
            this.tsmi_delete});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(117, 48);
            // 
            // tsmi_edit
            // 
            this.tsmi_edit.Name = "tsmi_edit";
            this.tsmi_edit.Size = new System.Drawing.Size(116, 22);
            this.tsmi_edit.Text = "Düzenle";
            this.tsmi_edit.Click += new System.EventHandler(this.tsmi_edit_Click);
            // 
            // dataGridBrand
            // 
            this.dataGridBrand.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dataGridBrand.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridBrand.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridBrand.Location = new System.Drawing.Point(690, 305);
            this.dataGridBrand.Name = "dataGridBrand";
            this.dataGridBrand.ReadOnly = true;
            this.dataGridBrand.Size = new System.Drawing.Size(659, 299);
            this.dataGridBrand.TabIndex = 4;
            this.dataGridBrand.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridBrand_MouseClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 18);
            this.label3.TabIndex = 1;
            this.label3.Text = "Kategori Adı";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(85, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "ID";
            // 
            // tb_catName
            // 
            this.tb_catName.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_catName.Location = new System.Drawing.Point(110, 77);
            this.tb_catName.Name = "tb_catName";
            this.tb_catName.Size = new System.Drawing.Size(183, 31);
            this.tb_catName.TabIndex = 0;
            // 
            // tb_catDescription
            // 
            this.tb_catDescription.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_catDescription.Location = new System.Drawing.Point(110, 114);
            this.tb_catDescription.Multiline = true;
            this.tb_catDescription.Name = "tb_catDescription";
            this.tb_catDescription.Size = new System.Drawing.Size(183, 93);
            this.tb_catDescription.TabIndex = 0;
            // 
            // tb_catID
            // 
            this.tb_catID.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_catID.Location = new System.Drawing.Point(110, 40);
            this.tb_catID.Name = "tb_catID";
            this.tb_catID.ReadOnly = true;
            this.tb_catID.Size = new System.Drawing.Size(183, 31);
            this.tb_catID.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(41, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 18);
            this.label4.TabIndex = 1;
            this.label4.Text = "Açıklama";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_catClear);
            this.groupBox1.Controls.Add(this.btn_catSave);
            this.groupBox1.Controls.Add(this.check_CatActive);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tb_catName);
            this.groupBox1.Controls.Add(this.tb_catDescription);
            this.groupBox1.Controls.Add(this.tb_whoCat);
            this.groupBox1.Controls.Add(this.tb_catID);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Font = new System.Drawing.Font("Calibri", 11.25F);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(13, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(662, 271);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Kategori Bilgileri";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(349, 47);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(108, 18);
            this.label7.TabIndex = 1;
            this.label7.Text = "Son Düzenleyen";
            // 
            // tb_whoCat
            // 
            this.tb_whoCat.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_whoCat.Location = new System.Drawing.Point(463, 40);
            this.tb_whoCat.Name = "tb_whoCat";
            this.tb_whoCat.ReadOnly = true;
            this.tb_whoCat.Size = new System.Drawing.Size(183, 31);
            this.tb_whoCat.TabIndex = 0;
            // 
            // dataGridCategory
            // 
            this.dataGridCategory.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dataGridCategory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridCategory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridCategory.Location = new System.Drawing.Point(13, 305);
            this.dataGridCategory.Name = "dataGridCategory";
            this.dataGridCategory.ReadOnly = true;
            this.dataGridCategory.Size = new System.Drawing.Size(662, 299);
            this.dataGridCategory.TabIndex = 4;
            this.dataGridCategory.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridCategory_MouseClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_brandClear);
            this.groupBox2.Controls.Add(this.btn_brandSave);
            this.groupBox2.Controls.Add(this.check_brandActive);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.tb_brandName);
            this.groupBox2.Controls.Add(this.tb_brandID);
            this.groupBox2.Controls.Add(this.tb_whoBrand);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox2.Font = new System.Drawing.Font("Calibri", 11.25F);
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(690, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(662, 271);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Marka Bilgileri";
            // 
            // btn_brandClear
            // 
            this.btn_brandClear.BackColor = System.Drawing.Color.Teal;
            this.btn_brandClear.FlatAppearance.BorderSize = 0;
            this.btn_brandClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_brandClear.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_brandClear.ForeColor = System.Drawing.Color.White;
            this.btn_brandClear.Location = new System.Drawing.Point(352, 219);
            this.btn_brandClear.Name = "btn_brandClear";
            this.btn_brandClear.Size = new System.Drawing.Size(144, 36);
            this.btn_brandClear.TabIndex = 4;
            this.btn_brandClear.Text = "Temizle";
            this.btn_brandClear.UseVisualStyleBackColor = false;
            this.btn_brandClear.Click += new System.EventHandler(this.btn_brandClear_Click);
            // 
            // btn_brandSave
            // 
            this.btn_brandSave.BackColor = System.Drawing.Color.YellowGreen;
            this.btn_brandSave.FlatAppearance.BorderSize = 0;
            this.btn_brandSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_brandSave.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_brandSave.Location = new System.Drawing.Point(502, 219);
            this.btn_brandSave.Name = "btn_brandSave";
            this.btn_brandSave.Size = new System.Drawing.Size(144, 36);
            this.btn_brandSave.TabIndex = 4;
            this.btn_brandSave.Text = "Kaydet";
            this.btn_brandSave.UseVisualStyleBackColor = false;
            this.btn_brandSave.Click += new System.EventHandler(this.btn_brandSave_Click);
            // 
            // check_brandActive
            // 
            this.check_brandActive.AutoSize = true;
            this.check_brandActive.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.check_brandActive.Location = new System.Drawing.Point(259, 151);
            this.check_brandActive.Name = "check_brandActive";
            this.check_brandActive.Size = new System.Drawing.Size(56, 22);
            this.check_brandActive.TabIndex = 2;
            this.check_brandActive.Text = "Aktif";
            this.check_brandActive.UseVisualStyleBackColor = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(57, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 18);
            this.label5.TabIndex = 1;
            this.label5.Text = "Marka Adı";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(107, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(21, 18);
            this.label6.TabIndex = 1;
            this.label6.Text = "ID";
            // 
            // tb_brandName
            // 
            this.tb_brandName.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_brandName.Location = new System.Drawing.Point(132, 77);
            this.tb_brandName.Name = "tb_brandName";
            this.tb_brandName.Size = new System.Drawing.Size(183, 31);
            this.tb_brandName.TabIndex = 0;
            // 
            // tb_brandID
            // 
            this.tb_brandID.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_brandID.Location = new System.Drawing.Point(132, 40);
            this.tb_brandID.Name = "tb_brandID";
            this.tb_brandID.ReadOnly = true;
            this.tb_brandID.Size = new System.Drawing.Size(183, 31);
            this.tb_brandID.TabIndex = 0;
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_edit2,
            this.tsmi_delete2});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(117, 48);
            // 
            // tsmi_edit2
            // 
            this.tsmi_edit2.Name = "tsmi_edit2";
            this.tsmi_edit2.Size = new System.Drawing.Size(116, 22);
            this.tsmi_edit2.Text = "Düzenle";
            this.tsmi_edit2.Click += new System.EventHandler(this.tsmi_edit2_Click);
            // 
            // tsmi_delete2
            // 
            this.tsmi_delete2.Name = "tsmi_delete2";
            this.tsmi_delete2.Size = new System.Drawing.Size(116, 22);
            this.tsmi_delete2.Text = "Sil";
            this.tsmi_delete2.Click += new System.EventHandler(this.tsmi_delete2_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 121);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(108, 18);
            this.label8.TabIndex = 1;
            this.label8.Text = "Son Düzenleyen";
            // 
            // tb_whoBrand
            // 
            this.tb_whoBrand.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_whoBrand.Location = new System.Drawing.Point(132, 114);
            this.tb_whoBrand.Name = "tb_whoBrand";
            this.tb_whoBrand.ReadOnly = true;
            this.tb_whoBrand.Size = new System.Drawing.Size(183, 31);
            this.tb_whoBrand.TabIndex = 0;
            // 
            // CategoryAndBrandsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1373, 616);
            this.Controls.Add(this.dataGridCategory);
            this.Controls.Add(this.dataGridBrand);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CategoryAndBrandsForm";
            this.Text = "Kategoriler ve Markalar Formu";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridBrand)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCategory)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.contextMenuStrip2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem tsmi_delete;
        private System.Windows.Forms.Button btn_catClear;
        private System.Windows.Forms.Button btn_catSave;
        private System.Windows.Forms.CheckBox check_CatActive;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmi_edit;
        private System.Windows.Forms.DataGridView dataGridBrand;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_catName;
        private System.Windows.Forms.TextBox tb_catDescription;
        private System.Windows.Forms.TextBox tb_catID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridCategory;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_brandClear;
        private System.Windows.Forms.Button btn_brandSave;
        private System.Windows.Forms.CheckBox check_brandActive;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tb_brandName;
        private System.Windows.Forms.TextBox tb_brandID;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tb_whoCat;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem tsmi_edit2;
        private System.Windows.Forms.ToolStripMenuItem tsmi_delete2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tb_whoBrand;
    }
}