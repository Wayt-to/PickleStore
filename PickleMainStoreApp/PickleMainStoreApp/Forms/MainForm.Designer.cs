namespace PickleMainStoreApp
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsb_products = new System.Windows.Forms.ToolStripButton();
            this.tsb_catandbrands = new System.Windows.Forms.ToolStripButton();
            this.tsb_sales = new System.Windows.Forms.ToolStripButton();
            this.tsb_purchases = new System.Windows.Forms.ToolStripButton();
            this.tsb_suppliers = new System.Windows.Forms.ToolStripButton();
            this.tsb_customers = new System.Windows.Forms.ToolStripButton();
            this.tsb_employees = new System.Windows.Forms.ToolStripButton();
            this.tsb_help = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tssl_user = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.toolStrip1.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsb_products,
            this.tsb_catandbrands,
            this.tsb_sales,
            this.tsb_purchases,
            this.tsb_suppliers,
            this.tsb_customers,
            this.tsb_employees,
            this.tsb_help});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1378, 45);
            this.toolStrip1.Stretch = true;
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsb_products
            // 
            this.tsb_products.AutoSize = false;
            this.tsb_products.ForeColor = System.Drawing.SystemColors.Control;
            this.tsb_products.Image = ((System.Drawing.Image)(resources.GetObject("tsb_products.Image")));
            this.tsb_products.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_products.Margin = new System.Windows.Forms.Padding(195, 0, 0, 0);
            this.tsb_products.Name = "tsb_products";
            this.tsb_products.Size = new System.Drawing.Size(100, 45);
            this.tsb_products.Text = "Ürünler";
            this.tsb_products.Click += new System.EventHandler(this.tsb_products_Click);
            // 
            // tsb_catandbrands
            // 
            this.tsb_catandbrands.ForeColor = System.Drawing.SystemColors.Control;
            this.tsb_catandbrands.Image = ((System.Drawing.Image)(resources.GetObject("tsb_catandbrands.Image")));
            this.tsb_catandbrands.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_catandbrands.Margin = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.tsb_catandbrands.Name = "tsb_catandbrands";
            this.tsb_catandbrands.Size = new System.Drawing.Size(182, 45);
            this.tsb_catandbrands.Text = "Kategoriler ve Markalar";
            this.tsb_catandbrands.Click += new System.EventHandler(this.tsb_catandbrands_Click);
            // 
            // tsb_sales
            // 
            this.tsb_sales.ForeColor = System.Drawing.SystemColors.Control;
            this.tsb_sales.Image = ((System.Drawing.Image)(resources.GetObject("tsb_sales.Image")));
            this.tsb_sales.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_sales.Margin = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.tsb_sales.Name = "tsb_sales";
            this.tsb_sales.Size = new System.Drawing.Size(87, 45);
            this.tsb_sales.Text = "Satışlar";
            this.tsb_sales.Click += new System.EventHandler(this.tsb_sales_Click);
            // 
            // tsb_purchases
            // 
            this.tsb_purchases.ForeColor = System.Drawing.SystemColors.Control;
            this.tsb_purchases.Image = ((System.Drawing.Image)(resources.GetObject("tsb_purchases.Image")));
            this.tsb_purchases.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_purchases.Margin = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.tsb_purchases.Name = "tsb_purchases";
            this.tsb_purchases.Size = new System.Drawing.Size(84, 45);
            this.tsb_purchases.Text = "Alımlar";
            this.tsb_purchases.Click += new System.EventHandler(this.tsb_purchases_Click);
            // 
            // tsb_suppliers
            // 
            this.tsb_suppliers.ForeColor = System.Drawing.SystemColors.Control;
            this.tsb_suppliers.Image = ((System.Drawing.Image)(resources.GetObject("tsb_suppliers.Image")));
            this.tsb_suppliers.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_suppliers.Margin = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.tsb_suppliers.Name = "tsb_suppliers";
            this.tsb_suppliers.Size = new System.Drawing.Size(111, 45);
            this.tsb_suppliers.Text = "Tedarikçiler";
            this.tsb_suppliers.Click += new System.EventHandler(this.tsb_suppliers_Click);
            // 
            // tsb_customers
            // 
            this.tsb_customers.ForeColor = System.Drawing.SystemColors.Control;
            this.tsb_customers.Image = ((System.Drawing.Image)(resources.GetObject("tsb_customers.Image")));
            this.tsb_customers.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_customers.Margin = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.tsb_customers.Name = "tsb_customers";
            this.tsb_customers.Size = new System.Drawing.Size(105, 45);
            this.tsb_customers.Text = "Müşteriler";
            this.tsb_customers.Click += new System.EventHandler(this.tsb_customers_Click);
            // 
            // tsb_employees
            // 
            this.tsb_employees.ForeColor = System.Drawing.SystemColors.Control;
            this.tsb_employees.Image = ((System.Drawing.Image)(resources.GetObject("tsb_employees.Image")));
            this.tsb_employees.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_employees.Margin = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.tsb_employees.Name = "tsb_employees";
            this.tsb_employees.Size = new System.Drawing.Size(100, 45);
            this.tsb_employees.Text = "Çalışanlar";
            this.tsb_employees.Click += new System.EventHandler(this.tsb_employees_Click);
            // 
            // tsb_help
            // 
            this.tsb_help.ForeColor = System.Drawing.SystemColors.Control;
            this.tsb_help.Image = ((System.Drawing.Image)(resources.GetObject("tsb_help.Image")));
            this.tsb_help.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_help.Margin = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.tsb_help.Name = "tsb_help";
            this.tsb_help.Size = new System.Drawing.Size(84, 45);
            this.tsb_help.Text = "Yardım";
            this.tsb_help.Click += new System.EventHandler(this.tsb_help_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssl_user});
            this.statusStrip1.Location = new System.Drawing.Point(0, 689);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1378, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tssl_user
            // 
            this.tssl_user.BackColor = System.Drawing.SystemColors.Control;
            this.tssl_user.Name = "tssl_user";
            this.tssl_user.Size = new System.Drawing.Size(118, 17);
            this.tssl_user.Text = "toolStripStatusLabel1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1378, 711);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MaximumSize = new System.Drawing.Size(1394, 775);
            this.Name = "MainForm";
            this.Text = "PickleApp";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsb_products;
        private System.Windows.Forms.ToolStripButton tsb_catandbrands;
        private System.Windows.Forms.ToolStripButton tsb_employees;
        private System.Windows.Forms.ToolStripButton tsb_sales;
        private System.Windows.Forms.ToolStripButton tsb_purchases;
        private System.Windows.Forms.ToolStripButton tsb_suppliers;
        private System.Windows.Forms.ToolStripButton tsb_customers;
        private System.Windows.Forms.ToolStripButton tsb_help;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tssl_user;
    }
}