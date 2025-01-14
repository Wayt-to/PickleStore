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

namespace PickleMainStoreApp.Forms
{
    public partial class PurchasesForm : Form
    {
        GeneralDataModel dm = new GeneralDataModel();
        PickleStoreModel db = new PickleStoreModel();
        Employee _user;
        int rowIndex = -1;
        double total;
        public PurchasesForm(Employee user)
        {
            InitializeComponent();
            dm.LoadPurchases(dataGridView1);
            cb_product.DataSource = db.Products.Where(p => p.IsActive).ToList();
            cb_product.DisplayMember = "ProductName";
            cb_product.ValueMember = "ID";
            cb_supplier.DataSource = db.Suppliers.Where(c => c.IsActive).ToList();
            cb_supplier.DisplayMember = "CompanyName";
            cb_supplier.ValueMember = "ID";
            _user = user;
            
            
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
        private void tsmi_pdf_Click(object sender, EventArgs e)
        {
            dm.SaveSelectedRowPdf(dataGridView1, "Alış İrsaliye Formu");
        }
        private void btn_clear_Click(object sender, EventArgs e)
        {
            dm.ClearAllControls(this);
        }
        private void cb_product_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_product.SelectedValue!=null)
            {
                int prodID = (int)cb_product.SelectedValue;
                Product p = db.Products.Find(prodID);
                tb_brand.Text = p.Brand.Name;
                tb_barcode.Text = p.Barcode;
                tb_category.Text = p.Category.Name;
                total = (double)(tb_price.Value * tb_quantity.Value);
                tb_total.Text = total.ToString();
            }
            
        }
        private void tb_quantity_ValueChanged_1(object sender, EventArgs e)
        {
            total = (double)(tb_price.Value * tb_quantity.Value);
            tb_total.Text = total.ToString();
        }
        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Alımı silmek istediğinize emin misiniz?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (rowIndex != -1)
                {
                    int id = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells["ID"].Value);
                    Purchase s = db.Purchases.Find(id);
                    try
                    {
                        s.IsActive = false;
                        s.IsDeleted = true;
                        db.SaveChanges();
                        MessageBox.Show("Alımı silme işlemi başarılı.", "İşlem Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        dm.LoadPurchases(dataGridView1);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Alımı silme işlemi başarısız : " + ex.Message, "İşlem Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void btn_save_Click(object sender, EventArgs e)
        {
            if (tb_id.Text != "")
            {
                
                if (string.IsNullOrWhiteSpace(tb_barcode.Text) || string.IsNullOrWhiteSpace(cb_product.Text) ||
                string.IsNullOrWhiteSpace(tb_price.Text) || string.IsNullOrWhiteSpace(tb_quantity.Text) || tb_docTime.Text == "__/__/____ __:__" || tb_saleTime.Text == "__/__/____ __:__" || string.IsNullOrWhiteSpace(tb_total.Text))
                {
                    MessageBox.Show("Lütfen tüm alanları doldurduğunuzdan emin olun.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    Purchase s = db.Purchases.Find(Convert.ToInt32(tb_id.Text));
                    s.Product_ID = (int)(cb_product.SelectedValue);
                    Product p = db.Products.Find(s.Product_ID);
                    p.Stock -= Convert.ToInt16(s.Quantity);
                    s.Quantity = (int)(tb_quantity.Value);
                    if (!string.IsNullOrEmpty(tb_description.Text)) s.Description = tb_description.Text;
                    s.Price = Convert.ToDouble(tb_price.Value);
                    s.Supplier_ID = (int)(cb_supplier.SelectedValue);
                    s.Employee_ID = _user.ID;
                    s.TotalPrice = Convert.ToDouble(tb_total.Text);
                    s.IsActive = check_isActive.Checked;
                    if (s.IsActive) s.IsDeleted = false;
                    s.DocEditTime = DateTime.Now;
                    p.Stock += Convert.ToInt16(tb_quantity.Value);
                    try
                    {
                        db.SaveChanges();
                        MessageBox.Show("Alış düzenleme işlemi başarılı.", "İşlem Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        dm.LoadPurchases(dataGridView1);
                        tb_total.Enabled = false;
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show("Alış düzenlenemedi: " + ex.Message, "İşlem Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    Purchase s = new Purchase();
                    s.Product_ID = (int)(cb_product.SelectedValue);
                    Product p = db.Products.Find(s.Product_ID);
                    s.Quantity = (int)(tb_quantity.Value);
                    if (!string.IsNullOrEmpty(tb_description.Text)) s.Description = tb_description.Text;
                    s.Price = Convert.ToDouble(tb_price.Value);
                    s.Supplier_ID = (int)(cb_supplier.SelectedValue);
                    s.Employee_ID = _user.ID;
                    s.TotalPrice = Convert.ToDouble(tb_total.Text);
                    s.IsActive = check_isActive.Checked;
                    if (s.IsActive) s.IsDeleted = false;
                    s.PurchaseTime = DateTime.Now; s.DocEditTime = DateTime.Now;
                    p.Stock += Convert.ToInt16(tb_quantity.Value);
                    db.Purchases.Add(s);
                    try
                    {
                        db.SaveChanges();
                        MessageBox.Show("Alış ekleme işlemi başarılı.", "İşlem Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        dm.LoadPurchases(dataGridView1);
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show("Alış eklenemedi: " + ex.Message, "İşlem Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
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
                        Purchase s = db.Purchases.Find(id);
                        if (s.Product.IsActive)
                        {
                            cb_product.DataSource = db.Products.ToList();
                            cb_product.DisplayMember = "ProductName";
                            cb_product.ValueMember = "ID";
                        }
                        if (s.Supplier.IsActive)
                        {
                            cb_supplier.DataSource = db.Suppliers.ToList();
                            cb_supplier.DisplayMember = "CompanyName";
                            cb_supplier.ValueMember = "ID";
                        }
                        if (s != null)
                        {
                            tb_id.Text = s.ID.ToString();
                            cb_product.SelectedValue = s.Product_ID;
                            tb_barcode.Text = s.Product.Barcode;
                            tb_description.Text = s.Description;
                            tb_price.Text = s.Price.ToString();
                            tb_quantity.Text = s.Quantity.ToString();
                            tb_saleTime.Text = s.PurchaseTime.ToString("dd/MM/yyyy HH:mm");
                            tb_docTime.Text = s.DocEditTime.ToString("dd/MM/yyyy HH:mm");
                            cb_supplier.SelectedValue = s.Supplier_ID;
                            tb_whosaved.Text = s.Employee.Name;
                            check_isActive.Checked = s.IsActive;
                            tb_total.Text = s.TotalPrice.ToString();
                            if (cb_product.SelectedValue != null)
                            {
                                int prodID = (int)cb_product.SelectedValue;
                                Product p = db.Products.Find(prodID);
                                tb_brand.Text = p.Brand.Name;
                                tb_barcode.Text = p.Barcode;
                                tb_category.Text = p.Category.Name;
                                total = (double)(tb_price.Value * tb_quantity.Value);
                                tb_total.Text = total.ToString();
                            }
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
                    Purchase s = db.Purchases.Find(id);
                    if (!s.Product.IsActive)
                    {
                        cb_product.DataSource = db.Products.ToList();
                        cb_product.DisplayMember = "ProductName";
                        cb_product.ValueMember = "ID";
                    }
                    if (!s.Supplier.IsActive)
                    {
                        cb_supplier.DataSource = db.Suppliers.ToList();
                        cb_supplier.DisplayMember = "CompanyName";
                        cb_supplier.ValueMember = "ID";
                    }
                    if (s != null)
                    {
                        tb_id.Text = s.ID.ToString();
                        cb_product.SelectedValue = s.Product_ID;
                        tb_barcode.Text = s.Product.Barcode;
                        tb_description.Text = s.Description;
                        tb_price.Text = s.Price.ToString();
                        tb_quantity.Text = s.Quantity.ToString();
                        tb_saleTime.Text = s.PurchaseTime.ToString("dd/MM/yyyy HH:mm");
                        tb_docTime.Text = s.DocEditTime.ToString("dd/MM/yyyy HH:mm");
                        cb_supplier.SelectedValue = s.Supplier_ID;
                        tb_whosaved.Text = s.Employee.Name;
                        check_isActive.Checked = s.IsActive;
                        tb_total.Text = s.TotalPrice.ToString();
                        if (cb_product.SelectedValue != null)
                        {
                            int prodID = (int)cb_product.SelectedValue;
                            Product p = db.Products.Find(prodID);
                            tb_brand.Text = p.Brand.Name;
                            tb_barcode.Text = p.Barcode;
                            tb_category.Text = p.Category.Name;
                            total = (double)(tb_price.Value * tb_quantity.Value);
                            tb_total.Text = total.ToString();
                        }
                    }
                }
            }
        }
        private void tb_price_ValueChanged(object sender, EventArgs e)
        {
            total = (double)(tb_price.Value * tb_quantity.Value);
            tb_total.Text = total.ToString();
        }

        private void PurchasesForm_Activated(object sender, EventArgs e)
        {
            dm.LoadPurchases(dataGridView1);
            cb_product.DataSource = db.Products.Where(p => p.IsActive).ToList();
            cb_product.DisplayMember = "ProductName";
            cb_product.ValueMember = "ID";
            cb_supplier.DataSource = db.Suppliers.Where(c => c.IsActive).ToList();
            cb_supplier.DisplayMember = "CompanyName";
            cb_supplier.ValueMember = "ID";
        }
    }
}
