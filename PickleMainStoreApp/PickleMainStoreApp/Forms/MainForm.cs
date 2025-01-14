using PickleMainStoreApp.Forms;
using PickleMainStoreApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PickleMainStoreApp
{
    
    public partial class MainForm : Form
    {
        PickleStoreModel db = new PickleStoreModel();
        public Employee _user;
        public MainForm()
        {
            InitializeComponent();
        }

        public MainForm(Employee user)
        {
            InitializeComponent();
            
            tssl_user.Text ="Mevcut kullanıcı : " + user.Username;
            _user = user;
            if (user.Type=="Çalışan")
            {
                tsb_employees.Enabled = false;
            }
        }
        #region FromOpens
        public void FormOpen(Form frm)
        {
            Form[] forms = this.MdiChildren;
            bool isopen = false;
            Type type = frm.GetType();
            foreach (Form item in forms)
            {
                if (item.GetType() == frm.GetType())
                {
                    isopen = true;
                    item.Activate();
                }
            }
            if (!isopen)
            {
                frm.MdiParent = this;
                frm.Show();
            }
        }
        
        private void tsb_products_Click(object sender, EventArgs e)
        {
            FormOpen(new ProductsForm(_user));
            
        }

        private void tsb_catandbrands_Click(object sender, EventArgs e)
        {
            FormOpen(new CategoryAndBrandsForm(_user));
        }
        
        private void tsb_employees_Click(object sender, EventArgs e)
        {
            FormOpen(new EmployeesForm(_user));
        }

        private void tsb_sales_Click(object sender, EventArgs e)
        {
            FormOpen(new SalesForm(_user));
        }

        private void tsb_suppliers_Click(object sender, EventArgs e)
        {
            FormOpen(new SuppliersForm(_user));
        }

        private void tsb_purchases_Click(object sender, EventArgs e)
        {
            FormOpen(new PurchasesForm(_user));
        }

        private void tsb_customers_Click(object sender, EventArgs e)
        {
            FormOpen(new CustomersForm(_user));
        }

        private void tsb_help_Click(object sender, EventArgs e)
        {
            FormOpen(new HelpForm());
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            db.Dispose();
            Application.Exit();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            
        }
        #endregion

        
    }
}
