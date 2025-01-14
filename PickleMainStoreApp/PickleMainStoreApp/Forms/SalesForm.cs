using PickleMainStoreApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using Font = iTextSharp.text.Font;
using System.Xml;

namespace PickleMainStoreApp.Forms
{
    public partial class SalesForm : Form
    {
        int rowIndex = -1;
        double total;
        GeneralDataModel dm = new GeneralDataModel();
        PickleStoreModel db = new PickleStoreModel();
        Employee _user = new Employee();
        public SalesForm(Employee user)
        {
            InitializeComponent();
            dm.LoadSales(dataGridView1);
            cb_costumer.DataSource = db.Customers.Where(c => c.IsActive).ToList();
            cb_costumer.DisplayMember = "Name";
            cb_costumer.ValueMember = "ID";
            Customer cus = db.Customers.Find(cb_costumer.SelectedValue);
            tb_discount.Text = "%" + (cus.Type.Discount * 100).ToString();
            cb_product.DataSource = db.Products.Where(p => p.IsActive).ToList();
            cb_product.DisplayMember = "ProductName";
            cb_product.ValueMember = "ID";
            _user = user;
        }
        private void SalesForm_Activated(object sender, EventArgs e)
        {
            dm.LoadSales(dataGridView1);
            cb_costumer.DataSource = db.Customers.Where(c => c.IsActive).ToList();
            cb_costumer.DisplayMember = "Name";
            cb_costumer.ValueMember = "ID";
            Customer cus = db.Customers.Find(cb_costumer.SelectedValue);
            tb_discount.Text = "%" + (cus.Type.Discount * 100).ToString();
            cb_product.DataSource = db.Products.Where(p => p.IsActive).ToList();
            cb_product.DisplayMember = "ProductName";
            cb_product.ValueMember = "ID";
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            dm.ClearAllControls(this);
            tb_total.Enabled = false;
            Customer cus = db.Customers.Find(cb_costumer.SelectedValue);
            tb_discount.Text = "%" + (cus.Type.Discount * 100).ToString();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (tb_id.Text!="")
            {
                if (string.IsNullOrWhiteSpace(tb_barcode.Text) || string.IsNullOrWhiteSpace(cb_product.Text) ||
                string.IsNullOrWhiteSpace(tb_price.Text) || string.IsNullOrWhiteSpace(tb_quantity.Text) || tb_docTime.Text == "__/__/____ __:__" || tb_saleTime.Text == "__/__/____ __:__" || string.IsNullOrWhiteSpace(tb_total.Text))
                {
                    MessageBox.Show("Lütfen tüm alanları doldurduğunuzdan emin olun.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (check_disApply.Checked)
                    {
                        Sale s = db.Sales.Find(Convert.ToInt32(tb_id.Text));
                        s.ProductId = (int)(cb_product.SelectedValue);
                        Product p = db.Products.Find(s.ProductId);
                        p.Stock += Convert.ToInt16(s.Quantity);
                        s.Quantity = (int)(tb_quantity.Value);
                        if (!string.IsNullOrEmpty(tb_description.Text)) s.Description = tb_description.Text;
                        s.Price = Convert.ToDouble(tb_price.Value);
                        s.CustomerId = (int)(cb_costumer.SelectedValue);
                        s.EmployeeId = _user.ID;
                        s.TotalPrice = Convert.ToDouble(tb_total.Text);
                        s.IsActive = check_isActive.Checked;
                        p.Stock -= Convert.ToInt16(s.Quantity);
                        if (s.IsActive) s.IsDeleted = false;
                        s.DocEditTime = DateTime.Now;
                        try
                        {
                            db.SaveChanges();
                            MessageBox.Show("Satış düzenleme işlemi başarılı.", "İşlem Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            dm.LoadSales(dataGridView1);
                            tb_total.Enabled = false;
                            
                        }
                        catch (Exception ex)
                        {

                            MessageBox.Show("Satış düzenlenemedi: " + ex.Message, "İşlem Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("İndirimi uyguladığınızdan emin olun.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                if (string.IsNullOrWhiteSpace(tb_barcode.Text) || string.IsNullOrWhiteSpace(cb_product.Text) ||
                string.IsNullOrWhiteSpace(tb_price.Text) || string.IsNullOrWhiteSpace(tb_quantity.Text))
                {
                    MessageBox.Show("Lütfen tüm alanları doldurduğunuzdan emin olun.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                   
                }
                else
                {
                    if (check_disApply.Checked)
                    {
                        Sale s = new Sale();
                        s.ProductId = (int)(cb_product.SelectedValue);
                        Product p = db.Products.Find(s.ProductId);
                        s.Quantity = (int)(tb_quantity.Value);
                        if (!string.IsNullOrEmpty(tb_description.Text)) s.Description = tb_description.Text;
                        s.Price = Convert.ToDouble(tb_price.Value) ;
                        s.CustomerId =(int)(cb_costumer.SelectedValue);
                        s.EmployeeId = _user.ID;
                        s.TotalPrice = Convert.ToDouble(tb_total.Text);
                        s.IsActive = check_isActive.Checked;
                        p.Stock -= Convert.ToInt16(s.Quantity);
                        if (s.IsActive) s.IsDeleted = false;
                        s.SaleTime = DateTime.Now;s.DocEditTime = DateTime.Now;
                        db.Sales.Add(s);
                        try
                        {
                            db.SaveChanges();
                            MessageBox.Show("Satış ekleme işlemi başarılı.", "İşlem Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            dm.LoadSales(dataGridView1);
                        }
                        catch (Exception ex)
                        {

                            MessageBox.Show("Satış eklenemedi: " + ex.Message, "İşlem Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("İndirimi uyguladığınızdan emin olun.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void cb_product_SelectedIndexChanged(object sender, EventArgs e)
        {
            int prodID = (int)cb_product.SelectedValue;
            Product p = db.Products.Find(prodID);

            tb_brand.Text = p.Brand.Name;
            tb_barcode.Text = p.Barcode;
            tb_category.Text = p.Category.Name;
            tb_price.Text = (p.Price).ToString();
            total = (double)(tb_price.Value * tb_quantity.Value);
            tb_total.Text = total.ToString();
            tb_quantity.Maximum = p.Stock;
        }

        private void tb_quantity_ValueChanged(object sender, EventArgs e)
        {
            total = (double)(tb_price.Value * tb_quantity.Value);
            check_disApply_CheckedChanged();
        }

        private void cb_costumer_SelectedIndexChanged(object sender, EventArgs e)
        {
            int customerID = (int)cb_costumer.SelectedValue;
            Customer ca = db.Customers.Find(customerID);
            tb_discount.Text = "%" + (ca.Type.Discount * 100).ToString();
            dm.LoadSales(dataGridView1);
        }
        //indirim uygulama fonksiyonlarım
        private void check_disApply_CheckedChanged(object sender, EventArgs e)
        {
            check_disApply_CheckedChanged();
        }
        public void check_disApply_CheckedChanged()
        {
            if (check_disApply.Checked)
            {
                int customerID = (int)cb_costumer.SelectedValue;
                Customer c = db.Customers.Find(customerID);
                if (c != null)
                {
                    total = (double)(tb_price.Value * tb_quantity.Value);
                    tb_total.Text = (total - (total) * c.Type.Discount).ToString();
                }
                else
                {
                    total = (double)(tb_price.Value * tb_quantity.Value);
                }
            }
            else
            {
                tb_total.Text = (total).ToString();
            }
        }
        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                rowIndex = dataGridView1.HitTest(e.X, e.Y).RowIndex;
                if (rowIndex >= 0)
                {
                    dataGridView1.ClearSelection();
                    dataGridView1.Rows[rowIndex].Selected = true;
                    contextMenuStrip1.Show(dataGridView1, e.X, e.Y);
                }
            }
        }
        private void tsmi_printPDF_Click(object sender, EventArgs e)
        {
            dm.SaveSelectedRowPdf(dataGridView1,"Satış İrsaliye Formu");
        }

        private void tsmi_edit_Click(object sender, EventArgs e)
        {
            if (tb_id.Text != "" && tb_barcode.Text != "" && tb_price.Text != "" && tb_description.Text != "")
            {
                if (MessageBox.Show("Ekranda kaydedilmeyen veri varsa silinecek, emin misiniz?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    tb_total.Enabled = true;
                    if (rowIndex != -1)
                    {
                        int id = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells["ID"].Value);
                        Sale s = db.Sales.Find(id);
                        if (!s.Product.IsActive)
                        {
                            cb_product.DataSource = db.Customers.ToList();
                            cb_product.DisplayMember = "ProductName";
                            cb_product.ValueMember = "ID";
                        }
                        if (!s.Customer.IsActive)
                        {
                            cb_costumer.DataSource = db.Customers.ToList();
                            cb_costumer.DisplayMember = "Name";
                            cb_costumer.ValueMember = "ID";
                        }
                        if (s != null)
                        {
                            tb_id.Text = s.ID.ToString();
                            cb_product.SelectedValue = s.ProductId;
                            tb_barcode.Text = s.Product.Barcode;
                            tb_description.Text = s.Description;
                            tb_price.Text = s.Price.ToString();
                            tb_quantity.Text = s.Quantity.ToString();
                            tb_saleTime.Text = s.SaleTime.ToString("dd/MM/yyyy HH:mm");
                            tb_docTime.Text = s.DocEditTime.ToString("dd/MM/yyyy HH:mm");
                            cb_costumer.SelectedValue = s.CustomerId;
                            tb_whosaved.Text = s.Employee?.Name ?? "";
                            tb_whosaved.Text = s.Employee.Name;
                            check_isActive.Checked = s.IsActive;
                            tb_total.Text = s.TotalPrice.ToString();
                            int prodID = (int)cb_product.SelectedValue;
                            Product p = db.Products.Find(prodID);
                            tb_brand.Text = p.Brand.Name;
                            tb_barcode.Text = p.Barcode;
                            tb_category.Text = p.Category.Name;
                            tb_price.Text = (p.Price).ToString();
                        }
                    }

                }
            }
            else
            {
                tb_total.Enabled = true;
                if (rowIndex != -1)
                {
                    int id = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells["ID"].Value);
                    Sale s = db.Sales.Find(id);
                    if (!s.Product.IsActive)
                    {
                        cb_product.DataSource = db.Customers.ToList();
                        cb_product.DisplayMember = "ProductName";
                        cb_product.ValueMember = "ID";
                    }
                    if (!s.Customer.IsActive)
                    {
                        cb_costumer.DataSource = db.Customers.ToList();
                        cb_costumer.DisplayMember = "Name";
                        cb_costumer.ValueMember = "ID";
                    }
                    if (s != null)
                    {
                        tb_id.Text = s.ID.ToString();
                        cb_product.SelectedValue = s.ProductId;
                        tb_barcode.Text = s.Product.Barcode;
                        tb_description.Text = s.Description;
                        tb_price.Text = s.Price.ToString();
                        tb_quantity.Text = s.Quantity.ToString();
                        tb_saleTime.Text = s.SaleTime.ToString("dd/MM/yyyy HH:mm");
                        tb_docTime.Text = s.DocEditTime.ToString("dd/MM/yyyy HH:mm");
                        cb_costumer.SelectedValue = s.CustomerId;
                        tb_whosaved.Text = s.Employee?.Name ?? "";
                        tb_total.Text = s.TotalPrice.ToString();
                        check_isActive.Checked = s.IsActive;
                        int prodID = (int)cb_product.SelectedValue;
                        Product p = db.Products.Find(prodID);
                        tb_brand.Text = p.Brand.Name;
                        tb_barcode.Text = p.Barcode;
                        tb_category.Text = p.Category.Name;
                        tb_price.Text = (p.Price).ToString();
                    }
                }

            }
        }
        
        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Satışı silmek istediğinize emin misiniz?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (rowIndex != -1)
                {
                    int id = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells["ID"].Value);
                    Sale s = db.Sales.Find(id);
                    try
                    {
                        s.IsActive = false;
                        s.IsDeleted = true;
                        db.SaveChanges();
                        MessageBox.Show("Satış silme işlemi başarılı.", "İşlem Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        dm.LoadSales(dataGridView1);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Satış silme işlemi başarısız : "+ex.Message, "İşlem Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

        }

        private void SalesForm_Load(object sender, EventArgs e)
        {
            dm.LoadSales(dataGridView1);
            cb_costumer.DataSource = db.Customers.Where(c => c.IsActive).ToList();
            cb_costumer.DisplayMember = "Name";
            cb_costumer.ValueMember = "ID";
            Customer cus = db.Customers.Find(cb_costumer.SelectedValue);
            tb_discount.Text = "%" + (cus.Type.Discount * 100).ToString();
            cb_product.DataSource = db.Products.Where(p => p.IsActive).ToList();
            cb_product.DisplayMember = "ProductName";
            cb_product.ValueMember = "ID";
        }

    }

}

